using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Payable.Tool
{
    public partial class FrmAdvanceAMTOper : Form
    {
        public FrmAdvanceAMTOper()
        {
            InitializeComponent(); 
            this.accBuyOrderNotes = new JERPData.Tool.BuyOrderNotes(); 
            this.BuyOrderNoteEntity = new JERPBiz.Tool.BuyOrderNoteEntity();
            this.accAdvanceAMT = new JERPData.Finance.AdvancePayingAccount();
            this.accCashAccount = new JERPData.Finance.CashAccount();
            this.accBankAccount = new JERPData.Finance.BankAccount();
            this.accReceiptNotes = new JERPData.Tool.BuyReceiptNotes();
            this.accRecords = new JERPData.Tool.BuyAdvanceAMTRecords(); 
            new ToolTip().SetToolTip(this.btnBuyOrder, "订单预付");
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnBuyOrder.Click += new EventHandler(btnBuyOrder_Click); 
            this.btnNew.Click += new EventHandler(btnNew_Click);
        }


        private JERPData.Tool.BuyOrderNotes accBuyOrderNotes; 
        private JERPBiz.Tool.BuyOrderNoteEntity BuyOrderNoteEntity;
        private JERPData.Tool.BuyAdvanceAMTRecords accRecords;
        private JERPData.Finance.AdvancePayingAccount accAdvanceAMT;
        private JERPData.Finance.CashAccount accCashAccount;
        private JERPData.Finance.BankAccount accBankAccount;
        private JERPData.Tool.BuyReceiptNotes accReceiptNotes; 
        private FrmAdvanceAMTFromOrderNote frmFromOrder; 
        private long BuyOrderNoteID = -1;
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
        void btnBuyOrder_Click(object sender, EventArgs e)
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
            this.BuyOrderNoteID = NoteID;
            this.BuyOrderNoteEntity.LoadData(NoteID);
            this.txtPONo.Text = this.BuyOrderNoteEntity.NoteCode;
            this.txtDateNote.Text = this.BuyOrderNoteEntity.DateNote.ToShortDateString();
            this.ctrlSupplierID.CompanyID = this.BuyOrderNoteEntity.CompanyID;  
            this.ctrlMoneyTypeID.MoneyTypeID = this.BuyOrderNoteEntity.MoneyTypeID;
            this.ctrlSupplierID.Enabled = false;
            this.ctrlMoneyTypeID.Enabled = false;         
        }

        public void New()
        {
            this.BuyOrderNoteID = -1;
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
            flag=this.accReceiptNotes.InsertBuyReceiptNotes(
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
            flag=this.accRecords.InsertBuyAdvanceAMTRecords(ref errormsg,
                this.dtpDateRecord.Value,
                this.BuyOrderNoteID,
                this.ctrlSupplierID.CompanyID,
                this.ctrlMoneyTypeID.MoneyTypeID,
                Amount,
                JERPBiz.Frame.UserBiz.PsnID,
                this.rchMemo.Text);
            if (this.BuyOrderNoteID > -1)
            {
                flag = this.accBuyOrderNotes.UpdateBuyOrderNotesForAdvanceAMT(
                    ref errormsg,
                    this.BuyOrderNoteID ,
                    Amount); 
               

            }            
            int BankID = JERPApp.Define.Finance.FrmSettleAMTType.GetBankID();  
            //弄一个增加之付据
            this.SaveReceiptNote(Amount,BankID);
            //增加而已
            this.accAdvanceAMT.InsertAdvancePayingAccountForDebit  (ref errormsg,
               "治具采购预付收据号[" + this.txtReceiptNoteCode.Text + "]",
               this.ctrlSupplierID .CompanyID,
               this.ctrlMoneyTypeID.MoneyTypeID,
               Amount ,
               JERPBiz.Frame.UserBiz.PsnID);
            if (BankID == -1)
            {
                //现金账
                this.accCashAccount.InsertCashAccountForCredit(
                    ref errormsg,
                    "支付治具供应商[" + this.ctrlSupplierID .CompanyAbbName + "]预付款,收据号[" + this.txtReceiptNoteCode.Text + "]",
                    this.ctrlMoneyTypeID .MoneyTypeID,
                    Amount ,
                    JERPBiz.Frame.UserBiz.PsnID);
            }
            else
            {
                //银行存款
                this.accBankAccount.InsertBankAccountForCredit(
                    ref errormsg,
                    "支付治具供应商[" + this.ctrlSupplierID.CompanyAbbName + "]预付款,收据号[" + this.txtReceiptNoteCode.Text + "]",
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