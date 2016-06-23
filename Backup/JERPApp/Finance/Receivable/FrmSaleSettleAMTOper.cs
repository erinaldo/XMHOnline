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
    public partial class FrmSaleSettleAMTOper : Form
    {
        public FrmSaleSettleAMTOper()
        {
            InitializeComponent();
            this.accReceiptNote = new JERPData.Product.SaleReceiptNotes();
            this.accDeliverItems = new JERPData.Product.SaleDeliverItems();
            this.accRepairItems = new JERPData.Product.RepairDeliverItems();
            this.accReturnItems = new JERPData.Product.SaleReturnItems();
            this.ReconciliationEntity = new JERPBiz.Product.SaleReconciliationEntity();
            this.accFineAMT = new JERPData.Product.SaleFineAMTNotes();
            this.accAdvance = new JERPData.Finance.AdvanceReceiveAccount();
            this.accReceivableAccount = new JERPData.Finance.ReceivableAccount();
            this.accExpressReceivableAccount = new JERPData.Finance.ExpressReceivableAccount();
            this.accReplaceExpressAMT = new JERPData.Product.SaleReplaceExpressAMTRecord(); 
            this.printhelper = new JERPBiz.Product.SaleReceiptPrintHelper();
            this.accReconciliation = new JERPData.Product.SaleReconciliations();
            this.accAdvanceRecords = new JERPData.Product.SaleAdvanceAMTRecords();
            this.accOrderNotes = new JERPData.Product.SaleOrderNotes();
            this.accCashAccount = new JERPData.Finance.CashAccount();
            this.accBankAccount = new JERPData.Finance.BankAccount();
            this.ctrlExpressID.AppendNull();
            this.hastable = new Hashtable();
            this.dgrdvDeliver.AutoGenerateColumns = false;
            this.dgrdvRepair.AutoGenerateColumns = false;
            this.dgrdvReturn.AutoGenerateColumns = false;
            this.dgrdvFine.AutoGenerateColumns = false;
            this.dgrdvReplaceExpressAMT.AutoGenerateColumns = false;
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnAdvanceAMT.Click += new EventHandler(btnAdvanceAMT_Click);
            this.txtSettleAMT.TextChanged += new EventHandler(txtSettleAMT_TextChanged);
        }

        private JERPData.Product.SaleReceiptNotes accReceiptNote; 
        private JERPData.Product.SaleFineAMTNotes accFineAMT;
        private JERPData.Product.SaleDeliverItems accDeliverItems;
        private JERPData.Product.RepairDeliverItems accRepairItems;
        private JERPData.Product.SaleReturnItems accReturnItems;
        private JERPData.Finance.AdvanceReceiveAccount accAdvance;
        private JERPData.Finance.ReceivableAccount accReceivableAccount;
        private JERPData.Finance.ExpressReceivableAccount accExpressReceivableAccount;
        private JERPData.Product.SaleReplaceExpressAMTRecord accReplaceExpressAMT;
        private JERPBiz.Product.SaleReconciliationEntity ReconciliationEntity;
        private JERPBiz.Product.SaleReceiptPrintHelper printhelper;
        private JERPData.Product.SaleReconciliations accReconciliation;
        private JERPData.Product.SaleAdvanceAMTRecords accAdvanceRecords;

        private JERPData.Finance.CashAccount accCashAccount;
        private JERPData.Finance.BankAccount accBankAccount;
        private JERPData.Product.SaleOrderNotes accOrderNotes;
        private Hashtable hastable;
        private FrmAdvanceAMTForReceipt frmAdvanceAMT;
        private DataTable dtblDeliverItems, dtblRepairItems,dtblReturnItems,dtblFineAMT,dtblReplaceExpressAMT;
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
            this.txtCompanyAbbName.Text = this.ReconciliationEntity.CompanyAbbName;
            this.txtFinanceAddress.Text = this.ReconciliationEntity.FinanceAddress;
            this.txtMoneyTypeName.Text = this.ReconciliationEntity.MoneyTypeName;
            this.txtSettleTypeName.Text = this.ReconciliationEntity.SettleTypeName;
            this.txtDateNote.Text  = this.ReconciliationEntity.DateNote .ToShortDateString ();
        
            this.ctrlExpressID.CompanyID = -1;
            this.txtDeliverAMT.Text = (this.ReconciliationEntity.DeliverAMT > 0) ? string.Format("{0:0.####}", this.ReconciliationEntity.DeliverAMT) : string.Empty;
            this.txtRepairAMT .Text = (this.ReconciliationEntity.RepairAMT  > 0) ? string.Format("{0:0.####}", this.ReconciliationEntity.RepairAMT ) : string.Empty;
            this.txtReplaceExpressAMT .Text = (this.ReconciliationEntity.ReplaceExpressAMT  > 0) ? string.Format("{0:0.####}", this.ReconciliationEntity.ReplaceExpressAMT) : string.Empty;

            this.txtReturnAMT.Text = (this.ReconciliationEntity.ReturnAMT > 0) ? string.Format("{0:0.####}", this.ReconciliationEntity.ReturnAMT) : string.Empty;
            this.txtFineAMT.Text = (this.ReconciliationEntity.FineAMT  > 0) ? string.Format("{0:0.####}", this.ReconciliationEntity.FineAMT) : string.Empty;

            decimal NonFinishedAMT = this.ReconciliationEntity.NonFinishedAMT;
            this.txtNonFinishedAMT.Text = string.Format("{0:0.####}", NonFinishedAMT);

            this.txtAdvanceAMT.Text = string.Format("{0:0.####}", 0);
            bool flag = false;
            this.accAdvanceRecords.GetParmSaleAdvanceAMTRecordsReceiptFlag(this.ReconciliationEntity.CompanyID,
                this.ReconciliationEntity.MoneyTypeID, ref flag);
            this.txtAdvanceAMT.BackColor = flag ? Color.Yellow : Color .White;
            this.txtSettleAMT.Text = string.Format("{0:0.####}", NonFinishedAMT);
            this.LoadItems();
        }
        void txtSettleAMT_TextChanged(object sender, EventArgs e)
        {
            decimal NonFinishedAMT = decimal.Parse(this.txtNonFinishedAMT.Text);
            decimal AdvanceAMT = decimal.Parse(this.txtAdvanceAMT.Text);
            decimal SettleAMT;
            if ((!decimal.TryParse(this.txtSettleAMT.Text, out SettleAMT)) || (SettleAMT > NonFinishedAMT - AdvanceAMT))
            {
                MessageBox.Show("输入格式不正确或结款金额大于未结金额-预收金额!");
                this.txtSettleAMT.Text = string.Format("{0:0.#####}", NonFinishedAMT - AdvanceAMT);
            }
        }
        private void LoadItems()
        {
            this.dtblDeliverItems = this.accDeliverItems.GetDataSaleDeliverItemsByReconciliationID(this.ReconciliationID).Tables[0];
            this.dgrdvDeliver.DataSource = this.dtblDeliverItems;

            this.dtblRepairItems  = this.accRepairItems.GetDataRepairDeliverItemsByReconciliationID (this.ReconciliationID).Tables[0];
            this.dgrdvRepair.DataSource = this.dtblRepairItems ;

            this.dtblReturnItems = this.accReturnItems.GetDataSaleReturnItemsByReconciliationID(this.ReconciliationID).Tables[0];
            this.dgrdvReturn.DataSource = this.dtblReturnItems;

            this.dtblFineAMT  = this.accFineAMT.GetDataSaleFineAMTNotesByReconciliationID (this.ReconciliationID).Tables[0];
            this.dgrdvFine .DataSource = this.dtblFineAMT;

            this.dtblReplaceExpressAMT = this.accReplaceExpressAMT.GetDataSaleReplaceExpressAMTRecordByReconciliationID(this.ReconciliationID).Tables[0];
            this.dgrdvReplaceExpressAMT.DataSource = this.dtblReplaceExpressAMT;
       }

        void btnAdvanceAMT_Click(object sender, EventArgs e)
        {
            if (frmAdvanceAMT == null)
            {
                frmAdvanceAMT = new FrmAdvanceAMTForReceipt();
                new FrmStyle(frmAdvanceAMT).SetPopFrmStyle(this);
                frmAdvanceAMT.AffterSave += new FrmAdvanceAMTForReceipt.AffterSaveDelegate(frmAdvanceAMT_AffterSave);
            }
            frmAdvanceAMT.AdvanceOper(this.ReconciliationEntity.CompanyID,
                this.ReconciliationEntity.MoneyTypeID, 
                this.ReconciliationEntity.NonFinishedAMT);
            frmAdvanceAMT.ShowDialog();
        }

        void frmAdvanceAMT_AffterSave(DataRow[] drows)
        {
            this.hastable.Clear();
            decimal AdvanceAMT = 0;
            foreach (DataRow drow in drows)
            {
                AdvanceAMT += (decimal)drow["Amount"];
                this.hastable.Add(drow["RecordID"], drow["Amount"]);
            }
            this.txtAdvanceAMT.Text = string.Format("{0:0.####}", AdvanceAMT);
            this.txtSettleAMT.Text =  string.Format("{0:0.####}",this.ReconciliationEntity.NonFinishedAMT - AdvanceAMT);
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
          
            DialogResult rul = MessageBox.Show("你将进行收据开取，注意是否取要物流代收，一经保存不能变更！\n是，确认；否，取消!", "操作确认",
     MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return;
            string errormsg = string.Empty;
            object objNoteID = DBNull.Value;
            object objNoteCode = DBNull.Value;
            decimal SettleAMT = decimal.Parse(this.txtSettleAMT.Text);
            decimal AdvanceAMT = decimal.Parse(this.txtAdvanceAMT.Text); 
            bool flag=false;
            bool printflag = (this.txtReceiptCode.Text.Length == 0);
            if (txtReceiptCode.Text.Length > 0)
            {
                objNoteCode =this.txtReceiptCode .Text ;
            }
            int BankID = -1;
            int ExpressCompanyID = this.ctrlExpressID.CompanyID ;
            if (ExpressCompanyID > -1)
            {
                BankID = -1;
            }
            else
            {
                if (SettleAMT > 0)
                {
                    BankID = JERPApp.Define.Finance.FrmSettleAMTType.GetBankID();
                }
            }
           flag= this.accReceiptNote.InsertSaleReceiptNotes(ref errormsg,
                ref objNoteID,
                 ref objNoteCode ,
                 DateTime.Now.Date,
                 this.ReconciliationEntity.CompanyID,
                 this.ReconciliationEntity.FinanceAddressID, 
                 this.ReconciliationID, 
                 this.ReconciliationEntity.MoneyTypeID,
                 SettleAMT + AdvanceAMT,//因为此次要结的数+已收即为完成数
                 AdvanceAMT,
                 BankID ,
                 this.ctrlExpressID.CompanyID ,
                 JERPBiz.Frame.UserBiz.PsnID);           
            if (!flag)
            {
                MessageBox.Show(errormsg);
                return;
            }
            this.txtReceiptCode.Text = objNoteCode.ToString();
            string ReceiptCode = objNoteCode.ToString();
            //设置对账单增加完成
            this.accReconciliation.UpdateSaleReconciliationsForAppendFinishedAMT  (
                ref errormsg,
                this.ReconciliationID,
                SettleAMT + AdvanceAMT);
            this.accOrderNotes.UpdateSaleOrderNotesForFinishedAMT(ref errormsg, this.ReconciliationEntity.SaleOrderNoteID);
            if (AdvanceAMT > 0)
            {
                this.accAdvance.InsertAdvanceReceiveAccountForDebit(ref errormsg,
                    "销售对账单[" + this.ReconciliationEntity.ReconciliationCode + "]收据单[" + this.txtReceiptCode.Text + "]扣预收",
                    this.ReconciliationEntity.CompanyID,
                    this.ReconciliationEntity.MoneyTypeID,
                    AdvanceAMT,
                    JERPBiz.Frame.UserBiz.PsnID);
                //应收账款
                this.accReceivableAccount.InsertReceivableAccountForCredit(
                    ref errormsg,
                    "销售对账单[" + this.ReconciliationEntity.ReconciliationCode + "]收据单[" + this.txtReceiptCode.Text + "]扣预收",
                    this.ReconciliationEntity.CompanyID,
                    this.ReconciliationEntity.MoneyTypeID,
                    AdvanceAMT,
                    JERPBiz.Frame.UserBiz.PsnID);
                foreach (DictionaryEntry item in this.hastable)
                {
                    this.accAdvanceRecords.UpdateSaleAdvanceAMTRecordsForReceipt(
                        ref errormsg,
                        item.Key,
                        objNoteID);
                }

            }
            if ((this.ctrlExpressID.CompanyID > -1) && (SettleAMT  > 0))
            {

                //代收账款
                this.accExpressReceivableAccount.InsertExpressReceivableAccountForDebit(ref errormsg,
                    "销售收据[" + this.txtReceiptCode.Text + "]代收款",
                    this.ctrlExpressID.CompanyID,
                    this.ReconciliationEntity .MoneyTypeID,
                    SettleAMT,
                    JERPBiz.Frame.UserBiz.PsnID);
                //应收账款
                this.accReceivableAccount.InsertReceivableAccountForCredit(
                    ref errormsg,
                   "销售收据[" + this.txtReceiptCode.Text + "]代收款",
                    this.ReconciliationEntity.CompanyID,
                    this.ReconciliationEntity.MoneyTypeID,
                    SettleAMT ,
                    JERPBiz.Frame.UserBiz.PsnID);

            }
           
            if ((ExpressCompanyID == -1) && (SettleAMT > 0))
            {
                //我们自己收的款我们处理,如果是代收的话,容对账容结款
                if (BankID == -1)
                {
                    //现金账
                    this.accCashAccount.InsertCashAccountForDebit(ref errormsg,
                        "收取客户[" + this.ReconciliationEntity .CompanyAbbName + "]收据[" +
                        ReceiptCode  + "]金额",
                        this.ReconciliationEntity .MoneyTypeID,
                        SettleAMT,
                        JERPBiz.Frame.UserBiz.PsnID);
                }
                else
                {

                    //银行存款
                    this.accBankAccount.InsertBankAccountForDebit(ref errormsg,
                            "收取客户[" + this.ReconciliationEntity.CompanyAbbName + "]收据[" +
                         ReceiptCode  + "]金额",
                        BankID,
                        this.ReconciliationEntity .MoneyTypeID,
                        SettleAMT,
                        JERPBiz.Frame.UserBiz.PsnID);
                }
                //应付账款
                this.accReceivableAccount.InsertReceivableAccountForCredit(
                    ref errormsg,
                    "收取客户[" + this.ReconciliationEntity.CompanyAbbName + "]收据[" +
                        ReceiptCode  + "]金额",
                    this.ReconciliationEntity .CompanyID,
                    this.ReconciliationEntity .MoneyTypeID,
                    SettleAMT,
                    JERPBiz.Frame.UserBiz.PsnID);
            }
            MessageBox.Show("成功进行收据开取");
            if (printflag)
            {
                rul = MessageBox.Show("需要进行单打印吗?", "打印确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rul == DialogResult.Yes)
                {
                    this.printhelper.ExportToExcel((long)objNoteID);
                }
            }
            if (this.affterSave != null) this.affterSave();
            this.Close();
        }
    }
}