using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Supply.MaterialOEM
{
    public partial class FrmOrderItemFromPlan : Form
    {
        public FrmOrderItemFromPlan()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false; 
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.ctrlQFind.BeforeFilter += this.LoadData;
            this.dtpDateTarget.Value = DateTime.Now.AddDays(10).Date ;
            this.ctrlAllChecked.SeachGridView = this.dgrdv;
            this.accOEMPlans = new JERPData.Material.OEMPlans();
            this.btnSave.Click += new EventHandler(btnSave_Click);            
        }

     
        private JERPData.Material.OEMPlans accOEMPlans;
        private DataTable dtblInitPlans,dtblPlans;
        public void OrderFromPlan(int CompanyID,DataRow[] drowItems)
        {
            this.dtblInitPlans = this.accOEMPlans.GetDataOEMPlansForOrder(CompanyID).Tables[0];
            this.dtblInitPlans.Columns.Add("CheckedFlag", typeof(bool));
            this.dtblInitPlans.Columns.Add("DateTarget", typeof(decimal));
            foreach (DataRow drowItem in drowItems)
            {
                DataRow[] drowPlans = this.dtblInitPlans.Select("PrdID=" + drowItem["PrdID"].ToString()
                   ,"",DataViewRowState.CurrentRows);
                if (drowPlans.Length > 0)
                {
                    drowPlans[0].Delete();
                }
            }
            this.LoadData();
        }
        private void LoadData()
        {
            this.dtblPlans = this.dtblInitPlans.Copy();
            this.dgrdv.DataSource = this.dtblPlans;
        }
        public delegate void AffterSaveDelegate(DataRow drowPlan);
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
        private bool ValidateData()
        {
            if (this.dtblPlans .Select("CheckedFlag=1").Length == 0)
            {
                MessageBox.Show("对不起,没有任何明细项");
                return false;
            }          
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateData() == false) return;      
            foreach (DataRow drow in this.dtblPlans.Rows )
            {
                if (drow.RowState == DataRowState.Unchanged) continue;
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow["CheckedFlag"] != DBNull.Value)
                {
                    if ((bool)drow["CheckedFlag"])
                    {
                        drow["DateTarget"] = this.dtpDateTarget.Value.Date;
                        if (this.affterSave != null) this.affterSave(drow);
                    }
                }
            }
            this.ctrlAllChecked.CheckedFlag = false;
            MessageBox.Show("成功将当前计划加入订单!");
            this.Close();
        }
    }
}