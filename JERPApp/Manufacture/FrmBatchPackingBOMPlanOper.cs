using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture
{
    public partial class FrmBatchPackingBOMPlanOper : Form
    {
        public FrmBatchPackingBOMPlanOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.ctrlCheckedAll.SeachGridView = this.dgrdv; 
            this.BOMPlanHelper = new JERPBiz.Manufacture.BOMPlanHelper(); 
            this.accPackingPlans = new JERPData.Packing .PackingPlans();  
            this.accBOMPlans = new JERPData.Packing .BOMPlans();
            this.accPackingBOM = new JERPData.Product.PackingBOM();
            this.dgrdv.ContextMenuStrip = this.cMenu;
            this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            for (int j = 1; j < this.dgrdv.ColumnCount; j++)
            {
                this.dgrdv.Columns[j].ReadOnly = true;
            }
        }


        private JERPData.Packing .PackingPlans  accPackingPlans; 
        private JERPBiz.Manufacture.BOMPlanHelper BOMPlanHelper;    
        private JERPData.Packing .BOMPlans accBOMPlans;
        private JERPData.Product.PackingBOM accPackingBOM;
        private DataTable dtblPackingPlans;
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
        public void LoadData()
        {
            this.dtblPackingPlans =  this.accPackingPlans.GetDataPackingPlansNeedBOMPlan().Tables[0];
            this.dtblPackingPlans.Columns.Add("CheckedFlag", typeof(bool));
            this.dgrdv .DataSource = this.dtblPackingPlans ;
             
        } 
        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
       
        void btnSave_Click(object sender, EventArgs e)
        {
            if (this.dtblPackingPlans.Select("CheckedFlag=1").Length == 0)
            {
                MessageBox.Show("未选择任何计划");
                return;
            }
            DialogResult rul = MessageBox.Show("即将对选中包装计划生成物料计划,请先确认组成物料的正确性,一经保存不能变更！", "操作确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return; 
            string errormsg=string.Empty ;
            int index=1; 
            foreach (DataRow drowPackingPlan in this.dtblPackingPlans .Rows )
            {
                Application.DoEvents();
                FrmMsg.Show("正在进行第[" + index.ToString() + "]批次物料计算");
                if ((drowPackingPlan["CheckedFlag"] == DBNull.Value)
                    || ((bool)drowPackingPlan["CheckedFlag"] == false)) continue; 
               //玩包装
                this.SavePackingBOMPlan(drowPackingPlan); 
                this.accPackingPlans.UpdatePackingPlansForBOMPlan(ref errormsg,
                    drowPackingPlan["PackingPlanID"]);
                index++;
            }
            FrmMsg.Hide();
            MessageBox.Show("成功生成当前物料计划");
            if (this.affterSave != null) this.affterSave();
            this.Close();
            
        }

     
        public void SavePackingBOMPlan(DataRow drowPackingPlan)
        {
            string errormsg = string.Empty;
            decimal RequireQty;
            int PrdID;
            long PackingPlanID = (long)drowPackingPlan["PackingPlanID"]; 
            decimal  PackingQty =(decimal )drowPackingPlan["Quantity"];
            int PackingTypeID = (int)drowPackingPlan["PackingTypeID"];
            int CustomerID =((drowPackingPlan["CompanyID"]==DBNull .Value )?-1:(int)drowPackingPlan["CompanyID"]);
             int SourceTypeID = 1;
            decimal StoreQty, RoadStoreQty,PlanQty;
            DataTable dtblBOM = this.accPackingBOM.GetDataPackingBOMByPackingTypeID(
                PackingTypeID).Tables[0];
            foreach (DataRow drowBom in dtblBOM.Rows)
            {

                RequireQty = PackingQty * (int)drowBom["PackageAssembly"] / (int)drowBom["PrdAssembly"];
                PrdID = (int)drowBom["PrdID"];
                SourceTypeID = (int)drowBom["SourceTypeID"];
                StoreQty = this.BOMPlanHelper.GetStoreAvailableQty(PrdID);
                RoadStoreQty = this.BOMPlanHelper.GetRoadAvailableQty(PrdID);
                if ((SourceTypeID == 3) && (CustomerID > -1))
                {
                    StoreQty = this.BOMPlanHelper.GetOEMStoreAvailableQty(CustomerID, PrdID);
                    RoadStoreQty = this.BOMPlanHelper.GetOEMRoadAvailableQty(CustomerID, PrdID);
                }
                PlanQty =RequireQty -StoreQty -RoadStoreQty ;
                if(PlanQty <0)
                {
                    PlanQty =0;
                } 
                if ((SourceTypeID < 3) || (CustomerID < 0))
                {
                    this.BOMPlanHelper.BOMHandle(CustomerID, PrdID, RequireQty, SourceTypeID);
                }
                if ((SourceTypeID == 3) && (CustomerID > -1))
                {
                    this.BOMPlanHelper.BOMOEMHandle(CustomerID, PrdID, RequireQty);
                }
                this.accBOMPlans.InsertBOMPlans (
                   ref errormsg,
                   PackingPlanID,
                   PrdID,
                   drowBom["PrdAssembly"],
                   drowBom["PrdAssembly"],
                    SourceTypeID,
                    RequireQty,
                    StoreQty,
                    RoadStoreQty,
                    PlanQty); 
            } 
            
     
    }
      
    
   
    }
}