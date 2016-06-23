using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture
{
    public partial class CtrlManufPlanAdjust : UserControl 
    {
        public CtrlManufPlanAdjust()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accManufPlans = new JERPData.Manufacture.ManufPlans ();
            this.dgrdv.ContextMenuStrip = this.cMenu;
            this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
            foreach (DataGridViewColumn col in this.dgrdv.Columns)
            {
                col.ReadOnly = true;
            } 
            this.ColumnNonFinishedQty.ReadOnly = false;
            this.btnSave.Click += new EventHandler(btnSave_Click);
        }
        private JERPData.Manufacture.ManufPlans  accManufPlans;
        private DataTable dtblManufPlans; 
        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
        public  void LoadData()
        {
            this.dtblManufPlans = this.accManufPlans.GetDataManufPlansNonFinished().Tables[0];
            this.dgrdv.DataSource = this.dtblManufPlans;

        }
        void btnSave_Click(object sender, EventArgs e)
        {
            string errormsg = string.Empty;
            foreach (DataRow drow in this.dtblManufPlans.Rows)
            {
                if (drow.RowState == DataRowState.Unchanged) continue;
                this.accManufPlans.UpdateManufPlansForAdjustNonFinishedQty(ref errormsg, drow["ManufPlanID"],
                    drow["NonFinishedQty"]);
                drow.AcceptChanges();
            }
            MessageBox.Show("成功保存当前设置");
        }

    }
}