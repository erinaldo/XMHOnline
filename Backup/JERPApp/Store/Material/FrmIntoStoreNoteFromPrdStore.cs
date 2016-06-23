using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Material
{
    public partial class FrmIntoStoreNoteFromPrdStore : Form
    {
        public FrmIntoStoreNoteFromPrdStore()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accPrdItems = new JERPData.Product.OutStoreItems();
            this.accPrdNotes = new JERPData.Product.OutStoreNotes();
            this.accPrdStore = new JERPData.Product.Store();
            this.accPrds = new JERPData.Product.Product();
            this.accPrdStoreReserve = new JERPData.Product.StoreReserve();

            this.accMtrItems = new JERPData.Material.IntoStoreItems();
            this.accMtrNotes = new JERPData.Material.IntoStoreNotes();
            this.accMtrStore = new JERPData.Material .Store();
            this.dgrdv.CellValueChanged += new DataGridViewCellEventHandler(dgrdv_CellValueChanged);
            this.dgrdv.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdv_DataBindingComplete);
            this.ctrlPrdBranchStoreID.AffterSelected += ctrlPrdBranchStoreID_AffterSelected;
            this.dgrdv.CellContextMenuStripNeeded += new DataGridViewCellContextMenuStripNeededEventHandler(dgrdv_CellContextMenuStripNeeded);
            this.dgrdv.CellQuery += new JCommon.MyDataGridView.CellQueryDelegate(dgrdv_CellQuery);
            this.dtblPrds = this.accPrds.GetDataProductForFinishedPrd().Tables[0];
            this.btnAddPrd.Click += new EventHandler(btnAddPrd_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click); 
        }

      
        private JERPData.Product.OutStoreNotes accPrdNotes;
        private JERPData.Product.OutStoreItems accPrdItems;
        private JERPData.Product.Store accPrdStore;
        private JERPData.Product.StoreReserve accPrdStoreReserve;


        private JERPData.Material.IntoStoreNotes accMtrNotes;
        private JERPData.Material.IntoStoreItems accMtrItems;

        private JERPData.Material.Store accMtrStore;
        private JERPData.Product.Product accPrds;
        private JERPApp.Define.Product.FrmFinishedPrd frmPrd;
        private JERPApp.Define.Product.FrmFinishedPrd frmAddPrd; 
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
        
    
        public void NewNote()
        {
            this.dtpDateNote.Value = DateTime.Now.Date;
            this.txtNoteCode.Text = string.Empty; 
            this.dtblItems = this.accMtrItems .GetDataIntoStoreItemsByNoteID (-1).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
            this.dtblItems.Columns["PrdID"].AllowDBNull = false;
            this.dtblItems.Columns["PrdID"].Unique = true;
            this.dtblItems.Columns["Quantity"].AllowDBNull = false;
            this.dtblItems.Columns.Add("InventoryQty", typeof(decimal));
        }


        private decimal GetInventoryQty(int PrdID)
        {
            decimal inventoryQty = 0;
            this.accPrdStore .GetParmStoreInventoryQty(PrdID, this.ctrlPrdBranchStoreID .BranchStoreID,
                ref inventoryQty);
            return inventoryQty;
        }
        void ctrlPrdBranchStoreID_AffterSelected()
        {
            foreach (DataGridViewRow grow in this.dgrdv.Rows)
            {
                if (grow.IsNewRow) continue;
                object objPrdID = grow.Cells[this.ColumnPrdCode.Name].Value;
                if (objPrdID == DBNull.Value) continue;
                grow.Cells[this.ColumnInventoryQty.Name].Value = this.GetInventoryQty((int)objPrdID);

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
        void dgrdv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].DataPropertyName == "PrdID")
            {
                object objPrdID = this.dgrdv[icol, irow].Value;
                if (objPrdID == DBNull.Value) return;
                this.dgrdv[this.ColumnInventoryQty.Name, irow].Value = this.GetInventoryQty((int)objPrdID);
            }
        }


        bool ValidateData()
        {
            if (this.ctrlMtrBranchStoreID .BranchStoreID ==-1)
            {
                MessageBox.Show("对不起,原料库位不能为空!");
                return false;
            }
            if (this.ctrlPrdBranchStoreID.BranchStoreID == -1)
            {
                MessageBox.Show("对不起,成品库位不能为空!");
                return false;
            }
            DataRow[] drows = this.dtblItems.Select("Quantity>InventoryQty", "", DataViewRowState.CurrentRows);
            if (drows.Length > 0)
            {
                MessageBox.Show("对不起,当前库存存在不足,不能出货");
                return false;
            }
            return true;
        }
        private decimal GetCostPrice(int PrdID)
        {
            decimal rut = 0;
            this.accPrdStore.GetParmStoreInventoryPrice(PrdID, this.ctrlPrdBranchStoreID.BranchStoreID, ref rut);
            return rut;
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
            DataGridViewRow grow = this.dgrdv.CurrentRow;
            int PrdID = (int)drow["PrdID"];
            grow.Cells[this.ColumnPrdID.Name].Value = PrdID;
            grow.Cells[this.ColumnPrdCode.Name].Value = drow["PrdCode"];
            grow.Cells[this.ColumnPrdName.Name].Value = drow["PrdName"];
            grow.Cells[this.ColumnPrdSpec.Name].Value = drow["PrdSpec"];
            grow.Cells[this.ColumnModel.Name].Value = drow["Model"]; 
            grow.Cells[this.ColumnUnitName.Name].Value = drow["UnitName"]; 
            grow.Cells[this.ColumnInventoryQty.Name].Value = this.GetInventoryQty(PrdID);
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
            drowNew["Quantity"] = 0;
            drowNew["InventoryQty"] = this.GetInventoryQty(PrdID);
            this.dtblItems.Rows.Add(drowNew);

        }
        void dgrdv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow grow in this.dgrdv.Rows)
            {
                if (grow.IsNewRow) continue;
                decimal Quantity = (decimal)grow.Cells[this.ColumnQuantity.Name].Value;
                decimal Inventory = (decimal)grow.Cells[this.ColumnInventoryQty.Name].Value;
                grow.ErrorText = (Quantity > Inventory) ? "库存不足" : string.Empty;

            }
        }
        private void SavePrdNote()
        {
            bool flag = false;
            string errormsg = string.Empty;
            long NoteID = -1;
            string NoteCode = string.Empty;
            object objNoteID = DBNull.Value;
            object objNoteCode = DBNull.Value;
            flag = this.accPrdNotes.InsertOutStoreNotes(ref errormsg,
                ref objNoteID,
                ref objNoteCode,
                this.dtpDateNote.Value,
                JERPBiz.Frame.UserBiz.PsnID,
               "调出至原料库");
            if (!flag)
            {
                MessageBox.Show(errormsg);
                return;
            }
            NoteID = (long)objNoteID;
            NoteCode = objNoteCode.ToString();
            decimal CostPrice = 0;
            object objItemID = DBNull.Value;
            foreach (DataRow drow in this.dtblItems.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                objItemID = DBNull.Value;
                CostPrice = this.GetCostPrice((int)drow["PrdID"]);
                this.accPrdItems.InsertOutStoreItems (ref errormsg,
                    ref objItemID ,
                     NoteID, 
                     drow["PrdID"],
                     drow["Quantity"],
                     this.ctrlPrdBranchStoreID.BranchStoreID,
                     CostPrice,
                     DBNull.Value,
                     DBNull.Value);
                this.accPrdStore.InsertStoreForOutStore (ref errormsg,
                     JERPBiz.Finance.NoteNameParm.PrdOutStoreNoteNameID,
                   NoteID,
                   NoteCode,
                   drow["PrdID"],
                   this.ctrlPrdBranchStoreID.BranchStoreID,
                   drow["Quantity"],
                   CostPrice);
                this.accPrdStoreReserve.SaveStoreReserveForSubReserve(ref errormsg,
                    drow["PrdID"],
                    drow["Quantity"]);


            }
        }
        private void SaveMtrNote()
        {
            bool flag = false;
            string errormsg = string.Empty;
            long NoteID = -1;
            string NoteCode = string.Empty;
            object objNoteID = DBNull.Value;
            object objNoteCode = DBNull.Value;
            flag = this.accMtrNotes.InsertIntoStoreNotes  (ref errormsg,
                ref objNoteID,
                ref objNoteCode,
                this.dtpDateNote.Value.Date,
                JERPBiz.Frame.UserBiz.PsnID,
               "成品库调入");
            if (!flag)
            {
                MessageBox.Show(errormsg);
                return;
            }
            NoteID = (long)objNoteID;
            NoteCode = objNoteCode.ToString();
            this.txtNoteCode.Text = NoteCode;
            decimal CostPrice;
            foreach (DataRow drow in this.dtblItems.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;  
                CostPrice =this.GetCostPrice ((int)drow["PrdID"]);
                this.accMtrItems.InsertIntoStoreItems (ref errormsg , 
                     NoteID,
                     DBNull .Value ,
                     drow["PrdID"],
                     drow["Quantity"],
                     this.ctrlMtrBranchStoreID .BranchStoreID ,
                    CostPrice ,
                    DBNull .Value );
                //出库
                this.accMtrStore.InsertStoreForIntoStore(
                    ref errormsg,
                    JERPBiz.Finance.NoteNameParm.MtrIntoStoreNoteNameID,
                    NoteID,
                    NoteCode,
                    drow["PrdID"],
                    this.ctrlMtrBranchStoreID .BranchStoreID,
                    drow["Quantity"],
                    CostPrice);
                
            }     
        }
    
        void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult rul = MessageBox.Show("将进行保存入账一经入账不能变更！", "审核确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return;
            if (ValidateData() == false) return;
            this.SaveMtrNote();
            this.SavePrdNote();
            MessageBox.Show("成功进行当前产品的库位转移");
            if (this.affterSave != null) this.affterSave();
            this.Close();
        }

    
    }
}