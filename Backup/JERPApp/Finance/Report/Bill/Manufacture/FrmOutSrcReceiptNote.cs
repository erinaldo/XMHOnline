using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Report.Bill.Manufacture
{
    public partial class FrmOutSrcReceiptNote : Form
    {
        public FrmOutSrcReceiptNote()
        {
            InitializeComponent(); 
            this.ReceiptEntity = new JERPBiz.Manufacture.OutSrcReceiptNoteEntity();
            this.lnkReconciliationCode.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkReconciliationCode_LinkClicked);  
        }

        private JERPBiz.Manufacture .OutSrcReceiptNoteEntity ReceiptEntity; 
        private FrmOutSrcReconciliation frmReconciliation;  
        private long NoteID = -1;
        public void Detail(long NoteID)
        {
            this.NoteID = NoteID;
            this.ReceiptEntity.LoadData(NoteID);
            this.txtNoteCode.Text = this.ReceiptEntity.NoteCode;
            this.txtDateNote.Text = this.ReceiptEntity.DateNote.ToShortDateString();
            this.txtCompanyAbbName.Text = this.ReceiptEntity.CompanyAbbName;
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
                this.frmReconciliation = new FrmOutSrcReconciliation();
                new FrmStyle(frmReconciliation).SetPopFrmStyle(this);
            }
            this.frmReconciliation.DetailNote(this.ReceiptEntity.ReconciliationID);
            this.frmReconciliation.ShowDialog();
        }

    }
}