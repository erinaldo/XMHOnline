using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Report.Bill.Material
{
    public partial class FrmBuyInvoice : Form
    {
        public FrmBuyInvoice()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accReceiveItems = new JERPData.Material.BuyReceiveItems();
            this.InvoiceEntity = new JERPBiz.Material.BuyInvoiceEntity();
        }

        private JERPData.Material.BuyReceiveItems accReceiveItems;
        private JERPBiz.Material.BuyInvoiceEntity InvoiceEntity;
        private DataTable dtblItems;
        public void Detial(long InvoiceID)
        {
            this.InvoiceEntity.LoadData(InvoiceID);
            this.txtInvoiceCode.Text = this.InvoiceEntity.InvoiceCode;
            this.txtInvoiceName.Text = this.InvoiceEntity.InvoiceName;
            this.txtDateNote.Text = this.InvoiceEntity.DateNote.ToShortDateString();
            this.txtCompanyAbbName.Text = this.InvoiceEntity.CompanyAbbName;
            this.txtInvoiceTypeName.Text = this.InvoiceEntity.InvoiceTypeName;
            this.txtMoneyTypeName.Text = this.InvoiceEntity.MoneyTypeName;
            this.txtTotalAMT.Text = string.Format("{0:0.####}", this.InvoiceEntity.TotalAMT);
            this.txtTaxAMT.Text = string.Format("{0:0.####}", this.InvoiceEntity.TaxAMT);
            this.txtYear.Text = this.InvoiceEntity.Year.ToString();
            this.txtMonth.Text = this.InvoiceEntity.Month.ToString();
            this.dtblItems = this.accReceiveItems.GetDataBuyReceiveItemsByInvoiceID(InvoiceID).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
        }
    }
}