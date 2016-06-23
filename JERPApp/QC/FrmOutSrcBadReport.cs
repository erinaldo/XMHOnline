using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.QC
{
    public partial class FrmOutSrcBadReport : Form
    {
        public FrmOutSrcBadReport()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accNotes = new JERPData.Manufacture.OutSrcBadReportNotes();
            this.SetPermit();
        }
        private JERPData.Manufacture.OutSrcBadReportNotes accNotes;
        private DataTable dtblNotes;
        private string whereclause = string.Empty;
        private FrmOutSrcBadReportOper frmOper;
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(221);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(222);
            if (this.enableBrowse)
            {
                //加载数据
                LoadData();
                this.ctrlNoteSearch.AffterSearch += new JCommon.ctrlNoteSearch.AffterSearchDelegate(ctrlNoteSearch_AffterSearch);
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
                this.pbar.OnPageIndexChanged += new EventHandler(pbar_OnPageIndexChanged);
            }
            this.lnkNew.Enabled = this.enableSave;
            if (this.enableSave)
            {
                this.lnkNew.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkNew_LinkClicked);
            }

        }
        private void LoadData()
        {
            int cnt = 0;
            this.dtblNotes = this.accNotes.GetDataOutSrcBadReportNotesDescPagesFreeSearch(1, this.pbar.PageSize,
                ref cnt, this.whereclause).Tables[0];
            this.dgrdv.DataSource = this.dtblNotes;
            this.pbar.Init(1, cnt);
        }
        void pbar_OnPageIndexChanged(object sender, EventArgs e)
        {
            int cnt = 0;
            this.dtblNotes = this.accNotes.GetDataOutSrcBadReportNotesDescPagesFreeSearch(this.pbar .PageIndex, this.pbar.PageSize,
                ref cnt, this.whereclause).Tables[0];
            this.dgrdv.DataSource = this.dtblNotes;
        }

        void ctrlNoteSearch_AffterSearch(string whereclause)
        {
            this.whereclause = whereclause;
            this.LoadData();
        }

        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnbtnEdit.Name)
            {
                long NoteID = (long)this.dtblNotes.DefaultView[irow]["NoteID"];
                if (frmOper == null)
                {
                    frmOper = new FrmOutSrcBadReportOper();
                    new FrmStyle(frmOper).SetPopFrmStyle(this);
                    frmOper.AffterSave += this.LoadData;
                }
                frmOper.Edit (NoteID);
                frmOper.ShowDialog();
            }
        }

        void lnkNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (frmOper == null)
            {
                frmOper = new FrmOutSrcBadReportOper();
                new FrmStyle(frmOper).SetPopFrmStyle(this);
                frmOper.AffterSave += this.LoadData;
            }
            frmOper.New();
            frmOper.ShowDialog();
        }
        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }

    }
}