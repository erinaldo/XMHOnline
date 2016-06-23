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
    /// 表[ManufSchedules]控件类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2014-11-19 22:56:09
    ///</时间> 
    public partial class CtrlManufSchedule : UserControl
    {
        public CtrlManufSchedule()
        {
            InitializeComponent();
            this.accDataManufSchedules = new JERPData.Manufacture.ManufSchedules();
            this.cmbItem.SelectedIndexChanged += new EventHandler(cmbItem_SelectedIndexChanged);
            
        }
        private JERPData.Manufacture.ManufSchedules accDataManufSchedules;
        private DataTable dtblManufSchedules;
        public void LoadData(long WorkingSheetID)
        {
            this.dtblManufSchedules = this.accDataManufSchedules.GetDataManufSchedulesByWorkingSheetID(WorkingSheetID).Tables[0];
            this.cmbItem.DataSource = this.dtblManufSchedules;
            this.cmbItem.ValueMember = "ManufScheduleID";
            this.cmbItem.DisplayMember = "PrdStatus";
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
        public long ManufScheduleID
        {
            get
            {
                if (this.cmbItem.SelectedIndex == -1) return -1;
                return (long)this.cmbItem.SelectedValue;
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
            return this.dtblManufSchedules.Rows[this.cmbItem.SelectedIndex][FieldName];
        }
        public long WorkingSheetID
        {
            get
            {
                object objValue = this.GetFieldValue("WorkingSheetID");
                if (objValue == DBNull.Value)
                {
                    return -1;
                }
                else
                {
                    return (long)objValue;
                }
            }
        }
        public string WorkingSheetCode
        {
            get
            {
                object objValue = this.GetFieldValue("WorkingSheetCode");
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
        public long ManufProcessID
        {
            get
            {
                object objValue = this.GetFieldValue("ManufProcessID");
                if (objValue == DBNull.Value)
                {
                    return -1;
                }
                else
                {
                    return (long)objValue;
                }
            }
        }
        public string PrdStatus
        {
            get
            {
                object objValue = this.GetFieldValue("PrdStatus");
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
        public int CompanyID
        {
            get
            {
                object objValue = this.GetFieldValue("CompanyID");
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
        public int PrdID
        {
            get
            {
                object objValue = this.GetFieldValue("PrdID");
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
        public int WorkingPositionID
        {
            get
            {
                object objValue = this.GetFieldValue("WorkingPositionID");
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
        public int LineCount
        {
            get
            {
                object objValue = this.GetFieldValue("LineCount");
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
        public int OutSrcCompanyID
        {
            get
            {
                object objValue = this.GetFieldValue("OutSrcCompanyID");
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
        public int PackingTypeID
        {
            get
            {
                object objValue = this.GetFieldValue("PackingTypeID");
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
        public decimal Quantity
        {
            get
            {
                object objValue = this.GetFieldValue("Quantity");
                if (objValue == DBNull.Value)
                {
                    return 0;
                }
                else
                {
                    return (decimal)objValue;
                }
            }
        }
        public decimal FinishedQty
        {
            get
            {
                object objValue = this.GetFieldValue("FinishedQty");
                if (objValue == DBNull.Value)
                {
                    return 0;
                }
                else
                {
                    return (decimal)objValue;
                }
            }
        }
        public decimal NonFinishedQty
        {
            get
            {
                object objValue = this.GetFieldValue("NonFinishedQty");
                if (objValue == DBNull.Value)
                {
                    return 0;
                }
                else
                {
                    return (decimal)objValue;
                }
            }
        }
        public DateTime DateBegin
        {
            get
            {
                object objValue = this.GetFieldValue("DateBegin");
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
        public DateTime DateEnd
        {
            get
            {
                object objValue = this.GetFieldValue("DateEnd");
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
        public decimal OutSrcOrderQty
        {
            get
            {
                object objValue = this.GetFieldValue("OutSrcOrderQty");
                if (objValue == DBNull.Value)
                {
                    return 0;
                }
                else
                {
                    return (decimal)objValue;
                }
            }
        }
        public decimal NonOutSrcOrderQty
        {
            get
            {
                object objValue = this.GetFieldValue("NonOutSrcOrderQty");
                if (objValue == DBNull.Value)
                {
                    return 0;
                }
                else
                {
                    return (decimal)objValue;
                }
            }
        }
        public bool BOMRequireFlag
        {
            get
            {
                object objValue = this.GetFieldValue("BOMRequireFlag");
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
        public decimal BOMFinishedQty
        {
            get
            {
                object objValue = this.GetFieldValue("BOMFinishedQty");
                if (objValue == DBNull.Value)
                {
                    return 0;
                }
                else
                {
                    return (decimal)objValue;
                }
            }
        }
        public decimal BOMNonFinishedQty
        {
            get
            {
                object objValue = this.GetFieldValue("BOMNonFinishedQty");
                if (objValue == DBNull.Value)
                {
                    return 0;
                }
                else
                {
                    return (decimal)objValue;
                }
            }
        }
        public int SerialNo
        {
            get
            {
                object objValue = this.GetFieldValue("SerialNo");
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
        public string ProcessTypeName
        {
            get
            {
                object objValue = this.GetFieldValue("ProcessTypeName");
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
        public string PrdStatus1
        {
            get
            {
                object objValue = this.GetFieldValue("PrdStatus1");
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
        public string WorkingPositionName
        {
            get
            {
                object objValue = this.GetFieldValue("WorkingPositionName");
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
        public string OutSrcSupplier
        {
            get
            {
                object objValue = this.GetFieldValue("OutSrcSupplier");
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