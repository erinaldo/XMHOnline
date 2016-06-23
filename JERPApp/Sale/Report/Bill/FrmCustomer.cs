using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Sale.Report.Bill
{
    public partial class FrmCustomer : Form
    {
        public FrmCustomer()
        {
            InitializeComponent();
            this.dgrdvDeliver.AutoGenerateColumns = false;
            this.dgrdvFinance.AutoGenerateColumns = false;
            this.Entity = new JERPBiz.General.CustomerEntity();
            this.lnkURL.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkURL_LinkClicked);
            this.accDeliverAddress = new JERPData.General.DeliverAddress();
            this.accFinanceAddress = new JERPData.General.FinanceAddress();
        }
   
        private JERPBiz.General.CustomerEntity Entity;
        private JERPData.General.DeliverAddress accDeliverAddress;
        private JERPData.General.FinanceAddress accFinanceAddress;
        private DataTable dtblDeliverAddress, dtblFinanceAddress;
        public void Detail(int CompanyID)
        {        
            this.Entity.LoadData(CompanyID);
            this.txtAreaName.Text  = this.Entity.AreaName ;
            this.txtCompanyCode.Text = this.Entity.CompanyCode;
            this.txtCompanyAbbName.Text = this.Entity.CompanyAbbName;
            this.txtCompanyAllName.Text = this.Entity.CompanyAllName;

            this.txtDateRegister.Text = string.Empty;
            if (this.Entity.DateRegister != DateTime.MinValue)
            {
                this.txtDateRegister.Text = this.Entity.DateRegister.ToShortDateString();
            }
            this.txtSalePsn.Text = this.Entity.SalePsn;
            this.txtHandlePsn.Text = this.Entity.HandlePsn;
            this.txtCustomerTypeName.Text = this.Entity.CustomerTypeName;
            this.txtTotalMainAMT.Text = string.Format ("{0:0.####}",this.Entity.TotalMainAMT);
            this.txtDateLastOrder.Text = this.Entity.DateLastOrder.ToShortDateString();
            this.txtLinkman.Text = this.Entity.Linkman;
            this.txtTelephone.Text = this.Entity.Telephone;
            this.txtMobile.Text = this.Entity.Mobile;
            this.txtFax.Text = this.Entity.Fax;
            this.txtQQ.Text = this.Entity.QQ;
            this.txtWechat.Text = this.Entity.Wechat;
            this.txtEmail.Text = this.Entity.Email;
            this.lnkURL.Text = this.Entity.URL;
            this.txtBankInfor.Text = this.Entity.BankInfor;
            this.txtMemo.Text = this.Entity.Memo;

            this.dtblDeliverAddress = this.accDeliverAddress.GetDataDeliverAddressByCompanyID(CompanyID).Tables[0];
            this.dgrdvDeliver.DataSource = this.dtblDeliverAddress;
            this.dtblFinanceAddress = this.accFinanceAddress.GetDataFinanceAddressByCompanyID(CompanyID).Tables[0];
            this.dgrdvFinance.DataSource = this.dtblFinanceAddress;

            this.ctrlFileBrowse.ReadOnly = false;
            string file = JERPData.ServerParameter.ERPFileFolder + @"\Customer\" + CompanyID.ToString();
            this.ctrlFileBrowse.Browse(file);
        }

        void lnkURL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(this.lnkURL.Text);
        }  
     
    }
}