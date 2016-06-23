using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Finance
{
    public partial class FrmAccountTitle : Form 
    {
        public FrmAccountTitle()
        {
            InitializeComponent();
            this.accBank = new JERPData.Finance.Bank();  
            this.accCustomer = new JERPData.General.Customer();
            this.accSupplier = new JERPData.General.Supplier();  
            this.accExpress = new JERPData.General.Express();
            this.accRevenueType = new JERPData.Finance.RevenueType();
            this.accExpenseType = new JERPData.Finance.ExpenseType();
            this.lsbAccountTitle.ValueMember = "AccountTitleID";
            this.lsbAccountTitle.DisplayMember = "AccountTitleName";
            this.ctrlAccountType.AffterSelected += new CtrlAccountType.AffterSelectedDelegate(ctrlAccountType_AffterSelected);
            this.btnSelect.Click += new EventHandler(btnSelect_Click);
            
        }

      
        private DataTable dtblAccountTitle;

        private JERPData.Finance.Bank accBank;
        private JERPData.General.Customer accCustomer;
        private JERPData.General.Express accExpress;
        private JERPData.General.Supplier accSupplier;
        private JERPData.Finance.RevenueType accRevenueType;
        private JERPData.Finance.ExpenseType accExpenseType;
        void ctrlAccountType_AffterSelected()
        {
            int AccountTypeID = this.ctrlAccountType.AccountTypeID;
            if (AccountTypeID == JERPBiz.Finance.AccountType.iCash)
            {
              
                dtblAccountTitle = new DataTable();
                dtblAccountTitle.Columns.Add("AccountTitleID", typeof(int));
                dtblAccountTitle.Columns.Add("AccountTitleName", typeof(string));
                this.lsbAccountTitle.DataSource = dtblAccountTitle;
                return;
            }

            if (AccountTypeID == JERPBiz.Finance.AccountType.iBank)
            {
                dtblAccountTitle = this.accBank.GetDataBank().Tables[0];
                dtblAccountTitle.Columns.Add("AccountTitleID", typeof(int), "BankID");
                dtblAccountTitle.Columns.Add("AccountTitleName", typeof(string), "ISNULL(BankName,'')+ISNULL(BankCode,'')");
                lsbAccountTitle.DataSource = dtblAccountTitle;
                return;
            }
            if (AccountTypeID == JERPBiz.Finance.AccountType.iReceivable)
            {
                dtblAccountTitle = this.accCustomer.GetDataCustomer().Tables[0];
                dtblAccountTitle.Columns.Add("AccountTitleID", typeof(int), "CompanyID");
                dtblAccountTitle.Columns.Add("AccountTitleName", typeof(string), "CompanyAbbName");
                lsbAccountTitle.DataSource = dtblAccountTitle;
                return;
            }
            if ((AccountTypeID == JERPBiz.Finance.AccountType.iExpressReceivable) ||
                (AccountTypeID == JERPBiz.Finance.AccountType.iExpressPayable))
            {
                dtblAccountTitle = this.accExpress.GetDataExpress().Tables[0];
                dtblAccountTitle.Columns.Add("AccountTitleID", typeof(int), "CompanyID");
                dtblAccountTitle.Columns.Add("AccountTitleName", typeof(string), "CompanyName");
                lsbAccountTitle.DataSource = dtblAccountTitle;
                return;
            }
            if (AccountTypeID == JERPBiz.Finance.AccountType.iPayable)
            {
                dtblAccountTitle = this.accSupplier.GetDataSupplier().Tables[0];
                dtblAccountTitle.Columns.Add("AccountTitleID", typeof(int), "CompanyID");
                dtblAccountTitle.Columns.Add("AccountTitleName", typeof(string), "CompanyAbbName");
                lsbAccountTitle.DataSource = dtblAccountTitle;
                return;
            }
            if (AccountTypeID == JERPBiz.Finance.AccountType.iExpense)
            {
                dtblAccountTitle = this.accExpenseType.GetDataExpenseType().Tables[0];
                dtblAccountTitle.Columns.Add("AccountTitleID", typeof(int), "ExpenseTypeID");
                dtblAccountTitle.Columns.Add("AccountTitleName", typeof(string), "ExpenseTypeName");
                lsbAccountTitle.DataSource = dtblAccountTitle;
                return;
            }
            if (AccountTypeID == JERPBiz.Finance.AccountType.iRevenue)
            {
                dtblAccountTitle = this.accRevenueType.GetDataRevenueType().Tables[0];
                dtblAccountTitle.Columns.Add("AccountTitleID", typeof(int), "RevenueTypeID");
                dtblAccountTitle.Columns.Add("AccountTitleName", typeof(string), "RevenueTypeName");
                lsbAccountTitle.DataSource = dtblAccountTitle;
                return;
            }
        }

        public delegate void AffterSelectedDelegate(int AccountTypeID,string AccountTypeName,
            int  AccountTitleID,string AccountTitleName);
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
        private bool ValidateData()
        {
            if ((this.ctrlAccountType.AccountTypeID != JERPBiz.Finance.AccountType.iCash)
                &&(this.lsbAccountTitle .SelectedIndex ==-1))
            {
                MessageBox.Show("未选择任何科目");
                return false;
            }
            return true;
        }
        void btnSelect_Click(object sender, EventArgs e)
        {
            if (ValidateData() == false) return;
            int AccountTitleID =-1;
            if (this.ctrlAccountType.AccountTypeID != JERPBiz.Finance.AccountType.iCash)
            {
                AccountTitleID = (int)this.lsbAccountTitle.SelectedValue;
            }
            if (this.affterSelected != null) this.affterSelected(
                this.ctrlAccountType.AccountTypeID,
                this.ctrlAccountType .AccountTypeName ,
                AccountTitleID,
                this.lsbAccountTitle .Text );
        }

    }
}
