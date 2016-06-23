using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Material
{
    public partial class FrmOutSrcReceiveNoteOper : Form
    {
        public FrmOutSrcReceiveNoteOper()
        {
            InitializeComponent();
            this.accNotes = new JERPData.Manufacture.OutSrcReceiveNotes();
            this.accItems = new JERPData.Manufacture.OutSrcReceiveItems();
            this.OrderNoteEntity = new JERPBiz.Manufacture.OutSrcOrderNoteEntity();
            this.accOrderItems = new JERPData.Manufacture.OutSrcOrderItems(); 
            this.accOutSrcStore = new JERPData.Material.OutSrcStore();
            this.accOrderNotes = new JERPData.Manufacture.OutSrcOrderNotes();
            this.accOutSrcStoreReserve = new JERPData.Material.OutSrcStoreReserve();
            this.accSchedules = new JERPData.Manufacture.ManufSchedules();
            this.accPrds = new JERPData.Product.Product();

            this.accExpenseAccount = new JERPData.Finance.ExpenseAccount();

            this.accManufSchedules = new JERPData.Manufacture.ManufSchedules();
            this.accWIP = new JERPData.Manufacture.WIP();
            this.accSemiPrdStore = new JERPData.SemiPrd.Store();
            this.accSemiPrdOutStoreItems = new JERPData.SemiPrd.OutStoreItems();
            this.accSemiPrdOutStoreNotes = new JERPData.SemiPrd.OutStoreNotes();

            this.accIntoStoreIems = new JERPData.Material.IntoStoreItems();
            this.accIntoStoreNotes = new JERPData.Material.IntoStoreNotes();

            this.accMtrStore = new JERPData.Material.Store();
            this.accBranchStore = new JERPData.Material.BranchStore();

            this.accWorkingSheets = new JERPData.Manufacture.WorkingSheets();

            this.accSettleType = new JERPData.Finance.SettleType();
            this.gridhelper = new JCommon.DataGridViewHelper();
            this.dgrdvItem.AutoGenerateColumns = false;
            this.dgrdvItem .CellMouseClick +=new DataGridViewCellMouseEventHandler(dgrdvItem_CellMouseClick);
            this.dgrdvItem.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdvItem_DataBindingComplete);
            this.SetColumnSrc();
            this.btnSave .Click +=new EventHandler(btnSave_Click);
        }

        private JERPData.Manufacture.OutSrcReceiveNotes accNotes;
        private JERPData.Manufacture.OutSrcReceiveItems accItems;
        private JERPData.Manufacture.OutSrcOrderItems accOrderItems; 
        private JERPData.Manufacture.OutSrcOrderNotes accOrderNotes; 
        private JERPBiz.Manufacture.OutSrcOrderNoteEntity OrderNoteEntity;
        private JERPData.Manufacture.WIP accWIP;
        private JERPData.Material.OutSrcStore accOutSrcStore;
        private JERPData.Material.OutSrcStoreReserve accOutSrcStoreReserve;
        private JERPData.Manufacture.ManufSchedules accSchedules;
        private JERPData.SemiPrd.Store accSemiPrdStore;
        private JERPData.SemiPrd.OutStoreItems accSemiPrdOutStoreItems;
        private JERPData.SemiPrd.OutStoreNotes accSemiPrdOutStoreNotes;
        private JERPData.Finance.SettleType accSettleType;
        private JERPData.Manufacture.ManufSchedules accManufSchedules;
        private JERPData.Material.Store accMtrStore;
        private JERPData.Material.BranchStore accBranchStore;
        private JERPData.Material.IntoStoreItems accIntoStoreIems;
        private JERPData.Material.IntoStoreNotes accIntoStoreNotes;
        private JERPData.Manufacture.WorkingSheets accWorkingSheets;
        private JERPData.Finance.ExpenseAccount accExpenseAccount;
        private JERPData.Product.Product accPrds;
        private JCommon.DataGridViewHelper gridhelper;
        private DataTable dtblItems,dtblBranchStore;   
        private long OutSrcOrderNoteID = -1;
        private void SetColumnSrc()
        {
            this.dtblBranchStore = this.accBranchStore.GetDataBranchStore().Tables[0];
            this.ColumnBranchStoreID.DataSource = this.dtblBranchStore;
            this.ColumnBranchStoreID.ValueMember = "BranchStoreID";
            this.ColumnBranchStoreID.DisplayMember = "BranchStoreName";
        }
        private bool GetIntoMtrStoreFlag(long ManufScheduleID)
        {
            bool flag = false;
            this.accManufSchedules.GetParmManufSchedulesAllowIntoMtrStoreFlag(ManufScheduleID, ref flag);
            return flag;

        }
        private bool GetFinalManufProcessFlag(long ManufScheduleID)
        {
            bool flag = false;
            this.accManufSchedules.GetParmManufSchedulesFinalManufProcessFlag(ManufScheduleID, ref flag);
            return flag;
        }
        private object GetDefaultBranchStoreID(int PrdID)
        {
            int rut = 1;
            this.accMtrStore.GetParmStoreDefaultBranchStoreID(PrdID, ref rut);
            if (rut > -1)
            {
                return rut;
            }
            return DBNull.Value;
        }
        private decimal GetCostPrice(int PrdID)
        {
            decimal rut = 0;
            this.accPrds.GetParmProductCostPrice(PrdID, ref rut);
            return rut;
        }
        public void NewNote(long OutSrcOrderNoteID)
        {
            this.OutSrcOrderNoteID = OutSrcOrderNoteID;
            this.OrderNoteEntity.LoadData(OutSrcOrderNoteID);
            this.txtNoteCode.Text = string.Empty;
            this.txtPONo.Text = this.OrderNoteEntity.NoteCode;
            this.txtCompanyAbbName.Text = this.OrderNoteEntity.CompanyAbbName;       
            this.tpkDateNote.Value = DateTime.Now.Date;
            this.rchMemo.Text = string.Empty;
            this.dtblItems = this.accOrderItems .GetDataOutSrcOrderItemsForReceive(this.OutSrcOrderNoteID).Tables[0];
            this.dtblItems.Columns.Add("ReceiveQty", typeof(decimal));  
            this.dtblItems.Columns.Add("BranchStoreID", typeof(int));
            this.dtblItems.Columns.Add("IntoMtrStoreFlag", typeof(bool));
            bool IntoMtrStoreFlag = false;
            foreach (DataRow drow in this.dtblItems.Rows)
            {
            
                drow["ReceiveQty"] = DBNull.Value;
                IntoMtrStoreFlag = this.GetIntoMtrStoreFlag((long)drow["ManufScheduleID"]);
                drow["IntoMtrStoreFlag"] = IntoMtrStoreFlag;
                if (IntoMtrStoreFlag)
                {
                    drow["BranchStoreID"] = this.GetDefaultBranchStoreID((int)drow["PrdID"]);
                }
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
        void dgrdvItem_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow grow in this.dgrdvItem.Rows)
            {
                
                grow.Cells[this.ColumnBranchStoreID.Name].ReadOnly = !(bool)grow.Cells[this.ColumnIntoMtrStoreFlag.Name].Value;
               
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
            if (this.txtNoteCode.Text == string.Empty)
            {
                MessageBox.Show("对不起,送货单号不能为空!");
                return false;
            }
            if (this.dtblItems.Select("(IntoMtrStoreFlag=1 and  BranchStoreID is  null)", "", DataViewRowState.CurrentRows).Length> 0)
            {
                MessageBox.Show("对不起,存在入库的当未设库位的项");
                return false;
            }
            if (this.dtblItems.Select("(ReceiveQty is not null) ", "", DataViewRowState.CurrentRows).Length == 0)
            {
                MessageBox.Show("对不起,没有任何明细项");
                return false;
            }
            if (this.dtblItems.Select("ReceiveQty is not null", "", DataViewRowState.CurrentRows).Length == 0)
            {
                MessageBox.Show("对不起,没有任何明细项");
                return false ;
            }
           
            
            return true;
        }
        private void SaveIntoStoreNote()
        {
            if (this.dtblItems.Select("IntoMtrStoreFlag=1", "", DataViewRowState.CurrentRows).Length == 0) return;
            string errormsg = string.Empty;
            bool flag = false;
            long NoteID = -1;
            string NoteCode = string.Empty;
            object objNoteID = DBNull.Value;
            object objNoteCode = DBNull.Value;
            flag = this.accIntoStoreNotes .InsertIntoStoreNotes(ref errormsg, ref objNoteID, ref objNoteCode,
                DateTime .Now .Date ,
                JERPBiz.Frame.UserBiz.PsnID,
               "委外收货单["+this.txtNoteCode .Text +"]");
            if (!flag)
            {
                MessageBox.Show(errormsg);
                return;
            }
            NoteID = (long)objNoteID;
            NoteCode = objNoteCode.ToString(); 
            decimal TotalAMT = 0;
            foreach (DataRow drow in this.dtblItems.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if ((bool)drow["IntoMtrStoreFlag"] == false) continue;
                int PrdID = (int)drow["PrdID"];
                int BranchStoreID = (int)drow["BranchStoreID"];
                decimal CostPrice = this.GetCostPrice(PrdID);
                decimal Quantity = (decimal)drow["ReceiveQty"];
                TotalAMT += CostPrice * Quantity;
                flag = this.accIntoStoreIems .InsertIntoStoreItems(ref errormsg,
                   NoteID,
                   drow["WorkingSheetID"],
                   PrdID,
                   Quantity,
                   BranchStoreID,
                   CostPrice,
                   drow["Memo"]);
                //入库
                this.accMtrStore .InsertStoreForIntoStore(ref errormsg,
                         JERPBiz.Finance.NoteNameParm.MtrIntoStoreNoteNameID,
                          NoteID,
                          NoteCode,
                          PrdID,
                          BranchStoreID,
                          Quantity,
                          CostPrice);

            }
            if (TotalAMT > 0)
            {
                //原料费用
                this.accExpenseAccount.InsertExpenseAccountForCredit(
                    ref errormsg,
                    "委外部品收货入库[" + NoteCode + "]",
                    JERPBiz.Finance.ExpenseTypeParm.MtrExpense,
                    TotalAMT,
                    JERPBiz.Frame.UserBiz.PsnID);
            }   

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateData() == false) return;
            DialogResult rul = MessageBox.Show("将进行保存入账一经确认不能变更！", "审核确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return;
            bool flag = false;
            string errormsg = string.Empty;
            long NoteID = -1;
            object objNoteID = DBNull.Value;
            decimal TotalAMT = 0;
            foreach (DataRow drow in this.dtblItems.Select("Price is not null", "", DataViewRowState.CurrentRows))
            {
                TotalAMT += (decimal)drow["Price"] * (decimal)drow["Quantity"];
            }           
            flag = this.accNotes.InsertOutSrcReceiveNotes (
               ref errormsg,
               ref objNoteID ,
               this.txtNoteCode.Text,
               this.tpkDateNote .Value .Date ,
               this.OutSrcOrderNoteID ,
               this.ctrlQCPsnID .PsnID,
               TotalAMT ,
               JERPBiz.Frame.UserBiz.PsnID,
               this.rchMemo.Text);
            if (!flag)
            {
                MessageBox.Show(errormsg,"操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            NoteID = (long)objNoteID;
            long OutStoreNoteID = -1;
            flag=this.accSemiPrdOutStoreNotes.InsertOutStoreNotes(
                ref errormsg,
                ref objNoteID,
                this.tpkDateNote.Value.Date,
                JERPBiz.Frame.UserBiz.PsnID,
                "委外供应商[" + this.OrderNoteEntity.CompanyAbbName + "]收货单[" + this.txtNoteCode.Text + "]");
            if (flag)
            {
                OutStoreNoteID = (long)objNoteID;
            }
            this.accOrderNotes.UpdateOutSrcOrderNotesForDeliverAMT (ref errormsg, this.OutSrcOrderNoteID);
            //明细
            object objItemID=DBNull .Value ;
        
            foreach (DataRow drow in this.dtblItems.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                this.accItems.InsertOutSrcReceiveItems(ref errormsg, 
                    ref objItemID ,
                    NoteID,
                    drow["ItemID"],
                    drow["ReceiveQty"]);
                //增加完成数               
                //订单完成
                this.accOrderItems.UpdateOutSrcOrderItemsForAppFinishedQty(ref errormsg, drow["ItemID"],
                    drow["ReceiveQty"]);
                
                //委外那边的转出
                this.accSemiPrdOutStoreItems.InsertOutStoreItems(
                    ref errormsg,
                    OutStoreNoteID,
                    drow["WorkingSheetID"],
                    drow["ManufProcessID"],
                    drow["ReceiveQty"],
                    DBNull.Value);
                   this.accSemiPrdStore.SaveStoreForOutStore(ref errormsg,
                    drow["ManufProcessID"],
                    drow["ReceiveQty"]);
                //这里换了算法,不在处理委外回收
                if (drow["ReceiveQty"] != DBNull.Value)
                {
                    //WIP
                    this.accWIP.InsertWIPForOutSrc(ref errormsg,
                        drow["ManufScheduleID"],
                        this.OrderNoteEntity.CompanyID,
                        drow["ReceiveQty"],
                        this.tpkDateNote.Value.Date);
                    //外发
                    this.accSchedules.UpdateManufSchedulesAppendFinishedQty(ref errormsg,
                        drow["ManufScheduleID"],
                        drow["ReceiveQty"]); 
                    if (this.GetFinalManufProcessFlag((long)drow["ManufScheduleID"]))
                    { 
                        this.accWorkingSheets.UpdateWorkingSheetsForAppendFinishedQty(ref errormsg,
                            drow["WorkingSheetID"],
                            drow["ReceiveQty"]); 
                     }
                }
           
              
            }
       
            this.SaveIntoStoreNote();     //做原料之入库
            MessageBox.Show("成功保存并入账当前单据!");
            if (this.affterSave != null) this.affterSave();
            this.Close();
           
        }

   
      
    }
}