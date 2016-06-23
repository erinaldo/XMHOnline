using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Product
{
    public partial class FrmSaleReturnNote : Form
    {
        public FrmSaleReturnNote()
        {
            InitializeComponent();
            this.accNotes = new JERPData.Product .SaleReturnNotes();
            this.printhelper = new JERPBiz.Product.SaleReturnNotePrintHelper();
            this.dgrdv.AutoGenerateColumns = false;
            this.dgrdvNonPrint.AutoGenerateColumns = false;
            this.ctrlGridNonPrintFind.SeachGridView = this.dgrdvNonPrint;
            this.SetPermit();
        }
        private JERPData.Product.SaleReturnNotes accNotes;
        private JERPBiz.Product.SaleReturnNotePrintHelper printhelper;
        private string whereclause = string.Empty;
        private DataTable dtblNotes,dtblNonPrint;
        
        private bool enableBrowse = false;
        private bool enableSave= false;
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(43);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(44);
            if (this.enableBrowse)
            {
                this.LoadData();
                this.LoadNonPrint();
                this.ctrlGridNonPrintFind.BeforeFilter += this.LoadNonPrint;
                this.dgrdvNonPrint.ContextMenuStrip = this.cMenu;
                this.dgrdv.ContextMenuStrip  = this.cMenu;
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

      
        void ctrlNoteSearch_AffterSearch(string whereclause)
        {
            this.whereclause = whereclause;
            this.LoadData();
        }
        private void LoadNonPrint()
        {
            this.dtblNonPrint = this.accNotes.GetDataSaleReturnNotesNonPrint().Tables[0];
            this.dgrdvNonPrint.DataSource = this.dtblNonPrint;
            this.pageNonPrint.Text = "Œ¥¥Ú”°[" + this.dtblNonPrint.Rows.Count.ToString() + "]";
        }
        private void LoadData()
        {
            int cnt = 0;
            this.dtblNotes = this.accNotes.GetDataSaleReturnNotesDescPagesFreeSearch(1, this.pbar.PageSize, ref cnt, this.whereclause).Tables[0];
            this.dgrdv.DataSource = this.dtblNotes;
            this.pbar.Init(1, cnt);
        }
        void mItemRefresh_Click(object sender, EventArgs e)
        {
            if (this.cMenu.SourceControl == this.dgrdv)
            {
                this.whereclause = string.Empty;
                this.LoadData();
            }
            if (this.cMenu.SourceControl == this.dgrdvNonPrint )
            {
                this.LoadNonPrint();
            }
        }
        void pbar_OnPageIndexChanged(object sender, EventArgs e)
        {
            int cnt = 0;
            this.dtblNotes = this.accNotes.GetDataSaleReturnNotesDescPagesFreeSearch(this.pbar.PageIndex, this.pbar.PageSize, ref cnt, this.whereclause).Tables[0];
            this.dgrdv.DataSource = this.dtblNotes;
        }
      
        FrmSaleReturnNoteOper frmOper = null;
        JERPApp.Store.Product .Report.Bill.FrmSaleReturnNote frmDetail;       
        private void lnkNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (frmOper  == null)
            {
                frmOper = new FrmSaleReturnNoteOper();
                new FrmStyle(frmOper).SetPopFrmStyle(this);
                frmOper.AffterSave += new FrmSaleReturnNoteOper.AffterSaveDelegate(frmOper_AffterSave);
              
            }
            frmOper.NewNote();
            frmOper.ShowDialog();
        }

        void frmOper_AffterSave()
        {
            this.whereclause = string.Empty;
            this.LoadData();
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
                    this.frmDetail = new JERPApp.Store.Product .Report.Bill.FrmSaleReturnNote();
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
                long NoteID = (long)this.dtblNonPrint.DefaultView[irow]["NoteID"];
                this.printhelper.ExportToExcel(NoteID);
                string errormsg = string.Empty;
                this.accNotes.UpdateSaleReturnNotesForPrint(ref errormsg, NoteID,
                    JERPBiz.Frame.UserBiz.PsnID);
            }
        }

    }
}