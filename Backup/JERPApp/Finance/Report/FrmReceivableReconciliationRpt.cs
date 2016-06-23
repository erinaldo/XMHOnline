using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Report
{
    public partial class FrmReceivableReconciliationRpt : Form
    {
        public FrmReceivableReconciliationRpt()
        {
            InitializeComponent();      
            this.ctrlYear.Year = DateTime.Now.Year;
            this.SetPermit();
        }
        //È¨ÏÞÂë
        private bool enableBrowse = false;//ä¯ÀÀ
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(77);
            if (this.enableBrowse)
            {
                this.LoadData();             
                this.ctrlYear.OnSelected += this.LoadData;             
            }
        }
     
        private void LoadData()
        {
            this.ctrlSaleReconciliationRpt.ReconciliationRpt(this.ctrlYear.Year);

        }
      
    }
}