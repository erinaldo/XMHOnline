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
    /// 表[CustomerSourceType]控件类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2015-04-25 07:23:48
    ///</时间> 
    public partial class CtrlCustomerSourceType : UserControl
    {
        public CtrlCustomerSourceType()
        {
            InitializeComponent();
            this.accDataCustomerSourceType = new JERPData.General.CustomerSourceType();
            this.cmbItem.SelectedIndexChanged += new EventHandler(cmbItem_SelectedIndexChanged);
            this.RefreshData();
        }
        private JERPData.General.CustomerSourceType accDataCustomerSourceType;
        private DataTable dtblCustomerSourceType;
        private void RefreshData()
        {
            this.dtblCustomerSourceType = this.accDataCustomerSourceType.GetDataCustomerSourceType().Tables[0];
            this.cmbItem.DataSource = this.dtblCustomerSourceType;
            this.cmbItem.ValueMember = "SourceTypeID";
            this.cmbItem.DisplayMember = "SourceTypeName";
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
        public int SourceTypeID
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
            return this.dtblCustomerSourceType.Rows[this.cmbItem.SelectedIndex][FieldName];
        }
        public string SourceTypeName
        {
            get
            {
                object objValue = this.GetFieldValue("SourceTypeName");
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