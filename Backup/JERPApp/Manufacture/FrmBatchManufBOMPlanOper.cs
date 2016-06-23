using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture
{
    public partial class FrmBatchManufBOMPlanOper : Form
    {
        public FrmBatchManufBOMPlanOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.ctrlCheckedAll.SeachGridView = this.dgrdv;
            this.accBOM = new JERPData.Product.BOM(); 
            this.ManufProcessEntity = new JERPBiz.Manufacture.ManufProcessEntity(); 
            this.BOMPlanHelper = new JERPBiz.Manufacture.BOMPlanHelper();
            this.accBOMPlans = new JERPData.Manufacture.BOMPlans();
            this.accManufPlans = new JERPData.Manufacture.ManufPlans();
            this.accManufProcess = new JERPData.Manufacture.ManufProcess();
            this.ManufPlanEntity = new JERPBiz.Manufacture.ManufPlanEntity(); 
            this.dgrdv.ContextMenuStrip = this.cMenu;
            this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            for (int j = 1; j < this.dgrdv.ColumnCount; j++)
            {
                this.dgrdv.Columns[j].ReadOnly = true;
            }
        }


        private JERPData.Manufacture.ManufPlans  accManufPlans;
        private JERPData.Manufacture.ManufProcess accManufProcess; 
        private JERPBiz.Manufacture.BOMPlanHelper BOMPlanHelper;  
        private JERPData.Product.BOM accBOM;    
        private JERPBiz.Manufacture.ManufProcessEntity ManufProcessEntity;
        private JERPBiz.Manufacture.ManufPlanEntity ManufPlanEntity; 
        private JERPData.Manufacture.BOMPlans accBOMPlans; 
        private DataTable dtblManufPlans;
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
            this.dtblManufPlans =  this.accManufPlans.GetDataManufPlansNeedBOMPlan  ().Tables[0];
            this.dtblManufPlans.Columns.Add("CheckedFlag", typeof(bool));
            this.dgrdv .DataSource = this.dtblManufPlans ;
             
        }

        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
       
        void btnSave_Click(object sender, EventArgs e)
        {
            if (this.dtblManufPlans.Select("CheckedFlag=1").Length == 0)
            {
                MessageBox.Show("未选择任何计划");
                return;
            }
            DialogResult rul = MessageBox.Show("即将对选中生产计划生成物料计划,请先确认组成物料的正确性,一经保存不能变更！", "操作确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return;
            DataTable dtblManufProcess;
            int PrdID=-1;
            long ManufPlanID = -1;
            long ManufProcessID = -1;
            decimal ManufQty=0;
            string errormsg=string.Empty ;
            int index=1; 
            foreach (DataRow drowManufPlan in this.dtblManufPlans .Rows )
            {
                Application.DoEvents();
                FrmMsg.Show("正在进行第[" + index.ToString() + "]批次物料计算");
                if((drowManufPlan["CheckedFlag"]==DBNull .Value )
                    ||((bool)drowManufPlan["CheckedFlag"]==false))continue ;
                ManufPlanID = (long)drowManufPlan["ManufPlanID"];
                PrdID = (int)drowManufPlan["PrdID"];
                ManufQty =(decimal)drowManufPlan ["Quantity"];
               
                dtblManufProcess = this.accManufProcess.GetDataManufProcessByPrdID((int)drowManufPlan["PrdID"]).Tables[0];
                foreach (DataRow drow in dtblManufProcess.Rows)
                {
                    ManufProcessID = (long)drow["ManufProcessID"];
                    this.SaveBOMPlan(ManufPlanID, ManufProcessID);
                }
             
                this.accManufPlans.UpdateManufPlansForBOMPlan  (ref errormsg,
                    ManufPlanID);
                index++;
            }
            FrmMsg.Hide();
            MessageBox.Show("成功生成当前物料计划");
            if (this.affterSave != null) this.affterSave();
            this.Close();
            
        }

        public void SaveBOMPlan(long ManufPlanID, long ManufProcessID)
        {

            string errormsg = string.Empty; 
            decimal AssemblyQty = 1, LossRate = 0, RequireQty = 0, OutSrcStoreQty = 0, StoreQty = 0, RoadStoreQty = 0, PlanQty = 0;
            int PrdID, SourceTypeID;
            this.ManufPlanEntity.LoadData(ManufPlanID);
            this.ManufProcessEntity.LoadData(ManufProcessID);
            int OutSrcCompanyID = this.ManufProcessEntity.OutSrcCompanyID;
            int CustomerID = this.ManufPlanEntity.CompanyID;
            decimal ManufQty = this.ManufPlanEntity.Quantity;
            DataTable dtblBOM = this.accBOM.GetDataBOMForManufRequire(ManufProcessID).Tables[0];
            foreach (DataRow drowBom in dtblBOM.Rows)
            {
                PrdID = (int)drowBom["PrdID"];
                SourceTypeID = (int)drowBom["SourceTypeID"];
                LossRate = 0;
                if (drowBom["LossRate"] != DBNull.Value)
                {
                    LossRate = (decimal)drowBom["LossRate"];
                }
                AssemblyQty = 1;
                if (drowBom["AssemblyQty"] != DBNull.Value)
                {
                    AssemblyQty = (decimal)drowBom["AssemblyQty"];
                }
                RequireQty = Convert.ToInt32(ManufQty * AssemblyQty * (1 + LossRate));
                if (OutSrcCompanyID > -1)
                {
                    OutSrcStoreQty = this.BOMPlanHelper.GetOutSrcAvailabelQty(OutSrcCompanyID, PrdID);
                }
                StoreQty = this.BOMPlanHelper.GetStoreAvailableQty(PrdID);
                RoadStoreQty = this.BOMPlanHelper.GetRoadAvailableQty(PrdID);
                if ((SourceTypeID == 3) && (CustomerID > -1))
                {
                    StoreQty = this.BOMPlanHelper.GetOEMStoreAvailableQty(CustomerID, PrdID);
                    RoadStoreQty = this.BOMPlanHelper.GetOEMRoadAvailableQty(CustomerID, PrdID);
                }
                PlanQty = RequireQty - OutSrcStoreQty - StoreQty - RoadStoreQty;
                if (PlanQty < 0)
                {
                    PlanQty = 0;
                }
                SourceTypeID = (int)drowBom["SourceTypeID"];
                if (SourceTypeID > 3) continue;  //1:生产;2,采购;3,客供,4,供应商自备
                PrdID = (int)drowBom["PrdID"]; 
                LossRate = 0;
                if (drowBom["LossRate"] != DBNull.Value)
                {
                    LossRate = (decimal)drowBom["LossRate"];
                }
                RequireQty = Convert.ToInt32(ManufQty * AssemblyQty * (1 + LossRate));
                //委外处理
                if (OutSrcCompanyID > -1)
                {
                    this.BOMPlanHelper.BOMOutSrcHandle(OutSrcCompanyID, PrdID, ref RequireQty);
                }
                if (RequireQty > 0)
                {
                    if ((SourceTypeID < 3) || (CustomerID < 0))
                    {
                        this.BOMPlanHelper.BOMHandle(CustomerID, PrdID, RequireQty, SourceTypeID );
                    }
                    if ((SourceTypeID == 3) && (CustomerID > -1))
                    {
                        this.BOMPlanHelper.BOMOEMHandle(CustomerID, PrdID, RequireQty);
                    }
                }
                //保存物料
                this.accBOMPlans.InsertBOMPlans(ref errormsg,
                    ManufPlanID,
                    ManufProcessID,
                    PrdID,
                    AssemblyQty,
                    LossRate,
                    SourceTypeID,
                    RequireQty,
                    StoreQty,
                    OutSrcStoreQty,
                    RoadStoreQty,
                    PlanQty);

                }
            } 
    }
}