using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Finance
{
    public partial class CtrlAccountType : UserControl
    {
        public CtrlAccountType()
        {
            InitializeComponent();
            this.dtblAccountType = new DataTable();
            this.dtblAccountType.Columns.Add("AccountTypeID", typeof(int));
            this.dtblAccountType.Columns.Add("AccountTypeName", typeof(string));

            this.dtblAccountType.Rows.Add(JERPBiz.Finance.AccountType.iCash, JERPBiz.Finance.AccountType.Cash);
            this.dtblAccountType.Rows.Add(JERPBiz.Finance.AccountType.iBank, JERPBiz.Finance.AccountType.Bank);
            this.dtblAccountType.Rows.Add(JERPBiz.Finance.AccountType.iReceivable, JERPBiz.Finance.AccountType.Receivable);
            this.dtblAccountType.Rows.Add(JERPBiz.Finance.AccountType.iExpressReceivable, JERPBiz.Finance.AccountType.ExpressReceivable);
            this.dtblAccountType.Rows.Add(JERPBiz.Finance.AccountType.iPayable, JERPBiz.Finance.AccountType.Payable);
            this.dtblAccountType.Rows.Add(JERPBiz.Finance.AccountType.iExpressPayable, JERPBiz.Finance.AccountType.ExpressPayable);
            this.dtblAccountType.Rows.Add(JERPBiz.Finance.AccountType.iExpense, JERPBiz.Finance.AccountType.Expense);
            this.dtblAccountType.Rows.Add(JERPBiz.Finance.AccountType.iRevenue, JERPBiz.Finance.AccountType.Revenue);

            this.cmbItem .DataSource = this.dtblAccountType;
            this.cmbItem.ValueMember = "AccountTypeID";
            this.cmbItem.DisplayMember = "AccountTypeName";
            this.cmbItem.SelectedIndexChanged += new EventHandler(cmbItem_SelectedIndexChanged);
        }
        public delegate void AffterSelectedDelegate();
        private AffterSelectedDelegate affterSelected;
        public event AffterSelectedDelegate AffterSelected
        {
            add
            {
                affterSelected += value;
            }
            remove
            {
                affterSelected -= value;
            }
        }
        private DataTable dtblAccountType;
        public  int AccountTypeID
        {
            get
            {
                if (this.cmbItem.SelectedIndex == -1) return -1;
                return (int)cmbItem.SelectedValue;
            }
            set
            {
                this.cmbItem.SelectedValue = value;
            }
        }
        public string  AccountTypeName
        {
            get
            {
                return this.cmbItem.Text;
            }
        }
        void cmbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.affterSelected != null) this.affterSelected();
        }
    }
}
