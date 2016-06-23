using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.MaterialOEM
{
    public partial class FrmReceiveNoteOper : Form
    {
        public FrmReceiveNoteOper()
        {
            InitializeComponent();
            this.accNotes = new JERPData.Material .OEMReceiveNotes();
            this.accItems = new JERPData.Material.OEMReceiveItems();
            this.accOrderItems = new JERPData.Material.OEMOrderItems();
            this.accStore = new JERPData.Material.OEMStore();
            this.OrderEntity = new JERPBiz.Material.OEMOrderNoteEntity();
            this.accRoadReserve = new JERPData.Material.OEMRoadStoreReserve(); 
            this.dgrdvItem.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdvItem;
            this.dgrdvItem .CellMouseClick +=new DataGridViewCellMouseEventHandler(dgrdvItem_CellMouseClick);   
            this.btnSave .Click +=new EventHandler(btnSave_Click);
        }
        private JERPData.Material.OEMReceiveNotes accNotes;
        private JERPData.Material.OEMReceiveItems accItems;
        private JERPData.Material.OEMOrderItems accOrderItems;
        private JERPData.Material.OEMStore accStore;
        private JERPData.Material.OEMRoadStoreReserve accRoadReserve; 
        private JERPBiz.Material.OEMOrderNoteEntity OrderEntity;
        private DataTable   dtblItems;     
     
        private long OEMOrderNoteID = -1;         
        public void NewNote(long  OEMOrderNoteID)
        {
            this.OEMOrderNoteID = OEMOrderNoteID;
            this.OrderEntity.LoadData(OEMOrderNoteID);
            this.txtPONo.Text = this.OrderEntity.NoteCode;
            this.txtCompanyAbbName.Text = this.OrderEntity.CompanyAbbName;
            this.tpkDateNote.Value = DateTime.Now.Date;
            this.txtNoteCode.Text = string.Empty;                
            this.rchMemo.Text = string.Empty;
            this.dtblItems = this.accOrderItems.GetDataOEMOrderItemsForReceive(OEMOrderNoteID).Tables[0];
            this.dtblItems.Columns.Add("ReceiveQty", typeof(decimal));
            foreach (DataRow drow in this.dtblItems.Rows)
            {
                drow["ReceiveQty"] = drow["NonFinishedQty"];
            }
            this.dgrdvItem.DataSource = this.dtblItems;

        }
      
        public delegate void AffterSaveDelegate();
        private AffterSaveDelegate affterSave;
        public event AffterSaveDelegate AffterSave
        {
            add
            {
                affterSave += value;
            }
            remove
            {
                affterSave -= value;
            }
        }
        void dgrdvItem_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvItem.Columns[icol].DataPropertyName == "ReceiveQty")
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (this.dgrdvItem[icol, irow].Value == DBNull.Value)
                    {
                        this.dgrdvItem[icol, irow].Value = this.dgrdvItem[this.ColumnNonFinishedQty .Name, irow].Value;
                    }
                }
                if (e.Button == MouseButtons.Right)
                {
                    this.dgrdvItem[icol, irow].Value = DBNull.Value;
                }
            }
        } 
        private  bool ValidateData()
        {
            if (this.OEMOrderNoteID == -1)
            {
                MessageBox.Show("对不起,未选择任何订单!");
                return false;

            }
            if (this.txtNoteCode.Text == string.Empty)
            {
                MessageBox.Show("对不起,送货单号不能为空!");
                return false;
            }
            if (this.dtblItems.Select("ReceiveQty is not null", "", DataViewRowState.CurrentRows).Length == 0)
            {
                MessageBox.Show("对不起,没有任何明细项");
                return false ;
            }
             
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateData() == false) return;
            DialogResult rul = MessageBox.Show("将进行保存入账一经确认不能变更！", "审核确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {
                bool flag = false;
                string errormsg = string.Empty;
                long NoteID = -1;
                object objNoteID = DBNull.Value;
                flag = this.accNotes.InsertOEMReceiveNotes (
                   ref errormsg,
                   ref objNoteID ,
                   this.txtNoteCode.Text,
                   this.tpkDateNote .Value .Date ,
                   this.OEMOrderNoteID ,
                   this.OrderEntity .CompanyID ,
                   this.ctrlQCPsnID.PsnID ,
                   JERPBiz.Frame.UserBiz.PsnID,
                   this.rchMemo.Text);
                if (!flag)
                {
                    MessageBox.Show(errormsg,"操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                NoteID = (long)objNoteID;                //明细
           
                foreach (DataRow drow in this.dtblItems.Rows )
                {
                    if (drow.RowState == DataRowState.Deleted) continue;
                    this.accItems.InsertOEMReceiveItems(ref errormsg,
                        NoteID,
                        drow["ItemID"],
                        drow["ReceiveQty"]);

                    //增加完成数
                    this.accOrderItems.UpdateOEMOrderItemsForAppFinishedQty(ref errormsg, 
                        drow["ItemID"], drow["ReceiveQty"]);
                  
                   
                    //客供入库
                    this.accStore.InsertOEMStoreForIntoStore(ref errormsg,
                        Report.Bill.FrmBizBill.ReceiveNoteID ,
                        Report.Bill.FrmBizBill.ReceiveNoteNoteName ,
                         NoteID,
                         this.txtNoteCode.Text,
                         drow["PrdID"],
                         this.OrderEntity.CompanyID,
                         drow["ReceiveQty"]);

                    //在途预留转库存预留
                    this.accRoadReserve.SaveOEMRoadStoreReserveSwitchToStoreReserve(ref errormsg,
                        this.OrderEntity.CompanyID,
                        drow["PrdID"],
                        drow["ReceiveQty"]);
                }                
                MessageBox.Show("成功保存并入账当前单据!");
                if (this.affterSave != null) this.affterSave();
                this.Close();
            }
        }

   
      
    }
}