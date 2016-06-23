using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Account
{
    public partial class FrmCashAccount : Form
    {
        public FrmCashAccount()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accAccount = new JERPData.Finance.CashAccount();  
        }
        private JERPData.Finance.CashAccount accAccount;
        private DataTable dtblRecord; 
        public void AccountRecord(int MoneyTypeID)
        {
            this.dtblRecord = this.accAccount.GetDataCashAccountLastRecord(MoneyTypeID ,50).Tables[0];
            this.dgrdv.DataSource = this.dtblRecord;
        }
      
   
    }
}