using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.MaterialOEM
{
    public partial class FrmOutSrcRecycleNoteOper : Form
    {
        public FrmOutSrcRecycleNoteOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accItems = new JERPData.Material.OEMOutSrcRecycleItems();
            this.accNotes = new JERPData.Material.OEMOutSrcRecycleNotes();
            this.accStore = new JERPData.Material.OEMStore();
            this.accPrds = new JERPData.Product.Product();
            this.accCustomer = new JERPData.General.Customer();
            this.accOutSrcStore = new JERPData.Material.OutSrcStore();
            this.accOutSrcStoreReserve = new JERPData.Material.OutSrcStoreReserve();
            this.accWorkingSheetReserve = new JERPData.Material.OutSrcStoreWorkingSheetReserve();
            this.dgrdv.CellQuery += new JCommon.MyDataGridView.CellQueryDelegate(dgrdv_CellQuery);
            this.SetColumnSrc();
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.dgrdv .CellContextMenuStripNeeded +=new DataGridViewCellContextMenuStripNeededEventHandler(dgrdv_CellContextMenuStripNeeded);
            this.btnAddPrd.Click += new EventHandler(btnAddPrd_Click);
        }

     
        private JERPData.Material.OEMOutSrcRecycleNotes accNotes;
        private JERPData.Material.OEMOutSrcRecycleItems accItems;
        private JERPData.General.Customer accCustomer;
        private JERPData.Material.OEMStore accStore;
        private JERPData.Product.Product accPrds;
        private JERPData.Material.OutSrcStore accOutSrcStore;
        private JERPData.Material.OutSrcStoreReserve accOutSrcStoreReserve;
        private JERPData.Material.OutSrcStoreWorkingSheetReserve accWorkingSheetReserve;
        private JERPApp.Define.Material.FrmProduct frmPrd;
        private JERPApp.Define.Material.FrmProduct frmAddPrd;
        private DataTable dtblItems, dtblPrds, dtblCustomers;
        private JCommon.FrmGridFind frmGridPrd;
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

            this.dtblPrds = this.accPrds.GetDataProductForMaterial ().Tables[0];
           

            this.dtblCustomers = this.accCustomer.GetDataCustomer().Tables[0];
            this.ColumnCustomerID.DataSource = this.dtblCustomers;
            this.ColumnCustomerID.ValueMember = "CompanyID";
            this.ColumnCustomerID.DisplayMember = "CompanyAbbName";

          

        }
      
        public void NewNote()
        {
          
            this.dtpDateNote.Value = DateTime.Now.Date;            
            this.txtNoteCode.Text = string.Empty;
            this.rchMemo.Text = string.Empty;
            this.dtblItems = this.accItems.GetDataOEMOutSrcRecycleItemsByNoteID(-1).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
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
            drows = this.dtblItems.Select("PrdID is null or Quantity is null or CustomerID is null", "", DataViewRowState.CurrentRows);
            if (drows.Length > 0)
            {
                MessageBox.Show("存在未完成项");
                return false;
            }
            return flag;
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
            this.dtblItems.Rows.Add(drowNew);

        }
        private decimal GetOutSrcInventoryPrice(int PrdID)
        {
            decimal rut = 0;
            this.accOutSrcStore.GetParmOutSrcStoreInventoryPrice(this.ctrlCompanyID.CompanyID,
                PrdID, ref rut);
            return rut;
        }
        private decimal GetOutStoreQty(int PrdID, decimal Quantity)
        {
            decimal rut = 0;
            this.accOutSrcStore.GetParmOutSrcStoreInventoryQty(this.ctrlCompanyID.CompanyID,
                PrdID, ref rut);
            if (rut >= Quantity) return Quantity;
            return rut;
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
            object objNoteCode=DBNull .Value ;
            flag = this.accNotes.InsertOEMOutSrcRecycleNotes(ref errormsg,
                ref objNoteID,
                ref objNoteCode ,
                this.ctrlCompanyID .CompanyID ,
                this.dtpDateNote.Value.Date,
                JERPBiz.Frame.UserBiz.PsnID,
                this.rchMemo.Text);
            if (!flag)
            {
                MessageBox .Show (errormsg );
                return;
            }
            NoteID = (long)objNoteID;
            NoteCode = objNoteCode.ToString();
            this.txtNoteCode.Text = NoteCode;
            int PrdID = 0,CustomerID;
            decimal InventoryPrice,OutStoreQty,Quantity;
            foreach (DataRow drow in this.dtblItems.Rows )
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                PrdID = (int)drow["PrdID"];
                InventoryPrice = this.GetOutSrcInventoryPrice(PrdID);
                Quantity = (decimal)drow["Quantity"];
                CustomerID = (int)drow["CustomerID"];
                this.accItems.InsertOEMOutSrcRecycleItems(ref errormsg,
                   NoteID,
                   PrdID,
                   Quantity ,
                   CustomerID,
                   drow["Memo"]); 
                //入库
                this.accStore.InsertOEMStoreForIntoStore(ref errormsg,
                          Report.Bill.FrmBizBill.OutSrcRecycleNoteID,
                          Report.Bill.FrmBizBill.OutSrcRecycleNoteName,
                          NoteID,
                          NoteCode,
                          PrdID,
                          CustomerID,
                          Quantity );
                OutStoreQty = this.GetOutStoreQty(PrdID, Quantity);
                if (OutStoreQty > 0)
                {
                    //委外出
                    this.accOutSrcStore.InsertOutSrcStoreForOutStore(ref errormsg,
                        JERPBiz.Material.OutSrcStoreNoteName.OutSrcRecycleOEMNoteNameID,
                        JERPBiz.Material.OutSrcStoreNoteName.OutSrcRecycleOEMNoteName,
                        NoteID,
                        NoteCode,
                        PrdID,
                        this.ctrlCompanyID.CompanyID,
                        OutStoreQty,
                        InventoryPrice);
                    //预留出
                    this.accOutSrcStoreReserve.SaveOutSrcStoreReserveForSubReserve(ref errormsg,
                        this.ctrlCompanyID.CompanyID,
                        PrdID,
                        OutStoreQty);

                    this.accWorkingSheetReserve.SaveOutSrcStoreWorkingSheetReserveForSubReserve(ref errormsg,
                        PrdID,
                        OutStoreQty);
                }
            }

            MessageBox.Show("成功保存并入账当前单据");
            if (this.affterSave != null) this.affterSave();
            this.NewNote();
        }

 

    }
}