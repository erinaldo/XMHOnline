using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Report.Bill.Material
{
    public partial class FrmOutSrcLossSupplyInvoice : Form
    {
        public FrmOutSrcLossSupplyInvoice()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accSupplyItems = new JERPData.Material.OutSrcLossSupplyItems();
            this.InvoiceEntity = new JERPBiz.Material.OutSrcLossSupplyInvoiceEntity();
        }

        private JERPData.Material.OutSrcLossSupplyItems  accSupplyItems;
        private JERPBiz.Material.OutSrcLossSupplyInvoiceEntity InvoiceEntity;
        private DataTable dtblItems;
        public void Detail(long InvoiceID)
        {
            this.InvoiceEntity.LoadData(InvoiceID);
            this.txtInvoiceCode.Text = this.InvoiceEntity.InvoiceCode;
            this.txtInvoiceName.Text = this.InvoiceEntity.InvoiceName;
            this.txtDateNote.Text = this.InvoiceEntity.DateNote.ToShortDateString();
            this.txtCompanyAbbName.Text = this.InvoiceEntity.CompanyAbbName; 
            this.txtMoneyTypeName.Text = this.InvoiceEntity.MoneyTypeName;
            this.txtTotalAMT.Text = string.Format("{0:0.####}", this.InvoiceEntity.TotalAMT); 
            this.txtYear.Text = this.InvoiceEntity.Year.ToString();
            this.txtMonth.Text = this.InvoiceEntity.Month.ToString();
            this.dtblItems = this.accSupplyItems.GetDataOutSrcLossSupplyItemsByInvoiceID (InvoiceID).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
        }
    }
}