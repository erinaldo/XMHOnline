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
    /// 表[CtrlInvoiceType]控件类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2015/6/30 10:30:58
    ///</时间> 
    public partial class CtrlInvoiceType : UserControl
    {
        public CtrlInvoiceType()
        {
            InitializeComponent();
            this.accInvoiceType = new JERPData.Finance.InvoiceType();
            this.cmbItem.SelectedIndexChanged += new EventHandler(cmbItem_SelectedIndexChanged);
            this.RefreshData();
        }
        private JERPData.Finance.InvoiceType accInvoiceType;
        private DataTable dtblInvoiceType;
        private void RefreshData()
        {
            this.dtblInvoiceType = this.accInvoiceType.GetDataInvoiceType().Tables[0];
            this.dtblInvoiceType.Columns.Add("exp", typeof(string), "ISNULL(InvoiceTypeCode,'')+' '+ISNULL(InvoiceTypeName,'')");
            this.cmbItem.DataSource = this.dtblInvoiceType;
            this.cmbItem.ValueMember = "InvoiceTypeID";
            this.cmbItem.DisplayMember = "exp";
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
        public int InvoiceTypeID
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
            return this.dtblInvoiceType.Rows[this.cmbItem.SelectedIndex][FieldName];
        }
        public string InvoiceTypeCode
        {
            get
            {
                object objValue = this.GetFieldValue("InvoiceTypeCode");
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
        public string InvoiceTypeName
        {
            get
            {
                object objValue = this.GetFieldValue("InvoiceTypeName");
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