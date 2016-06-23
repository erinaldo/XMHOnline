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
    /// 表[CustomerProcessType]控件类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2015-04-25 07:23:48
    ///</时间> 
    public partial class CtrlCustomerProcessType : UserControl
    {
        public CtrlCustomerProcessType()
        {
            InitializeComponent();
            this.accDataCustomerProcessType = new JERPData.General.CustomerProcessType();
            this.cmbItem.SelectedIndexChanged += new EventHandler(cmbItem_SelectedIndexChanged);
            this.RefreshData();
        }
        private JERPData.General.CustomerProcessType accDataCustomerProcessType;
        private DataTable dtblCustomerProcessType;
        private void RefreshData()
        {
            this.dtblCustomerProcessType = this.accDataCustomerProcessType.GetDataCustomerProcessType().Tables[0];
             this.cmbItem.DataSource = this.dtblCustomerProcessType;
            this.cmbItem.ValueMember = "ProcessTypeID";
            this.cmbItem.DisplayMember = "ProcessTypeName";
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
        public int ProcessTypeID
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
            return this.dtblCustomerProcessType.Rows[this.cmbItem.SelectedIndex][FieldName];
        }
        public string ProcessTypeName
        {
            get
            {
                object objValue = this.GetFieldValue("ProcessTypeName");
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