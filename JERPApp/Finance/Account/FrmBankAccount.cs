using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Account
{
    public partial class FrmBankAccount : Form
    {
        public FrmBankAccount()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accAccount = new JERPData.Finance.BankAccount();
        }
        private JERPData.Finance.BankAccount accAccount;
        private DataTable dtblRecord;    
        public  void AccountRecord(int BankID,int MoneyTypeID)
        {
            this.dtblRecord = this.accAccount.GetDataBankAccountLastRecord(
                BankID ,
                MoneyTypeID ,50).Tables[0];
            this.dgrdv.DataSource = this.dtblRecord;
        } 
    }
}