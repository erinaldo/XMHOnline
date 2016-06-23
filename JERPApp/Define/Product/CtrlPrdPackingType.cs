using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
namespace JERPApp.Define.Product
{
    /// <描述>
    /// 表[PackingType]控件类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2014/3/19 7:40:38
    ///</时间> 
    public partial class CtrlPrdPackingType : UserControl
    {
        public CtrlPrdPackingType()
        {
            InitializeComponent();
            this.accDataPackingType = new JERPData.Product.PackingType();
            this.cmbItem.SelectedIndexChanged += new EventHandler(cmbItem_SelectedIndexChanged);
           
        }
        private JERPData.Product.PackingType accDataPackingType;
        private DataTable dtblPackingType;
        public  void LoadData(int PrdID)
        {
           
            this.dtblPackingType = this.accDataPackingType.GetDataPackingTypeByPrdID(PrdID).Tables[0];
            this.cmbItem.DataSource = this.dtblPackingType;
            this.cmbItem.ValueMember = "PackingTypeID";
            this.cmbItem.DisplayMember = "PackingTypeName";
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
        public int PackingTypeID
        {
            get
            {
                if (this.cmbItem.SelectedIndex == -1) return -1;
                try
                {
                    return (int)this.cmbItem.SelectedValue;
                }
                catch
                {
                    return -1;
                }
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
            return this.dtblPackingType.Rows[this.cmbItem.SelectedIndex][FieldName];
        }
        public int PrdID
        {
            get
            {
                object objValue = this.GetFieldValue("PrdID");
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
        public string PackingTypeName
        {
            get
            {
                object objValue = this.GetFieldValue("PackingTypeName");
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
        public string Description
        {
            get
            {
                object objValue = this.GetFieldValue("Description");
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