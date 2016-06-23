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
    /// 表[DiaryType]控件类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2014-11-27 22:31:15
    ///</时间> 
    public partial class CtrlDiaryType : UserControl
    {
        public CtrlDiaryType()
        {
            InitializeComponent();
            this.accDataDiaryType = new JERPData.General.DiaryType();
            this.cmbItem.SelectedIndexChanged += new EventHandler(cmbItem_SelectedIndexChanged);
            this.RefreshData();
        }
        private JERPData.General.DiaryType accDataDiaryType;
        private DataTable dtblDiaryType;
        private void RefreshData()
        {
            this.dtblDiaryType = this.accDataDiaryType.GetDataDiaryType().Tables[0];
            this.dtblDiaryType.Columns.Add("exp", typeof(string), "ISNULL(DiaryTypeName,'')");
            this.cmbItem.DataSource = this.dtblDiaryType;
            this.cmbItem.ValueMember = "DiaryTypeID";
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
        public int DiaryTypeID
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
            return this.dtblDiaryType.Rows[this.cmbItem.SelectedIndex][FieldName];
        }
        public string DiaryTypeName
        {
            get
            {
                object objValue = this.GetFieldValue("DiaryTypeName");
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