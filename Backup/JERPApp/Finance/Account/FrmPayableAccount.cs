using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Account
{
    public partial class FrmPayableAccount : Form
    {
        public FrmPayableAccount()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accAccount = new JERPData.Finance.PayableAccount(); 
        }
        private JERPData.Finance.PayableAccount  accAccount;
        private DataTable dtblRecords;
        public void AccountRecord(int CompanyID, int MoneyTypeID)
        {
            this.dtblRecords = this.accAccount.GetDataPayableAccountLastRecord (CompanyID,
                MoneyTypeID,
                50).Tables[0];
            this.dgrdv.DataSource = this.dtblRecords;
        }
    
    }
}