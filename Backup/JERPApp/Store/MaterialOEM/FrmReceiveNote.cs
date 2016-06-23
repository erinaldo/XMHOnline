using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.MaterialOEM
{
    public partial class FrmReceiveNote : Form
    {
        public FrmReceiveNote()
        {
            InitializeComponent();
            this.accNotes = new JERPData.Material.OEMReceiveNotes();
            this.accOrderNotes = new JERPData.Material.OEMOrderNotes();
            this.dgrdv.AutoGenerateColumns = false;
            this.dgrdvOrder.AutoGenerateColumns = false;
            this.ctrlGridOrder.SeachGridView = this.dgrdvOrder;
            this.SetPermit();
        }
        private JERPData.Material.OEMReceiveNotes accNotes;
        private JERPData.Material.OEMOrderNotes  accOrderNotes;
        FrmReceiveNoteOper frmOper = null;
        FrmReceiveNoteNonOrderOper frmNonOrderOper;

        JERPApp.Store.MaterialOEM.Report.Bill.FrmReceiveNote frmDetail;
        private string whereclause = string.Empty;
        private DataTable dtblOrdrNotes, dtblNotes;
     
        private void LoadData()
        {
            int cnt = 0;
            this.dtblNotes = this.accNotes.GetDataOEMReceiveNotesDescPagesFreeSearch(1, this.pbar.PageSize, ref cnt, this.whereclause).Tables[0];
            this.dgrdv.DataSource = this.dtblNotes;
            this.pbar.Init(1, cnt);
        }
       
        private void LoadOrder()
        {
            this.dtblOrdrNotes = this.accOrderNotes.GetDataOEMOrderNotesForReceive ().Tables[0];
            this.dgrdvOrder.DataSource = this.dtblOrdrNotes;
            this.pageOrder .Text = "∂©µ• ’ªı[" + this.dtblOrdrNotes.Rows.Count.ToString() + "]";
        }
        private bool enableBrowse = false;
        private bool enableSave= false;
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(435);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(436);
            if (this.enableBrowse)
            {
                this.LoadOrder();
                this.LoadData();
                this.ctrlGridOrder.BeforeFilter += this.LoadOrder;
                this.dgrdv.ContextMenuStrip = this.cMenu;
                this.dgrdvOrder.ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                this.ctrlNoteSearch.AffterSearch += new JCommon.ctrlNoteSearch.AffterSearchDelegate(ctrlNoteSearch_AffterSearch);  
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
                this.pbar.OnPageIndexChanged += new EventHandler(pbar_OnPageIndexChanged);
            }
            this.ColumnbtnReceive.Visible = this.enableSave;
            this.lnkNonNew.Enabled = enableSave;
            if (this.enableSave)
            {
                this.dgrdvOrder.CellContentClick += new DataGridViewCellEventHandler(dgrdvOrder_CellContentClick);               
                this.lnkNonNew.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkNonNew_LinkClicked);
            }
        }

        void mItemRefresh_Click(object sender, EventArgs e)
        {
            if (this.cMenu.SourceControl == this.dgrdvOrder)
            {
                this.LoadOrder();
            }
            if (this.cMenu.SourceControl == this.dgrdv)
            {
                this.whereclause = string.Empty;
                this.LoadData();
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
            this.dtblNotes = this.accNotes.GetDataOEMReceiveNotesDescPagesFreeSearch (this.pbar .PageIndex, this.pbar.PageSize, ref cnt,this.whereclause ).Tables[0];
            this.dgrdv.DataSource = this.dtblNotes;
        }
        private void dgrdvOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvOrder.Columns[icol].Name == this.ColumnbtnReceive.Name)
            {
                long NoteID = (long)this.dtblOrdrNotes.DefaultView[irow]["NoteID"];
                if (this.frmOper == null)
                {
                    this.frmOper = new FrmReceiveNoteOper();
                    new FrmStyle(frmOper).SetPopFrmStyle(this);
                    this.frmOper.AffterSave += this.frmOper_AffterSave;

                }
                this.frmOper.NewNote(NoteID);
                this.frmOper.ShowDialog();
            }
        }
        private void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnBtnDetail.Name)
            {
                if (frmDetail  == null)
                {
                    frmDetail = new JERPApp.Store.MaterialOEM.Report.Bill.FrmReceiveNote();
                    new FrmStyle(frmDetail).SetPopFrmStyle(this);                
                   
                }
                long NoteID = (long)this.dtblNotes.DefaultView[irow]["NoteID"];
                frmDetail.DetailNote(NoteID);
                frmDetail.ShowDialog();
            }
        }
       
        void lnkNonNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (frmNonOrderOper == null)
            {
                frmNonOrderOper = new FrmReceiveNoteNonOrderOper();
                new FrmStyle(frmNonOrderOper).SetPopFrmStyle(this);
                frmNonOrderOper.AffterSave += frmOper_AffterSave;
            }
            frmNonOrderOper.NewNote();
            frmNonOrderOper.ShowDialog();
        }
        void frmOper_AffterSave()
        {
            this.whereclause = string.Empty;
            this.LoadOrder();
            this.LoadData();
        }
    }
}