using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Account
{
    public partial class FrmExpenseAccount : Form
    {
        public FrmExpenseAccount()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accExpenseAccount = new JERPData.Finance.ExpenseAccount();          
        }
        private JERPData.Finance.ExpenseAccount accExpenseAccount;
        private DataTable dtblRecords;
        public void AccounRecord(int ExpenseTypeID)
        {          
            this.dtblRecords = this.accExpenseAccount.GetDataExpenseAccountLastRecord (ExpenseTypeID ,                
                50).Tables[0];
            this.dgrdv.DataSource = this.dtblRecords;
        }
  
    

    }
}