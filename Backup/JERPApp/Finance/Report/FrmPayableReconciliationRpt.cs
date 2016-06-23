using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Report
{
    public partial class FrmPayableReconciliationRpt : Form
    {
        public FrmPayableReconciliationRpt()
        {
            InitializeComponent();
         
            this.ctrlYear.Year = DateTime.Now.Year;
            this.SetPermit();
        }      
   
        //È¨ÏÞÂë
        private bool enableBrowse = false;//ä¯ÀÀ
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(109);
            if (this.enableBrowse)
            {
             
                this.LoadData();
                this.ctrlYear.OnSelected += this.LoadData;             
            }
        }
       
    
        private void LoadData()
        {
            this.ctrlMtrBuyReconciliationRpt.ReconciliationRpt(this.ctrlYear.Year);
            this.ctrlOtherResBuyReconciliationRpt.ReconciliationRpt(this.ctrlYear.Year);
            this.ctrlOutSrcReconciliationRpt.ReconciliationRpt(this.ctrlYear.Year); 
            this.ctrlPostageReconciliationRpt.ReconciliationRpt(this.ctrlYear.Year);
            this.ctrlPrdBuyReconciliationRpt.ReconciliationRpt(this.ctrlYear.Year);
            this.ctrlToolBuyReconciliationRpt.ReconciliationRpt(this.ctrlYear.Year);
        }
     
    }
}