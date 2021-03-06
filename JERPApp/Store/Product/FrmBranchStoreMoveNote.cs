using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Product
{
    public partial class FrmBranchStoreMoveNote : Form
    {
        public FrmBranchStoreMoveNote()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accNotes = new JERPData.Product.BranchStoreMoveNotes();
            this.SetPermit();
        }
        private JERPData.Product.BranchStoreMoveNotes accNotes;
        private FrmBranchStoreMoveNoteOper frmOper;
        private string whereclause = string.Empty;
        private JERPApp.Store.Product.Report.Bill .FrmBranchStoreMoveNote frmDetail;
        private DataTable dtblNotes;
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(68);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(69);
            if (this.enableBrowse)
            {
                //加载数据
                LoadData();
                this.ctrlNoteSearch.AffterSearch += new JCommon.ctrlNoteSearch.AffterSearchDelegate(ctrlNoteSearch_AffterSearch);  
                this.pbar.OnPageIndexChanged += new EventHandler(pbar_OnPageIndexChanged);
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
            }
            this.lnkNew.Enabled = this.enableSave;          
            if (this.enableSave)
            {
                this.lnkNew.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkNew_LinkClicked);
                
            }

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
            if (this.dgrdv.Columns[icol].Name == this.ColumnbtnDetail .Name)
            {
                long NoteID =(long) this.dtblNotes.DefaultView[irow]["NoteID"];
                if (this.frmDetail  == null)
                {
                    this.frmDetail = new JERPApp.Store.Product.Report.Bill.FrmBranchStoreMoveNote();
                    new FrmStyle(frmDetail).SetPopFrmStyle(this);
                  
                }
                frmDetail.DetailNote(NoteID);
                frmDetail.ShowDialog();
            }
        }

        void lnkNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.frmOper == null)
            {
                this.frmOper = new FrmBranchStoreMoveNoteOper();
                new FrmStyle(frmOper).SetPopFrmStyle(this);
                frmOper.AffterSave += new FrmBranchStoreMoveNoteOper.AffterSaveDelegate(frmOper_AffterSave);
            }
            frmOper.NewNote();
            frmOper.ShowDialog();
        }

        void frmOper_AffterSave()
        {
            this.whereclause = string.Empty;
            this.LoadData();
        }
        private void LoadData()
        {
            int cnt = 0;
            this.dtblNotes = this.accNotes.GetDataBranchStoreMoveNotesDescPagesFreeSearch (1,this.pbar .PageSize ,ref cnt,this.whereclause ).Tables [0];
            this.dgrdv.DataSource = this.dtblNotes;
            this.pbar.Init(1, cnt);
        }

        void pbar_OnPageIndexChanged(object sender, EventArgs e)
        {
            int cnt = 0;
            this.dtblNotes = this.accNotes.GetDataBranchStoreMoveNotesDescPagesFreeSearch(this.pbar.PageIndex, this.pbar.PageSize, ref cnt, this.whereclause).Tables[0];
            this.dgrdv.DataSource = this.dtblNotes;
        }
    }
}