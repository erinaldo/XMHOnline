using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Common
{
    public partial class FrmWorkingReportConfirm : Form
    {
        public FrmWorkingReportConfirm()
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
        private FrmWorkingReportConfirmOper  frmOper;
        private Report.Bill.FrmWorkingReport frmReport;
        //È¨ÏÞÂë
        private bool enableBrowse = false;//ä¯ÀÀ
        private bool enableSave = false;//±£´æ
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(302);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(303);
            if (this.enableBrowse)
            {
                this.dgrdv.ContextMenuStrip = this.cMenu;
                this.dgrdvConfirm.ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                this.ctrlBetweenDate.DateBegin = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                this.ctrlBetweenDate.DateEnd = this.ctrlBetweenDate.DateBegin.AddMonths(1).AddDays(-1);
                this.whereclause = " and (ConfirmPsnID is not null)";
                this.LoadData();
                this.pbar.OnPageIndexChanged += new EventHandler(pbar_OnPageIndexChanged);
                this.btnSearch.Click += new EventHandler(btnSearch_Click);
            }
            this.ColumnbtnConfirm .Visible  = this.enableSave;
            this.ColumnbtnDetail.Visible = this.enableSave;
          
            if (this.enableSave)
            {
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
                this.dgrdvConfirm.CellContentClick += new DataGridViewCellEventHandler(dgrdvConfirm_CellContentClick);
             
            }
        }

        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.whereclause = "  and (ConfirmPsnID  is not null)";
            this.LoadData();
        }

    

        void btnSearch_Click(object sender, EventArgs e)
        {
            this.whereclause = "  and (ConfirmPsnID  is not null)";
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
            if (this.dgrdv .Columns[icol].Name == this.ColumnbtnConfirm .Name)
            {
                long ReportID = (long)this.dtblReports  .DefaultView[irow]["ReportID"];
                if (frmOper  == null)
                {
                    frmOper = new FrmWorkingReportConfirmOper();
                    new FrmStyle(frmOper).SetPopFrmStyle(this);
                    frmOper.AffterSave+=this.frmOper_AffterSave;
                }
                frmOper.Confirm(ReportID);
                frmOper.ShowDialog();
            }
        }

        void frmOper_AffterSave()
        {
            this.whereclause = " and (ConfirmPsnID is not null)";
            this.LoadData();
        }
        private void LoadData()
        {
            this.dtblReports = this.accReports.GetDataWorkingReportsNonConfirm ().Tables[0];
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