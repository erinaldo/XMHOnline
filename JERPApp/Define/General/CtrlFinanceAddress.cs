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
    /// 表[FinanceAddress]控件类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2014/4/10 14:44:42
    ///</时间> 
    public partial class CtrlFinanceAddress : UserControl
    {
        public CtrlFinanceAddress()
        {
            InitializeComponent();
            this.accDataFinanceAddress = new JERPData.General.FinanceAddress();
            this.cmbItem.SelectedIndexChanged += new EventHandler(cmbItem_SelectedIndexChanged);
        }
        private JERPData.General.FinanceAddress accDataFinanceAddress;
        private DataTable dtblFinanceAddress;
        public  void LoadData(int CompanyID)
        {
            this.dtblFinanceAddress = this.accDataFinanceAddress.GetDataFinanceAddressByCompanyID(CompanyID).Tables[0];
            this.cmbItem.DataSource = this.dtblFinanceAddress;
            this.cmbItem.ValueMember = "FinanceAddressID";
            this.cmbItem.DisplayMember = "Address";
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
        public int FinanceAddressID
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
            return this.dtblFinanceAddress.Rows[this.cmbItem.SelectedIndex][FieldName];
        }
        public int CompanyID
        {
            get
            {
                object objValue = this.GetFieldValue("CompanyID");
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
        public string Address
        {
            get
            {
                object objValue = this.GetFieldValue("Address");
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
    }
}