using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Supply.MaterialOEM
{
    public partial class CtrlOEMPlanOper : UserControl 
    {
        public CtrlOEMPlanOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accOEMPlans = new JERPData.Material.OEMPlans();
            this.dgrdv.ContextMenuStrip = this.cMenu;
            this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
        }
        private JERPData.Material.OEMPlans accOEMPlans;
        private DataTable dtblPlans;
        private int CompanyID = -1;
        public void OEMPlanOper(int CompanyID)
        {
            this.CompanyID = CompanyID;
            this.LoadData();
        } 
        void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult rut = MessageBox.Show("即将调整物料下单欠数，系统不建议经常这么做!", "调整确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (rut == DialogResult.Cancel) return;
            string errormsg=string.Empty ;
            foreach (DataRow drow in this.dtblPlans.Rows)
            {
                if (drow.RowState == DataRowState.Unchanged) continue;
                if (drow["AdjustQty"] == DBNull.Value) continue;
                this.accOEMPlans.UpdateOEMPlansForAdjust (ref errormsg,
                    this .CompanyID ,
                    drow["PrdID"],
                    drow["AdjustQty"]);
                drow.AcceptChanges();
            }
            MessageBox.Show("成功进行欠数调整");
        }

        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
        private void LoadData()
        {
            this.dtblPlans = this.accOEMPlans.GetDataOEMPlansByCompanyID (this.CompanyID).Tables[0];
            this.dtblPlans.Columns.Add("AdjustQty", typeof(decimal));
            this.dgrdv.DataSource = this.dtblPlans;
        }
    }
}