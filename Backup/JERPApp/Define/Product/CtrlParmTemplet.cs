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
    /// 表[ParmTemplet]控件类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2014/3/3 18:15:04
    ///</时间> 
    public partial class CtrlParmTemplet : UserControl
    {
        public CtrlParmTemplet()
        {
            InitializeComponent();
            this.accDataParmTemplet = new JERPData.Product.ParmTemplet();
            this.cmbItem.SelectedIndexChanged += new EventHandler(cmbItem_SelectedIndexChanged);
            this.RefreshData();
        }
        private JERPData.Product.ParmTemplet accDataParmTemplet;
        private DataTable dtblParmTemplet;
        private void RefreshData()
        {
            this.dtblParmTemplet = this.accDataParmTemplet.GetDataParmTemplet().Tables[0];
            this.cmbItem.DataSource = this.dtblParmTemplet;
            this.cmbItem.ValueMember = "TempletID";
            this.cmbItem.DisplayMember = "TempletName";
        }
        JERPApp.Define.Product.FrmParmTemplet  frmDefine = null;
        public void AllowDefine()
        {
            new ToolTip().SetToolTip(this.cmbItem, "右健新增");
            this.cmbItem.MouseDown += new MouseEventHandler(cmbItem_MouseDown);
        }
        void cmbItem_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (frmDefine == null)
                {
                    frmDefine = new FrmParmTemplet();
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
        public int TempletID
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
            return this.dtblParmTemplet.Rows[this.cmbItem.SelectedIndex][FieldName];
        }
        public string TempletName
        {
            get
            {
                object objValue = this.GetFieldValue("TempletName");
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