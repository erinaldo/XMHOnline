using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Receivable
{
    public partial class FrmSaleReturnNoteOper : Form
    {
        public FrmSaleReturnNoteOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accNotes = new JERPData.Product.SaleReturnNotes();
            this.accItems = new JERPData.Product.SaleReturnItems();
            this.NoteEntity = new JERPBiz.Product.SaleReturnNoteEntity();
            this.accCashAccount = new JERPData.Finance.CashAccount();
            this.accBankAccount = new JERPData.Finance.BankAccount();
            this.accExpenseAccount = new JERPData.Finance.ExpenseAccount();
            this.MoneyTypeParm = new JERPBiz.Finance.MoneyTypeParm();
            this.accReceivableAccount = new JERPData.Finance.ReceivableAccount();
            this.btnSave.Click += new EventHandler(btnSave_Click);

        }
        private JERPData.Product.SaleReturnNotes accNotes;
        private JERPData.Product.SaleReturnItems accItems;
        private JERPBiz.Product.SaleReturnNoteEntity NoteEntity;
        private JERPData.Finance.CashAccount accCashAccount;
        private JERPData.Finance.BankAccount accBankAccount;
        private JERPData.Finance.ExpenseAccount accExpenseAccount;
        private JERPBiz.Finance.MoneyTypeParm MoneyTypeParm;
        private JERPData.Finance.ReceivableAccount accReceivableAccount;
        private DataTable dtblItems;     
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
        public  void ConfirmOper(long NoteID)
        {
            this.NoteID = NoteID;
            this.NoteEntity.LoadData(NoteID);
            this.txtNoteCode.Text = this.NoteEntity.NoteCode;
            this.txtCompanyAbbName.Text = this.NoteEntity.CompanyAbbName;
            this.txtMoneyTypeName.Text = this.NoteEntity.MoneyTypeName ;
            this.txtDateNote.Text = this.NoteEntity.DateNote.ToShortDateString();
            this.txtMakerPsn.Text = this.NoteEntity.MakerPsn;
            this.rchMemo.Text = this.NoteEntity.Memo;
            this.txtTotalAMT.Text = string.Format("{0:0.####}", this.NoteEntity.TotalAMT);
            this.dtblItems = this.accItems.GetDataSaleReturnItemsByNoteID(this.NoteID).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;

        }
        
        void btnSave_Click(object sender, EventArgs e)
        {
            string errormsg = string.Empty;
            bool flag = false;
            flag=this.accNotes.UpdateSaleReturnNotesForFinance (ref errormsg,
                this.NoteID,
                this.radCashSettleFlag .Checked ,
                JERPBiz.Frame.UserBiz.PsnID);
            if (!flag)
            {
                MessageBox.Show(errormsg);
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
                        "销售退货单[" + this.txtNoteCode.Text + "]付现款",
                        this.NoteEntity.MoneyTypeID,
                        this.txtTotalAMT.Text,
                        JERPBiz.Frame.UserBiz.PsnID);
                }
                else
                {
                    //银行存款
                    this.accBankAccount.InsertBankAccountForCredit (
                        ref errormsg,
                        "销售退货单[" + this.txtNoteCode.Text + "]付现款",
                        BankID ,
                        this.NoteEntity.MoneyTypeID,
                        this.txtTotalAMT.Text,
                        JERPBiz.Frame.UserBiz.PsnID);
                }
              
                foreach (DataRow drow in this.dtblItems.Rows)
                {
                    this.accItems.UpdateSaleReturnItemsForReconciliation(
                        ref errormsg,
                        drow["ItemID"],
                        -1);
                }                    
            }
            else
            {
                //应付账款
                this.accReceivableAccount.InsertReceivableAccountForCredit(
                    ref errormsg,
                    "销售退货单[" + this.txtNoteCode.Text + "]扣款",
                    this.NoteEntity.CompanyID,
                    this.NoteEntity.MoneyTypeID,
                    this.txtTotalAMT.Text,
                    JERPBiz.Frame.UserBiz.PsnID);
            }    
            //扣款就当成费用了
            this.accExpenseAccount.InsertExpenseAccountForDebit(
                ref errormsg,
                "销售退货单[" + this.txtNoteCode.Text + "]扣款",
                JERPBiz.Finance.ExpenseTypeParm.SaleFineExpense,
                decimal.Parse(this.txtTotalAMT.Text) * this.MoneyTypeParm.GetExchangeRate(this.NoteEntity.MoneyTypeID),
                JERPBiz.Frame.UserBiz.PsnID);            
            MessageBox.Show("成功完成当前退货单结款");           
            if (this.affterSave != null) this.affterSave();
            this.Close();
           
        }
    }
}