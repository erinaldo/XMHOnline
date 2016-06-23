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
    /// 表[PrdType]控件类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2014/3/26 8:42:46
    ///</时间> 
    public partial class CtrlManufPrdType : UserControl
    {
        public CtrlManufPrdType()
        {
            InitializeComponent();
            this.accDataPrdType = new JERPData.Product.PrdType();
            this.cmbItem.SelectedIndexChanged += new EventHandler(cmbItem_SelectedIndexChanged);
            this.RefreshData();
        }
        private JERPData.Product.PrdType accDataPrdType;
        private DataTable dtblPrdType;      
        private void RefreshData()
        {
            this.dtblPrdType = this.accDataPrdType.GetDataPrdTypeForManufPrd().Tables[0];
            if (this.insertAllRowFlag)
            {
                this.InsertAllRow();
            } 
            this.cmbItem.DataSource = this.dtblPrdType;
            this.cmbItem.ValueMember = "PrdTypeID";
            this.cmbItem.DisplayMember = "PrdTypeName";
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
        private bool insertAllRowFlag = false;
        public bool InsertAllRowFlag
        {
            get
            {
                return this.insertAllRowFlag;
            }
            set
            {
                this.insertAllRowFlag = value;
                if (value)
                {
                    this.InsertAllRow();
                }

            }
        }
        private void InsertAllRow()
        {
            DataRow drow = this.dtblPrdType.NewRow();
            drow["PrdTypeID"] = -1;
            drow["PrdTypeName"] = "全部";
            if (this.dtblPrdType.Rows.Count > 0)
            {
                this.dtblPrdType.Rows.InsertAt(drow, 0);
            }
            else
            {
                this.dtblPrdType.Rows.Add(drow);
            }
            this.cmbItem.SelectedIndex = 0;
        }
        private void cmbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.affterSelected != null)
            {
                this.affterSelected();
            }
        }
        public int PrdTypeID
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
            return this.dtblPrdType.Rows[this.cmbItem.SelectedIndex][FieldName];
        }
        public string PrdTypeCode
        {
            get
            {
                object objValue = this.GetFieldValue("PrdTypeCode");
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
        public string PrdTypeName
        {
            get
            {
                object objValue = this.GetFieldValue("PrdTypeName");
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