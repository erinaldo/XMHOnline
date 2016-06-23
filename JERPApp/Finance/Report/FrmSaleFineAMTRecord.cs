using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Report
{
    public partial class FrmSaleFineAMTRecord : Form
    {
        public FrmSaleFineAMTRecord()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accFineAMT = new JERPData.Product.SaleFineAMTNotes();
        }
        private JERPData.Product.SaleFineAMTNotes accFineAMT;
        private DataTable dtblFineAMT;
        public void FineRecord(int Year, int Month,int CompanyID, int MoneyTypeID)
        {
            this.dtblFineAMT = this.accFineAMT.GetDataSaleFineAMTNotesMonthRecord(
                Year, Month, CompanyID, MoneyTypeID).Tables[0];
            this.dgrdv.DataSource = this.dtblFineAMT;
        }
    }
}