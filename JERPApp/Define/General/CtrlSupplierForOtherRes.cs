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
    /// 表[SupplierForOtherRes]控件类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2014/5/30 14:52:17
    ///</时间> 
    public partial class CtrlSupplierForOtherRes : UserControl
    {
        public CtrlSupplierForOtherRes()
        {
            InitializeComponent();
            this.accDataSupplier = new JERPData.General.Supplier();
            this.cmbItem.SelectedIndexChanged += new EventHandler(cmbItem_SelectedIndexChanged);
            this.RefreshData();
        }
        private JERPData.General.Supplier accDataSupplier;
        private DataTable dtblSupplier;
        private void RefreshData()
        {
            this.dtblSupplier = this.accDataSupplier.GetDataSupplierForOtherRes().Tables[0];
            this.dtblSupplier.Columns.Add("exp", typeof(string), "ISNULL(CompanyCode,'')+' '+ISNULL(CompanyAbbName,'')");
            this.cmbItem.DataSource = this.dtblSupplier;
            this.cmbItem.ValueMember = "CompanyID";
            this.cmbItem.DisplayMember = "exp";
        }
        public void AppendAll()
        {
            if (this.dtblSupplier.Rows.Count > 0)
            {
                DataRow drowNew = this.dtblSupplier.NewRow();
                drowNew["CompanyID"] = -1;
                drowNew["CompanyCode"] = "不限";
                drowNew["CompanyAbbName"] = string.Empty;
                this.dtblSupplier.Rows.InsertAt(drowNew, 0);
                this.cmbItem.SelectedIndex = 0;
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
            return this.dtblSupplier.Rows[this.cmbItem.SelectedIndex][FieldName];
        }
        public string CompanyCode
        {
            get
            {
                object objValue = this.GetFieldValue("CompanyCode");
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
        public string CompanyAbbName
        {
            get
            {
                object objValue = this.GetFieldValue("CompanyAbbName");
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
        public string CompanyAllName
        {
            get
            {
                object objValue = this.GetFieldValue("CompanyAllName");
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
        public string LegalPerson
        {
            get
            {
                object objValue = this.GetFieldValue("LegalPerson");
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
        public bool MtrFlag
        {
            get
            {
                object objValue = this.GetFieldValue("MtrFlag");
                if (objValue == DBNull.Value)
                {
                    return false;
                }
                else
                {
                    return (bool)objValue;
                }
            }
        }
        public bool PrdFlag
        {
            get
            {
                object objValue = this.GetFieldValue("PrdFlag");
                if (objValue == DBNull.Value)
                {
                    return false;
                }
                else
                {
                    return (bool)objValue;
                }
            }
        }
 
        public bool OtherResFlag
        {
            get
            {
                object objValue = this.GetFieldValue("OtherResFlag");
                if (objValue == DBNull.Value)
                {
                    return false;
                }
                else
                {
                    return (bool)objValue;
                }
            }
        }
        public bool ToolFlag
        {
            get
            {
                object objValue = this.GetFieldValue("ToolFlag");
                if (objValue == DBNull.Value)
                {
                    return false;
                }
                else
                {
                    return (bool)objValue;
                }
            }
        }
        public bool OutSrcFlag
        {
            get
            {
                object objValue = this.GetFieldValue("OutSrcFlag");
                if (objValue == DBNull.Value)
                {
                    return false;
                }
                else
                {
                    return (bool)objValue;
                }
            }
        }
        public bool SolutionFlag
        {
            get
            {
                object objValue = this.GetFieldValue("SolutionFlag");
                if (objValue == DBNull.Value)
                {
                    return false;
                }
                else
                {
                    return (bool)objValue;
                }
            }
        }
        public string Telephone
        {
            get
            {
                object objValue = this.GetFieldValue("Telephone");
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
        public string Fax
        {
            get
            {
                object objValue = this.GetFieldValue("Fax");
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
        public string Email
        {
            get
            {
                object objValue = this.GetFieldValue("Email");
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
        public string Linkman
        {
            get
            {
                object objValue = this.GetFieldValue("Linkman");
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
        public string Address
        {
            get
            {
                object objValue = this.GetFieldValue("Address");
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
        public string Memo
        {
            get
            {
                object objValue = this.GetFieldValue("Memo");
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
        public DateTime DateLastOrder
        {
            get
            {
                object objValue = this.GetFieldValue("DateLastOrder");
                if (objValue == DBNull.Value)
                {
                    return DateTime.MinValue;
                }
                else
                {
                    return (DateTime)objValue;
                }
            }
        }
    }
}