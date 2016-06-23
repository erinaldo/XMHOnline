using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Common
{
    public partial class FrmWorkingReportOper : Form
    {
        public FrmWorkingReportOper()
        {
            InitializeComponent();
            this.accReports = new JERPData.General.WorkingReports();
            this.ReportEntity = new JERPBiz.General.WorkingReportEntity();
            this.btnDelete.Click += new EventHandler(btnDelete_Click);
            this.btnNew.Click += new EventHandler(btnNew_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
        }

        JERPData.General.WorkingReports accReports;
        JERPBiz.General.WorkingReportEntity ReportEntity;
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
                this.btnDelete.Enabled = (value > -1);

            }
        }
        public void New()
        {
            this.ReportID  = -1;
            this.dtpDateReport.Value = DateTime.Now.Date;
            this.txtReportTitle.Text = "每日汇报";
            this.rchReportContent.Text = string.Empty;
        }
        public void Edit(long ReportID)
        {
            this.ReportID = ReportID;
            this.ReportEntity.LoadData(ReportID);
            this.dtpDateReport.Value = this.ReportEntity.DateReport;
            this.txtReportTitle.Text = this.ReportEntity.ReportTitle;
            this.rchReportContent.Text = this.ReportEntity.ReportContent;

        }
        private bool ValidateData()
        {
            if (this.txtReportTitle.Text == string.Empty)
            {
                MessageBox.Show("对不起，标题不能为空");
                return false;
            }
            return true;
        }
        void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateData() == false) return;
            string errormsg = string.Empty;
            bool flag = false;
            if (this.ReportID == -1)
            {
                object objReportID = DBNull.Value;
                flag = this.accReports.InsertWorkingReports(ref errormsg,
                    ref objReportID,
                    this.dtpDateReport.Value.Date,
                    this.txtReportTitle.Text,
                    JERPBiz .Frame .UserBiz .PsnID ,
                    this.rchReportContent.Text);
                if (flag)
                {
                    this.ReportID = (long)objReportID;
                }
            }
            else
            {
                flag = this.accReports.UpdateWorkingReports(ref errormsg,
                    this.ReportID,
                    this.dtpDateReport.Value .Date ,
                    this.txtReportTitle.Text,
                    this.rchReportContent.Text);
            }
            if (flag)
            {
                MessageBox.Show("成功保存当前工作汇报");
                if (this.affterSave != null) this.affterSave();
            }
            else
            {
                MessageBox.Show(errormsg);
            }
        }

        void btnNew_Click(object sender, EventArgs e)
        {
            this.New();
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
            bool flag = false;
            string errormsg = string.Empty;
            DialogResult rul = MessageBox.Show("您将删除当前工作汇报，一经删除不能恢复！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return;
            flag = this.accReports.DeleteWorkingReports(ref errormsg, this.ReportID);
            if (flag)
            {
                MessageBox.Show("成功删除当前工作汇报");              
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