using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Account
{
    public partial class FrmAccountBookCheck : Form
    {
        public FrmAccountBookCheck()
        {
            InitializeComponent();
            this.SetPermit();
        }
        FrmBankAccountCheck frmBank;
        FrmCashAccountCheck frmCash;
        FrmExpressPayableAccountCheck frmExpressPayable;
        FrmExpressReceivableAccountCheck frmExpressReceivable;
        FrmPayableAccountCheck frmPayable;
        FrmReceivableAccountCheck frmReceivable;
        FrmExpenseAccountCheck frmExpense;
        FrmRevenueAccountCheck frmRevenue;
        //È¨ÏÞÂë
        private bool enableBrowse = false;//ä¯ÀÀ
        private bool enableSave = false;//±£´æ  
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(599);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(600);
            this.btnCash.Enabled = this.enableSave;
            this.btnBank.Enabled = this.enableSave;
            this.btnReceivable.Enabled = this.enableSave;
            this.btnExpressReceivable.Enabled = this.enableSave;
            this.btnPayable.Enabled = this.enableSave;
            this.btnExpressPayable.Enabled = this.enableSave;
            this.btnExpense.Enabled = this.enableSave;
            this.btnRevenue.Enabled = this.enableSave;
            if (this.enableSave)
            {
                this.btnBank.Click += new EventHandler(btnBank_Click);
                this.btnCash.Click += new EventHandler(btnCash_Click);
                this.btnExpressPayable.Click += new EventHandler(btnExpressPayable_Click);
                this.btnExpressReceivable.Click += new EventHandler(btnExpressReceivable_Click);
                this.btnPayable.Click += new EventHandler(btnPayable_Click);
                this.btnReceivable.Click += new EventHandler(btnReceivable_Click);
                this.btnExpense.Click += new EventHandler(btnExpense_Click);
                this.btnRevenue.Click += new EventHandler(btnRevenue_Click);
            }
        }

        void btnReceivable_Click(object sender, EventArgs e)
        {
            if (frmReceivable == null)
            {
                frmReceivable = new FrmReceivableAccountCheck();
                new FrmStyle(frmReceivable).SetPopFrmStyle(this);
            }
            frmReceivable.AccountCheck();
            frmReceivable.ShowDialog();
        }

        void btnPayable_Click(object sender, EventArgs e)
        {
            if (frmPayable == null)
            {
                frmPayable = new FrmPayableAccountCheck();
                new FrmStyle(frmPayable).SetPopFrmStyle(this);
            }
            frmPayable.AccountCheck();
            frmPayable.ShowDialog();
        }

        void btnExpressReceivable_Click(object sender, EventArgs e)
        {
            if (frmExpressReceivable  == null)
            {
                frmExpressReceivable = new FrmExpressReceivableAccountCheck();
                new FrmStyle(frmExpressReceivable).SetPopFrmStyle(this);
            }
            frmExpressReceivable.AccountCheck();
            frmExpressReceivable.ShowDialog();
        }

        void btnExpressPayable_Click(object sender, EventArgs e)
        {
            if (frmExpressPayable  == null)
            {
                frmExpressPayable = new FrmExpressPayableAccountCheck();
                new FrmStyle(frmExpressPayable).SetPopFrmStyle(this);
            }
            frmExpressPayable.AccountCheck();
            frmExpressPayable.ShowDialog();
        }

        void btnCash_Click(object sender, EventArgs e)
        {
            if (frmCash  == null)
            {
                frmCash = new FrmCashAccountCheck();
                new FrmStyle(frmCash).SetPopFrmStyle(this);
            }
            frmCash.AccountCheck();
            frmCash.ShowDialog();
        }

        void btnBank_Click(object sender, EventArgs e)
        {
            if (frmBank == null)
            {
                frmBank = new FrmBankAccountCheck();
                new FrmStyle(frmBank).SetPopFrmStyle(this);
            }
            frmBank.AccountCheck();
            frmBank.ShowDialog();
        }



        void btnRevenue_Click(object sender, EventArgs e)
        {
            if (frmRevenue == null)
            {
                frmRevenue = new FrmRevenueAccountCheck();
                new FrmStyle(frmRevenue).SetPopFrmStyle(this);
            }
            frmRevenue.AccountCheck();
            frmRevenue.ShowDialog();
        }

        void btnExpense_Click(object sender, EventArgs e)
        {
            if (frmExpense == null)
            {
                frmExpense = new FrmExpenseAccountCheck();
                new FrmStyle(frmExpense).SetPopFrmStyle(this);
            }
            frmExpense.AccountCheck();
            frmExpense.ShowDialog();
        }

    }
}