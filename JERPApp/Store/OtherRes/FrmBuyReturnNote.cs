using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.OtherRes
{
    public partial class FrmBuyReturnNote : Form
    {
        public FrmBuyReturnNote()
        {
            InitializeComponent();
            this.accNotes = new JERPData.OtherRes .BuyReturnNotes();
            this.printhelper = new JERPBiz.OtherRes.BuyReceiveNotePrintHelper();
            this.dgrdv.AutoGenerateColumns = false;
            this.dgrdvNonPrint.AutoGenerateColumns = false;
            this.SetPermit();
        }
        private JERPData.OtherRes.BuyReturnNotes accNotes;
        private JERPBiz.OtherRes.BuyReceiveNotePrintHelper printhelper;
        private string whereclause = string.Empty;
        private DataTable dtblNotes, dtblNonPrints;
        FrmBuyReturnNoteOper frmOper = null;
        JERPApp.Store.OtherRes.Report.Bill.FrmBuyReturnNote frmDetail;        
        private bool enableBrowse = false;
        private bool enableSave= false;
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(568);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(569);
            if (this.enableBrowse)
            {
                this.LoadData();
                this.LoadNonPrint();
                this.dgrdvNonPrint.ContextMenuStrip = this.cMenu;
                this.dgrdv.ContextMenuStrip = this.cMenu;
                this.ctrlGridNonPrintFind.BeforeFilter += this.LoadNonPrint;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                this.ctrlNoteSearch .AffterSearch +=new JCommon.ctrlNoteSearch.AffterSearchDelegate(ctrlNoteSearch_AffterSearch);
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
                this.dgrdvNonPrint.CellContentClick += new DataGridViewCellEventHandler(dgrdvNonPrint_CellContentClick);
                this.pbar.OnPageIndexChanged += new EventHandler(pbar_OnPageIndexChanged);
            }
            this.lnkNew .Enabled = this.enableSave;
            if (this.enableSave)
            {
                this.lnkNew .LinkClicked +=new LinkLabelLinkClickedEventHandler(lnkNew_LinkClicked);
            }
        }


        void mItemRefresh_Click(object sender, EventArgs e)
        {
            if (this.cMenu.SourceControl == this.dgrdv)
            {
                this.whereclause = string.Empty;
                this.LoadData();
            }
            if (this.cMenu.SourceControl == this.dgrdvNonPrint)
            {
                this.LoadNonPrint();
            }
        }
        private void LoadNonPrint()
        {
            this.dtblNonPrints = this.accNotes.GetDataBuyReturnNotesNonPrint().Tables[0];
            this.dgrdvNonPrint.DataSource = this.dtblNonPrints;
            this.pageNonPrint.Text = "Œ¥¥Ú”°[" + this.dtblNonPrints.Rows.Count.ToString() + "]";
        }
        private void LoadData()
        {
            int cnt = 0;
            this.dtblNotes = this.accNotes.GetDataBuyReturnNotesDescPagesFreeSearch(1, this.pbar.PageSize, ref cnt, this.whereclause).Tables[0];
            this.dgrdv.DataSource = this.dtblNotes;
            this.pbar.Init(1, cnt);
        }

        void pbar_OnPageIndexChanged(object sender, EventArgs e)
        {
            int cnt = 0;
            this.dtblNotes = this.accNotes.GetDataBuyReturnNotesDescPagesFreeSearch(this.pbar.PageIndex, this.pbar.PageSize, ref cnt, this.whereclause).Tables[0];
            this.dgrdv.DataSource = this.dtblNotes;
        }
        void ctrlNoteSearch_AffterSearch(string whereclause)
        {
            this.whereclause = whereclause;
            this.LoadData();
        }
      
        private void lnkNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (frmOper  == null)
            {

                frmOper = new FrmBuyReturnNoteOper();
                new FrmStyle(frmOper).SetPopFrmStyle(this);
                frmOper.AffterSave += new FrmBuyReturnNoteOper.AffterSaveDelegate(frmOper_AffterSave);
              
            }
            frmOper.NewNote();
            frmOper.ShowDialog();
        }

        void frmOper_AffterSave()
        {
            this.whereclause = string.Empty;
            this.LoadData();
            this.LoadNonPrint();
        }
        private void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnBntDetail.Name)
            {
                long NoteID = (long)this.dtblNotes.DefaultView[irow]["NoteID"];
                if (this.frmDetail == null)
                {
                    this.frmDetail = new JERPApp.Store.OtherRes.Report.Bill.FrmBuyReturnNote();
                    new FrmStyle(frmDetail).SetPopFrmStyle(this);

                }
                this.frmDetail.DetailNote(NoteID);
                this.frmDetail.ShowDialog();
            }
        }
        void dgrdvNonPrint_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvNonPrint.Columns[icol].Name == this.ColumnbtnPrint .Name)
            {
                long NoteID = (long)this.dtblNonPrints .DefaultView[irow]["NoteID"];
                this.printhelper.ExportToExcel(NoteID);
                string errormsg = string.Empty;
                this.accNotes.UpdateBuyReturnNotesForPrint(ref errormsg,
                    NoteID, JERPBiz.Frame.UserBiz.PsnID);
            }
        }

    }
}