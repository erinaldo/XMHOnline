using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Payable.Tool
{
    public partial class FrmBuyFineAMTConfirm : Form
    {
        public FrmBuyFineAMTConfirm()
        {
            InitializeComponent();
            this.accFineNote = new JERPData.Tool.BuyFineAMTNotes();
            this.NoteEntity = new JERPBiz.Tool.BuyFineAMTNoteEntity();
            this.accCashAccount = new JERPData.Finance.CashAccount();
            this.accBankAccount = new JERPData.Finance.BankAccount();
            this.accRevenueAccount = new JERPData.Finance.RevenueAccount();
            this.MoneyTypeParm = new JERPBiz.Finance.MoneyTypeParm();
            this.accPayableAccount = new JERPData.Finance.PayableAccount();         
            this.btnSave.Click += new EventHandler(btnSave_Click);
        }

        private JERPData.Tool.BuyFineAMTNotes accFineNote;
        private JERPBiz.Tool.BuyFineAMTNoteEntity NoteEntity;
        private JERPData.Finance.CashAccount accCashAccount;
        private JERPData.Finance.BankAccount accBankAccount;
        private JERPData.Finance.RevenueAccount accRevenueAccount;
        private JERPBiz.Finance.MoneyTypeParm MoneyTypeParm;
        private JERPData.Finance.PayableAccount accPayableAccount;
        private long noteid = -1;
        private long NoteID
        {
            get
            {
                return this.noteid;
            }
            set
            {
                this.noteid = value;
            }
        }
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
     
        public void ConfirmOper(long NoteID)
        {
            this.NoteID = NoteID;
            this.NoteEntity .LoadData (NoteID );
            this.txtNoteCode.Text = this.NoteEntity.NoteCode;
            this.txtCompanyAbbName.Text = this.NoteEntity.CompanyAbbName;
            this.txtMoneyTypeName.Text = this.NoteEntity.MoneyTypeName;
            this.txtDateNote.Text = this.NoteEntity.DateNote.ToShortDateString();            
            this.txtAmount.Text = string.Format("{0:0.####}", this.NoteEntity.Amount);
            this.rchSummary.Text = this.NoteEntity.Summary;
        }
    

        void btnSave_Click(object sender, EventArgs e)
        {
         
            string errormsg = string.Empty;
            bool flag = false;
            DialogResult rut = MessageBox.Show("将对扣款单进行新增，一经新增,日期不能变更?", "保存确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rut == DialogResult.No) return;
           
            flag = this.accFineNote.UpdateBuyFineAMTNotesForConfirm(
                ref errormsg,
                this.NoteID,
                this.radCashFlag.Checked,
                JERPBiz.Frame.UserBiz.PsnID);
            if (!flag)
            {
                MessageBox.Show(errormsg);
                if (this.affterSave != null) this.affterSave();
                this.Close();
            }
            if (this.radCashFlag.Checked)
            {
               int BankID = JERPApp.Define.Finance.FrmSettleAMTType.GetBankID();
               if (BankID == -1)
               {
                   //现金账
                   this.accCashAccount.InsertCashAccountForDebit(
                       ref errormsg,
                       "治具采购扣款单[" + this.txtNoteCode.Text + "]现金",
                       this.NoteEntity.MoneyTypeID,
                       this.txtAmount.Text,
                       JERPBiz.Frame.UserBiz.PsnID);
               }
               else
               {
                   //银行存款
                   this.accBankAccount.InsertBankAccountForDebit (
                       ref errormsg,
                       "治具采购扣款单[" + this.txtNoteCode.Text + "]现金",
                       BankID,
                       this.NoteEntity.MoneyTypeID,
                       this.txtAmount.Text,
                       JERPBiz.Frame.UserBiz.PsnID);
               }
                //弄成已对账
                this.accFineNote.UpdateBuyFineAMTNotesForReconciliation(ref errormsg,
                    this.NoteID,
                    -1);
              
            }
            else
            {
                //应付账款
                this.accPayableAccount .InsertPayableAccountForDebit (ref errormsg ,
                    "治具采购扣款单[" + this.txtNoteCode.Text + "]扣除",
                    this.NoteEntity.CompanyID,
                    this.NoteEntity.MoneyTypeID,
                    this.txtAmount .Text,
                    JERPBiz.Frame.UserBiz.PsnID);

            }
            //弄成扣款收入
            this.accRevenueAccount.InsertRevenueAccountForCredit(
                     ref errormsg,
                      "治具采购扣款单[" + this.txtNoteCode.Text + "]",
                      JERPBiz.Finance.RevenueTypeParm.FineRevenue,
                      decimal.Parse(this.txtAmount.Text) * this.MoneyTypeParm.GetExchangeRate(this.NoteEntity.MoneyTypeID),
                     JERPBiz.Frame.UserBiz.PsnID);
            MessageBox.Show("成功审核并入账当前扣款单");
            if (this.affterSave != null) this.affterSave();
            this.Close();
        }

       

    }
}