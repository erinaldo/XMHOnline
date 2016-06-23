using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Payable.OutSrc
{
    public partial class FrmSettleAMT : Form
    {
        public FrmSettleAMT()
        {
            InitializeComponent();
            this.dgrdvReconciliation.AutoGenerateColumns = false; 
            this.dgrdvReceipt .AutoGenerateColumns = false;
            this.accReceiptNotes = new JERPData.Manufacture.OutSrcReceiptNotes();
            this.accReconciliations = new JERPData.Manufacture.OutSrcReconciliations();
            this.SetPermit();
        }
        private JERPData.Manufacture.OutSrcReceiptNotes  accReceiptNotes;
        private JERPData.Manufacture.OutSrcReconciliations accReconciliations;
        private string whereclause = string.Empty;   
        private DataTable dtblReconciliations, dtblReceipts;
        private FrmSettleAMTOper  frmReconciliation; 
        private JERPApp.Finance.Report.Bill.Manufacture .FrmOutSrcReceiptNote frmReceiptNote;
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存  
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(149);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(150);
            if (this.enableBrowse)
            {
                this.dtpDateBegin.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                this.dtpDateEnd.Value = this.dtpDateBegin.Value.AddMonths(1).AddDays(-1);

                this.LoadReconciliation(); 
                this.LoadReceipt();
                this.btnSearch .Click +=new EventHandler(btnSearch_Click);
                this.dgrdvReconciliation.ContextMenuStrip = this.cMenu;
                this.dgrdvReceipt.ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                  this.pbar.OnPageIndexChanged += new EventHandler(pbar_OnPageIndexChanged);
            }

            this.ColumnbtnReconciliation.Visible = this.enableSave; 
            if (this.enableSave)
            {
                this.dgrdvReconciliation.CellContentClick += new DataGridViewCellEventHandler(dgrdvReconciliation_CellContentClick);

                this.dgrdvReceipt.CellContentClick += new DataGridViewCellEventHandler(dgrdvReceipt_CellContentClick);
            }
        }

        void dgrdvReceipt_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow=e.RowIndex ;
            int icol=e.ColumnIndex ;
            if((irow==-1)||(icol==-1))return;
            long NoteID=(long)this.dtblReceipts .DefaultView [irow]["NoteID"];
            if (this.dgrdvReceipt.Columns[icol].Name == this.ColumnlnkNoteCode.Name)
            {
                if (frmReceiptNote == null)
                {
                    frmReceiptNote = new JERPApp.Finance.Report.Bill.Manufacture.FrmOutSrcReceiptNote();
                    new FrmStyle(frmReceiptNote).SetPopFrmStyle(this);
                }
                frmReceiptNote.Detail(NoteID);
                frmReceiptNote.ShowDialog();
            }
        }

        private void LoadReconciliation()
        {
            this.dtblReconciliations = this.accReconciliations .GetDataOutSrcReconciliationsNonFinishedAMT ().Tables[0];
            this.dgrdvReconciliation.DataSource = this.dtblReconciliations;
            this.pageReconciliation.Text = "对账结款[" + this.dtblReconciliations.Rows.Count.ToString() + "]";

        }
      
        private void LoadReceipt()
        {
            int cnt = 0;
            this.dtblReceipts = this.accReceiptNotes .GetDataOutSrcReceiptNotesDescPagesFreeSearch (1, this.pbar.PageSize, ref cnt, this.whereclause).Tables[0];
            this.dgrdvReceipt.DataSource = this.dtblReceipts;
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
            if (this.ckbSupplierFlag.Checked)
            {
                this.whereclause += " and (CompanyID=" + this.ctrlCompanyID.CompanyID.ToString() + ")";
            }
          
            if (this.ckbDateNoteFlag.Checked)
            {
                this.whereclause += " and (DateNote>='" + this.dtpDateBegin.Value.ToShortDateString()
                    + "' and DateNote<='" + this.dtpDateEnd.Value.ToShortDateString() + "')";
            }
            this.LoadReceipt();
        }
   
        void pbar_OnPageIndexChanged(object sender, EventArgs e)
        {
            int cnt = 0;
            this.dtblReceipts = this.accReceiptNotes .GetDataOutSrcReceiptNotesDescPagesFreeSearch (this.pbar.PageIndex, this.pbar.PageSize, ref cnt, this.whereclause).Tables[0];
            this.dgrdvReceipt.DataSource = this.dtblReceipts;
        }
        void mItemRefresh_Click(object sender, EventArgs e)
        {
            if (this.cMenu.SourceControl == this.dgrdvReconciliation)
            {
                this.LoadReconciliation();
            }
            if (this.cMenu.SourceControl == this.dgrdvReceipt )
            {
                this.whereclause = string.Empty;
                this.LoadReceipt();
            }
         
        }

       
        void dgrdvReconciliation_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvReconciliation .Columns[icol].Name == this.ColumnbtnReconciliation.Name)
            {

                long ReconciliationID = (long)this.dtblReconciliations.DefaultView[irow]["ReconciliationID"];
                if (this.frmReconciliation   == null)
                {
                    this.frmReconciliation = new FrmSettleAMTOper();
                    new FrmStyle(this.frmReconciliation).SetPopFrmStyle(this);
                    this.frmReconciliation.AffterSave += new FrmSettleAMTOper.AffterSaveDelegate(frmReconciliation_AffterSave);

                }
                this.frmReconciliation.ReconciliationSettle(ReconciliationID);
                this.frmReconciliation.ShowDialog();
            }

            
        }

        void frmReconciliation_AffterSave()
        {
           
            this.LoadReconciliation();
            this.whereclause = string.Empty ;
            this.LoadReceipt();
        }

    

    }
}