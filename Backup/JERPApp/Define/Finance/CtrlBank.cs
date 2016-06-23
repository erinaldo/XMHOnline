using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
namespace JERPApp.Define.Finance
{
    /// <描述>
    /// 表[Bank]控件类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2015-01-04 17:03:18
    ///</时间> 
    public partial class CtrlBank : UserControl
    {
        public CtrlBank()
        {
            InitializeComponent();
            this.accDataBank = new JERPData.Finance.Bank();
            this.cmbItem.SelectedIndexChanged += new EventHandler(cmbItem_SelectedIndexChanged);
            this.RefreshData();
        }
        private JERPData.Finance.Bank accDataBank;
        private DataTable dtblBank;
        private void RefreshData()
        {
            this.dtblBank = this.accDataBank.GetDataBank().Tables[0];
            this.dtblBank.Columns.Add("exp", typeof(string), "ISNULL(BankName,'')+' '+ISNULL(BankCode,'')");
            this.cmbItem.DataSource = this.dtblBank;
            this.cmbItem.ValueMember = "BankID";
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
        public int BankID
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
            return this.dtblBank.Rows[this.cmbItem.SelectedIndex][FieldName];
        }
        public string BankName
        {
            get
            {
                object objValue = this.GetFieldValue("BankName");
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
        public string BankCode
        {
            get
            {
                object objValue = this.GetFieldValue("BankCode");
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