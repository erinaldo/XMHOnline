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
    /// 表[ProcessTemplet]控件类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2014/5/1 20:40:00
    ///</时间> 
    public partial class CtrlProcessTemplet : UserControl
    {
        public CtrlProcessTemplet()
        {
            InitializeComponent();
            this.accDataProcessTemplet = new JERPData.Technology.ProcessTemplet();
            this.cmbItem.SelectedIndexChanged += new EventHandler(cmbItem_SelectedIndexChanged);
            this.RefreshData();
        }
        private JERPData.Technology.ProcessTemplet accDataProcessTemplet;
        private DataTable dtblProcessTemplet;
        private FrmProcessTemplet frmDefine;
        public void AllowDefine()
        {
            new ToolTip().SetToolTip(this.cmbItem, "右击自定义");
            this.cmbItem.MouseDown += new MouseEventHandler(cmbItem_MouseDown);
        }

        void cmbItem_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (frmDefine == null)
                {
                    frmDefine = new FrmProcessTemplet();
                    new FrmStyle(frmDefine).SetPopFrmStyle(this.ParentForm);
                    frmDefine.AffterSave += this.RefreshData;
                }
                frmDefine.ShowDialog();
            }
        }
        private void RefreshData()
        {
            this.dtblProcessTemplet = this.accDataProcessTemplet.GetDataProcessTemplet().Tables[0];
            this.cmbItem.DataSource = this.dtblProcessTemplet;
            this.cmbItem.ValueMember = "TempletID";
            this.cmbItem.DisplayMember = "TempletName";
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
            return this.dtblProcessTemplet.Rows[this.cmbItem.SelectedIndex][FieldName];
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