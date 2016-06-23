using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.MaterialOEM
{
    public partial class FrmOutStoreNoteOper : Form
    {
        public FrmOutStoreNoteOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accItems = new JERPData.Material.OEMOutStoreItems();
            this.accNotes = new JERPData.Material.OEMOutStoreNotes();
            this.accStore = new JERPData.Material.OEMStore();
            this.accReserve = new JERPData.Material.OEMStoreReserve();
            this.accPrds = new JERPData.Product.Product();
            this.accCustomer = new JERPData.General.Customer();
            this.dgrdv.CellQuery += new JCommon.MyDataGridView.CellQueryDelegate(dgrdv_CellQuery);
            this.SetColumnSrc();
            this.dgrdv .CellContextMenuStripNeeded +=new DataGridViewCellContextMenuStripNeededEventHandler(dgrdv_CellContextMenuStripNeeded);
            this.dgrdv.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdv_DataBindingComplete);
            this.dgrdv.CellValueChanged += new DataGridViewCellEventHandler(dgrdv_CellValueChanged);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnAddPrd.Click += new EventHandler(btnAddPrd_Click);
           
        }

     
        private JERPData.Material.OEMOutStoreNotes accNotes;
        private JERPData.Material.OEMOutStoreItems accItems;
        private JERPData.General.Customer accCustomer;
        private JERPData.Material.OEMStore accStore;
        private JERPData.Material.OEMStoreReserve accReserve;
        private JERPData.Product.Product accPrds;
        private JERPApp.Define.Material.FrmProduct frmPrd;
        private JERPApp.Define.Material.FrmProduct frmAddPrd;
        private JCommon.FrmGridFind frmGridPrd;
        private DataTable dtblItems, dtblPrds, dtblCustomers;
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
            this.ColumnCompanyID.DataSource = this.dtblCustomers;
            this.ColumnCompanyID.ValueMember = "CompanyID";
            this.ColumnCompanyID.DisplayMember = "CompanyAbbName";

          

        }
      
        public void NewNote()
        {
          
            this.dtpDateNote.Value = DateTime.Now.Date;            
            this.txtNoteCode.Text = string.Empty;
            this.rchMemo.Text = string.Empty;
            this.dtblItems = this.accItems.GetDataOEMOutStoreItemsByNoteID (-1).Tables[0];
            this.dtblItems.Columns["PrdID"].AllowDBNull = false;
            this.dtblItems.Columns["PrdID"].Unique = true;
            this.dtblItems.Columns.Add("InventoryQty", typeof(decimal));
            this.dgrdv.DataSource = this.dtblItems;
        }
        private decimal GetStoreQty(int CompanyID,int PrdID)
        {
            decimal rut = 0;
            this.accStore.GetParmOEMStoreInventoryQty(CompanyID, PrdID, ref rut);
            return rut;
        }
        bool ValidateData()
        {
          
            DataRow[] drows = this.dtblItems.Select("", "", DataViewRowState.CurrentRows);
            if (drows.Length == 0)
            {
                MessageBox.Show("未存在任何明细项");
                return false;
            }
            drows = this.dtblItems.Select("Quantity is null or CompanyID is null", "", DataViewRowState.CurrentRows);
            if (drows.Length > 0)
            {
                MessageBox.Show("存在未完成项");
                return false;
            }
            drows = this.dtblItems.Select("Quantity>InventoryQty", "", DataViewRowState.CurrentRows);
            if (drows.Length > 0)
            {
                MessageBox.Show("对不起,当前库存存在不足,不能出货");
                return false;
            }
           
            return true;
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
        void dgrdv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;          
            if ((this.dgrdv.Columns[icol].DataPropertyName == "PrdID")
               || (this.dgrdv.Columns[icol].Name == this.ColumnCompanyID.Name))
            {
                object objPrdID = this.dgrdv[this.ColumnPrdID.Name, irow].Value;
                object objCompanyID = this.dgrdv[this.ColumnCompanyID.Name, irow].Value;
                if ((objPrdID != DBNull.Value)
                    && (objPrdID != null)
                    && (objCompanyID != DBNull.Value)
                    && (objCompanyID != null))
                {
                    this.dgrdv[this.ColumnInventoryQty.Name, irow].Value = this.GetStoreQty((int)objCompanyID,(int)objPrdID);
                }
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
        void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateData() == false) return;
             DialogResult rul = MessageBox.Show("将进行保存出账一经出账不能变更！", "审核确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return;
            string errormsg = string.Empty;
            bool flag = false;
            long NoteID = -1;
            string NoteCode = string.Empty;
            object objNoteID = DBNull.Value;
            object objNoteCode=DBNull .Value ;
            flag = this.accNotes.InsertOEMOutStoreNotes(ref errormsg,
                ref objNoteID,
                ref objNoteCode ,
                this.dtpDateNote.Value.Date,
                JERPBiz.Frame.UserBiz.PsnID,
                this.rchMemo.Text);
            if (flag)
            {
                NoteID = (long)objNoteID;
                NoteCode = objNoteCode.ToString();
                this.txtNoteCode.Text = NoteCode;
                foreach (DataRow drow in this.dtblItems.Rows )
                {
                    if (drow.RowState == DataRowState.Deleted) continue;
                    int PrdID = (int)drow["PrdID"];
                    flag = this.accItems.InsertOEMOutStoreItems(ref errormsg,
                       NoteID,
                       PrdID ,
                       drow["Quantity"],
                       drow["CompanyID"],
                       drow["Memo"]);
                    if (flag)
                    {

                        //出库
                        this.accStore.InsertOEMStoreForOutStore(ref errormsg,
                                  Report.Bill.FrmBizBill.OutStoreNoteID,
                                  Report.Bill.FrmBizBill.OutStoreNoteName,
                                  NoteID,
                                  NoteCode,
                                  PrdID,
                                  drow["CompanyID"],
                                  drow["Quantity"]);
                        //预留
                        this.accReserve.SaveOEMStoreReserveSubReserve(
                            ref errormsg,
                            drow["CompanyID"],
                            PrdID ,
                            drow["Quantity"]);
                      
                    } 
                   
                }
                MessageBox.Show("成功保存并出账当前单据");
                if (this.affterSave != null) this.affterSave();
                this.NewNote();
            }
        }

 

    }
}