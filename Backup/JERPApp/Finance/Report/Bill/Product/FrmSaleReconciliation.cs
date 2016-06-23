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
    public partial class FrmSaleReconciliation : Form
    {
        public FrmSaleReconciliation()
        {
            InitializeComponent();
            this.accReconciliations = new JERPData.Product.SaleReconciliations();
            this.accDeliverItems = new JERPData.Product.SaleDeliverItems();
            this.accRepairItems = new JERPData.Product.RepairDeliverItems();
            this.accReturnItems = new JERPData.Product.SaleReturnItems();
            this.accReplaceExpressAMT = new JERPData.Product.SaleReplaceExpressAMTRecord();
            this.ReconciliationEntity = new JERPBiz.Product.SaleReconciliationEntity();
            this.accFineAMT = new JERPData.Product.SaleFineAMTNotes();
            this.PrintHelper = new JERPBiz.Product.SaleReconciliationPrintHelper();
            this.dgrdvDeliver.AutoGenerateColumns = false;
            this.dgrdvReturn.AutoGenerateColumns = false;
            this.dgrdvFine.AutoGenerateColumns = false;
            this.dgrdvRepair.AutoGenerateColumns = false;
            this.dgrdvReplaceExpressAMT.AutoGenerateColumns = false;
            this.btnExplore.Click += new EventHandler(btnExplore_Click); 
            this.lnkFinishedAMT.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkFinishedAMT_LinkClicked);
        }

     
    
        private JERPData.Product.SaleReconciliations accReconciliations;
        private JERPData.Product.SaleDeliverItems accDeliverItems;
        private JERPData.Product.SaleReturnItems accReturnItems;
        private JERPData.Product.SaleFineAMTNotes accFineAMT;
        private JERPData.Product.RepairDeliverItems accRepairItems;
        private JERPBiz.Product.SaleReconciliationEntity ReconciliationEntity;
        private JERPBiz.Product.SaleReconciliationPrintHelper PrintHelper;
        private JERPData.Product.SaleReplaceExpressAMTRecord accReplaceExpressAMT;
        private FrmSaleReconciliationSettleRecord frmRecord;
        private DataTable dtblDeliverItems, dtblRepairItems, dtblReturnItems, dtblFineAMTs, dtblReplaceExpressAMT;
     
        private long ReconciliationID = -1;
        public void DetailNote(long ReconciliationID)
        {
            this.ReconciliationID = ReconciliationID;
            this.ReconciliationEntity.LoadData(ReconciliationID);
            this.txtReconciliationCode.Text = this.ReconciliationEntity.ReconciliationCode;
            this.txtReconciliationName.Text = this.ReconciliationEntity.ReconciliationName;
            this.txtYear.Text = this.ReconciliationEntity.Year.ToString();
            this.txtMonth.Text = this.ReconciliationEntity.Month.ToString();
            this.txtCompanyAbbName.Text = this.ReconciliationEntity.CompanyAbbName;
            this.txtFinanceAddress.Text = this.ReconciliationEntity.FinanceAddress;
            this.txtMoneyTypeName.Text = this.ReconciliationEntity.MoneyTypeName;
            this.txtSettleTypeName.Text = this.ReconciliationEntity.SettleTypeName;
            this.txtDateNote.Text  = this.ReconciliationEntity.DateNote .ToShortDateString ();
            this.txtTotalAMT.Text = string.Format("{0:#,##0.####}", this.ReconciliationEntity.TotalAMT);
            this.txtMakerPsn.Text = this.ReconciliationEntity.MakerPsn;
            this.LoadItems();
        }    
      
        private void LoadItems()
        {
            this.dtblDeliverItems = this.accDeliverItems.GetDataSaleDeliverItemsByReconciliationID(this.ReconciliationID).Tables[0];
            this.dgrdvDeliver.DataSource = this.dtblDeliverItems;

            this.dtblRepairItems = this.accRepairItems.GetDataRepairDeliverItemsByReconciliationID(this.ReconciliationID).Tables[0];
            this.dgrdvRepair.DataSource = this.dtblRepairItems;


            this.dtblReturnItems = this.accReturnItems.GetDataSaleReturnItemsByReconciliationID(this.ReconciliationID).Tables[0];
            this.dgrdvReturn.DataSource = this.dtblReturnItems;

            this.dtblFineAMTs = this.accFineAMT.GetDataSaleFineAMTNotesByReconciliationID(this.ReconciliationID).Tables[0];
            this.dgrdvFine.DataSource = this.dtblFineAMTs;

            this.dtblReplaceExpressAMT = this.accReplaceExpressAMT.GetDataSaleReplaceExpressAMTRecordByReconciliationID(this.ReconciliationID).Tables[0];
            this.dgrdvReplaceExpressAMT.DataSource = this.dtblReplaceExpressAMT;

  
        }

        void lnkFinishedAMT_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (frmRecord == null)
            {
                frmRecord = new FrmSaleReconciliationSettleRecord() ;
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