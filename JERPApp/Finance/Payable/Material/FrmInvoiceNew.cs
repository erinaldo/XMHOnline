using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Payable.Material
{
    public partial class FrmInvoiceNew : Form
    {
        public FrmInvoiceNew()
        {
            InitializeComponent();
            this.dtpDateNote.Value = DateTime.Now.Date;
            this.ctrlYear.Year = DateTime.Now.Year;
            this.ctrlMonth.Month = DateTime.Now.Month;
            this.ctrlYear.OnSelected += this.SetCaption;
            this.ctrlMonth.OnSelected += this.SetCaption;
            this.SetCaption();
            this.accInvoice = new JERPData.Material.BuyInvoices();
            this.btnSave.Click += new EventHandler(btnSave_Click);
        }
        private JERPData.Material.BuyInvoices accInvoice;
        public delegate void AffterSaveDelegate(long InvoiceID);
        private AffterSaveDelegate affterSave;
        public event AffterSaveDelegate AffterSave
        {
            add
            {
                affterSave += value;
            }
            remove
            {
                affterSave -= value;
            }
        }
        public void New()
        {
            this.txtInvoiceCode.Text = string.Empty;
          
        }
        private void SetCaption()
        {
            this.txtInvoiceName.Text = this.ctrlYear.Year.ToString() + "年" + this.ctrlMonth.Month.ToString() + "月发票";
        }
        void btnSave_Click(object sender, EventArgs e)
        {
             DialogResult rut = MessageBox.Show("你将新增发票单，一经保存，供应商、币种、年、月、发票类型不能变更，确认否?", "新增确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
             if (rut == DialogResult.Yes)
             {
                 object objInvoiceID = DBNull.Value;
                 string errormsg=string.Empty ;
                 bool flag=this.accInvoice.InsertBuyInvoices(
                     ref errormsg,
                     ref objInvoiceID,
                     this.txtInvoiceCode.Text,
                     this.txtInvoiceName.Text,
                     this.ctrlYear.Year,
                     this.ctrlMonth.Month,
                     this.dtpDateNote.Value.Date,
                     this.ctrlSupplierID.CompanyID,
                     this.ctrlMoneyTypeID.MoneyTypeID,
                     this.ctrlInvoiceTypeID.InvoiceTypeID,
                     JERPBiz.Frame.UserBiz.PsnID);
                 if (flag)
                 {
                     MessageBox.Show("成功新增发票单");
                     if (this.affterSave != null) this.affterSave((long)objInvoiceID);
                     this.Close();
                 }
             }
              
        }
    }
}