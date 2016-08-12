using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Product
{
    public partial class FrmSaleReplenishNote : Form
    {
        public FrmSaleReplenishNote()
        {
            InitializeComponent();
            this.accNotes = new JERPData.Product .SaleReplenishNotes();
            this.accPlans = new JERPData.Product.SaleReplenishPlans();
            this.printhelper = new JERPBiz.Product.SaleReplenishPrintHelper();
            this.dgrdvPlan.AutoGenerateColumns = false;
            this.dgrdv.AutoGenerateColumns = false;
            this.dgrdvNonPrint.AutoGenerateColumns = false;
            this.ctrlGridNonPrintFind.SeachGridView = this.dgrdvNonPrint;
            this.SetPermit();
        }
        private JERPData.Product.SaleReplenishNotes accNotes;
        private JERPBiz.Product.SaleReplenishPrintHelper printhelper;
        private JERPData.Product.SaleReplenishPlans accPlans; 
        FrmSaleReplenishNoteOper frmOper = null;
        JERPApp.Store.Product.Report.Bill.FrmSaleReplenishNote frmDetail;
        private string whereclause = string.Empty;
        private DataTable dtblNotes,dtblPlans,dtblNonPrint;
        private bool enableBrowse = false;
        private bool enableSave= false;
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(187);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(188);            
            if (this.enableBrowse)
            {
                this.dgrdv .ContextMenuStrip  = this.cMenu;
                this.dgrdvPlan.ContextMenuStrip = this.cMenu;
                this.menuItemRefresh.Click += new EventHandler(menuItemRefresh_Click);
                this.ctrlNoteSearch.AffterSearch += new JCommon.ctrlNoteSearch.AffterSearchDelegate(ctrlNoteSearch_AffterSearch);
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
                this.dgrdvNonPrint.CellContentClick += new DataGridViewCellEventHandler(dgrdvNonPrint_CellContentClick);
                this.LoadData();
                this.LoadPlan();
                this.LoadNonPrint();
                this.ctrlGridNonPrintFind.BeforeFilter += this.LoadNonPrint;
                this.pbar.OnPageIndexChanged += new EventHandler(pbar_OnPageIndexChanged);
            }
            this.ColumnbtnReplenish.Visible = this.enableSave;
            if (this.enableSave)
            {
                this.dgrdvPlan.CellContentClick += new DataGridViewCellEventHandler(dgrdvPlan_CellContentClick);
              
            }
        }

       
        private void LoadPlan()
        {
            this.dtblPlans = this.accPlans.GetDataSaleReplenishPlansCustomerForDeliver().Tables[0];
            this.dgrdvPlan.DataSource = this.dtblPlans;
            this.pagePlan.Text = "≤πªı[" + this.dtblPlans.Rows.Count.ToString() + "]";
        }
        private void LoadData()
        {
            int cnt = 0;
            this.dtblNotes = this.accNotes.GetDataSaleReplenishNotesDescPagesFreeSearch(1, this.pbar.PageSize, ref cnt, this.whereclause).Tables[0];
            this.dgrdv.DataSource = this.dtblNotes;
            this.pbar.Init(1, cnt);
        }
        private void LoadNonPrint()
        {
            this.dtblNonPrint = this.accNotes.GetDataSaleReplenishNotesNonPrint().Tables[0];
            this.dgrdvNonPrint.DataSource = this.dgrdvNonPrint;
            this.pageNonPrint.Text = "Œ¥¥Ú”°[" + this.dtblNonPrint.Rows.Count.ToString() + "]";
        }
        void ctrlNoteSearch_AffterSearch(string whereclause)
        {
            this.whereclause = whereclause;
            this.LoadData();
        }

        void pbar_OnPageIndexChanged(object sender, EventArgs e)
        {
            int cnt = 0;
            this.dtblNotes = this.accNotes.GetDataSaleReplenishNotesDescPagesFreeSearch (this.pbar .PageIndex , this.pbar.PageSize, ref cnt,this.whereclause ).Tables[0];
            this.dgrdv.DataSource = this.dtblNotes;
        }

        private void menuItemRefresh_Click(object sender, EventArgs e)
        {
            if (this.cMenu.SourceControl == this.dgrdv)
            {
                this.whereclause = string.Empty;
                this.LoadData();
            }
            if (this.cMenu.SourceControl == this.dgrdvPlan )
            {
                this.LoadPlan();
            }
            if (this.cMenu.SourceControl == this.dgrdvNonPrint )
            {
                this.LoadNonPrint();
            }
        }
      

        private void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnBtnDetail .Name)
            {
                long NoteID = (long)this.dtblNotes.DefaultView[irow]["NoteID"];
                if (frmDetail == null)
                {

                    frmDetail = new JERPApp.Store.Product.Report.Bill.FrmSaleReplenishNote();
                    new FrmStyle(frmDetail).SetPopFrmStyle(this);
                    
                }
                frmDetail.DetailNote(NoteID);
                frmDetail.ShowDialog();
            }
        }

        void dgrdvNonPrint_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvNonPrint.Columns[icol].Name == this.ColumnbtnPrint.Name)
            {
                long NoteID = (long)this.dtblNonPrint.DefaultView[irow]["NoteID"];
                this.printhelper.ExportToExcel(NoteID);
                string errormsg = string.Empty;
                this.accNotes.UpdateSaleReplenishNotesForPrint  (ref errormsg, NoteID, JERPBiz.Frame.UserBiz.PsnID);
            }
        }
        void dgrdvPlan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvPlan.Columns[icol].Name == this.ColumnbtnReplenish.Name)
            {
                int CompanyID = (int)this.dtblPlans.DefaultView[irow]["CompanyID"];
                string CompanyAbbName = this.dtblPlans.DefaultView[irow]["CompanyAbbName"].ToString ();
                if (frmOper == null)
                {               
                    frmOper = new FrmSaleReplenishNoteOper();
                    new FrmStyle(frmOper).SetPopFrmStyle(this);
                    frmOper.AffterSave += new FrmSaleReplenishNoteOper.AffterSaveDelegate(frmOper_AffterSave);
                }
                frmOper.NewNote(CompanyID ,CompanyAbbName);
                frmOper.ShowDialog();

            }
        }

        void frmOper_AffterSave()
        {
            this.whereclause = string.Empty;
            this.LoadData();
            this.LoadNonPrint();
            this.LoadPlan();
        }
    }
}