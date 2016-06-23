using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Common.Report
{
    public partial class FrmDiary : Form
    {
        public FrmDiary()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accDiary = new JERPData.General.Diary();
            this.SetPermit();
        }
        private JERPData.General.Diary accDiary;
        private DataTable dtblDiary;
        private string whereclause = string.Empty;
        private Bill.FrmDiary frmDetail;
        //È¨ÏÞÂë
        private bool enableBrowse = false;//ä¯ÀÀ
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(392);
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
            if (this.ckbDiaryTitleFlag.Checked)
            {
                this.whereclause += " and (DiaryTitle like '%" + this.txtDiaryTitle.Text + "%')";
            } 
            if (this.ckbDiaryTypeFlag.Checked)
            {
                this.whereclause += " and (DiaryTypeID=" + this.ctrlDiaryTypeID.DiaryTypeID + ")";
            }
            if (this.ckbDateReportFlag.Checked)
            {
                this.whereclause += " and (DateDiary>='" + this.ctrlBetweenDate.DateBegin.ToShortDateString() + "' and DateDiary<='" + this.ctrlBetweenDate.DateEnd.ToShortDateString() + "')";
            }
            if (this.ckbPsnFlag.Checked)
            {
                this.whereclause += " and (PsnID=" + this.ctrlPsnID.PsnID.ToString() + ")";
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
                long DiaryID = (long)this.dtblDiary.DefaultView[irow]["DiaryID"];
                if (frmDetail   == null)
                {
                    frmDetail = new JERPApp.Common.Report.Bill.FrmDiary();
                    new FrmStyle(frmDetail).SetPopFrmStyle(this);
                }
                frmDetail.Detail(DiaryID);
                frmDetail.ShowDialog();
            }
        }

   
        private void LoadData()
        {
            int cnt = 0;
            this.dtblDiary  = this.accDiary.GetDataDiaryDescPagesFreeSearch (1, this.pbar.PageSize,
                ref cnt, this.whereclause).Tables[0];
            this.dgrdv .DataSource = this.dtblDiary;
            this.pbar.Init(1, cnt);

        }
        void pbar_OnPageIndexChanged(object sender, EventArgs e)
        {
            int cnt = 0;
            this.dtblDiary = this.accDiary.GetDataDiaryDescPagesFreeSearch(this.pbar.PageIndex, this.pbar.PageSize,
                ref cnt, this.whereclause).Tables[0];
            this.dgrdv .DataSource = this.dtblDiary;
        }

    }
}