using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Account
{
    public partial class FrmRevenueAccount : Form
    {
        public FrmRevenueAccount()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accRevenueAccount = new JERPData.Finance.RevenueAccount(); 
          
        }
        private JERPData.Finance.RevenueAccount accRevenueAccount; 
        private DataTable dtblRecords; 
        public void AccountRecord(int RevenueTypeID)
        {
             this.dtblRecords = this.accRevenueAccount.GetDataRevenueAccountLastRecord (RevenueTypeID ,                
                50).Tables[0];
            this.dgrdv.DataSource = this.dtblRecords;
        }
    
    }
}