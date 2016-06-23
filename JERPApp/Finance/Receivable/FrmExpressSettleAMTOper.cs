using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace JERPApp.Finance.Receivable
{
    public partial class FrmExpressSettleAMTOper : Form
    {
        public FrmExpressSettleAMTOper()
        {
            InitializeComponent();
            this.accReceiptNote = new JERPData.Product.ExpressReceiptNotes();
            this.ReconciliationEntity = new JERPBiz.Product.ExpressReconciliationEntity();
            this.printhelper = new JERPBiz.Product.ExpressReceiptPrintHelper();
            this.accReconciliation = new JERPData.Product.ExpressReconciliations();
            this.accReceivableAccount = new JERPData.Finance.ExpressReceivableAccount();
            this.accCashAccount = new JERPData.Finance.CashAccount();
            this.accBankAccount = new JERPData.Finance.BankAccount();
            this.accSaleReceiptNotes = new JERPData.Product.SaleReceiptNotes();
            this.dgrdvReceipt .AutoGenerateColumns = false;
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.txtSettleAMT.TextChanged += new EventHandler(txtSettleAMT_TextChanged);
        }

        private JERPData.Product.ExpressReceiptNotes accReceiptNote;
        private JERPBiz.Product.ExpressReconciliationEntity ReconciliationEntity;
        private JERPBiz.Product.ExpressReceiptPrintHelper printhelper;
        private JERPData.Product.ExpressReconciliations accReconciliation;
        private JERPData.Finance .ExpressReceivableAccount  accReceivableAccount;
        private JERPData.Product.SaleReceiptNotes accSaleReceiptNotes;

        private JERPData.Finance.CashAccount accCashAccount;
        private JERPData.Finance.BankAccount accBankAccount;
        private DataTable dtblReceiptNotes;
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
        public void ReceiptOper(long ReconciliationID)
        {
            this.ReconciliationID = ReconciliationID;
            this.txtReceiptCode.Text = string.Empty;
            this.ReconciliationEntity.LoadData(ReconciliationID);
            this.txtReconciliationCode.Text = this.ReconciliationEntity.ReconciliationCode;
            this.txtReconciliationName.Text = this.ReconciliationEntity.ReconciliationName;
            this.txtYear.Text = this.ReconciliationEntity.Year.ToString();
            this.txtMonth.Text = this.ReconciliationEntity.Month.ToString();
            this.txtCompanyAbbName.Text = this.ReconciliationEntity.CompanyName;
        
            this.txtMoneyTypeName.Text = this.ReconciliationEntity.MoneyTypeName;
            this.txtDateNote.Text  = this.ReconciliationEntity.DateNote .ToShortDateString ();
            decimal NonFinishedAMT = this.ReconciliationEntity.NonFinishedAMT;
            this.txtNonFinishedAMT.Text = string.Format("{0:0.####}", NonFinishedAMT);
            this.txtSettleAMT.Text = string.Format("{0:0.####}", NonFinishedAMT);
            this.dtblReceiptNotes  = this.accSaleReceiptNotes.GetDataSaleReceiptNotesByExpressReconciliationID (this.ReconciliationID).Tables[0];
            this.dgrdvReceipt.DataSource = this.dtblReceiptNotes;
        }
        void txtSettleAMT_TextChanged(object sender, EventArgs e)
        {
            decimal NonFinishedAMT = decimal.Parse(this.txtNonFinishedAMT.Text);
            decimal SettleAMT;
            if ((!decimal.TryParse(this.txtSettleAMT.Text, out SettleAMT)) || (SettleAMT > NonFinishedAMT))
            {
                MessageBox.Show("输入格式不正确或结款金额大于未结金额!");
                this.txtSettleAMT.Text = string.Format("{0:0.#####}", NonFinishedAMT);
            }
        }
   
        private bool ValidateData()
        {
         
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
          
            DialogResult rlt = MessageBox.Show("你将进行收据开取，一经保存不能变更！\n是，确认；否，取消!", "操作确认",
     MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rlt == DialogResult.No) return;
            string errormsg = string.Empty;
            object objNoteID = DBNull.Value;
            object objNoteCode = DBNull.Value;
            decimal SettleAMT = decimal.Parse(this.txtSettleAMT.Text);
        
            bool flag=false;
            if (this.txtReceiptCode.Text.Length > 0)
            {
                objNoteCode = this.txtReceiptCode.Text;
            }
            bool printflag = (txtReceiptCode.Text.Length == 0);
            int BankID = -1;
            if (SettleAMT > 0)
            {
               BankID= JERPApp.Define.Finance.FrmSettleAMTType.GetBankID();
            }
            flag = this.accReceiptNote.InsertExpressReceiptNotes  (ref errormsg,
                ref objNoteID,
                 ref objNoteCode ,
                 DateTime.Now.Date,
                 this.ReconciliationID,
                 SettleAMT,
                 BankID ,
                 JERPBiz.Frame.UserBiz.PsnID);
            if (flag)
            {
                this.txtReceiptCode.Text = objNoteCode.ToString();
            }
            
            if (!flag)
            {
                MessageBox.Show(errormsg);
                return;
            }
            string ReceiptCode = objNoteCode.ToString();
            //设置对账单增加完成
            this.accReconciliation.UpdateExpressReconciliationsForAppendFinishedAMT(
                ref errormsg,
                this.ReconciliationID,
                SettleAMT); 
            if (SettleAMT > 0)
            {
              
                //我们自己收的款我们处理,如果是代收的话,容对账容结款
                if (BankID == -1)
                {
                    //现金账
                    this.accCashAccount.InsertCashAccountForDebit(ref errormsg,
                        "收取物流公司[" + this.ReconciliationEntity .CompanyName + "]收据[" +
                        ReceiptCode  + "]代收货款",
                        this.ReconciliationEntity.MoneyTypeID,
                        SettleAMT,
                        JERPBiz.Frame.UserBiz.PsnID);
                }
                else
                {

                    //银行存款
                    this.accBankAccount.InsertBankAccountForDebit(ref errormsg,
                             "收取物流公司[" + this.ReconciliationEntity.CompanyName + "]收据[" +
                        ReceiptCode + "]代收货款",
                        BankID,
                        this.ReconciliationEntity.MoneyTypeID,
                        SettleAMT,
                        JERPBiz.Frame.UserBiz.PsnID);
                }
                //代收账款
                this.accReceivableAccount .InsertExpressReceivableAccountForCredit(
                    ref errormsg,
                   "收取物流公司[" + this.ReconciliationEntity.CompanyName + "]收据[" +
                        ReceiptCode + "]代收货款",
                    this.ReconciliationEntity.CompanyID,
                    this.ReconciliationEntity.MoneyTypeID,
                    SettleAMT,
                    JERPBiz.Frame.UserBiz.PsnID);
            } 
            MessageBox.Show("成功进行收据开取!");
            if (printflag)
            {
                rlt = MessageBox.Show("需要进行单打印吗?", "打印确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rlt == DialogResult.Yes)
                {
                    this.printhelper.ExportToExcel((long)objNoteID);
                }
            }
            if (this.affterSave != null) this.affterSave();
            this.Close();
        }
    }
}