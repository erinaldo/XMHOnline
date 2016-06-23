using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Report
{
    public partial class FrmBankAccountBalance : Form
    {
        public FrmBankAccountBalance()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accAccount = new JERPData.Finance.BankAccount();
            this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
            
        }     
        private JERPData.Finance.BankAccount accAccount;
        private DataTable dtblBalance;
        private FrmBankAccountRecord frmRecord;
        public void LoadData()
        {
            this.dtblBalance = this.accAccount.GetDataBankAccount().Tables[0];
            this.dgrdv.DataSource = this.dtblBalance;
        }
        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnBalanceAMT.Name)
            {
                int BankID = (int)this.dtblBalance.DefaultView[irow]["BankID"];
                int MoneyTypeID=(int)this.dtblBalance .DefaultView [irow]["MoneyTypeID"];
                if (frmRecord == null)
                {
                    frmRecord = new FrmBankAccountRecord();
                    new FrmStyle(frmRecord).SetPopFrmStyle(this);                  
                }
                frmRecord.LoadRecord(BankID,MoneyTypeID);
                frmRecord.ShowDialog();
            }
        }
    }
}