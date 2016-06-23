using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Common.Report.Bill
{
    public partial class FrmWorkingReport : Form
    {
        public FrmWorkingReport()
        {
            InitializeComponent();
            this.RecordEntity = new JERPBiz.General.WorkingReportEntity();
        }
        JERPBiz.General.WorkingReportEntity RecordEntity;
        public void Detail(long RecordID)
        {         
            this.RecordEntity.LoadData(RecordID);
            this.txtDateRecord .Text  = this.RecordEntity.DateReport .ToShortDateString ();
            this.txtPsnName.Text = this.RecordEntity.PsnName;
            this.txtReportTitle.Text = this.RecordEntity.ReportTitle ;
            this.rchReportContent.Text = this.RecordEntity.ReportContent ;
        }
    }
}