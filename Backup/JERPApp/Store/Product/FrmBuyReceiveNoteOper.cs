using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Product
{
    public partial class FrmBuyReceiveNoteOper : Form
    {
        public FrmBuyReceiveNoteOper()
        {
            InitializeComponent();
            this.accNotes = new JERPData.Product .BuyReceiveNotes();
            this.accItems = new JERPData.Product.BuyReceiveItems();
            this.accOrderItems = new JERPData.Product.BuyOrderItems();
            this.accOrderNotes = new JERPData.Product.BuyOrderNotes();
            this.accStore = new JERPData.Product.Store();
            this.accPayableAccount = new JERPData.Finance.PayableAccount();
            this.accBranchSotre = new JERPData.Product.BranchStore();
            this.printhelper = new JERPBiz.Product.BuyReceiveNotePrintHelper();
            this.OrderNoteEntity = new JERPBiz.Product.BuyOrderNoteEntity();
            this.MoneyTypeParm = new JERPBiz.Finance.MoneyTypeParm();
            this.accSettleType = new JERPData.Finance.SettleType();
            this.accPrds = new JERPData.Product.Product();
            this.SetColumnSrc();
            this.dgrdvItem.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdvItem;
            this.dgrdvItem.CellMouseClick += new DataGridViewCellMouseEventHandler(dgrdvItem_CellMouseClick);
            this.dgrdvItem.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdvItem_DataBindingComplete);
             this.btnSave .Click +=new EventHandler(btnSave_Click);
        }
        private JERPBiz.Product.BuyReceiveNotePrintHelper printhelper;
        private JERPData.Product.BuyReceiveNotes accNotes;
        private JERPData.Product.BuyReceiveItems accItems;
        private JERPData.Product.BuyOrderItems accOrderItems;
        private JERPData.Product.BuyOrderNotes accOrderNotes;
        private JERPData.Product.Store accStore;
        private JERPData.Product.BranchStore accBranchSotre;
        private JERPData.Finance.PayableAccount accPayableAccount;
        private JERPBiz.Product.BuyOrderNoteEntity OrderNoteEntity;
        private JERPBiz.Finance.MoneyTypeParm MoneyTypeParm;
        private JERPData.Product.Product accPrds;
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
            if (this.dtblItems.Select("ReceiveQty is not  null  and BranchStoreID is not null").Length == 0)
            {
                MessageBox.Show("对不起,没有任何明细项");
                return false ;
            }
            if (this.dtblItems.Select("(ReceiveQty is not null ) and (BranchStoreID is null)").Length > 0)
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
                    drow["CostPrice"] =(decimal)drow["Price"] * ExchangeRate ;
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
                        "产品采购收货单[" + this.txtNoteCode.Text + "]",
                        CompanyID,
                        MoneyTypeID,
                        TotalAMT,
                        JERPBiz.Frame.UserBiz.PsnID);
              
            }
            //明细
            object objItemID=DBNull .Value ;
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
                this.accStore.InsertStoreForIntoStore(ref errormsg,
                    JERPBiz.Finance.NoteNameParm.PrdBuyReceiveNoteNameID,
                     NoteID,
                     this.txtNoteCode.Text,
                     drow["PrdID"],
                     drow["BranchStoreID"],
                     drow["ReceiveQty"],
                     drow["CostPrice"]);
            
                
            }
            this.accOrderNotes.UpdateBuyOrderNotesForDeliverAMT(
               ref errormsg,
               this.BuyOrderNoteID);
            //rul = MessageBox.Show("成功进行采购收货,需要输出打印吗?", "打印确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (rul == DialogResult.Yes)
            //{
            //    this.printhelper.ExportToExcel(NoteID);
                this.accNotes.UpdateBuyReceiveNotesForPrint(ref errormsg, NoteID, JERPBiz.Frame.UserBiz.PsnID);
            //}
            MessageBox.Show("成功保存采购收货单");
            if (this.affterSave != null) this.affterSave();
            this.Close();
          
        }

   
      
    }
}