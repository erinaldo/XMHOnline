using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Payable.OutSrc
{
    public partial class FrmOutSrcInvoiceConfirmOper : Form
    {
        public FrmOutSrcInvoiceConfirmOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accInvoices = new JERPData.Manufacture.OutSrcInvoices();
            this.accReceiveItems = new JERPData.Manufacture.OutSrcReceiveItems();
            this.InvoiceEntity = new JERPBiz.Manufacture.OutSrcInvoiceEntity();
            this.accPayableAccount = new JERPData.Finance.PayableAccount();
            this.accExpenseAccount = new JERPData.Finance.ExpenseAccount();
            this.MoneyTypeParm = new JERPBiz.Finance.MoneyTypeParm();
            this.dgrdv.AutoGenerateColumns = false;
            this.dgrdv.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdv_DataBindingComplete);
            this.btnSave.Click += new EventHandler(btnSave_Click);
        }

      
        private JERPData.Manufacture.OutSrcInvoices accInvoices;
        private JERPData.Manufacture.OutSrcReceiveItems accReceiveItems;
        private JERPBiz.Manufacture.OutSrcInvoiceEntity InvoiceEntity;
        private JERPData.Finance.PayableAccount accPayableAccount;
        private JERPData.Finance.ExpenseAccount accExpenseAccount;
        private JERPBiz.Finance.MoneyTypeParm MoneyTypeParm;
        private DataTable dtblItems;
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

        private long invoiceID = -1;
        private long InvoiceID
        {
            get
            {
                return this.invoiceID;
            }
            set
            {
                this.invoiceID = value;
                this.btnSave.Enabled = (value > -1);
            }
        }
        public void ConfirmOper(long InvoiceID)
        {
            this.InvoiceID = InvoiceID;
            this.InvoiceEntity.LoadData(InvoiceID);
            this.txtInvoiceCode.Text = this.InvoiceEntity.InvoiceCode;
            this.txtInvoiceName.Text = this.InvoiceEntity.InvoiceName;
            this.txtDateNote.Text = this.InvoiceEntity.DateNote.ToShortDateString();
            this.txtCompanyAbbName.Text = this.InvoiceEntity.CompanyAbbName;
            this.txtInvoiceTypeName.Text = this.InvoiceEntity.InvoiceTypeName;
            this.txtMoneyTypeName.Text = this.InvoiceEntity.MoneyTypeName;
            this.txtTotalAMT.Text = string.Format("{0:0.####}", this.InvoiceEntity.TotalAMT);
            this.txtTaxAMT.Text = string.Format("{0:0.####}", this.InvoiceEntity.TaxAMT);
            this.txtYear.Text = this.InvoiceEntity.Year.ToString();
            this.txtMonth.Text = this.InvoiceEntity.Month.ToString();
            this.dtblItems = this.accReceiveItems.GetDataOutSrcReceiveItemsByInvoiceID(this.InvoiceID).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
        }
        void dgrdv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.btnSave.Enabled = true;
            foreach (DataGridViewRow grow in this.dgrdv.Rows)
            {
                grow.ErrorText = string.Empty;
                if (grow.Cells[this.ColumnPrice.Name].Value == DBNull.Value )
                {
                    grow.ErrorText = "未设单价!";
                    this.btnSave.Enabled = false;
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
           
            DialogResult rul = MessageBox.Show("将进行保存入账一经确认不能变更！", "审核确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return;
            bool flag = false;
            string errormsg = string.Empty;
            flag = this.accInvoices.UpdateOutSrcInvoicesForConfirm(ref errormsg,
                this.invoiceID,
                JERPBiz.Frame.UserBiz.PsnID);
            if (!flag)
            {
                MessageBox.Show(errormsg);
                return;
            }
            decimal TotalAMT = this.InvoiceEntity.TotalAMT;
            decimal CostAMT = TotalAMT*this.MoneyTypeParm.GetExchangeRate(this.InvoiceEntity.MoneyTypeID);
            //这里不去惹税金
            if (TotalAMT > 0)
            {
                //应付账款
                this.accPayableAccount.InsertPayableAccountForCredit(
                         ref errormsg,
                        "供应商["+this.txtCompanyAbbName .Text +"]委外发票[" + this.txtInvoiceCode .Text + "]",
                        this.InvoiceEntity .CompanyID,
                        this.InvoiceEntity.MoneyTypeID,
                        TotalAMT,
                        JERPBiz.Frame.UserBiz.PsnID);
            }            
            if(CostAMT >0)
            {
                //加工费用
                this.accExpenseAccount.InsertExpenseAccountForDebit(ref errormsg,
                        "供应商[" + this.txtCompanyAbbName.Text + "]委外发票[" + this.txtInvoiceCode.Text + "]",
                        JERPBiz.Finance.ExpenseTypeParm.OutSrcExpense,
                        CostAMT,
                        JERPBiz.Frame.UserBiz.PsnID);
            }
            MessageBox.Show("成功审核当前委外发票");
            if (this.affterSave != null) this.affterSave();
            this.Close();

        }

    }
}