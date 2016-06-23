using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Payable.Postage
{
    public partial class FrmSettleAMT : Form
    {
        public FrmSettleAMT()
        {
            InitializeComponent();
            this.dgrdvReconciliation.AutoGenerateColumns = false;
            this.dgrdvReceipt.AutoGenerateColumns = false;
            this.ctrlQReconciliation.SeachGridView = this.dgrdvReconciliation;
            this.accReconciliations = new JERPData.Finance.PostageReconciliations();
            this.accReceiptNotes = new JERPData.Finance.PostageReceiptNotes();
            this.SetPermit();
        }
        private JERPData.Finance.PostageReconciliations accReconciliations;
        private JERPData.Finance.PostageReceiptNotes accReceiptNotes;
        private DataTable dtblReconciliation, dtblReceiptNotes;
        private string whereclause=string.Empty ;
        private FrmSettleAMTOper frmOper;
        private JERPApp.Finance .Report.Bill.Finance.FrmPostageReceiptNote    frmDetail;
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存  
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(593);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(594);
         
            if (this.enableBrowse)
            {
                this.whereclause = string.Empty;
                this.LoadReceipt();
                this.LoadReconciliation();

                this.dtpDateBegin.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                this.dtpDateEnd.Value = this.dtpDateBegin.Value.AddMonths(1).AddDays(-1);

                this.dgrdvReconciliation.ContextMenuStrip = this.cMenu;
                this.dgrdvReceipt.ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                this.dgrdvReceipt.CellContentClick += new DataGridViewCellEventHandler(dgrdvReceipt_CellContentClick);
                this.pbar.OnPageIndexChanged += new EventHandler(pbar_OnPageIndexChanged);
              
                this.btnSearch.Click += new EventHandler(btnSearch_Click);
            }
            this.ColumnBtnSettle.Visible = this.enableSave;
            if (this.enableSave)
            {
                this.dgrdvReconciliation.CellContentClick += new DataGridViewCellEventHandler(dgrdvReconciliation_CellContentClick);
            }
        }

        void btnSearch_Click(object sender, EventArgs e)
        {

            this.whereclause = string.Empty;
            if (this.ckbNoteCode .Checked)
            {
                this.whereclause += " and (NoteCode like '%" + this.txtNoteCode.Text + "%')";
            }
            if (this.ckbReconciliationCode .Checked)
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
            this.LoadReceipt();
        }
        private void LoadReconciliation()
        {
            this.dtblReconciliation = this.accReconciliations.GetDataPostageReconciliationsNonFinishedAMT().Tables[0];
            this.dgrdvReconciliation.DataSource = this.dtblReconciliation;
            this.pageReconciliation.Text = "结款制单[" + this.dtblReconciliation.Rows.Count.ToString() + "]";
        }
        private void LoadReceipt()
        {
          
            int records=0;
            this.dtblReceiptNotes = this.accReceiptNotes .GetDataPostageReceiptNotesDescPagesFreeSearch  (1, this.pbar.PageSize, ref records,this.whereclause).Tables[0];
            this.dgrdvReceipt.DataSource = this.dtblReceiptNotes;
            this.pbar.Init(1, records);
        }
        void pbar_OnPageIndexChanged(object sender, EventArgs e)
        {
            int records = 0;
            this.dtblReceiptNotes = this.accReconciliations.GetDataPostageReconciliationsDescPagesSettleAMT(this.pbar.PageIndex, this.pbar.PageSize, ref records).Tables[0];
            this.dgrdvReceipt.DataSource = this.dtblReceiptNotes;
        }
        void mItemRefresh_Click(object sender, EventArgs e)
        {
            if (this.cMenu.SourceControl == this.dgrdvReceipt)
            {
                this.whereclause = string.Empty;
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
            if (this.dgrdvReceipt.Columns[icol].Name == this.ColumnlnkNoteCode .Name)
            {
                long NoteID = (long)this.dtblReceiptNotes.DefaultView[irow]["NoteID"];
                if (this.frmDetail == null)
                {
                    this.frmDetail = new JERPApp.Finance.Report.Bill.Finance.FrmPostageReceiptNote();
                    new FrmStyle(this.frmDetail).SetPopFrmStyle(this);
                  
                }
                this.frmDetail.DetailNote(NoteID);
                this.frmDetail.ShowDialog();
            }
        }

        void dgrdvReconciliation_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvReconciliation .Columns[icol].Name == this.ColumnBtnSettle  .Name)
            {
                long ReconciliationID = (long)this.dtblReconciliation .DefaultView[irow]["ReconciliationID"];
                if (this.frmOper  == null)
                {
                    this.frmOper = new FrmSettleAMTOper();
                    new FrmStyle(this.frmOper).SetPopFrmStyle(this);
                    this.frmOper.AffterSave += new FrmSettleAMTOper.AffterSaveDelegate(frmOper_AffterSave);

                }
                this.frmOper.SettleAMTOper (ReconciliationID);
                this.frmOper.ShowDialog();
            }
        }

        void frmOper_AffterSave()
        {
            this.LoadReceipt();
            this.LoadReconciliation();
        }
    }
}