using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace JERPApp.Finance.Report.Bill.Finance
{
    public partial class FrmPostageReconciliation : Form
    {
        public FrmPostageReconciliation()
        {
            InitializeComponent();
            this.accDeliverNotes = new JERPData.Finance.PostageNotes();
            this.ReconciliationEntity = new JERPBiz.Finance .PostageReconciliationEntity();
            this.dgrdv.AutoGenerateColumns = false;
          
            this.btnExplore .Click +=new EventHandler(btnExplore_Click);
            this.lnkFinishedAMT.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkFinishedAMT_LinkClicked);
        }

        private JERPData.Finance.PostageNotes  accDeliverNotes;   
        private JERPBiz.Finance .PostageReconciliationEntity ReconciliationEntity;
        private DataTable dtblDeliverNotes;
        private FrmPostageReconciliationSettleRecord frmRecord;
        private long ReconciliationID = -1;
        public void DetailNote(long ReconciliationID)
        {
            this.ReconciliationID = ReconciliationID;
            this.ReconciliationEntity.LoadData(ReconciliationID);
            this.txtReconciliationCode.Text = this.ReconciliationEntity.ReconciliationCode;
            this.txtYear.Text = this.ReconciliationEntity.Year.ToString();
            this.txtMonth.Text = this.ReconciliationEntity.Month.ToString();
            this.txtCompanyName.Text = this.ReconciliationEntity.CompanyName  ;
            this.txtDateNote.Text = this.ReconciliationEntity.DateNote.ToShortDateString(); 
            this.txtDateSettle.Text = this.ReconciliationEntity.DateNote.ToShortDateString();
            this.txtMakerPsn.Text = this.ReconciliationEntity.MakerPsn;
            this.txtTotalAMT.Text = string.Format ("{0:#,##0.####}",this.ReconciliationEntity.TotalAMT);
            this.lnkFinishedAMT .Text = string.Format("{0:#,##0.####}", this.ReconciliationEntity.FinishedAMT );
            this.txtNonFinishedAMT .Text = string.Format("{0:#,##0.####}", this.ReconciliationEntity.NonFinishedAMT );
            this.LoadItems();
        }
        private void LoadItems()
        {
            this.dtblDeliverNotes = this.accDeliverNotes.GetDataPostageNotesByReconciliationID (this.ReconciliationID).Tables[0];
            this.dgrdv.DataSource = this.dtblDeliverNotes;

        }

        void lnkFinishedAMT_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (frmRecord == null)
            {
                frmRecord = new FrmPostageReconciliationSettleRecord();
                new FrmStyle(frmRecord).SetPopFrmStyle(this);               
            }
            frmRecord.DetailNote(this.ReconciliationID);
            frmRecord.ShowDialog();
        }
       
        void btnExplore_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "快递邮费对账单");
            excel.SetCellVal("A2", "对账单号:" + this.txtReconciliationCode .Text +
                "   物流公司:" + this.txtCompanyName .Text  + "   制单日期:" + this.txtDateNote.Text + "  年:" + this.txtYear.Text);
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(this.dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            FrmMsg.Hide();
            excel.Show();
        }
    
    }
}