using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Supply.Product
{
    public partial class FrmOrderNoteOper : Form
    {
        public FrmOrderNoteOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accItems = new JERPData.Product.BuyOrderItems();
            this.accNotes = new JERPData.Product.BuyOrderNotes();
            this.accPrds = new JERPData.Product.Product();
            this.NoteEntity = new JERPBiz.Product.BuyOrderNoteEntity();
            this.accSupplierPrdCode = new JERPData.Product.SupplierPrdCode();
            this.accSupplier = new JERPData.General.Supplier();
            this.accPrice = new JERPData.Product.BuyPriceItems();
            this.accRoadReserve = new JERPData.Product.RoadStoreReserve();
            this.accPriceNotes = new JERPData.Product.BuyPriceNotes();
            this.dtblPrds = this.accPrds.GetDataProductForFinishedPrd().Tables[0];
            this.dgrdv.CellQuery += new JCommon.MyDataGridView.CellQueryDelegate(dgrdv_CellQuery);
            this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
            this.dgrdv.CellValueChanged += new DataGridViewCellEventHandler(dgrdv_CellValueChanged);
            this.dgrdv.CellEnter += new DataGridViewCellEventHandler(dgrdv_CellEnter);
            this.dgrdv.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdv_DataBindingComplete);
            this.dgrdv.CellContextMenuStripNeeded += new DataGridViewCellContextMenuStripNeededEventHandler(dgrdv_CellContextMenuStripNeeded);
            this.btnAddItem.Click += new EventHandler(btnAddItem_Click);
            this.btnNew.Click += new EventHandler(btnNew_Click);
            this.btnDelete.Click += new EventHandler(btnDelete_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.lnkFile.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkFile_LinkClicked);
            this.btnAddPrd .Click +=new EventHandler(btnAddPrd_Click);
            this.FormClosed += new FormClosedEventHandler(FrmBuyOrderNoteOper_FormClosed);

            this.ctrlCompanyID.AffterSelected += this.SetPriceElement;
            this.ctrlMoneyTypeID.AffterSelected += this.SetAllPrice;
            this.ctrlSettleTypeID.AffterSelected += this.SetAllPrice;
            this.ctrlPriceTypeID.AffterSelected += this.SetAllPrice;
        }

        private JERPData.Product.BuyOrderNotes accNotes;
        private JERPData.Product.BuyOrderItems accItems;
        private JERPData.Product.Product accPrds;
        private JERPBiz.Product.BuyOrderNoteEntity NoteEntity;
        private JERPData.Product.SupplierPrdCode accSupplierPrdCode;
        private JERPApp.Define.Product.FrmFinishedPrd frmPrd;
        private JERPApp.Define.Product.FrmFinishedPrd frmAddPrd;
        private JERPData.Product.RoadStoreReserve accRoadReserve;
        private JCommon.FrmFileBrowse frmFileBrowse;
        private JERPData.General.Supplier accSupplier;
        private JERPData.Product.BuyPriceItems accPrice;
        private JERPData.Product.BuyPriceNotes accPriceNotes;
        private JCommon.FrmGridFind frmGridPrd;
        private FrmOrderItemFromPlan frmFromPlan;
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
                this.btnDelete.Enabled = (value > -1);
                this.lnkFile.Enabled = (value > -1);
                this.ctrlCompanyID.Enabled = (value == -1);
                this.dpkDateNote.Enabled = (value == -1);
            }
        }
        
        void SetPriceElement()
        {
            int CompanyID = this.ctrlCompanyID.CompanyID;
            int MoneyTypeID = 1;
            int SettleTypeID = 1;
            int PriceTypeID = 1;
            this.accPriceNotes.GetParmBuyPriceNotesLastElement(
                CompanyID,
                ref MoneyTypeID,
                ref SettleTypeID,
                ref PriceTypeID);
            this.ctrlMoneyTypeID.MoneyTypeID = MoneyTypeID;
            this.ctrlSettleTypeID.SettleTypeID = SettleTypeID;
            this.ctrlPriceTypeID.PriceTypeID = PriceTypeID;
            this.SetAllPrice();
        }
        private void SetAllPrice()
        {
            if (this.dtblItems == null) return;
            foreach (DataRow drow in this.dtblItems.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow["PrdID"] == DBNull.Value) continue;
                drow["Price"] = this.GetPrice((int)drow["PrdID"]);
            }
        }
        void lnkFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.frmFileBrowse == null)
            {
                this.frmFileBrowse = new JCommon.FrmFileBrowse();
                new FrmStyle(frmFileBrowse).SetPopFrmStyle(this);
                this.frmFileBrowse.ReadOnly = false;
            }
            this.frmFileBrowse.Browse(JERPData.ServerParameter.ERPFileFolder + @"\Supply\PrdOrderNote\" + this.NoteID.ToString());
            this.frmFileBrowse.ShowDialog();
        }

        private void LoadItems()
        {
            this.dtblItems = this.accItems.GetDataBuyOrderItemsByNoteID(this.NoteID).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
            this.dtblItems.Columns["PrdID"].AllowDBNull = false;
        }
        public void NewNote()
        {
            this.NoteID = -1;
            this.SetPriceElement();
            this.txtNoteCode.Text = string.Empty;
            this.dpkDateNote.Value = DateTime.Now.Date;
            this.ctrlDeliverAddress.LoadData();
            this.rchMemo.Text = string.Empty;
            this.LoadItems();
        }
        public void EditNote(long NoteID)
        {
            this.NoteID = NoteID;
            this.NoteEntity.LoadData(NoteID);
            this.txtNoteCode.Text = this.NoteEntity.NoteCode;
            this.ctrlDeliverAddress.LoadData();
            this.ctrlCompanyID.CompanyID = this.NoteEntity.CompanyID;
            this.dpkDateNote.Value = this.NoteEntity.DateNote;
            this.ctrlDeliverAddress.DeliverAddress = this.NoteEntity.DeliverAddress;
            this.ctrlDeliverTypeID.DeliverTypeID = this.NoteEntity.DeliverTypeID;
            this.txtExpressRequire.Text = this.NoteEntity.ExpressRequire;
            this.ctrlMoneyTypeID.MoneyTypeID = this.NoteEntity.MoneyTypeID;
            this.ctrlPriceTypeID.PriceTypeID = this.NoteEntity.PriceTypeID;
            this.ctrlSettleTypeID.SettleTypeID = this.NoteEntity.SettleTypeID;
            this.ctrlInvoiceTypeID.InvoiceTypeID = this.NoteEntity.InvoiceTypeID;
            this.rchMemo.Text = this.NoteEntity.Memo;
            this.LoadItems();
        }
      
        void btnNew_Click(object sender, EventArgs e)
        {
            this.NewNote();
          
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
                flag = this.accItems .DeleteBuyOrderItems(ref ErrorMsg,
                    drow["ItemID"]);
                if (flag)
                {
                    this.accRoadReserve.UpdateStoreReserveForAdjustStore(ref ErrorMsg, drow["PrdID"]);
                }
                else
                {
                    MessageBox.Show(ErrorMsg);
                    e.Cancel = true;
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
            this.accPrice.GetParmBuyPriceItemsPrice (
                this.ctrlCompanyID.CompanyID,
                this.ctrlMoneyTypeID .MoneyTypeID,
                this.ctrlSettleTypeID .SettleTypeID,
                this.ctrlPriceTypeID.PriceTypeID,
                this.dpkDateNote .Value .Date  ,
                PrdID ,
                ref Price);
            if (Price > -1)
            {
                return Price;
            }
            this.accItems.GetParmBuyOrderItemsLastPrice(
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
        private object GetSupplierPrdCode(int PrdID)
        {
            string SupplierPrdCode = string.Empty;
            this.accSupplierPrdCode.GetParmSupplierPrdCode(PrdID, this.NoteEntity.CompanyID,
                ref SupplierPrdCode);
            if (SupplierPrdCode != string.Empty)
            {
                return SupplierPrdCode;
            }
            return DBNull.Value;
        }
        private object GetMinPackingQty(int PrdID)
        {
            DataRow[] drows = this.dtblPrds.Select("PrdID=" + PrdID.ToString());
            if (drows.Length > 0)
            {
                return drows[0]["MinPackingQty"];
            }
            return DBNull.Value;
        }
        private decimal GetQuantity(object objMinPackingQty, decimal PlanQty)
        {
            if (objMinPackingQty == DBNull.Value) return PlanQty;
            if ((decimal)objMinPackingQty <= 0) return PlanQty;
            return Math.Ceiling(PlanQty / (decimal)objMinPackingQty) * (decimal)objMinPackingQty;
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
                    this.dgrdv[this.ColumnMinPackingQty.Name, irow].Value = this.GetMinPackingQty((int)objPrdID);
                    this.dgrdv[this.ColumnPrice.Name, irow].Value = this.GetPrice ((int)objPrdID );
                    this.dgrdv[this.ColumnSupplierPrdCode.Name, irow].Value = this.GetSupplierPrdCode((int)objPrdID);
                }
            }
        }

        void dgrdv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach(DataGridViewRow grow in this.dgrdv .Rows )
            {
              
                if (grow.IsNewRow) continue;
                bool flag = (grow.Cells [this.ColumnPlanQty.Name ].Value != DBNull.Value);
                grow.Cells[this.ColumnPrdCode.Name].ReadOnly = flag;
                grow.Cells[this.ColumnPrdName.Name].ReadOnly = flag;
                grow.Cells[this.ColumnPrdSpec.Name].ReadOnly = flag;
                grow.Cells[this.ColumnUnitName.Name].ReadOnly = flag;
                grow.Cells[this.ColumnQuantity.Name].ReadOnly = flag;
            }
        }
        private bool SaveNote()
        {
            bool flag = false;
            string errormsg = string.Empty;
            if (this.NoteID == -1)
            {
                object objNoteID = DBNull.Value;
                object objNoteCode = DBNull.Value;
                flag = this.accNotes.InsertBuyOrderNotes(ref errormsg,
                       ref objNoteID,
                       ref objNoteCode,
                       this.dpkDateNote.Value.Date,
                       this.ctrlCompanyID.CompanyID,
                       this.ctrlDeliverAddress.DeliverAddress,
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
                    this.txtNoteCode.Text = objNoteCode.ToString();
                }
            }
            else
            {
                flag = this.accNotes.UpdateBuyOrderNotes(ref errormsg,
                    this.NoteID,
                    this.ctrlDeliverAddress.DeliverAddress,
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
                MessageBox.Show(errormsg);
            }
            return flag;

        }
        void SaveItem()
        {
            foreach (DataRow drow in this.dtblItems.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow.RowState ==DataRowState.Unchanged) continue;
                string ErrorMsg=string.Empty;
		        object  objItemID=drow["ItemID"];
                bool flag = false;
                if (objItemID == DBNull.Value)
                {
                    flag = this.accItems.InsertBuyOrderItems(ref ErrorMsg,
                         ref objItemID,
                         this.NoteID,
                         drow["PrdID"],
                         drow["SupplierPrdCode"],
                         drow["PlanQty"],
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
                    flag=this.accItems.UpdateBuyOrderItems(ref ErrorMsg,
			            drow["ItemID"],
                        drow["PrdID"],
                        drow["SupplierPrdCode"],
			            drow["Quantity"],
			            drow["Price"],
			            drow["DateTarget"],
                        drow["Memo"]);
		                if(flag)
		                {
			                drow.AcceptChanges ();
                            this.accRoadReserve.UpdateStoreReserveForAdjustStore(ref ErrorMsg,
                                drow["PrdID"]);
		                }
                }
                if (flag)
                {
                    if (drow["SupplierPrdCode"] != DBNull.Value)
                    {
                        this.accSupplierPrdCode.SaveSupplierPrdCode(ref ErrorMsg,
                            drow["PrdID"],
                            this.ctrlCompanyID.CompanyID,
                            drow["SupplierPrdCode"]);
                      
                    }                  
                }
                else
                {
                    MessageBox.Show(ErrorMsg);
                }
            
            }
        }
        private void SaveSupplier()
        {
            string errormsg = string.Empty;
            this.accSupplier.UpdateSupplierForDateLastOrder(ref errormsg, this.NoteEntity .CompanyID);

        }
        private bool ValidateData()
        {
            if (this.ctrlCompanyID.CompanyID == -1)
            {
                MessageBox.Show("供应商不能为空！", "出错啦!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (this.ctrlInvoiceTypeID.InvoiceTypeID == -1)
            {
                MessageBox.Show("发票类型不能为空！", "出错啦!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            DataRow[] drows = this.dtblItems.Select("", "", DataViewRowState.CurrentRows);
            if (drows.Length == 0)
            {
                MessageBox.Show("没有任何明细项");
                return false;
            }          
            drows = this.dtblItems.Select( "Quantity is null", "", DataViewRowState.CurrentRows);
            if (drows.Length > 0)
            {
                MessageBox.Show("存在数量不能为空项!");              
                return false;
            }
            return true;
        }
        void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateData() == false) return;
            if (this.NoteID == -1)
            {
                DialogResult rul = MessageBox.Show("将进行订单保存,一经保存供应商及下单日期不能变更", "新增提醒", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rul == DialogResult.No) return;
            }
            if (this.SaveNote())
            {
                this.SaveItem();
                this.SaveSupplier();
                MessageBox.Show("成功保存当前订单");
            }

        }
        void FrmBuyOrderNoteOper_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.affterSave != null) this.affterSave();
        }
        void btnDelete_Click(object sender, EventArgs e)
        {
              DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
              if (rul == DialogResult.Yes)
              {
                  string errormsg=string.Empty ;
                  bool flag = this.accNotes.DeleteBuyOrderNotes(ref errormsg, this.NoteID);
                  if (!flag)
                  {
                      MessageBox.Show(errormsg, "出借啦!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                      return;
                  }             
                  this.Close();
              }
        } 
        void btnAddItem_Click(object sender, EventArgs e)
        {
            if (frmFromPlan == null)
            {
                frmFromPlan = new FrmOrderItemFromPlan();
                frmFromPlan.AffterSave += new FrmOrderItemFromPlan.AffterSaveDelegate(frmFromPlan_AffterSave);
                new FrmStyle(frmFromPlan).SetPopFrmStyle(this);
            }
            DataRow[] drows = this.dtblItems.Select("ItemID is null", "", DataViewRowState.CurrentRows);
            frmFromPlan.BuyOrderFromPlan(drows);
            frmFromPlan.ShowDialog();
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
                    this.frmGridPrd.AddGridColumn("PrdCode", "产品编号", 100);
                    this.frmGridPrd.AddGridColumn("PrdName", "产品名称", 120);
                    this.frmGridPrd.AddGridColumn("PrdSpec", "产品规格", 100);
                    this.frmGridPrd.AddGridColumn("Model", "机型", 66); 
                    this.frmGridPrd.AddGridColumn("AssistantCode", "助记码", 66);
                    this.frmGridPrd.AffterSelected += frmGridPrd_AffterSelected;

                }
              
                this.frmGridPrd.Query(this.dtblPrds, "AssistantCode", this.dgrdv.CurrentCell);
               
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
        void dgrdv_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if ((this.dgrdv.Columns[icol].DataPropertyName == "PrdCode")
              || (this.dgrdv.Columns[icol].DataPropertyName == "PrdName")
              || (this.dgrdv.Columns[icol].DataPropertyName == "PrdSpec")
              || (this.dgrdv.Columns[icol].DataPropertyName == "Model"))
            {
                if (this.dgrdv[this.ColumnPlanQty.Name, irow].Value != DBNull.Value) return;
                this.dgrdv.CurrentCell = this.dgrdv[icol, irow];
                if (frmPrd == null)
                {
                    this.frmPrd = new JERPApp.Define.Product.FrmFinishedPrd();
                    new FrmStyle(this.frmPrd).SetPopFrmStyle(this);
                    this.frmPrd.AffterSelected += new JERPApp.Define.Product.FrmFinishedPrd.AffterSelectedDelegate(frmPrd_AffterSelected);
                }
                this.frmPrd.ShowDialog();
            }
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
            grow.Cells[this.ColumnMinPackingQty.Name].Value = this.GetMinPackingQty(PrdID);
            grow.Cells[this.ColumnSupplierPrdCode.Name].Value = this.GetSupplierPrdCode (PrdID);
            frmPrd.Close();

        }
        void btnAddPrd_Click(object sender, EventArgs e)
        {
            if (frmAddPrd == null)
            {
                this.frmAddPrd = new JERPApp.Define.Product.FrmFinishedPrd();
                new FrmStyle(this.frmAddPrd).SetPopFrmStyle(this);
                this.frmAddPrd.AffterSelected += frmAddPrd_AffterSelected;
            }
            this.frmAddPrd.ShowDialog();
        }

        void frmAddPrd_AffterSelected(DataRow drow)
        {
            int PrdID = (int)drow["PrdID"];
            if (this.dtblItems.Select("PrdID=" + PrdID.ToString(), "", DataViewRowState.CurrentRows).Length > 0)
            {
                return;
            }
            DataRow drowNew = this.dtblItems.NewRow();
            drowNew["PrdID"] = PrdID;
            drowNew["PrdCode"] = drow["PrdCode"];
            drowNew["PrdName"] = drow["PrdName"];
            drowNew["PrdSpec"] = drow["PrdSpec"];
            drowNew["Model"] = drow["Model"];
            drowNew["UnitName"] = drow["UnitName"]; 
            drowNew["Price"] = this.GetPrice(PrdID);
            drowNew["SupplierPrdCode"] = this.GetSupplierPrdCode(PrdID); 
            drowNew["MinPackingQty"] = this.GetMinPackingQty (PrdID);
            drowNew["Quantity"] = drowNew["MinPackingQty"];
            this.dtblItems.Rows.Add(drowNew);
        }
        void frmFromPlan_AffterSave(DataRow drowPlan)
        {
           
            int PrdID = -1;
            PrdID = (int)drowPlan["PrdID"];
            DataRow[] drows = this.dtblItems.Select("PrdID=" + PrdID.ToString(), "", DataViewRowState.CurrentRows);
            if (drows.Length > 0) return;
            DataRow drowNew = this.dtblItems.NewRow(); 
            drowNew["PrdID"] = PrdID;
            drowNew["PrdCode"] = drowPlan["PrdCode"];
            drowNew["PrdName"] = drowPlan["PrdName"];
            drowNew["PrdSpec"] = drowPlan["PrdSpec"];
            drowNew["Model"] = drowPlan["Model"];
            drowNew["UnitName"] = drowPlan["UnitName"]; 
            drowNew["SupplierPrdCode"] = this.GetSupplierPrdCode(PrdID); 
            decimal NonFinishedQty = (decimal)drowPlan["NonFinishedQty"];
            drowNew["PlanQty"] = NonFinishedQty;
            object objMinPackingQty = this.GetMinPackingQty(PrdID);
            drowNew["MinPackingQty"] = objMinPackingQty;
            drowNew["Quantity"] = this.GetQuantity(objMinPackingQty, NonFinishedQty);
            drowNew["Price"] = this.GetPrice(PrdID);
            drowNew["DateTarget"] = drowPlan["DateTarget"];
            this.dtblItems.Rows.Add(drowNew);
           
        }  
    }
}