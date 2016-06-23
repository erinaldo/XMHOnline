using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace JERPApp.Finance.Report.Bill.Tool
{
    public partial class FrmBuyReconciliation : Form
    {
        public FrmBuyReconciliation()
        {
            InitializeComponent();
            this.accReceiveItems = new JERPData.Tool.BuyReceiveItems();
            this.accFineAMT = new JERPData.Tool.BuyFineAMTNotes();
            this.ReconciliationEntity = new JERPBiz.Tool.BuyReconciliationEntity();
            this.dgrdvReceive.AutoGenerateColumns = false;
            this.dgrdvFine.AutoGenerateColumns = false;
            this.btnExplore .Click +=new EventHandler(btnExplore_Click);
            this.lnkFinishedAMT.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkFinishedAMT_LinkClicked);
        }

        private JERPData.Tool.BuyReceiveItems accReceiveItems;
        private JERPData.Tool.BuyFineAMTNotes accFineAMT;
        private JERPBiz.Tool.BuyReconciliationEntity ReconciliationEntity;
        private DataTable dtblReceiveItems, dtblFineAMT;
        private FrmBuyReconciliationSettleRecord  frmRecord;
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
            this.txtMoneyTypeName.Text = this.ReconciliationEntity.MoneyTypeName;
            this.txtSettleTypeName.Text = this.ReconciliationEntity.SettleTypeName;          
            this.txtDateNote.Text = this.ReconciliationEntity.DateNote.ToShortDateString();
            this.txtDateSettle.Text = this.ReconciliationEntity.DateSettle.ToShortDateString();
            this.txtMakerPsn.Text = this.ReconciliationEntity.MakerPsn;
            this.txtTotalAMT.Text = string.Format ("{0:#,##0.####}",this.ReconciliationEntity.TotalAMT);
            this.lnkFinishedAMT .Text = string.Format("{0:#,##0.####}", this.ReconciliationEntity.FinishedAMT );
            this.txtNonFinishedAMT .Text = string.Format("{0:#,##0.####}", this.ReconciliationEntity.NonFinishedAMT );
            this.LoadItems();
        }
        private void LoadItems()
        {
            this.dtblReceiveItems = this.accReceiveItems.GetDataBuyReceiveItemsByReconciliationID(this.ReconciliationID).Tables[0];
            this.dgrdvReceive.DataSource = this.dtblReceiveItems;
    
            this.dtblFineAMT = this.accFineAMT.GetDataBuyFineAMTNotesByReconciliationID(this.ReconciliationID).Tables[0];
            this.dgrdvFine.DataSource = this.dtblFineAMT;
        }

        void lnkFinishedAMT_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (frmRecord == null)
            {
                frmRecord = new FrmBuyReconciliationSettleRecord();
                new FrmStyle(frmRecord).SetPopFrmStyle(this);               
            }
            frmRecord.SettleRecord (this.ReconciliationID);
            frmRecord.ShowDialog();
        }
       
        void btnExplore_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "治具采购对账单");
            excel.SetCellVal("A2", "对账单号:" + this.txtReconciliationCode .Text +
                "   供应商:" + this.txtCompanyAbbName .Text  + "   制单日期:" + this.txtDateNote.Text + "  年:" + this.txtYear.Text+
                "   月:" + this.txtMonth .Text + "  币种:"+this.txtMoneyTypeName  .Text +"  结算方式:"+this.txtSettleTypeName  .Text );
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(this.dgrdvReceive, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            FrmMsg.Hide();
            excel.Show();
        }
    
    }
}