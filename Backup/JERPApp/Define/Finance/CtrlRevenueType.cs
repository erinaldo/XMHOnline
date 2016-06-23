using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
namespace JERPApp.Define.Finance
{
    /// <描述>
    /// 表[RevenueType]控件类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2015-01-15 09:37:17
    ///</时间> 
    public partial class CtrlRevenueType : UserControl
    {
        public CtrlRevenueType()
        {
            InitializeComponent();
            this.accDataRevenueType = new JERPData.Finance.RevenueType();
            this.cmbItem.SelectedIndexChanged += new EventHandler(cmbItem_SelectedIndexChanged);
            this.RefreshData();
        }
        private JERPData.Finance.RevenueType accDataRevenueType;
        private DataTable dtblRevenueType;
        private void RefreshData()
        {
            this.dtblRevenueType = this.accDataRevenueType.GetDataRevenueType().Tables[0];
            this.cmbItem.DataSource = this.dtblRevenueType;
            this.cmbItem.ValueMember = "RevenueTypeID";
            this.cmbItem.DisplayMember = "RevenueTypeName";
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
        public int RevenueTypeID
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
            return this.dtblRevenueType.Rows[this.cmbItem.SelectedIndex][FieldName];
        }
        public string RevenueTypeName
        {
            get
            {
                object objValue = this.GetFieldValue("RevenueTypeName");
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
        public bool LockFlag
        {
            get
            {
                object objValue = this.GetFieldValue("LockFlag");
                if (objValue == DBNull.Value)
                {
                    return false;
                }
                else
                {
                    return (bool)objValue;
                }
            }
        }
    }
}