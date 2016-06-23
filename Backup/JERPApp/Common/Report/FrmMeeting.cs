using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Common.Report
{
    public partial class FrmMeeting : Form
    {
        public FrmMeeting()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accMeeting = new JERPData.General.Meeting();
            this.SetPermit();
        }
        private JERPData.General.Meeting accMeeting;
        private DataTable dtblMeeting;
        private string whereclause = string.Empty;
        private Bill.FrmMeeting frmDetail;
        //È¨ÏÞÂë
        private bool enableBrowse = false;//ä¯ÀÀ
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(582);
            if (this.enableBrowse)
            {
                this.dgrdv.ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                this.ctrlBetweenDate.DateBegin = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                this.ctrlBetweenDate.DateEnd = this.ctrlBetweenDate.DateBegin.AddMonths(1).AddDays(-1);
            
                this.LoadData();
                this.pbar.OnPageIndexChanged += new EventHandler(pbar_OnPageIndexChanged);
                this.btnSearch.Click += new EventHandler(btnSearch_Click);
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
            }
         
        }

        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.whereclause = string.Empty;
            this.LoadData();
        }

    

        void btnSearch_Click(object sender, EventArgs e)
        {
            this.whereclause = string.Empty;
            if (this.ckbMeetingTitleFlag.Checked)
            {
                this.whereclause += " and (MeetingTitle like '%" + this.txtReportTitle.Text + "%')";
            }
            if (this.ckbDateReportFlag.Checked)
            {
                this.whereclause += " and (DateMeeting>='" + this.ctrlBetweenDate.DateBegin.ToShortDateString() + "' and DateMeeting<='" + this.ctrlBetweenDate.DateEnd.ToShortDateString() + "')";
            }
            this.LoadData();
        }

     
        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv .Columns[icol].Name == this.ColumnbtnDetail  .Name)
            {
                long MeetingID = (long)this.dtblMeeting.DefaultView[irow]["MeetingID"];
                if (frmDetail   == null)
                {
                    frmDetail = new JERPApp.Common.Report.Bill.FrmMeeting();
                    new FrmStyle(frmDetail).SetPopFrmStyle(this);
                }
                frmDetail.Detail(MeetingID);
                frmDetail.ShowDialog();
            }
        }

   
        private void LoadData()
        {
            int cnt = 0;
            this.dtblMeeting  = this.accMeeting.GetDataMeetingDescPagesFreeSearch (1, this.pbar.PageSize,
                ref cnt, this.whereclause).Tables[0];
            this.dgrdv .DataSource = this.dtblMeeting;
            this.pbar.Init(1, cnt);

        }
        void pbar_OnPageIndexChanged(object sender, EventArgs e)
        {
            int cnt = 0;
            this.dtblMeeting = this.accMeeting.GetDataMeetingDescPagesFreeSearch(this.pbar.PageIndex, this.pbar.PageSize,
                ref cnt, this.whereclause).Tables[0];
            this.dgrdv .DataSource = this.dtblMeeting;
        }

    }
}