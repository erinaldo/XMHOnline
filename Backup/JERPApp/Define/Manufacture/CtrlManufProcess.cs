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
    /// 表[ProcessType]控件类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2014/4/11 8:45:33
    ///</时间> 
    public partial class CtrlManufProcess : UserControl
    {
        public CtrlManufProcess()
        {
            InitializeComponent();
            this.accManufProcess  = new JERPData.Manufacture.ManufProcess ();
            this.cmbItem.SelectedIndexChanged += new EventHandler(cmbItem_SelectedIndexChanged);          
        }
        private JERPData.Manufacture.ManufProcess  accManufProcess;
        private DataTable dtblManufProcess;
        public  void LoadData(int PrdID)
        {
            this.dtblManufProcess =this.accManufProcess .GetDataManufProcessByPrdID (PrdID).Tables[0];
             this.cmbItem.DataSource = this.dtblManufProcess ;
            this.cmbItem.ValueMember = "ManufProcessID";
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
        public long ManufProcessID
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
            return this.dtblManufProcess.Rows[this.cmbItem.SelectedIndex][FieldName];
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
        public int ProcessTypeID
        {
            get
            {
                object objValue = this.GetFieldValue("ProcessTypeID");
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
        public decimal LastCostPrice
        {
            get
            {
                object objValue = this.GetFieldValue("LastCostPrice");
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
        public decimal MtrCostPrice
        {
            get
            {
                object objValue = this.GetFieldValue("MtrCostPrice");
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
        public decimal ProcessCostPrice
        {
            get
            {
                object objValue = this.GetFieldValue("ProcessCostPrice");
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
        public decimal CostPrice
        {
            get
            {
                object objValue = this.GetFieldValue("CostPrice");
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
        public decimal LaborPrice
        {
            get
            {
                object objValue = this.GetFieldValue("LaborPrice");
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
        public decimal ReworkLaborPrice
        {
            get
            {
                object objValue = this.GetFieldValue("ReworkLaborPrice");
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
        public string DieInfor
        {
            get
            {
                object objValue = this.GetFieldValue("DieInfor");
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





    }
}