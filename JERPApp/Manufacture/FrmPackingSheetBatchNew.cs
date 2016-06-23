using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture
{
    public partial class FrmPackingSheetBatchNew : Form
    {
        public FrmPackingSheetBatchNew()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlCkbAll.SeachGridView = this.dgrdv;
            this.ctrlQFind.SeachGridView = this.dgrdv; 
            this.accWorkingSheets = new JERPData.Packing .WorkingSheets();
            this.accPackingPlans = new JERPData.Packing .PackingPlans(); 
            this.accBOMPlans = new JERPData.Packing .BOMPlans(); 
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
         
        JERPData.Packing .WorkingSheets accWorkingSheets;
        JERPData.Packing .PackingPlans accPackingPlans;  
        private JERPData.Packing .BOMPlans accBOMPlans;  
        private FrmAvailablePackingQty frmAvailablePackingQty;
        private JERPBiz.Material.Store storeBiz;  
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

        private void SetPackingAvailabeQty(DataRow drow)
        {
            decimal AvailableManufQty = 0; 
           this.accBOMPlans.GetParmBOMPlanAvailablePackingQty(
                     (long)drow["ManufPlanID"], ref AvailableManufQty);
           drow["AvailablePackingQty"] = AvailableManufQty;
        }
        public void LoadData()
        {
            this.dtblPackingPlans = this.accPackingPlans .GetDataPackingPlansNonFinished  ().Tables[0];
            this.dtblPackingPlans.Columns.Add("CheckedFlag", typeof(bool));
            this.dtblPackingPlans.Columns.Add("AvailablePackingQty", typeof(decimal));
            foreach (DataRow drow in this.dtblPackingPlans.Rows)
            { 
                this.SetPackingAvailabeQty(drow);
            }
            this.dgrdv.DataSource = this.dtblPackingPlans;
        }
 
  
   
        void btnSave_Click(object sender, EventArgs e)
        {
            if(this.dtblPackingPlans .Select ("CheckedFlag=1").Length ==0)
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
            foreach (DataRow drowManufPlan in this.dtblPackingPlans.Rows)
            {
                if (drowManufPlan["CheckedFlag"] == DBNull.Value) continue;
                if ((bool)drowManufPlan["CheckedFlag"] == false) continue;              
                flag = this.accWorkingSheets.InsertWorkingSheets (ref errormsg,
                    ref objWorkingSheetID,
                    ref objWorkingSheetCode ,
                    DateTime.Now .Date ,
                    drowManufPlan["PackingPlanID"],
                    drowManufPlan["PrdID"],
                    drowManufPlan["PackingTypeID"],
                    drowManufPlan["CompanyID"],
                    drowManufPlan["NonFinishedQty"],
                    drowManufPlan["DateTarget"],
                    drowManufPlan["Memo"],
                    JERPBiz.Frame .UserBiz .PsnID );
                if (flag)
                {
                    this.accPackingPlans.UpdatePackingPlansForFinishedQty (ref errormsg, drowManufPlan["PackingPlanID"]); 
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
            if (this.dgrdv.Columns[icol].Name == this.ColumnAvailablePackingQty  .Name)
            {

                long PackingPlanID = (long)this.dtblPackingPlans.DefaultView[irow]["PackingPlanID"]; 
                if (frmAvailablePackingQty == null)
                {
                    frmAvailablePackingQty = new FrmAvailablePackingQty();
                    new FrmStyle(frmAvailablePackingQty).SetPopFrmStyle(this);
                }
                frmAvailablePackingQty.AvailablePackingQty(PackingPlanID);
                frmAvailablePackingQty.ShowDialog();
                
            }
           
        } 
     

       
  
     
    }
}