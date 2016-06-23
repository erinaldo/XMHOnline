using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Material
{
    public partial class FrmBuyReturnNoteOper : Form
    {
        public FrmBuyReturnNoteOper()
        {
            InitializeComponent();
            this.accNotes = new JERPData.Material .BuyReturnNotes();
            this.accItems = new JERPData.Material.BuyReturnItems();
            this.accReceiveItems = new JERPData.Material.BuyReceiveItems();
            this.accOrderItems = new JERPData.Material.BuyOrderItems();
            this.accStore = new JERPData.Material.Store();
            this.accPrds = new JERPData.Product.Product();
            this.accStoreReserve = new JERPData.Material.StoreReserve();
            this.accWorkingSheetReserve = new JERPData.Material.StoreWorkingSheetReserve();
            this.accBranchSotre = new JERPData.Material.BranchStore();
            this.accReplenishPlans = new JERPData.Material.BuyReplenishPlans();
            this.PrintHelper = new JERPBiz.Material.BuyReturnNotePrintHelper();
            this.SetColumnSrc();
            this.dgrdvItem.AutoGenerateColumns = false;
            this.ctrlReturnHandleTypeID.AffterSelected += ctrlReturnHandleTypeID_AffterSelected;
            this.dgrdvItem.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdvItem_DataBindingComplete);
            this.dgrdvItem.CellValueChanged += new DataGridViewCellEventHandler(dgrdvItem_CellValueChanged);
            this.btnAdd.Click += new EventHandler(btnAdd_Click);
            this.btnNonAdd.Click += new EventHandler(btnNonAdd_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
        
          
        }

        private JERPData.Material.BuyReturnNotes accNotes;
        private JERPData.Material.BuyReturnItems accItems;
        private JERPData.Material.BuyReceiveItems accReceiveItems;
        private JERPData.Material.BuyOrderItems accOrderItems;
        private JERPData.Material.Store accStore;
        private JERPData.Product.Product accPrds;
        private JERPData.Material.StoreReserve accStoreReserve;
        private JERPData.Material.StoreWorkingSheetReserve accWorkingSheetReserve;
        private JERPData.Material.BranchStore accBranchSotre;
        private JERPData.Material.BuyReplenishPlans accReplenishPlans;
        private JERPBiz.Material.BuyReturnNotePrintHelper PrintHelper;
        private JERPApp.Define.Material.FrmBuyReceiveItemForReturn frmReceiveItem;
        private FrmBuyReturnItemAppend frmAppend;
        private DataTable dtblItems, dtblBranchStores;
        private long noteID;
        private long NoteID
        {
            get
            {
                 return this.noteID;
            } 
            set
            {
                this.noteID = value;               
                this.btnSave.Enabled = (value > -1);
                
            }
        }
        private void SetColumnSrc()
        {
            this.dtblBranchStores = this.accBranchSotre.GetDataBranchStore().Tables[0];
            this.ColumnBranchStoreID.DataSource = this.dtblBranchStores;
            this.ColumnBranchStoreID.ValueMember = "BranchStoreID";
            this.ColumnBranchStoreID.DisplayMember = "BranchStoreName";
        }
        private object GetDefaultBranchStoreID(int PrdID)
        {
            int rut = 1;
            this.accStore.GetParmStoreDefaultBranchStoreID(PrdID, ref rut);
            if (rut > -1)
            {
                return rut;
            }
            return DBNull.Value;
        }
  
   
        public void NewNote()
        {
            this.ctrlCompanyID.CompanyID = -1; 
            this.ctrlCompanyID.Enabled = true;
            this.ctrlMoneyTypeID.Enabled = true;
            this.ctrlReturnHandleTypeID.Enabled = true;
            this.tpkDateNote.Value = DateTime.Now.Date;
            this.txtNoteCode.Text = string.Empty;
            this.rchMemo.Text = string.Empty;
            this.dtblItems = this.accItems.GetDataBuyReturnItemsByNoteID(-1).Tables[0];
            this.dtblItems.Columns["Quantity"].AllowDBNull = false;
            this.dtblItems.Columns.Add("BuyOrderItemID", typeof(long));
            this.dtblItems.Columns["BranchStoreID"].AllowDBNull = false;
            this.dtblItems.Columns.Add("InventoryQty", typeof(decimal));
            this.dgrdvItem.DataSource = this.dtblItems;
        }
        //单据保存
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
      
        private decimal GetStoreQty(int PrdID,int BranchStoreID)
        {
            decimal rut = 0;
            this.accStore.GetParmStoreInventoryQty (PrdID,BranchStoreID , ref rut);
            return rut;
        }
        private decimal GetCostPrice(int PrdID,int BranchStoreID)
        {
            decimal rut = 0;
            this.accStore.GetParmStoreInventoryPrice(PrdID, BranchStoreID, ref rut);           
            return rut;
        }
        void ctrlReturnHandleTypeID_AffterSelected(int ReturnHandleTypeID)
        {
            this.ColumnPrice.Visible = (this.ctrlReturnHandleTypeID.ReturnHandleTypeID > 1);
         
        }
        private bool GetPrdSetFlag(int PrdID)
        {
            bool flag = false;
            this.accPrds.GetParmProductPrdSetFlag(PrdID, ref flag);
            return flag;
        }
        void btnAdd_Click(object sender, EventArgs e)
        {

            this.ctrlReturnHandleTypeID.Enabled = false;
            this.ctrlCompanyID.Enabled = false;
            this.ctrlMoneyTypeID.Enabled = false;

            if (this.frmReceiveItem == null)
            {
                this.frmReceiveItem = new JERPApp.Define.Material.FrmBuyReceiveItemForReturn();
                new FrmStyle(this.frmReceiveItem).SetPopFrmStyle(this);
                this.frmReceiveItem.AffterSelect += this.frmReceiveItem_AffterSelect;
            }
            this.frmReceiveItem.BuyReceiveForReturn(this.ctrlCompanyID.CompanyID, this.ctrlMoneyTypeID.MoneyTypeID);
            this.frmReceiveItem.ShowDialog();

        }


        void frmReceiveItem_AffterSelect(DataRow drow)
        {
            DataRow[] drowItems = this.dtblItems.Select("BuyReceiveItemID=" + drow["ItemID"].ToString(), "", DataViewRowState.CurrentRows);
            if (drowItems.Length > 0)
            {
                MessageBox.Show("已存在此项");
                return;
            }
            int PrdID = (int)drow["PrdID"];
            if (this.GetPrdSetFlag(PrdID))
            {
                MessageBox.Show("不做套料退货");
                return;
            }
            DataRow drowNew = this.dtblItems.NewRow();
            drowNew["PrdID"] =PrdID ;
            drowNew["BuyReceiveItemID"] = drow["ItemID"];
            drowNew["BuyOrderItemID"] = drow["BuyOrderItemID"];
            object objBranchStoreID = this.GetDefaultBranchStoreID(PrdID);
            drowNew["BranchStoreID"] = objBranchStoreID;
            if (objBranchStoreID != DBNull.Value)
            {
                drowNew["InventoryQty"] = this.GetStoreQty(PrdID, (int)objBranchStoreID);
            }
            drowNew["ReceiveNoteCode"] = drow["NoteCode"];
            drowNew["PONo"] = drow["PONo"];
            drowNew["PrdCode"] = drow["PrdCode"];
            drowNew["PrdName"] = drow["PrdName"];
            drowNew["PrdSpec"] = drow["PrdSpec"];
            drowNew["Model"] = drow["Model"];
            drowNew["Manufacturer"] = drow["Manufacturer"];
            drowNew["SupplierPrdCode"] = drow["SupplierPrdCode"];
            drowNew["Quantity"] = drow["Quantity"];
            if (this.ctrlReturnHandleTypeID.ReturnHandleTypeID > 1)
            {              
                drowNew["Price"] = drow["Price"];
            }
            drowNew["UnitName"] = drow["UnitName"];
           
            this.dtblItems.Rows.Add(drowNew);
        }

        void btnNonAdd_Click(object sender, EventArgs e)
        {

            this.ctrlReturnHandleTypeID.Enabled = false;
            this.ctrlCompanyID.Enabled = false;
            this.ctrlMoneyTypeID.Enabled = false;
            if (this.frmAppend == null)
            {
                this.frmAppend = new FrmBuyReturnItemAppend();
                new FrmStyle(frmAppend).SetPopFrmStyle(this);
                this.frmAppend.AffterAppend += new FrmBuyReturnItemAppend.AffterAppendDelegate(frmAppend_AffterAppend);
            }
            this.frmAppend.ReturnAppend(this.ctrlReturnHandleTypeID.ReturnHandleTypeID);
            this.frmAppend.ShowDialog();
        }

        void frmAppend_AffterAppend(DataRow drow)
        {
            DataRow[] drowItems = this.dtblItems.Select("BuyReceiveItemID is null and PrdID=" + drow["PrdID"].ToString(), "", DataViewRowState.CurrentRows);
            if (drowItems.Length > 0)
            {
                MessageBox.Show("已存在此项");
                return;
            }
            int PrdID = (int)drow["PrdID"];
            if (this.GetPrdSetFlag(PrdID))
            {
                MessageBox.Show("不做套料退货");
                return;
            }
            DataRow drowNew = this.dtblItems.NewRow();
            drowNew["PrdID"] = PrdID;
            object objBranchStoreID = this.GetDefaultBranchStoreID(PrdID);
            drowNew["BranchStoreID"] = objBranchStoreID;
            if (objBranchStoreID != DBNull.Value)
            {
                drowNew["InventoryQty"] = this.GetStoreQty(PrdID, (int)objBranchStoreID);
            }         
            drowNew["PrdCode"] = drow["PrdCode"];
            drowNew["PrdName"] = drow["PrdName"];
            drowNew["PrdSpec"] = drow["PrdSpec"];
            drowNew["Model"] = drow["Model"];
            drowNew["Manufacturer"] = drow["Manufacturer"];
            drowNew["SupplierPrdCode"] = drow["SupplierPrdCode"];
            drowNew["Quantity"] = drow["Quantity"];
            if (this.ctrlReturnHandleTypeID.ReturnHandleTypeID > 1)
            {
                drowNew["Price"] = drow["Price"];
            }
            drowNew["UnitName"] = drow["UnitName"];
            this.dtblItems.Rows.Add(drowNew);
        }

        private void dgrdvItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvItem.Columns[icol].DataPropertyName == "PrdID")
            {
                object objPrdID = this.dtblItems.DefaultView[irow]["PrdID"];
                if ((objPrdID != DBNull.Value)
                   && (objPrdID != null))
                {
                    this.dgrdvItem[this.ColumnBranchStoreID.Name, irow].Value =
                        this.GetDefaultBranchStoreID((int)objPrdID);
                }
            }
            if ((this.dgrdvItem.Columns[icol].DataPropertyName == "PrdID")
               || (this.dgrdvItem.Columns[icol].Name == this.ColumnBranchStoreID.Name))
            {
                object objPrdID = this.dtblItems.DefaultView[irow]["PrdID"];
                object objBranchStoreID = this.dgrdvItem[this.ColumnBranchStoreID.Name, irow].Value;
                if ((objPrdID != DBNull.Value)
                    && (objPrdID != null)
                    && (objBranchStoreID != DBNull.Value)
                    && (objBranchStoreID != null))
                {
                    this.dgrdvItem[this.ColumnInventoryQty.Name, irow].Value = this.GetStoreQty((int)objPrdID, (int)objBranchStoreID);
                }
            }
         
        }
        void dgrdvItem_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow grow in this.dgrdvItem.Rows)
            {
                object objQuantity = grow.Cells[this.ColumnQuantity.Name].Value;
                object objInventory = grow.Cells[this.ColumnInventoryQty.Name].Value;
                if ((objQuantity != DBNull.Value) && (objInventory != DBNull.Value))
                {
                    grow.ErrorText = ((decimal)objQuantity > (decimal)objInventory) ? "库存不足" : string.Empty;
                }

            }
        }
        private bool ValidateData()
        {

            DataRow[] drows = this.dtblItems.Select("", "", DataViewRowState.CurrentRows);
            if (drows.Length == 0)
            {
                MessageBox.Show("没有任何记录,不能保存");
                return false;
            }
           
            drows = this.dtblItems.Select("Quantity>InventoryQty", "", DataViewRowState.CurrentRows);
            if (drows.Length > 0)
            {
                MessageBox.Show("对不起,存在库存不足记录,不能出货");
                return false;
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateData() == false) return;
            DialogResult rul = MessageBox.Show("即将进行退货出库, 一经确认不能变更！", "保存确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {
                bool flag = false;
                string errormsg = string.Empty;
                object objNoteID = DBNull.Value;
                object objNoteCode = DBNull.Value;
                object objTotalAMT = DBNull.Value;
                if (this.ctrlReturnHandleTypeID.ReturnHandleTypeID > 1)
                {
                    decimal TotalAMT = 0;
                    foreach (DataRow drow in this.dtblItems.Rows)
                    {
                        if (drow.RowState == DataRowState.Deleted) continue;
                        TotalAMT += (decimal)drow["Price"] * (decimal)drow["Quantity"];
                    }
                    objTotalAMT = TotalAMT;
                }
                flag = this.accNotes.InsertBuyReturnNotes(ref errormsg, ref objNoteID,
                    ref objNoteCode,
                    this.tpkDateNote.Value.Date,
                    this.ctrlCompanyID.CompanyID,
                    this.ctrlMoneyTypeID.MoneyTypeID ,
                    this.ctrlReturnHandleTypeID .ReturnHandleTypeID ,
                    this.ctrlDeliverPsnID .PsnID ,
                    objTotalAMT ,
                    JERPBiz.Frame.UserBiz.PsnID,
                    this.rchMemo.Text);
                if (!flag)
                {
                    MessageBox.Show(errormsg);
                    return;
                }
                long NoteID = (long)objNoteID;
                string NoteCode = objNoteCode.ToString();
                this.txtNoteCode.Text = NoteCode;
                foreach (DataRow drow in this.dtblItems.Rows)
                {
                    if (drow.RowState == DataRowState.Deleted) continue;
                    object objItemID = DBNull.Value;
                    int PrdID = (int)drow["PrdID"];
                    int BranchStoreID = (int)drow["BranchStoreID"];
                    decimal Quantity = (decimal)drow["Quantity"];
                    decimal CostPrice = this.GetCostPrice(PrdID,BranchStoreID );
                    flag = this.accItems.InsertBuyReturnItems(ref errormsg, ref objItemID,
                        NoteID,
                        drow["BuyReceiveItemID"],
                        PrdID ,
                        drow["SupplierPrdCode"],
                        BranchStoreID ,
                        Quantity,
                        drow["Price"],
                        CostPrice);
                    if (flag)
                    {

                        this.accStore.InsertStoreForOutStore(ref errormsg,
                            JERPBiz.Finance.NoteNameParm.MtrBuyReturnNoteNameID,
                           NoteID,
                           NoteCode,
                           PrdID,
                           BranchStoreID ,
                           Quantity,
                           CostPrice);
                        //两个预留都要出的啦
                        this.accStoreReserve.SaveStoreReserveForSubReserve(ref errormsg,
                            PrdID,
                            Quantity);
                        this.accWorkingSheetReserve.SaveStoreWorkingSheetReserveForSubReserve(ref errormsg,
                            PrdID,
                            Quantity);
                        if (this.ctrlReturnHandleTypeID.ReturnHandleTypeID == 1)
                        {
                            //补货计划
                            this.accReplenishPlans.SaveBuyReplenishPlans (ref errormsg,
                                this.ctrlCompanyID.CompanyID,
                                PrdID,
                                Quantity);
                        }
                        if (this.ctrlReturnHandleTypeID.ReturnHandleTypeID == 3)
                        {
                            if (drow["BuyOrderItemID"] != DBNull.Value)
                            {
                                //重新送货
                                this.accOrderItems.UpdateBuyOrderItemsForSubFinishedQty (ref errormsg,
                                    drow["BuyOrderItemID"],
                                    Quantity);
                            }
                        }
                    }
                }
                rul = MessageBox.Show("成功生成退货单, 需要立即将打印吗?", "打印确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rul == DialogResult.Yes)
                {
                    this.PrintHelper.ExportToExcel(NoteID);
                    this.accNotes.UpdateBuyReturnNotesForPrint(ref errormsg, NoteID, JERPBiz.Frame.UserBiz.PsnID);
                } 
                if (this.affterSave != null) this.affterSave();
                this.NewNote();
            }

        }       
  
   
    
    }
}