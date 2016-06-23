using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Supply.OutSrc
{
    public partial class FrmManufScheduleAdjust : Form
    {
        public FrmManufScheduleAdjust()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accManufSchedules = new JERPData.Manufacture.ManufSchedules();
            this.SetPermit();
        }
        private JERPData.Manufacture.ManufSchedules accManufSchedules;
        private DataTable dtblManufSchedules;
        private string whereclause = string.Empty;
        private string initwhereclause = " and (OutSrcFlag=1)";
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(521);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(522);
            if (this.enableBrowse)
            {
                this.whereclause = this.initwhereclause;
                this.LoadData();
                this.btnSearch.Click += new EventHandler(btnSearch_Click);
                this.pbar.OnPageIndexChanged += new EventHandler(pbar_OnPageIndexChanged);
                foreach (DataGridViewColumn col in this.dgrdv.Columns)
                {
                    col.ReadOnly = true;
                }
                this.ColumnOutSrcOrderNonFinishedQty.ReadOnly = false;
            } 
            if (this.enableSave)
            {
                this.btnSave.Click += new EventHandler(btnSave_Click);
            }
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult rul = MessageBox.Show("即将变更余数，请确认！", "操作确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            string errormsg=string.Empty ;
            foreach (DataRow drow in this.dtblManufSchedules.Rows)
            {
                if (drow.RowState == DataRowState.Unchanged) continue;
                this.accManufSchedules.UpdateManufSchedulesAdjustOutSrcOrderNonFinishedQty(ref errormsg,
                    drow["ManufScheduleID"],
                    drow["OutSrcOrderNonFinishedQty"]);
                drow.AcceptChanges();
            }
            MessageBox.Show("成功保存当前变更");
        }

        void pbar_OnPageIndexChanged(object sender, EventArgs e)
        {
            int records = 0;
            this.dtblManufSchedules = this.accManufSchedules.GetDataManufSchedulesDescPagesFreeSearch(this.pbar .PageIndex , this.pbar.PageSize, ref records, this.whereclause).Tables[0];
            this.dgrdv.DataSource = this.dtblManufSchedules;
        }

        void btnSearch_Click(object sender, EventArgs e)
        {
            this.whereclause = this.initwhereclause;
            if (this.ckbWorkingSheetCode.Checked)
            {
                this.whereclause += " and (WorkingSheetCode like '%" + this.txtWorkingSheetCode.Text + "%'";
            }
            if (this.ckbSupplier.Checked)
            {
                this.whereclause += " and (OutSrcCompanyID=" + this.ctrlSupplierID.CompanyID.ToString() + ")";
            }
            this.LoadData();
        }
        private void LoadData()
        {
            int records=0;
            this.dtblManufSchedules = this.accManufSchedules.GetDataManufSchedulesDescPagesFreeSearch(1, this.pbar.PageSize, ref records, this.whereclause).Tables[0];
            this.dgrdv.DataSource = this.dtblManufSchedules;
            this.pbar.Init(1, records);
        }
    }
}