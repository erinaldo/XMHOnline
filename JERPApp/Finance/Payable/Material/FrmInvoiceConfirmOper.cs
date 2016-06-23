using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Payable.Material
{
    public partial class FrmInvoiceConfirmOper : Form
    {
        public FrmInvoiceConfirmOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accInvoices = new JERPData.Material.BuyInvoices();
            this.accReceiveItems = new JERPData.Material.BuyReceiveItems();
            this.InvoiceEntity = new JERPBiz.Material.BuyInvoiceEntity();
            this.accPayableAccount = new JERPData.Finance.PayableAccount();
            this.MoneyTypeParm = new JERPBiz.Finance.MoneyTypeParm();
            this.accStore = new JERPData.Material.Store();
            this.accPrd = new JERPData.Product.Product(); 
            this.dgrdv.AutoGenerateColumns = false;
            this.dgrdv.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdv_DataBindingComplete);
            this.btnSave.Click += new EventHandler(btnSave_Click);
        }

      
        private JERPData.Material.BuyInvoices accInvoices;
        private JERPData.Material.BuyReceiveItems accReceiveItems;
        private JERPBiz.Material.BuyInvoiceEntity InvoiceEntity;
        private JERPData.Finance.PayableAccount accPayableAccount;
        private JERPBiz.Finance.MoneyTypeParm MoneyTypeParm;
        private JERPData.Material.Store accStore;
        private JERPData.Product.Product accPrd;
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
            this.dtblItems = this.accReceiveItems.GetDataBuyReceiveItemsByInvoiceID(this.InvoiceID).Tables[0];
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
        private bool GetPrdSetFlag(int PrdID)
        {
            bool flag = false;
            this.accPrd.GetParmProductPrdSetFlag(PrdID, ref flag);
            return flag;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
           
            DialogResult rul = MessageBox.Show("将进行保存入账一经确认不能变更！", "审核确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return;
            bool flag = false;
            string errormsg = string.Empty;
            flag = this.accInvoices.UpdateBuyInvoicesForConfirm(ref errormsg,
                this.InvoiceID,
                JERPBiz.Frame.UserBiz.PsnID);
            if (!flag)
            {
                MessageBox.Show(errormsg);
                return;
            }
            //完的是差别应付款
            decimal AppendAMT = 0;
            foreach (DataRow drow in this.dtblItems.Rows)
            {
                if ((drow["ItemAMT"]!= DBNull.Value)
                    && (drow["ReceiveItemAMT"] != DBNull.Value))
                {
                    AppendAMT += (decimal)drow["ItemAMT"] - (decimal)drow["ReceiveItemAMT"];
                }
                if (this.GetPrdSetFlag((int)drow["PrdID"]) == false)
                {
                    //如果不是套料就得这么搞
                    if ((drow["CostAMT"] != DBNull.Value)
                        && (drow["ReceiveCostAMT"] != DBNull.Value))
                    {
                        //库存之差额
                        this.accStore.UpdateStoreForAppendInventoryAMT(
                            ref errormsg,
                            drow["PrdID"],
                            drow["BranchStoreID"],
                           (decimal)drow["CostAMT"] - (decimal)drow["ReceiveCostAMT"]);

                    }
                }
            }
         
            //这里不去惹税金
            if (AppendAMT!=0)
            {
                //应付账款
                this.accPayableAccount.InsertPayableAccountForCredit(
                         ref errormsg,
                        "供应商["+this.txtCompanyAbbName .Text +"]原料采购发票[" + this.txtInvoiceCode .Text + "]",
                        this.InvoiceEntity .CompanyID,
                        this.InvoiceEntity.MoneyTypeID,
                        AppendAMT,
                        JERPBiz.Frame.UserBiz.PsnID);
            }            
           
            MessageBox.Show("成功审核当前采购发票");
            if (this.affterSave != null) this.affterSave();
            this.Close();

        }

    }
}