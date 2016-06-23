using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.General
{
    public partial class FrmSupplier : Form
    {
        public FrmSupplier()
        {
            InitializeComponent();
            this.Entity = new JERPBiz.General.SupplierEntity();
            this.lnkURL.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkURL_LinkClicked);
        }

        private JERPBiz.General.SupplierEntity Entity;
        public void Detail(int CompanyID)
        {
            this.Entity.LoadData(CompanyID);
            this.txtCompanyCode.Text = Entity.CompanyCode;
            this.txtCompanyAbbName.Text = Entity.CompanyAbbName;
            this.txtCompanyAllName.Text = Entity.CompanyAllName;
            this.txtLinkman.Text = Entity.Linkman;
            this.txtLegalPerson.Text = Entity.LegalPerson;
            this.txtTelephone.Text = Entity.Telephone;
            this.txtMobile.Text = Entity.Mobile;
            this.txtFax.Text = Entity.Fax;
            this.txtQQ.Text = Entity.QQ;
            this.txtWechat.Text = Entity.Wechat;
            this.txtEmail.Text = Entity.Email;
            this.lnkURL.Text = Entity.URL;
            this.rchBankInfor.Text = Entity.BankInfor;
            this.rchAddress.Text = Entity.Address;
            this.rchMemo.Text = Entity.Memo; 
            
            this.chkMtrFlag.Checked = Entity.MtrFlag;
            this.chkOutSrcFlag.Checked = Entity.OutSrcFlag;
            this.ckbOtherResFlag.Checked = Entity.OtherResFlag;
            this.ckbToolFlag.Checked = Entity.ToolFlag;

            this.ctrlFileBrowse.ReadOnly = false;
            string file = JERPData.ServerParameter.ERPFileFolder + @"\Supply\" + CompanyID.ToString();
            this.ctrlFileBrowse.Browse(file);

        
        }


        void lnkURL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(this.lnkURL.Text);
        }  
    }
}