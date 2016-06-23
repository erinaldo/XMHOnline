using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
namespace JERPApp.Define.Manufacture
{
    /// <描述>
    /// 表[OutSrcOrderType]控件类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2014/3/24 21:42:49
    ///</时间> 
    public partial class CtrlOutSrcOrderType : UserControl
    {
        public CtrlOutSrcOrderType()
        {
            InitializeComponent();
            this.accDataOutSrcOrderType = new JERPData.Manufacture.OutSrcOrderType();
            this.cmbItem.SelectedIndexChanged += new EventHandler(cmbItem_SelectedIndexChanged);
            this.RefreshData();
        }
        private JERPData.Manufacture.OutSrcOrderType accDataOutSrcOrderType;
        private DataTable dtblOutSrcOrderType;
        private FrmOutSrcOrderType frmDefine;
        public void AllowDefine()
        {
            new ToolTip().SetToolTip(this.cmbItem, "右击设置");
            this.cmbItem.MouseDown += new MouseEventHandler(cmbItem_MouseDown);
        }
        void cmbItem_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (frmDefine == null)
                {
                    this.frmDefine = new FrmOutSrcOrderType();
                    new FrmStyle(this.frmDefine).SetPopFrmStyle(this.ParentForm);
                    this.frmDefine.AffterSave += this.RefreshData;
                }
                frmDefine.ShowDialog();
            }
        }
        private void RefreshData()
        {
            this.dtblOutSrcOrderType = this.accDataOutSrcOrderType.GetDataOutSrcOrderType().Tables[0];
            this.dtblOutSrcOrderType.Columns.Add("exp", typeof(string), "ISNULL(OrderTypeCode,'')+' '+ISNULL(OrderTypeName,'')");
            this.cmbItem.DataSource = this.dtblOutSrcOrderType;
            this.cmbItem.ValueMember = "OrderTypeID";
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
        public int OrderTypeID
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
            return this.dtblOutSrcOrderType.Rows[this.cmbItem.SelectedIndex][FieldName];
        }
        public string OrderTypeCode
        {
            get
            {
                object objValue = this.GetFieldValue("OrderTypeCode");
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
        public string OrderTypeName
        {
            get
            {
                object objValue = this.GetFieldValue("OrderTypeName");
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