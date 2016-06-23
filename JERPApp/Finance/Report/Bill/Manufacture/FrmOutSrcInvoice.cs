using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Report.Bill.Manufacture
{
    public partial class FrmOutSrcInvoice : Form
    {
        public FrmOutSrcInvoice()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accReceiveItems = new JERPData.Manufacture.OutSrcReceiveItems();
            this.InvoiceEntity = new JERPBiz.Manufacture.OutSrcInvoiceEntity();
        }

        private JERPData.Manufacture.OutSrcReceiveItems accReceiveItems;
        private JERPBiz.Manufacture.OutSrcInvoiceEntity InvoiceEntity;
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
            this.dtblItems = this.accReceiveItems.GetDataOutSrcReceiveItemsByInvoiceID(InvoiceID).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
        }
    }
}