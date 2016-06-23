using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Dispatcher
{
    public partial class FrmPostageNoteOper : Form
    {
        public FrmPostageNoteOper()
        {
            InitializeComponent();
            this.accNotes = new JERPData.Finance.PostageNotes();
            this.accSettleType = new JERPData.Finance.SettleType();
            this.accCashAccount = new JERPData.Finance.CashAccount();
            this.accExpenseAccount = new JERPData.Finance.ExpenseAccount();
            this.MoneyTypeParm = new JERPBiz.Finance.MoneyTypeParm();
            this.accExpressPayableAccount = new JERPData.Finance.ExpressPayableAccount();
            this.dtpDateNote.Value = DateTime.Now.Date;
            this.btnSave.Click += new EventHandler(btnSave_Click);

        }

        private JERPData.Finance.PostageNotes accNotes;
        private JERPData.Finance.CashAccount accCashAccount;
        private JERPData.Finance.SettleType accSettleType;
        private JERPData.Finance.ExpenseAccount accExpenseAccount;
        private JERPBiz.Finance.MoneyTypeParm MoneyTypeParm;
        private JERPData.Finance.ExpressPayableAccount accExpressPayableAccount;
        
        private long noteID = -1;
        private   long NoteID
        {
            get
            {
                return this.noteID;
            }
            set
            {
                this.noteID = value;
            }
        }
        public void NewNote()
        {
            this.NoteID = -1;
            this.txtNoteCode .Text = string.Empty;
            this.txtAmount.Text = string.Empty;
            this.rchMemo.Text = string.Empty;
        }


        public delegate void AffterSaveDelegate(long ExpressNoteID,int ExpressCompanyID,string ExpressCode);
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
      
        private bool ValidateData()
        {
            decimal Amount;
            if (!decimal.TryParse(this.txtAmount.Text, out Amount))
            {
                MessageBox.Show("对不起,邮递费用输入错误!");
                return false;
            }
            if (this.txtNoteCode.Text == string.Empty)
            {
                MessageBox.Show("对不起,快递单号未填写!");
                return false;
            }
            if (this.ctrlExpressID.CompanyID == -1)
            {
                MessageBox.Show("对不起，请选择供应商!");
                return false;
            }
           
            return true;
        }
     
   
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (this.ValidateData() == false) return;
            DialogResult rut = MessageBox.Show("你将添加当前快递单据,一经保存过账不能变更！\n是,确认;是,否，取消",
      "保存确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rut == DialogResult.No) return;
            bool flag = false;
            string errormsg = string.Empty;
            object objNoteID = DBNull.Value;
            flag = this.accNotes.InsertPostageNotes(
                ref errormsg,
                ref objNoteID,
                this.dtpDateNote.Value.Date,
                this.txtNoteCode.Text,
                this.ctrlExpressID.CompanyID,
                this.txtAmount.Text,
                JERPBiz.Frame.UserBiz.PsnID,
                this.rchMemo.Text);
            if (!flag)
            {
                MessageBox .Show (errormsg);
                return;
            }
            this.NoteID = (long)objNoteID;
            int MainMoneyTypeID = this.MoneyTypeParm.GetMainMoneyTypeID();
            if (this.radCashFlag.Checked)
            {
                this.accNotes.UpdatePostageNotesForReconciliation(ref errormsg, NoteID, -1);
                //现金账
                this.accCashAccount.InsertCashAccountForCredit(
                    ref errormsg,
                    "支付快递公司[" + this.ctrlExpressID.CompanyName + "]快递费",
                    MainMoneyTypeID,
                    this.txtAmount.Text,
                    JERPBiz.Frame.UserBiz.PsnID);
              
            }
            if (this.radPayableFlag.Checked)
            {
                //快递公司应付账款
                this.accExpressPayableAccount.InsertExpressPayableAccountForCredit(
                    ref errormsg,
                    "快递单[" + this.txtNoteCode.Text + "]",
                    this.ctrlExpressID.CompanyID,
                    MainMoneyTypeID,
                    this.txtAmount.Text,
                    JERPBiz.Frame.UserBiz.PsnID);

            }    
            //物流费用
            this.accExpenseAccount.InsertExpenseAccountForDebit(
                ref errormsg,
               "快递公司[" + this.ctrlExpressID.CompanyName + "][" + this.txtNoteCode.Text + "]",
                JERPBiz.Finance.ExpenseTypeParm.ExpressExpense,
                this.txtAmount.Text,
                JERPBiz.Frame.UserBiz.PsnID);    
            if (this.affterSave != null) this.affterSave(this.NoteID,this.ctrlExpressID .CompanyID ,this.txtNoteCode.Text  );   
        }
    }
}