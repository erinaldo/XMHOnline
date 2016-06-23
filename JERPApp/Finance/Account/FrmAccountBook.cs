using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Account
{
    public partial class FrmAccountBook : Form
    {
        public FrmAccountBook()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accBankAccount = new JERPData.Finance.BankAccount();
            this.accCashAccount = new JERPData.Finance.CashAccount();
            this.accExpressPayableAccount = new JERPData.Finance.ExpressPayableAccount();
            this.accExpressReceivableAccount = new JERPData.Finance.ExpressReceivableAccount();
            this.accPayableAccount = new JERPData.Finance.PayableAccount();
            this.accReceivableAccount = new JERPData.Finance.ReceivableAccount();
            this.accRevenueAccount = new JERPData.Finance.RevenueAccount();
            this.accExpenseAccount = new JERPData.Finance.ExpenseAccount();
            this.SetPermit();
        }
        private DataTable dtblItems;
        private JERPData.Finance.CashAccount accCashAccount;
        private JERPData.Finance.BankAccount accBankAccount;
        private JERPData.Finance.ReceivableAccount accReceivableAccount;
        private JERPData.Finance.ExpressReceivableAccount accExpressReceivableAccount;
        private JERPData .Finance.PayableAccount accPayableAccount;
        private JERPData.Finance.ExpressPayableAccount accExpressPayableAccount;
        private JERPData.Finance.RevenueAccount accRevenueAccount;
        private JERPData.Finance.ExpenseAccount accExpenseAccount;

        private JERPApp.Define.Finance.FrmAccountTitle frmAccountTitle;
        private JERPApp.Define.Finance.FrmAccountTitle frmApppendTitle;

        FrmBankAccount frmBank;
        FrmCashAccount frmCash;
        FrmExpressPayableAccount frmExpressPayable;
        FrmExpressReceivableAccount frmExpressReceivable;
        FrmPayableAccount frmPayable;
        FrmReceivableAccount frmReceivable;
        FrmExpenseAccount frmExpense;
        FrmRevenueAccount frmRevenue;

           //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存  
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(601);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(602);
            if (this.enableBrowse)
            { 

                this.dtblItems = new DataTable();
                this.dtblItems.Columns.Add("Summary", typeof(string));
                this.dtblItems.Columns.Add("AccountTypeID", typeof(int));
                this.dtblItems.Columns.Add("AccountTypeName", typeof(string));
                this.dtblItems.Columns.Add("AccountTitleID", typeof(int));
                this.dtblItems.Columns.Add("AccountTitleName", typeof(string));
                this.dtblItems.Columns.Add("DebitAMT", typeof(decimal));
                this.dtblItems.Columns.Add("CreditAMT", typeof(decimal)); 
                this.dgrdv.DataSource = this.dtblItems; 
            }
            this.btnSave.Enabled = this.enableSave;
            if (this.enableSave)
            {
                this.btnAdd.Click += new EventHandler(btnAdd_Click);
                this.dgrdv.RowEnter += new DataGridViewCellEventHandler(dgrdv_RowEnter);
                this.dgrdv.CellContextMenuStripNeeded += new DataGridViewCellContextMenuStripNeededEventHandler(dgrdv_CellContextMenuStripNeeded);
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
                this.dgrdv.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdv_DataBindingComplete);
                this.btnSave.Click += new EventHandler(btnSave_Click);
            }
            
        }

        void dgrdv_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if ((this.dgrdv.Columns[icol].Name == this.ColumnAccountTypeName.Name)
                || (this.dgrdv.Columns[icol].Name == this.ColumnAccountTitleName.Name))
            {
                this.dgrdv.CurrentCell = this.dgrdv[icol, irow];
                if (frmAccountTitle == null)
                {
                    frmAccountTitle = new JERPApp.Define.Finance.FrmAccountTitle();
                    new FrmStyle(frmAccountTitle).SetPopFrmStyle(this);
                    frmAccountTitle.AffterSelected += new JERPApp.Define.Finance.FrmAccountTitle.AffterSelectedDelegate(frmAccountTitle_AffterSelected);
                }
                frmAccountTitle.ShowDialog();
            }
        }

        void frmAccountTitle_AffterSelected(int AccountTypeID, string AccountTypeName, int AccountTitleID, string AccountTitleName)
        {
            DataGridViewRow grow = this.dgrdv.CurrentRow;
            grow.Cells[this.ColumnAccountTypeID.Name].Value = AccountTypeID;
            grow.Cells[this.ColumnAccountTypeName.Name].Value = AccountTypeName;
            grow.Cells[this.ColumnAccountTitleID.Name].Value = AccountTitleID;
            grow.Cells[this.ColumnAccountTitleName.Name].Value = AccountTitleName;
            frmAccountTitle.Close();
        }

        void btnAdd_Click(object sender, EventArgs e)
        {
            if (frmApppendTitle  == null)
            {
                frmApppendTitle = new JERPApp.Define.Finance.FrmAccountTitle();
                new FrmStyle(frmApppendTitle).SetPopFrmStyle(this);
                frmApppendTitle.AffterSelected += new JERPApp.Define.Finance.FrmAccountTitle.AffterSelectedDelegate(frmApppendTitle_AffterSelected);
            }
            frmApppendTitle.ShowDialog();
        }

        void frmApppendTitle_AffterSelected(int AccountTypeID, string AccountTypeName, int AccountTitleID, string AccountTitleName)
        {
            DataRow drowNew = this.dtblItems.NewRow();
            drowNew["AccountTypeID"] = AccountTypeID;
            drowNew["AccountTypeName"] = AccountTypeName;
            drowNew["AccountTitleID"] = AccountTitleID;
            drowNew["AccountTitleName"] = AccountTitleName;
            this.dtblItems.Rows.Add(drowNew);
        }

        void dgrdv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow grow in this.dgrdv.Rows)
            {
                if (grow.IsNewRow) continue;
                grow.ErrorText = string.Empty;
                if (grow.Cells[this.ColumnAccountTypeID.Name].Value == DBNull.Value)
                {
                    grow.ErrorText = "类别不能为空";
                    continue ;
                }
                if (grow.Cells[this.ColumnAccountTitleID.Name].Value == DBNull.Value)
                {
                    if ((int)grow.Cells[this.ColumnAccountTypeID.Name].Value > JERPBiz .Finance .AccountType .iCash )
                    {
                        grow.ErrorText = "明细不能为空";
                        continue;
                    }
                }
                if (grow.Cells[this.ColumnSummary.Name].Value == DBNull.Value)
                {
                      grow.ErrorText = "摘要不能为空";
                      continue;                    
                }
                if ((grow.Cells[this.ColumnDebitAMT .Name].Value == DBNull.Value)
                    &&(grow.Cells[this.ColumnCreditAMT .Name].Value == DBNull.Value))
                {
                    grow.ErrorText = "金额不能为空";
                    continue;
                }
            }
        }

        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name ==this.ColumnlnkDetail .Name )
            {
                object objAccountTypeID = this.dgrdv[this.ColumnAccountTypeID.Name, irow].Value;
                object objAccountTitleID = this.dgrdv[this.ColumnAccountTitleID.Name, irow].Value;
                if ((objAccountTypeID ==null)||(objAccountTypeID == DBNull.Value)) return;
                int AccountTypeID = (int)objAccountTypeID;
                int MoneyTypeID=this.ctrlMoneyTypeID.MoneyTypeID ;
                if (AccountTypeID == JERPBiz.Finance .AccountType .iCash)
                {
                    if (frmCash == null)
                    {
                        frmCash = new FrmCashAccount();
                        new FrmStyle(frmCash).SetPopFrmStyle(this);
                    }
                    frmCash.AccountRecord(MoneyTypeID);
                    frmCash.ShowDialog();
                    return;
                }
                if ((objAccountTitleID == null) || (objAccountTitleID == DBNull.Value)) return;
                int AccountTitleID = (int)objAccountTitleID;
                if (AccountTypeID == JERPBiz.Finance.AccountType.iBank)
                {
                    if (frmBank == null)
                    {
                        frmBank = new FrmBankAccount();
                        new FrmStyle(frmBank).SetPopFrmStyle(this);                       
                    }
                    frmBank.AccountRecord(AccountTitleID, MoneyTypeID);
                    frmBank.ShowDialog();
                }
                if (AccountTypeID == JERPBiz.Finance.AccountType.iReceivable)
                {
                    if (frmReceivable == null)
                    {
                        frmReceivable = new FrmReceivableAccount();
                        new FrmStyle(frmReceivable).SetPopFrmStyle(this);
                    }
                    frmReceivable.AccountRecord(AccountTitleID, MoneyTypeID);
                    frmReceivable.ShowDialog();
                }
                if (AccountTypeID == JERPBiz.Finance.AccountType.iExpressReceivable)
                {
                    if (frmExpressReceivable == null)
                    {
                        frmExpressReceivable = new FrmExpressReceivableAccount();
                        new FrmStyle(frmExpressReceivable).SetPopFrmStyle(this);
                    }
                    frmExpressReceivable.AccountRecord(AccountTitleID, MoneyTypeID);
                    frmExpressReceivable.ShowDialog();
                }
                if (AccountTypeID == JERPBiz.Finance.AccountType.iPayable)
                {
                    if (frmPayable == null)
                    {
                        frmPayable = new FrmPayableAccount();
                        new FrmStyle(frmPayable).SetPopFrmStyle(this);
                    }
                    frmPayable.AccountRecord(AccountTitleID, MoneyTypeID);
                    frmPayable.ShowDialog();
                }
                if (AccountTypeID == JERPBiz.Finance.AccountType.iExpressPayable)
                {
                    if (frmExpressPayable == null)
                    {
                        frmExpressPayable = new FrmExpressPayableAccount();
                        new FrmStyle(frmExpressPayable).SetPopFrmStyle(this);
                    }
                    frmExpressPayable.AccountRecord(AccountTitleID, MoneyTypeID);
                    frmExpressPayable.ShowDialog();
                }
                if (AccountTypeID == JERPBiz.Finance.AccountType.iExpense)
                {
                    if (frmExpense == null)
                    {
                        frmExpense = new FrmExpenseAccount();
                        new FrmStyle(frmExpense).SetPopFrmStyle(this);
                    }
                    frmExpense.AccounRecord(AccountTitleID );
                    frmExpense.ShowDialog();
                }
                if (AccountTypeID == JERPBiz.Finance.AccountType.iRevenue)
                {
                    if (frmRevenue  == null)
                    {
                        frmRevenue = new FrmRevenueAccount();
                        new FrmStyle(frmRevenue).SetPopFrmStyle(this);
                    }
                    frmRevenue.AccountRecord (AccountTitleID);
                    frmRevenue.ShowDialog();
                }
            }

        }

        void dgrdv_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if((irow<1)||(icol==-1))return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnSummary.Name)
            {
                if ((this.dgrdv[icol, irow].Value == null)
                    || (this.dgrdv[icol, irow].Value == DBNull.Value))
                {
                    this.dgrdv[icol, irow].Value = this.dgrdv[icol, irow - 1].Value;
                }
            }
        }
        void dgrdv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnDebitAMT.Name)
            {
                object objDebitAMT = this.dgrdv[icol, irow].Value;
                if ((objDebitAMT != null) && (objDebitAMT != DBNull.Value))
                {
                    this.dgrdv[this.ColumnCreditAMT.Name, irow].Value = DBNull.Value;
                } 
            }
            if (this.dgrdv.Columns[icol].Name == this.ColumnCreditAMT.Name)
            {
                object objCreditAMT = this.dgrdv[icol, irow].Value;
                if ((objCreditAMT != null) && (objCreditAMT != DBNull.Value))
                {
                    this.dgrdv[this.ColumnDebitAMT.Name, irow].Value = DBNull.Value;
                }
            }
        }
        bool ValidateData()
        {
            if (this.ctrlMoneyTypeID.MoneyTypeID == -1)
            {
                MessageBox.Show("币种不能为空");
                return false;
            }
            DataRow[] drows = this.dtblItems.Select("DebitAMT is not null or CreditAMT is not null", "", DataViewRowState.CurrentRows);
            if(drows .Length ==0)
            {
                MessageBox.Show("不存在任何金额项");
                return false;
            }
            drows = this.dtblItems.Select("DebitAMT is null and CreditAMT is null", "", DataViewRowState.CurrentRows);
            if (drows .Length>0)
            {
                MessageBox.Show("存在金额不能为空项!");
                return false;
            }
            drows = this.dtblItems.Select("(AccountTypeID>1 and AccountTitleID is null) or (AccountTypeID is null)", "", DataViewRowState.CurrentRows);
            if (drows.Length > 0)
            {
                MessageBox.Show("存在账目不能为空项");
                return false;
            }
            drows = this.dtblItems.Select("Summary is null", "", DataViewRowState.CurrentRows);
            if (drows.Length > 0)
            {
                MessageBox.Show("摘要不能为空!");
                return false;
            }
            return true;
        }
        private void RegisterCashAccount(DataRow drow)
        {
            string errormsg = string.Empty;
            if (drow["DebitAMT"] != DBNull.Value)
            {
                this.accCashAccount.InsertCashAccountForDebit(ref errormsg,
                    drow["Summary"],
                    this.ctrlMoneyTypeID.MoneyTypeID,
                    drow["DebitAMT"],
                    JERPBiz.Frame.UserBiz.PsnID);
            }
            if (drow["CreditAMT"] != DBNull.Value)
            {
                this.accCashAccount.InsertCashAccountForCredit(ref errormsg,
                     drow["Summary"],
                    this.ctrlMoneyTypeID.MoneyTypeID,
                    drow["CreditAMT"],
                    JERPBiz.Frame.UserBiz.PsnID);
            }
        }
        private void RegisterBankAccount(DataRow drow)
        {
            string errormsg = string.Empty;
            if (drow["DebitAMT"] != DBNull.Value)
            {
                this.accBankAccount.InsertBankAccountForDebit (ref errormsg,
                    drow["Summary"],
                    drow["AccountTitleID"],
                    this.ctrlMoneyTypeID.MoneyTypeID,
                    drow["DebitAMT"],
                    JERPBiz.Frame.UserBiz.PsnID);
            }
            if (drow["CreditAMT"] != DBNull.Value)
            {
                this.accBankAccount.InsertBankAccountForCredit (ref errormsg,
                    drow["Summary"],
                    drow["AccountTitleID"],
                    this.ctrlMoneyTypeID.MoneyTypeID,
                    drow["CreditAMT"],
                    JERPBiz.Frame.UserBiz.PsnID);
            }
        }
        private void RegisterReceiveableAccount(DataRow drow)
        {
            string errormsg = string.Empty;
            if (drow["DebitAMT"] != DBNull.Value)
            {
                this.accReceivableAccount.InsertReceivableAccountForDebit (ref errormsg,
                    drow["Summary"],
                    drow["AccountTitleID"],
                    this.ctrlMoneyTypeID.MoneyTypeID,
                    drow["DebitAMT"],
                    JERPBiz.Frame.UserBiz.PsnID);
            }
            if (drow["CreditAMT"] != DBNull.Value)
            {
                this.accReceivableAccount.InsertReceivableAccountForCredit(ref errormsg,
                     drow["Summary"],
                     drow["AccountTitleID"],
                     this.ctrlMoneyTypeID.MoneyTypeID,
                     drow["CreditAMT"],
                     JERPBiz.Frame.UserBiz.PsnID);
            }
        }
        private void RegisterExpressReceiveableAccount(DataRow drow)
        {
            string errormsg = string.Empty;
            if (drow["DebitAMT"] != DBNull.Value)
            {
                this.accExpressReceivableAccount.InsertExpressReceivableAccountForDebit (ref errormsg,
                    drow["Summary"],
                    drow["AccountTitleID"],
                    this.ctrlMoneyTypeID.MoneyTypeID,
                    drow["DebitAMT"],
                    JERPBiz.Frame.UserBiz.PsnID);
            }
            if (drow["CreditAMT"] != DBNull.Value)
            {
                this.accExpressReceivableAccount.InsertExpressReceivableAccountForCredit(ref errormsg,
                     drow["Summary"],
                     drow["AccountTitleID"],
                     this.ctrlMoneyTypeID.MoneyTypeID,
                     drow["CreditAMT"],
                     JERPBiz.Frame.UserBiz.PsnID);
            }
        }
        private void RegisterPayableAccount(DataRow drow)
        {
            string errormsg = string.Empty;
            if (drow["DebitAMT"] != DBNull.Value)
            {
                this.accPayableAccount.InsertPayableAccountForDebit (ref errormsg,
                    drow["Summary"],
                    drow["AccountTitleID"],
                    this.ctrlMoneyTypeID.MoneyTypeID,
                    drow["DebitAMT"],
                    JERPBiz.Frame.UserBiz.PsnID);
            }
            if (drow["CreditAMT"] != DBNull.Value)
            {
                this.accPayableAccount.InsertPayableAccountForCredit (ref errormsg,
                     drow["Summary"],
                     drow["AccountTitleID"],
                     this.ctrlMoneyTypeID.MoneyTypeID,
                     drow["CreditAMT"],
                     JERPBiz.Frame.UserBiz.PsnID);
            }
        }
        private void RegisterExpressPayableAccount(DataRow drow)
        {
            string errormsg = string.Empty;
            if (drow["DebitAMT"] != DBNull.Value)
            {
                this.accExpressPayableAccount.InsertExpressPayableAccountForDebit(ref errormsg,
                    drow["Summary"],
                    drow["AccountTitleID"],
                    this.ctrlMoneyTypeID.MoneyTypeID,
                    drow["DebitAMT"],
                    JERPBiz.Frame.UserBiz.PsnID);
            }
            if (drow["CreditAMT"] != DBNull.Value)
            {
                this.accExpressPayableAccount.InsertExpressPayableAccountForCredit(ref errormsg,
                     drow["Summary"],
                     drow["AccountTitleID"],
                     this.ctrlMoneyTypeID.MoneyTypeID,
                     drow["CreditAMT"],
                     JERPBiz.Frame.UserBiz.PsnID);
            }
        }
        private void RegisterExpenseAccount(DataRow drow)
        {
            string errormsg = string.Empty;
            if (drow["DebitAMT"] != DBNull.Value)
            {
                this.accExpenseAccount .InsertExpenseAccountForDebit (ref errormsg,
                    drow["Summary"],
                    drow["AccountTitleID"], 
                    (decimal)drow["DebitAMT"]*this.ctrlMoneyTypeID .ExchangeRate,
                    JERPBiz.Frame.UserBiz.PsnID);
            }
            if (drow["CreditAMT"] != DBNull.Value)
            {
                this.accExpenseAccount .InsertExpenseAccountForCredit (ref errormsg,
                     drow["Summary"],
                     drow["AccountTitleID"],
                     (decimal)drow["CreditAMT"] * this.ctrlMoneyTypeID.ExchangeRate,
                     JERPBiz.Frame.UserBiz.PsnID);
            }
        }
        private void RegisterRevenueAccount(DataRow drow)
        {
            string errormsg = string.Empty;
            if (drow["DebitAMT"] != DBNull.Value)
            {
                this.accRevenueAccount .InsertRevenueAccountForDebit (ref errormsg,
                    drow["Summary"],
                    drow["AccountTitleID"],
                    (decimal)drow["DebitAMT"] * this.ctrlMoneyTypeID.ExchangeRate,
                    JERPBiz.Frame.UserBiz.PsnID);
            }
            if (drow["CreditAMT"] != DBNull.Value)
            {
                this.accRevenueAccount .InsertRevenueAccountForCredit (ref errormsg,
                     drow["Summary"],
                     drow["AccountTitleID"],
                     (decimal)drow["CreditAMT"] * this.ctrlMoneyTypeID.ExchangeRate,
                     JERPBiz.Frame.UserBiz.PsnID);
            }
        }
        void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateData() == false) return;
            DialogResult rut = MessageBox.Show("将对应收款进行保存，一经入账不能变更,确认否?", "保存确认", MessageBoxButtons.YesNo , MessageBoxIcon.Question);
            if (rut == DialogResult.No) return;
            string errormsg = string.Empty;           
            int MoneyTypeID = this.ctrlMoneyTypeID.MoneyTypeID; 
            int AccountTypeID; 
            foreach (DataRow drow in this.dtblItems.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                AccountTypeID = (int)drow["AccountTypeID"]; 
                if (AccountTypeID == JERPBiz.Finance .AccountType .iCash)
                {
                    this.RegisterCashAccount(drow);
                }
                if (AccountTypeID == JERPBiz.Finance.AccountType.iBank)
                {
                    this.RegisterBankAccount(drow);
                }
                if (AccountTypeID == JERPBiz.Finance.AccountType.iReceivable)
                {
                    this.RegisterReceiveableAccount(drow);
                }
                if (AccountTypeID == JERPBiz.Finance.AccountType.iExpressReceivable)
                {
                    this.RegisterExpressReceiveableAccount(drow);
                }
                if (AccountTypeID == JERPBiz.Finance.AccountType.iPayable)
                {
                    this.RegisterPayableAccount (drow);
                }
                if (AccountTypeID == JERPBiz.Finance.AccountType.iExpressPayable)
                {
                    this.RegisterExpressPayableAccount (drow);
                }
                if (AccountTypeID == JERPBiz.Finance.AccountType.iExpense)
                {
                    this.RegisterExpenseAccount (drow);
                }
                if (AccountTypeID == JERPBiz.Finance.AccountType.iRevenue)
                {
                    this.RegisterRevenueAccount (drow);
                }

            }
            MessageBox.Show("成功保存并入账");
            this.dtblItems.Clear();


        }
    }
}