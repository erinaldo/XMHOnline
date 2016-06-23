using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
namespace JERPApp.Define.Tool
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
    public partial class CtrlPrdType : UserControl
    {
        public CtrlPrdType()
        {
            InitializeComponent();
            this.accDataPrdType = new JERPData.Tool.PrdType();
            this.cmbItem.SelectedIndexChanged += new EventHandler(cmbItem_SelectedIndexChanged);
            this.RefreshData();
        }
        private JERPData.Tool.PrdType accDataPrdType;
        private DataTable dtblPrdType;
        private FrmPrdType frmDefine;
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
                    this.frmDefine = new FrmPrdType();
                    new FrmStyle(this.frmDefine).SetPopFrmStyle(this.ParentForm);
                    this.frmDefine.AffterSave += this.RefreshData;
                }
                frmDefine.ShowDialog();
            }
        }
        public void RefreshData()
        {
            this.dtblPrdType = this.accDataPrdType.GetDataPrdType().Tables[0];
            if (this.insertAllRowFlag)
            {
                this.InsertAllRow();
            } 
            this.cmbItem.DataSource = this.dtblPrdType;
            this.cmbItem.ValueMember = "PrdTypeID";
            this.cmbItem.DisplayMember = "PrdTypeName";
            if (this.affterRefreshData != null) this.affterRefreshData();
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
        public delegate void AffterRefreshDataDelegate();
        private AffterRefreshDataDelegate affterRefreshData;
        public event AffterRefreshDataDelegate AffterRefreshData
        {
            add
            {
                affterRefreshData += value;
            }
            remove
            {
                affterRefreshData -= value;
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