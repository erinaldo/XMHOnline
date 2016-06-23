using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Material
{
    public partial class FrmOutSrcRecycleNoteOper : Form
    {
        public FrmOutSrcRecycleNoteOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accItems = new JERPData.Material.OutSrcRecycleItems();
            this.accNotes = new JERPData.Material.OutSrcRecycleNotes();
            this.accStore = new JERPData.Material.Store();
            this.accOutSrcStore = new JERPData.Material.OutSrcStore();
            this.accOutSrcStoreReserve = new JERPData.Material.OutSrcStoreReserve();
            this.accWorkingSheetReserve = new JERPData.Material.OutSrcStoreWorkingSheetReserve(); 
            this.accBranchSotre = new JERPData.Material.BranchStore();
            this.accExpenseAccount = new JERPData.Finance.ExpenseAccount();
            this.accPrds = new JERPData.Product.Product();
            this.dgrdv.CellContextMenuStripNeeded += new DataGridViewCellContextMenuStripNeededEventHandler(dgrdv_CellContextMenuStripNeeded);
            this.SetColumnSrc();
            this.dgrdv.CellValueChanged += new DataGridViewCellEventHandler(dgrdv_CellValueChanged); 
            this.dgrdv.CellQuery += new JCommon.MyDataGridView.CellQueryDelegate(dgrdv_CellQuery);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnAddPrd.Click += new EventHandler(btnAddPrd_Click);
        }

        private JERPData.Material.OutSrcRecycleNotes accNotes;
        private JERPData.Material.OutSrcRecycleItems accItems;
        private JERPData.Material.Store accStore;
        private JERPData.Material.OutSrcStore accOutSrcStore;
        private JERPData.Material.OutSrcStoreReserve accOutSrcStoreReserve;
        private JERPData.Material.OutSrcStoreWorkingSheetReserve accWorkingSheetReserve; 
        private JERPData.Product.Product accPrds;
        private JERPData.Material.BranchStore accBranchSotre;
        private JERPApp.Define.Material.FrmProduct frmPrd;
        private JERPApp.Define.Material.FrmProduct frmAddPrd;
        private JCommon.FrmGridFind frmGridPrd;
        private JERPData.Finance.ExpenseAccount accExpenseAccount;
        private DataTable dtblItems, dtblPrds, dtblBranchStores;
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

        private void SetColumnSrc()
        {

            this.dtblPrds = this.accPrds.GetDataProductForMaterial().Tables[0];
            


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
        private decimal GetInventoryPrice(int PrdID)
        {
            decimal rut = 0;
            this.accOutSrcStore .GetParmOutSrcStoreInventoryPrice (this.ctrlCompanyID .CompanyID ,
                PrdID, ref rut);
            return rut;
        }
        private decimal GetOutStoreQty(int PrdID,decimal Quantity)
        {
            decimal rut = 0;
            this.accOutSrcStore.GetParmOutSrcStoreInventoryQty(this.ctrlCompanyID.CompanyID,
                PrdID, ref rut);
            if (rut >= Quantity) return Quantity;
            return rut;
        }
        public void NewNote()
        {
          
            this.dtpDateNote.Value = DateTime.Now.Date;            
            this.txtNoteCode.Text = string.Empty;
            this.rchMemo.Text = string.Empty;
            this.dtblItems = this.accItems.GetDataOutSrcRecycleItemsByNoteID(-1).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
            this.dtblItems.Columns["PrdID"].AllowDBNull = false; 
            this.dtblItems.Columns["BranchStoreID"].AllowDBNull = false;
            this.dtblItems.Columns["Quantity"].AllowDBNull = false;
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
                    this.frmGridPrd.AddGridColumn("Model", "机型", 66);
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
                    this.frmPrd.AffterSelected += new JERPApp.Define.Material.FrmProduct.AffterSelectedDelegate(frmPrd_AffterSelected);
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
            grow.Cells[this.ColumnBranchStoreID.Name].Value = this.GetDefaultBranchStoreID(PrdID);
            frmPrd.Close();

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
            drowNew["Quantity"] = 0;
            drowNew["BranchStoreID"] = this.GetDefaultBranchStoreID(PrdID);
            this.dtblItems.Rows.Add(drowNew);

        }
        void dgrdv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int icol = e.ColumnIndex; ;
            int irow = e.RowIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].DataPropertyName == "PrdID")
            {
                object objPrdID = this.dgrdv[icol, irow].Value;
                if ((objPrdID != null) && (objPrdID != DBNull.Value))
                {
                    this.dgrdv[this.ColumnBranchStoreID.Name, irow].Value =
                        this.GetDefaultBranchStoreID((int)objPrdID);
                }
            }
            
        }

        bool ValidateData()
        {
            if (this.ctrlCompanyID.CompanyID == -1)
            {
                MessageBox.Show("未选择任何供应商...");
                return false;
            }
            DataRow[] drows = this.dtblItems.Select("", "", DataViewRowState.CurrentRows);
            if (drows.Length == 0)
            {
                MessageBox.Show("未存在任何明细项");
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
            flag = this.accNotes.InsertOutSrcRecycleNotes(ref errormsg, ref objNoteID, ref objNoteCode,
                this.ctrlCompanyID .CompanyID ,
                this.dtpDateNote.Value.Date,
                JERPBiz.Frame.UserBiz.PsnID,
                this.rchMemo.Text);
            if (!flag)
            {
                MessageBox .Show (errormsg);
                return;
            }
            NoteID = (long)objNoteID;
            NoteCode = objNoteCode.ToString();
            this.txtNoteCode.Text = NoteCode;
            object objItemID = DBNull.Value;
            decimal TotalAMT = 0;
            decimal Quantity,CostPrice,OutStoreQty; 
            int PrdID, BranchStoreID;

            foreach (DataRow drow in this.dtblItems.Rows )
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                 PrdID = (int)drow["PrdID"];
                 BranchStoreID = (int)drow["BranchStoreID"];
                 CostPrice = this.GetInventoryPrice(PrdID);
                 Quantity = (decimal)drow["Quantity"];
                 TotalAMT += CostPrice * Quantity;
                flag = this.accItems.InsertOutSrcRecycleItems(ref errormsg,
                   ref objItemID,
                   NoteID,
                   PrdID ,
                   Quantity,
                   BranchStoreID ,
                   CostPrice ,
                   drow["Memo"]);
                //入库
                this.accStore.InsertStoreForIntoStore(ref errormsg,
                         JERPBiz.Finance.NoteNameParm.MtrOutSrcRecycleNoteNameID,
                          NoteID,
                          NoteCode,
                          PrdID,
                          BranchStoreID ,
                          Quantity,
                          CostPrice);
                OutStoreQty = this.GetOutStoreQty(PrdID, Quantity);
                if (OutStoreQty > 0)
                {
                    //外发库减
                    this.accOutSrcStore.InsertOutSrcStoreForOutStore(
                        ref errormsg,
                        JERPBiz.Material.OutSrcStoreNoteName.OutSrcRecycleNoteNameID,
                        JERPBiz.Material.OutSrcStoreNoteName.OutSrcRecycleNoteName,
                        NoteID,
                        NoteCode,
                        PrdID,
                        this.ctrlCompanyID.CompanyID,
                        OutStoreQty,
                        CostPrice);
                    this.accOutSrcStoreReserve.SaveOutSrcStoreReserveForSubReserve(
                        ref errormsg,
                        this.ctrlCompanyID.CompanyID,
                        PrdID,
                       OutStoreQty);
                    this.accWorkingSheetReserve.SaveOutSrcStoreWorkingSheetReserveForSubReserve(ref errormsg,
                   PrdID,
                   OutStoreQty);
                }
               
            }
            if (TotalAMT > 0)
            {
                //原料费用
                this.accExpenseAccount.InsertExpenseAccountForCredit(
                    ref errormsg,
                    "领料返库单[" + NoteCode + "]",
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