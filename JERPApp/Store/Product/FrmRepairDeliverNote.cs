using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Product
{
    public partial class FrmRepairDeliverNote : Form
    {
        public FrmRepairDeliverNote()
        {
            InitializeComponent();
            this.accNotes = new JERPData.Product.RepairDeliverNotes(); 
            this.dgrdvNonConfirm.AutoGenerateColumns = false;
            this.dgrdvConfirm.AutoGenerateColumns = false;
            this.ctrlQNonConfirm.SeachGridView = this.dgrdvNonConfirm; 
            this.SetPermit();
        }
        private JERPData.Product.RepairDeliverNotes accNotes; 
        FrmRepairDeliverNoteOper frmOper = null;
        private Report.Bill.FrmRepairDeliverNote frmDetail;
        private DataTable dtblConfirms,dtblNonConfirm;
        private string whereclause = string.Empty;
        private string iniwhereclause = " and (ConfirmPsnID is not null)";
        private bool enableBrowse = false;
        private bool enableSave= false;
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(157);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(158);
            if (this.enableBrowse)
            {
                this.dtpDateBegin.Value = DateTime.Now.AddDays(-10).Date;
                this.dtpDateEnd.Value = DateTime.Now.AddDays(1).Date;
                this.LoadConfirm();
                this.LoadNonConfirm();
                
                this.whereclause = this.iniwhereclause;
                this.dgrdvConfirm .ContextMenuStrip = this.cMenu;
                this.dgrdvNonConfirm.ContextMenuStrip = this.cMenu; 
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                this.pbar.OnPageIndexChanged += new EventHandler(pbar_OnPageIndexChanged);
                this.dgrdvConfirm.CellContentClick += new DataGridViewCellEventHandler(dgrdvConfirm_CellContentClick);
                this.btnSearch.Click += new EventHandler(btnSearch_Click);
                 
            }
           
            if (this.enableSave)
            {
                this.dgrdvNonConfirm.CellContentClick += new DataGridViewCellEventHandler(dgrdvNonConfirm_CellContentClick); 
               
            }
        }

        void btnSearch_Click(object sender, EventArgs e)
        {
            this.whereclause = this.iniwhereclause;
            if (this.ckbCustomer.Checked)
            {
                this.whereclause += " and (CompanyID=" + this.ctrlCompanyID.CompanyID.ToString() + ")";
            }
            if (this.ckbPrd.Checked)
            {
                this.whereclause += " and (PrdID=" + this.ctrlPrdID.PrdID.ToString() + ")";
            }
            if (this.ckbDateNote.Checked)
            {
                this.whereclause += " and (DateNote>='" + this.dtpDateBegin.Value.ToShortDateString() + "' and DateNote<='" + this.dtpDateEnd.Value.ToShortDateString() + "')";
            }
            this.LoadConfirm();
        }

       
        private void LoadNonConfirm()
        {
            this.dtblNonConfirm  = this.accNotes .GetDataRepairDeliverNotesNonConfirm ().Tables[0];
            this.dgrdvNonConfirm .DataSource = this.dtblNonConfirm ;
            this.pageNonConfirm.Text = "Î´³ö»õ[" + this.dtblNonConfirm.Rows.Count.ToString() + "]";
        }
        private void LoadConfirm()
        {
            int cnt = 0;
            this.dtblConfirms  = this.accNotes.GetDataRepairDeliverNotesDescPagesFreeSearch (1,this.pbar .PageSize ,ref cnt ,this.whereclause ).Tables[0];
            this.dgrdvConfirm .DataSource = this.dtblConfirms ;
            this.pbar.Init(1, cnt);
        }

        void pbar_OnPageIndexChanged(object sender, EventArgs e)
        {
            int cnt = 0;
            this.dtblConfirms = this.accNotes.GetDataRepairDeliverNotesDescPagesFreeSearch(this.pbar .PageIndex , this.pbar.PageSize, ref cnt, this.whereclause).Tables[0];
            this.dgrdvConfirm.DataSource = this.dtblConfirms;
        } 
        void mItemRefresh_Click(object sender, EventArgs e)
        {
            if (this.cMenu.SourceControl == this.dgrdvNonConfirm)
            {
                this.LoadNonConfirm();
            }
            if (this.cMenu.SourceControl == this.dgrdvConfirm )
            {
                this.whereclause = this.iniwhereclause;   
                this.LoadConfirm();
            } 
        }
       
       
        void frmOper_AffterSave()
        {
            this.whereclause = this.iniwhereclause;
            this.LoadConfirm();
            this.LoadNonConfirm(); 
        }

        void dgrdvConfirm_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvConfirm.Columns[icol].Name == this.ColumnbtnDetail .Name)
            {
                long NoteID = (long)this.dtblConfirms.DefaultView[irow]["NoteID"];
                if (frmDetail == null)
                {
                    frmDetail = new JERPApp.Store.Product.Report.Bill.FrmRepairDeliverNote();
                    new FrmStyle(frmDetail).SetPopFrmStyle(this);
                }
                frmDetail.DetailNote(NoteID);
                frmDetail.ShowDialog();
            }
        }

        private void dgrdvNonConfirm_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvNonConfirm.Columns[icol].Name == this.ColumnbtnConfirm .Name )
            {
                long NoteID = (long)this.dtblNonConfirm.DefaultView[irow]["NoteID"];
                if (frmOper   == null)
                {
                    frmOper = new FrmRepairDeliverNoteOper();
                    new FrmStyle(frmOper).SetPopFrmStyle(this);        
                    frmOper .AffterSave +=new FrmRepairDeliverNoteOper.AffterSaveDelegate(frmOper_AffterSave); 
                } 
                frmOper.ConfirmOper(NoteID);
                frmOper.ShowDialog();
            }
        }
       
       
    }
}