using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Report
{
    public partial class FrmPayableReceiptRpt : Form
    {
        public FrmPayableReceiptRpt()
        {
            InitializeComponent();
            this.SetPermit();
        }
        private bool enableBrowse = false;
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(742);
            if (this.enableBrowse)
            {
                this.ctrlPayableCashSettleRpt .LoadData();
                this.ctrlPayableReconciliationReceiptRpt.LoadData();
            }


        }
    }
}