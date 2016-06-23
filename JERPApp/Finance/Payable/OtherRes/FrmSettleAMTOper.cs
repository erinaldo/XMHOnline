using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace JERPApp.Finance.Payable.OtherRes
{
    public partial class FrmSettleAMTOper : Form
    {
        public FrmSettleAMTOper()
        {
            InitializeComponent();
            this.accReconciliations = new JERPData.OtherRes .BuyReconciliations();
            this.accReceiveItems = new JERPData.OtherRes.BuyReceiveItems();
            this.accReturnItems = new JERPData.OtherRes.BuyReturnItems();
            this.accFineAMT = new JERPData.OtherRes.BuyFineAMTNotes();
            this.ReconciliationEntity = new JERPBiz.OtherRes.BuyReconciliationEntity();
            this.accReceiptNote = new JERPData.OtherRes.BuyReceiptNotes();
            this.accAdvance = new JERPData.Finance.AdvancePayingAccount();
            this.accCashAccount = new JERPData.Finance.CashAccount();
            this.accBankAccount = new JERPData.Finance.BankAccount();
            this.accPayableAccount = new JERPData.Finance.PayableAccount();
            this.accOrderNotes = new JERPData.OtherRes.BuyOrderNotes();
            this.accAdvanceRecords = new JERPData.OtherRes.BuyAdvanceAMTRecords();
            this.hastable = new Hashtable();
            this.dgrdvReceive.AutoGenerateColumns = false;
            this.dgrdvReturn.AutoGenerateColumns = false;
            this.dgrdvFine.AutoGenerateColumns = false;
            this.txtSettleAMT.TextChanged += new EventHandler(txtSettleAMT_TextChanged);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnAdvanceAMT.Click += new EventHandler(btnAdvanceAMT_Click);
        }

       
        private JERPData.OtherRes.BuyReconciliations accReconciliations;
        private JERPData.OtherRes.BuyReceiptNotes  accReceiptNote;
        private JERPData.Finance.AdvancePayingAccount accAdvance;
        private JERPData.OtherRes.BuyReceiveItems accReceiveItems;
        private JERPData.OtherRes.BuyReturnItems accReturnItems;
        private JERPData.OtherRes.BuyFineAMTNotes accFineAMT;
        private JERPData.OtherRes.BuyOrderNotes accOrderNotes;
        private JERPBiz.OtherRes.BuyReconciliationEntity ReconciliationEntity;
        private JERPData.Finance.CashAccount accCashAccount;
        private JERPData.Finance.BankAccount accBankAccount;
        private JERPData.Finance.PayableAccount accPayableAccount;
        private JERPData.OtherRes.BuyAdvanceAMTRecords accAdvanceRecords;
        FrmAdvanceAMTForReceipt frmAdvance;
        private Hashtable hastable;
        private DataTable dtblReceiveItems, dtblReturnItems, dtblFineAMT;
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
        private long ReconciliationID = -1;
        public void ReconciliationSettle(long ReconciliationID)
        {
            this.ReconciliationID = ReconciliationID;
            this.txtReceiptCode.Text = string.Empty;
            this.ReconciliationEntity.LoadData(ReconciliationID);
            this.txtReconciliationCode.Text = this.ReconciliationEntity.ReconciliationCode;
            this.txtYear.Text = this.ReconciliationEntity.Year.ToString();
            this.txtMonth.Text = this.ReconciliationEntity.Month.ToString();
            this.txtCompanyAbbName.Text = this.ReconciliationEntity.CompanyAbbName;
            this.txtMoneyTypeName.Text = this.ReconciliationEntity.MoneyTypeName;
            this.txtSettleTypeName.Text = this.ReconciliationEntity.SettleTypeName;
            this.txtDateNote.Text = this.ReconciliationEntity.DateNote.ToShortDateString();
            this.txtDateSettle.Text = this.ReconciliationEntity.DateSettle.ToShortDateString();
            decimal NonFinishedAMT = this.ReconciliationEntity.NonFinishedAMT;
            this.txtNonFinishedAMT.Text = string.Format("{0:0.####}", NonFinishedAMT);
            decimal AdvanceAMT = 0;
            this.txtAdvanceAMT.Text = string.Format("{0:0.####}", AdvanceAMT);
            bool flag = false;
            this.accAdvanceRecords.GetParmBuyAdvanceAMTRecordsReceiptFlag(this.ReconciliationEntity.CompanyID,
                this.ReconciliationEntity.MoneyTypeID, ref flag);
            this.txtAdvanceAMT.BackColor = flag ? Color.Yellow : Color.White;
            this.txtSettleAMT.Text = string.Format("{0:0.####}", NonFinishedAMT-AdvanceAMT );
          
            this.LoadItems();
        }
        void txtSettleAMT_TextChanged(object sender, EventArgs e)
        {
            decimal NonFinishedAMT = decimal.Parse(this.txtNonFinishedAMT.Text);
            decimal AdvanceAMT = decimal.Parse(this.txtAdvanceAMT.Text);
            decimal SettleAMT;
            if ((!decimal.TryParse(this.txtSettleAMT.Text, out SettleAMT)) || (SettleAMT > NonFinishedAMT - AdvanceAMT))
            {
                MessageBox.Show("输入格式不正确或结款金额大于未结金额-预付金额!");
                this.txtSettleAMT.Text = string.Format("{0:0.#####}", NonFinishedAMT - AdvanceAMT);
            }
        }
    
        private void LoadItems()
        {
            this.dtblReceiveItems = this.accReceiveItems.GetDataBuyReceiveItemsByReconciliationID(this.ReconciliationID).Tables[0];
            this.dgrdvReceive.DataSource = this.dtblReceiveItems;

            this.dtblReturnItems = this.accReturnItems.GetDataBuyReturnItemsByReconciliationID(this.ReconciliationID).Tables[0];
            this.dgrdvReturn.DataSource = this.dtblReturnItems;

            this.dtblFineAMT = this.accFineAMT.GetDataBuyFineAMTNotesByReconciliationID(this.ReconciliationID).Tables[0];
            this.dgrdvFine.DataSource = this.dtblFineAMT;
        }
        void btnAdvanceAMT_Click(object sender, EventArgs e)
        {
            if (frmAdvance == null)
            {
                frmAdvance = new FrmAdvanceAMTForReceipt();
                new FrmStyle(frmAdvance).SetPopFrmStyle(this);
                frmAdvance.AffterSave += frmAdvance_AffterSave;
            }
            frmAdvance.AdvanceOper(this.ReconciliationEntity.CompanyID,
                this.ReconciliationEntity.MoneyTypeID,
                this.ReconciliationEntity.NonFinishedAMT);
            frmAdvance.ShowDialog();
        }

        void frmAdvance_AffterSave(DataRow[] drows)
        {

            this.hastable.Clear();
            decimal AdvanceAMT = 0;
            foreach (DataRow drow in drows)
            {
                AdvanceAMT += (decimal)drow["Amount"];
                this.hastable.Add(drow["RecordID"], drow["Amount"]);
            }
            this.txtAdvanceAMT.Text = string.Format("{0:0.####}", AdvanceAMT);
            this.txtSettleAMT.Text = string.Format("{0:0.####}", this.ReconciliationEntity.NonFinishedAMT - AdvanceAMT);
        }
        private bool ValidateData()
        {
            if (this.txtReceiptCode.Text.Length == 0)
            {
                MessageBox.Show("对不起，收据单号不能为空!");
                return false;
            }
            decimal SettleAMT;
            if (!decimal.TryParse(this.txtSettleAMT.Text, out SettleAMT))
            {
                MessageBox.Show("对不起，结算金额输入有误!");
                return false;
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateData() == false) return;
            decimal SettleAMT = decimal.Parse(this.txtSettleAMT.Text);
            decimal AdvanceAMT = decimal.Parse(this.txtAdvanceAMT.Text);
            DialogResult rlt = MessageBox.Show("你将进行审核结款，一经结款不能修改单据！\n是，确认；否，取消!", "操作确认",
      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rlt == DialogResult.No) return;
            string errormsg = string.Empty;
            object objNoteID = DBNull.Value;
            int BankID = JERPApp.Define.Finance.FrmSettleAMTType.GetBankID();
            int BankID_ = -1;
            if (SettleAMT > 0)
            {
                BankID_ = BankID;
            }
            bool flag = this.accReceiptNote.InsertBuyReceiptNotes (ref errormsg,
                ref objNoteID,
                this.txtReceiptCode.Text,
                DateTime.Now.Date, 
                this.ReconciliationID, 
                this.ReconciliationEntity.CompanyID,
                this.ReconciliationEntity.MoneyTypeID,
                SettleAMT + AdvanceAMT,
                AdvanceAMT,
                BankID_,
                JERPBiz.Frame.UserBiz.PsnID);
            if (!flag)
            {
                MessageBox.Show(errormsg);
                return;
            }
            flag = this.accReconciliations.UpdateBuyReconciliationsForAppendFinishedAMT(
                     ref errormsg, this.ReconciliationID, SettleAMT + AdvanceAMT);
            this.accOrderNotes.UpdateBuyOrderNotesForReceiptAMT(ref errormsg,
                this.ReconciliationEntity.BuyOrderNoteID);
            if (AdvanceAMT > 0)
            {
                this.accAdvance.InsertAdvancePayingAccountForCredit(ref errormsg,
                    "耗材结款单[" + this.txtReceiptCode.Text + "]扣除",
                    this.ReconciliationEntity.CompanyID,
                    this.ReconciliationEntity.MoneyTypeID,
                    AdvanceAMT,
                    JERPBiz.Frame.UserBiz.PsnID);
                foreach (DictionaryEntry item in this.hastable)
                {
                    this.accAdvanceRecords .UpdateBuyAdvanceAMTRecordsForReceipt (
                        ref errormsg,
                        item.Key,
                        objNoteID );
                }

            }
            if (SettleAMT > 0)
            {
                if (BankID == -1)
                {
                    //现金账
                    this.accCashAccount.InsertCashAccountForCredit(ref errormsg,
                        "支付耗材供应商[" + this.ReconciliationEntity.CompanyAbbName + "]结款单[" +
                       this.txtReceiptCode.Text + "]货款",
                        this.ReconciliationEntity.MoneyTypeID,
                        SettleAMT,
                        JERPBiz.Frame.UserBiz.PsnID);
                }
                else
                {
                    //银行存款
                    this.accBankAccount.InsertBankAccountForCredit(ref errormsg,
                        "支付耗材供应商[" + this.ReconciliationEntity.CompanyAbbName + "]结款单[" +
                       this.txtReceiptCode.Text + "]货款",
                        BankID,
                        this.ReconciliationEntity.MoneyTypeID,
                        SettleAMT,
                        JERPBiz.Frame.UserBiz.PsnID);
                }
            }
            //应付账款
            this.accPayableAccount.InsertPayableAccountForDebit(
                ref errormsg,
                "耗材供应商[" + this.ReconciliationEntity.CompanyAbbName + "]结款单[" +
                       this.txtReceiptCode.Text + "]货款",
                this.ReconciliationEntity.CompanyID,
                this.ReconciliationEntity.MoneyTypeID,
                SettleAMT + AdvanceAMT,
                JERPBiz.Frame.UserBiz.PsnID);
            MessageBox.Show("成功完成当前对账结款");
            if (this.affterSave != null) this.affterSave();
            this.Close();
        }


     }
}