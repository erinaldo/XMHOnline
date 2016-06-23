using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Report.Bill.Product
{
    public partial class FrmSaleReconciliationSettleRecord : Form
    {
        public FrmSaleReconciliationSettleRecord()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accReceiptNotes = new JERPData.Product.SaleReceiptNotes();
        }
        private JERPData.Product.SaleReceiptNotes  accReceiptNotes;
        private DataTable dtblRecords;
        public void SettleRecord(long ReconciliationID)
        {
            this.dtblRecords = this.accReceiptNotes .GetDataSaleReceiptNotesReconciliationSettleRecord(ReconciliationID).Tables[0];
            this.dgrdv.DataSource = this.dtblRecords;
        }
    }
}