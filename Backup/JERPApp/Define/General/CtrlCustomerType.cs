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
    /// 表[CustomerType]控件类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2014/1/20 14:11:14
    ///</时间> 
    public partial class CtrlCustomerType : UserControl
    {
        public CtrlCustomerType()
        {
            InitializeComponent();
            this.accDataCustomerType = new JERPData.General.CustomerType();
            this.cmbItem.SelectedIndexChanged += new EventHandler(cmbItem_SelectedIndexChanged);
            this.RefreshData();
        }
        private JERPData.General.CustomerType accDataCustomerType;
        private DataTable dtblCustomerType;
  
        private void RefreshData()
        {
            this.dtblCustomerType = this.accDataCustomerType.GetDataCustomerType().Tables[0];
            this.cmbItem.DataSource = this.dtblCustomerType;
            this.cmbItem.ValueMember = "CustomerTypeID";
            this.cmbItem.DisplayMember = "CustomerTypeName";
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
        public int CustomerTypeID
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
            return this.dtblCustomerType.Rows[this.cmbItem.SelectedIndex][FieldName];
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