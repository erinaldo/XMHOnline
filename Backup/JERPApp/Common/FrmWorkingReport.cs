using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Common
{
    public partial class FrmWorkingReport : Form
    {
        public FrmWorkingReport()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.dgrdvConfirm.AutoGenerateColumns = false;
            this.accReports = new JERPData.General.WorkingReports();
            this.SetPermit();
        }
        private JERPData.General.WorkingReports accReports;
        private DataTable dtblReports,dtblConfirms;
        private string whereclause = string.Empty;
        private FrmWorkingReportOper frmOper;
        private Report.Bill.FrmWorkingReport frmReport;
        //È¨ÏÞÂë
        private bool enableBrowse = false;//ä¯ÀÀ
        private bool enableSave = false;//±£´æ
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(151);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(152);
            if (this.enableBrowse)
            {
                this.dgrdv.ContextMenuStrip = this.cMenu;
                this.dgrdvConfirm.ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                this.ctrlBetweenDate.DateBegin = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                this.ctrlBetweenDate.DateEnd = this.ctrlBetweenDate.DateBegin.AddMonths(1).AddDays(-1);
                this.whereclause = " and (PsnID=" + JERPBiz.Frame.UserBiz.PsnID.ToString() + ") and (ConfirmPsnID is not null)";
                this.LoadData();
                this.pbar.OnPageIndexChanged += new EventHandler(pbar_OnPageIndexChanged);
                this.btnSearch.Click += new EventHandler(btnSearch_Click);
            }
            this.ColumnbtnEdit.Visible  = this.enableSave;
            this.ColumnbtnDetail.Visible = this.enableSave;
            this.lnkNew.Enabled = this.enableSave;
            if (this.enableSave)
            {
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
                this.dgrdvConfirm.CellContentClick += new DataGridViewCellEventHandler(dgrdvConfirm_CellContentClick);
                this.lnkNew.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkNew_LinkClicked);
            }
        }

        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.whereclause = " and (PsnID=" + JERPBiz.Frame.UserBiz.PsnID.ToString() + ") and (ConfirmPsnID  is not null)";
            this.LoadData();
        }


        void btnSearch_Click(object sender, EventArgs e)
        {
            this.whereclause = " and (PsnID=" + JERPBiz.Frame.UserBiz.PsnID.ToString() + ") and (ConfirmPsnID  is not null)";
            if (this.ckbReportTitleFlag.Checked)
            {
                this.whereclause += " and (ReportTitle like '%" + this.txtReportTitle.Text + "%')";
            }
            if (this.ckbDateReportFlag.Checked)
            {
                this.whereclause += " and (DateReport>='" + this.ctrlBetweenDate.DateBegin.ToShortDateString() + "' and DateReport<='" + this.ctrlBetweenDate.DateEnd.ToShortDateString() + "')";
            }
            int cnt = 0;
            this.dtblConfirms = this.accReports.GetDataWorkingReportsDescPagesFreeSearch(1, this.pbar.PageSize,
                ref cnt, this.whereclause).Tables[0];
            this.dgrdvConfirm.DataSource = this.dtblConfirms;
            this.pbar.Init(1, cnt);
        }

        void lnkNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (frmOper == null)
            {
                frmOper = new FrmWorkingReportOper();
                new FrmStyle(frmOper).SetPopFrmStyle(this);
                frmOper.AffterSave += new FrmWorkingReportOper.AffterSaveDelegate(frmOper_AffterSave);
            }
            frmOper.New();
            frmOper.ShowDialog();
        }
        void dgrdvConfirm_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvConfirm.Columns[icol].Name == this.ColumnbtnDetail.Name)
            {
                long ReportID =(long)this.dtblConfirms.DefaultView[irow]["ReportID"];
                if (frmReport == null)
                {
                    frmReport = new JERPApp.Common.Report.Bill.FrmWorkingReport();
                    new FrmStyle(frmReport).SetPopFrmStyle(this);                   
                }
                frmReport.Detail(ReportID);
                frmReport.ShowDialog();
            }
        }


        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv .Columns[icol].Name == this.ColumnbtnEdit .Name)
            {
                long ReportID = (long)this.dtblReports  .DefaultView[irow]["ReportID"];
                if (frmOper  == null)
                {
                    frmOper = new FrmWorkingReportOper();
                    new FrmStyle(frmOper).SetPopFrmStyle(this);
                    frmOper.AffterSave += new FrmWorkingReportOper.AffterSaveDelegate(frmOper_AffterSave);
                }
                frmOper.Edit (ReportID);
                frmOper.ShowDialog();
            }
        }

        void frmOper_AffterSave()
        {
            this.whereclause = " and (PsnID=" + JERPBiz.Frame.UserBiz.PsnID.ToString() + ") and (ConfirmPsnID is not null)";
            this.LoadData();
        }
        private void LoadData()
        {
            this.dtblReports = this.accReports.GetDataWorkingReportsNonConfirmByPsnID(JERPBiz.Frame.UserBiz.PsnID).Tables[0];
            this.dgrdv.DataSource = this.dtblReports;

            int cnt = 0;
            this.dtblConfirms = this.accReports.GetDataWorkingReportsDescPagesFreeSearch(1, this.pbar.PageSize,
                ref cnt, this.whereclause).Tables[0];
            this.dgrdvConfirm.DataSource = this.dtblConfirms;
            this.pbar.Init(1, cnt);

        }
        void pbar_OnPageIndexChanged(object sender, EventArgs e)
        {
            int cnt = 0;
            this.dtblConfirms = this.accReports.GetDataWorkingReportsDescPagesFreeSearch(this.pbar .PageIndex , this.pbar.PageSize,
                ref cnt, this.whereclause).Tables[0];
            this.dgrdvConfirm.DataSource = this.dtblConfirms;
        }

    }
}