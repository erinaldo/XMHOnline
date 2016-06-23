using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
namespace JERPApp.Define.General
{
    /// <描述>
    /// 表[Customer]控件类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2014/3/27 9:46:00
    ///</时间> 
    public partial class CtrlCustomer : UserControl
    {
        public CtrlCustomer()
        {
            InitializeComponent();
            this.accDataCustomer = new JERPData.General.Customer();
            this.cmbItem.SelectedIndexChanged += new EventHandler(cmbItem_SelectedIndexChanged);
            this.RefreshData();
        }
        private JERPData.General.Customer accDataCustomer;
        private DataTable dtblCustomer;
        private void RefreshData()
        {
            this.dtblCustomer = this.accDataCustomer.GetDataCustomer().Tables[0];
            this.dtblCustomer.Columns.Add("exp", typeof(string), "ISNULL(AssistantCode,'')+' '+ISNULL(CompanyAbbName,'')");
            this.cmbItem.DataSource = this.dtblCustomer;
            this.cmbItem.ValueMember = "CompanyID";
            this.cmbItem.DisplayMember = "exp";
        }
        public void AppendAll()
        {
            if (this.dtblCustomer.Rows.Count > 0)
            {
                DataRow drowNew = this.dtblCustomer.NewRow();
                drowNew["CompanyID"] = -1;
                drowNew["CompanyCode"] = "不限";
                drowNew["CompanyAbbName"] = string.Empty;
                this.dtblCustomer.Rows.InsertAt(drowNew, 0);
                this.cmbItem.SelectedIndex = 0;
            }
        }
        public delegate void AffterSelectedDelegate();
        private AffterSelectedDelegate affterSelected;
        public event AffterSelectedDelegate AffterSelected
        {
            add
            {
                affterSelected += value;
            }
            remove
            {
                affterSelected -= value;
            }
        }
        private void cmbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.affterSelected != null)
            {
                this.affterSelected();
            }
        }
        public int CompanyID
        {
            get
            {
                if (this.cmbItem.SelectedIndex == -1) return -1;
                return (int)this.cmbItem.SelectedValue;
            }
            set
            {
                if (value == -1)
                {
                    this.cmbItem.SelectedIndex = -1;
                }
                else
                {
                    this.cmbItem.SelectedValue = value;
                }
            }
        }
        private object GetFieldValue(string FieldName)
        {
            if (this.cmbItem.SelectedIndex == -1) return DBNull.Value;
            return this.dtblCustomer.Rows[this.cmbItem.SelectedIndex][FieldName];
        }
        public string CompanyCode
        {
            get
            {
                object objValue = this.GetFieldValue("CompanyCode");
                if (objValue == DBNull.Value)
                {
                    return string.Empty;
                }
                else
                {
                    return objValue.ToString();
                }
            }
        }
        public string CompanyAbbName
        {
            get
            {
                object objValue = this.GetFieldValue("CompanyAbbName");
                if (objValue == DBNull.Value)
                {
                    return string.Empty;
                }
                else
                {
                    return objValue.ToString();
                }
            }
        }
        public string CompanyAllName
        {
            get
            {
                object objValue = this.GetFieldValue("CompanyAllName");
                if (objValue == DBNull.Value)
                {
                    return string.Empty;
                }
                else
                {
                    return objValue.ToString();
                }
            }
        }
        public string LegalPerson
        {
            get
            {
                object objValue = this.GetFieldValue("LegalPerson");
                if (objValue == DBNull.Value)
                {
                    return string.Empty;
                }
                else
                {
                    return objValue.ToString();
                }
            }
        }
        public int CustomerTypeID
        {
            get
            {
                object objValue = this.GetFieldValue("CustomerTypeID");
                if (objValue == DBNull.Value)
                {
                    return -1;
                }
                else
                {
                    return (int)objValue;
                }
            }
        }
        public DateTime DateRegister
        {
            get
            {
                object objValue = this.GetFieldValue("DateRegister");
                if (objValue == DBNull.Value)
                {
                    return DateTime.MinValue;
                }
                else
                {
                    return (DateTime)objValue;
                }
            }
        }
        public int AreaID
        {
            get
            {
                object objValue = this.GetFieldValue("AreaID");
                if (objValue == DBNull.Value)
                {
                    return -1;
                }
                else
                {
                    return (int)objValue;
                }
            }
        }
        public int SalePsnID
        {
            get
            {
                object objValue = this.GetFieldValue("SalePsnID");
                if (objValue == DBNull.Value)
                {
                    return -1;
                }
                else
                {
                    return (int)objValue;
                }
            }
        }
        public int HandlePsnID
        {
            get
            {
                object objValue = this.GetFieldValue("HandlePsnID");
                if (objValue == DBNull.Value)
                {
                    return -1;
                }
                else
                {
                    return (int)objValue;
                }
            }
        }
        public string Linkman
        {
            get
            {
                object objValue = this.GetFieldValue("Linkman");
                if (objValue == DBNull.Value)
                {
                    return string.Empty;
                }
                else
                {
                    return objValue.ToString();
                }
            }
        }
        public string Telephone
        {
            get
            {
                object objValue = this.GetFieldValue("Telephone");
                if (objValue == DBNull.Value)
                {
                    return string.Empty;
                }
                else
                {
                    return objValue.ToString();
                }
            }
        }
        public string Mobile
        {
            get
            {
                object objValue = this.GetFieldValue("Mobile");
                if (objValue == DBNull.Value)
                {
                    return string.Empty;
                }
                else
                {
                    return objValue.ToString();
                }
            }
        }
        public string Fax
        {
            get
            {
                object objValue = this.GetFieldValue("Fax");
                if (objValue == DBNull.Value)
                {
                    return string.Empty;
                }
                else
                {
                    return objValue.ToString();
                }
            }
        }
        public string QQ
        {
            get
            {
                object objValue = this.GetFieldValue("QQ");
                if (objValue == DBNull.Value)
                {
                    return string.Empty;
                }
                else
                {
                    return objValue.ToString();
                }
            }
        }
        public string Wechat
        {
            get
            {
                object objValue = this.GetFieldValue("Wechat");
                if (objValue == DBNull.Value)
                {
                    return string.Empty;
                }
                else
                {
                    return objValue.ToString();
                }
            }
        }
        public string Email
        {
            get
            {
                object objValue = this.GetFieldValue("Email");
                if (objValue == DBNull.Value)
                {
                    return string.Empty;
                }
                else
                {
                    return objValue.ToString();
                }
            }
        }
        public string DeliverAddress
        {
            get
            {
                object objValue = this.GetFieldValue("DeliverAddress");
                if (objValue == DBNull.Value)
                {
                    return string.Empty;
                }
                else
                {
                    return objValue.ToString();
                }
            }
        }
        public string FinanceAddress
        {
            get
            {
                object objValue = this.GetFieldValue("FinanceAddress");
                if (objValue == DBNull.Value)
                {
                    return string.Empty;
                }
                else
                {
                    return objValue.ToString();
                }
            }
        }
        public string BankInfor
        {
            get
            {
                object objValue = this.GetFieldValue("BankInfor");
                if (objValue == DBNull.Value)
                {
                    return string.Empty;
                }
                else
                {
                    return objValue.ToString();
                }
            }
        }
        public string Memo
        {
            get
            {
                object objValue = this.GetFieldValue("Memo");
                if (objValue == DBNull.Value)
                {
                    return string.Empty;
                }
                else
                {
                    return objValue.ToString();
                }
            }
        }
        public decimal CreditAMT
        {
            get
            {
                object objValue = this.GetFieldValue("CreditAMT");
                if (objValue == DBNull.Value)
                {
                    return 0;
                }
                else
                {
                    return (decimal)objValue;
                }
            }
        }
        public decimal TotalMainAMT
        {
            get
            {
                object objValue = this.GetFieldValue("TotalMainAMT");
                if (objValue == DBNull.Value)
                {
                    return 0;
                }
                else
                {
                    return (decimal)objValue;
                }
            }
        }
        public DateTime DateLastOrder
        {
            get
            {
                object objValue = this.GetFieldValue("DateLastOrder");
                if (objValue == DBNull.Value)
                {
                    return DateTime.MinValue;
                }
                else
                {
                    return (DateTime)objValue;
                }
            }
        }
        public string SalePsn
        {
            get
            {
                object objValue = this.GetFieldValue("SalePsn");
                if (objValue == DBNull.Value)
                {
                    return string.Empty;
                }
                else
                {
                    return objValue.ToString();
                }
            }
        }
        public string HandlePsn
        {
            get
            {
                object objValue = this.GetFieldValue("HandlePsn");
                if (objValue == DBNull.Value)
                {
                    return string.Empty;
                }
                else
                {
                    return objValue.ToString();
                }
            }
        }
        public string AreaName
        {
            get
            {
                object objValue = this.GetFieldValue("AreaName");
                if (objValue == DBNull.Value)
                {
                    return string.Empty;
                }
                else
                {
                    return objValue.ToString();
                }
            }
        }
        public string CustomerTypeName
        {
            get
            {
                object objValue = this.GetFieldValue("CustomerTypeName");
                if (objValue == DBNull.Value)
                {
                    return string.Empty;
                }
                else
                {
                    return objValue.ToString();
                }
            }
        }
    }
}