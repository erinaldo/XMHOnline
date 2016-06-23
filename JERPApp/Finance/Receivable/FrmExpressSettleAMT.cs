using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Receivable
{
    public partial class FrmExpressSettleAMT : Form
    {
        public FrmExpressSettleAMT()
        {
            InitializeComponent();
            this.dgrdvReconciliation.AutoGenerateColumns = false;
            this.dgrdvReceipt.AutoGenerateColumns = false;
            this.ctrlQReceipt.SeachGridView = this.dgrdvReceipt;
            this.ctrlQReconciliation.SeachGridView = this.dgrdvReconciliation;
            this.accReconciliations = new JERPData.Product.ExpressReconciliations();
            this.accReceiptNotes = new JERPData.Product.ExpressReceiptNotes();
            this.SetPermit();
        }
        private JERPData.Product.ExpressReconciliations accReconciliations;
        private JERPData.Product.ExpressReceiptNotes accReceiptNotes;
        private DataTable dtblReconciliations, dtblReceiptNotes;
        private FrmExpressSettleAMTOper frmSettleAMTOper;
        private string whereclause = string.Empty; 
        private JERPApp.Finance.Report.Bill.Product.FrmExpressReceiptNote frmDetail;
         //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存  

        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(737);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(738);
            if (this.enableBrowse)
            {

                this.dtpDateBegin.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                this.dtpDateEnd.Value = this.dtpDateBegin.Value.AddMonths(1).AddDays(-1);

                this.LoadReconciliation();
                this.LoadReceipt();
                this.btnSearch.Click += new EventHandler(btnSearch_Click);
                this.dgrdvReconciliation.ContextMenuStrip = this.cMenu;
                this.dgrdvReceipt.ContextMenuStrip = this.cMenu;              
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                this.dgrdvReceipt.CellContentClick += new DataGridViewCellEventHandler(dgrdvReceipt_CellContentClick);
                this.pbar.OnPageIndexChanged += new EventHandler(pbar_OnPageIndexChanged);
            }
            this.ColumnbtnReconciliation.Visible = this.enableSave; 
            if (this.enableSave)
            {
                this.dgrdvReconciliation.CellContentClick += new DataGridViewCellEventHandler(dgrdvReconciliation_CellContentClick);
            }
        }

        private void LoadReconciliation()
        {
            this.dtblReconciliations = this.accReconciliations.GetDataExpressReconciliationsForReceipt().Tables[0];
            this.dgrdvReconciliation.DataSource = this.dtblReconciliations;
            this.pageReconciliation.Text = "未结[" + dtblReconciliations.Rows.Count.ToString() + "]";
        }
      
        private void LoadReceipt()
        {
            int cnt = 0;
            this.dtblReceiptNotes = this.accReceiptNotes .GetDataExpressReceiptNotesDescPagesFreeSearch(1, this.pbar.PageSize, ref cnt, this.whereclause).Tables[0];
            this.dgrdvReceipt.DataSource = this.dtblReceiptNotes;
            this.pbar.Init(1, cnt);
            
            
        }
        void btnSearch_Click(object sender, EventArgs e)
        {
            this.whereclause = string.Empty;
            if (this.ckbNoteCodeFlag.Checked)
            {
                this.whereclause += " and (NoteCode like '%" + this.txtNoteCode.Text + "%')";
            }
            if (this.ckbReconciliationCodeFlag.Checked)
            {
                this.whereclause += " and (ReconciliationCode like '%" + this.txtReconciliationCode.Text + "%')";
            }
            if (this.ckbExpressFlag.Checked)
            {
                this.whereclause += " and (CompanyID=" + this.ctrlExpressID.CompanyID.ToString() + ")";
            }
            if (this.ckbDateNoteFlag.Checked)
            {
                this.whereclause += " and (DateNote>='" + this.dtpDateBegin.Value.ToShortDateString()
                    + "' and DateNote<='" + this.dtpDateEnd.Value.ToShortDateString() + "')";
            }
            this.LoadReceipt ();
        }

        void pbar_OnPageIndexChanged(object sender, EventArgs e)
        {
            int cnt = 0;
            this.dtblReceiptNotes  = this.accReceiptNotes .GetDataExpressReceiptNotesDescPagesFreeSearch(this.pbar.PageIndex, this.pbar.PageSize, ref cnt, this.whereclause).Tables[0];
            this.dgrdvReceipt.DataSource = this.dtblReceiptNotes;
        }
        void mItemRefresh_Click(object sender, EventArgs e)
        {
         
            if (this.cMenu.SourceControl == this.dgrdvReceipt)
            {
                this.LoadReceipt();
            }
            if (this.cMenu.SourceControl == this.dgrdvReconciliation)
            {
                this.LoadReconciliation();
            }
            
        }


        void dgrdvReceipt_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            long NoteID = (long)this.dtblReceiptNotes.DefaultView[irow]["NoteID"];
            if (this.dgrdvReceipt.Columns[icol].Name == this.ColumnlnkNoteCode.Name)
            {
                if (frmDetail == null)
                {
                    frmDetail = new JERPApp.Finance.Report.Bill.Product.FrmExpressReceiptNote();
                    new FrmStyle(frmDetail).SetPopFrmStyle(this);
                }
                frmDetail.Detail(NoteID);
                frmDetail.ShowDialog();
            }
            
        }

     

     
        void dgrdvReconciliation_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvReconciliation .Columns[icol].Name == this.ColumnbtnReconciliation.Name)
            {
                long ReconciliationID = (long)this.dtblReconciliations .DefaultView[irow]["ReconciliationID"];
                if (this.frmSettleAMTOper  == null)
                {
                    this.frmSettleAMTOper = new FrmExpressSettleAMTOper();
                    new FrmStyle(this.frmSettleAMTOper).SetPopFrmStyle(this);
                    this.frmSettleAMTOper.AffterSave += new FrmExpressSettleAMTOper.AffterSaveDelegate(frmReconciliationOper_AffterSave);
                 

                }
                this.frmSettleAMTOper.ReceiptOper (ReconciliationID);
                this.frmSettleAMTOper.ShowDialog();
            }
        }

        void frmReconciliationOper_AffterSave()
        {
            this.whereclause = string.Empty;
            this.LoadReconciliation();
            this.LoadReceipt ();
        }
    }
}