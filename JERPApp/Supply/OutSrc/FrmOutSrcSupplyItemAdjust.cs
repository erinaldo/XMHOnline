using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Supply.OutSrc
{
    public partial class FrmOutSrcSupplyItemAdjust : Form
    {
        public FrmOutSrcSupplyItemAdjust()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accOutSrcSupplyItems = new JERPData.Material.OutSrcSupplyItems ();
            this.SetPermit();
        }
        private JERPData.Material.OutSrcSupplyItems accOutSrcSupplyItems;
        private DataTable dtblPlans;
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(477);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(478);
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
            DialogResult rut = MessageBox.Show("即将调整物料委外欠料，系统不建议经常这么做!", "调整确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (rut == DialogResult.Cancel) return;
            string errormsg=string.Empty ;
            foreach (DataRow drow in this.dtblPlans.Rows)
            {
                if (drow.RowState == DataRowState.Unchanged) continue;
                if (drow["AdjustQty"] == DBNull.Value) continue;
                this.accOutSrcSupplyItems.UpdateOutSrcSupplyItemsForNonFinishedQty (ref errormsg,
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
            this.dtblPlans = this.accOutSrcSupplyItems.GetDataOutSrcSupplyItemsPrdLastItems ().Tables[0];
            this.dtblPlans.Columns.Add("AdjustQty", typeof(decimal));
            this.dgrdv.DataSource = this.dtblPlans;
        }
    }
}