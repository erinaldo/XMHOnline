using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Report.Bill.Finance
{
    public partial class FrmPostageReceiptNote : Form 
    {
        public FrmPostageReceiptNote()
        {
            InitializeComponent();
            this.ReceiptEntity = new JERPBiz.Finance.PostageReceiptNoteEntity();
            this.btnExport.Click += new EventHandler(btnExport_Click);
            this.lnkReconciliationCode.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkReconciliationCode_LinkClicked);
        }

        private JERPBiz.Finance.PostageReceiptNoteEntity  ReceiptEntity;
        private FrmPostageReconciliation frmReconciliation;
        public  void DetailNote(long NoteID)
        {
            this.ReceiptEntity.LoadData(NoteID);
            this.txtNoteCode.Text = ReceiptEntity.NoteCode;
            this.txtDateNote.Text = ReceiptEntity.DateNote.ToShortDateString ();
            this.txtCompanyName.Text = ReceiptEntity.CompanyName;
            this.txtAmountAMT.Text = string.Format("{0:0.####}", ReceiptEntity.Amount );
            this.txtMakerPsn.Text = ReceiptEntity.MakerPsn;
            this.txtBankName.Text = this.ReceiptEntity.BankName;
            this.txtBankCode.Text = this.ReceiptEntity.BankCode;
            this.lnkReconciliationCode.Text = ReceiptEntity.ReconciliationCode;
           
        }

        void lnkReconciliationCode_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.frmReconciliation == null)
            {
                this.frmReconciliation = new FrmPostageReconciliation();
                new FrmStyle(frmReconciliation).SetPopFrmStyle(this);             
            }
            this.frmReconciliation.DetailNote(this.ReceiptEntity.ReconciliationID);
            this.frmReconciliation.ShowDialog();
        }


        void btnExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "快递邮费支付");
            excel.SetCellVal("A3", "供应商:" + this.txtCompanyName.Text);
            excel.SetCellVal("A4", "收据单号:" + this.txtNoteCode.Text );
            excel.SetCellVal("A5", "对账单号:" + this.lnkReconciliationCode.Text);
            excel.SetCellVal("A6", "支付金额:" + this.txtAmountAMT.Text + "        制单人:" + this.txtMakerPsn.Text);
            excel.Show();
            FrmMsg.Hide();
        }
    }
}