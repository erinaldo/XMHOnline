using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Sale
{
    public partial class FrmCustomerOper : Form
    {
        public FrmCustomerOper()
        {
            InitializeComponent();
            this.ctrlAreaID.DefineFlag = true;
            this.dtpDateRegister.Value = DateTime.Now.Date;
            this.accCustomers=new JERPData.General.Customer();
            this.Entity = new JERPBiz.General.CustomerEntity();
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnNew.Click += new EventHandler(btnNew_Click);
            this.btnCompanyCode.Click += new EventHandler(btnCompanyCode_Click);
            this.btnCompanyAbbName.Click += new EventHandler(btnCompanyAbbName_Click);
            this.btnCompanyAllName.Click += new EventHandler(btnCompanyAllName_Click);
        }

     
        private JERPData.General.Customer accCustomers;
        private JERPBiz.General.CustomerEntity Entity;
        private FrmCustomerSameSearch frmSame;
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
        private int companyID = -1;
        private int CompanyID
        {
            get
            {
                return this.companyID;
            }
            set
            {
                this.companyID = value;
                if (value == -1)
                {
                    this.ctrlFileBrowse.ReadOnly = true;
                    this.ctrlFileBrowse.Clear();
                }
                else
                {
                    this.ctrlFileBrowse.ReadOnly = false;
                    string file=JERPData.ServerParameter.ERPFileFolder + @"\Customer\" + value.ToString();
                    this.ctrlFileBrowse.Browse(file);
                }
            }
        }
     
        public void New()
        {
            this.CompanyID = -1;         
            this.txtCompanyAbbName.Text = string.Empty;
            this.txtCompanyAllName.Text = string.Empty;
            this.txtCompanyCode.Text = string.Empty;
            this.txtAssistantCode.Text = string.Empty;
            this.txtLegalPerson.Text = string.Empty;
            this.txtLinkman.Text = string.Empty;
            this.txtTelephone.Text = string.Empty;
            this.txtMobile.Text = string.Empty;
            this.txtFax.Text = string.Empty;
            this.txtQQ.Text = string.Empty;
            this.txtWechat.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtURL.Text = string.Empty;
            this.txtBankInfor.Text = string.Empty;
            this.txtCreditAMT.Text = string.Empty;
            this.txtMemo.Text = string.Empty;
            this.ctrlDeliverAddress.DeliverAddressOper(this.CompanyID);
            this.ctrlFinanceAddress.FinanceAddressOper(this.CompanyID);
        }
        public void Edit(int CompanyID)
        {
            this.CompanyID = CompanyID;
            this.Entity.LoadData(CompanyID);
            this.ctrlAreaID.AreaID = this.Entity.AreaID;
            this.ctrlCustomerTypeID.CustomerTypeID = this.Entity.CustomerTypeID;
            this.txtCompanyCode.Text = this.Entity.CompanyCode;
            this.txtCompanyAbbName.Text = this.Entity.CompanyAbbName;
            this.txtCompanyAllName.Text = this.Entity.CompanyAllName;
            this.txtAssistantCode.Text = this.Entity.AssistantCode;
            this.txtLegalPerson.Text = this.Entity.LegalPerson;
            if (this.Entity.DateRegister == DateTime.MinValue)
            {
                this.dtpDateRegister.Value = DateTime.Now.Date;
            }
            else
            {
                this.dtpDateRegister.Value = this.Entity.DateRegister;
            }
            this.ctrlSalePsnID.PsnID = this.Entity.SalePsnID;
            this.ctrlHandlePsnID.PsnID = this.Entity.HandlePsnID;
            this.txtLinkman.Text = this.Entity.Linkman;     
            this.txtTelephone.Text = this.Entity.Telephone;
            this.txtMobile.Text = this.Entity.Mobile;
            this.txtFax.Text = this.Entity.Fax;
            this.txtQQ.Text = this.Entity.QQ;
            this.txtWechat.Text = this.Entity.Wechat;
            this.txtEmail.Text = this.Entity.Email;
            this.txtURL.Text = this.Entity.URL;
            this.txtBankInfor.Text = this.Entity.BankInfor;
            this.txtCreditAMT.Text = (this.Entity .CreditAMT >0)?string.Format ("{0:0.####}",this.Entity.CreditAMT):string.Empty;
            this.txtMemo.Text = this.Entity.Memo ;
            this.ctrlDeliverAddress.DeliverAddressOper(this.CompanyID);
            this.ctrlFinanceAddress.FinanceAddressOper(this.CompanyID);
          
        }
 
        void btnNew_Click(object sender, EventArgs e)
        {
            this.New();
        }
        private void SameSearch(TextBox txt, string fieldname)
        {
            if (txt.Text == string.Empty) return;
            string whereclause = " and (" + fieldname + " like '%" + txt.Text + "%')";
            if (frmSame == null)
            {
                frmSame = new FrmCustomerSameSearch();
                new FrmStyle(frmSame).SetPopFrmStyle(this);               
            }
            frmSame.SameSearch(whereclause);
            frmSame.ShowDialog();
        }
        void btnCompanyAllName_Click(object sender, EventArgs e)
        {
            this.SameSearch(this.txtCompanyAllName, "CompanyAllName");
        }

        void btnCompanyAbbName_Click(object sender, EventArgs e)
        {
            this.SameSearch(this.txtCompanyAbbName , "CompanyAbbName");
        }

        void btnCompanyCode_Click(object sender, EventArgs e)
        {
            this.SameSearch(this.txtCompanyCode , "CompanyCode");
            
        }

     
        private bool ValidateData()
        {
            if ((this.txtCompanyAbbName.Text == string.Empty)
                           || (this.txtCompanyAllName.Text == string.Empty)
                           || (this.txtCompanyCode.Text == string.Empty))
            {
                MessageBox.Show("对不起,客户编号 简称 全称均不能为空");
                return false;
            }
            if (this.ctrlSalePsnID.PsnID == -1)
            {
                MessageBox.Show("对不起,业务员不能为空");
                return false;
            }
            if (this.ctrlHandlePsnID.PsnID == -1)
            {
                MessageBox.Show("对不起,跟单人不能为空");
                return false;
            }
         
            if (this.txtCreditAMT.Text != string.Empty)
            {
                decimal d;
                if (!decimal.TryParse(this.txtCreditAMT.Text, out d))
                {
                    MessageBox.Show("信用额度出错");
                    return false;
                }
            }
            int companyid = -1;
            this.accCustomers.GetParmCustomerCompanyID(this.txtCompanyCode.Text, ref companyid);
            if ((companyid > -1)&&(companyid !=this.CompanyID ))
            {
                MessageBox.Show("对不起,已存在此客户编号");
                return false;
            }
            return true;
        }
        void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateData() == false) return;
         
            string errormsg = string.Empty;
            bool flag = false;       
            int SalePsnID = ctrlSalePsnID.PsnID;
            int HandlePsnID = this.ctrlHandlePsnID.PsnID;
            object objCreditAMT = DBNull.Value; 
            if (this.txtCreditAMT.Text.Length > 0)
            {
                objCreditAMT = decimal.Parse(this.txtCreditAMT.Text);
            }
             
            if (this.CompanyID == -1)
            {
                object objCompanyID = DBNull.Value;
                flag = this.accCustomers.InsertCustomer(
                    ref errormsg,
                    ref objCompanyID,
                    this.txtCompanyCode.Text,
                    this.txtCompanyAbbName.Text,
                    this.txtCompanyAllName.Text,
                    this.txtAssistantCode .Text ,
                    this.txtLegalPerson.Text,
                    this.ctrlCustomerTypeID.CustomerTypeID,
                    this.dtpDateRegister.Value.Date,
                    this.ctrlAreaID.AreaID,
                    SalePsnID,
                    HandlePsnID,
                    this.txtLinkman.Text, 
                    this.txtTelephone.Text,
                    this.txtMobile .Text ,
                    this.txtFax.Text,
                    this.txtQQ .Text ,
                    this.txtWechat .Text ,
                    this.txtEmail.Text,
                    this.txtURL .Text ,
                    this.txtBankInfor .Text ,
                    objCreditAMT ,
                    this.txtMemo.Text);
                if (flag)
                {
                    this.CompanyID = (int)objCompanyID;
                }
            }
            else
            {
                flag = this.accCustomers.UpdateCustomer(ref errormsg,
                    this.CompanyID,
                     this.txtCompanyCode.Text,
                    this.txtCompanyAbbName.Text,
                    this.txtCompanyAllName.Text,
                    this.txtAssistantCode.Text,
                    this.txtLegalPerson.Text,
                    this.ctrlCustomerTypeID.CustomerTypeID,
                    this.dtpDateRegister.Value.Date,
                    this.ctrlAreaID.AreaID,
                    SalePsnID,
                    HandlePsnID,
                    this.txtLinkman.Text,
                    this.txtTelephone.Text,
                    this.txtMobile.Text,
                    this.txtFax.Text,
                    this.txtQQ.Text,
                    this.txtWechat.Text,
                    this.txtEmail.Text,
                    this.txtURL .Text ,
                    this.txtBankInfor.Text,
                    objCreditAMT ,
                    this.txtMemo.Text);
            }
            if (!flag)
            {
                MessageBox.Show(errormsg);
            }
            else
            {
                this.ctrlDeliverAddress.Save(this.CompanyID);
                this.ctrlFinanceAddress.Save(this.CompanyID);
                this.accCustomers.UpdateCustomerForAddress(ref errormsg, this.CompanyID);
                MessageBox.Show("成功保存当前客户信息!");
                if (this.affterSave != null) this.affterSave();
              
            }
           
        }
    }
}