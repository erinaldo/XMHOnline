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
    public partial class FrmRepairInvoice : Form
    {
        public FrmRepairInvoice()
        {
            InitializeComponent();
            this.accInvoices = new JERPData.Product.RepairInvoices();
            this.accDeliverItems = new JERPData.Product.RepairDeliverItems();
            this.InvoiceEntity = new JERPBiz.Product.RepairInvoiceEntity();
            this.printhelper = new JERPBiz.Product.RepairInvoicePrintHelper();
            this.dgrdv.AutoGenerateColumns = false;
            this.btnExplore .Click +=new EventHandler(btnExplore_Click);

        }

       
        private JERPData.Product.RepairInvoices accInvoices;
        private JERPData.Product.RepairDeliverItems accDeliverItems;
        private JERPBiz.Product.RepairInvoiceEntity InvoiceEntity;
        private JERPBiz.Product.RepairInvoicePrintHelper printhelper;
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
            this.dtblItems = this.accDeliverItems.GetDataRepairDeliverItemsByInvoiceID(this.InvoiceID).Tables[0];
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