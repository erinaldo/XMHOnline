using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Supply
{
    public partial class FrmSupplierOper : Form
    {
        public FrmSupplierOper()
        {
            InitializeComponent();
            this.accSupplier = new JERPData.General.Supplier();
            this.Entity = new JERPBiz.General.SupplierEntity();
            this.btnNew .Click +=new EventHandler(btnNew_Click);
            this.btnSave .Click +=new EventHandler(btnSave_Click);
        }
        private JERPData.General.Supplier accSupplier;
        private JERPBiz.General.SupplierEntity Entity;
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
                    string file = JERPData.ServerParameter.ERPFileFolder + @"\Supplier\" + value.ToString();
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
            this.txtAddress.Text = string.Empty;
            this.txtMemo.Text = string.Empty;
           
        }
        public void Edit(int CompanyID)
        {
            this.CompanyID = CompanyID;
            this.Entity.LoadData(CompanyID);
        
            this.txtCompanyCode.Text = this.Entity.CompanyCode;
            this.txtCompanyAbbName.Text = this.Entity.CompanyAbbName;
            this.txtCompanyAllName.Text = this.Entity.CompanyAllName; 
            this.txtLegalPerson.Text = this.Entity.LegalPerson;
            this.ckbMtrFlag.Checked = this.Entity.MtrFlag;
            this.ckbOtherResFlag.Checked = this.Entity.OtherResFlag;
            this.ckbOutSrcFlag.Checked = this.Entity.OutSrcFlag; 
            this.ckbPrdFlag.Checked = this.Entity.PrdFlag;
            this.ckbToolFlag.Checked = this.Entity.ToolFlag;
            this.ckbSolutionFlag.Checked = this.Entity.SolutionFlag;
            this.txtLinkman.Text = this.Entity.Linkman;
            this.txtTelephone.Text = this.Entity.Telephone;
            this.txtMobile.Text = this.Entity.Mobile;
            this.txtFax.Text = this.Entity.Fax;
            this.txtQQ.Text = this.Entity.QQ;
            this.txtWechat.Text = this.Entity.Wechat;
            this.txtEmail.Text = this.Entity.Email;
            this.txtURL.Text = this.Entity.URL;
            this.txtAddress.Text = this.Entity.Address;
            this.txtBankInfor.Text = this.Entity.BankInfor;
            this.txtMemo.Text = this.Entity.Memo;
           

        }

        void btnNew_Click(object sender, EventArgs e)
        {
            this.New();
        }

        private bool ValidateData()
        {
            if ((this.txtCompanyAbbName.Text == string.Empty)
                           || (this.txtCompanyAllName.Text == string.Empty)
                           || (this.txtCompanyCode.Text == string.Empty))
            {
                MessageBox.Show("对不起,供应商编号 简称 全称均不能为空");
                return false;
            }
          
            int companyid = -1;
            this.accSupplier.GetParmSupplierCompanyID (this.txtCompanyCode.Text, ref companyid);
            if ((companyid > -1) && (companyid != this.CompanyID))
            {
                MessageBox.Show("对不起,已存在此供应商编号");
                return false;
            }
            return true;
        }
        void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateData() == false) return;
            string errormsg = string.Empty;
            bool flag = false;           
            if (this.CompanyID == -1)
            {
                object objCompanyID = DBNull.Value;
                flag = this.accSupplier.InsertSupplier(
                    ref errormsg,
                    ref objCompanyID,
                    this.txtCompanyCode.Text,
                    this.txtCompanyAbbName.Text,
                    this.txtCompanyAllName.Text, 
                    this.txtLegalPerson.Text,
                    this.ckbMtrFlag .Checked ,
                    this.ckbPrdFlag.Checked, 
                    this.ckbOtherResFlag.Checked,
                    this.ckbToolFlag.Checked,
                    this.ckbOutSrcFlag .Checked ,
                    this.ckbSolutionFlag .Checked ,
                    this.txtLinkman.Text,
                    this.txtTelephone.Text,
                    this.txtMobile.Text,
                    this.txtFax.Text,
                    this.txtQQ.Text,
                    this.txtWechat.Text,
                    this.txtEmail.Text,
                    this.txtURL .Text ,
                    this.txtAddress .Text ,
                    this.txtBankInfor.Text,
                    this.txtMemo.Text);
                if (flag)
                {
                    this.CompanyID = (int)objCompanyID;
                }
            }
            else
            {
                flag = this.accSupplier.UpdateSupplier (ref errormsg,
                    this.CompanyID,
                     this.txtCompanyCode.Text,
                    this.txtCompanyAbbName.Text,
                    this.txtCompanyAllName.Text, 
                    this.txtLegalPerson.Text,
                     this.ckbMtrFlag.Checked,
                    this.ckbPrdFlag.Checked, 
                    this.ckbOtherResFlag.Checked,
                    this.ckbToolFlag.Checked,
                    this.ckbOutSrcFlag.Checked,
                    this.ckbSolutionFlag.Checked,
                    this.txtLinkman.Text,
                    this.txtTelephone.Text,
                    this.txtMobile.Text,
                    this.txtFax.Text,
                    this.txtQQ.Text,
                    this.txtWechat.Text,
                    this.txtEmail.Text,
                    this.txtURL .Text ,
                    this.txtAddress .Text ,
                    this.txtBankInfor.Text,
                    this.txtMemo.Text);
            }
            if (!flag)
            {
                MessageBox.Show(errormsg);
            }
            else
            {
                MessageBox.Show("成功保存当前供应商信息!");
                if (this.affterSave != null) this.affterSave();

            }

        }
    }
}