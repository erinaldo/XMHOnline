using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture
{
    public partial class CtrlPackingPlanAdjust : UserControl 
    {
        public CtrlPackingPlanAdjust()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accPackingPlans = new JERPData.Packing .PackingPlans ();
            this.dgrdv.ContextMenuStrip = this.cMenu;
            this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
            foreach (DataGridViewColumn col in this.dgrdv.Columns)
            {
                col.ReadOnly = true;
            } 
            this.ColumnNonFinishedQty.ReadOnly = false;
            this.btnSave.Click += new EventHandler(btnSave_Click);
        }
        private JERPData.Packing .PackingPlans  accPackingPlans;
        private DataTable dtblPackingPlans; 
        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
        public  void LoadData()
        {
            this.dtblPackingPlans = this.accPackingPlans.GetDataPackingPlansNonFinished ().Tables[0];
            this.dgrdv.DataSource = this.dtblPackingPlans;

        }
        void btnSave_Click(object sender, EventArgs e)
        {
            string errormsg = string.Empty;
            foreach (DataRow drow in this.dtblPackingPlans.Rows)
            {
                if (drow.RowState == DataRowState.Unchanged) continue;
                this.accPackingPlans.UpdatePackingPlansForAdjustNonFinishedQty(ref errormsg, drow["PackingPlanID"],
                    drow["NonFinishedQty"]);
                drow.AcceptChanges();
            }
            MessageBox.Show("成功保存当前设置");
        }

    }
}