using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.MaterialOEM
{
    public partial class FrmReturnNote : Form
    {
        public FrmReturnNote()
        {
            InitializeComponent();
            this.accNotes = new JERPData.Material .OEMReturnNotes();
            this.dgrdv.AutoGenerateColumns = false;
            this.SetPermit();
        }
        private JERPData.Material.OEMReturnNotes accNotes;
        private string whereclause = string.Empty;
        private DataTable dtblNotes;
        private void LoadData()
        {
            int cnt = 0;
            this.dtblNotes = this.accNotes.GetDataOEMReturnNotesDescPagesFreeSearch  (1,this.pbar .PageSize ,ref cnt,this.whereclause ).Tables[0];
            this.dgrdv.DataSource = this.dtblNotes;
            this.pbar.Init(1, cnt);
        }

        void pbar_OnPageIndexChanged(object sender, EventArgs e)
        {
            int cnt = 0;
            this.dtblNotes = this.accNotes.GetDataOEMReturnNotesDescPagesFreeSearch (this.pbar.PageIndex, this.pbar.PageSize, ref cnt,this.whereclause ).Tables[0];
            this.dgrdv.DataSource = this.dtblNotes;
        }
      
        private bool enableBrowse = false;
        private bool enableSave= false;
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(437);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(438);
            if (this.enableBrowse)
            {
                this.LoadData(); 
                this.ctrlNoteSearch .AffterSearch +=new JCommon.ctrlNoteSearch.AffterSearchDelegate(ctrlNoteSearch_AffterSearch);
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
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
        FrmReturnNoteOper frmOper = null;
        Report.Bill.FrmReturnNote frmDetail;
       
        private void lnkNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (frmOper  == null)
            {

                frmOper = new FrmReturnNoteOper();
                new FrmStyle(frmOper).SetPopFrmStyle(this);
                frmOper.AffterSave += new FrmReturnNoteOper.AffterSaveDelegate(frmOper_AffterSave);
              
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
                    this.frmDetail = new JERPApp.Store.MaterialOEM.Report.Bill.FrmReturnNote();
                    new FrmStyle(frmDetail).SetPopFrmStyle(this);

                }
                this.frmDetail.DetailNote(NoteID);
                this.frmDetail.ShowDialog();
            }
        }

    }
}