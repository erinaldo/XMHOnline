using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Report.Bill.OtherRes
{
    public partial class FrmBuyReconciliationSettleRecord : Form
    {
        public FrmBuyReconciliationSettleRecord()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accReceiptNotes = new JERPData.OtherRes.BuyReceiptNotes();
        }
        private JERPData.OtherRes.BuyReceiptNotes   accReceiptNotes;
        private DataTable dtblRecords;
        public void SettleRecord(long ReconciliationID)
        {
            this.dtblRecords = this.accReceiptNotes.GetDataBuyReceiptNotesByReconciliationID (ReconciliationID).Tables[0];
            this.dgrdv.DataSource = this.dtblRecords;
        }
    }
}