using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Sale
{
    public partial class FrmSaleDeliverPlanOper : Form
    {
        public FrmSaleDeliverPlanOper()
        {
            InitializeComponent();
            this.dgrdvOrder .AutoGenerateColumns = false;
            this.ctrlCkbAll.SeachGridView = this.dgrdvOrder;
            this.ctrlQFind.SeachGridView = this.dgrdvOrder;
            this.dgrdvItem.AutoGenerateColumns = false;
            this.accNotes = new JERPData.Product .SaleDeliverPlanNotes();
            this.accItems = new JERPData.Product.SaleDeliverPlanItems();
            this.OrderNoteEntity = new JERPBiz.Product.SaleOrderNoteEntity();
            this.accOrderItems = new JERPData.Product.SaleOrderItems();
            this.bizStore = new JERPBiz.Product.Store();
            this.NoteEntity = new JERPBiz.Product.SaleDeliverPlanNoteEntity(); 
            this.dgrdvItem.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdvItem_DataBindingComplete);
             this.btnSave .Click +=new EventHandler(btnSave_Click); 
            this.btnDelete.Click += new EventHandler(btnDelete_Click);
            this.btnAdd.Click += new EventHandler(btnAdd_Click);
            this.dgrdvItem.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdvItem_UserDeletingRow);
            for (int j = 1; j < this.dgrdvOrder.ColumnCount; j++)
            {
                this.dgrdvOrder.Columns[j].ReadOnly = true;
            }
            foreach(DataGridViewColumn col in this.dgrdvItem .Columns )
            {
                col.ReadOnly =true;
            }
            this.ColumnCustomerRef.ReadOnly =false;
            this.ColumnQuantity .ReadOnly=false;
            this.ColumnPrice.ReadOnly = false; 
            this.ColumnMemo.ReadOnly = false; 
        }

      
        private JERPData.Product.SaleDeliverPlanNotes accNotes;
        private JERPData.Product.SaleDeliverPlanItems accItems;
        private JERPData.Product.SaleOrderItems accOrderItems;
        private JERPBiz.Product.SaleOrderNoteEntity OrderNoteEntity;
        private JERPBiz.Product.SaleDeliverPlanNoteEntity NoteEntity;
        private JERPBiz.Product.Store bizStore;
        private DataTable  dtblOrderItems,dtblItems;
        private long noteid = -1;
        private long NoteID
        {
            get
            {
                return this.noteid;
            }
            set
            {
                this.noteid = value;
                this.btnDelete.Enabled = (value > -1);
            }
        }
        private long saleordernoteID = -1;
        private long SaleOrderNoteID
        {
            get
            {
                return this.saleordernoteID;
            }
            set
            {
                this.saleordernoteID = value;
              
            }
        }
        private int companyid = -1;
        private int CompanyID
        {
            get
            {
                return this.companyid;
            }
            set
            {
                this.companyid = value;
                this.ctrlDeliverAddressID.LoadData(value );
                this.ctrlFinanceAddressID.LoadData(value );
            }
        }
        private void LoadOrder()
        { 
            this.dtblOrderItems = this.accOrderItems.GetDataSaleOrderItemsForDeliverApply(this.SaleOrderNoteID,this.NoteID ).Tables[0];
            this.dtblOrderItems.Columns.Add("CheckedFlag", typeof(bool));
            this.dtblOrderItems.Columns.Add("InventoryQty", typeof(decimal));
            foreach (DataRow drow in this.dtblOrderItems.Rows)
            {
                drow["InventoryQty"] = this.bizStore.GetPrdStoreQty((int)drow["PrdID"]);
            }
            this.dgrdvOrder.DataSource = this.dtblOrderItems;
        }
        private void LoadItem()
        {

            this.dtblItems = this.accItems.GetDataSaleDeliverPlanItemsForSetting  (this.NoteID).Tables[0];
            this.dtblItems.Columns.Add("InventoryQty", typeof(decimal)); 
            foreach (DataRow drow in this.dtblItems.Rows)
            {
                drow["InventoryQty"] = this.bizStore.GetPrdStoreQty((int)drow["PrdID"]); 
            }
            this.dgrdvItem.DataSource = this.dtblItems;
        }
       
        
        public void NewNote(long SaleOrderNoteID)
        {
            this.NoteID = -1;
            this.SaleOrderNoteID = SaleOrderNoteID;
            this.OrderNoteEntity.LoadData(SaleOrderNoteID);

            this.tpkDateTarget.Value = DateTime.Now.Date; 
            this.txtPONo.Text = this.OrderNoteEntity.PONo;
            this.CompanyID = this.OrderNoteEntity.CompanyID;
            this.txtCompanyAbbName.Text = this.OrderNoteEntity.CompanyAbbName;
            this.ctrlDeliverTypeID.DeliverTypeID = this.OrderNoteEntity.DeliverTypeID;
            this.txtExpressRequire.Text = this.OrderNoteEntity.ExpressRequire;
            this.ctrlDeliverAddressID.LoadData (this.OrderNoteEntity.CompanyID);
            this.ctrlDeliverAddressID.DeliverAddressID = this.OrderNoteEntity.DeliverAddressID;

            this.ctrlFinanceAddressID.LoadData(this.OrderNoteEntity.CompanyID);
            this.ctrlFinanceAddressID.FinanceAddressID = this.OrderNoteEntity.FinanceAddressID;

            this.ctrlMoneyTypeID.MoneyTypeID = this.OrderNoteEntity.MoneyTypeID;
            this.ctrlSettleTypeID.SettleTypeID = this.OrderNoteEntity.SettleTypeID;
            this.ctrlPriceTypeID.PriceTypeID = this.OrderNoteEntity.PriceTypeID;
            this.ctrlInvoiceTypeID.InvoiceTypeID = this.OrderNoteEntity.InvoiceTypeID;

            this.rchMemo.Text = this.OrderNoteEntity.Memo;
           this.LoadOrder ();
           this.LoadItem(); 
            
        }
      
        public void Edit(long NoteID)
        {
            this.NoteID = NoteID;
            this.NoteEntity .LoadData (NoteID );
            this.SaleOrderNoteID = this.NoteEntity.SaleOrderNoteID;

            this.tpkDateTarget.Value = this.NoteEntity.DateTarget;
            this.txtPONo.Text = this.NoteEntity.PONo;
            this.CompanyID = this.NoteEntity.CompanyID;
            this.txtCompanyAbbName.Text = this.NoteEntity.CompanyAbbName;
            this.ctrlDeliverTypeID.DeliverTypeID = this.NoteEntity.DeliverTypeID;
            this.txtExpressRequire.Text = this.NoteEntity.ExpressRequire;
            this.ctrlDeliverAddressID.LoadData(this.NoteEntity.CompanyID);
            this.ctrlDeliverAddressID.DeliverAddressID = this.NoteEntity.DeliverAddressID;

            this.ctrlFinanceAddressID.LoadData(this.NoteEntity.CompanyID);
            this.ctrlFinanceAddressID.FinanceAddressID = this.NoteEntity.FinanceAddressID;

            this.ctrlMoneyTypeID.MoneyTypeID = this.NoteEntity.MoneyTypeID;
            this.ctrlSettleTypeID.SettleTypeID = this.NoteEntity.SettleTypeID;
            this.ctrlPriceTypeID.PriceTypeID = this.NoteEntity.PriceTypeID;
            this.ctrlInvoiceTypeID.InvoiceTypeID = this.NoteEntity.InvoiceTypeID;

            this.rchMemo.Text = this.NoteEntity.Memo;
            this.LoadOrder();
            this.LoadItem();
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
        void btnAdd_Click(object sender, EventArgs e)
        {
            DataRow drowOrder, drowNew;
            DataGridViewRow grow;
            for (int irow = 0; irow < this.dgrdvOrder.RowCount;irow++ )
            {
                grow = this.dgrdvOrder.Rows[irow];
                if (grow.Cells[this.ColumnCheckedFlag.Name].Value == DBNull.Value) continue;
                if ((bool)grow.Cells[this.ColumnCheckedFlag.Name].Value == false) continue;
                drowOrder = this.dtblOrderItems.DefaultView[grow.Index].Row;
                drowNew = this.dtblItems.NewRow();
                drowNew["SaleOrderItemID"] = drowOrder["ItemID"];
                drowNew["PrdID"] = drowOrder["PrdID"];
                drowNew["PrdCode"] = drowOrder["PrdCode"];
                drowNew["PrdName"] = drowOrder["PrdName"];
                drowNew["PrdSpec"] = drowOrder["PrdSpec"];
                drowNew["Model"] = drowOrder["Model"];
                drowNew["CustomerRef"] = drowOrder["CustomerRef"];
                drowNew["UnitName"] = drowOrder["UnitName"];
                drowNew["InventoryQty"] = drowOrder["InventoryQty"];
                drowNew["AllowPlanQty"] = drowOrder["NonDeliverPlanQty"];
                drowNew["Quantity"] = drowOrder["NonDeliverPlanQty"];
                drowNew["FinishedQty"] = 0;
                drowNew["Price"] = drowOrder["Price"];
                drowNew["Memo"] = drowOrder["Memo"];
                this.dtblItems.Rows.Add(drowNew);
                this.dgrdvOrder.Rows.Remove(grow);
                irow--;
            }
        } 
        void dgrdvItem_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow grow in this.dgrdvItem.Rows)
            {
                grow.ErrorText = string.Empty;
                object objQty = grow.Cells[this.ColumnQuantity.Name].Value;
                object objFinishedQty = grow.Cells[this.ColumnFinishedQty.Name].Value;
                if ((objQty != DBNull.Value) && (objFinishedQty != DBNull.Value))
                {
                    if ((decimal)objQty < (decimal)objFinishedQty)
                    {
                        grow.ErrorText = "数量不能小于已完成数";
                        continue;
                    }
                }
                object objAllowPlanQty = grow.Cells[this.ColumnAllowPlanQty.Name].Value;
                if ((objQty != DBNull.Value) && (objAllowPlanQty != DBNull.Value))
                {
                    if ((decimal)objQty > (decimal)objAllowPlanQty)
                    {
                        grow.ErrorText = "数量不能大于可申请数";
                        continue;
                    }
                }
            }
        }

 
        private bool ValidateData()
        {
            foreach (DataGridViewRow grow in this.dgrdvItem.Rows)
            {
                if (grow.ErrorText != string.Empty)
                {
                    return false;
                }
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateData() == false) return;
            DialogResult rul = MessageBox.Show("将进行保存入账一经确认不能变更！", "审核确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
         
            bool flag = false;
            string errormsg = string.Empty; 
            object objNoteID = DBNull.Value;
            object objSaleOrderNoteID = DBNull.Value;
            if (this.SaleOrderNoteID > -1)
            {
                objSaleOrderNoteID = this.SaleOrderNoteID;
            }
            if (this.NoteID == -1)
            {
                flag = this.accNotes.InsertSaleDeliverPlanNotes(
                   ref errormsg,
                   ref objNoteID,
                   this.tpkDateTarget.Value.Date,
                   objSaleOrderNoteID,
                   this.CompanyID,
                   this.ctrlDeliverAddressID.DeliverAddressID,
                   this.ctrlFinanceAddressID.FinanceAddressID,
                   this.ctrlDeliverTypeID.DeliverTypeID,
                   this.txtExpressRequire.Text,
                   this.ctrlMoneyTypeID.MoneyTypeID,
                   this.ctrlSettleTypeID.SettleTypeID,
                   this.ctrlPriceTypeID.PriceTypeID,
                   this.ctrlInvoiceTypeID.InvoiceTypeID,
                   JERPBiz.Frame.UserBiz.PsnID,
                   this.rchMemo.Text);
                if (flag)
                {
                    this.NoteID = (long)objNoteID;
                }
            }
            else
            {
                flag = this.accNotes.UpdateSaleDeliverPlanNotes(
                    ref errormsg,
                    this.NoteID,
                   this.tpkDateTarget.Value.Date,
                   this.ctrlDeliverAddressID.DeliverAddressID,
                   this.ctrlFinanceAddressID.FinanceAddressID,
                   this.ctrlDeliverTypeID.DeliverTypeID,
                   this.txtExpressRequire.Text,
                   this.ctrlMoneyTypeID.MoneyTypeID,
                   this.ctrlSettleTypeID.SettleTypeID,
                   this.ctrlPriceTypeID.PriceTypeID,
                   this.ctrlInvoiceTypeID.InvoiceTypeID,
                   JERPBiz.Frame.UserBiz.PsnID,
                   this.rchMemo.Text);

            }
            if (!flag)
            {
                MessageBox.Show(errormsg,"操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (NoteID == -1) return;
            //明细
            object objItemID=DBNull .Value ; 
            foreach (DataRow drow in this.dtblItems.Rows )
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow.RowState == DataRowState.Unchanged) continue;
                if (drow["ItemID"] == DBNull.Value)
                {
                    objItemID = DBNull.Value;
                    flag = this.accItems.InsertSaleDeliverPlanItems(ref errormsg, ref objItemID,
                        this.NoteID,
                        drow["SaleOrderItemID"],
                        drow["PrdID"],
                        drow["Quantity"],
                        drow["Price"],
                        drow["CustomerRef"], 
                        drow["Memo"]);
                    if (flag)
                    {
                        drow["ItemID"] = objItemID;
                    }
                }
                else
                {
                    flag = this.accItems.UpdateSaleDeliverPlanItems (ref errormsg,
                       drow["ItemID"], 
                       drow["Quantity"],
                       drow["Price"],
                       drow["CustomerRef"], 
                       drow["Memo"]); 
                }
                if (flag)
                { 
                     this.accOrderItems.UpdateSaleOrderItemsForDeliverPlanQty (ref errormsg,
                            drow["SaleOrderItemID"]); 
                    drow.AcceptChanges();
                }
                else
                {
                    MessageBox.Show(errormsg);
                }
             }  
	        MessageBox.Show("成功保存当前出货申请单");
            this.LoadOrder();
            this.LoadItem();
            if (this.affterSave != null) this.affterSave();
          

        }
        private void ReturnRow(long SaleOrderItemID)
        {
            DataTable dtblPOItems = this.accOrderItems.GetDataSaleOrderItemsByItemID(SaleOrderItemID).Tables[0];
            dtblPOItems.Columns.Add("CheckedFlag", typeof(bool));
            dtblPOItems.Columns.Add("InventoryQty", typeof(decimal));
            if (dtblPOItems.Rows .Count> 0)
            {
                DataRow drow = dtblPOItems.Rows[0];
                drow["InventoryQty"] = this.bizStore.GetPrdStoreQty((int)drow["PrdID"]);
                this.dtblOrderItems.ImportRow(drow);
            }
        }
        void dgrdvItem_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            bool flag = false;
            DataRow drow = this.dtblItems.DefaultView[irow].Row;
            string ErrorMsg = string.Empty;
            if (drow["ItemID"] == DBNull.Value)
            {
                this.ReturnRow((long)drow["SaleOrderItemID"]);
                return;
            }
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {
                flag = this.accItems.DeleteSaleDeliverPlanItems (ref ErrorMsg,
                    drow["ItemID"]);
                if (!flag)
                {

                    MessageBox.Show(ErrorMsg);
                    e.Cancel = true;
                }
                else
                {
                     
                    this.accOrderItems.UpdateSaleOrderItemsForDeliverPlanQty(ref ErrorMsg,
                            drow["SaleOrderItemID"]);
                    this.ReturnRow((long)drow["SaleOrderItemID"]);
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.OKCancel , MessageBoxIcon.Question);
            if (rul == DialogResult.Cancel )return;
            bool flag = false;
            string errormsg = string.Empty;
            flag = this.accNotes.DeleteSaleDeliverPlanNotes(ref errormsg,
                this.NoteID);
            if (flag)
            {
                MessageBox.Show("成功删除当前出货申请单");
                if (this.affterSave != null) this.affterSave();
                this.Close();
            }
            else
            {
                MessageBox.Show(errormsg);
            }
        }
     

      
      
    }
}