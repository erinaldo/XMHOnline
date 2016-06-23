using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace JERPApp.Finance.Report.Bill.Product
{
    public partial class FrmSaleInvoice : Form
    {
        public FrmSaleInvoice()
        {
            InitializeComponent();
            this.accInvoices = new JERPData.Product.SaleInvoices();
            this.accDeliverItems = new JERPData.Product.SaleDeliverItems();
            this.InvoiceEntity = new JERPBiz.Product.SaleInvoiceEntity();
            this.printhelper = new JERPBiz.Product.SaleInvoicePrintHelper();
            this.dgrdv.AutoGenerateColumns = false;
            this.btnExplore .Click +=new EventHandler(btnExplore_Click);

        }

       
        private JERPData.Product.SaleInvoices accInvoices;
        private JERPData.Product.SaleDeliverItems accDeliverItems;
        private JERPBiz.Product.SaleInvoiceEntity InvoiceEntity;
        private JERPBiz.Product.SaleInvoicePrintHelper printhelper;
        private DataTable dtblItems;
  
        private long InvoiceID = -1;
        public void DetailNote(long InvoiceID)
        {
            this.InvoiceID = InvoiceID;
            this.InvoiceEntity.LoadData(InvoiceID);
            this.txtInvoiceName.Text = this.InvoiceEntity.InvoiceName;
            this.txtInvoiceCode.Text = this.InvoiceEntity.InvoiceCode;
            this.txtYear.Text = this.InvoiceEntity.Year.ToString();
            this.txtMonth.Text = this.InvoiceEntity.Month.ToString();
            this.txtCompanyAbbName.Text = this.InvoiceEntity.CompanyAbbName;
            this.txtFinanceAddress.Text = this.InvoiceEntity.FinanceAddress;
            this.txtMoneyTypeName.Text = this.InvoiceEntity.MoneyTypeName;
            this.txtInvoiceTypeName.Text = this.InvoiceEntity.InvoiceTypeName ;
            this.txtTotalAMT.Text = string.Format("{0:0.####}", this.InvoiceEntity.TotalAMT);
            this.txtTaxAMT .Text = string.Format("{0:0.####}", this.InvoiceEntity.TaxAMT);
            this.txtDateNote.Text  = this.InvoiceEntity.DateNote .ToShortDateString ();
            this.txtMakerPsn.Text = this.InvoiceEntity.MakerPsn;
            this.LoadItems();
        }
        private void LoadItems()
        {
            this.dtblItems = this.accDeliverItems.GetDataSaleDeliverItemsByInvoiceID(this.InvoiceID).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
        }

        void btnExplore_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            this.printhelper.ExportToExcel(new long[] { this.InvoiceID });
            FrmMsg.Hide();
        }
    
    }
}