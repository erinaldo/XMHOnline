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
    /// 表[SettleType]控件类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2014-12-16 21:48:37
    ///</时间> 
    public partial class CtrlSettleType : UserControl
    {
        public CtrlSettleType()
        {
            InitializeComponent();
            this.accDataSettleType = new JERPData.Finance.SettleType();
            this.cmbItem.SelectedIndexChanged += new EventHandler(cmbItem_SelectedIndexChanged);
            this.RefreshData();
        }
        private JERPData.Finance.SettleType accDataSettleType;
        private DataTable dtblSettleType;
        private void RefreshData()
        {
            this.dtblSettleType = this.accDataSettleType.GetDataSettleType().Tables[0];
            this.cmbItem.DataSource = this.dtblSettleType;
            this.cmbItem.ValueMember = "SettleTypeID";
            this.cmbItem.DisplayMember = "SettleTypeName";
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
        public int SettleTypeID
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
            return this.dtblSettleType.Rows[this.cmbItem.SelectedIndex][FieldName];
        }
        public string SettleTypeCode
        {
            get
            {
                object objValue = this.GetFieldValue("SettleTypeCode");
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
        public string SettleTypeName
        {
            get
            {
                object objValue = this.GetFieldValue("SettleTypeName");
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
        public bool CashSettleFlag
        {
            get
            {
                object objValue = this.GetFieldValue("CashSettleFlag");
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