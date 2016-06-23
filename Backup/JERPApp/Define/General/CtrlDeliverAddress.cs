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
    /// 表[DeliverAddress]控件类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2014/4/10 14:44:42
    ///</时间> 
    public partial class CtrlDeliverAddress : UserControl
    {
        public CtrlDeliverAddress()
        {
            InitializeComponent();
            this.accDataDeliverAddress = new JERPData.General.DeliverAddress();
            this.cmbItem.SelectedIndexChanged += new EventHandler(cmbItem_SelectedIndexChanged);
        }
        private JERPData.General.DeliverAddress accDataDeliverAddress;
        private DataTable dtblDeliverAddress;
        public  void LoadData(int CompanyID)
        {
            this.dtblDeliverAddress = this.accDataDeliverAddress.GetDataDeliverAddressByCompanyID(CompanyID).Tables[0];
            this.cmbItem.DataSource = this.dtblDeliverAddress;
            this.cmbItem.ValueMember = "DeliverAddressID";
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
        public int DeliverAddressID
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
            return this.dtblDeliverAddress.Rows[this.cmbItem.SelectedIndex][FieldName];
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