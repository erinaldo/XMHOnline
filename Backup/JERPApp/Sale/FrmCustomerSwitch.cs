using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Sale
{
    public partial class FrmCustomerSwitch : Form
    {
        public FrmCustomerSwitch()
        {
            InitializeComponent();
            this.ctrlAreaID.DefineFlag = true;
            this.dtpDateRegister.Value = DateTime.Now.Date;
            this.accCustomers=new JERPData.General.Customer();
            this.accBeforeCustomer = new JERPData.General.PotentialCustomer();
            this.BeforeEntity = new JERPBiz.General.PotentialCustomerEntity();
            this.btnSave.Click += new EventHandler(btnSave_Click);
        }

     
        private JERPData.General.Customer accCustomers;
        private JERPData.General.PotentialCustomer accBeforeCustomer;
        private JERPBiz.General.PotentialCustomerEntity BeforeEntity;
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
                    string file = JERPData.ServerParameter.ERPFileFolder + @"\Sale\Customer\" + value.ToString();
                    this.ctrlFileBrowse.Browse(file);
                }
            }
        }
        private int BeforeCompanyID = -1;
      
        public void Switch(int BeforeCompanyID)
        {
            this.CompanyID =-1;
            this.BeforeCompanyID = BeforeCompanyID;
            this.BeforeEntity.LoadData(BeforeCompanyID);
            this.txtCompanyCode.Text = string.Empty;
            this.txtCompanyAbbName.Text = this.BeforeEntity.CompanyName;
            this.txtCompanyAllName.Text = this.BeforeEntity.CompanyName;
            this.txtAssistantCode.Text = string.Empty;
            this.txtLegalPerson.Text = string.Empty;
          
            this.dtpDateRegister.Value = DateTime.Now.Date;
            
            this.ctrlSalePsnID.PsnID = this.BeforeEntity.SalePsnID;
            this.ctrlHandlePsnID.PsnID = this.BeforeEntity.SalePsnID;
            this.txtLinkman.Text = this.BeforeEntity.Linkman;   
            this.txtTelephone.Text = this.BeforeEntity.Telephone;
            this.txtMobile.Text = this.BeforeEntity.Mobile;
            this.txtFax.Text = string.Empty;
            this.txtQQ.Text = this.BeforeEntity.QQ;
            this.txtEmail.Text = this.BeforeEntity.Email;
            this.txtURL.Text = this.BeforeEntity.URL;
            this.txtWechat.Text = this.BeforeEntity.Wechat;
            this.txtBankInfor.Text = string.Empty;
            this.txtCreditAMT.Text = string.Empty;
            this.txtMemo .Text = this.BeforeEntity.Memo ;
            this.ctrlDeliverAddress.DeliverAddressOper(-1);
            this.ctrlFinanceAddress.FinanceAddressOper(-1);
          
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
            if (this.ctrlSalePsnID .PsnID == -1)
            {
                MessageBox.Show("对不起,业务员不能为空");
                return false;
            }
            if (this.ctrlHandlePsnID.PsnID == -1)
            {
                MessageBox.Show("对不起,跟单人不能为空");
                return false;
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
                    this.txtAssistantCode.Text,
                    this.txtLegalPerson.Text,
                    this.ctrlCustomerTypeID.CustomerTypeID,
                    this.dtpDateRegister.Value.Date,
                    this.ctrlAreaID.AreaID,
                    this.ctrlSalePsnID.PsnID,
                    this.ctrlHandlePsnID.PsnID,
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
                    this.txtAssistantCode .Text ,
                    this.ctrlCustomerTypeID.CustomerTypeID,
                    this.txtLegalPerson.Text,
                    this.ctrlAreaID.AreaID,
                    this.dtpDateRegister.Value.Date,
                    this.ctrlSalePsnID.PsnID,
                    this.ctrlHandlePsnID.PsnID,
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
            if (flag)
            {
                   
                this.ctrlDeliverAddress.Save(this.CompanyID);
                this.ctrlFinanceAddress.Save(this.CompanyID);
                this.accCustomers.UpdateCustomerForAddress(ref errormsg, this.CompanyID);
                //设置售前客户为完成状态
                this.accBeforeCustomer.UpdatePotentialCustomerForSuccess(ref errormsg, this.BeforeCompanyID);
                MessageBox.Show("成功保存当前客户信息!");
                if (this.affterSave != null) this.affterSave();
            }                       
            else
            {
                MessageBox.Show(errormsg);
            }
          
           
        }
    }
}