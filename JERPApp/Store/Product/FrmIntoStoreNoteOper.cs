using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Product
{
    public partial class FrmIntoStoreNoteOper : Form
    {
        public FrmIntoStoreNoteOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accItems = new JERPData.Product.IntoStoreItems();
            this.accNotes = new JERPData.Product.IntoStoreNotes();
            this.accStore = new JERPData.Product.Store();
            this.accBranchSotre = new JERPData.Product.BranchStore();
            this.accWorkingSheets = new JERPData.Manufacture.WorkingSheets();
            this.accPrds = new JERPData.Product.Product();
            this.SetColumnSrc();
            this.dgrdv.CellValueChanged += new DataGridViewCellEventHandler(dgrdv_CellValueChanged);
            this.dgrdv .CellContextMenuStripNeeded +=new DataGridViewCellContextMenuStripNeededEventHandler(dgrdv_CellContextMenuStripNeeded);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnNew.Click += new EventHandler(btnNew_Click);
            this.btnPrd.Click += new EventHandler(btnPrd_Click);
            this.dgrdv.CellQuery += new JCommon.MyDataGridView.CellQueryDelegate(dgrdv_CellQuery);
        }

        private JERPData.Product.IntoStoreNotes accNotes;
        private JERPData.Product.IntoStoreItems accItems;
        private JERPData.Product.Store accStore;
        private JERPData.Product.Product accPrds;
        private JERPApp.Define.Product.FrmFinishedPrd frmPrd;
        private JERPApp.Define.Product.FrmFinishedPrd frmAddPrd;
        private JERPData.Manufacture.WorkingSheets accWorkingSheets;
        private JERPData.Product.BranchStore accBranchSotre;
        private JCommon.FrmGridFind frmGridPrd;
        private DataTable dtblItems,dtblWorkingSheets,  dtblPrds, dtblBranchStores;
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
        private void SetWorkingSheetColumn()
        {
            this.dtblWorkingSheets = this.accWorkingSheets.GetDataWorkingSheetsNeedIntoPrdStore().Tables[0];
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
             
            this.dtblPrds = this.accPrds.GetDataProductForFinishedPrd().Tables[0]; 

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
            this.rchMemo.Text = string.Empty;
            this.dtblItems = this.accItems.GetDataIntoStoreItemsByNoteID(-1).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
            this.dtblItems.Columns["PrdID"].AllowDBNull = false; 
            this.dtblItems.Columns["BranchStoreID"].AllowDBNull = false; 
            this.SetWorkingSheetColumn();
        }
        public void NewNote(DataRow[] drowWorkingSheets)
        {

            this.dtpDateNote.Value = DateTime.Now.Date; 
            this.rchMemo.Text = string.Empty;
            this.dtblItems = this.accItems.GetDataIntoStoreItemsByNoteID(-1).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
            this.dtblItems.Columns["PrdID"].AllowDBNull = false;
            this.dtblItems.Columns["BranchStoreID"].AllowDBNull = false;
            this.dtblItems.Columns["Quantity"].AllowDBNull = false;
            this.SetWorkingSheetColumn();
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
                drowNew["UnitName"] = drowWrk["UnitName"];
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
        void frmPrd_AffterSelected(DataRow drow)
        {
            int PrdID = (int)drow["PrdID"];
            DataGridViewRow grow = this.dgrdv.CurrentRow;
            grow.Cells[this.ColumnPrdID.Name].Value = PrdID;
            grow.Cells[this.ColumnPrdCode.Name].Value = drow["PrdCode"];
            grow.Cells[this.ColumnPrdName.Name].Value = drow["PrdName"];
            grow.Cells[this.ColumnPrdSpec.Name].Value = drow["PrdSpec"];
            grow.Cells[this.ColumnModel.Name].Value = drow["Model"];
            grow.Cells[this.ColumnUnitName.Name].Value = drow["UnitName"]; 
            grow.Cells[this.ColumnBranchStoreID.Name].Value = this.GetDefaultBranchStoreID(PrdID);
            this.frmPrd.Close();
        }

        void btnPrd_Click(object sender, EventArgs e)
        {
            if (frmAddPrd == null)
            {
                this.frmAddPrd = new JERPApp.Define.Product.FrmFinishedPrd();
                new FrmStyle(this.frmAddPrd).SetPopFrmStyle(this);
                this.frmAddPrd.AffterSelected += new JERPApp.Define.Product.FrmFinishedPrd.AffterSelectedDelegate(frmAddPrd_AffterSelected);
            }
            this.frmAddPrd.ShowDialog();
        }

        void frmAddPrd_AffterSelected(DataRow drow)
        {
            DataGridViewRow grow = this.dgrdv.CurrentRow;
            DataRow drowNew = this.dtblItems.NewRow();
            int PrdID = (int)drow["PrdID"];
            drowNew["PrdID"] = PrdID; 
            drowNew["PrdCode"] = drow["PrdCode"];
            drowNew["PrdName"] = drow["PrdName"];
            drowNew["PrdSpec"] = drow["PrdSpec"];
            drowNew["Model"] = drow["Model"]; 
            drowNew["UnitName"] = drow["UnitName"]; 
            drowNew["Quantity"] = 0;
            drowNew["BranchStoreID"] = this.GetDefaultBranchStoreID(PrdID);
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
                    this.frmGridPrd.AddGridColumn("PrdCode", "产品编号", 100);
                    this.frmGridPrd.AddGridColumn("PrdName", "产品名称", 120);
                    this.frmGridPrd.AddGridColumn("PrdSpec", "产品规格", 100);
                    this.frmGridPrd.AddGridColumn("Model", "型号", 66);
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
                    DataRow[] drows = this.dtblWorkingSheets.Select("WorkingSheetID=" + objWorkingSheetID.ToString());                   
                    if (drows.Length > 0)
                    {
                        this.dgrdv[this.ColumnPrdID.Name, irow].Value = drows[0]["PrdID"];
                        this.dgrdv[this.ColumnPrdCode.Name, irow].Value = drows[0]["PrdCode"];
                        this.dgrdv[this.ColumnPrdName.Name, irow].Value = drows[0]["PrdName"];
                        this.dgrdv[this.ColumnPrdSpec.Name, irow].Value = drows[0]["PrdSpec"];
                        this.dgrdv[this.ColumnModel.Name, irow].Value = drows[0]["Model"];
                        this.dgrdv[this.ColumnUnitName.Name, irow].Value = drows[0]["UnitName"];
                    }
                }
            }
            if (this.dgrdv.Columns[icol].DataPropertyName == "PrdID")
            {

                object objPrdID = this.dgrdv[icol, irow].Value;
                if ((objPrdID != DBNull.Value) && (objPrdID != null))
                {
                    this.dgrdv[this.ColumnBranchStoreID.Name, irow].Value =
                        this.GetDefaultBranchStoreID((int)objPrdID);
                }
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
                MessageBox.Show(errormsg);
                return;
            }           
            NoteID = (long)objNoteID;
            NoteCode = objNoteCode.ToString(); 
            decimal Quantity, CostPrice, CostAMT = 0;
            int PrdID, BranchStoreID;
            foreach (DataRow drow in this.dtblItems.Rows )
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                PrdID = (int)drow["PrdID"];
                BranchStoreID = (int)drow["BranchStoreID"];
                CostPrice = this.GetCostPrice(PrdID);
                Quantity = (decimal)drow["Quantity"];
                CostAMT += CostPrice * Quantity; 
                this.accItems.InsertIntoStoreItems(ref errormsg,
                   NoteID, 
                   drow["WorkingSheetID"],
                   PrdID ,
                   Quantity,
                   BranchStoreID ,
                   CostPrice,
                   drow["Memo"]);   
                //入库
                this.accStore.InsertStoreForIntoStore(ref errormsg,
                         JERPBiz.Finance.NoteNameParm.PrdIntoStoreNoteNameID,
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
           
            MessageBox.Show("成功保存并入账当前单据");
            if (this.affterSave != null) this.affterSave();
            this.NewNote();              
         
        }

 

    }
}