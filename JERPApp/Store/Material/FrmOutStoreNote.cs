using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Material
{
    public partial class FrmOutStoreNote : Form
    {
        public FrmOutStoreNote()
        {
            InitializeComponent();
            this.dgrdvNote.AutoGenerateColumns = false;
            this.dgrdvSchedule.AutoGenerateColumns = false;
            this.dgrdvPacking.AutoGenerateColumns = false;
          
            this.dgrdvReplenish.AutoGenerateColumns = false;
            this.dgrdvOEMReplenish.AutoGenerateColumns = false;
            this.accNotes = new JERPData.Material.OutStoreNotes();
            this.accWorkingSheets = new JERPData.Packing .WorkingSheets();
            this.accManufSchedules = new JERPData.Manufacture.ManufSchedules();
            this.accReplenishPlans = new JERPData.Material.OutStoreReplenishPlans();
            this.accOEMReplenishPlans = new JERPData.Material.OEMOutStoreReplenishPlans();
            this.SetPermit();
        }
        private JERPData.Material.OutStoreNotes accNotes;
        private JERPData.Material.OutStoreReplenishPlans accReplenishPlans;
        private JERPData.Material.OEMOutStoreReplenishPlans accOEMReplenishPlans;
        private JERPData.Manufacture.ManufSchedules accManufSchedules;
        private JERPData.Packing .WorkingSheets accWorkingSheets;
        private FrmOutStoreNoteAppOper frmAppOper;
        private FrmOutStoreReplenishOper frmReplenishOper;
        private FrmOutStoreReplenishAdjust frmReplenishAdjust;
        private FrmOutStoreNoteOper frmOper; 
        private JERPApp.Store.Material.Report.Bill.FrmOutStoreNote frmDetail;
        private string whereclause = string.Empty;
        private DataTable dtblSchedule,dtblPacking,dtblReplenish,dtblOEMReplenish,dtblNotes;
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(296);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(297);
            if (this.enableBrowse)
            {
                //加载数据
                LoadData();
                this.dgrdvSchedule.ContextMenuStrip = this.cMenu;
                this.dgrdvReplenish.ContextMenuStrip = this.cMenu;
                this.dgrdvOEMReplenish.ContextMenuStrip = this.cMenu;
                this.dgrdvPacking.ContextMenuStrip = this.cMenu;
                this.dgrdvNote.ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                this.ctrlNoteSearch.AffterSearch += new JCommon.ctrlNoteSearch.AffterSearchDelegate(ctrlNoteSearch_AffterSearch);
                this.dgrdvNote.CellContentClick += new DataGridViewCellEventHandler(dgrdvNote_CellContentClick);
                this.pbar.OnPageIndexChanged += new EventHandler(pbar_OnPageIndexChanged);
                this.dgrdvSchedule.CellMouseDown += new DataGridViewCellMouseEventHandler(dgrdvSchedule_CellMouseDown);
                this.dgrdvPacking.CellMouseDown += new DataGridViewCellMouseEventHandler(dgrdvPacking_CellMouseDown);
            }
            this.lnkAppend.Enabled = this.enableSave;
            this.lnkReplenish.Enabled = this.enableSave;
            this.btnCreate.Enabled = this.enableSave;
            this.lnkReplenishAdust.Enabled = this.enableSave;
            if (this.enableSave)
            {
                for (int j = 0; j < this.dgrdvSchedule .ColumnCount; j++)
                {
                    this.dgrdvSchedule.Columns[j].ReadOnly = true;
                }
                for (int j = 0; j < this.dgrdvPacking .ColumnCount; j++)
                {
                    this.dgrdvPacking.Columns[j].ReadOnly = true;
                }
                this.ColumnManufQty.ReadOnly = false;
                this.ColumnPackingQty.ReadOnly = false;
                this.btnCreate.Click += new EventHandler(btnCreate_Click);
                this.lnkAppend.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkAppend_LinkClicked);
                this.lnkReplenish.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkReplenish_LinkClicked);
                this.lnkReplenishAdust.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkReplenishAdust_LinkClicked);
            }

        }


        void lnkReplenishAdust_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (frmReplenishAdjust == null)
            {
                frmReplenishAdjust = new FrmOutStoreReplenishAdjust();
                new FrmStyle(frmReplenishAdjust).SetPopFrmStyle(this);
                frmReplenishAdjust.AffterSave += new FrmOutStoreReplenishAdjust.AffterSaveDelegate(frmReplenishAdjust_AffterSave);
            }
            frmReplenishAdjust.AdjustOper();
            frmReplenishAdjust.ShowDialog();
        }

        void frmReplenishAdjust_AffterSave()
        {
            this.LoadReplenish();
        }

        void lnkReplenish_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (frmReplenishOper == null)
            {
                frmReplenishOper = new FrmOutStoreReplenishOper();
                new FrmStyle(frmReplenishOper).SetPopFrmStyle(this);
                frmReplenishOper.AffterSave += new FrmOutStoreReplenishOper.AffterSaveDelegate(frmReplenishOper_AffterSave);
            }
            frmReplenishOper.NewNote();
            frmReplenishOper.ShowDialog();
        }

        void frmReplenishOper_AffterSave()
        {
            this.LoadReplenish();
            this.whereclause = string.Empty;
            this.LoadNote();
        }

      
        void dgrdvSchedule_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvSchedule.Columns[icol].Name == this.ColumnManufQty.Name)
            {
                if (e.Button == MouseButtons.Left)
                {
                    this.dgrdvSchedule[icol, irow].Value = this.dgrdvSchedule[this.ColumnBOMNonFinishedQty.Name, irow].Value;
                }
                if (e.Button == MouseButtons.Right)
                {
                    this.dgrdvSchedule[icol, irow].Value = DBNull.Value;
                }
            }
        }


        void dgrdvPacking_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvPacking .Columns[icol].Name == this.ColumnPackingQty .Name)
            {
                if (e.Button == MouseButtons.Left)
                {
                    this.dgrdvPacking[icol, irow].Value = this.dgrdvPacking[this.ColumnPackingBOMNonFinishedQty.Name, irow].Value;
                }
                if (e.Button == MouseButtons.Right)
                {
                    this.dgrdvPacking[icol, irow].Value = DBNull.Value;
                }
            }
        }
        void mItemRefresh_Click(object sender, EventArgs e)
        {
            if ((this.cMenu.SourceControl == this.dgrdvSchedule)
                ||(this.cMenu.SourceControl == this.dgrdvPacking))
            {
                this.LoadSchedule();
            }
            if ((this.cMenu.SourceControl == this.dgrdvReplenish)
                ||(this.cMenu.SourceControl == this.dgrdvOEMReplenish))
            {
                this.LoadReplenish();
            }
            if (this.cMenu.SourceControl == this.dgrdvNote)
            {
                this.LoadNote();
            }
        }

   
        void ctrlNoteSearch_AffterSearch(string whereclause)
        {
            this.whereclause = whereclause;
            this.LoadData();
        }
        void pbar_OnPageIndexChanged(object sender, EventArgs e)
        {
            int cnt = 0;
            this.dtblNotes = this.accNotes.GetDataOutStoreNotesDescPagesFreeSearch (this.pbar .PageIndex , this.pbar.PageSize, ref cnt,this.whereclause ).Tables[0];
            this.dtblNotes.Columns.Add("CheckedFlag", typeof(bool));
            this.dgrdvNote.DataSource = this.dtblNotes;
        }
        private void LoadSchedule()
        {
            this.dtblSchedule = this.accManufSchedules.GetDataManufSchedulesForBOMRequire().Tables[0];
            this.dtblSchedule.Columns.Add("ManufQty", typeof(decimal));
            this.dgrdvSchedule.DataSource = this.dtblSchedule; 
            
            this.dtblPacking = this.accWorkingSheets.GetDataWorkingSheetsForBOMRequire().Tables[0];
            this.dtblPacking.Columns.Add("PackingQty", typeof(decimal));
            this.dgrdvPacking.DataSource = this.dtblPacking;
            this.pageSchedule.Text = "未领料[" + (this.dtblSchedule.Rows.Count+this.dtblPacking .Rows .Count).ToString()+ "]";
        }
        private void LoadReplenish()
        {
            this.dtblReplenish = this.accReplenishPlans.GetDataOutStoreReplenishPlans().Tables[0];
            this.dgrdvReplenish.DataSource = this.dtblReplenish;

            this.dtblOEMReplenish = this.accOEMReplenishPlans.GetDataOEMOutStoreReplenishPlans().Tables[0];
            this.dgrdvOEMReplenish.DataSource = this.dtblOEMReplenish;

            this.pageReplenish.Text = "未补料[" + (this.dtblReplenish.Rows.Count+this.dtblOEMReplenish .Rows .Count ).ToString() + "]";
        }
        private void LoadNote()
        {
            int cnt = 0;
            this.dtblNotes = this.accNotes.GetDataOutStoreNotesDescPagesFreeSearch(1, this.pbar.PageSize, ref cnt, this.whereclause).Tables[0];
            this.dtblNotes.Columns.Add("CheckedFlag", typeof(bool));
            this.dgrdvNote.DataSource = this.dtblNotes;
            this.pbar.Init(1, cnt);

        }
         
        private void LoadData()
        {
            this.LoadSchedule();
            this.LoadReplenish();
            this.LoadNote();
        }
        void btnCreate_Click(object sender, EventArgs e)
        {
            DataRow[] drowManufSchedules = this.dtblSchedule.Select("ManufQty is not null");
           
            DataRow[] drowWorkingSheets = this.dtblPacking .Select("PackingQty is not null");
            if (drowManufSchedules.Length +drowWorkingSheets .Length ==0)
            {
                MessageBox.Show("未设任何领料数");
                return;
            }
            if (frmOper == null)
            {
                frmOper = new FrmOutStoreNoteOper();
                new FrmStyle(frmOper).SetPopFrmStyle(this);
                frmOper.AffterSave += new FrmOutStoreNoteOper.AffterSaveDelegate(frmOper_AffterSave);
            }
            frmOper.NewNote(drowManufSchedules,drowWorkingSheets);
            frmOper.ShowDialog();
        }

        void dgrdvNote_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvNote.Columns[icol].DataPropertyName =="NoteCode")
            {
                long NoteID =(long) this.dtblNotes.DefaultView[irow]["NoteID"];
                if (this.frmDetail  == null)
                {
                    this.frmDetail = new JERPApp.Store.Material.Report.Bill.FrmOutStoreNote();
                    new FrmStyle(frmDetail).SetPopFrmStyle(this);                   
                }
                frmDetail.DetailNote (NoteID);
                frmDetail.ShowDialog();
            }
        }
     
        void lnkAppend_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.frmAppOper == null)
            {
                this.frmAppOper = new FrmOutStoreNoteAppOper();
                new FrmStyle(frmAppOper).SetPopFrmStyle(this);
                frmAppOper.AffterSave += new FrmOutStoreNoteAppOper.AffterSaveDelegate(frmOper_AffterSave);
            }
            frmAppOper.NewNote();
            frmAppOper.ShowDialog();
        }

        void frmOper_AffterSave()
        {
            this.LoadReplenish();
            this.whereclause = string.Empty;
            this.LoadData();
        }
 
    }
}