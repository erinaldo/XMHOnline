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
    /// 表[DeliverType]控件类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2014/1/20 14:11:14
    ///</时间> 
    public partial class CtrlDeliverType : UserControl
    {
        public CtrlDeliverType()
        {
            InitializeComponent();
            this.accDataDeliverType = new JERPData.General.DeliverType();
            this.cmbItem.SelectedIndexChanged += new EventHandler(cmbItem_SelectedIndexChanged);
            this.RefreshData();
        }
        private JERPData.General.DeliverType accDataDeliverType;
        private DataTable dtblDeliverType;
        private FrmDeliverType frmDefine;
        private void RefreshData()
        {
            this.dtblDeliverType = this.accDataDeliverType.GetDataDeliverType().Tables[0];
            this.dtblDeliverType.Columns.Add("Exp", typeof(string), "ISNULL(DeliverTypeCode,'')+ISNULL(DeliverTypeName,'')");
            this.cmbItem.DataSource = this.dtblDeliverType;
            this.cmbItem.ValueMember = "DeliverTypeID";
            this.cmbItem.DisplayMember = "Exp";
        }
        public void AllowDefine()
        {
            this.cmbItem.MouseDown += new MouseEventHandler(cmbItem_MouseDown);
            new ToolTip().SetToolTip(this.cmbItem, "右击定义");
        }

        void cmbItem_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (frmDefine == null)
                {
                    frmDefine = new FrmDeliverType();
                    new FrmStyle(frmDefine).SetPopFrmStyle(this);
                    frmDefine.AffterSave += this.RefreshData;
                }
                frmDefine.ShowDialog();
            }
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
        public int DeliverTypeID
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
            return this.dtblDeliverType.Rows[this.cmbItem.SelectedIndex][FieldName];
        }
        public string DeliverTypeName
        {
            get
            {
                object objValue = this.GetFieldValue("DeliverTypeName");
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
        public string DeliverTypeCode
        {
            get
            {
                object objValue = this.GetFieldValue("DeliverTypeCode");
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