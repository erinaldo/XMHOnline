using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Supply.OtherRes
{
    public partial class FrmOrderItemFromPlan : Form
    {
        public FrmOrderItemFromPlan()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.ctrlAllChecked.SeachGridView = this.dgrdv;
            this.accBuyPlans = new JERPData.OtherRes.BuyPlans();
            this.ctrlQFind.BeforeFilter += this.LoadData; 
            this.btnSave.Click += new EventHandler(btnSave_Click);            
        }

     
        private JERPData.OtherRes.BuyPlans accBuyPlans;
        private DataTable dtblInitPlans,dtblPlans;
        public void BuyOrderFromPlan(DataRow[] drowItems)
        {
            this.dtblInitPlans = this.accBuyPlans.GetDataBuyPlans ().Tables[0];
            this.dtblInitPlans.Columns.Add("CheckedFlag", typeof(bool)); 
            foreach (DataRow drowItem in drowItems)
            {
                DataRow[] drowInitPlans = this.dtblInitPlans.Select("PrdID=" + drowItem["PrdID"].ToString(), "", DataViewRowState.CurrentRows);
                if (drowInitPlans.Length > 0)
                {
                    drowInitPlans[0].Delete();
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