using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Report.Bill.Manufacture
{
    public partial class FrmOutSrcReconciliationSettleRecord : Form
    {
        public FrmOutSrcReconciliationSettleRecord()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accReceiptNotes = new JERPData.Manufacture.OutSrcReceiptNotes();
        }
        private JERPData.Manufacture.OutSrcReceiptNotes   accReceiptNotes;
        private DataTable dtblRecords;
        public void SettleRecord(long ReconciliationID)
        {
            this.dtblRecords = this.accReceiptNotes.GetDataOutSrcReceiptNotesByReconciliationID (ReconciliationID).Tables[0];
            this.dgrdv.DataSource = this.dtblRecords;
        }
    }
}