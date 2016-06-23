using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture
{
    public partial class FrmBOMPlanForPacking : Form
    {
        public FrmBOMPlanForPacking()
        {
            InitializeComponent();
            this.accBom = new JERPData.Product.PackingBOM();
            this.gridhelper = new JCommon.DataGridViewHelper();
            this.accPackingPlans = new JERPData.Packing.PackingPlans();
            this.BOMPlanHelper = new JERPBiz.Manufacture.BOMPlanHelper();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accPrd = new JERPData.Product.Product();
            this.PackingPlanEntity = new JERPBiz.Packing.PackingPlanEntity();
            this.accSourceType = new JERPData.Product.SourceType();
            this.accBOMPlans = new JERPData.Packing.BOMPlans();
            this.ctrlCompanyID.AppendAll();
            this.SetColumnSrc();
            this.dgrdv.CellPainting += new DataGridViewCellPaintingEventHandler(dgrdv_CellPainting);
            this.ctrlPrdID.AffterSelected +=  ctrlPrdID_AffterSelected;
          
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnAdd.Click += new EventHandler(btnAdd_Click); 
            this.dgrdv.CellContextMenuStripNeeded += dgrdv_CellContextMenuStripNeeded;
            this.dgrdv .CellValueChanged +=new DataGridViewCellEventHandler(dgrdv_CellValueChanged);
            this.ctrlPackingTypeID.AffterSelected += this.LoadBom;
            this.txtQuantity.TextChanged += new EventHandler(txtQuantity_TextChanged);
        }


        private JERPData.Product.PackingBOM accBom;
        private JERPData.Product.Product accPrd;
        private JERPData.Product .SourceType accSourceType;
        private JERPData.Packing .PackingPlans    accPackingPlans;
        private JERPData.Packing .BOMPlans accBOMPlans;
        private JERPApp.Define.Product.FrmProduct frmPrd;
        private JERPApp.Define.Product.FrmProduct frmPrdAlter;
        private DataTable dtblBom, dtblSourceType;
        private JCommon.DataGridViewHelper gridhelper;

        private JERPBiz.Manufacture .BOMPlanHelper BOMPlanHelper;
        private JERPBiz.Packing .PackingPlanEntity    PackingPlanEntity;
        private long packingplanid = -1;
        private long PackingPlanID
        {
            get
            {
                return this.packingplanid;
            }
            set
            {
                this.packingplanid = value;
                this.ctrlPackingTypeID.Enabled = (value == -1);
                this.ctrlPrdID.Enabled = (value == -1);
                this.txtQuantity.Enabled = (value == -1);
            }

        }
        private void LoadBom()
        {

            this.dtblBom = this.accBom.GetDataPackingBOMForPackingRequire   (this.ctrlPackingTypeID.PackingTypeID).Tables[0];
            this.dtblBom.Columns.Add("RequireQty", typeof(decimal));
            this.dtblBom.Columns["SourceTypeID"].DefaultValue = 2; 
            this.dtblBom.Columns.Add("StoreQty", typeof(decimal));
            this.dtblBom.Columns.Add("RoadStoreQty", typeof(decimal));
            this.dtblBom.Columns.Add("PlanQty", typeof(decimal));
            this.SetBOMStoreQty(); 
            this.dgrdv.DataSource = this.dtblBom;

        }
        void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            decimal Quantity;
            if (!decimal.TryParse(this.txtQuantity.Text, out Quantity))
            {
                MessageBox.Show("数量格式不正确");
                return;
            }
            this.SetBOMStoreQty();
        }

        private void SetBOMStoreQty(DataRow drowBom)
        {
            int PrdID = (int)drowBom["PrdID"];
            decimal ManufQty = decimal.Parse (this.txtQuantity.Text);
            int PrdAssembly = 1,PackageAssembly=1;
            int SourceTypeID = (int)drowBom["SourceTypeID"];
            decimal  RequireQty = 0,  StoreQty = 0, RoadStoreQty = 0, PlanQty = 0; 
            if (drowBom["PrdAssembly"] == DBNull.Value)
            {
                PrdAssembly = (int)drowBom["PrdAssembly"];
            }
            if (drowBom["PackageAssembly"] == DBNull.Value)
            {
                PackageAssembly = (int)drowBom["PackageAssembly"];
            }
            RequireQty = Convert.ToInt32 (ManufQty * PackageAssembly/PrdAssembly); 
            StoreQty = this.BOMPlanHelper.GetStoreAvailableQty(PrdID);
            if ((SourceTypeID == 3)&&(this.ctrlCompanyID .CompanyID >0))
            {
                StoreQty = this.BOMPlanHelper.GetOEMStoreAvailableQty (this.ctrlCompanyID .CompanyID ,PrdID);
            }
            RoadStoreQty = this.BOMPlanHelper.GetRoadAvailableQty(PrdID);
            if ((SourceTypeID == 3) && (this.ctrlCompanyID.CompanyID > 0))
            {
                RoadStoreQty = this.BOMPlanHelper.GetOEMRoadAvailableQty(this.ctrlCompanyID.CompanyID, PrdID);
            }
            PlanQty = RequireQty - StoreQty - RoadStoreQty;
            if (PlanQty < 0)
            {
                PlanQty = 0;
            }
            drowBom["RequireQty"] = RequireQty; 
            drowBom["StoreQty"] = StoreQty;
            drowBom["RoadStoreQty"] = RoadStoreQty;
            drowBom["PlanQty"] = PlanQty;
        }
        private void SetBOMStoreQty()
        {
            if (this.dtblBom == null) return;
            foreach (DataRow drow in this.dtblBom.Select("PrdID>-1", "", DataViewRowState.CurrentRows))
            {
                this.SetBOMStoreQty(drow);
            }

        }
        void btnLoad_Click(object sender, EventArgs e)
        {
            this.LoadBom();
        }
  
        private void SetColumnSrc()
        {

            this.dtblSourceType = this.accSourceType.GetDataSourceType().Tables[0];
            foreach (DataRow drow in this.dtblSourceType.Select("SourceTypeID>3"))
            {
                this.dtblSourceType.Rows.Remove(drow);
            }
            this.ColumnSourceTypeName.DataSource = this.dtblSourceType;
            this.ColumnSourceTypeName.ValueMember = "SourceTypeID";
            this.ColumnSourceTypeName.DisplayMember = "SourceTypeName";

        }
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
        void ctrlPrdID_AffterSelected()
        { 
            this.ctrlPackingTypeID.LoadData(this.ctrlPrdID.PrdID);
        }
        
        public void PackingPlan(long PackingPlanID)
        {
            this.PackingPlanID = PackingPlanID ;
            this.PackingPlanEntity.LoadData(PackingPlanID); 
            this.ctrlCompanyID.CompanyID = this.PackingPlanEntity.CompanyID;
            this.ctrlCompanyID.Enabled = false;
            this.ctrlPrdID.PrdID = this.PackingPlanEntity.PrdID;
            this.ctrlPrdID.Enabled = false; 
            
            this.ctrlPackingTypeID.LoadData(this.ctrlPrdID.PrdID);
            this.ctrlPackingTypeID.PackingTypeID = this.PackingPlanEntity.PackingTypeID;

            this.txtQuantity.Text = string.Format("{0:0.####}", this.PackingPlanEntity.Quantity);
            this.LoadBom();
        }
        public void PackingPlan()
        {
            this.PackingPlanID = -1;
            this.ctrlPrdID.PrdID = -1;
            this.ctrlPrdID.Enabled = true;  
            this.ctrlPackingTypeID.LoadData(-1); 
            this.ctrlCompanyID.CompanyID = -1;
            this.ctrlCompanyID.Enabled = true;
            this.txtQuantity.Text = "0";
            this.LoadBom();
            
        }
        void dgrdv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if (irow > -1) return;
            if ((icol == 6) || (icol == 7))
            {
                this.gridhelper.MerageColumnHeaderSpan(this.dgrdv, e, 6, 7, "用量比");
            }
        }
        private bool ValidateData()
        {
            
            if (this.ctrlPrdID.PrdID == -1)
            {
                MessageBox.Show("未选择任何产品");
                return false;
            }
            int d;
            if(!int .TryParse (this.txtQuantity .Text ,out d)
                ||(d<0))
            {
                MessageBox.Show("包装数量不正确");
                return false;
            }
            if (this.dtblBom.Select("", "", DataViewRowState.CurrentRows).Length == 0)
            {
                MessageBox.Show("没有任何物料");
                return false;
            }
            if (this.dtblBom.Select("PrdID is null or SourceTypeID is null or PackageAssembly is null or PrdAssembly is null", "", DataViewRowState.CurrentRows ).Length> 0)
            {
                MessageBox.Show("存在错误行,注意包材,包材用量,产品用量数据");
                return false;
            }
            return true;
        }
        private decimal GetReserveQty(decimal RequireQty, decimal StoreQty)
        {
            if (RequireQty >= StoreQty)
            {
                return StoreQty;
            }
            return RequireQty;
        }

        void dgrdv_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if ((this.dgrdv.Columns[icol].DataPropertyName == "PrdCode")
                || (this.dgrdv.Columns[icol].DataPropertyName == "PrdName")
                || (this.dgrdv.Columns[icol].DataPropertyName == "PrdSpec")
                ||(this.dgrdv.Columns[icol].DataPropertyName == "Model")
                || (this.dgrdv.Columns[icol].DataPropertyName == "Manufacturer"))
            {
                this.dgrdv .CurrentCell =this.dgrdv [icol,irow];
                if(frmPrdAlter ==null)
                {
                    frmPrdAlter =new JERPApp.Define.Product.FrmProduct ();
                    new FrmStyle (frmPrdAlter).SetPopFrmStyle (this);
                    frmPrdAlter.AllowAppendFlag = true;
                    frmPrdAlter .AffterSelected +=frmPrdAlter_AffterSelected;
                }
                frmPrdAlter .ShowDialog ();
            }
        }

        void frmPrdAlter_AffterSelected(DataRow drow)
        {
            DataRow[] drowBoms = this.dtblBom.Select("PrdID=" + drow["PrdID"].ToString());
            if (drowBoms.Length > 0)
            {
                MessageBox.Show("已存在此包材");
                return;
            }
            DataGridViewRow grow = this.dgrdv.CurrentRow;
            grow.Cells[this.ColumnPrdID.Name].Value = drow["PrdID"];
            grow.Cells[this.ColumnPrdCode.Name].Value = drow["PrdCode"];
            grow.Cells[this.ColumnPrdName .Name].Value = drow["PrdName"];
            grow.Cells[this.ColumnPrdSpec .Name].Value = drow["PrdSpec"];
            grow.Cells[this.ColumnModel .Name].Value = drow["Model"];
            grow.Cells[this.ColumnManufacturer.Name].Value = drow["Manufacturer"];
            grow.Cells[this.ColumnPackageAssembly .Name].Value = 1;
            grow.Cells[this.ColumnPrdAssembly .Name].Value = 1;
            grow.Cells[this.ColumnSourceTypeName .Name].Value = 2; 
            this.SetBOMStoreQty(drowBoms[0]);
            this.frmPrdAlter.Close();

        }

        void btnAdd_Click(object sender, EventArgs e)
        {
            if (frmPrd== null)
            {
                frmPrd = new JERPApp.Define.Product.FrmProduct();
                new FrmStyle(frmPrd).SetPopFrmStyle(this);
                frmPrd.AffterSelected += frmPrd_AffterSelected;
            }
            frmPrd.ShowDialog();
        }

        void frmPrd_AffterSelected(DataRow drow)
        {
            DataRow[] drowBoms = this.dtblBom.Select("PrdID=" + drow["PrdID"].ToString());
            if (drowBoms.Length > 0)
            {
                MessageBox.Show("此包材已存在");
                return;
            }
            DataRow drowNew = this.dtblBom.NewRow();
            drowNew["PrdID"] = drow["PrdID"];
            drowNew["PrdCode"] = drow["PrdCode"];
            drowNew["PrdName"] = drow["PrdName"];
            drowNew["PrdSpec"] = drow["PrdSpec"];
            drowNew["Model"] = drow["Model"];
            drowNew["Manufacturer"] = drow["Manufacturer"];
            drowNew["PrdAssembly"] = 1;
            drowNew["PackageAssembly"] = 1;
            drowNew["SourceTypeID"] = 2; 
            this.SetBOMStoreQty(drowNew);
            this.dtblBom.Rows.Add(drowNew);
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
                    this.SetBOMStoreQty(this.dtblBom.DefaultView[irow].Row);
                }
            }
            if (this.dgrdv.Columns[icol].DataPropertyName == "SourceTypeID")
            {
                this.SetBOMStoreQty(this.dtblBom.DefaultView[irow].Row);
            }

        }
   
        void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateData()) return;
            DialogResult rul = MessageBox.Show("即将生成包材需求计划,一经保存不能变更！", "申请计算", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return;
            string errormsg = string.Empty;
            decimal RequireQty;
            int PrdID;
            int Quantity = int.Parse(this.txtQuantity.Text);
            int CustomerID = this.ctrlCompanyID.CompanyID;
            int SourceTypeID = 1; 
            foreach (DataRow drow in this.dtblBom.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                RequireQty = Quantity * (int)drow["PackageAssembly"] / (int)drow["PrdAssembly"];
                PrdID =(int)drow["PrdID"];
                SourceTypeID = (int)drow["SourceTypeID"];
                if (this.PackingPlanID > -1)
                {
                    this.accBOMPlans.InsertBOMPlans(ref errormsg,
                        this.PackingPlanID,
                        PrdID,
                        drow["PrdAssembly"],
                        drow["PackageAssembly"],
                        SourceTypeID,
                        RequireQty,
                        drow["StoreQty"], 
                        drow["RoadStoreQty"],
                        drow["PlanQty"]);
                } 
                if (RequireQty <= 0) continue;
                if ((SourceTypeID < 3)||(CustomerID <0))
                {
                    this.BOMPlanHelper.BOMHandle(CustomerID, PrdID, RequireQty, SourceTypeID );
                }
                if ((SourceTypeID == 3) && (CustomerID > -1))
                {
                    this.BOMPlanHelper.BOMOEMHandle(CustomerID, PrdID, RequireQty);
                }
              
            }
            MessageBox.Show("成功生成包材需求计划");
            if (this.PackingPlanID > -1)
            { 
                this.accPackingPlans.UpdatePackingPlansForBOMPlan  (ref errormsg, 
                    this.PackingPlanID  
                    );

                if (this.affterSave != null) this.affterSave();
            }
            this.Close();
        }

     
    }
}