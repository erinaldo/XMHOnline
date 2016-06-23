using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
namespace JERPApp.Define.Packing
{
    /// <描述>
    /// 表[WorkingSheets]控件类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2014-11-23 16:21:19
    ///</时间> 
    public partial class CtrlWorkingSheet : UserControl
    {
        public CtrlWorkingSheet()
        {
            InitializeComponent();
            this.accDataWorkingSheets = new JERPData.Packing.WorkingSheets();
            this.cmbItem.SelectedIndexChanged += new EventHandler(cmbItem_SelectedIndexChanged);
            this.RefreshData();
        }
        private JERPData.Packing.WorkingSheets accDataWorkingSheets;
        private DataTable dtblWorkingSheets;
        private void RefreshData()
        {
            this.dtblWorkingSheets = this.accDataWorkingSheets.GetDataWorkingSheetsLastRecord (500) .Tables[0];
            if (this.dtblWorkingSheets.Rows.Count > 0)
            {
                DataRow drowNew = this.dtblWorkingSheets.NewRow();
                drowNew["WorkingSheetID"] = -1;
                drowNew["WorkingSheetCode"] = string.Empty;
                drowNew["PrdID"] = -1; 
                this.dtblWorkingSheets.Rows.InsertAt(drowNew, 0);
            }
            this.cmbItem.DataSource = this.dtblWorkingSheets;
            this.cmbItem.ValueMember = "WorkingSheetID";
            this.cmbItem.DisplayMember = "WorkingSheetCode";
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
        public long WorkingSheetID
		{
			get
			{
				if(this.cmbItem.SelectedIndex == -1) return -1;
				return (long)this.cmbItem.SelectedValue;
			}
			set
			{
				if(value== -1)
				{
					this.cmbItem.SelectedIndex = -1;
				}
				else
				{
					this.cmbItem.SelectedValue=value;
				}
			}
		}
		private object GetFieldValue(string FieldName)
		{
			if (this.cmbItem.SelectedIndex == -1) return DBNull.Value;
            return this.dtblWorkingSheets.Rows[this.cmbItem.SelectedIndex][FieldName];
		}
		public string WorkingSheetCode
		{
			get
			{
				object objValue=this.GetFieldValue("WorkingSheetCode");
				if(objValue==DBNull .Value)
				{
					return string.Empty;
				}
				else
				{
					return objValue.ToString();
				}
			}
		}
		public int SerialNo
		{
			get
			{
				object objValue=this.GetFieldValue("SerialNo");
				if(objValue==DBNull .Value)
				{
					return -1;
				}
				else
				{
					return (int)objValue;
				}
			}
		}
		public DateTime DateNote
		{
			get
			{
				object objValue=this.GetFieldValue("DateNote");
				if(objValue==DBNull .Value)
				{
					return DateTime.MinValue;
				}
				else
				{
					return (DateTime)objValue;
				}
			}
		}
		public long PackingPlanID
		{
			get
			{
				object objValue=this.GetFieldValue("PackingPlanID");
				if(objValue==DBNull .Value)
				{
					return -1;
				}
				else
				{
					return (long)objValue;
				}
			}
		}
		public long SaleOrderItemID
		{
			get
			{
				object objValue=this.GetFieldValue("SaleOrderItemID");
				if(objValue==DBNull .Value)
				{
					return -1;
				}
				else
				{
					return (long)objValue;
				}
			}
		}
		public string PONo
		{
			get
			{
				object objValue=this.GetFieldValue("PONo");
				if(objValue==DBNull .Value)
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
				object objValue=this.GetFieldValue("CompanyID");
				if(objValue==DBNull .Value)
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
				object objValue=this.GetFieldValue("PrdID");
				if(objValue==DBNull .Value)
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
				object objValue=this.GetFieldValue("PackingTypeID");
				if(objValue==DBNull .Value)
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
				object objValue=this.GetFieldValue("Quantity");
				if(objValue==DBNull .Value)
				{
					return 0;
				}
				else
				{
					return (decimal)objValue;
				}
			}
		}
		public DateTime DateTarget
		{
			get
			{
				object objValue=this.GetFieldValue("DateTarget");
				if(objValue==DBNull .Value)
				{
					return DateTime.MinValue;
				}
				else
				{
					return (DateTime)objValue;
				}
			}
		}
		public int MakerPsnID
		{
			get
			{
				object objValue=this.GetFieldValue("MakerPsnID");
				if(objValue==DBNull .Value)
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
				object objValue=this.GetFieldValue("Memo");
				if(objValue==DBNull .Value)
				{
					return string.Empty;
				}
				else
				{
					return objValue.ToString();
				}
			}
		}
		public decimal FinishedQty
		{
			get
			{
				object objValue=this.GetFieldValue("FinishedQty");
				if(objValue==DBNull .Value)
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
				object objValue=this.GetFieldValue("NonFinishedQty");
				if(objValue==DBNull .Value)
				{
					return 0;
				}
				else
				{
					return (decimal)objValue;
				}
			}
		}
		public bool PublishFlag
		{
			get
			{
				object objValue=this.GetFieldValue("PublishFlag");
				if(objValue==DBNull .Value)
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
				object objValue=this.GetFieldValue("BOMFinishedQty");
				if(objValue==DBNull .Value)
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
				object objValue=this.GetFieldValue("BOMNonFinishedQty");
				if(objValue==DBNull .Value)
				{
					return 0;
				}
				else
				{
					return (decimal)objValue;
				}
			}
		}
		public decimal BarcodeFinishedQty
		{
			get
			{
				object objValue=this.GetFieldValue("BarcodeFinishedQty");
				if(objValue==DBNull .Value)
				{
					return 0;
				}
				else
				{
					return (decimal)objValue;
				}
			}
		}
		public decimal BarcodeNonFinishedQty
		{
			get
			{
				object objValue=this.GetFieldValue("BarcodeNonFinishedQty");
				if(objValue==DBNull .Value)
				{
					return 0;
				}
				else
				{
					return (decimal)objValue;
				}
			}
		}
		public long RowNum
		{
			get
			{
				object objValue=this.GetFieldValue("RowNum");
				if(objValue==DBNull .Value)
				{
					return -1;
				}
				else
				{
					return (long)objValue;
				}
			}
		}
		public string CompanyCode
		{
			get
			{
				object objValue=this.GetFieldValue("CompanyCode");
				if(objValue==DBNull .Value)
				{
					return string.Empty;
				}
				else
				{
					return objValue.ToString();
				}
			}
		}
		public string PrdCode
		{
			get
			{
				object objValue=this.GetFieldValue("PrdCode");
				if(objValue==DBNull .Value)
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
				object objValue=this.GetFieldValue("PrdName");
				if(objValue==DBNull .Value)
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
				object objValue=this.GetFieldValue("PrdSpec");
				if(objValue==DBNull .Value)
				{
					return string.Empty;
				}
				else
				{
					return objValue.ToString();
				}
			}
		}
		public string Model
		{
			get
			{
				object objValue=this.GetFieldValue("Model");
				if(objValue==DBNull .Value)
				{
					return string.Empty;
				}
				else
				{
					return objValue.ToString();
				}
			}
		}
		public string UnitName
		{
			get
			{
				object objValue=this.GetFieldValue("UnitName");
				if(objValue==DBNull .Value)
				{
					return string.Empty;
				}
				else
				{
					return objValue.ToString();
				}
			}
		}
		public string PackingTypeName
		{
			get
			{
				object objValue=this.GetFieldValue("PackingTypeName");
				if(objValue==DBNull .Value)
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
 