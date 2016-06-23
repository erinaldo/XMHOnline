using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Supply.OtherRes
{
    public partial class FrmOrderNoteOper : Form
    {
        public FrmOrderNoteOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accItems = new JERPData.OtherRes.BuyOrderItems();
            this.accNotes = new JERPData.OtherRes.BuyOrderNotes();
            this.accPrds = new JERPData.OtherRes.Product ();
            this.NoteEntity = new JERPBiz.OtherRes.BuyOrderNoteEntity();
            this.accSupplier = new JERPData.General.Supplier();
            this.accPrice = new JERPData.OtherRes.BuyPriceItems();
            this.accPriceNotes = new JERPData.OtherRes.BuyPriceNotes(); 
            
            this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
            this.dgrdv.CellValueChanged +=new DataGridViewCellEventHandler(dgrdv_CellValueChanged);
            this.dgrdv.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdv_DataBindingComplete);
            this.dgrdv.CellEnter += new DataGridViewCellEventHandler(dgrdv_CellEnter); 
            this.dgrdv.CellQuery += new JCommon.MyDataGridView.CellQueryDelegate(dgrdv_CellQuery);
            this.dgrdv.CellContextMenuStripNeeded += new DataGridViewCellContextMenuStripNeededEventHandler(dgrdv_CellContextMenuStripNeeded);
            this.btnAddPrd.Click += new EventHandler(btnAddPrd_Click);
            this.btnSafeStore.Click += new EventHandler(btnSafeStore_Click);
            this.btnNew.Click += new EventHandler(btnNew_Click);
            this.btnDelete.Click += new EventHandler(btnDelete_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click); 
            this.FormClosed += new FormClosedEventHandler(FrmBuyOrderNoteOper_FormClosed);
            this.lnkFile.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkFile_LinkClicked);
            this.ctrlCompanyID.AffterSelected += this.SetPriceElement;
            this.ctrlMoneyTypeID.AffterSelected += this.SetAllPrice;
            this.ctrlSettleTypeID.AffterSelected += this.SetAllPrice;
            this.ctrlPriceTypeID.AffterSelected += this.SetAllPrice;
            this.dtblPrds = this.accPrds.GetDataProduct().Tables[0];
            this.btnAddPlan.Click += new EventHandler(btnAddPlan_Click);
        }

    
        private JERPData.OtherRes.BuyOrderNotes accNotes;
        private JERPData.OtherRes.BuyOrderItems accItems;
        private JERPData.OtherRes.Product  accPrds;
        private JERPBiz.OtherRes.BuyOrderNoteEntity NoteEntity;
        private JERPApp.Define.OtherRes.FrmProduct frmPrd;
        private JERPApp.Define.OtherRes.FrmProduct frmAddPrd; 
        private JERPData.General.Supplier accSupplier;
        private JCommon.FrmFileBrowse frmFileBrowse;
        private JERPData.OtherRes.BuyPriceItems accPrice;
        private JERPData.OtherRes.BuyPriceNotes accPriceNotes;
        private FrmOrderItemFromSafeStore frmFromStore; 
        private FrmOrderItemFromPlan  frmFromPlan;
        private JCommon.FrmGridFind frmGridPrd;
        private DataTable  dtblItems, dtblPrds;
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
            this.rchMemo.Text = string.Empty;
            this.ctrlDeliverAddress.LoadData();
            this.LoadItems();
        }
        public void EditNote(long NoteID)
        {
            this.NoteID = NoteID;
            this.NoteEntity.LoadData(NoteID);
            this.txtNoteCode.Text = this.NoteEntity .NoteCode ; 
            this.dpkDateNote.Value = this.NoteEntity.DateNote;
            this.ctrlCompanyID.CompanyID = this.NoteEntity.CompanyID;
            this.ctrlMoneyTypeID.MoneyTypeID = this.NoteEntity.MoneyTypeID;
            this.ctrlSettleTypeID.SettleTypeID = this.NoteEntity.SettleTypeID;
            this.ctrlPriceTypeID.PriceTypeID = this.NoteEntity.PriceTypeID;
            this.ctrlInvoiceTypeID.InvoiceTypeID = this.NoteEntity.InvoiceTypeID;
            this.ctrlDeliverAddress.LoadData();
            this.ctrlDeliverAddress.DeliverAddress = this.NoteEntity.DeliverAddress;
            this.ctrlDeliverTypeID.DeliverTypeID = this.NoteEntity.DeliverTypeID;
            this.txtExpressRequire.Text = this.NoteEntity.ExpressRequire;
            this.rchMemo.Text = this.NoteEntity.Memo  ;
            this.LoadItems();
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
            this.frmFileBrowse.Browse(JERPData.ServerParameter.ERPFileFolder + @"\Supply\OtherResOrderNote\" + this.NoteID.ToString());
            this.frmFileBrowse.ShowDialog();
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
                if (!flag)
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

            decimal Price =0;
            this.accPrice .GetParmBuyPriceItemsPrice (
                this.ctrlCompanyID.CompanyID,
                this.ctrlMoneyTypeID.MoneyTypeID,
                this.ctrlSettleTypeID.SettleTypeID,
                this.ctrlPriceTypeID.PriceTypeID,
                this.dpkDateNote .Value .Date ,
                PrdID,
                ref Price);
            if (Price > -1)
            {
                return Price;
            }
            this.accItems .GetParmBuyOrderItemsLastPrice (
                this.ctrlCompanyID.CompanyID,
                this.ctrlMoneyTypeID.MoneyTypeID,
                this.ctrlSettleTypeID .SettleTypeID,
                this.ctrlPriceTypeID .PriceTypeID,
                PrdID ,
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
                    this.frmGridPrd.AddGridColumn("PrdName", "产品名称", 100);
                    this.frmGridPrd.AddGridColumn("PrdSpec", "型号及规格", 120);   
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
            grow.Cells[this.ColumnPrdName.Name].Value = drow["PrdName"];
            grow.Cells[this.ColumnPrdSpec.Name].Value = drow["PrdSpec"];
            grow.Cells[this.ColumnUnitName.Name].Value = drow["UnitName"]; 

        }
        void dgrdv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow grow in this.dgrdv.Rows)
            {
                grow.ErrorText = string.Empty;
                bool flag = (grow.Cells[this.ColumnPlanQty.Name].Value != DBNull.Value);
                grow.Cells[this.ColumnAssistantCode.Name].ReadOnly = flag; 
                if (grow.Cells[this.ColumnQuantity.Name].Value == DBNull.Value)
                {
                    grow.ErrorText = "未设数量";
                    continue;
                }
              
                if (grow.Cells[this.ColumnPrdID.Name].Value == DBNull.Value)
                {
                    grow.ErrorText = "未设产品";
                    continue;
                }
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
                    this.dgrdv[this.ColumnPrice.Name, irow].Value = this.GetPrice((int)objPrdID);
                }
            }
          
        }
        void dgrdv_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if ((this.dgrdv.Columns[icol].DataPropertyName == "PrdName")
               || (this.dgrdv.Columns[icol].DataPropertyName == "PrdSpec")
       )
            {
                if (this.dgrdv[this.ColumnPlanQty.Name, irow].Value != DBNull.Value) return;
                this.dgrdv.CurrentCell = this.dgrdv[icol, irow];
                if (frmPrd == null)
                {
                    this.frmPrd = new JERPApp.Define.OtherRes.FrmProduct();
                    new FrmStyle(this.frmPrd).SetPopFrmStyle(this);
                    this.frmPrd.AllowAppendFlag = true;
                    this.frmPrd.AffterSelected += frmPrd_AffterSelected;
                }
                this.frmPrd.ShowDialog();

            }
        }
        void frmPrd_AffterSelected(DataRow drow)
        {
            DataGridViewRow grow = this.dgrdv.CurrentRow;
            int PrdID = (int)drow["PrdID"];
            grow.Cells[this.ColumnPrdID.Name].Value = drow["PrdID"];
            grow.Cells[this.ColumnPrdName.Name].Value = drow["PrdName"];
            grow.Cells[this.ColumnPrdSpec.Name].Value = drow["PrdSpec"];
            grow.Cells[this.ColumnUnitName.Name].Value = drow["UnitName"]; 
            grow.Cells[this.ColumnPrice.Name].Value = this.GetPrice(PrdID);        
            frmPrd.Close();
        }
        void btnAddPrd_Click(object sender, EventArgs e)
        {
            if (frmAddPrd == null)
            {
                this.frmAddPrd = new JERPApp.Define.OtherRes.FrmProduct();
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
            drowNew["PrdName"] = drow["PrdName"];
            drowNew["PrdSpec"] = drow["PrdSpec"];
            drowNew["UnitName"] = drow["UnitName"];
            drowNew["Price"] = this.GetPrice(PrdID); 
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
        private bool SaveNote()
        {
            bool flag = false;
            string errormsg = string.Empty;
            if (this.NoteID == -1)
            {
                object objNoteID = DBNull.Value;
                object objNoteCode = DBNull.Value;
                flag = this.accNotes.InsertBuyOrderNotes(ref errormsg, ref objNoteID,
                    ref objNoteCode, 
                    this.dpkDateNote.Value.Date,
                    this.ctrlCompanyID.CompanyID, 
                    this.ctrlDeliverAddress.DeliverAddress,
                    this.ctrlDeliverTypeID.DeliverTypeID,
                    this.txtExpressRequire.Text,
                    this.ctrlMoneyTypeID.MoneyTypeID,
                    this.ctrlSettleTypeID.SettleTypeID,
                    this.ctrlPriceTypeID.PriceTypeID,
                    this.ctrlInvoiceTypeID .InvoiceTypeID ,
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
                    this.ctrlMoneyTypeID .MoneyTypeID ,
                    this.ctrlSettleTypeID .SettleTypeID ,
                    this.ctrlPriceTypeID .PriceTypeID ,
                    this.ctrlInvoiceTypeID .InvoiceTypeID ,
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
            string ErrorMsg = string.Empty;
            object objItemID =DBNull.Value;
            bool flag = false;
            foreach (DataRow drow in this.dtblItems.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow.RowState ==DataRowState.Unchanged) continue;
                objItemID = drow["ItemID"];
                if (objItemID == DBNull.Value)
                {
                    flag = this.accItems.InsertBuyOrderItems(ref ErrorMsg,
                         ref objItemID,
                         this.NoteID ,
                         drow["PrdID"],
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
        private void SaveSupplier()
        {
            string errormsg = string.Empty;
            this.accSupplier.UpdateSupplierForDateLastOrder(ref errormsg, this.NoteEntity.CompanyID);

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
            DataRow[] drows = this.dtblItems.Select("", "", DataViewRowState.CurrentRows);
            if (drows.Length == 0)
            {
                MessageBox.Show("没有任何明细项");
                return false;
            }
          
            drows = this.dtblItems.Select(" Quantity is null ", "", DataViewRowState.CurrentRows);
            if (drows.Length > 0)
            {
                MessageBox.Show("存在明细出错,注单数量，单价单位及价格!");               
                return false;
            }
            return true;
        }
        void btnAddPlan_Click(object sender, EventArgs e)
        {
            if (frmFromPlan == null)
            {
                frmFromPlan =new FrmOrderItemFromPlan ();
                frmFromPlan.AffterSave += new FrmOrderItemFromPlan.AffterSaveDelegate(frmFromPlan_AffterSave);
                new FrmStyle(frmFromPlan).SetPopFrmStyle(this);
            }
            DataTable dt = dtblItems.DefaultView.ToTable(true, "PrdID");
            frmFromPlan.BuyOrderFromPlan(dt.Select());
            frmFromPlan.ShowDialog();
        }

        void frmFromPlan_AffterSave(DataRow drowPlan)
        {

            int PrdID = (int)drowPlan["PrdID"];
            DataRow[] drows = this.dtblItems.Select("PrdID=" + PrdID.ToString(), "", DataViewRowState.CurrentRows);
            if (drows.Length > 0) return;
            DataRow drowNew = this.dtblItems.NewRow();
            drowNew["PrdID"] = PrdID;
            drowNew["PrdName"] = drowPlan["PrdName"];
            drowNew["PrdSpec"] = drowPlan["PrdSpec"];
            drowNew["UnitName"] = drowPlan["UnitName"]; 
            drowNew["PlanQty"] = drowPlan["NonFinishedQty"];   
            drowNew["Price"] = this.GetPrice(PrdID); 
            this.dtblItems.Rows.Add(drowNew);
        }

    
        void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateData() == false) return;
            if (this.NoteID == -1)
            {
                DialogResult rul = MessageBox.Show("将进行订单保存,一经保存供应商、下单日期限不能变更", "新增提醒", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
    

         void btnSafeStore_Click(object sender, EventArgs e)
        {
            if (frmFromStore == null)
            {
                this.frmFromStore = new FrmOrderItemFromSafeStore();
                new FrmStyle(this.frmFromStore).SetPopFrmStyle(this);
                this.frmFromStore.AffterSave += new FrmOrderItemFromSafeStore.AffterSaveDelegate(frmFromStore_AffterSave);
            }
            DataTable dtblNonBuys = new DataTable();
            dtblNonBuys.Columns.Add("PrdID", typeof(int));
            dtblNonBuys.Columns.Add("Quantity", typeof(decimal));
            DataRow[] drowItems = this.dtblItems.Select("ItemID is null", "", DataViewRowState.CurrentRows);
            foreach (DataRow drowItem in drowItems)
            {
                int PrdID = (int)drowItem["PrdID"];
                decimal Quantity = (decimal)drowItem["Quantity"];
                DataRow[] drowNonPO = dtblNonBuys.Select("PrdID=" + PrdID.ToString());
                if (drowNonPO.Length > 0)
                {
                    drowNonPO[0]["Quantity"] = (decimal)drowNonPO[0]["Quantity"] + Quantity;
                }
                else
                {
                    dtblNonBuys.Rows.Add(PrdID, Quantity);
                }

            }
            frmFromStore.ItemFromStore(dtblNonBuys.Select("Quantity>0"));
            frmFromStore.ShowDialog();
        }

        void frmFromStore_AffterSave(DataRow drowStore)
        {
            int PrdID=(int)drowStore ["PrdID"];
            decimal Quantity=(decimal)drowStore ["RequireQty"];
            DataRow[] drowItems = this.dtblItems.Select("PrdID=" + PrdID.ToString());
            DataRow drowItem;
            if (drowItems.Length > 0)
            {
                drowItem = drowItems[0];
                drowItem["Quantity"] = (decimal)drowItem["Quantity"] + Quantity;
            }
            else
            {
                drowItem = this.dtblItems.NewRow();
                drowItem["PrdID"] = PrdID;
                drowItem["Quantity"] = Quantity;
                drowItem["Price"] = this.GetPrice(PrdID);
                drowItem["DateTarget"] = drowStore["DateTarget"]; 
                this.dtblItems.Rows.Add(drowItem);
            }
        }

   
    }
}