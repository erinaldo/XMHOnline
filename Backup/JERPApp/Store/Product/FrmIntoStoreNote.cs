using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Product
{
    public partial class FrmIntoStoreNote : Form
    {
        public FrmIntoStoreNote()
        {
            InitializeComponent();
            this.dgrdvNote.AutoGenerateColumns = false;
            this.dgrdvWorkingSheet.AutoGenerateColumns = false;
            this.dgrdvPlan.AutoGenerateColumns = false;
            this.ctrlQPlan.SeachGridView = this.dgrdvPlan;
            this.ctrlCkbAll.SeachGridView = this.dgrdvWorkingSheet ;
            this.ctrlQWorkingSheet.SeachGridView = this.dgrdvWorkingSheet;
            this.accNotes = new JERPData.Product.IntoStoreNotes();
            this.accWorkingSheets = new JERPData.Manufacture.WorkingSheets();
            this.accPlans = new JERPData.Product.IntoStoreItemPlans();
            this.SetPermit();
        }
        private JERPData.Product.IntoStoreNotes accNotes;
        private JERPData.Product.IntoStoreItemPlans accPlans;
        private JERPData.Manufacture.WorkingSheets accWorkingSheets;
        private string whereclause = string.Empty;
        private FrmIntoStoreNoteOper frmOper;
        private FrmIntoStoreNoteFromMtrStore frmFromMtrStore;
        private FrmIntoStoreNoteFromApply frmFromApply;
        private FrmIntoStoreNoteFromBox frmBox;
        private JERPApp.Store.Product.Report.Bill.FrmIntoStoreNote frmDetail;
        private DataTable dtblPlans, dtblWorkingSheets, dtblNotes;
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
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(53);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(54);
            if (this.enableBrowse)
            {
                //加载数据
                this.LoadPlan();
                this.LoadNoteData();
                this.LoadWorkingSheet();
                this.dgrdvWorkingSheet.ContextMenuStrip = this.cMenu;
                this.dgrdvPlan.ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                this.ctrlNoteSearch.AffterSearch += new JCommon.ctrlNoteSearch.AffterSearchDelegate(ctrlNoteSearch_AffterSearch);
                this.pbar.OnPageIndexChanged += new EventHandler(pbar_OnPageIndexChanged);
                this.dgrdvNote.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
                this.lnkRefreshAll.Click += new EventHandler(lnkRefreshAll_Click);
            }
            this.lnkNew .Enabled = this.enableSave;
            this.btnBatchNew.Enabled = this.enableSave;
            this.lnkMtrNew.Enabled = this.enableSave;
            this.lnkApplyNew.Enabled = this.enableSave;
            this.lnkBoxNew.Enabled = this.enableSave;
            if (this.enableSave)
            {
                this.lnkApplyNew.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkApplyNew_LinkClicked);
                this.lnkMtrNew.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkMtrNew_LinkClicked);   
                this.lnkNew .LinkClicked += new LinkLabelLinkClickedEventHandler(lnkNew_LinkClicked);
                this.btnBatchNew.Click += new EventHandler(btnBatchNew_Click);
                this.lnkBoxNew.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkBoxNew_LinkClicked);
                for (int j = 1; j < this.dgrdvWorkingSheet.ColumnCount; j++)
                {
                    this.dgrdvWorkingSheet.Columns[j].ReadOnly = true;
                }
            }

        }

        void lnkBoxNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (frmBox == null)
            {
                frmBox = new FrmIntoStoreNoteFromBox();
                new FrmStyle(frmBox).SetPopFrmStyle(this);
                frmBox.AffterSave += new FrmIntoStoreNoteFromBox.AffterSaveDelegate(frmBox_AffterSave);                
            }
            frmBox.New();
            frmBox.ShowDialog();
        }

        void frmBox_AffterSave()
        {
            this.whereclause = string.Empty;
            this.LoadWorkingSheet();
            this.LoadNoteData();
        }

      
        void lnkRefreshAll_Click(object sender, EventArgs e)
        {
            this.LoadPlan();
            this.LoadWorkingSheet();
        }

        void mItemRefresh_Click(object sender, EventArgs e)
        {
            if (this.cMenu.SourceControl == this.dgrdvPlan)
            {
                this.LoadPlan();
            }
            if (this.cMenu.SourceControl == this.dgrdvWorkingSheet)
            {
                this.LoadWorkingSheet();
            }
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
        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvNote.Columns[icol].Name == this.ColumnbtnDetail.Name)
            {
                long NoteID =(long) this.dtblNotes.DefaultView[irow]["NoteID"];
                if (this.frmDetail  == null)
                {
                    this.frmDetail = new JERPApp.Store.Product.Report.Bill.FrmIntoStoreNote();
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
            frmOper.NewNote(drows);
            frmOper.ShowDialog();
        }
        void lnkNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.frmOper == null)
            {
                this.frmOper = new FrmIntoStoreNoteOper();
                new FrmStyle(frmOper).SetPopFrmStyle(this);
                frmOper.AffterSave+=frmOper_AffterSave;
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
        void lnkApplyNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (frmFromApply == null)
            {
                frmFromApply = new FrmIntoStoreNoteFromApply();
                new FrmStyle(frmFromApply).SetPopFrmStyle(this);
                frmFromApply.AffterSave += new FrmIntoStoreNoteFromApply.AffterSaveDelegate(frmFromApply_AffterSave);
            }
            frmFromApply.New();
            frmFromApply.ShowDialog();
        }

        void frmFromApply_AffterSave()
        {
            this.whereclause = string.Empty;
            this.LoadPlan();
            this.LoadWorkingSheet();
            this.LoadNoteData();
        }

        void lnkMtrNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (frmFromMtrStore == null)
            {
                frmFromMtrStore = new FrmIntoStoreNoteFromMtrStore();
                new FrmStyle(frmFromMtrStore).SetPopFrmStyle(this);
                frmFromMtrStore.AffterSave += new FrmIntoStoreNoteFromMtrStore.AffterSaveDelegate(frmFromMtrStore_AffterSave);
            }
            frmFromMtrStore.NewNote();
            frmFromMtrStore.ShowDialog();
        }

        void frmFromMtrStore_AffterSave()
        {
            this.whereclause = string.Empty;
            this.LoadNoteData();
        }

        private void LoadPlan()
        {
            this.dtblPlans  = this.accPlans .GetDataIntoStoreItemPlansNonIntoStore().Tables[0];
            this.dgrdvPlan.DataSource = this.dtblPlans;
            this.pagePlan.Text = "入库申请[" + this.dtblPlans.Rows.Count.ToString() + "]";
        }
        private void LoadWorkingSheet()
        {
            this.dtblWorkingSheets = this.accWorkingSheets.GetDataWorkingSheetsNeedIntoPrdStore().Tables[0];
            this.dtblWorkingSheets.Columns.Add("CheckedFlag", typeof(bool));
            this.dgrdvWorkingSheet.DataSource = this.dtblWorkingSheets;
            this.pageWorkingSheet.Text = "未完批次[" + this.dtblWorkingSheets.Rows.Count.ToString() + "]";
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