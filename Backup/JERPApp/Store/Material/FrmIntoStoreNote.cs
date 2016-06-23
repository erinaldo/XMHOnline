using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Material
{
    public partial class FrmIntoStoreNote : Form
    {
        public FrmIntoStoreNote()
        {
            InitializeComponent();
            this.dgrdvNote.AutoGenerateColumns = false;
            this.dgrdvWorkingSheet.AutoGenerateColumns = false;
            this.ctrlCkbAll.SeachGridView = this.dgrdvWorkingSheet ;
            this.ctrlQWorkingSheet.SeachGridView = this.dgrdvWorkingSheet ;
            this.accNotes = new JERPData.Material.IntoStoreNotes();
            this.accWorkingSheets = new JERPData.Manufacture.WorkingSheets();
            this.SetPermit();
        }
        private JERPData.Material.IntoStoreNotes accNotes;
        private JERPData.Manufacture.WorkingSheets accWorkingSheets;
        private string whereclause = string.Empty;
        private FrmIntoStoreNoteOper frmOper;
        private FrmIntoStoreNoteFromPrdStore frmFromPrdStore;
        private FrmIntoStoreNoteFromOEMStore frmFromOEMStore;
        private JERPApp.Store.Material.Report.Bill.FrmIntoStoreNote frmDetail;
        private DataTable dtblWorkingSheets,dtblNotes;
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(298);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(299);
            if (this.enableBrowse)
            {
                //加载数据
                this.LoadWorkingSheet();
                this.LoadNoteData();
                this.dgrdvWorkingSheet.ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                this.ctrlNoteSearch.AffterSearch += new JCommon.ctrlNoteSearch.AffterSearchDelegate(ctrlNoteSearch_AffterSearch);
                this.pbar.OnPageIndexChanged += new EventHandler(pbar_OnPageIndexChanged);
                this.dgrdvNote.CellContentClick += new DataGridViewCellEventHandler(dgrdvNote_CellContentClick);
            }
            this.lnkAppend.Enabled = this.enableSave;
            this.btnBatchNew.Enabled = this.enableSave;
            this.lnkNewFromPrd.Enabled = this.enableSave;
            this.lnkFromOEM.Enabled = this.enableSave;
            if (this.enableSave)
            {
                this.lnkNewFromPrd.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkNewFromPrd_LinkClicked);
                this.lnkAppend.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkAppend_LinkClicked);
                this.btnBatchNew.Click += new EventHandler(btnBatchNew_Click);
                this.lnkFromOEM.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkFromOEM_LinkClicked);
                for (int j = 1; j < this.dgrdvWorkingSheet.ColumnCount; j++)
                {
                    this.dgrdvWorkingSheet.Columns[j].ReadOnly = true;
                }
            }

        }

      
        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadWorkingSheet();
        }
        void ctrlNoteSearch_AffterSearch(string whereclause)
        {
            this.whereclause = whereclause;
            this.LoadNoteData();
        }
        void pbar_OnPageIndexChanged(object sender, EventArgs e)
        {
            int cnt = 0;
            this.dtblNotes =this.accNotes.GetDataIntoStoreNotesDescPagesFreeSearch (this.pbar.PageIndex, this.pbar.PageSize, ref cnt,this.whereclause ).Tables [0];
            this.dgrdvNote.DataSource = this.dtblNotes;
        
        }
        void dgrdvNote_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvNote.Columns[icol].Name == this.ColumnbtnDetail.Name)
            {
                long NoteID =(long) this.dtblNotes.DefaultView[irow]["NoteID"];
                if (this.frmDetail  == null)
                {
                    this.frmDetail = new JERPApp.Store.Material.Report.Bill.FrmIntoStoreNote();
                    new FrmStyle(frmDetail).SetPopFrmStyle(this);
                 
                }
                frmDetail.DetailNote(NoteID);
                frmDetail.ShowDialog();
            }
        }

        void btnBatchNew_Click(object sender, EventArgs e)
        {
            DataRow[] drows = this.dtblWorkingSheets.Select("CheckedFlag=1");
            if (this.frmOper == null)
            {
                this.frmOper = new FrmIntoStoreNoteOper();
                new FrmStyle(frmOper).SetPopFrmStyle(this);
                frmOper.AffterSave += new FrmIntoStoreNoteOper.AffterSaveDelegate(frmOper_AffterSave);
            }
            frmOper.NewNote(drows );
            frmOper.ShowDialog();
        }
        void lnkAppend_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.frmOper == null)
            {
                this.frmOper = new FrmIntoStoreNoteOper();
                new FrmStyle(frmOper).SetPopFrmStyle(this);
                frmOper.AffterSave+=new FrmIntoStoreNoteOper.AffterSaveDelegate(frmOper_AffterSave);
            }
            frmOper.NewNote();
            frmOper.ShowDialog();
        }
        void frmOper_AffterSave()
        {
            this.whereclause = string.Empty;
            this.LoadWorkingSheet();
            this.LoadNoteData();
        }

        void lnkNewFromPrd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (frmFromPrdStore == null)
            {
                frmFromPrdStore = new FrmIntoStoreNoteFromPrdStore();
                new FrmStyle(frmFromPrdStore).SetPopFrmStyle(this);
                frmFromPrdStore.AffterSave += new FrmIntoStoreNoteFromPrdStore.AffterSaveDelegate(frmFromPrdStore_AffterSave);
            }            
            frmFromPrdStore.NewNote();
            frmFromPrdStore.ShowDialog();
        }

        void frmFromPrdStore_AffterSave()
        {
            this.whereclause = string.Empty;
            this.LoadNoteData();
        }
        void lnkFromOEM_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (frmFromOEMStore  == null)
            {
                frmFromOEMStore = new FrmIntoStoreNoteFromOEMStore();
                new FrmStyle(frmFromOEMStore).SetPopFrmStyle(this);
                frmFromOEMStore.AffterSave += new FrmIntoStoreNoteFromOEMStore.AffterSaveDelegate(frmFromOEMStore_AffterSave);
            }
            frmFromOEMStore.NewNote();
            frmFromOEMStore.ShowDialog();
        }

        void frmFromOEMStore_AffterSave()
        { 
            this.whereclause = string.Empty;
            this.LoadNoteData();
        }

        private void LoadWorkingSheet()
        {
            this.dtblWorkingSheets = this.accWorkingSheets.GetDataWorkingSheetsNeedIntoMtrStore().Tables[0];
            this.dtblWorkingSheets.Columns.Add("CheckedFlag", typeof(bool));
            this.dgrdvWorkingSheet.DataSource = this.dtblWorkingSheets;
            this.pageWokingSheet.Text = "未完批次[" + this.dtblWorkingSheets.Rows.Count.ToString() + "]";
        }
        private void LoadNoteData()
        {
            int cnt = 0;
            this.dtblNotes = this.accNotes.GetDataIntoStoreNotesDescPagesFreeSearch  (1,this.pbar .PageSize ,ref cnt,this.whereclause ).Tables [0];
            this.dgrdvNote.DataSource = this.dtblNotes;
            this.pbar.Init(1, cnt);
        }

    }
}