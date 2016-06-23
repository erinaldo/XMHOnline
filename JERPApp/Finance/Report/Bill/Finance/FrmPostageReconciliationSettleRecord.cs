using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Report.Bill.Finance
{
    public partial class FrmPostageReconciliationSettleRecord : Form 
    {
        public FrmPostageReconciliationSettleRecord()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accPayingAMT = new JERPData.Finance.PostageReceiptNotes();
        }
        private JERPData.Finance.PostageReceiptNotes accPayingAMT;
        private DataTable dtblRecords;
        public  void DetailNote(long ReconciliationID)
        {
            this.dtblRecords = this.accPayingAMT.GetDataPostageReceiptNotesByReconciliationID(ReconciliationID).Tables[0];
            this.dgrdv.DataSource = this.dtblRecords;
        }
    }
}