using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Sale
{
    public partial class FrmBeforeCustomerOper : Form
    {
        public FrmBeforeCustomerOper()
        {
            InitializeComponent();
            this.accCustomer = new JERPData.General.PotentialCustomer();
            this.CustomerEntity = new JERPBiz.General.PotentialCustomerEntity();
            this.ctrlRegisterPsnID.PsnID = JERPBiz.Frame.UserBiz.PsnID;
            this.ctrlSalePsnID.PsnID = JERPBiz.Frame.UserBiz.PsnID;
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnNew.Click += new EventHandler(btnNew_Click);
            this.btnSame.Click += new EventHandler(btnSame_Click);
        }

      
        JERPData.General.PotentialCustomer accCustomer;
        JERPBiz.General.PotentialCustomerEntity CustomerEntity;
        private FrmBeforeCustomerSameSearch frmSame;
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
        void btnSame_Click(object sender, EventArgs e)
        {
            if (this.txtCompanyName.Text == string.Empty) return;
            if (frmSame == null)
            {
                frmSame = new FrmBeforeCustomerSameSearch();
                new FrmStyle(frmSame).SetPopFrmStyle(this);            
            }
            frmSame.SameSearch(" and (CompanyName like '%" + this.txtCompanyName.Text + "%')");
            frmSame.ShowDialog();
        }
 
        private int companyid = -1;
        private int CompanyID
        {
            get
            {
                return this.companyid;
            }
            set
            {
                this.companyid = value;
                this.dtpDateRegister.Enabled = (value == -1);
                this.ctrlSourceTypeID.Enabled = (value == -1);
                this.ctrlRegisterPsnID.Enabled = (value == -1);
                this.ctrlSalePsnID.Enabled = (value == -1);
            }
        }
        public void New()
        {
            this.CompanyID = -1;
            this.txtCompanyName.Text = string.Empty;
            this.txtLinkman.Text = string.Empty;
            this.txtTelephone.Text = string.Empty;
            this.txtMobile.Text = string.Empty;
            this.txtQQ.Text = string.Empty;
            this.txtWecast.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtAddress.Text = string.Empty;
            this.txtURL.Text = string.Empty;
            this.txtMemo.Text = string.Empty;
            this.dtpDateContact.Value = DateTime.Now.Date;
            this.dtpDateNextContact.Value = DateTime.Now.Date.AddDays(30);
            this.txtResultContact.Text = string.Empty;
        }
        public void Edit(int CompanyID)
        {
            this.CompanyID = CompanyID;
            this.CustomerEntity.LoadData(CompanyID);
            this.dtpDateRegister.Value = this.CustomerEntity.DateRegister.Date;
            this.ctrlSourceTypeID.SourceTypeID = this.CustomerEntity.SourceTypeID;
            this.ctrlRegisterPsnID.PsnID = this.CustomerEntity.RegisterPsnID;
            this.ctrlSalePsnID.PsnID = this.CustomerEntity.SalePsnID;

            this.txtCompanyName.Text = this.CustomerEntity.CompanyName;
            this.txtLinkman.Text = this.CustomerEntity.Linkman ;
            this.txtTelephone.Text = this.CustomerEntity.Telephone;
            this.txtMobile.Text = this.CustomerEntity.Mobile;
            this.txtQQ.Text = this.CustomerEntity.QQ;
            this.txtWecast.Text = this.CustomerEntity.Wechat;
            this.txtEmail.Text = this.CustomerEntity.Email;
            this.txtURL.Text = this.CustomerEntity.URL;
            this.txtAddress.Text = this.CustomerEntity.Address;
            this.txtMemo.Text = this.CustomerEntity.Memo;

            this.dtpDateContact.Value = this.CustomerEntity.DateContact;
            this.dtpDateNextContact.Value = this.CustomerEntity.DateNextContact;
            this.txtResultContact.Text = this.CustomerEntity.ResultContact;
        }
        private bool ValidateData()
        {
            if (this.txtCompanyName.Text.Length == 0)
            {
                MessageBox.Show("客户名称不能为空");
                return false;
            }
            if (this.ctrlSourceTypeID.SourceTypeID == -1)
            {
                MessageBox.Show("未指定来源方式");
                return false;
            }
            if (this.ctrlRegisterPsnID.PsnID == -1)
            {
                MessageBox.Show("未批定注册人");
                return false;
            }
            if (this.ctrlSalePsnID .PsnID == -1)
            {
                MessageBox.Show("未指定销售人");
                return false;
            }
            return true;
        }

        void btnNew_Click(object sender, EventArgs e)
        {
            this.New();
        }   
        void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateData() == false) return;
            string errormsg = string.Empty;
            bool flag = false;
            if (this.CompanyID == -1)
            {
                DialogResult rul = MessageBox.Show("即将新增售前客户，一经保存，日期和注册人来源方式均不能变更！", "新增确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rul == DialogResult.No) return;
                object objCompanyID = DBNull.Value;
                flag = this.accCustomer.InsertPotentialCustomer(ref errormsg,
                    ref objCompanyID,
                    this.dtpDateRegister.Value.Date,
                    this.ctrlSourceTypeID.SourceTypeID,
                    this.ctrlRegisterPsnID.PsnID,
                    this.txtCompanyName.Text,
                    this.txtLinkman.Text,
                    this.txtTelephone.Text,
                    this.txtMobile.Text,
                    this.txtQQ.Text,
                    this.txtWecast.Text,
                    this.txtEmail.Text,
                    this.txtURL .Text ,
                    this.txtAddress.Text,
                    this.txtMemo.Text,                        
                    this.ctrlSalePsnID.PsnID);
                if (flag)
                {
                    this.CompanyID = (int)objCompanyID;
                }
            }
            else
            {
                flag=this.accCustomer .UpdatePotentialCustomer (
                    ref errormsg ,
                    this.CompanyID ,
                    this.txtCompanyName.Text,
                    this.txtLinkman.Text,
                    this.txtTelephone.Text,
                    this.txtMobile.Text,
                    this.txtQQ.Text,
                    this.txtWecast.Text,
                    this.txtEmail.Text,
                    this.txtURL .Text ,
                    this.txtAddress.Text,
                    this.txtMemo.Text);
            }
            if (flag)
            {
                MessageBox.Show("成功保存当前客户");         
                this.accCustomer.UpdatePotentialCustomerForProcess(
                    ref errormsg,
                    this.CompanyID,
                    this.ctrlProcessTypeID.ProcessTypeID,
                    this.dtpDateContact.Value.Date,
                    this.txtResultContact .Text ,
                    this.dtpDateNextContact.Value.Date);

                if (this.affterSave != null) this.affterSave();
            }
            else
            {
                MessageBox.Show(errormsg);
            }
        }
    }
}