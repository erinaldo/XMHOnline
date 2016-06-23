using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Report.Bill.Product
{
    public partial class FrmSaleReceiptNote : Form
    {
        public FrmSaleReceiptNote()
        {
            InitializeComponent(); 
            this.ReceiptEntity = new JERPBiz.Product.SaleReceiptNoteEntity();
            this.printhelper = new JERPBiz.Product.SaleReceiptPrintHelper();
            this.lnkReconciliationCode.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkReconciliationCode_LinkClicked); 
         
            this.btnExport.Click += new EventHandler(btnExport_Click);
        }


        private JERPBiz.Product.SaleReceiptNoteEntity ReceiptEntity; 
        private JERPApp.Finance.Report.Bill.Product.FrmSaleReconciliation frmReconciliation; 
        private JERPBiz.Product.SaleReceiptPrintHelper printhelper; 
        private long NoteID = -1;
        public void Detail(long NoteID)
        {
            this.NoteID = NoteID;
            this.ReceiptEntity.LoadData(NoteID);
            this.txtNoteCode.Text = this.ReceiptEntity.NoteCode;
            this.txtDateNote.Text = this.ReceiptEntity.DateNote.ToShortDateString();
            this.txtCompanyAbbName.Text = this.ReceiptEntity.CompanyAbbName;
            this.txtExpressCompanyName.Text = this.ReceiptEntity.ExpressCompanyName;
            this.txtMoneyTypeName.Text = this.ReceiptEntity.MoneyTypeName;
            this.txtTotalAMT.Text = string.Format ("{0:0.####}",this.ReceiptEntity.TotalAMT);
            this.txtAdvanceAMT.Text = string.Format("{0:0.####}", this.ReceiptEntity.AdvanceAMT );
            this.txtAmount.Text = string.Format("{0:0.####}", this.ReceiptEntity.Amount);
             this.lnkReconciliationCode.Text = this.ReceiptEntity.ReconciliationCode;
            this.txtMakerPsn.Text = this.ReceiptEntity.MakerPsn;
            this.txtBankName.Text = this.ReceiptEntity.BankName;
            this.txtBankCode.Text = this.ReceiptEntity.BankCode; 
 
    
        }
     
        void lnkReconciliationCode_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.frmReconciliation == null)
            {
                this.frmReconciliation = new JERPApp.Finance.Report.Bill.Product.FrmSaleReconciliation();
                new FrmStyle(frmReconciliation).SetPopFrmStyle(this);
            }
            this.frmReconciliation.DetailNote(this.ReceiptEntity.ReconciliationID);
            this.frmReconciliation.ShowDialog();
        }

        void btnExport_Click(object sender, EventArgs e)
        {
            this.printhelper.ExportToExcel(this.NoteID);
        }
    }
}