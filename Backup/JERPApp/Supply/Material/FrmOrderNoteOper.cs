using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Supply.Material
{
    public partial class FrmOrderNoteOper : Form
    {
        public FrmOrderNoteOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accItems = new JERPData.Material.BuyOrderItems();
            this.accNotes = new JERPData.Material.BuyOrderNotes();
            this.accPrds = new JERPData.Product.Product ();
            this.NoteEntity = new JERPBiz.Material.BuyOrderNoteEntity();
            this.accSupplierPrdCode = new JERPData.Product .SupplierPrdCode();
            this.accSupplier = new JERPData.General.Supplier();
            this.accPrice = new JERPData.Material.BuyPriceItems();
            this.accRoadStoreReserve = new JERPData.Material.RoadStoreReserve();
            this.accPrdSetBom = new JERPData.Product.PrdSet();
            this.dtblPrds = this.accPrds.GetDataProductForMaterial().Tables[0];
            this.accPriceNotes = new JERPData.Material.BuyPriceNotes();
            ToolTip tip = new ToolTip();
            tip.SetToolTip(this.btnAddItem, "本供应商");
            tip.SetToolTip(this.btnAddOtherItem, "其他供应商");
            this.dgrdv.CellEnter += new DataGridViewCellEventHandler(dgrdv_CellEnter); 
            this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
            this.dgrdv.CellValueChanged +=new DataGridViewCellEventHandler(dgrdv_CellValueChanged);
            this.dgrdv.CellQuery += new JCommon.MyDataGridView.CellQueryDelegate(dgrdv_CellQuery);
            this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
            this.dgrdv.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdv_DataBindingComplete);
            this.dgrdv.CellContextMenuStripNeeded += new DataGridViewCellContextMenuStripNeededEventHandler(dgrdv_CellContextMenuStripNeeded);
            this.btnAddItem.Click += new EventHandler(btnAddItem_Click);
            this.btnAddSetPrd.Click += new EventHandler(btnAddSetPrd_Click);
            this.btnAddOtherItem.Click += new EventHandler(btnAddOtherItem_Click);
            this.btnSafeStore.Click += new EventHandler(btnSafeStore_Click);
            this.btnAddPrd.Click += new EventHandler(btnAddPrd_Click);
            this.btnDelete.Click += new EventHandler(btnDelete_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.lnkFile.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkFile_LinkClicked);
            this.FormClosed += new FormClosedEventHandler(FrmBuyOrderNoteOper_FormClosed);
            this.ctrlCompanyID.AffterSelected +=  this.SetPriceElement;
            this.ctrlMoneyTypeID.AffterSelected += this.SetAllPrice;
            this.ctrlSettleTypeID.AffterSelected += this.SetAllPrice;
            this.ctrlPriceTypeID.AffterSelected += this.SetAllPrice;
            this.dtblPrdItems = new DataTable();
            this.dtblPrdItems.Columns.Add("PrdID", typeof(int));
            this.dtblPrdItems.Columns.Add("Quantity", typeof(decimal));
        }

        private JERPData.Material.BuyOrderNotes accNotes;
        private JERPData.Material.BuyOrderItems accItems;
        private JERPData.Product.Product  accPrds;
        private JERPBiz.Material.BuyOrderNoteEntity NoteEntity;
        private JERPData.Product.SupplierPrdCode accSupplierPrdCode;
        private JERPApp.Define.Material.FrmProduct frmPrd;
        private JERPApp.Define.Material.FrmProduct frmAddPrd;
        private JCommon.FrmFileBrowse frmFileBrowse;
        private JERPData.General.Supplier accSupplier;
        private JERPData.Material.BuyPriceItems accPrice;
        private JERPData.Material.BuyPriceNotes accPriceNotes;
        private JERPData.Material.RoadStoreReserve accRoadStoreReserve;
        private JERPData.Product.PrdSet accPrdSetBom;
        private JCommon.FrmGridFind frmGridPrd;
        private FrmOrderItemFromPlan frmFromPlan;
        private FrmOrderItemFromOtherPlan frmFormOtherPlan;
        private FrmOrderItemFromSetPlan frmFromSetPlan;

        private FrmOrderItemFromSafeStore frmFromStore;
        private DataTable dtblItems, dtblPrdItems,dtblPrds;       
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
                this.ctrlCompanyID.Enabled = (value == -1);
                this.dpkDateNote.Enabled = (value == -1);
            }
        }
        private object GetDateTarget(int PrdID)
        {
            DataRow[] drows = this.dtblPrds.Select("PrdID=" + PrdID.ToString());
            if (drows.Length == 0) return DBNull.Value;
            if (drows[0]["ManufDays"] == DBNull.Value) return DBNull.Value;
            return this.dpkDateNote.Value.AddDays((int)drows[0]["ManufDays"]); 
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
            this.frmFileBrowse.Browse(JERPData.ServerParameter.ERPFileFolder + @"\Supply\MtrOrderNote\" + this.NoteID.ToString());
            this.frmFileBrowse.ShowDialog();
        }

        private void LoadItems()
        {
            this.dtblItems = this.accItems.GetDataBuyOrderItemsByNoteID(this.NoteID).Tables[0];
            this.dgrdv.DataSource = this.dtblItems; 
        
        }
        private void SetPrdItems(int PrdID,decimal Quantity)
        {
            DataRow[] drowPrdItems = this.dtblPrdItems.Select("PrdID=" + PrdID.ToString(), "");
            DataRow drowPrdItem;
            if (drowPrdItems.Length == 0)
            {
                drowPrdItem = dtblPrdItems.NewRow();
                drowPrdItem["PrdID"] = PrdID;
                drowPrdItem["Quantity"] = Quantity;
                dtblPrdItems.Rows.Add(drowPrdItem);
            }
            else
            {
                drowPrdItem = drowPrdItems[0];
                drowPrdItem["Quantity"] = (decimal)drowPrdItem["Quantity"]+Quantity;
            }
        }
        private DataRow[] GetPrdItems()
        {
            this.dtblPrdItems.Clear();
            int PrdID = -1;
            decimal Quantity=0;
            DataTable dtblSetBom;
            foreach (DataRow drowItem in this.dtblItems.Select("", "", DataViewRowState.CurrentRows))
            {
                if (drowItem["Quantity"] == DBNull.Value) continue;
                PrdID = (int)drowItem["PrdID"];
                Quantity =(decimal)drowItem["Quantity"];
                dtblSetBom = this.accPrdSetBom.GetDataPrdSetBySetPrdID(PrdID).Tables[0];
                if (dtblSetBom.Rows.Count == 0)
                {
                    this.SetPrdItems(PrdID, Quantity);
                }
                else
                {
                    foreach (DataRow drowBom in dtblSetBom.Rows)
                    {
                        this.SetPrdItems((int)drowBom["PrdID"], Quantity * (decimal)drowBom["AssemblyQty"]);
                    }
                }
            }
            return this.dtblPrdItems.Select();
        }
        public void NewNote(int CompanyID)
        {
            this.NoteID = -1;
            this.ctrlCompanyID.Enabled = (CompanyID == -1);
            this.ctrlCompanyID.CompanyID = CompanyID;
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
            this.ctrlCompanyID.CompanyID  = this.NoteEntity.CompanyID  ;
            this.dpkDateNote .Value  = this.NoteEntity.DateNote;
            this.ctrlDeliverAddress.DeliverAddress = this.NoteEntity.DeliverAddress;
            this.ctrlDeliverTypeID.DeliverTypeID = this.NoteEntity.DeliverTypeID;
            this.txtExpressRequire.Text = this.NoteEntity.ExpressRequire;
            this.ctrlMoneyTypeID.MoneyTypeID = this.NoteEntity.MoneyTypeID;
            this.ctrlPriceTypeID.PriceTypeID = this.NoteEntity.PriceTypeID;
            this.ctrlSettleTypeID.SettleTypeID = this.NoteEntity.SettleTypeID;
            this.ctrlInvoiceTypeID.InvoiceTypeID = this.NoteEntity.InvoiceTypeID;

            this.rchMemo.Text = this.NoteEntity.Memo  ;
            this.LoadItems();
        }
        private void RoadRerserveAdjust(int PrdID)
        {
            string errormsg = string.Empty;
            this.accRoadStoreReserve.UpdateRoadStoreReserveForAdjustStore(ref errormsg,
                PrdID);
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
                    //调整一下库存预留
                    this.RoadRerserveAdjust((int)drow["PrdID"]);
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
            decimal Price = 0;
            this.accPrice.GetParmBuyPriceItemsPrice(
              this.ctrlCompanyID.CompanyID,
              this.ctrlMoneyTypeID.MoneyTypeID,
              this.ctrlSettleTypeID.SettleTypeID,
              this.ctrlPriceTypeID.PriceTypeID,
              this.dpkDateNote.Value.Date,
              PrdID,
              ref Price);
          
            if (Price > 0)
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
            if (Price >0)
            {
                return Price;
            }
            return DBNull.Value;
        }
       
     
        private object GetSupplierPrdCode(int PrdID)
        {
            string SupplierPrdCode = string.Empty;
            this.accSupplierPrdCode.GetParmSupplierPrdCode(PrdID, this.ctrlCompanyID .CompanyID,
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

        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnPrdCode.Name)
            {
                string url = this.dgrdv[this.ColumnURL.Name, irow].Value.ToString();
                if (url == string.Empty) return;
                System.Diagnostics.Process.Start(url);
            }
        }

       
        void dgrdv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow grow in this.dgrdv.Rows)
            {
                if (grow.IsNewRow) continue;
                bool flag = (grow.Cells[this.ColumnPlanQty.Name].Value != DBNull.Value);
                grow.Cells[this.ColumnAssistantCode.Name].ReadOnly = flag; 
                grow.Cells[this.ColumnSupplierPrdCode.Name].ReadOnly = flag;
                grow.Cells[this.ColumnUnitName.Name].ReadOnly = flag;
              
            }
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
                    this.frmGridPrd.AddGridColumn("PrdCode", "物料编号", 80);
                    this.frmGridPrd.AddGridColumn("PrdName", "物料名称", 100);
                    this.frmGridPrd.AddGridColumn("PrdSpec", "物料规格", 100);
                    this.frmGridPrd.AddGridColumn("Model", "型号", 66);
                    this.frmGridPrd.AddGridColumn("Manufacturer", "品牌", 66);
                    this.frmGridPrd.AddGridColumn("AssistantCode", "助记码", 66);
                    this.frmGridPrd.AffterSelected += frmGridPrd_AffterSelected;

                }
             
                this.frmGridPrd.Query(this.dtblPrds ,"AssistantCode",this.dgrdv.CurrentCell);
                
            }
        }
        void frmGridPrd_AffterSelected(DataRow drow)
        {
            DataGridViewRow grow = this.dgrdv.CurrentRow;
            grow.Cells[this.ColumnPrdID.Name].Value = drow["PrdID"];
            grow.Cells[this.ColumnPrdCode.Name].Value = drow["PrdCode"];
            grow.Cells[this.ColumnPrdName.Name].Value = drow["PrdName"];
            grow.Cells[this.ColumnPrdSpec.Name].Value = drow["PrdSpec"];
            grow.Cells[this.ColumnModel.Name].Value = drow["Model"];
            grow.Cells[this.ColumnManufacturer.Name].Value = drow["Manufacturer"];
            grow.Cells[this.ColumnUnitName.Name].Value = drow["UnitName"];
        }
        void dgrdv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].DataPropertyName == "PrdID")
            {
                object objPrdID = this.dgrdv[icol, irow].Value;
                if (objPrdID != DBNull.Value)
                {
                    this.dgrdv[this.ColumnSupplierPrdCode.Name, irow].Value = this.GetSupplierPrdCode((int)objPrdID);
                    this.dgrdv[this.ColumnMinPackingQty.Name, irow].Value = this.GetMinPackingQty((int)objPrdID);                   
                    this.dgrdv[this.ColumnPrice.Name, irow].Value = this.GetPrice((int)objPrdID);
                    if (this.dgrdv[this.ColumnDateTarget.Name, irow].Value == DBNull.Value)
                    {
                        this.dgrdv[this.ColumnDateTarget.Name, irow].Value = this.GetDateTarget((int)objPrdID);
                    }
                   
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
                flag = this.accNotes.InsertBuyOrderNotes (ref errormsg,
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
                    this.ctrlDeliverAddress .DeliverAddress ,
                    this.ctrlDeliverTypeID .DeliverTypeID ,
                    this.txtExpressRequire .Text ,
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
                         this.NoteID ,
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
                            //调整一下在途预留,以防减少之情况
                            this.RoadRerserveAdjust((int)drow["PrdID"]);
			                drow.AcceptChanges ();
		                }
                    
                }
                if (flag)
                {
                    if (drow["SupplierPrdCode"] != DBNull.Value)
                    {
                        this.accSupplierPrdCode.SaveSupplierPrdCode(ref ErrorMsg,
                            drow["PrdID"],
                            this.ctrlCompanyID .CompanyID,
                            drow["SupplierPrdCode"]);
                        this.accPrds.UpdateProductForSupplierPrdCode(ref ErrorMsg, drow["PrdID"]);
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
            if (this.ctrlInvoiceTypeID.InvoiceTypeID  == -1)
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
           
            drows = this.dtblItems.Select("Quantity is null or PrdID is null", "", DataViewRowState.CurrentRows);
            if (drows.Length > 0)
            {
                MessageBox.Show("存在明细出错,注意产品，数量，单价单位!");
                
                return false;
            }
          
            return true;
        }
        void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateData() == false) return;
            if (this.NoteID == -1)
            {
                DialogResult rul = MessageBox.Show("将进行订单保存,一经保存供应商，采购日期均不能变更", "新增提醒", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                  bool flag=this.accNotes.DeleteBuyOrderNotes(ref errormsg, this.NoteID);
                  if (!flag)
                  {
                      MessageBox.Show(errormsg, "出借啦!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                      return;
                  }
                  this.Close();
              }
        }
       
        private decimal GetQuantity(object objMinPackingQty, decimal PlanQty)
        {
            if (objMinPackingQty == DBNull.Value) return PlanQty;
            if((decimal)objMinPackingQty <=0)return PlanQty ;
            return  Math.Ceiling(PlanQty / (decimal)objMinPackingQty) * (decimal)objMinPackingQty;
        }
        void btnAddItem_Click(object sender, EventArgs e)
        {
            if (this.ctrlCompanyID.CompanyID == -1)
            {
                MessageBox.Show("未选择任何供应商");
                return;
            }
            if (frmFromPlan == null)
            {
                frmFromPlan = new FrmOrderItemFromPlan();
                frmFromPlan.AffterSave += frmFromPlan_AffterSave;
                new FrmStyle(frmFromPlan).SetPopFrmStyle(this);
            }
       
            frmFromPlan.BuyOrderFromPlan(this.ctrlCompanyID .CompanyID ,this.GetPrdItems ());
            frmFromPlan.ShowDialog();
        }
        void btnAddOtherItem_Click(object sender, EventArgs e)
        {
            if (this.ctrlCompanyID.CompanyID == -1)
            {
                MessageBox.Show("未选择任何供应商");
                return;
            }
            if (frmFormOtherPlan  == null)
            {
                frmFormOtherPlan = new FrmOrderItemFromOtherPlan();
                frmFormOtherPlan.AffterSave += frmFromPlan_AffterSave;
                new FrmStyle(frmFormOtherPlan).SetPopFrmStyle(this);
            }

            frmFormOtherPlan.BuyOrderFromPlan(this.ctrlCompanyID .CompanyID ,this.GetPrdItems());
            frmFormOtherPlan.ShowDialog();
        } 
        void frmFromPlan_AffterSave(DataRow drowPlan)
        {
           
            int PrdID = (int)drowPlan["PrdID"];
            DataRow[] drows = this.dtblItems.Select("PrdID=" + PrdID.ToString(), "", DataViewRowState.CurrentRows);
            if (drows.Length > 0) return;
            DataRow drowNew = this.dtblItems.NewRow();
            drowNew["PrdID"] = PrdID;
            drowNew["PrdCode"] = drowPlan["PrdCode"];
            drowNew["PrdName"] = drowPlan["PrdName"];
            drowNew["PrdSpec"] = drowPlan["PrdSpec"];
            drowNew["Model"] = drowPlan["Model"];
            drowNew["Manufacturer"] = drowPlan["Manufacturer"];
            drowNew["UnitName"] = drowPlan["UnitName"];
            decimal NonFinishedQty = (decimal)drowPlan["NonFinishedQty"];
            drowNew["PlanQty"] = NonFinishedQty;
            object objMinPackingQty = this.GetMinPackingQty(PrdID);
            drowNew["MinPackingQty"] = objMinPackingQty; 
            drowNew["Quantity"] = this.GetQuantity (objMinPackingQty ,NonFinishedQty ); 
            drowNew["SupplierPrdCode"] = this.GetSupplierPrdCode(PrdID);            
            drowNew["Price"] = this.GetPrice(PrdID);
            drowNew["DateTarget"] = this.GetDateTarget(PrdID);
            this.dtblItems.Rows.Add(drowNew);
        }
        void btnAddSetPrd_Click(object sender, EventArgs e)
        {
            if (frmFromSetPlan == null)
            {
                frmFromSetPlan = new FrmOrderItemFromSetPlan();
                new FrmStyle(frmFromSetPlan).SetPopFrmStyle(this);
                frmFromSetPlan.AffterSave +=frmFromSetPlan_AffterSave;
            }
            frmFromSetPlan.BuyOrderFromSetPlan();
            frmFromSetPlan.ShowDialog();
        }

        void frmFromSetPlan_AffterSave(int PrdID, decimal Quantity)
        {
          
            DataRow[] drows = this.dtblItems.Select("PrdID=" + PrdID.ToString(), "", DataViewRowState.CurrentRows);
            if (drows.Length > 0)
            {
                MessageBox.Show("对不起,此套料已存在");
                return;

            }
            DataRow drowNew = this.dtblItems.NewRow();
            drowNew["PrdID"] = PrdID;
            DataRow drowPrd = this.dtblPrds.Select("PrdID=" + PrdID.ToString())[0];
            drowNew["PrdCode"] = drowPrd["PrdCode"];
            drowNew["PrdName"] = drowPrd["PrdName"];
            drowNew["PrdSpec"] = drowPrd["PrdSpec"];
            drowNew["Model"] = drowPrd["Model"];
            drowNew["Manufacturer"] = drowPrd["Manufacturer"];
            drowNew["UnitName"] = drowPrd["UnitName"];
            decimal NonFinishedQty = Quantity;
            drowNew["PlanQty"] = Quantity;
            object objMinPackingQty = this.GetMinPackingQty(PrdID);
            drowNew["MinPackingQty"] = objMinPackingQty;
            drowNew["Quantity"] = this.GetQuantity(objMinPackingQty, Quantity);
            drowNew["SupplierPrdCode"] = this.GetSupplierPrdCode(PrdID);
            drowNew["Price"] = this.GetPrice(PrdID);
            drowNew["DateTarget"] = this.GetDateTarget(PrdID);
            this.dtblItems.Rows.Add(drowNew);

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
            decimal RequireQty = (decimal)drowStore["RequireQty"];
            DataRow[] drowItems = this.dtblItems.Select("PrdID=" + PrdID.ToString());
            DataRow drowItem;
            if (drowItems.Length > 0)
            {
                drowItem = drowItems[0];
                drowItem["Quantity"] = this.GetQuantity(drowItem["MinPackingQty"], (decimal)drowItem["Quantity"] + RequireQty);

            }
            else
            {
                drowItem = this.dtblItems.NewRow();
                drowItem["PrdID"] = PrdID;
                drowItem["PrdCode"] = drowStore["PrdCode"];
                drowItem["PrdName"] = drowStore["PrdName"];
                drowItem["PrdSpec"] = drowStore["PrdSpec"];
                drowItem["Model"] = drowStore["Model"];
                drowItem["Manufacturer"] = drowStore["Manufacturer"];
                drowItem["UnitName"] = drowStore["UnitName"];
                drowItem["MinPackingQty"] = this.GetMinPackingQty(PrdID);
                drowItem["SupplierPrdCode"] = this.GetSupplierPrdCode (PrdID );
                drowItem["Price"] = this.GetPrice(PrdID);              
                drowItem["Quantity"] = this.GetQuantity(drowItem["MinPackingQty"], RequireQty);
                drowItem["DateTarget"] = this.GetDateTarget (PrdID );
                this.dtblItems.Rows.Add(drowItem);
            }
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
            if ((this.dgrdv.Columns[icol].Name  ==this.ColumnPrdCode.Name )
                ||(this.dgrdv.Columns[icol].Name  ==this.ColumnPrdName.Name )
                ||(this.dgrdv.Columns[icol].Name  ==this.ColumnPrdSpec.Name )
                ||(this.dgrdv.Columns[icol].Name  ==this.ColumnModel.Name )
                || (this.dgrdv.Columns[icol].Name == this.ColumnManufacturer .Name))
            { 
                if (this.dgrdv[this.ColumnPlanQty.Name, irow].Value != DBNull.Value) return;
                this.dgrdv.CurrentCell = this.dgrdv[icol, irow];
                if (frmPrd == null)
                {
                    this.frmPrd = new JERPApp.Define.Material.FrmProduct();
                    new FrmStyle(this.frmPrd).SetPopFrmStyle(this);
                    this.frmPrd.AffterSelected += new JERPApp.Define.Material.FrmProduct.AffterSelectedDelegate(frmPrd_AffterSelected);
                }
                this.frmPrd.ShowDialog();
            }
        }

        void frmPrd_AffterSelected(DataRow drow)
        {
            int PrdID = (int)drow["PrdID"];
            DataGridViewRow grow = this.dgrdv.CurrentRow;
            grow.Cells[this.ColumnPrdID.Name].Value = PrdID;
            grow.Cells[this.ColumnPrdCode.Name].Value = drow["PrdCode"];
            grow.Cells[this.ColumnPrdName.Name].Value = drow["PrdName"]; ;
            grow.Cells[this.ColumnPrdSpec.Name].Value = drow["PrdSpec"];
            grow.Cells[this.ColumnModel.Name].Value = drow["Model"];
            grow.Cells[this.ColumnURL .Name].Value = drow["URL"];
            grow.Cells[this.ColumnManufacturer.Name].Value = drow["Manufacturer"];
            grow.Cells[this.ColumnUnitName.Name].Value = drow["UnitName"];
            grow.Cells[this.ColumnSupplierPrdCode.Name].Value = this.GetSupplierPrdCode(PrdID);
            grow.Cells[this.ColumnMinPackingQty.Name].Value = this.GetMinPackingQty(PrdID);
            grow.Cells[this.ColumnPrice.Name].Value = this.GetPrice(PrdID);
            grow.Cells[this.ColumnDateTarget.Name].Value = this.GetDateTarget(PrdID);
            frmPrd.Close();
        }
        void btnAddPrd_Click(object sender, EventArgs e)
        {
            if (frmAddPrd == null)
            {
                this.frmAddPrd = new JERPApp.Define.Material.FrmProduct();
                new FrmStyle(this.frmAddPrd).SetPopFrmStyle(this);
                this.frmAddPrd.AffterSelected += new JERPApp.Define.Material.FrmProduct.AffterSelectedDelegate(frmAddPrd_AffterSelected);
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
            drowNew["Manufacturer"] = drow["Manufacturer"];
            drowNew["UnitName"] = drow["UnitName"];
            drowNew["URL"] = drow["URL"];
            drowNew["MinPackingQty"] = this.GetMinPackingQty(PrdID);
            drowNew["SupplierPrdCode"] = this.GetSupplierPrdCode(PrdID);
            drowNew["Price"] = this.GetPrice(PrdID);
            drowNew["Quantity"] = drowNew["MinPackingQty"];
            drowNew["DateTarget"] = this.GetDateTarget (PrdID);
            this.dtblItems.Rows.Add(drowNew);
        }

  
    }
}