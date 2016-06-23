using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
namespace JERPApp.Define.Technology
{
    /// <描述>
    /// 表[ProcessType]控件类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2014/4/11 8:45:33
    ///</时间> 
    public partial class CtrlProcessType : UserControl
    {
        public CtrlProcessType()
        {
            InitializeComponent();
            this.accDataProcessType = new JERPData.Technology.ProcessType();
            this.cmbItem.SelectedIndexChanged += new EventHandler(cmbItem_SelectedIndexChanged);
            this.RefreshData();
        }
        private JERPData.Technology.ProcessType accDataProcessType;
        private DataTable dtblProcessType;
        private void RefreshData()
        {
            this.dtblProcessType = this.accDataProcessType.GetDataProcessType().Tables[0];
            this.dtblProcessType.Columns.Add("exp", typeof(string), "ISNULL(ProcessTypeCode,'')+' '+ISNULL(ProcessTypeName,'')");
            this.cmbItem.DataSource = this.dtblProcessType;
            this.cmbItem.ValueMember = "ProcessTypeID";
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
            return this.dtblProcessType.Rows[this.cmbItem.SelectedIndex][FieldName];
        }
        public string ProcessTypeCode
        {
            get
            {
                object objValue = this.GetFieldValue("ProcessTypeCode");
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