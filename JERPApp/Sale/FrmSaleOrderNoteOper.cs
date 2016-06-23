using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Sale
{
    public partial class FrmSaleOrderNoteOper : Form
    {
        public FrmSaleOrderNoteOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accItems = new JERPData.Product.SaleOrderItems(); 
            this.accNotes = new JERPData.Product.SaleOrderNotes();
            this.accPrds = new JERPData.Product.Product();
            this.accCustomer = new JERPData.General.Customer();
            this.NoteEntity = new JERPBiz.Product.SaleOrderNoteEntity();
            this.accPriceItems = new JERPData.Product.SalePriceItems();
            this.accPriceNotes = new JERPData.Product.SalePriceNotes();
            this.ctrlDeliverTypeID.AllowDefine();
            this.ctrlCompanyID.AffterSelected += this.LoadElement; 
            this.dtblPrds = this.accPrds.GetDataProductForFinishedPrd().Tables[0];
            this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
            this.dgrdv.CellValueChanged +=new DataGridViewCellEventHandler(dgrdv_CellValueChanged);
            this.dgrdv .CellEnter +=new DataGridViewCellEventHandler(dgrdv_CellEnter);
            this.btnAddPrd.Click += new EventHandler(btnAddPrd_Click);
            this.dgrdv.CellContextMenuStripNeeded += new DataGridViewCellContextMenuStripNeededEventHandler(dgrdv_CellContextMenuStripNeeded);
            this.dgrdv.CellQuery += new JCommon.MyDataGridView.CellQueryDelegate(dgrdv_CellQuery);
            this.lnkFile.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkFile_LinkClicked);
            this.lnkCredit.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkCredit_LinkClicked);
            this.btnNew.Click += new EventHandler(btnNew_Click);
            this.btnDelete.Click += new EventHandler(btnDelete_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnImport.Click += new EventHandler(btnImport_Click);
            this.ctrlMoneyTypeID.AffterSelected += this.SetAllPrice;
            this.ctrlPriceTypeID.AffterSelected += this.SetAllPrice;
            this.ctrlSettleTypeID.AffterSelected += this.SetAllPrice;
        }

     
        private JERPData.Product.SaleOrderNotes accNotes;
        private JERPData.Product.SaleOrderItems accItems; 
        private JERPData.Product.Product accPrds;
        private JERPData.Product.SalePriceItems accPriceItems;
        private JERPData.Product.SalePriceNotes accPriceNotes;
        private JCommon.FrmExcelImport frmImport;
        private JERPApp.Define.Product.FrmFinishedPrd frmPrd;
        private JERPApp.Define.Product.FrmFinishedPrd frmAddPrd; 
        private JERPBiz.Product.SaleOrderNoteEntity NoteEntity;
        private JERPData.General.Customer accCustomer;
        private JERPApp.Define.Product.FrmSaleOrderRequire frmRequire;
        private JCommon.FrmFileBrowse frmFileBrowse;
        private JCommon.FrmGridFind frmGridPrd;
        private DataTable dtblItems,dtblPrds;
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
     
        private long noteID = -1;
        private long NoteID
        {
            get
            {
                return this.noteID;
            }
            set
            {
                this.noteID = value;
                this.ctrlCompanyID.Enabled = (value == -1);
                this.dpkDateNote.Enabled = (value == -1);
                this.btnDelete.Enabled = (value > -1);
                this.lnkFile.Enabled = (value > -1);
            }
        } 
        private void LoadItems()
        {
            this.dtblItems = this.accItems.GetDataSaleOrderItemsByNoteID(this.NoteID).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
            this.dtblItems.Columns["PrdID"].AllowDBNull = false;

        }
        
        
        void LoadElement()
        {
            int CompanyID =this.ctrlCompanyID .CompanyID ;
            int MoneyTypeID=1;
            int SettleTypeID=1;
            int PriceTypeID=1;
            this.accPriceNotes.GetParmSalePriceNotesLastElement(CompanyID,
               ref  MoneyTypeID,
               ref  SettleTypeID,
               ref  PriceTypeID);
            this.ctrlMoneyTypeID.MoneyTypeID = MoneyTypeID;
            this.ctrlSettleTypeID.SettleTypeID = SettleTypeID;
            this.ctrlPriceTypeID.PriceTypeID = PriceTypeID;

            string memo = string.Empty;
            this.accNotes.GetParmSaleOrderNotesMemoByCompanyID(CompanyID, ref memo);
            this.rchMemo.Text = memo;
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
        public void NewNote()
        {
            this.NoteID = -1;            
            this.txtNoteCode .Text = string.Empty;
            this.txtPONo.Text = string.Empty;
            this.LoadElement();
            this.rchMemo.Text = string.Empty;
            this.LoadItems();
        }
        public void EditNote(long NoteID)
        {
            this.NoteID = NoteID;
            this.NoteEntity.LoadData(NoteID);
            this.txtNoteCode.Text = this.NoteEntity.NoteCode;
            this.txtPONo.Text = this.NoteEntity.PONo ;
            this.dpkDateNote .Value  = this.NoteEntity.DateNote.Date ;
            this.ctrlCompanyID.CompanyID = this.NoteEntity.CompanyID;
            this.ctrlDeliverAddressID.LoadData(this.NoteEntity.CompanyID);
            this.ctrlFinanceAddressID.LoadData(this.NoteEntity.CompanyID);
            this.ctrlDeliverAddressID.DeliverAddressID = this.NoteEntity.DeliverAddressID;
            this.ctrlFinanceAddressID.FinanceAddressID = this.NoteEntity.FinanceAddressID;
            this.ctrlMoneyTypeID.MoneyTypeID = this.NoteEntity.MoneyTypeID;
            this.ctrlSettleTypeID.SettleTypeID = this.NoteEntity.SettleTypeID;
            this.ctrlPriceTypeID.PriceTypeID = this.NoteEntity.PriceTypeID;
            this.ctrlInvoiceTypeID.InvoiceTypeID = this.NoteEntity.InvoiceTypeID;
            this.ctrlDeliverTypeID.DeliverTypeID = this.NoteEntity.DeliverTypeID;
            this.txtExpressRequire.Text = this.NoteEntity.ExpressRequire;           
            this.rchMemo.Text = this.NoteEntity.Memo  ;
            this.LoadItems();
        }

        void lnkFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.frmFileBrowse == null)
            {
                this.frmFileBrowse = new JCommon.FrmFileBrowse();
                new FrmStyle(frmFileBrowse).SetPopFrmStyle(this);
                this.frmFileBrowse.ReadOnly = false;
            }
            this.frmFileBrowse.Browse(JERPData.ServerParameter.ERPFileFolder + @"\Sale\OrderNote\" + this.NoteID.ToString());
            this.frmFileBrowse.ShowDialog();
        }
      
        void btnNew_Click(object sender, EventArgs e)
        {
            this.NewNote();
           
        }
       
        void dgrdv_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnMemo.Name)
            {
                this.dgrdv.CurrentCell = this.dgrdv[icol, irow];
                if (frmRequire == null)
                {
                    frmRequire = new JERPApp.Define.Product.FrmSaleOrderRequire();
                    new FrmStyle(frmRequire).SetPopFrmStyle(this);
                    frmRequire.AffterConfirm += new JERPApp.Define.Product.FrmSaleOrderRequire.AffterConfirmDelegate(frmRequire_AffterConfirm);
                }
                frmRequire.ShowDialog();
            }            
            if ((this.dgrdv.Columns[icol].DataPropertyName == "PrdCode")
             || (this.dgrdv.Columns[icol].DataPropertyName == "PrdName")
             || (this.dgrdv.Columns[icol].DataPropertyName == "PrdSpec")
             || (this.dgrdv.Columns[icol].DataPropertyName == "Model"))
            {

                this.dgrdv.CurrentCell = this.dgrdv[icol, irow];
                if (frmPrd == null)
                {
                    this.frmPrd = new JERPApp.Define.Product.FrmFinishedPrd();
                    new FrmStyle(this.frmPrd).SetPopFrmStyle(this);
                    this.frmPrd.AffterSelected += frmPrd_AffterSelected;
                }
                this.frmPrd.ShowDialog();
            }
           
        }


     
        void frmRequire_AffterConfirm(string RequireInfor)
        {
            this.dgrdv.CurrentCell.Value = RequireInfor;
        }
 
      
        void frmPrd_AffterSelected(DataRow drow)
        {
            DataGridViewRow grow = this.dgrdv.CurrentRow;
            int PrdID = (int)drow["PrdID"];
            grow.Cells[this.ColumnPrdID.Name].Value = drow["PrdID"];
            grow.Cells[this.ColumnPrdCode.Name].Value = drow["PrdCode"];
            grow.Cells[this.ColumnPrdName.Name].Value = drow["PrdName"];
            grow.Cells[this.ColumnPrdSpec.Name].Value = drow["PrdSpec"];
            grow.Cells[this.ColumnModel.Name].Value = drow["Model"];
            grow.Cells[this.ColumnUnitName.Name].Value = drow["UnitName"]; 
            grow.Cells[this.ColumnPrice.Name].Value = this.GetPrice(PrdID);
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
            int PrdID = (int)drow["PrdID"];
            if (this.dtblItems.Select("PrdID=" + PrdID.ToString(), "", DataViewRowState.CurrentRows).Length > 0) return;
            DataRow drowNew = this.dtblItems.NewRow();
            drowNew["PrdID"] = PrdID;
            drowNew["PrdCode"] = drow["PrdCode"];
            drowNew["PrdName"] = drow["PrdName"];
            drowNew["PrdSpec"] = drow["PrdSpec"];
            drowNew["Model"] = drow["Model"];
            drowNew["UnitName"] = drow["UnitName"];
            drowNew["Quantity"] = 0;
            drowNew["Price"] = this.GetPrice(PrdID);
            this.dtblItems.Rows.Add(drowNew);
        }


    
        void btnImport_Click(object sender, EventArgs e)
        {
            if (this.frmImport == null)
            {
                this.frmImport = new JCommon.FrmExcelImport();
                new FrmStyle(frmImport).SetPopFrmStyle(this);
                this.frmImport.ImportHandle += new JCommon.FrmExcelImport.ImportDelegate(frmImport_ImportHandle);
                DataColumn[] columns = new DataColumn[] {      
                    new DataColumn ("产品编号",typeof (string)),
                    new DataColumn ("产品名称",typeof (string)),
                    new DataColumn ("产品规格",typeof (string)),
                    new DataColumn ("机型",typeof (string)),
                    new DataColumn ("客户料号",typeof (string)),                       
                    new DataColumn ("数量",typeof (decimal)),
                    new DataColumn ("单价",typeof (decimal)),
                    new DataColumn ("交货期",typeof (DateTime)),                       
                    new DataColumn ("备注",typeof (string))       
                };
                this.frmImport.SetImportColumn(columns, "产品编号不能为空,数量不能为空!");
            }
            this.frmImport.ShowDialog();
        }
        private int GetPrdID(string PrdCode)
        {
         
            DataRow[] drows = this.dtblItems.Select("PrdCode='" + PrdCode + "'");
            if (drows.Length == 0)
            {
                return (int)drows[0]["PrdID"];
            }
            return -1;
        }
        void frmImport_ImportHandle(DataRow drow, out bool flag, out string msg)
        {
            flag = true;
            msg = "成功!";           
            int PrdID = this.GetPrdID(drow["产品编号"].ToString());
            if (PrdID ==-1)
            {
                flag = false;
                msg = "此产品编号未存在";
                return;
            }
            DataRow[] drowItems = this.dtblItems.Select("PrdID=" + PrdID.ToString(),"",DataViewRowState.CurrentRows );
            if (drowItems.Length > 0)
            {
                flag = false;
                msg = "此产品已下单";
                return;
            }
            DataRow drowNew = this.dtblItems .NewRow();         
            drowNew["PrdID"] = PrdID;
            drowNew["PrdCode"] = drow["产品编号"];
            drowNew["PrdName"] = drow["产品名称"];
            drowNew["PrdSpec"] = drow["产品规格"];
            drowNew["Model"] = drow["机型"];       
            drowNew["CustomerRef"] = drow["客户料号"];       
            drowNew["Quantity"] = drow["数量"];
            drowNew["Price"] = drow["单价"];
            if (drowNew["Price"] == DBNull.Value)
            {
                drowNew["Price"] = this.GetPrice(PrdID);
            }
            drowNew["DateTarget"] = drow["交货期"]; 
            drowNew["Memo"] = drow["备注"];
            this.dtblItems.Rows.Add(drowNew);
        }
        void dgrdv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (irow == 0) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnDateTarget.Name)
            {
                if (this.dgrdv[icol, irow].Value == DBNull.Value)
                {
                    this.dgrdv[icol, irow].Value = this.dgrdv[icol, irow - 1].Value;
                }
            }
        }
        void dgrdv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            bool flag = false;
            DataRow drow = this.dtblItems .DefaultView[irow].Row;
            string ErrorMsg = string.Empty;
            if (drow["ItemID"] == DBNull.Value)
            {           
                return;
            }
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {
                flag = this.accItems .DeleteSaleOrderItems(ref ErrorMsg,
                    drow["ItemID"]);
                if (!flag)
                {

                    MessageBox.Show(ErrorMsg);
                }
                else
                {
                    this.SaveTotalAMT();
                }
            }
            else
            {
                e.Cancel = true;
            }
        }
        private object GetPrice(int PrdID)
        {

            decimal Price = -1;
            //首先按的是报价单
            this.accPriceItems.GetParmSalePriceItemsPrice(
                this.ctrlCompanyID  .CompanyID,
                this.ctrlMoneyTypeID .MoneyTypeID,
                this.ctrlSettleTypeID .SettleTypeID,
                this.ctrlPriceTypeID .PriceTypeID,
                this.dpkDateNote .Value .Date ,
                PrdID,
                ref Price);
            if (Price > -1) return Price;
            //最后订单的单价
            this.accItems.GetParmSaleOrderItemsLastPrice(
                this.ctrlCompanyID.CompanyID,
                this.ctrlMoneyTypeID.MoneyTypeID,
                this.ctrlSettleTypeID.SettleTypeID,
                this.ctrlPriceTypeID.PriceTypeID,
                PrdID,
                ref Price);          
            if (Price > -1)
            {
                return Price;
            }
            return DBNull.Value;
        }

        void dgrdv_CellQuery(DataGridViewCellEventArgs e)
        { 
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnAssistantCode.Name)
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
                this.frmGridPrd.Query(this.dtblPrds, "AssistantCode", this.dgrdv.CurrentCell);
              
            }
        }

        void dgrdv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;          
            if (this.dgrdv.Columns[e.ColumnIndex].DataPropertyName == "PrdID")
            {
                object objPrdID = this.dgrdv[icol, irow].Value;
                if (objPrdID != DBNull.Value)
                {
                    this.dgrdv[this.ColumnPrice.Name, irow].Value = this.GetPrice ((int)objPrdID );
                }

            }
        }
        void frmGridPrd_AffterSelected(DataRow drow)
        {
            int PrdID = (int)drow["PrdID"];
            DataGridViewRow grow = this.dgrdv.CurrentRow;
            grow.Cells[this.ColumnPrdID.Name].Value = PrdID;
            grow.Cells[this.ColumnPrdCode.Name].Value = drow["PrdCode"];
            grow.Cells[this.ColumnPrdName.Name].Value = drow["PrdName"];
            grow.Cells[this.ColumnPrdSpec.Name].Value = drow["PrdSpec"];
            grow.Cells[this.ColumnModel.Name].Value = drow["Model"];
            grow.Cells[this.ColumnUnitName.Name].Value = drow["UnitName"]; 
              
        }
        void lnkCredit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            decimal CreditAMT = 0;
            decimal ReceivableAMT=0;
            this.accCustomer.GetParmCustomerCreditAMT(this.ctrlCompanyID.CompanyID,
                ref CreditAMT, ref ReceivableAMT);
            MessageBox.Show("信用额度:" + string.Format("{0:0.####}", CreditAMT) + "\n当前欠款:" +
                string.Format("{0:0.####}", ReceivableAMT));
        }

        private bool SaveNote()
        {
            bool flag = false;
            string errormsg = string.Empty;
            if (this.NoteID == -1)
            {
                object objNoteID = DBNull.Value;
                object ojbNoteCode=DBNull .Value ;
                flag=this.accNotes.InsertSaleOrderNotes(
                    ref errormsg,
                    ref objNoteID,
                    ref ojbNoteCode,
                    this.txtPONo.Text,
                    this.dpkDateNote.Value.Date,
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
                    this.txtNoteCode.Text = ojbNoteCode.ToString();                  
                }
            }
            else
            {
                flag = this.accNotes.UpdateSaleOrderNotes(ref errormsg,
                    this.NoteID,
                    this.txtPONo.Text,
                    this.ctrlMoneyTypeID.MoneyTypeID,
                    this.ctrlSettleTypeID.SettleTypeID,
                    this.ctrlPriceTypeID.PriceTypeID,
                    this.ctrlInvoiceTypeID.InvoiceTypeID,
                    this.ctrlDeliverAddressID .DeliverAddressID ,
                    this.ctrlFinanceAddressID .FinanceAddressID ,
                    this.ctrlDeliverTypeID.DeliverTypeID,
                    this.txtExpressRequire.Text,
                    JERPBiz.Frame.UserBiz.PsnID,
                    this.rchMemo.Text);
            }
            if (!flag)
            {              
                MessageBox.Show(errormsg);
            }
            return flag;

        }
        void SaveItem()
        {
            foreach (DataRow drow in this.dtblItems.Rows )
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow.RowState ==DataRowState.Unchanged) continue;
                string ErrorMsg=string.Empty;
		        object  objItemID=drow["ItemID"];
                bool flag = false;
                if (objItemID == DBNull.Value)
                {
                    flag = this.accItems.InsertSaleOrderItems(ref ErrorMsg,
                         ref objItemID,
                         this.NoteID ,
                         drow["PrdID"],
                         drow["ItemNo"],
                         drow["CustomerRef"],
                         drow["BatchNo"],
                         drow["Quantity"],
                         drow["Price"],
                         drow["DateTarget"], 
                         drow["Memo"]);
                    if (flag)
                    {
                        drow["ItemID"] = objItemID;
                        drow.AcceptChanges();
                    }
                }
                else
                {
                    flag=this.accItems.UpdateSaleOrderItems(ref ErrorMsg,
			            drow["ItemID"],
                        drow["PrdID"],
                        drow["ItemNo"],
                        drow["CustomerRef"], 
                        drow["BatchNo"],
			            drow["Quantity"],
			            drow["Price"],
                        drow["DateTarget"], 
                        drow["Memo"]);
		                if(flag)
		                {
			                drow.AcceptChanges ();
		                }
                }

                if (!flag)
                {
                    
                    MessageBox.Show(ErrorMsg);
                }
            
            }
        }
        void SaveCustomer()
        {
            string errormsg = string.Empty;
            this.accCustomer.UpdateCustomerForDateLastOrder(ref errormsg,
                this.NoteEntity .CompanyID);
        }
        private bool ValidateData()
        {
            if (this.ctrlCompanyID.CompanyID == -1)
            {
                MessageBox.Show("客户不能为空！", "出错啦!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (this.ctrlMoneyTypeID.MoneyTypeID == -1)
            {
                MessageBox.Show("币种不能为空！", "出错啦!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (this.ctrlSettleTypeID.SettleTypeID == -1)
            {
                MessageBox.Show("结算方式不能为空！", "出错啦!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (this.ctrlPriceTypeID.PriceTypeID == -1)
            {
                MessageBox.Show("单价类型不能为空！", "出错啦!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (this.ctrlInvoiceTypeID.InvoiceTypeID  == -1)
            {
                MessageBox.Show("发票类型不能为空！", "出错啦!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void SaveTotalAMT()
        {
            string errormsg = string.Empty;
            this.accNotes.UpdateSaleOrderNotesForTotalAMT(ref errormsg, this.NoteID);

        }
        void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateData() == false) return;
            if (this.NoteID == -1)
            {
                 DialogResult rul = MessageBox.Show("即将进行新增订单,一经保存,客户及接单日期不能变更！", "操作确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                 if (rul == DialogResult.No) return;

            }
            if (this.SaveNote())
            {
                this.SaveItem();
                this.SaveCustomer();
                this.SaveTotalAMT();
                if (this.affterSave != null) this.affterSave();
                MessageBox.Show("成功保存当前订单");
            }
        }
       
        void btnDelete_Click(object sender, EventArgs e)
        {
              DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
              if (rul == DialogResult.Yes)
              {
                  string errormsg=string.Empty ;
                  bool flag=this.accNotes.DeleteSaleOrderNotes(ref errormsg, this.NoteID);
                  if (!flag)
                  {
                      MessageBox.Show(errormsg);
                      return;
                  }
                  this.SaveCustomer();
                  if (this.affterSave != null) this.affterSave();
                  this.Close();
              }
        }
     

    }
}