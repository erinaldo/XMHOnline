using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Material
{
    public partial class FrmReportLossNoteOper : Form
    {
        public FrmReportLossNoteOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accItems = new JERPData.Material.ReportLossItems();
            this.accNotes = new JERPData.Material.ReportLossNotes();
            this.accPrds = new JERPData.Product.Product();
            this.accBranchStore = new JERPData.Material.BranchStore();
            this.accStore = new JERPData.Material.Store();
            this.accStoreReserve = new JERPData.Material.StoreReserve();
            this.accWorkingSheetReserve = new JERPData.Material.StoreWorkingSheetReserve();
            this.accBadType = new JERPData.Material.BadType();
            this.accExpenseAccount = new JERPData.Finance.ExpenseAccount();
            this.SetColumnSrc(); 
            this.btnAddPrd.Click += new EventHandler(btnAddPrd_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.dgrdv.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdv_DataBindingComplete);
            this.dgrdv.CellValueChanged += new DataGridViewCellEventHandler(dgrdv_CellValueChanged);
            this.dgrdv.CellContextMenuStripNeeded += new DataGridViewCellContextMenuStripNeededEventHandler(dgrdv_CellContextMenuStripNeeded);
            this.dgrdv.CellQuery += new JCommon.MyDataGridView.CellQueryDelegate(dgrdv_CellQuery);
        }

     
        private JERPData.Material.ReportLossNotes accNotes;
        private JERPData.Material.ReportLossItems accItems;
        private JERPData.Product.Product accPrds;
        private JERPData.Material.BadType accBadType;
        private JERPData.Material.Store accStore;
        private JERPData.Material.StoreReserve accStoreReserve;
        private JERPData.Material.StoreWorkingSheetReserve accWorkingSheetReserve;

        private JERPData.Material.BranchStore accBranchStore;
        private JERPApp.Define.Material.FrmBadType frmBadType;
        private JERPApp.Define.Material.FrmProduct frmPrd;
        private JERPApp.Define.Material.FrmProduct frmAddPrd;
        private JCommon.FrmGridFind frmGridPrd;
        private JERPData.Finance.ExpenseAccount accExpenseAccount;
        private DataTable dtblItems,dtblPrds,dtblBadTypes,dtblBranchStore;
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
        private object GetDefaultBranchStoreID(int PrdID)
        {
            int BranchStoreID = -1;
            this.accStore.GetParmStoreDefaultBranchStoreID(PrdID, ref BranchStoreID);
            if (BranchStoreID == -1) return DBNull.Value;
            return BranchStoreID;
        }
        private void SetBadTypeSrc()
        {
            this.dtblBadTypes = this.accBadType.GetDataBadType().Tables[0];
            this.dtblBadTypes.Columns.Add("Exp", typeof(string), "ISNULL(BadTypeCode,'')+ISNULL(BadTypeName,'')");
            this.ColumnBadTypeID.DataSource = this.dtblBadTypes;
            this.ColumnBadTypeID.ValueMember = "BadTypeID";
            this.ColumnBadTypeID.DisplayMember = "Exp";
        }
        private void SetColumnSrc()
        {
            this.SetBadTypeSrc();

            this.dtblPrds = this.accPrds.GetDataProductForMaterial().Tables[0];


            this.dtblBranchStore = this.accBranchStore.GetDataBranchStore().Tables[0];
            this.ColumnBranchStoreID.DataSource = this.dtblBranchStore;
            this.ColumnBranchStoreID.ValueMember = "BranchStoreID";
            this.ColumnBranchStoreID.DisplayMember = "BranchStoreName";

        }
      
        public void NewNote()
        {
          
            this.dtpDateNote.Value = DateTime.Now.Date;            
            this.txtNoteCode.Text = string.Empty;
            this.rchMemo.Text = string.Empty;
            this.dtblItems = this.accItems.GetDataReportLossItemsByNoteID(-1).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
            this.dtblItems.Columns["PrdID"].AllowDBNull = false;
            this.dtblItems.Columns["BranchStoreID"].AllowDBNull = false;
            this.dtblItems.Columns["Quantity"].AllowDBNull = false;
            this.dtblItems.Columns.Add("InventoryQty", typeof(decimal));
        }
        
        void dgrdv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].DataPropertyName == "PrdID")
            {
                object objPrdID = this.dgrdv[icol, irow].Value;
                if ((objPrdID != null) && (objPrdID != DBNull.Value))
                {
                    if (this.dgrdv[this.ColumnBranchStoreID.Name, irow].Value == DBNull.Value)
                    {
                        this.dgrdv[this.ColumnBranchStoreID.Name, irow].Value = this.GetDefaultBranchStoreID((int)objPrdID);
                    }
                }
            }
            if ((this.dgrdv.Columns[icol].DataPropertyName == "PrdID")
               || (this.dgrdv.Columns[icol].Name == this.ColumnBranchStoreID.Name))
            {
                object objPrdID = this.dgrdv[this.ColumnPrdID.Name, irow].Value;
                object objBranchStoreID = this.dgrdv[this.ColumnBranchStoreID.Name, irow].Value;
                if ((objPrdID != DBNull.Value)
                    && (objPrdID != null)
                    && (objBranchStoreID != DBNull.Value)
                    && (objBranchStoreID != null))
                {
                    this.dgrdv[this.ColumnInventoryQty.Name, irow].Value = this.GetStoreQty((int)objPrdID, (int)objBranchStoreID);
                }
            }
        }
        void dgrdv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow grow in this.dgrdv.Rows)
            {
                if (grow.IsNewRow) continue;
                grow.ErrorText = string.Empty;
                object objBadTypeID = grow.Cells[this.ColumnBadTypeID.Name].Value;
                if (objBadTypeID == DBNull.Value)
                {
                    grow.ErrorText = "不良原因不能为空";
                    continue;
                }
                object objQuantity = grow.Cells[this.ColumnQuantity.Name].Value;
                object objInventory = grow.Cells[this.ColumnInventoryQty.Name].Value;
                if ((objQuantity != DBNull.Value) && (objInventory != DBNull.Value))
                {

                    if ((decimal)objQuantity > (decimal)objInventory)
                    {
                        grow.ErrorText = "库存不足";
                        continue;
                    }
                    
                }
            }
        }
        void btnAddPrd_Click(object sender, EventArgs e)
        {
            if (frmAddPrd == null)
            {
                this.frmAddPrd = new JERPApp.Define.Material.FrmProduct();
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
            drowNew["Manufacturer"] = drow["Manufacturer"];
            drowNew["UnitName"] = drow["UnitName"]; 
            drowNew["BranchStoreID"] = this.GetDefaultBranchStoreID(PrdID);
            if (drowNew["BranchStoreID"] != DBNull.Value)
            {
                drowNew["InventoryQty"] = this.GetStoreQty(PrdID, (int)drowNew["BranchStoreID"]);
            }
            drowNew["Quantity"] = 0;
            this.dtblItems.Rows.Add(drowNew);

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
                    this.frmGridPrd.AddGridColumn("PrdCode", "物料编号", 100);
                    this.frmGridPrd.AddGridColumn("PrdName", "物料名称", 100);
                    this.frmGridPrd.AddGridColumn("PrdSpec", "物料规格", 100);
                    this.frmGridPrd.AddGridColumn("Model", "型号", 66);
                    this.frmGridPrd.AddGridColumn("Manufacturer", "品牌", 66);
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
            grow.Cells[this.ColumnManufacturer.Name].Value = drow["Manufacturer"];
            grow.Cells[this.ColumnUnitName.Name].Value = drow["UnitName"];

        }
        void dgrdv_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnBadTypeID.Name)
            {
                if (frmBadType == null)
                {
                    frmBadType = new JERPApp.Define.Material.FrmBadType();
                    new FrmStyle(frmBadType).SetPopFrmStyle(this);
                    frmBadType.AffterSave += this.SetBadTypeSrc;
                }
                frmBadType.ShowDialog();
            }
            if ((this.dgrdv.Columns[icol].DataPropertyName == "PrdCode")
               || (this.dgrdv.Columns[icol].DataPropertyName == "PrdName")
               || (this.dgrdv.Columns[icol].DataPropertyName == "PrdSpec")
               || (this.dgrdv.Columns[icol].DataPropertyName == "Model")
               || (this.dgrdv.Columns[icol].DataPropertyName == "Manufacturer"))
            {

                this.dgrdv.CurrentCell = this.dgrdv[icol, irow];
                if (frmPrd == null)
                {
                    this.frmPrd = new JERPApp.Define.Material.FrmProduct();
                    new FrmStyle(this.frmPrd).SetPopFrmStyle(this);
                    this.frmPrd.AffterSelected += frmPrd_AffterSelected;
                }
                this.frmPrd.ShowDialog();
            }

        }
      
        void frmPrd_AffterSelected(DataRow drow)
        {
            DataGridViewRow grow = this.dgrdv.CurrentRow;
            int PrdID = (int)drow["PrdID"];
            grow.Cells[this.ColumnPrdID.Name].Value = PrdID;
            grow.Cells[this.ColumnPrdCode.Name].Value = drow["PrdCode"];
            grow.Cells[this.ColumnPrdName.Name].Value = drow["PrdName"];
            grow.Cells[this.ColumnPrdSpec.Name].Value = drow["PrdSpec"];
            grow.Cells[this.ColumnModel.Name].Value = drow["Model"];
            grow.Cells[this.ColumnManufacturer.Name].Value = drow["Manufacturer"];
            grow.Cells[this.ColumnUnitName.Name].Value = drow["UnitName"];

            object objBranchStoreID = this.GetDefaultBranchStoreID(PrdID);
            grow.Cells[this.ColumnBranchStoreID.Name].Value = objBranchStoreID;
            if (objBranchStoreID != DBNull.Value)
            {
                grow.Cells[this.ColumnInventoryQty.Name].Value = this.GetStoreQty(PrdID, (int)objBranchStoreID);
            }
            frmPrd.Close();

        }
        private decimal GetStoreQty(int PrdID, int BranchStoreID)
        {
            decimal rut = 0;
            this.accStore.GetParmStoreInventoryQty (PrdID, BranchStoreID, ref rut);
            return rut;
        }
        private decimal GetCostPrice(int PrdID, int BranchStoreID)
        {
            decimal rut = 0;
            this.accStore.GetParmStoreInventoryPrice(PrdID, BranchStoreID, ref rut);
            return rut;
        }
        bool ValidateData()
        {

            DataRow[] drows = this.dtblItems.Select("Quantity is not null", "", DataViewRowState.CurrentRows);
            if (drows.Length == 0)
            {
                MessageBox.Show("未存在任何明细项");
                return false;
            }
            drows = this.dtblItems.Select("Quantity>InventoryQty", "", DataViewRowState.CurrentRows);
            if (drows.Length > 0)
            {
                MessageBox.Show("对不起，存在库存不足项");
                return false;
            } 
            drows = this.dtblItems.Select("BadTypeID is null", "", DataViewRowState.CurrentRows);
            if (drows.Length > 0)
            {
                MessageBox.Show("对不起,不良原因不能为空");
                return false;
            }
            return true;
        }
        void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateData() == false) return;
             DialogResult rul = MessageBox.Show("将进行保存入账一经入账不能变更！", "审核确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return;
            string errormsg = string.Empty;
            bool flag = false;
            long NoteID = -1;
            string NoteCode = string.Empty;
            object objNoteID = DBNull.Value;
            object objNoteCode = DBNull.Value;
            flag = this.accNotes.InsertReportLossNotes(ref errormsg, ref objNoteID, ref objNoteCode,
                this.dtpDateNote.Value.Date,
                JERPBiz.Frame.UserBiz.PsnID,
                this.rchMemo.Text);
            if (flag == false)
            {
                MessageBox.Show(errormsg);
                return;
            }
           
            NoteID = (long)objNoteID;
            NoteCode = objNoteCode.ToString();
            this.txtNoteCode.Text = NoteCode;
            object objItemID = DBNull.Value; 
            decimal TotalAMT = 0;
            foreach (DataRow drow in this.dtblItems.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                decimal CostPrice = this.GetCostPrice((int)drow["PrdID"], (int)drow["BranchStoreID"]);
                decimal Quantity = (decimal)drow["Quantity"];
                TotalAMT += CostPrice * Quantity; 
                flag = this.accItems.InsertReportLossItems(ref errormsg,
                   ref objItemID,
                   NoteID ,
                   drow["PrdID"],
                   drow["BadTypeID"],
                   drow["Quantity"],
                   drow["BranchStoreID"],
                   CostPrice );
              
                //报损出库
                this.accStore.InsertStoreForOutStore(ref errormsg,
                          JERPBiz.Finance.NoteNameParm.MtrReportLossNoteNameID,
                          NoteID,
                          NoteCode,                                  
                          drow["PrdID"],
                          drow["BranchStoreID"],
                          drow["Quantity"],
                          CostPrice );
                //预留出
                this.accStoreReserve.SaveStoreReserveForSubReserve(ref errormsg,
                     drow["PrdID"],
                     drow["Quantity"]);
                this.accWorkingSheetReserve.SaveStoreWorkingSheetReserveForSubReserve(ref errormsg,
                    drow["PrdID"],
                    drow["Quantity"]);
            }
            if (TotalAMT > 0)
            {
                //原料费用
                this.accExpenseAccount.InsertExpenseAccountForDebit(
                    ref errormsg,
                    "原料报损单[" + NoteCode + "]",
                    JERPBiz.Finance.ExpenseTypeParm.MtrExpense,
                    TotalAMT,
                    JERPBiz.Frame.UserBiz.PsnID);
            }
       
            MessageBox.Show("成功保存并入账当前单据");
            if (this.affterSave != null) this.affterSave();
            this.NewNote();
               
            
        }

 

    }
}