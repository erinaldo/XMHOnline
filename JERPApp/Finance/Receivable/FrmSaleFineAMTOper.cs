using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Receivable
{
    public partial class FrmSaleFineAMTOper : Form
    {
        public FrmSaleFineAMTOper()
        {
            InitializeComponent();
            this.accCashAccount = new JERPData.Finance.CashAccount();
            this.accBankAccount = new JERPData.Finance.BankAccount();
            this.accReceivableAccount = new JERPData.Finance.ReceivableAccount();
            this.accNotes = new JERPData.Product.SaleFineAMTNotes();
            this.accExpenseAccount = new JERPData.Finance.ExpenseAccount();
            this.btnSave .Click +=new EventHandler(btnSave_Click);
        }

        private JERPData.Product.SaleFineAMTNotes accNotes;
        private JERPData.Finance.CashAccount accCashAccount;
        private JERPData.Finance.BankAccount accBankAccount;
        private JERPData.Finance.ExpenseAccount accExpenseAccount;
        private JERPData.Finance.ReceivableAccount accReceivableAccount;
        public delegate void AffterSaveDelegate();
        private AffterSaveDelegate affterSave;
        public event AffterSaveDelegate AffterSave
        {
            add
            {
                affterSave += value;
            }
            remove
            {
                affterSave -= value;
            }
        }
        public  void New()
        {

            this.txtNoteCode.Text = "新单据";
            this.dtpDateNote.Value = DateTime.Now.Date;
            this.ctrlCustomerID.CompanyID = -1;
            this.txtAmount.Text = string.Empty;
            this.txtSummary.Text = string.Empty;
          
        }
  
        private bool ValidateData()
        {
            int CompanyID = this.ctrlCustomerID.CompanyID;
            int MoneyTypeID = this.ctrlMoneyTypeID.MoneyTypeID;
            if (
                (CompanyID == -1) ||
                (MoneyTypeID == -1))
            {
                MessageBox.Show("对不起客户、币种不能为空！");
                return false;
            }
            decimal Amount;
            if (!decimal.TryParse(this.txtAmount.Text, out Amount))
            {
                MessageBox.Show("对不起,扣款款格式出错!");
                return false;
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateData() == false) return;
            bool flag = false;
            string errormsg = string.Empty;
            DialogResult rut = MessageBox.Show("你将添加当前扣款款单据！请注意结款方式!\n是,确认;是,否，取消",
      "新增提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rut == DialogResult.No) return;
            object objNoteID = -1;
         
            flag = this.accNotes.InsertSaleFineAMTNotes(
                ref errormsg,
                ref objNoteID,
                this.txtNoteCode.Text,
                this.dtpDateNote.Value.Date,
                this.ctrlCustomerID.CompanyID,
                this.ctrlMoneyTypeID.MoneyTypeID,
                this.radCashSettleFlag.Checked,
                this.txtAmount .Text ,
                this.txtSummary.Text,
                JERPBiz.Frame.UserBiz.PsnID);
            if (!flag)
            {
                MessageBox .Show (errormsg );
                return;
            }
            if (this.radCashSettleFlag.Checked)
            {
               int BankID = JERPApp.Define.Finance.FrmSettleAMTType.GetBankID();
               if (BankID == -1)
               {
                   //现金
                   this.accCashAccount.InsertCashAccountForCredit(
                       ref errormsg,
                       "销售扣款单[" + this.txtNoteCode.Text + "]扣款",
                       this.ctrlMoneyTypeID.MoneyTypeID,
                       this.txtAmount.Text,
                       JERPBiz.Frame.UserBiz.PsnID);
               }
               else
               {
                   //银行存款
                   this.accBankAccount.InsertBankAccountForCredit (
                       ref errormsg,
                       "销售扣款单[" + this.txtNoteCode.Text + "]扣款",
                       BankID ,
                       this.ctrlMoneyTypeID.MoneyTypeID,
                       this.txtAmount.Text,
                       JERPBiz.Frame.UserBiz.PsnID);
               }
              
                //弄成对账
                this.accNotes.UpdateSaleFineAMTNotesForReconciliation(ref errormsg,
                   objNoteID,-1);
            }
            else
            {
                //应收账款
                this.accReceivableAccount.InsertReceivableAccountForCredit(
                    ref errormsg,
                    "销售扣款单[" + this.txtNoteCode.Text + "]结款",
                    this.ctrlCustomerID.CompanyID,
                    this.ctrlMoneyTypeID.MoneyTypeID,
                    this.txtAmount .Text ,
                    JERPBiz.Frame.UserBiz.PsnID);

            }
            //扣款就当成费用了
            this.accExpenseAccount.InsertExpenseAccountForDebit(
                ref errormsg,
                "销售扣款单[" + this.txtNoteCode.Text + "]扣款",
                JERPBiz.Finance.ExpenseTypeParm.SaleFineExpense,
                decimal.Parse(this.txtAmount.Text) * this.ctrlMoneyTypeID.ExchangeRate,
                JERPBiz.Frame.UserBiz.PsnID);

            MessageBox.Show("成功保存了当前扣款款单据");
            if (this.affterSave != null) this.affterSave();
            this.New();
          
        }

   
    }
}