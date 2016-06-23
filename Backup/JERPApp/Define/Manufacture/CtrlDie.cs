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
    /// 表[Dies]控件类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2014/4/28 11:38:38
    ///</时间> 
    public partial class CtrlDie : UserControl
    {
        public CtrlDie()
        {
            InitializeComponent();
            this.accDataDies = new JERPData.Tool.Product ();
            this.cmbItem.SelectedIndexChanged += new EventHandler(cmbItem_SelectedIndexChanged);
            this.RefreshData();
        }
        private JERPData.Tool.Product  accDataDies;
        private DataTable dtblDies;
        private void RefreshData()
        {
            this.dtblDies = this.accDataDies.GetDataProductForDie ().Tables[0];         
            this.cmbItem.DataSource = this.dtblDies;
            this.cmbItem.ValueMember = "PrdID";
            this.cmbItem.DisplayMember = "PrdCode";
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
        public int PrdID
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
            return this.dtblDies.Rows[this.cmbItem.SelectedIndex][FieldName];
        }
        public string PrdCode
        {
            get
            {
                object objValue = this.GetFieldValue("PrdCode");
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
        public string PrdName
        {
            get
            {
                object objValue = this.GetFieldValue("PrdName");
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
        public string PrdSpec
        {
            get
            {
                object objValue = this.GetFieldValue("PrdSpec");
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
        public string Manufacturer
        {
            get
            {
                object objValue = this.GetFieldValue("Manufacturer");
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
        public string ContactInfor
        {
            get
            {
                object objValue = this.GetFieldValue("ContactInfor");
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
        public string ResponsiblePsnName
        {
            get
            {
                object objValue = this.GetFieldValue("ResponsiblePsnName");
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
        public DateTime DateBatch
        {
            get
            {
                object objValue = this.GetFieldValue("DateBatch");
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
        public int PositionID
        {
            get
            {
                object objValue = this.GetFieldValue("PositionID");
                if (objValue == DBNull.Value)
                {
                    return -1;
                }
                else
                {
                    return (int)objValue;
                }
            }
        }
        public int StatusID
        {
            get
            {
                object objValue = this.GetFieldValue("StatusID");
                if (objValue == DBNull.Value)
                {
                    return -1;
                }
                else
                {
                    return (int)objValue;
                }
            }
        }
        public decimal MaxManufQty
        {
            get
            {
                object objValue = this.GetFieldValue("MaxManufQty");
                if (objValue == DBNull.Value)
                {
                    return -1;
                }
                else
                {
                    return (decimal)objValue;
                }
            }
        }
        public decimal MaxRepairQty
        {
            get
            {
                object objValue = this.GetFieldValue("MaxRepairQty");
                if (objValue == DBNull.Value)
                {
                    return -1;
                }
                else
                {
                    return (decimal)objValue;
                }
            }
        }
        public decimal ManufQty
        {
            get
            {
                object objValue = this.GetFieldValue("ManufQty");
                if (objValue == DBNull.Value)
                {
                    return -1;
                }
                else
                {
                    return (decimal)objValue;
                }
            }
        }
        public decimal RepairedQty
        {
            get
            {
                object objValue = this.GetFieldValue("RepairedQty");
                if (objValue == DBNull.Value)
                {
                    return -1;
                }
                else
                {
                    return (decimal)objValue;
                }
            }
        }
        public int RepairedCnt
        {
            get
            {
                object objValue = this.GetFieldValue("RepairedCnt");
                if (objValue == DBNull.Value)
                {
                    return -1;
                }
                else
                {
                    return (int)objValue;
                }
            }
        }
        public bool AvailableManufFlag
        {
            get
            {
                object objValue = this.GetFieldValue("AvailableManufFlag");
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
        public string PositionName
        {
            get
            {
                object objValue = this.GetFieldValue("PositionName");
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
        public string StatusName
        {
            get
            {
                object objValue = this.GetFieldValue("StatusName");
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