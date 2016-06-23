using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Material
{
    public partial class FrmIntoStoreNoteFromOEMStore : Form
    {
        public FrmIntoStoreNoteFromOEMStore()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accItems = new JERPData.Material.IntoStoreItems();
            this.accNotes = new JERPData.Material.IntoStoreNotes();
            this.accPrds = new JERPData.Product.Product ();
            this.accStore = new JERPData.Material.Store();

            this.accOEMItems = new JERPData.Material.OEMOutStoreItems();
            this.accOEMNotes = new JERPData.Material.OEMOutStoreNotes();
            this.accOEMStore = new JERPData.Material.OEMStore();
            this.accOEMStoreReserve = new JERPData.Material.OEMStoreReserve();
             
            this.dgrdv.CellValueChanged += new DataGridViewCellEventHandler(dgrdv_CellValueChanged);
            this.dgrdv.CellQuery += new JCommon.MyDataGridView.CellQueryDelegate(dgrdv_CellQuery);
            this.dgrdv.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdv_DataBindingComplete);
            this.ctrlCompanyID.AffterSelected += new JERPApp.Define.General.CtrlCustomer.AffterSelectedDelegate(ctrlCompanyID_AffterSelected);
            this.dgrdv .CellContextMenuStripNeeded +=new DataGridViewCellContextMenuStripNeededEventHandler(dgrdv_CellContextMenuStripNeeded);
            this.dtblPrds = this.accPrds.GetDataProductForMaterial().Tables[0];
            this.btnAddPrd .Click +=new EventHandler(btnAddPrd_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
        }

      
        private JERPData.Material.Store accStore;     
        private JERPData.Material.IntoStoreNotes  accNotes;
        private JERPData.Material.IntoStoreItems  accItems;
        private JERPData.Product.Product accPrds;

        private JERPData.Material.OEMStore accOEMStore;
        private JERPData.Material.OEMOutStoreItems accOEMItems;
        private JERPData.Material.OEMOutStoreNotes accOEMNotes;
        private JERPData.Material.OEMStoreReserve accOEMStoreReserve;

        private JERPApp.Define.Material.FrmProduct frmPrd;
        private JERPApp.Define.Material.FrmProduct frmAddPrd;
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
            this.dtblItems = this.accItems.GetDataIntoStoreItemsByNoteID (-1).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
            this.dtblItems.Columns["PrdID"].AllowDBNull = false;
            this.dtblItems.Columns["PrdID"].Unique = true;
            this.dtblItems.Columns["Quantity"].AllowDBNull = false;
            this.dtblItems.Columns.Add("InventoryQty", typeof(decimal));
        }
        private decimal GetInventoryQty(int PrdID)
        {
            decimal inventoryQty = 0;
            this.accOEMStore.GetParmOEMStoreInventoryQty (PrdID, this.ctrlCompanyID.CompanyID ,
                ref inventoryQty);
            return inventoryQty;
        }

        void ctrlCompanyID_AffterSelected()
        { 
            foreach (DataGridViewRow grow in this.dgrdv.Rows)
            {
                if (grow.IsNewRow) continue;
                object objPrdID = grow.Cells[this.ColumnPrdCode.Name].Value;
                if (objPrdID == DBNull.Value) continue;
                grow.Cells[this.ColumnInventoryQty.Name].Value = this.GetInventoryQty((int)objPrdID);

            }
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
            if (this.ctrlMtrBranchStoreID.BranchStoreID ==-1)
            {
                MessageBox.Show("对不起,原料库不能为空!");
                return false;
            }
            if (this.ctrlCompanyID .CompanyID == -1)
            {
                MessageBox.Show("对不起,客供库不能为空!");
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
            this.accPrds.GetParmProductCostPrice(PrdID, ref rut);
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
                || (this.dgrdv.Columns[icol].DataPropertyName == "Model")
                || (this.dgrdv.Columns[icol].DataPropertyName == "Manufacturer"))
            {

                this.dgrdv.CurrentCell = this.dgrdv[icol, irow];
                if (frmPrd == null)
                {
                    this.frmPrd = new JERPApp.Define.Material .FrmProduct();
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
            grow.Cells[this.ColumnInventoryQty.Name].Value = this.GetInventoryQty(PrdID);
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
            drowNew["InventoryQty"] = this.GetInventoryQty(PrdID);
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
                    this.frmGridPrd.AddGridColumn("Model", "机型", 66);
                    this.frmGridPrd.AddGridColumn("Manufacturer", "品牌", 66);
                    this.frmGridPrd.AddGridColumn("AssistantCode", "助记码", 66);
                    this.frmGridPrd.AffterSelected += frmGridPrd_AffterSelected;

                }
              
                this.frmGridPrd.Query(this.dtblPrds, "AssistantCode",this.dgrdv .CurrentCell );
                 
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
        void dgrdv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow grow in this.dgrdv.Rows)
            {
                if (grow.IsNewRow) continue;
                object objQuantity = grow.Cells[this.ColumnQuantity.Name].Value;
                object objInventory = grow.Cells[this.ColumnInventoryQty.Name].Value;
                if ((objQuantity != DBNull.Value) && (objInventory != DBNull.Value))
                {
                    grow.ErrorText = ((decimal)objQuantity > (decimal)objInventory) ? "库存不足" : string.Empty;
                }
            }
        }
        void SaveOEMNote()
        {
            string errormsg = string.Empty;
            bool flag = false;
            long NoteID = -1;
            string NoteCode = string.Empty;
            object objNoteID = DBNull.Value;
            object objNoteCode = DBNull.Value;
            flag = this.accOEMNotes  .InsertOEMOutStoreNotes(ref errormsg,
                ref objNoteID,
                ref objNoteCode,
                this.dtpDateNote.Value.Date,
                JERPBiz.Frame.UserBiz.PsnID,
                "调出到原料库");
            if (!flag)
            {
                MessageBox.Show(errormsg);
                return;
            } 
            NoteID = (long)objNoteID;
            NoteCode = objNoteCode.ToString(); 
            foreach (DataRow drow in this.dtblItems.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                int PrdID = (int)drow["PrdID"];
                this.accOEMItems .InsertOEMOutStoreItems(ref errormsg,
                   NoteID,
                   PrdID,
                   drow["Quantity"],
                   this.ctrlCompanyID .CompanyID ,
                   drow["Memo"]); 
                //出库
                this.accOEMStore.InsertOEMStoreForOutStore(ref errormsg,
                          JERPApp.Store .MaterialOEM .Report .Bill .FrmBizBill .OutStoreNoteID, 
                         JERPApp.Store .MaterialOEM .Report .Bill .FrmBizBill.OutStoreNoteName ,
                          NoteID,
                          NoteCode,
                          PrdID,
                          this.ctrlCompanyID .CompanyID ,
                          drow["Quantity"]);
                //预留
                this.accOEMStoreReserve.SaveOEMStoreReserveSubReserve(
                    ref errormsg,
                    this.ctrlCompanyID .CompanyID ,
                    PrdID,
                    drow["Quantity"]); 

            
        }
        }
        void SaveNote()
        {
            bool flag = false;
            string errormsg = string.Empty;
            long NoteID = -1;
            string NoteCode = string.Empty;
            object objNoteID = DBNull.Value;
            object objNoteCode = DBNull.Value;
            flag = this.accNotes.InsertIntoStoreNotes(ref errormsg,
                ref objNoteID,
                ref objNoteCode,
                this.dtpDateNote.Value.Date,
                JERPBiz.Frame.UserBiz.PsnID,
               "客供库调入");
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
                CostPrice = this.GetCostPrice((int)drow["PrdID"]);
                this.accItems.InsertIntoStoreItems(ref errormsg,
                     NoteID,
                     DBNull.Value,
                     drow["PrdID"],
                     drow["Quantity"],
                     this.ctrlMtrBranchStoreID.BranchStoreID,
                    CostPrice,
                    DBNull.Value);
                //出库
                this.accStore .InsertStoreForIntoStore(
                    ref errormsg,
                    JERPBiz.Finance.NoteNameParm.MtrIntoStoreNoteNameID,
                    NoteID,
                    NoteCode,
                    drow["PrdID"],
                    this.ctrlMtrBranchStoreID.BranchStoreID,
                    drow["Quantity"],
                    CostPrice);

            }     
        }
        void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateData() == false) return;
            DialogResult rul = MessageBox.Show("将进行保存入账一经入账不能变更！", "审核确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return;
            this.SaveOEMNote();
            this.SaveNote();
            MessageBox.Show("成功保存并入账当前单据");
            if (this.affterSave != null) this.affterSave();
            this.Close();
        }

    
    }
}