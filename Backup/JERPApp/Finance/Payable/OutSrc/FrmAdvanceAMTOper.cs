using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Payable.OutSrc
{
    public partial class FrmAdvanceAMTOper : Form
    {
        public FrmAdvanceAMTOper()
        {
            InitializeComponent(); 
            this.accOutSrcOrderNotes = new JERPData.Manufacture.OutSrcOrderNotes(); 
            this.OutSrcOrderNoteEntity = new JERPBiz.Manufacture.OutSrcOrderNoteEntity();
            this.accAdvanceAMT = new JERPData.Finance.AdvancePayingAccount();
            this.accCashAccount = new JERPData.Finance.CashAccount();
            this.accBankAccount = new JERPData.Finance.BankAccount();
            this.accReceiptNotes = new JERPData.Manufacture.OutSrcReceiptNotes();
            this.accRecords = new JERPData.Manufacture.OutSrcAdvanceAMTRecords(); 
            new ToolTip().SetToolTip(this.btnOutSrcOrder, "订单预付");
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnOutSrcOrder.Click += new EventHandler(btnOutSrcOrder_Click); 
            this.btnNew.Click += new EventHandler(btnNew_Click);
        }


        private JERPData.Manufacture.OutSrcOrderNotes accOutSrcOrderNotes; 
        private JERPBiz.Manufacture.OutSrcOrderNoteEntity OutSrcOrderNoteEntity;
        private JERPData.Manufacture.OutSrcAdvanceAMTRecords accRecords;
        private JERPData.Finance.AdvancePayingAccount accAdvanceAMT;
        private JERPData.Finance.CashAccount accCashAccount;
        private JERPData.Finance.BankAccount accBankAccount;
        private JERPData.Manufacture.OutSrcReceiptNotes accReceiptNotes; 
        private FrmAdvanceAMTFromOrderNote frmFromOrder; 
        private long OutSrcOrderNoteID = -1;
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
        void btnOutSrcOrder_Click(object sender, EventArgs e)
        {
            if (frmFromOrder == null)
            {
                frmFromOrder = new FrmAdvanceAMTFromOrderNote();
                new FrmStyle(frmFromOrder).SetPopFrmStyle(this);
                frmFromOrder.AffterSelect += new FrmAdvanceAMTFromOrderNote.AffterSelectDelegate(frmFromOrder_AffterSelect);
            }
            frmFromOrder.LoadData();
            frmFromOrder.ShowDialog();
        }

        void frmFromOrder_AffterSelect(long NoteID)
        {
            this.OutSrcOrderNoteID = NoteID;
            this.OutSrcOrderNoteEntity.LoadData(NoteID);
            this.txtPONo.Text = this.OutSrcOrderNoteEntity.NoteCode;
            this.txtDateNote.Text = this.OutSrcOrderNoteEntity.DateNote.ToShortDateString();
            this.ctrlSupplierID.CompanyID = this.OutSrcOrderNoteEntity.CompanyID;  
            this.ctrlMoneyTypeID.MoneyTypeID = this.OutSrcOrderNoteEntity.MoneyTypeID;
            this.ctrlSupplierID.Enabled = false;
            this.ctrlMoneyTypeID.Enabled = false;         
        }

        public void New()
        {
            this.OutSrcOrderNoteID = -1;
            this.txtReceiptNoteCode.Text = string.Empty;
            this.txtPONo.Text = string.Empty;
            this.txtDateNote.Text = string.Empty;
            this.dtpDateRecord.Value = DateTime.Now.Date;
            this.txtAmount.Text = string.Empty;
            this.rchMemo.Text = string.Empty;
            this.ctrlSupplierID.CompanyID = -1; 
            this.ctrlSupplierID.Enabled =true ;
            this.ctrlMoneyTypeID.Enabled = true;
        }

   

        void btnNew_Click(object sender, EventArgs e)
        {
            this.New();
        }
        bool ValidateData()
        {
            if (this.ctrlSupplierID.CompanyID == -1)
            {
                MessageBox.Show("对不起，供应商不能为空");
                return false;
            }
            if (this.ctrlMoneyTypeID .MoneyTypeID  == -1)
            {
                MessageBox.Show("对不起，币种不能为空");
                return false;
            }
            decimal Amount;
            if ((decimal.TryParse(this.txtAmount.Text, out Amount) == false)
                || (Amount <= 0))
            {
                MessageBox.Show("金额必须大于0!");
                return false;
            }
            return true;
        }


      
        private void SaveReceiptNote(decimal Amount,int BankID)
        {
            object objReceiptNoteID = DBNull.Value;
            string errormsg = string.Empty;
            bool flag = false; 
            flag=this.accReceiptNotes.InsertOutSrcReceiptNotes(
                ref errormsg,
                ref objReceiptNoteID,
                this.txtReceiptNoteCode .Text ,
                DateTime.Now.Date,
                DBNull .Value , 
                this.ctrlSupplierID .CompanyID ,
                this.ctrlMoneyTypeID .MoneyTypeID,
                Amount,
                0,
                BankID,
                JERPBiz.Frame.UserBiz.PsnID);
            if (!flag)
            {
                MessageBox .Show(errormsg );
                return;
            }
           
           
        }
       
        void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateData() == false) return;          
            DialogResult rut = MessageBox.Show("将对预付款进行保存，一经保存,不能变更,确认否?", "保存确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rut == DialogResult.No) return;        
            string errormsg = string.Empty;
            bool flag = false;
            decimal Amount = decimal.Parse(this.txtAmount.Text);
            flag=this.accRecords.InsertOutSrcAdvanceAMTRecords(ref errormsg,
                this.dtpDateRecord.Value,
                this.OutSrcOrderNoteID,
                this.ctrlSupplierID.CompanyID,
                this.ctrlMoneyTypeID.MoneyTypeID,
                Amount,
                JERPBiz.Frame.UserBiz.PsnID,
                this.rchMemo.Text);
            if (this.OutSrcOrderNoteID > -1)
            {
                flag = this.accOutSrcOrderNotes.UpdateOutSrcOrderNotesForAdvanceAMT(
                    ref errormsg,
                    this.OutSrcOrderNoteID ,
                    Amount); 
               

            }            
            int BankID = JERPApp.Define.Finance.FrmSettleAMTType.GetBankID();  
            //弄一个增加之付据
            this.SaveReceiptNote(Amount,BankID);
            //增加而已
            this.accAdvanceAMT.InsertAdvancePayingAccountForDebit  (ref errormsg,
               "产品委外预付收据号[" + this.txtReceiptNoteCode.Text + "]",
               this.ctrlSupplierID .CompanyID,
               this.ctrlMoneyTypeID.MoneyTypeID,
               Amount ,
               JERPBiz.Frame.UserBiz.PsnID);
            if (BankID == -1)
            {
                //现金账
                this.accCashAccount.InsertCashAccountForCredit(
                    ref errormsg,
                    "支付产品供应商[" + this.ctrlSupplierID .CompanyAbbName + "]预付款,收据号[" + this.txtReceiptNoteCode.Text + "]",
                    this.ctrlMoneyTypeID .MoneyTypeID,
                    Amount ,
                    JERPBiz.Frame.UserBiz.PsnID);
            }
            else
            {
                //银行存款
                this.accBankAccount.InsertBankAccountForCredit(
                    ref errormsg,
                    "支付产品供应商[" + this.ctrlSupplierID.CompanyAbbName + "]预付款,收据号[" + this.txtReceiptNoteCode.Text + "]",
                    BankID,
                    this.ctrlMoneyTypeID .MoneyTypeID,
                    Amount,
                    JERPBiz.Frame.UserBiz.PsnID);
            }            
            if (this.affterSave != null) this.affterSave();
            MessageBox.Show("成功入账当前预付款");
            this.Close();
        }
    }
}