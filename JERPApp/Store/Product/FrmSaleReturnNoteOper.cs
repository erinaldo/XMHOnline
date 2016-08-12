using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Product
{
    public partial class FrmSaleReturnNoteOper : Form
    {
        public FrmSaleReturnNoteOper()
        {
            InitializeComponent();
            this.accNotes = new JERPData.Product .SaleReturnNotes();
            this.accItems = new JERPData.Product.SaleReturnItems();
            this.accOrderItems = new JERPData.Product.SaleOrderItems();
            this.accStore = new JERPData.Product.Store();
            this.accPrds = new JERPData.Product.Product();
            this.accBranchSotre = new JERPData.Product.BranchStore();
            this.accReplenishPlans = new JERPData.Product.SaleReplenishPlans();
            this.printhelper = new JERPBiz.Product.SaleReturnNotePrintHelper();
            this.SetColumnSrc();
            this.dgrdvItem.AutoGenerateColumns = false;
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnAdd.Click += new EventHandler(btnAdd_Click);
            this.btnAddNon.Click += new EventHandler(btnAddNon_Click);
          
        }

        private JERPData.Product.SaleReturnNotes accNotes;
        private JERPData.Product.SaleReturnItems accItems;
        private JERPData.Product.SaleOrderItems accOrderItems;
        private JERPData.Product.Store accStore;
        private JERPData.Product.Product accPrds;
        private JERPData.Product.BranchStore accBranchSotre;
        private JERPBiz.Product.SaleReturnNotePrintHelper printhelper;
        private JERPApp.Define.Product.FrmSaleDeliverItemForReturn frmDeliverItem;
        private FrmSaleReturnItemAppend frmAppend;
        private JERPData.Product.SaleReplenishPlans accReplenishPlans;
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
        private void SetColumnSrc()
        {
            this.dtblBranchStores = this.accBranchSotre.GetDataBranchStore().Tables[0];
            this.ColumnBranchStoreID.DataSource = this.dtblBranchStores;
            this.ColumnBranchStoreID.ValueMember = "BranchStoreID";
            this.ColumnBranchStoreID.DisplayMember = "BranchStoreName";

        }
      

        void btnAdd_Click(object sender, EventArgs e)
        {
            this.ctrlCompanyID.Enabled = false;
            this.ctrlMoneyTypeID.Enabled = false;
            this.ctrlReturnHandleTypeID.Enabled = false;
            if (this.frmDeliverItem == null)
            {
                this.frmDeliverItem = new JERPApp.Define.Product.FrmSaleDeliverItemForReturn();
                new FrmStyle(this.frmDeliverItem).SetPopFrmStyle(this);
                this.frmDeliverItem.AffterSelect += this.frmOrderItem_AffterSelect;
            }
            this.frmDeliverItem.SaleDeliverForReturn(this.ctrlCompanyID.CompanyID, this.ctrlMoneyTypeID.MoneyTypeID);
            this.frmDeliverItem.ShowDialog();
        }   
        void frmOrderItem_AffterSelect(DataRow drow)
        {
            DataRow[] drowItems = this.dtblItems.Select("SaleDeliverItemID=" + drow["ItemID"].ToString(), "", DataViewRowState.CurrentRows);
            if (drowItems.Length > 0)
            {
                MessageBox.Show("已存在此项");
                return;
            }
            DataRow drowNew = this.dtblItems.NewRow();
            drowNew["PrdID"] = drow["PrdID"];
            drowNew["SaleDeliverItemID"] = drow["ItemID"];
            drowNew["SaleOrderItemID"] = drow["SaleOrderItemID"];
            drowNew["PONo"] = drow["PONo"];
            drowNew["BranchStoreID"] = this.GetDefaultBranchStoreID((int)drow["PrdID"]);
            drowNew["DeliverNoteCode"] = drow["NoteCode"]; 
            drowNew["PrdCode"] = drow["PrdCode"];
            drowNew["PrdName"] = drow["PrdName"];
            drowNew["PrdSpec"] = drow["PrdSpec"];
            drowNew["Model"] = drow["Model"];
            drowNew["Quantity"] = drow["Quantity"];
            if (this.ctrlReturnHandleTypeID.ReturnHandleTypeID > 1)
            {
                drowNew["Price"] = drow["Price"];
            }
            drowNew["UnitName"] = drow["UnitName"];
            this.dtblItems.Rows.Add(drowNew);
        }

        void btnAddNon_Click(object sender, EventArgs e)
        {
            this.ctrlCompanyID.Enabled = false;
            this.ctrlMoneyTypeID.Enabled = false;
            this.ctrlReturnHandleTypeID.Enabled = false;
            if (this.frmAppend == null)
            {
                this.frmAppend = new FrmSaleReturnItemAppend();
                new FrmStyle(this.frmAppend).SetPopFrmStyle(this);
                this.frmAppend.AffterAppend += new FrmSaleReturnItemAppend.AffterAppendDelegate(frmAppend_AffterAppend);
            }
            this.frmAppend.ReturnAppend(this.ctrlReturnHandleTypeID.ReturnHandleTypeID);
            this.frmAppend.ShowDialog();
        }

        void frmAppend_AffterAppend(DataRow drow)
        {
            DataRow[] drowItems = this.dtblItems.Select("SaleDeliverItemID is null and PrdID=" + drow["PrdID"].ToString(), "", DataViewRowState.CurrentRows);
            if (drowItems.Length > 0)
            {
                MessageBox.Show("已存在此项");
                return;
            }
            DataRow drowNew = this.dtblItems.NewRow();
            drowNew["PrdID"] = drow["PrdID"];       
            drowNew["BranchStoreID"] = this.GetDefaultBranchStoreID((int)drow["PrdID"]);     
            drowNew["PrdCode"] = drow["PrdCode"];
            drowNew["PrdName"] = drow["PrdName"];
            drowNew["PrdSpec"] = drow["PrdSpec"];
            drowNew["Quantity"] = drow["Quantity"];
            drowNew["Price"] = drow["Price"];
            drowNew["UnitName"] = drow["UnitName"];
            this.dtblItems.Rows.Add(drowNew);
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
            this.dtblItems = this.accItems.GetDataSaleReturnItemsByNoteID(-1).Tables[0];         
            this.dtblItems.Columns["Quantity"].AllowDBNull = false;
            this.dtblItems.Columns.Add ("SaleOrderItemID",typeof (long));
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

        private decimal GetCostPrice(int PrdID)
        {
            decimal rut = 0;
            this.accPrds.GetParmProductCostPrice(PrdID, ref rut);
            return rut;
        }
     
     
        private bool ValidateData()
        {
            bool flag = true;
            DataRow[] drows = this.dtblItems.Select("", "", DataViewRowState.CurrentRows);
            if (drows.Length == 0)
            {
                MessageBox.Show("没有任何记录,不能保存");
                return false;
            }
            return flag;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateData() == false) return;
            DialogResult rul = MessageBox.Show("将进行保存入账, 一经确认不能变更！", "保存确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {
                bool flag = false;
                string errormsg = string.Empty;
                object objNoteID = DBNull.Value;
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
                flag = this.accNotes.InsertSaleReturnNotes(ref errormsg, ref objNoteID,
                    this.txtNoteCode .Text ,
                    this.tpkDateNote.Value.Date,
                    this.ctrlCompanyID.CompanyID,
                    this.ctrlMoneyTypeID .MoneyTypeID ,
                    this.ctrlReturnHandleTypeID .ReturnHandleTypeID ,
                    objTotalAMT ,
                    this.ctrlQCPsnID .PsnID ,
                    JERPBiz.Frame.UserBiz.PsnID,
                    this.rchMemo.Text);
                if (!flag)
                {
                    MessageBox.Show(errormsg);
                    return;
                }
                long NoteID = (long)objNoteID;
                foreach (DataRow drow in this.dtblItems.Rows)
                {
                    if (drow.RowState == DataRowState.Deleted) continue;
                    object objItemID = DBNull.Value;
                    int PrdID = (int)drow["PrdID"];
                    int BranchStoreID = (int)drow["BranchStoreID"];
                    decimal Quantity = (decimal)drow["Quantity"];
                    decimal CostPrice = this.GetCostPrice(PrdID);
                    flag = this.accItems.InsertSaleReturnItems(ref errormsg, ref objItemID,
                        NoteID,
                        drow["SaleDeliverItemID"],
                        drow["PrdID"],        
                        Quantity,
                        BranchStoreID,
                        drow["Price"],
                        CostPrice);
                    if (flag)
                    {

                        this.accStore.InsertStoreForIntoStore (ref errormsg,
                           JERPBiz .Finance .NoteNameParm .PrdSaleReturnNoteNameID ,
                           NoteID ,
                           this.txtNoteCode .Text ,
                           PrdID,
                           BranchStoreID ,
                           Quantity,
                           CostPrice);
                        if (this.ctrlReturnHandleTypeID.ReturnHandleTypeID == 1)
                        {
                            //补货计划
                            this.accReplenishPlans.SaveSaleReplenishPlans(ref errormsg,
                                this.ctrlCompanyID.CompanyID,
                                PrdID,
                                Quantity);

                        }
                        if (this.ctrlReturnHandleTypeID.ReturnHandleTypeID == 3)
                        {
                            if (drow["SaleOrderItemID"] != DBNull.Value)
                            {
                                //重新送货
                                this.accOrderItems.UpdateSaleOrderItemsForSubFinishedQty  (ref errormsg,
                                    drow["SaleOrderItemID"],
                                    drow["Quantity"]);
                            }
                        }
                    }
                }
                rul = MessageBox.Show("成功进行销售退货,需要输出打印吗?", "打印确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rul == DialogResult.Yes)
                {
                    this.printhelper.ExportToExcel(NoteID);
                    this.accNotes.UpdateSaleReturnNotesForPrint  (ref errormsg, NoteID, JERPBiz.Frame.UserBiz.PsnID);
                }
                if (this.affterSave != null) this.affterSave();
                this.NewNote();
            }

        }       
  
   
    
    }
}