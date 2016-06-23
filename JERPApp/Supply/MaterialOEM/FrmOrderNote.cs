using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Supply.MaterialOEM
{
    public partial class FrmOrderNote : Form
    {
        public FrmOrderNote()
        {
            InitializeComponent();
            this.dgrdvNote.AutoGenerateColumns = false;
            this.dgrdvPlan.AutoGenerateColumns = false;
            this.dgrdvStore.AutoGenerateColumns = false;
            this.ctrlQPlan.SeachGridView = this.dgrdvPlan;
            this.ctrlQStore.SeachGridView = this.dgrdvStore;
            this.accNotes = new JERPData.Material.OEMOrderNotes();
            this.accOEMPlans = new JERPData.Material.OEMPlans();
            this.accStore = new JERPData.Material.OEMStore();
            this.printer = new JERPBiz.Material.OEMOrderNotePrintHelper();
            this.SetPermit();
        }
        private JERPData.Material.OEMOrderNotes accNotes;
        private JERPData.Material.OEMPlans accOEMPlans;
        private JERPData.Material.OEMStore accStore;
        private JERPBiz.Material.OEMOrderNotePrintHelper printer;
        private string whereclause = string.Empty;
        private FrmOrderNoteOper frmOper;
        private DataTable dtblNotes, dtblPlans, dtblStores;
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(420);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(421);
            if (this.enableBrowse)
            {    //加载数据
                LoadData();
                this.dgrdvNote.ContextMenuStrip = this.cMenu;
                this.dgrdvPlan.ContextMenuStrip = this.cMenu;
                this.dgrdvStore.ContextMenuStrip = this.cMenu;
                this.tabMain.SelectedIndexChanged += new EventHandler(tabMain_SelectedIndexChanged);
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);

                this.lnkRefreshAll.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkRefreshAll_LinkClicked);
                this.pbar.OnPageIndexChanged += new EventHandler(pbar_OnPageIndexChanged);
                this.ctrlNoteSearch.AffterSearch += new JCommon.ctrlNoteSearch.AffterSearchDelegate(ctrlNoteSearch_AffterSearch);
            }
            this.lnkNew.Enabled = this.enableSave;
            this.ColumnbtnEdit.Visible = this.enableSave;
            if (this.enableSave)
            {
                this.lnkNew.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkNew_LinkClicked);
                this.dgrdvNote.CellContentClick += new DataGridViewCellEventHandler(dgrdvNote_CellContentClick);
            }


        }


        void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataGridView dgrdv = (DataGridView)this.tabMain.SelectedTab.Controls[0];
            this.ctrlQPlan.SeachGridView = dgrdv;
        }
        void ctrlNoteSearch_AffterSearch(string whereclause)
        {
            this.whereclause = whereclause;
            int cnt = 0;
            this.dtblNotes = this.accNotes.GetDataOEMOrderNotesDescPagesFreeSearch(1, this.pbar.PageSize, ref cnt, this.whereclause).Tables[0];
            this.dgrdvNote.DataSource = this.dtblNotes;
            this.pbar.Init(1, cnt);
        }
        void lnkRefreshAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        { 
            this.LoadData();
        }
        void dgrdvNote_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            long NoteID = (long)this.dtblNotes.DefaultView[irow]["NoteID"];
            if (this.dgrdvNote.Columns[icol].Name == this.ColumnbtnEdit.Name)
            {
             
                if (this.frmOper == null)
                {
                    this.frmOper = new FrmOrderNoteOper();
                    new FrmStyle(frmOper).SetPopFrmStyle(this);
                    frmOper.AffterSave += this.LoadData;
                    
                }
                frmOper.EditNote(NoteID);
                frmOper.ShowDialog();
            } 
            if (this.dgrdvNote.Columns[icol].Name == this.ColumnbtnPrint.Name)
            {
                FrmMsg.Show("正在生成打印文档，请稍候......");
                this.printer.ExportToExcel(NoteID);
                FrmMsg.Hide();
            }
        }

        void lnkNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.frmOper == null)
            {
                this.frmOper = new FrmOrderNoteOper();
                new FrmStyle(frmOper).SetPopFrmStyle(this);
                frmOper.AffterSave += this.LoadData;
            }
            frmOper.NewNote();
            frmOper.ShowDialog();
        }

        void mItemRefresh_Click(object sender, EventArgs e)
        {
            if (this.cMenu.SourceControl == this.dgrdvPlan)
            {
                this.LoadPlan();
            }
            if (this.cMenu.SourceControl == this.dgrdvStore)
            {
                this.LoadStore();

            }
            if (this.cMenu.SourceControl == this.dgrdvNote)
            {
                this.whereclause = string.Empty;
                this.LoadNote();
            }
        }
        private void LoadPlan()
        {
            this.dtblPlans = this.accOEMPlans.GetDataOEMPlansNonFinished().Tables[0];
            this.dgrdvPlan.DataSource = this.dtblPlans;
            this.pagePlan.Text = "客供计划[" + this.dtblPlans.Rows.Count.ToString() + "]";
        }
        private void LoadStore()
        {
            this.dtblStores = this.accStore.GetDataOEMStoreSafeInventory().Tables[0];
            this.dgrdvStore.DataSource = this.dtblStores;
            this.pageStore.Text = "安全库存[" + this.dtblStores.Rows.Count.ToString() + "]";
        }
        private void LoadNote()
        {
            int cnt = 0;
            this.dtblNotes = this.accNotes.GetDataOEMOrderNotesDescPagesFreeSearch(1, this.pbar.PageSize, ref cnt, this.whereclause).Tables[0];
            this.dgrdvNote.DataSource = this.dtblNotes;
            this.pbar.Init(1, cnt);
        }
        private void LoadData()
        {
            this.LoadPlan();
            this.LoadStore();
            this.LoadNote();
        }

        void pbar_OnPageIndexChanged(object sender, EventArgs e)
        {
            int cnt = 0;
            this.dtblNotes = this.accNotes.GetDataOEMOrderNotesDescPagesFreeSearch(this.pbar .PageIndex , this.pbar.PageSize, ref cnt, this.whereclause).Tables[0];
            this.dgrdvNote.DataSource = this.dtblNotes;
        }


    }
}