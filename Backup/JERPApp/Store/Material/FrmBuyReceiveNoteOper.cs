using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Material
{
    public partial class FrmBuyReceiveNoteOper : Form
    {
        public FrmBuyReceiveNoteOper()
        {
            InitializeComponent();
            this.accNotes = new JERPData.Material .BuyReceiveNotes();
            this.accItems = new JERPData.Material.BuyReceiveItems();
            this.accOrderItems = new JERPData.Material.BuyOrderItems();
            this.accOrderNotes = new JERPData.Material.BuyOrderNotes();
            this.accStore = new JERPData.Material.Store();
            this.accPayableAccount = new JERPData.Finance.PayableAccount();
            this.accBranchSotre = new JERPData.Material.BranchStore();
            this.printhelper = new JERPBiz.Material.BuyReceiveNotePrintHelper();
            this.OrderNoteEntity = new JERPBiz.Material.BuyOrderNoteEntity();
            this.MoneyTypeParm = new JERPBiz.Finance.MoneyTypeParm();
            this.accSettleType = new JERPData.Finance.SettleType();
            this.accPrds = new JERPData.Product.Product();
            this.accPrdSet = new JERPData.Product.PrdSet();
            this.accRoadReserve = new JERPData.Material.RoadStoreReserve(); 
            this.SetColumnSrc();
            this.dgrdvItem.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdvItem;
            this.dgrdvItem.CellMouseClick += new DataGridViewCellMouseEventHandler(dgrdvItem_CellMouseClick);
            this.dgrdvItem.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdvItem_DataBindingComplete);
            this.btnSave .Click +=new EventHandler(btnSave_Click);
        }
        private JERPBiz.Material.BuyReceiveNotePrintHelper printhelper;
        private JERPData.Material.BuyReceiveNotes accNotes;
        private JERPData.Material.BuyReceiveItems accItems;
        private JERPData.Material.BuyOrderItems accOrderItems;
        private JERPData.Material.BuyOrderNotes accOrderNotes;
        private JERPData.Material.Store accStore;
        private JERPData.Material.BranchStore accBranchSotre;
        private JERPData.Finance.PayableAccount accPayableAccount;
        private JERPBiz.Material.BuyOrderNoteEntity OrderNoteEntity;
        private JERPBiz.Finance.MoneyTypeParm MoneyTypeParm;
        private JERPData.Product .Product accPrds;
        private JERPData.Product.PrdSet accPrdSet;
        private JERPData.Material.RoadStoreReserve accRoadReserve; 
        private JERPData.Finance.SettleType accSettleType;
        private DataTable dtblItems, dtblBranchStores;
        private void SetColumnSrc()
        {
            this.dtblBranchStores = this.accBranchSotre.GetDataBranchStore().Tables[0];
            this.ColumnBranchStoreID.DataSource = this.dtblBranchStores;
            this.ColumnBranchStoreID.ValueMember = "BranchStoreID";
            this.ColumnBranchStoreID.DisplayMember = "BranchStoreName";
        }     
        private object  GetDefaultBranchStoreID(int PrdID)
        {
            int rut = 1;
            this.accStore.GetParmStoreDefaultBranchStoreID(PrdID, ref rut);
            if (rut > -1)
            {
                return rut;
            }
            return DBNull .Value ;
        }
        private decimal GetCostPrice(int PrdID)
        {
            decimal rut = 0;
            this.accPrds.GetParmProductCostPrice(PrdID, ref rut);
            return rut;
        }
       
        private long BuyOrderNoteID = -1;
        public void NewNote(long BuyOrderNoteID)
        {
            this.BuyOrderNoteID = BuyOrderNoteID;
            this.txtNoteCode.Text = string.Empty;
            this.rchMemo.Text = string.Empty;
            this.OrderNoteEntity.LoadData(BuyOrderNoteID);
            this.txtCompanyAbbName.Text = this.OrderNoteEntity.CompanyAbbName;
            this.txtPONo.Text = this.OrderNoteEntity.NoteCode;
            
            this.dtblItems = this.accOrderItems.GetDataBuyOrderItemsForReceive(BuyOrderNoteID).Tables[0];
            this.dtblItems.Columns.Add("ReceiveQty", typeof(decimal)); 
            this.dtblItems.Columns.Add("BranchStoreID", typeof(int));
            this.dtblItems.Columns.Add("CostPrice", typeof(decimal));
            foreach (DataRow drow in this.dtblItems.Rows)
            {
                drow["BranchStoreID"] = this.GetDefaultBranchStoreID((int)drow["PrdID"]);
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

        void dgrdvItem_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow grow in this.dgrdvItem.Rows)
            {
                
                grow.ErrorText = string.Empty;
                if (grow.Cells[this.ColumnReceiveQty.Name].Value != DBNull.Value)
                {
                    if (grow.Cells[this.ColumnBranchStoreID.Name].Value == DBNull.Value)
                    {
                        grow.ErrorText = "未设库位";
                        continue;
                    }
                    
                }
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
            if (this.dtblItems.Select("ReceiveQty is not  null and BranchStoreID is not null").Length == 0)
            {
                MessageBox.Show("对不起,没有任何明细项");
                return false ;
            }
            if (this.dtblItems.Select("(ReceiveQty is not null) and (BranchStoreID is null)").Length > 0)
            {
                MessageBox.Show("存在未设库位明细");
                return false;
            }
           
            return true;
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
            int CompanyID = this.OrderNoteEntity.CompanyID;
            int MoneyTypeID = this.OrderNoteEntity.MoneyTypeID;
            int SettleTypeID = this.OrderNoteEntity.SettleTypeID;
            int PriceTypeID = this.OrderNoteEntity.PriceTypeID;
            int InvoiceTypeID = this.OrderNoteEntity.InvoiceTypeID;
            decimal ExchangeRate = this.MoneyTypeParm.GetExchangeRate(MoneyTypeID); 
            foreach (DataRow drow in this.dtblItems.Rows )
            {
                if (drow["ReceiveQty"] == DBNull.Value) continue;   
                if (drow["Price"] == DBNull.Value)
                {
                    drow["CostPrice"] = this.GetCostPrice((int)drow["PrdID"]);
                    TotalAMT += (decimal)drow["ReceiveQty"] * (decimal)drow["CostPrice"] / ExchangeRate;
                }
                else
                {
                    TotalAMT += (decimal)drow["ReceiveQty"] * (decimal)drow["Price"];
                    drow["CostPrice"] = (decimal)drow["Price"] * ExchangeRate;
                }
            }   
            flag = this.accNotes.InsertBuyReceiveNotes (
               ref errormsg,
               ref objNoteID ,
               this.txtNoteCode.Text,
               this.tpkDateNote .Value .Date ,
               this.BuyOrderNoteID ,
               CompanyID ,
               MoneyTypeID ,
               SettleTypeID ,
               PriceTypeID,
               InvoiceTypeID ,
               this.ctrlQCPsnID .PsnID ,
               TotalAMT ,
               JERPBiz.Frame.UserBiz.PsnID,
               this.rchMemo.Text);
            if (!flag)
            {
                MessageBox.Show(errormsg,"操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            NoteID = (long)objNoteID;
            if (TotalAMT > 0)
            {
                //应付账款
                this.accPayableAccount.InsertPayableAccountForCredit(
                         ref errormsg,
                        "原料采购收货单[" + this.txtNoteCode.Text + "]",
                        CompanyID,
                        MoneyTypeID,
                        TotalAMT,
                        JERPBiz.Frame.UserBiz.PsnID);
              
            }
            //明细
            object objItemID=DBNull .Value ;
            DataTable dtblPrdSet;
            foreach (DataRow drow in this.dtblItems.Rows)
            {
                if (drow["ReceiveQty"] == DBNull.Value) continue;                  
                this.accItems.InsertBuyReceiveItems(ref errormsg, ref objItemID,
                    NoteID,
                    drow["ItemID"],
                    drow["ReceiveQty"],
                    drow["BranchStoreID"], 
                    ExchangeRate ,
                    drow["CostPrice"]);
                //增加完成数
                this.accOrderItems.UpdateBuyOrderItemsForAppFinishedQty(ref errormsg, drow["ItemID"], drow["ReceiveQty"]);
                   //采购入库
                dtblPrdSet = this.accPrdSet.GetDataPrdSetBySetPrdID((int)drow["PrdID"]).Tables[0];
                //解决套料问题的啦
                if (dtblPrdSet.Rows.Count == 0)
                {
                    this.accStore.InsertStoreForIntoStore(ref errormsg,
                        JERPBiz.Finance.NoteNameParm.MtrBuyReceiveNoteNameID,
                         NoteID,
                         this.txtNoteCode.Text,
                         drow["PrdID"],
                         drow["BranchStoreID"],
                         drow["ReceiveQty"],
                         drow["CostPrice"]);
                    //预留也要减少了
                    this.accRoadReserve.SaveRoadStoreReserveSwitchToStoreReserve(ref errormsg, drow["PrdID"], drow["ReceiveQty"]);
          
                }
                else
                {
                    foreach (DataRow drowSet in dtblPrdSet.Rows)
                    {
                        this.accStore.InsertStoreForIntoStore(ref errormsg,
                           JERPBiz.Finance.NoteNameParm.MtrBuyReceiveNoteNameID,
                            NoteID,
                            this.txtNoteCode.Text,
                            drowSet["PrdID"],
                            drow["BranchStoreID"],
                            (decimal)drow["ReceiveQty"]*(decimal)drowSet ["AssemblyQty"],
                            this.GetCostPrice ((int)drowSet["PrdID"]));
                        //预留也要减少了
                        this.accRoadReserve.SaveRoadStoreReserveSwitchToStoreReserve(ref errormsg, drowSet["PrdID"],
                            (decimal)drow["ReceiveQty"] * (decimal)drowSet["AssemblyQty"]);
          
                    }
                }
              
                
         
            }  
            //订单送货金额
            this.accOrderNotes.UpdateBuyOrderNotesForDeliverAMT(
                ref errormsg,
                this.BuyOrderNoteID);
            //rul = MessageBox.Show("成功进行采购收货,需要输出打印吗?", "打印确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (rul == DialogResult.Yes)
            //{
                //this.printhelper.ExportToExcel(NoteID);
                this.accNotes.UpdateBuyReceiveNotesForPrint(ref errormsg, NoteID, JERPBiz.Frame.UserBiz.PsnID);
            //}
            MessageBox.Show("成功进行采购收货");
            if (this.affterSave != null) this.affterSave();
            this.Close();
          
        }

   
      
    }
}