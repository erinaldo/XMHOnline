using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Supply.Material
{
    public partial class FrmBuyPlan : Form
    {
        public FrmBuyPlan()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accBuyPlans = new JERPData.Material.BuyPlans();
            this.SetPermit();
        }
        private JERPData.Material.BuyPlans accBuyPlans;
        private DataTable dtblPlans;
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(475);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(476);
            if (this.enableBrowse)
            {

                this.LoadData();
                this.dgrdv.ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
              
            }
            this.btnSave.Enabled  = this.enableSave;
            if (this.enableSave)
            {
                this.btnSave.Click += new EventHandler(btnSave_Click);
            }
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
                this.accBuyPlans.UpdateBuyPlansForAdjust(ref errormsg,
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
            this.dtblPlans = this.accBuyPlans.GetDataBuyPlans().Tables[0];
            this.dtblPlans.Columns.Add("AdjustQty", typeof(decimal));
            this.dgrdv.DataSource = this.dtblPlans;
        }
    }
}