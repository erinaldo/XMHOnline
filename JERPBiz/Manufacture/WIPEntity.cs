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
    /// 表[WIP]数据实体类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2016/6/6 7:36:44
    ///</时间>  
    public class WIPEntity
    {
        public WIPEntity()
        {
            this.accData = new JERPData.Manufacture.WIP();
        }
        private JERPData.Manufacture.WIP accData;
        public long WIPID = -1;
        public long ManufScheduleID = -1;
        public long WorkingSheetID = -1;
        public long ManufProcessID = -1;
        public int ProcessTypeID = -1;
        public int WorkgroupID = -1;
        public int OutSrcCompanyID = -1;
        public decimal Quantity = 0;
        public decimal WorkingHour = 0;
        public DateTime DateFinished = DateTime.MinValue;
        public string WorkingSheetCode = string.Empty;
        public int CompanyID = -1;
        public long SaleOrderItemID = -1;
        public string PONo = string.Empty;
        public int PrdID = -1;
        public string PrdStatus = string.Empty;
        public string WorkgroupName = string.Empty;
        public string OutSrcSupplier = string.Empty;
        public string PrdCode = string.Empty;
        public string PrdName = string.Empty;
        public string PrdSpec = string.Empty;
        public string Model = string.Empty;
        public string CompanyCode = string.Empty;
        public void LoadData(long WIPID)
        {
            this.WIPID = WIPID;
            DataTable dtbl = this.accData.GetDataWIPByWIPID(WIPID).Tables[0];
            if (dtbl.Rows.Count == 0)
            {
                this.ManufScheduleID = -1;
                this.WorkingSheetID = -1;
                this.ManufProcessID = -1;
                this.ProcessTypeID = -1;
                this.WorkgroupID = -1;
                this.OutSrcCompanyID = -1;
                this.Quantity = 0;
                this.WorkingHour = 0;
                this.DateFinished = DateTime.MinValue;
                this.WorkingSheetCode = string.Empty;
                this.CompanyID = -1;
                this.SaleOrderItemID = -1;
                this.PONo = string.Empty;
                this.PrdID = -1;
                this.PrdStatus = string.Empty;
                this.WorkgroupName = string.Empty;
                this.OutSrcSupplier = string.Empty;
                this.PrdCode = string.Empty;
                this.PrdName = string.Empty;
                this.PrdSpec = string.Empty;
                this.Model = string.Empty;
                this.CompanyCode = string.Empty;
                return;
            }
            DataRow drow = dtbl.Rows[0];
            if (drow["ManufScheduleID"] == DBNull.Value)
            {
                this.ManufScheduleID = -1;
            }
            else
            {
                this.ManufScheduleID = (long)drow["ManufScheduleID"];
            }
            if (drow["WorkingSheetID"] == DBNull.Value)
            {
                this.WorkingSheetID = -1;
            }
            else
            {
                this.WorkingSheetID = (long)drow["WorkingSheetID"];
            }
            if (drow["ManufProcessID"] == DBNull.Value)
            {
                this.ManufProcessID = -1;
            }
            else
            {
                this.ManufProcessID = (long)drow["ManufProcessID"];
            }
            if (drow["ProcessTypeID"] == DBNull.Value)
            {
                this.ProcessTypeID = -1;
            }
            else
            {
                this.ProcessTypeID = (int)drow["ProcessTypeID"];
            }
            if (drow["WorkgroupID"] == DBNull.Value)
            {
                this.WorkgroupID = -1;
            }
            else
            {
                this.WorkgroupID = (int)drow["WorkgroupID"];
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
            if (drow["WorkingHour"] == DBNull.Value)
            {
                this.WorkingHour = 0;
            }
            else
            {
                this.WorkingHour = (decimal)drow["WorkingHour"];
            }
            if (drow["DateFinished"] == DBNull.Value)
            {
                this.DateFinished = DateTime.MinValue;
            }
            else
            {
                this.DateFinished = (DateTime)drow["DateFinished"];
            }
            if (drow["WorkingSheetCode"] == DBNull.Value)
            {
                this.WorkingSheetCode = string.Empty;
            }
            else
            {
                this.WorkingSheetCode = drow["WorkingSheetCode"].ToString();
            }
            if (drow["CompanyID"] == DBNull.Value)
            {
                this.CompanyID = -1;
            }
            else
            {
                this.CompanyID = (int)drow["CompanyID"];
            }
            if (drow["SaleOrderItemID"] == DBNull.Value)
            {
                this.SaleOrderItemID = -1;
            }
            else
            {
                this.SaleOrderItemID = (long)drow["SaleOrderItemID"];
            }
            if (drow["PONo"] == DBNull.Value)
            {
                this.PONo = string.Empty;
            }
            else
            {
                this.PONo = drow["PONo"].ToString();
            }
            if (drow["PrdID"] == DBNull.Value)
            {
                this.PrdID = -1;
            }
            else
            {
                this.PrdID = (int)drow["PrdID"];
            }
            if (drow["PrdStatus"] == DBNull.Value)
            {
                this.PrdStatus = string.Empty;
            }
            else
            {
                this.PrdStatus = drow["PrdStatus"].ToString();
            }
            if (drow["WorkgroupName"] == DBNull.Value)
            {
                this.WorkgroupName = string.Empty;
            }
            else
            {
                this.WorkgroupName = drow["WorkgroupName"].ToString();
            }
            if (drow["OutSrcSupplier"] == DBNull.Value)
            {
                this.OutSrcSupplier = string.Empty;
            }
            else
            {
                this.OutSrcSupplier = drow["OutSrcSupplier"].ToString();
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
        }
    }
}