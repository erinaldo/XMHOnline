using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Material
{
    public partial class FrmIntoStoreNoteOper : Form
    {
        public FrmIntoStoreNoteOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accItems = new JERPData.Material.IntoStoreItems();
            this.accNotes = new JERPData.Material.IntoStoreNotes();
            this.accStore = new JERPData.Material.Store();
            this.accWorkingSheets = new JERPData.Manufacture.WorkingSheets();
            this.accBranchSotre = new JERPData.Material.BranchStore();
            this.accPrds = new JERPData.Product.Product();
            this.accExpenseAccount = new JERPData.Finance.ExpenseAccount();
            this.SetColumnSrc();
            this.dgrdv.CellValueChanged += new DataGridViewCellEventHandler(dgrdv_CellValueChanged); 
            this.dgrdv.CellQuery += new JCommon.MyDataGridView.CellQueryDelegate(dgrdv_CellQuery);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.dgrdv.CellContextMenuStripNeeded += new DataGridViewCellContextMenuStripNeededEventHandler(dgrdv_CellContextMenuStripNeeded);
            this.btnNew.Click += new EventHandler(btnNew_Click);
            this.btnPrd.Click += new EventHandler(btnPrd_Click);
            
        }

     
        private JERPData.Material.IntoStoreNotes accNotes;
        private JERPData.Material.IntoStoreItems accItems;
        private JERPData.Material.Store accStore;
        private JERPData.Product.Product accPrds;
        private JERPApp.Define.Material.FrmProduct frmPrd;
        private JERPApp.Define.Material.FrmProduct frmAddPrd;
        private JCommon.FrmGridFind frmGridPrd;
        private JERPData.Material.BranchStore accBranchSotre;
        private JERPData.Finance.ExpenseAccount accExpenseAccount;
        private JERPData.Manufacture.WorkingSheets accWorkingSheets;
        private DataTable dtblItems, dtblWorkingSheets,dtblPrds, dtblBranchStores;
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
        private void SetWorkingSheetColumnSrc()
        {

            this.dtblWorkingSheets = this.accWorkingSheets.GetDataWorkingSheetsNeedIntoMtrStore().Tables[0];
            if (this.dtblWorkingSheets.Rows.Count > 0)
            {
                DataRow drowNew = this.dtblWorkingSheets.NewRow();
                drowNew["WorkingSheetID"] = -1;
                drowNew["WorkingSheetCode"] = string.Empty;
                this.dtblWorkingSheets.Rows.Add(drowNew);
            }
            this.ColumnWorkingSheetID.DataSource = this.dtblWorkingSheets;
            this.ColumnWorkingSheetID.ValueMember = "WorkingSheetID";
            this.ColumnWorkingSheetID.DisplayMember = "WorkingSheetCode";
        }
        private void SetColumnSrc()
        {

            this.dtblPrds = this.accPrds.GetDataProductForMaterial ().Tables[0];
             

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
        private decimal GetCostPrice(int PrdID)
        {
            decimal rut = 0;
            this.accPrds.GetParmProductCostPrice(PrdID, ref rut);
            return rut;
        }
        public void NewNote()
        {
          
            this.dtpDateNote.Value = DateTime.Now.Date;            
            this.txtNoteCode.Text = string.Empty;
            this.rchMemo.Text = string.Empty;
            this.dtblItems = this.accItems.GetDataIntoStoreItemsByNoteID(-1).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
            this.dtblItems.Columns["PrdID"].AllowDBNull = false; 
            this.dtblItems.Columns["BranchStoreID"].AllowDBNull = false;
            this.dtblItems.Columns["Quantity"].AllowDBNull = false;

            this.SetWorkingSheetColumnSrc();
        }
        public void NewNote(DataRow[] drowWorkingSheets)
        {

            this.dtpDateNote.Value = DateTime.Now.Date;
            this.txtNoteCode.Text = string.Empty;
            this.rchMemo.Text = string.Empty;
            this.dtblItems = this.accItems.GetDataIntoStoreItemsByNoteID(-1).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
            this.dtblItems.Columns["PrdID"].AllowDBNull = false;
            this.dtblItems.Columns["BranchStoreID"].AllowDBNull = false;
            this.dtblItems.Columns["Quantity"].AllowDBNull = false;
            this.SetWorkingSheetColumnSrc();
            DataRow drowNew = this.dtblItems.NewRow();
            foreach (DataRow drowWrk in drowWorkingSheets)
            {
                drowNew = this.dtblItems.NewRow();
                drowNew["WorkingSheetID"] = drowWrk["WorkingSheetID"];
                drowNew["PrdID"] = drowWrk["PrdID"];
                drowNew["PrdCode"] = drowWrk["PrdCode"];
                drowNew["PrdName"] = drowWrk["PrdName"];
                drowNew["PrdSpec"] = drowWrk["PrdSpec"];
                drowNew["Model"] = drowWrk["Model"];
                drowNew["Quantity"] = drowWrk["NonFinishedQty"];
                drowNew["BranchStoreID"] = this.GetDefaultBranchStoreID((int)drowWrk["PrdID"]);
                this.dtblItems.Rows.Add(drowNew);

            }
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

        void btnPrd_Click(object sender, EventArgs e)
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
            DataRow drowNew = this.dtblItems.NewRow();
            drowNew["PrdID"] = drow["PrdID"];
            drowNew["PrdCode"] = drow["PrdCode"];
            drowNew["PrdName"] = drow["PrdName"];
            drowNew["PrdSpec"] = drow["PrdSpec"];
            drowNew["Model"] = drow["Model"];
            drowNew["Manufacturer"] = drow["Manufacturer"];
            drowNew["UnitName"] = drow["UnitName"];
            drowNew["Quantity"] = 0;
            drowNew["BranchStoreID"] = this.GetDefaultBranchStoreID((int)drow["PrdID"]);
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
                    this.frmGridPrd.AddGridColumn("PrdCode", "物料编号", 80);
                    this.frmGridPrd.AddGridColumn("PrdName", "物料名称", 100);
                    this.frmGridPrd.AddGridColumn("PrdSpec", "物料规格", 100);
                    this.frmGridPrd.AddGridColumn("Model", "机型", 66);
                    this.frmGridPrd.AddGridColumn("Manufacturer", "品牌", 66);
                    this.frmGridPrd.AddGridColumn("AssistantCode", "助记码", 66);
                    this.frmGridPrd.AffterSelected += frmGridPrd_AffterSelected;

                } 
                this.frmGridPrd.Query(this.dtblPrds, "AssistantCode", this.dgrdv.CurrentCell); ;
               
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
        void dgrdv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int icol = e.ColumnIndex; ;
            int irow = e.RowIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].DataPropertyName == "WorkingSheetID")
            {
                 object objWorkingSheetID = this.dgrdv[icol, irow].Value;   
                 if (objWorkingSheetID != DBNull.Value)
                 {
                     DataRow[] drows =this.dtblWorkingSheets .Select ("WorkingSheetID="+objWorkingSheetID .ToString ());
                     if (drows.Length > 0)
                     {
                         this.dgrdv[this.ColumnPrdID.Name, irow].Value = drows[0]["PrdID"];
                         this.dgrdv[this.ColumnPrdCode.Name, irow].Value = drows[0]["PrdCode"];
                         this.dgrdv[this.ColumnPrdName.Name, irow].Value = drows[0]["PrdName"];
                         this.dgrdv[this.ColumnPrdSpec.Name, irow].Value = drows[0]["PrdSpec"];
                         this.dgrdv[this.ColumnModel.Name, irow].Value = drows[0]["Model"];
                         this.dgrdv[this.ColumnManufacturer.Name, irow].Value = drows[0]["Manufacturer"];
                         this.dgrdv[this.ColumnUnitName .Name, irow].Value = drows[0]["UnitName"];
                     }
                 }
            }
            if (this.dgrdv.Columns[icol].DataPropertyName == "PrdID")
            {
            
                object objPrdID = this.dgrdv [icol,irow].Value;
                if (objPrdID == null) return;
                if (objPrdID == DBNull.Value) return;                         
                this.dgrdv[this.ColumnBranchStoreID.Name, irow].Value =
                    this.GetDefaultBranchStoreID((int)objPrdID);           
            }
            
        }

        bool ValidateData()
        {
            bool flag = true;
            DataRow[] drows = this.dtblItems.Select("", "", DataViewRowState.CurrentRows);
            if (drows.Length == 0)
            {
                MessageBox.Show("未存在任何明细项");
                return false;
            }
            return flag;
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
            flag = this.accNotes.InsertIntoStoreNotes(ref errormsg, ref objNoteID, ref objNoteCode,
                this.dtpDateNote.Value.Date,
                JERPBiz.Frame.UserBiz.PsnID,
                this.rchMemo.Text);
            if (!flag)
            {
                MessageBox .Show (errormsg );
                return ;
            }
            NoteID = (long)objNoteID;
            NoteCode = objNoteCode.ToString();
            this.txtNoteCode.Text = NoteCode; 
            decimal TotalAMT = 0;
            foreach (DataRow drow in this.dtblItems.Rows )
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                int PrdID = (int)drow["PrdID"];
                int BranchStoreID = (int)drow["BranchStoreID"];
                decimal CostPrice = this.GetCostPrice(PrdID);
                decimal Quantity=(decimal)drow["Quantity"];
                TotalAMT += CostPrice * Quantity;
                flag = this.accItems.InsertIntoStoreItems(ref errormsg,
                   NoteID,
                   drow["WorkingSheetID"],
                   PrdID,
                   Quantity ,
                   BranchStoreID ,
                   CostPrice ,
                   drow["Memo"]);                     
                //入库
                this.accStore.InsertStoreForIntoStore(ref errormsg,
                         JERPBiz.Finance.NoteNameParm.MtrIntoStoreNoteNameID,
                          NoteID,
                          NoteCode,
                          PrdID,
                          BranchStoreID ,
                          Quantity,
                          CostPrice);
                if (drow["WorkingSheetID"] != DBNull.Value)
                {

                    this.accWorkingSheets.UpdateWorkingSheetsForAppendFinishedQty(ref errormsg,
                        drow["WorkingSheetID"],
                        Quantity);
                }
            
            }
            if (TotalAMT > 0)
            {
                //原料费用
                this.accExpenseAccount.InsertExpenseAccountForCredit(
                    ref errormsg,
                    "原料入库[" + NoteCode + "]",
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