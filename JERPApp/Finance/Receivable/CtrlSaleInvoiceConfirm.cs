using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Receivable
{
    public partial class CtrlSaleInvoiceConfirm : UserControl
    {
        public CtrlSaleInvoiceConfirm()
        {
            InitializeComponent();
            this.dtpDateBegin.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            this.dtpDateEnd.Value = this.dtpDateBegin.Value.AddMonths(1).AddDays(-1);
            this.dgrdvNonConfirm.AutoGenerateColumns = false;
            this.ctrlQFindNonConfirm.SeachGridView = this.dgrdvNonConfirm;
            this.dgrdvConfirm.AutoGenerateColumns = false;
            this.accInvoices = new JERPData.Product.SaleInvoices();
            this.whereclause = this.iniwhereclause;
            this.dgrdvNonConfirm.ContextMenuStrip = this.cMenu;
            this.dgrdvConfirm.ContextMenuStrip = this.cMenu;
            this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
           
            this.pbar.OnPageIndexChanged += new EventHandler(pbar_OnPageIndexChanged);
            this.btnSearch.Click += new EventHandler(btnSearch_Click);
            this.dgrdvConfirm.CellContentClick += new DataGridViewCellEventHandler(dgrdvConfirm_CellContentClick);
            this.dgrdvNonConfirm.CellContentClick += new DataGridViewCellEventHandler(dgrdvNonConfirm_CellContentClick);
        }
        private JERPData.Product.SaleInvoices accInvoices;
        private DataTable  dtblNonConfirms,dtblConfirms;
        private FrmSaleInvoiceConfirmOper frmOper;
        private JERPApp.Finance.Report.Bill.Product.FrmSaleInvoice frmDetail;
        private string whereclause = string.Empty;
        private string iniwhereclause = " and (ConfirmPsnID is not null)";
        public void LoadData()
        {
            this.LoadNonConfirm();
            this.LoadConfirm();
        }
        public delegate void AffterRefreshDelegate(int count);
        private AffterRefreshDelegate affterRefresh;
        public event AffterRefreshDelegate AffterRefresh
        {
            add
            {
                affterRefresh += value;
            }
            remove
            {
                affterRefresh -= value;
            }
        }
     
        private void LoadNonConfirm()
        {         
            this.dtblNonConfirms = this.accInvoices.GetDataSaleInvoicesNonConfirm().Tables[0];
            this.dgrdvNonConfirm.DataSource = this.dtblNonConfirms;
            if (this.affterRefresh != null) this.affterRefresh(this.dtblNonConfirms.Rows.Count);
           
        }
        private void LoadConfirm()
        {
            int cnt=0;
            this.dtblConfirms = this.accInvoices.GetDataSaleInvoicesDescPagesFreeSearch(1, this.pbar.PageSize, ref cnt, this.whereclause).Tables[0];
            this.dgrdvConfirm.DataSource = this.dtblConfirms;
            this.pbar.Init(1, cnt);
        }
        void pbar_OnPageIndexChanged(object sender, EventArgs e)
        {
            int cnt = 0;
            this.dtblConfirms = this.accInvoices.GetDataSaleInvoicesDescPagesFreeSearch(this.pbar .PageIndex , this.pbar.PageSize, ref cnt, this.whereclause).Tables[0];
            this.dgrdvConfirm.DataSource = this.dtblConfirms;
        }
        void mItemRefresh_Click(object sender, EventArgs e)
        {
            if (this.cMenu.SourceControl == this.dgrdvNonConfirm)
            {
                this.LoadNonConfirm();
            }
            if (this.cMenu.SourceControl == this.dgrdvConfirm)
            {
                this.whereclause = this.iniwhereclause;
                this.LoadConfirm();
            }
        }

        void btnSearch_Click(object sender, EventArgs e)
        {
            this.whereclause = this.iniwhereclause;
            if (this.ckbInvoiceCode.Checked)
            {
                this.whereclause += " and (InvoiceCode like '%" + this.txtInvoiceCode.Text + "%')";
            }
            if (this.ckbCompany.Checked)
            {
                this.whereclause += " and (CompanyID=" + this.ctrlCustomerID.CompanyID.ToString() + ")";
            }
            if (this.ckbMoneyType .Checked)
            {
                this.whereclause += " and (MoneyTypeID=" + this.ctrlMoneyTypeID.MoneyTypeID .ToString() + ")";
            }
            if (this.ckbInvoiceType .Checked)
            {
                this.whereclause += " and (InvoiceTypeID=" + this.ctrlInvoiceTypeID.InvoiceTypeID .ToString() + ")";
            }
            if (this.ckbDateNote.Checked)
            {
                this.whereclause += " and (DateNote>='" + this.dtpDateBegin.Value.ToShortDateString() + "' and DateNote<='" + this.dtpDateEnd.Value.ToShortDateString() + "')";
            }
            this.LoadConfirm();
        }

        void dgrdvConfirm_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvConfirm .Columns[icol].Name == this.ColumnlnkInvoiceCode.Name)
            {
                long InvoiceID = (long)this.dtblConfirms .DefaultView[irow]["InvoiceID"];
                if (frmDetail == null)
                {
                    frmDetail = new JERPApp.Finance.Report.Bill.Product.FrmSaleInvoice();
                    new FrmStyle(frmDetail).SetPopFrmStyle(this.ParentForm );
                }
                frmDetail.DetailNote (InvoiceID);
                frmDetail.ShowDialog();
            }
        }    
        void dgrdvNonConfirm_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;          
            if (this.dgrdvNonConfirm.Columns[icol].Name == this.ColumnbtnConfirm.Name)
            {
                long InvoiceID = (long)this.dtblNonConfirms.DefaultView[irow]["InvoiceID"];
                if (this.frmOper == null)
                {
                    this.frmOper = new FrmSaleInvoiceConfirmOper();
                    new FrmStyle(this.frmOper).SetPopFrmStyle(this.ParentForm );
                    this.frmOper.AffterSave += frmOper_AffterSave;
                }
                this.frmOper.ConfirmOper (InvoiceID);
                this.frmOper.ShowDialog();
            }
        }

        void frmOper_AffterSave()
        {
            this.whereclause = this.iniwhereclause;
            this.LoadConfirm();
            this.LoadNonConfirm();
        }
    }
}