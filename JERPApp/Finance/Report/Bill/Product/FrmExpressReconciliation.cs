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
    public partial class FrmExpressReconciliation : Form
    {
        public FrmExpressReconciliation()
        {
            InitializeComponent();
            this.accReconciliations = new JERPData.Product.ExpressReconciliations();
            this.ReconciliationEntity = new JERPBiz.Product.ExpressReconciliationEntity();
            this.PrintHelper = new JERPBiz.Product.ExpressReconciliationPrintHelper();
            this.accSaleReceiptNote = new JERPData.Product.SaleReceiptNotes();
            this.dgrdvReceipt .AutoGenerateColumns = false;
            this.btnExplore.Click += new EventHandler(btnExplore_Click); 
            this.lnkFinishedAMT.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkFinishedAMT_LinkClicked);
        }

     
    
        private JERPData.Product.ExpressReconciliations accReconciliations;
        private JERPBiz.Product.ExpressReconciliationEntity ReconciliationEntity;
        private JERPBiz.Product.ExpressReconciliationPrintHelper PrintHelper;
        private JERPData.Product.SaleReceiptNotes accSaleReceiptNote;
        private FrmExpressReconciliationSettleRecord frmRecord;
        private DataTable dtblReceiptNotes;
     
        private long ReconciliationID = -1;
        public void DetailNote(long ReconciliationID)
        {
            this.ReconciliationID = ReconciliationID;
            this.ReconciliationEntity.LoadData(ReconciliationID);
            this.txtReconciliationCode.Text = this.ReconciliationEntity.ReconciliationCode;
            this.txtReconciliationName.Text = this.ReconciliationEntity.ReconciliationName;
            this.txtYear.Text = this.ReconciliationEntity.Year.ToString();
            this.txtMonth.Text = this.ReconciliationEntity.Month.ToString();
            this.txtCompanyName.Text = this.ReconciliationEntity.CompanyName;
            this.txtMoneyTypeName.Text = this.ReconciliationEntity.MoneyTypeName;
            this.txtDateNote.Text  = this.ReconciliationEntity.DateNote .ToShortDateString ();
            this.txtTotalAMT.Text = string.Format("{0:#,##0.####}", this.ReconciliationEntity.TotalAMT);
            this.txtMakerPsn.Text = this.ReconciliationEntity.MakerPsn;
            this.dtblReceiptNotes = this.accSaleReceiptNote.GetDataSaleReceiptNotesByExpressReconciliationID(this.ReconciliationID).Tables[0];
            this.dgrdvReceipt.DataSource = this.dtblReceiptNotes;
        }    
      
        

        void lnkFinishedAMT_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (frmRecord == null)
            {
                frmRecord = new FrmExpressReconciliationSettleRecord();
                new FrmStyle(frmRecord).SetPopFrmStyle(this);
            }
            frmRecord.SettleRecord (this.ReconciliationID);
            frmRecord.ShowDialog();
        }

        void btnExplore_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            this.PrintHelper.ExportToExcel(new long[] { this.ReconciliationEntity.ReconciliationID });
            FrmMsg.Hide();
           
        }
    }
}