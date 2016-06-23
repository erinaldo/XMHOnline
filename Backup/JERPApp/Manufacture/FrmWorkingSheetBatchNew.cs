using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture
{
    public partial class FrmWorkingSheetBatchNew : Form
    {
        public FrmWorkingSheetBatchNew()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlCkbAll.SeachGridView = this.dgrdv;
            this.ctrlQFind.SeachGridView = this.dgrdv; 
            this.accWorkingSheets = new JERPData.Manufacture.WorkingSheets();
            this.accManufPlans = new JERPData.Manufacture.ManufPlans();
            this.accManufSchedules = new JERPData.Manufacture.ManufSchedules();  
            this.accManufProcess = new JERPData.Manufacture.ManufProcess();  
            this.outSrcStoreBiz = new JERPBiz.Material.OutSrcStore();
            this.accBOMPlans = new JERPData.Manufacture.BOMPlans();
            this.storeBiz = new JERPBiz.Material.Store();
            this.btnSave.Click += new EventHandler(btnSave_Click);  
            this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
            foreach (DataGridViewColumn col in this.dgrdv.Columns)
            {
                col.ReadOnly = true;
            }
            this.ColumnCheckedFlag.ReadOnly = false;
            this.ColumnNonFinishedQty .ReadOnly = false;
        
        }
         
        JERPData.Manufacture.WorkingSheets accWorkingSheets;
        JERPData.Manufacture.ManufPlans accManufPlans;
        JERPData.Manufacture.ManufSchedules accManufSchedules;
        JERPData.Manufacture.ManufProcess accManufProcess;
        private JERPData.Manufacture.BOMPlans accBOMPlans;
        private FrmAvailableManufQty frmAvailableManufQty;
        private JERPBiz.Material.Store storeBiz;
        private JERPBiz.Material.OutSrcStore outSrcStoreBiz; 
     
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

        private void SetManufAvailabeQty(DataRow drow)
        {
            decimal AvailableManufQty = 0; 
            this.accBOMPlans.GetParmBOMPlanAvailableManufQty((long)drow["ManufPlanID"],
                     ref AvailableManufQty); 
            drow["AvailableManufQty"] = AvailableManufQty;
        }
        public void LoadData()
        {
            this.dtblManufPlans = this.accManufPlans .GetDataManufPlansNonFinished ().Tables[0];
            this.dtblManufPlans.Columns.Add("CheckedFlag", typeof(bool));
            this.dtblManufPlans.Columns.Add("AvailableManufQty", typeof(decimal));
            foreach (DataRow drow in this.dtblManufPlans.Rows)
            { 
                this.SetManufAvailabeQty(drow);
            }
            this.dgrdv.DataSource = this.dtblManufPlans;
        }
 
  
        private void SaveManufSchedule(long WorkingSheetID,DataRow drowManufPlan)
        {
            DataTable dtblManufProcess = this.accManufProcess.GetDataManufProcessByPrdID((int)drowManufPlan["PrdID"]).Tables[0];
            object objManufScheduleID = DBNull.Value;
            long ManufProcessID = -1;  
            decimal Quantity=(decimal)drowManufPlan ["NonFinishedQty"];
            string errormsg = string.Empty;
            foreach (DataRow drow in dtblManufProcess.Rows)
            { 
                ManufProcessID = (long)drow["ManufProcessID"];
                objManufScheduleID = DBNull.Value;
              
                this.accManufSchedules.InsertManufSchedules(ref errormsg,
                    ref objManufScheduleID,
                    WorkingSheetID,
                    ManufProcessID,
                    drow["Memo"],
                    drow["OutSrcFlag"],
                    drow["OutSrcCompanyID"],
                    Quantity, 
                   DBNull .Value ); 
              
            }
        }
        void btnSave_Click(object sender, EventArgs e)
        {
            if(this.dtblManufPlans .Select ("CheckedFlag=1").Length ==0)
            {
                MessageBox .Show ("未选择任何生产批次");
                return;
            }
            DialogResult rul = MessageBox.Show("请仔细检查您的设定,数量一经生成不能变更,但可以取消此制令！", "操作确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return;
            string errormsg = string.Empty;
            bool flag = false;
            FrmMsg.Show("制令正在保存中，请稍候...");
            object objWorkingSheetID = DBNull.Value;
            object objWorkingSheetCode = DBNull.Value;
            foreach (DataRow drowManufPlan in this.dtblManufPlans.Rows)
            {
                if (drowManufPlan["CheckedFlag"] == DBNull.Value) continue;
                if ((bool)drowManufPlan["CheckedFlag"] == false) continue;              
                flag = this.accWorkingSheets.InsertWorkingSheets (ref errormsg,
                    ref objWorkingSheetID,
                    ref objWorkingSheetCode ,
                    DateTime.Now .Date ,
                    drowManufPlan["ManufPlanID"],
                    drowManufPlan["PrdID"],
                    drowManufPlan["CompanyID"],
                    drowManufPlan["NonFinishedQty"],
                    drowManufPlan["PrdStoreFlag"],
                    drowManufPlan["MtrStoreFlag"],
                    drowManufPlan["DateTarget"],
                    drowManufPlan["Memo"],
                    JERPBiz.Frame .UserBiz .PsnID );
                if (flag)
                {
                    this.accManufPlans.UpdateManufPlansForFinishedQty(ref errormsg, drowManufPlan["ManufPlanID"]); 
                    this.SaveManufSchedule((long)objWorkingSheetID, drowManufPlan); 
                }
            }
            FrmMsg.Hide();
            MessageBox.Show("成功保存当前生产制令");         
            if (this.affterSave != null) this.affterSave();
            this.Close();
            

        }
     
        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return; 
            if (this.dgrdv.Columns[icol].Name == this.ColumnAvailableManufQty  .Name)
            {

                long ManufPlanID = (long)this.dtblManufPlans.DefaultView[irow]["ManufPlanID"]; 
                if (frmAvailableManufQty == null)
                {
                    frmAvailableManufQty = new FrmAvailableManufQty();
                    new FrmStyle(frmAvailableManufQty).SetPopFrmStyle(this);
                }
                frmAvailableManufQty.AvailableManufQty(ManufPlanID);
                frmAvailableManufQty.ShowDialog();
                  
                
            }
           
        } 
     

       
  
     
    }
}