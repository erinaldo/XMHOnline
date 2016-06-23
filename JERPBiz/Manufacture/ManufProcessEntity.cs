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
    /// 表[ManufProcess]数据实体类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2016/6/5 7:17:36
    ///</时间>  
    public class ManufProcessEntity
    {
        public ManufProcessEntity()
        {
            this.accData = new JERPData.Manufacture.ManufProcess();
        }
        private JERPData.Manufacture.ManufProcess accData;
        public long ManufProcessID = -1;
        public int PrdID = -1;
        public int SerialNo = -1;
        public int ProcessTypeID = -1;
        public string PrdStatus = string.Empty;
        public string Memo = string.Empty;
        public string MouldCode = string.Empty;
        public bool OutSrcFlag = false;
        public int OutSrcCompanyID = -1;
        public decimal LastCostPrice = 0;
        public decimal MtrCostPrice = 0;
        public decimal ProcessCostPrice = 0;
        public decimal CostPrice = 0;
        public decimal LaborPrice = 0;
        public decimal ReworkLaborPrice = 0;
        public int FileCount = -1;
        public string PrdCode = string.Empty;
        public string PrdName = string.Empty;
        public string PrdSpec = string.Empty;
        public string Model = string.Empty;
        public string UnitName = string.Empty;
        public string OutSrcSupplier = string.Empty;
        public string ProcessTypeName = string.Empty;
        public void LoadData(long ManufProcessID)
        {
            this.ManufProcessID = ManufProcessID;
            DataTable dtbl = this.accData.GetDataManufProcessByManufProcessID(ManufProcessID).Tables[0];
            if (dtbl.Rows.Count == 0)
            {
                this.PrdID = -1;
                this.SerialNo = -1;
                this.ProcessTypeID = -1;
                this.PrdStatus = string.Empty;
                this.Memo = string.Empty;
                this.MouldCode = string.Empty;
                this.OutSrcFlag = false;
                this.OutSrcCompanyID = -1;
                this.LastCostPrice = 0;
                this.MtrCostPrice = 0;
                this.ProcessCostPrice = 0;
                this.CostPrice = 0;
                this.LaborPrice = 0;
                this.ReworkLaborPrice = 0;
                this.FileCount = -1;
                this.PrdCode = string.Empty;
                this.PrdName = string.Empty;
                this.PrdSpec = string.Empty;
                this.Model = string.Empty;
                this.UnitName = string.Empty;
                this.OutSrcSupplier = string.Empty;
                this.ProcessTypeName = string.Empty;
                return;
            }
            DataRow drow = dtbl.Rows[0];
            if (drow["PrdID"] == DBNull.Value)
            {
                this.PrdID = -1;
            }
            else
            {
                this.PrdID = (int)drow["PrdID"];
            }
            if (drow["SerialNo"] == DBNull.Value)
            {
                this.SerialNo = -1;
            }
            else
            {
                this.SerialNo = (int)drow["SerialNo"];
            }
            if (drow["ProcessTypeID"] == DBNull.Value)
            {
                this.ProcessTypeID = -1;
            }
            else
            {
                this.ProcessTypeID = (int)drow["ProcessTypeID"];
            }
            if (drow["PrdStatus"] == DBNull.Value)
            {
                this.PrdStatus = string.Empty;
            }
            else
            {
                this.PrdStatus = drow["PrdStatus"].ToString();
            }
            if (drow["Memo"] == DBNull.Value)
            {
                this.Memo = string.Empty;
            }
            else
            {
                this.Memo = drow["Memo"].ToString();
            }
            if (drow["MouldCode"] == DBNull.Value)
            {
                this.MouldCode = string.Empty;
            }
            else
            {
                this.MouldCode = drow["MouldCode"].ToString();
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
            if (drow["LastCostPrice"] == DBNull.Value)
            {
                this.LastCostPrice = 0;
            }
            else
            {
                this.LastCostPrice = (decimal)drow["LastCostPrice"];
            }
            if (drow["MtrCostPrice"] == DBNull.Value)
            {
                this.MtrCostPrice = 0;
            }
            else
            {
                this.MtrCostPrice = (decimal)drow["MtrCostPrice"];
            }
            if (drow["ProcessCostPrice"] == DBNull.Value)
            {
                this.ProcessCostPrice = 0;
            }
            else
            {
                this.ProcessCostPrice = (decimal)drow["ProcessCostPrice"];
            }
            if (drow["CostPrice"] == DBNull.Value)
            {
                this.CostPrice = 0;
            }
            else
            {
                this.CostPrice = (decimal)drow["CostPrice"];
            }
            if (drow["LaborPrice"] == DBNull.Value)
            {
                this.LaborPrice = 0;
            }
            else
            {
                this.LaborPrice = (decimal)drow["LaborPrice"];
            }
            if (drow["ReworkLaborPrice"] == DBNull.Value)
            {
                this.ReworkLaborPrice = 0;
            }
            else
            {
                this.ReworkLaborPrice = (decimal)drow["ReworkLaborPrice"];
            }
            if (drow["FileCount"] == DBNull.Value)
            {
                this.FileCount = -1;
            }
            else
            {
                this.FileCount = (int)drow["FileCount"];
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
            if (drow["ProcessTypeName"] == DBNull.Value)
            {
                this.ProcessTypeName = string.Empty;
            }
            else
            {
                this.ProcessTypeName = drow["ProcessTypeName"].ToString();
            }
        }
    }
}