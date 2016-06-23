using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Sale
{
    public partial class FrmSaleDeliverPlanTmpOper : Form
    {
        public FrmSaleDeliverPlanTmpOper()
        {
            InitializeComponent();
            this.dgrdvItem.AutoGenerateColumns = false;
            this.accNotes = new JERPData.Product .SaleDeliverPlanNotes();
            this.accItems = new JERPData.Product.SaleDeliverPlanItems(); 
            this.bizStore = new JERPBiz.Product.Store();
            this.accPrds = new JERPData.Product.Product();
            this.accPriceItems = new JERPData.Product.SalePriceItems();
            this.accPriceNotes = new JERPData.Product.SalePriceNotes();

            this.NoteEntity = new JERPBiz.Product.SaleDeliverPlanNoteEntity(); 
            this.dtblPrds = this.accPrds.GetDataProductForFinishedPrd().Tables[0];
            this.ctrlCompanyID.AffterSelected += this.LoadElement;
            this.ctrlMoneyTypeID.AffterSelected += this.SetAllPrice;
            this.ctrlPriceTypeID.AffterSelected += this.SetAllPrice;
            this.ctrlSettleTypeID.AffterSelected += this.SetAllPrice;

            this.dgrdvItem.CellValueChanged += new DataGridViewCellEventHandler(dgrdvItem_CellValueChanged);
            this.dgrdvItem.CellQuery += new JCommon.MyDataGridView.CellQueryDelegate(dgrdvItem_CellQuery);
            this.dgrdvItem.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdvItem_DataBindingComplete);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnAddPrd.Click += new EventHandler(btnAddPrd_Click);        
            this.btnDelete.Click += new EventHandler(btnDelete_Click);
            this.dgrdvItem.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdvItem_UserDeletingRow);
            this.dgrdvItem.CellContextMenuStripNeeded += new DataGridViewCellContextMenuStripNeededEventHandler(dgrdvItem_CellContextMenuStripNeeded);
         
        }

     
        private JERPData.Product.SaleDeliverPlanNotes accNotes;
        private JERPData.Product.SaleDeliverPlanItems accItems;
        private JERPData.Product.SalePriceItems accPriceItems;
        private JERPData.Product.SalePriceNotes accPriceNotes;
        private JERPBiz.Product.SaleDeliverPlanNoteEntity NoteEntity;
        private JERPBiz.Product.Store bizStore;
        private JERPApp.Define.Product.FrmFinishedPrd frmPrd;
        private JERPApp.Define.Product.FrmFinishedPrd frmAddPrd;
        private JERPData.Product.Product accPrds;
        private JCommon.FrmGridFind frmGridPrd;
        private DataTable  dtblPrds,dtblItems;
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
   
        void LoadElement()
        {
            int CompanyID = this.ctrlCompanyID.CompanyID;
            int MoneyTypeID = 1;
            int SettleTypeID = 1;
            int PriceTypeID = 1;
            this.accPriceNotes.GetParmSalePriceNotesLastElement(CompanyID,
               ref  MoneyTypeID,
               ref  SettleTypeID,
               ref  PriceTypeID);
            this.ctrlMoneyTypeID.MoneyTypeID = MoneyTypeID;
            this.ctrlSettleTypeID.SettleTypeID = SettleTypeID;
            this.ctrlPriceTypeID.PriceTypeID = PriceTypeID;
 
            this.ctrlDeliverAddressID.LoadData(CompanyID);
            this.ctrlFinanceAddressID.LoadData(CompanyID);

            this.SetAllPrice();
        }
        private void SetAllPrice()
        {
            if (this.dtblItems == null) return;
            foreach (DataRow drow in this.dtblItems.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow["PrdID"] != DBNull.Value)
                {
                    drow["Price"] = this.GetPrice((int)drow["PrdID"]);
                }
            }
        }
        private object GetPrice(int PrdID)
        {

            decimal Price = -1;
            //首先按的是报价单
            this.accPriceItems.GetParmSalePriceItemsPrice(
                this.ctrlCompanyID.CompanyID,
                this.ctrlMoneyTypeID.MoneyTypeID,
                this.ctrlSettleTypeID.SettleTypeID,
                this.ctrlPriceTypeID.PriceTypeID,
                DateTime .Now .Date ,
                PrdID,
                ref Price);
            if (Price > -1) return Price;  
            return DBNull.Value;
        }
        private void LoadItem()
        {
            this.dtblItems = this.accItems.GetDataSaleDeliverPlanItemsByNoteID(this.NoteID).Tables[0];
            this.dtblItems.Columns.Add("InventoryQty", typeof(decimal));
            this.dtblItems.Columns.Add("SaveQty", typeof(decimal));
            foreach (DataRow drow in this.dtblItems.Rows)
            {
                drow["InventoryQty"] = this.bizStore.GetPrdStoreQty((int)drow["PrdID"]);
                drow["SaveQty"] = drow["Quantity"];
            }
            this.dgrdvItem.DataSource = this.dtblItems;
        } 
        public void NewNote()
        {
            this.NoteID = -1; 
            this.tpkDateTarget.Value = DateTime.Now.Date;
            this.LoadElement();
            this.LoadItem();
        }
        public void Edit(long NoteID)
        {
            this.NoteID = NoteID;
            this.NoteEntity .LoadData (NoteID ); 

            this.tpkDateTarget.Value = this.NoteEntity.DateTarget; 
            this.ctrlCompanyID.CompanyID = this.NoteEntity.CompanyID;
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

        void dgrdvItem_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow grow in this.dgrdvItem.Rows)
            {
                if (grow.IsNewRow) continue;
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
            }
        }

        void dgrdvItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvItem.Columns[icol].DataPropertyName  == "PrdID")
            {
                object objPrdID=this.dgrdvItem [icol,irow].Value ;
                if (objPrdID != DBNull.Value)
                {
                    this.dgrdvItem[this.ColumnInventoryQty.Name, irow].Value = this.bizStore.GetPrdStoreQty((int)objPrdID);
                    this.dgrdvItem[this.ColumnPrice.Name, irow].Value = this.GetPrice((int)objPrdID);
                }
            }
            if (this.dgrdvItem.Columns[icol].Name == this.ColumnQuantity.Name)
            {
                object objQuantity = this.dgrdvItem[icol, irow].Value; 
                object objFinishedQty = this.dgrdvItem[this.ColumnFinishedQty.Name, irow].Value;
                if ((objQuantity != null) && (objQuantity != DBNull.Value)
                   && (objFinishedQty != null) && (objFinishedQty != DBNull.Value)
                    )
                {
                    this.dgrdvItem[this.ColumnNonFinishedQty.Name, irow].Value = (decimal)objQuantity - (decimal)objFinishedQty;
                }
            }
        }


      
        private bool ValidateData()
        {
            if (this.dtblItems.Select("Quantity is  null or Quantity<=0", "", DataViewRowState.CurrentRows).Length > 0)
            {
                MessageBox.Show("对不起,存在数量为空或小于0项");
                return false;
            }
            if (this.dtblItems.Select("Quantity<FinishedQty", "", DataViewRowState.CurrentRows).Length > 0)
            {
                MessageBox.Show("对不起,存在数量少于完成数项");
                return false;
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
           
            if (this.NoteID == -1)
            {
                flag = this.accNotes.InsertSaleDeliverPlanNotes(
                   ref errormsg,
                   ref objNoteID,
                   this.tpkDateTarget.Value.Date,
                   DBNull .Value ,
                   this.ctrlCompanyID.CompanyID,
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
                        DBNull .Value ,
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
                    drow["SaveQty"] = drow["Quantity"]; 
                    drow.AcceptChanges();
                }
                else
                {
                    MessageBox.Show(errormsg);
                }
             }  
	        MessageBox.Show("成功保存当前出货申请单");
            if (this.affterSave != null) this.affterSave();
          

        }
        void dgrdvItem_CellQuery(DataGridViewCellEventArgs e)
        { 

            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvItem.Columns[icol].Name == this.ColumnAssistantCode.Name)
            {
                
                if (this.frmGridPrd == null)
                {
                    this.frmGridPrd = new JCommon.FrmGridFind();
                    this.frmGridPrd.AddGridColumn("PrdCode", "产品编号", 80);
                    this.frmGridPrd.AddGridColumn("PrdName", "产品名称", 120);
                    this.frmGridPrd.AddGridColumn("PrdSpec", "产品规格", 100);
                    this.frmGridPrd.AddGridColumn("Model", "机型", 66);
                    this.frmGridPrd.AddGridColumn("AssistantCode", "助记码", 66);
                    this.frmGridPrd.AffterSelected += frmGridPrd_AffterSelected;

                }
                this.frmGridPrd.Query(this.dtblPrds, "AssistantCode", this.dgrdvItem .CurrentCell);

            }
        }
        void frmGridPrd_AffterSelected(DataRow drow)
        {
            int PrdID = (int)drow["PrdID"];
            DataGridViewRow grow = this.dgrdvItem.CurrentRow;
            grow.Cells[this.ColumnPrdID.Name].Value = PrdID;
            grow.Cells[this.ColumnPrdCode.Name].Value = drow["PrdCode"];
            grow.Cells[this.ColumnPrdName.Name].Value = drow["PrdName"];
            grow.Cells[this.ColumnPrdSpec.Name].Value = drow["PrdSpec"];
            grow.Cells[this.ColumnModel.Name].Value = drow["Model"];
            grow.Cells[this.ColumnUnitName.Name].Value = drow["UnitName"];

        }
        void dgrdvItem_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if ((this.dgrdvItem.Columns[icol].DataPropertyName == "PrdCode")
                || (this.dgrdvItem.Columns[icol].DataPropertyName == "PrdName")
                || (this.dgrdvItem.Columns[icol].DataPropertyName == "PrdSpec")
                || (this.dgrdvItem.Columns[icol].DataPropertyName == "Model"))
            {

                this.dgrdvItem.CurrentCell = this.dgrdvItem[icol, irow];
                if (frmPrd == null)
                {
                    this.frmPrd = new JERPApp.Define.Product.FrmFinishedPrd();
                    new FrmStyle(this.frmPrd).SetPopFrmStyle(this);
                    this.frmPrd.AffterSelected += frmPrd_AffterSelected;
                }
                this.frmPrd.ShowDialog();
            }
        }

        void frmPrd_AffterSelected(DataRow drow)
        {
            DataGridViewRow grow = this.dgrdvItem.CurrentRow;
            int PrdID = (int)drow["PrdID"];
            grow.Cells[this.ColumnPrdID.Name].Value = drow["PrdID"];
            grow.Cells[this.ColumnPrdCode.Name].Value = drow["PrdCode"];
            grow.Cells[this.ColumnPrdName.Name].Value = drow["PrdName"];
            grow.Cells[this.ColumnPrdSpec.Name].Value = drow["PrdSpec"];
            grow.Cells[this.ColumnModel.Name].Value = drow["Model"];
            grow.Cells[this.ColumnUnitName.Name].Value = drow["UnitName"];
            grow.Cells[this.ColumnPrice.Name].Value = this.GetPrice(PrdID);
            grow.Cells[this.ColumnInventoryQty.Name].Value = this.bizStore.GetPrdStoreQty(PrdID);
            this.frmPrd.Close();
        }
        void btnAddPrd_Click(object sender, EventArgs e)
        {
            if (frmAddPrd == null)
            {
                frmAddPrd = new JERPApp.Define.Product.FrmFinishedPrd();
                new FrmStyle(frmAddPrd).SetPopFrmStyle(this);
                frmAddPrd.AffterSelected += new JERPApp.Define.Product.FrmFinishedPrd.AffterSelectedDelegate(frmAddPrd_AffterSelected);
            }
            frmAddPrd.ShowDialog();
        }

        void frmAddPrd_AffterSelected(DataRow drow)
        {
            DataRow drowNew = this.dtblItems.NewRow();
            drowNew["PrdID"] = drow["PrdID"];
            drowNew["PrdCode"] = drow["PrdCode"];
            drowNew["PrdName"] = drow["PrdName"];
            drowNew["PrdSpec"] = drow["PrdSpec"];
            drowNew["Model"] = drow["Model"];
            drowNew["UnitName"] = drow["UnitName"]; 
            drowNew["Quantity"] = 0;
            drowNew["InventoryQty"] = this.bizStore.GetPrdStoreQty((int)drow["PrdID"]);
            drowNew["Price"] = this.GetPrice((int)drow["PrdID"]);
            this.dtblItems.Rows.Add(drowNew);
        }

        void dgrdvItem_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            bool flag = false;
            DataRow drow = this.dtblItems.DefaultView[irow].Row;
            string ErrorMsg = string.Empty;
            if (drow["ItemID"] == DBNull.Value)
            {
                 
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