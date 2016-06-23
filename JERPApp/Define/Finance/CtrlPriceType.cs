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
    /// 表[PriceType]控件类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2014-12-28 09:27:13
    ///</时间> 
    public partial class CtrlPriceType : UserControl
    {
        public CtrlPriceType()
        {
            InitializeComponent();
            this.accDataPriceType = new JERPData.Finance.PriceType();
            this.cmbItem.SelectedIndexChanged += new EventHandler(cmbItem_SelectedIndexChanged);
            this.RefreshData();
        }
        private JERPData.Finance.PriceType accDataPriceType;
        private DataTable dtblPriceType;
        private void RefreshData()
        {
            this.dtblPriceType = this.accDataPriceType.GetDataPriceType().Tables[0];
            this.dtblPriceType.Columns.Add("exp", typeof(string), "ISNULL(PriceTypeCode,'')+' '+ISNULL(PriceTypeName,'')");
            this.cmbItem.DataSource = this.dtblPriceType;
            this.cmbItem.ValueMember = "PriceTypeID";
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
        public int PriceTypeID
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
            return this.dtblPriceType.Rows[this.cmbItem.SelectedIndex][FieldName];
        }
        public string PriceTypeCode
        {
            get
            {
                object objValue = this.GetFieldValue("PriceTypeCode");
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
        public string PriceTypeName
        {
            get
            {
                object objValue = this.GetFieldValue("PriceTypeName");
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
        public decimal TaxRate
        {
            get
            {
                object objValue = this.GetFieldValue("TaxRate");
                if (objValue == DBNull.Value)
                {
                    return -1;
                }
                else
                {
                    return (decimal)objValue;
                }
            }
        }
    }
}