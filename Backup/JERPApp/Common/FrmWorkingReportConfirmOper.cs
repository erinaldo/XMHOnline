using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Common
{
    public partial class FrmWorkingReportConfirmOper : Form
    {
        public FrmWorkingReportConfirmOper()
        {
            InitializeComponent();
            this.ReportEntity = new JERPBiz.General.WorkingReportEntity();
            this.accReports = new JERPData.General.WorkingReports();
            this.btnConfirm.Click += new EventHandler(btnConfirm_Click);
        }

     
        JERPBiz.General.WorkingReportEntity ReportEntity;
        JERPData.General.WorkingReports accReports;
        public void Confirm(long ReportID)
        {
            this.ReportID = ReportID;
            this.ReportEntity.LoadData(ReportID);
            this.txtDateReport .Text  = this.ReportEntity.DateReport.ToShortDateString ();
            this.txtPsnName.Text = this.ReportEntity.PsnName;
            this.txtReportTitle.Text = this.ReportEntity.ReportTitle;
            this.rchReportContent.Text = this.ReportEntity.ReportContent;
        }
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
        private long reportid = -1;
        private long ReportID
        {
            get
            {
                return this.reportid;
            }
            set
            {
                this.reportid = value;

            }
        }
        void btnConfirm_Click(object sender, EventArgs e)
        {
            bool flag = false;
            string errormsg = string.Empty;
            DialogResult rul = MessageBox.Show("您将进行审核，一经审核业务员将不能变更内容！", "审核确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return;
            flag = this.accReports.UpdateWorkingReportsForConfirm(ref errormsg,
                this.ReportID,
                JERPBiz.Frame.UserBiz.PsnID);
            if (flag)
            {
                MessageBox.Show("成功审核当前工作汇报");
            }
            else
            {
                MessageBox.Show(errormsg);
            }
            if (this.affterSave != null) this.affterSave();
            this.Close();
        }
    }
}