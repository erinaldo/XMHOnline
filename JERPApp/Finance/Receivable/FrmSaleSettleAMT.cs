using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Receivable
{
    public partial class FrmSaleSettleAMT : Form
    {
        public FrmSaleSettleAMT()
        {
            InitializeComponent();
            this.dgrdvReconciliation.AutoGenerateColumns = false;
            this.dgrdvReceipt.AutoGenerateColumns = false;
        
            this.ctrlQReceipt .SeachGridView =this.dgrdvReceipt ;
            this.ctrlQReconciliation .SeachGridView =this.dgrdvReconciliation ; 
            this.accReconciliations = new JERPData.Product.SaleReconciliations();
            this.accReceiptNotes = new JERPData.Product.SaleReceiptNotes(); 
            this.SetPermit();
        }
        private JERPData.Product.SaleReconciliations accReconciliations;
        private JERPData.Product.SaleReceiptNotes accReceiptNotes;
         
        private DataTable dtblReconciliations,  dtblReceiptNotes;
        private FrmSaleSettleAMTOper frmSettleAMTOper; 
        private JERPApp.Finance.Report.Bill.Product.FrmSaleReceiptNote frmDetail;
        private string whereclause = string.Empty;
         //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存  

        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(374);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(375);
            this.ColumnbtnReconciliation.Visible = this.enableSave; 
            if (this.enableBrowse)
            {
                this.dtpDateBegin.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                this.dtpDateEnd.Value = this.dtpDateBegin.Value.AddMonths(1).AddDays(-1);

                this.LoadReconciliation(); 
                this.LoadReceipt();
               
                this.dgrdvReconciliation.ContextMenuStrip = this.cMenu;
                this.dgrdvReceipt.ContextMenuStrip = this.cMenu;
              
                this.lnkRefreshAll.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkRefreshAll_LinkClicked);
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                this.dgrdvReceipt.CellContentClick += new DataGridViewCellEventHandler(dgrdvReceipt_CellContentClick);
                this.pbar.OnPageIndexChanged += new EventHandler(pbar_OnPageIndexChanged);
                this.btnSearch.Click += new EventHandler(btnSearch_Click);
            }
            if (this.enableSave)
            {
                   this.dgrdvReconciliation.CellContentClick += new DataGridViewCellEventHandler(dgrdvReconciliation_CellContentClick);
            }
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
            if (this.ckbCustomerFlag.Checked)
            {
                this.whereclause += " and (CompanyID=" + this.ctrlCustomerID.CompanyID.ToString() + ")";
            }
            if (this.ckbExpressFlag.Checked)
            {
                this.whereclause += " and (ExpressCompanyID=" + this.ctrlExpressID.CompanyID.ToString() + ")";
            }
            if (this.ckbDateNoteFlag.Checked)
            {
                this.whereclause += " and (DateNote>='" + this.dtpDateBegin.Value.ToShortDateString()
                    + "' and DateNote<='" + this.dtpDateEnd.Value.ToShortDateString() + "')";
            }
            this.LoadReceipt();
        }

        void lnkRefreshAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        { 
        
            this.LoadReceipt(); 
            this.LoadReconciliation(); 
        }


        private void LoadReconciliation()
        {
            this.dtblReconciliations = this.accReconciliations.GetDataSaleReconciliationsForReceipt().Tables[0];
            this.dgrdvReconciliation.DataSource = this.dtblReconciliations;
            this.pageReconciliation.Text = "未结算[" + dtblReconciliations.Rows.Count.ToString() + "]";
        }
        
        private void LoadReceipt()
        {
            int cnt = 0;
            this.dtblReceiptNotes = this.accReceiptNotes.GetDataSaleReceiptNotesDescPagesFreeSearch(1,this.pbar .PageSize ,ref cnt,this.whereclause  ).Tables[0];
            this.dgrdvReceipt.DataSource = this.dtblReceiptNotes;
            this.pbar.Init(1, cnt);
        }
        void pbar_OnPageIndexChanged(object sender, EventArgs e)
        {
            int cnt = 0;
            this.dtblReceiptNotes = this.accReceiptNotes.GetDataSaleReceiptNotesDescPagesFreeSearch(this.pbar.PageIndex , this.pbar.PageSize, ref cnt, this.whereclause).Tables[0];
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
            if (this.dgrdvReceipt.Columns[icol].Name == this.ColumnNoteCode.Name)
            {
                if (frmDetail == null)
                {
                    frmDetail = new JERPApp.Finance.Report.Bill.Product.FrmSaleReceiptNote();
                    new FrmStyle(frmDetail).SetPopFrmStyle(this);
                }
                frmDetail.Detail(NoteID);
                frmDetail.ShowDialog();
            }
            
        }

        void frmDelete_AffterSave()
        {
          
            this.LoadReceipt();
            this.LoadReconciliation();
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
                    this.frmSettleAMTOper = new FrmSaleSettleAMTOper();
                    new FrmStyle(this.frmSettleAMTOper).SetPopFrmStyle(this);
                    this.frmSettleAMTOper.AffterSave += new FrmSaleSettleAMTOper.AffterSaveDelegate(frmReconciliationOper_AffterSave);
                 

                }
                this.frmSettleAMTOper.ReceiptOper (ReconciliationID);
                this.frmSettleAMTOper.ShowDialog();
            }
        }

        void frmReconciliationOper_AffterSave()
        {
            this.LoadReconciliation();
            this.LoadReceipt ();
        }
    }
}