using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Report
{
    public partial class FrmOtherResBuyFineAMTRecord : Form
    {
        public FrmOtherResBuyFineAMTRecord()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accFineAMT = new JERPData.OtherRes.BuyFineAMTNotes();
        }
        private JERPData.OtherRes .BuyFineAMTNotes accFineAMT;
        private DataTable dtblFineAMT;
        public void FineRecord(int Year, int Month,int CompanyID, int MoneyTypeID)
        {
            this.dtblFineAMT = this.accFineAMT.GetDataBuyFineAMTNotesMonthRecord(
                Year, Month, CompanyID, MoneyTypeID).Tables[0];
            this.dgrdv.DataSource = this.dtblFineAMT;
        }
    }
}