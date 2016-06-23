using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Report
{
    public partial class FrmReceivableReceiptRpt : Form
    {
        public FrmReceivableReceiptRpt()
        {
            InitializeComponent();
            this.SetPermit();
        }
        private bool enableBrowse = false;
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(741);
            if (this.enableBrowse)
            {
                this.ctrlReceivableCashSettleRpt.LoadData();
                this.ctrlReceivableReconciliationSettleRpt.LoadData();
            }


        }
    }
}