/*
$Header$
$Author$
$Date$
$Revision$
*/
using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
namespace JERPBiz.Manufacture
{
    /// <描述>
    /// 表[ManufSchedules]数据实体类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2016/6/11 11:57:49
    ///</时间>  
    public class ManufScheduleEntity
    {
        public ManufScheduleEntity()
        {
            this.accData = new JERPData.Manufacture.ManufSchedules();
        }
        private JERPData.Manufacture.ManufSchedules accData;
        public long ManufScheduleID = -1;
        public long ManufPlanID = -1;
        public long WorkingSheetID = -1;
        public string WorkingSheetCode = string.Empty;
        public long ManufProcessID = -1;
        public string PrdStatus = string.Empty;
        public int CompanyID = -1;
        public int PrdID = -1;
        public string Memo = string.Empty;
        public bool OutSrcFlag = false;
        public int OutSrcCompanyID = -1;
        public decimal Quantity = 0;
        public decimal FinishedQty = 0;
        public decimal NonFinishedQty = 0;
        public DateTime DateTarget = DateTime.MinValue;
        public decimal OutSrcOrderQty = 0;
        public decimal OutSrcOrderFinishedQty = 0;
        public decimal OutSrcOrderNonFinishedQty = 0;
        public bool BOMRequireFlag = false;
        public decimal BOMFinishedQty = 0;
        public decimal BOMNonFinishedQty = 0;
        public int SerialNo = -1;
        public string ProcessTypeName = string.Empty;
        public string PrdCode = string.Empty;
        public string PrdName = string.Empty;
        public string PrdSpec = string.Empty;
        public string Model = string.Empty;
        public string CompanyCode = string.Empty;
        public string UnitName = string.Empty;
        public string OutSrcSupplier = string.Empty;
        public string LastPrdStatus = string.Empty;
        public string NextPrdStatus = string.Empty;
        public void LoadData(long ManufScheduleID)
        {
            this.ManufScheduleID = ManufScheduleID;
            DataTable dtbl = this.accData.GetDataManufSchedulesByManufScheduleID(ManufScheduleID).Tables[0];
            if (dtbl.Rows.Count == 0)
            {
                this.ManufPlanID = -1;
                this.WorkingSheetID = -1;
                this.WorkingSheetCode = string.Empty;
                this.ManufProcessID = -1;
                this.PrdStatus = string.Empty;
                this.CompanyID = -1;
                this.PrdID = -1;
                this.Memo = string.Empty;
                this.OutSrcFlag = false;
                this.OutSrcCompanyID = -1;
                this.Quantity = 0;
                this.FinishedQty = 0;
                this.NonFinishedQty = 0;
                this.DateTarget = DateTime.MinValue;
                this.OutSrcOrderQty = 0;
                this.OutSrcOrderFinishedQty = 0;
                this.OutSrcOrderNonFinishedQty = 0;
                this.BOMRequireFlag = false;
                this.BOMFinishedQty = 0;
                this.BOMNonFinishedQty = 0;
                this.SerialNo = -1;
                this.ProcessTypeName = string.Empty;
                this.PrdCode = string.Empty;
                this.PrdName = string.Empty;
                this.PrdSpec = string.Empty;
                this.Model = string.Empty;
                this.CompanyCode = string.Empty;
                this.UnitName = string.Empty;
                this.OutSrcSupplier = string.Empty;
                this.LastPrdStatus = string.Empty;
                this.NextPrdStatus = string.Empty;
                return;
            }
            DataRow drow = dtbl.Rows[0];
            if (drow["ManufPlanID"] == DBNull.Value)
            {
                this.ManufPlanID = -1;
            }
            else
            {
                this.ManufPlanID = (long)drow["ManufPlanID"];
            }
            if (drow["WorkingSheetID"] == DBNull.Value)
            {
                this.WorkingSheetID = -1;
            }
            else
            {
                this.WorkingSheetID = (long)drow["WorkingSheetID"];
            }
            if (drow["WorkingSheetCode"] == DBNull.Value)
            {
                this.WorkingSheetCode = string.Empty;
            }
            else
            {
                this.WorkingSheetCode = drow["WorkingSheetCode"].ToString();
            }
            if (drow["ManufProcessID"] == DBNull.Value)
            {
                this.ManufProcessID = -1;
            }
            else
            {
                this.ManufProcessID = (long)drow["ManufProcessID"];
            }
            if (drow["PrdStatus"] == DBNull.Value)
            {
                this.PrdStatus = string.Empty;
            }
            else
            {
                this.PrdStatus = drow["PrdStatus"].ToString();
            }
            if (drow["CompanyID"] == DBNull.Value)
            {
                this.CompanyID = -1;
            }
            else
            {
                this.CompanyID = (int)drow["CompanyID"];
            }
            if (drow["PrdID"] == DBNull.Value)
            {
                this.PrdID = -1;
            }
            else
            {
                this.PrdID = (int)drow["PrdID"];
            }
            if (drow["Memo"] == DBNull.Value)
            {
                this.Memo = string.Empty;
            }
            else
            {
                this.Memo = drow["Memo"].ToString();
            }
            if (drow["OutSrcFlag"] == DBNull.Value)
            {
                this.OutSrcFlag = false;
            }
            else
            {
                this.OutSrcFlag = (bool)drow["OutSrcFlag"];
            }
            if (drow["OutSrcCompanyID"] == DBNull.Value)
            {
                this.OutSrcCompanyID = -1;
            }
            else
            {
                this.OutSrcCompanyID = (int)drow["OutSrcCompanyID"];
            }
            if (drow["Quantity"] == DBNull.Value)
            {
                this.Quantity = 0;
            }
            else
            {
                this.Quantity = (decimal)drow["Quantity"];
            }
            if (drow["FinishedQty"] == DBNull.Value)
            {
                this.FinishedQty = 0;
            }
            else
            {
                this.FinishedQty = (decimal)drow["FinishedQty"];
            }
            if (drow["NonFinishedQty"] == DBNull.Value)
            {
                this.NonFinishedQty = 0;
            }
            else
            {
                this.NonFinishedQty = (decimal)drow["NonFinishedQty"];
            }
            if (drow["DateTarget"] == DBNull.Value)
            {
                this.DateTarget = DateTime.MinValue;
            }
            else
            {
                this.DateTarget = (DateTime)drow["DateTarget"];
            }
            if (drow["OutSrcOrderQty"] == DBNull.Value)
            {
                this.OutSrcOrderQty = 0;
            }
            else
            {
                this.OutSrcOrderQty = (decimal)drow["OutSrcOrderQty"];
            }
            if (drow["OutSrcOrderFinishedQty"] == DBNull.Value)
            {
                this.OutSrcOrderFinishedQty = 0;
            }
            else
            {
                this.OutSrcOrderFinishedQty = (decimal)drow["OutSrcOrderFinishedQty"];
            }
            if (drow["OutSrcOrderNonFinishedQty"] == DBNull.Value)
            {
                this.OutSrcOrderNonFinishedQty = 0;
            }
            else
            {
                this.OutSrcOrderNonFinishedQty = (decimal)drow["OutSrcOrderNonFinishedQty"];
            }
            if (drow["BOMRequireFlag"] == DBNull.Value)
            {
                this.BOMRequireFlag = false;
            }
            else
            {
                this.BOMRequireFlag = (bool)drow["BOMRequireFlag"];
            }
            if (drow["BOMFinishedQty"] == DBNull.Value)
            {
                this.BOMFinishedQty = 0;
            }
            else
            {
                this.BOMFinishedQty = (decimal)drow["BOMFinishedQty"];
            }
            if (drow["BOMNonFinishedQty"] == DBNull.Value)
            {
                this.BOMNonFinishedQty = 0;
            }
            else
            {
                this.BOMNonFinishedQty = (decimal)drow["BOMNonFinishedQty"];
            }
            if (drow["SerialNo"] == DBNull.Value)
            {
                this.SerialNo = -1;
            }
            else
            {
                this.SerialNo = (int)drow["SerialNo"];
            }
            if (drow["ProcessTypeName"] == DBNull.Value)
            {
                this.ProcessTypeName = string.Empty;
            }
            else
            {
                this.ProcessTypeName = drow["ProcessTypeName"].ToString();
            }
            if (drow["PrdCode"] == DBNull.Value)
            {
                this.PrdCode = string.Empty;
            }
            else
            {
                this.PrdCode = drow["PrdCode"].ToString();
            }
            if (drow["PrdName"] == DBNull.Value)
            {
                this.PrdName = string.Empty;
            }
            else
            {
                this.PrdName = drow["PrdName"].ToString();
            }
            if (drow["PrdSpec"] == DBNull.Value)
            {
                this.PrdSpec = string.Empty;
            }
            else
            {
                this.PrdSpec = drow["PrdSpec"].ToString();
            }
            if (drow["Model"] == DBNull.Value)
            {
                this.Model = string.Empty;
            }
            else
            {
                this.Model = drow["Model"].ToString();
            }
            if (drow["CompanyCode"] == DBNull.Value)
            {
                this.CompanyCode = string.Empty;
            }
            else
            {
                this.CompanyCode = drow["CompanyCode"].ToString();
            }
            if (drow["UnitName"] == DBNull.Value)
            {
                this.UnitName = string.Empty;
            }
            else
            {
                this.UnitName = drow["UnitName"].ToString();
            }
            if (drow["OutSrcSupplier"] == DBNull.Value)
            {
                this.OutSrcSupplier = string.Empty;
            }
            else
            {
                this.OutSrcSupplier = drow["OutSrcSupplier"].ToString();
            }
            if (drow["LastPrdStatus"] == DBNull.Value)
            {
                this.LastPrdStatus = string.Empty;
            }
            else
            {
                this.LastPrdStatus = drow["LastPrdStatus"].ToString();
            }
            if (drow["NextPrdStatus"] == DBNull.Value)
            {
                this.NextPrdStatus = string.Empty;
            }
            else
            {
                this.NextPrdStatus = drow["NextPrdStatus"].ToString();
            }
        }
    }
}