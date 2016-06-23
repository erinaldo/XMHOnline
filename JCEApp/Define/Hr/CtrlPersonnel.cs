using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
namespace JCEApp.Define.Hr
{
    /// <描述>
    /// 表[BranchStore]控件类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2014-09-29 09:29:43
    ///</时间> 
    public partial class CtrlPersonnel : UserControl
    {
        public CtrlPersonnel()
        {
            InitializeComponent();
            this.accPsn = new JCEData.Hr.Personnel();
            this.cmbItem.SelectedIndexChanged += new EventHandler(cmbItem_SelectedIndexChanged);
            this.RefreshData();
            this.btnRefresh .Click +=new EventHandler(btnRefresh_Click);
        }
        private JCEData.Hr.Personnel accPsn;
        private DataTable dtblPsns;
        private void RefreshData()
        {
            this.dtblPsns = this.accPsn .GetDataPersonnel ().Tables[0];          
            this.cmbItem.DataSource = this.dtblPsns;
            this.cmbItem.ValueMember = "PsnID";
            this.cmbItem.DisplayMember = "PsnName";
        }

        void btnRefresh_Click(object sender, EventArgs e)
        {
            this.RefreshData();
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
        public int PsnID
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
            return this.dtblPsns.Rows[this.cmbItem.SelectedIndex][FieldName];
        }
        public string PsnName
        {
            get
            {
                object objValue = this.GetFieldValue("PsnName");
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
        public string PsnCode
        {
            get
            {
                object objValue = this.GetFieldValue("PsnCode");
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