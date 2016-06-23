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
    /// 表[Express]控件类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2014/1/19 20:23:37
    ///</时间> 
    public partial class CtrlExpress : UserControl
    {
        public CtrlExpress()
        {
            InitializeComponent();
            this.accDataExpress = new JERPData.General.Express();
            this.cmbItem.SelectedIndexChanged += new EventHandler(cmbItem_SelectedIndexChanged);
            this.RefreshData();
        }
        private JERPData.General.Express accDataExpress;
        private DataTable dtblExpress;
        private void RefreshData()
        {
            this.dtblExpress = this.accDataExpress.GetDataExpress().Tables[0];
            this.dtblExpress.Columns.Add("exp", typeof(string), "ISNULL(CompanyName,'')");
            this.cmbItem.DataSource = this.dtblExpress;
            this.cmbItem.ValueMember = "CompanyID";
            this.cmbItem.DisplayMember = "exp";
        }
        public void AppendNull()
        {
            if (this.dtblExpress.Rows.Count > 0)
            {
                DataRow drowNew = this.dtblExpress.NewRow ();
                drowNew["CompanyID"] = -1;
                drowNew["CompanyName"] = string.Empty;
                this.dtblExpress.Rows.InsertAt(drowNew, 0);
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
        public int CompanyID
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
            return this.dtblExpress.Rows[this.cmbItem.SelectedIndex][FieldName];
        }
        public new string CompanyName
        {
            get
            {
                object objValue = this.GetFieldValue("CompanyName");
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
        public string ReceiveCompanyNameCellName
        {
            get
            {
                object objValue = this.GetFieldValue("ReceiveCompanyNameCellName");
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
        public string ReceiveAddressCellName
        {
            get
            {
                object objValue = this.GetFieldValue("ReceiveAddressCellName");
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
        public string LinkmanCellName
        {
            get
            {
                object objValue = this.GetFieldValue("LinkmanCellName");
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
        public string TelephoneCellName
        {
            get
            {
                object objValue = this.GetFieldValue("TelephoneCellName");
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