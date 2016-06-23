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
namespace JERPBiz.Asset
{
    /// <描述>
    /// 表[Product]数据实体类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2013-8-22 11:20:15
    ///</时间>  
    public class ProductEntity
    {
        public ProductEntity()
        {
            this.accData = new JERPData.Asset.Product();
        }
        private JERPData.Asset.Product accData;
        public int PrdID = -1;
        public int PrdTypeID = -1;
        public string PrdCode = string.Empty;
        public string PrdName = string.Empty;
        public string PrdSpec = string.Empty;
        public int UnitID = -1;
        public int DeptID = -1;
        public string UserName = string.Empty;
        public string PICName = string.Empty;
        public string DepositPlace = string.Empty;
        public string DepositStatus = string.Empty;
        public DateTime DatePurchase = DateTime.MinValue;
        public int MethodID = -1;
        public decimal Cost = -1;
        public decimal Salvage = -1;
        public decimal AccumDepreciate = -1;
        public int Year = -1;
        public int Month = -1;
        public int LifeMonth = -1;
        public int DepreciateMonth = -1;
        public bool StopFlag = false;
        public decimal LifeWorkload = -1;
        public decimal MonthWorkload = -1;
        public decimal DepreciateWorkload = -1;
        public string WorkloadUnit = string.Empty;
        public bool SLFlag = false;
        public bool UOPFlag = false;
        public bool DDBFlag = false;
        public bool SYDFlag = false;
        public bool OfficeFlag = false;
        public bool ManufFlag = false;
        public string PrdTypeName = string.Empty;
        public string DeptName = string.Empty;
        public string MethodName = string.Empty;
        public string UnitName = string.Empty;
        public void LoadData(int PrdID)
        {
            this.PrdID = PrdID;
            DataTable dtbl = this.accData.GetDataProductByPrdID(PrdID).Tables[0];
            if (dtbl.Rows.Count == 0)
            {
                this.PrdTypeID = -1;
                this.PrdCode = string.Empty;
                this.PrdName = string.Empty;
                this.PrdSpec = string.Empty;
                this.UnitID = -1;
                this.DeptID = -1;
                this.UserName = string.Empty;
                this.PICName = string.Empty;
                this.DepositPlace = string.Empty;
                this.DepositStatus = string.Empty;
                this.DatePurchase = DateTime.MinValue;
                this.MethodID = -1;
                this.Cost = -1;
                this.Salvage = -1;
                this.AccumDepreciate = -1;
                this.Year = -1;
                this.Month = -1;
                this.LifeMonth = -1;
                this.DepreciateMonth = -1;
                this.StopFlag = false;
                this.LifeWorkload = -1;
                this.MonthWorkload = -1;
                this.DepreciateWorkload = -1;
                this.WorkloadUnit = string.Empty;
                this.SLFlag = false;
                this.UOPFlag = false;
                this.DDBFlag = false;
                this.SYDFlag = false;
                this.OfficeFlag = false;
                this.ManufFlag = false;
                this.PrdTypeName = string.Empty;
                this.DeptName = string.Empty;
                this.MethodName = string.Empty;
                this.UnitName = string.Empty;
                return;
            }
            DataRow drow = dtbl.Rows[0];
            if (drow["PrdTypeID"] == DBNull.Value)
            {
                this.PrdTypeID = -1;
            }
            else
            {
                this.PrdTypeID = (int)drow["PrdTypeID"];
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
            if (drow["UnitID"] == DBNull.Value)
            {
                this.UnitID = -1;
            }
            else
            {
                this.UnitID = (int)drow["UnitID"];
            }
            if (drow["DeptID"] == DBNull.Value)
            {
                this.DeptID = -1;
            }
            else
            {
                this.DeptID = (int)drow["DeptID"];
            }
            if (drow["UserName"] == DBNull.Value)
            {
                this.UserName = string.Empty;
            }
            else
            {
                this.UserName = drow["UserName"].ToString();
            }
            if (drow["PICName"] == DBNull.Value)
            {
                this.PICName = string.Empty;
            }
            else
            {
                this.PICName = drow["PICName"].ToString();
            }
            if (drow["DepositPlace"] == DBNull.Value)
            {
                this.DepositPlace = string.Empty;
            }
            else
            {
                this.DepositPlace = drow["DepositPlace"].ToString();
            }
            if (drow["DepositStatus"] == DBNull.Value)
            {
                this.DepositStatus = string.Empty;
            }
            else
            {
                this.DepositStatus = drow["DepositStatus"].ToString();
            }
            if (drow["DatePurchase"] == DBNull.Value)
            {
                this.DatePurchase = DateTime.MinValue;
            }
            else
            {
                this.DatePurchase = (DateTime)drow["DatePurchase"];
            }
            if (drow["MethodID"] == DBNull.Value)
            {
                this.MethodID = -1;
            }
            else
            {
                this.MethodID = (int)drow["MethodID"];
            }
            if (drow["Cost"] == DBNull.Value)
            {
                this.Cost = -1;
            }
            else
            {
                this.Cost = (decimal)drow["Cost"];
            }
            if (drow["Salvage"] == DBNull.Value)
            {
                this.Salvage = -1;
            }
            else
            {
                this.Salvage = (decimal)drow["Salvage"];
            }
            if (drow["AccumDepreciate"] == DBNull.Value)
            {
                this.AccumDepreciate = -1;
            }
            else
            {
                this.AccumDepreciate = (decimal)drow["AccumDepreciate"];
            }
            if (drow["Year"] == DBNull.Value)
            {
                this.Year = -1;
            }
            else
            {
                this.Year = (int)drow["Year"];
            }
            if (drow["Month"] == DBNull.Value)
            {
                this.Month = -1;
            }
            else
            {
                this.Month = (int)drow["Month"];
            }
            if (drow["LifeMonth"] == DBNull.Value)
            {
                this.LifeMonth = -1;
            }
            else
            {
                this.LifeMonth = (int)drow["LifeMonth"];
            }
            if (drow["DepreciateMonth"] == DBNull.Value)
            {
                this.DepreciateMonth = -1;
            }
            else
            {
                this.DepreciateMonth = (int)drow["DepreciateMonth"];
            }
            if (drow["StopFlag"] == DBNull.Value)
            {
                this.StopFlag = false;
            }
            else
            {
                this.StopFlag = (bool)drow["StopFlag"];
            }
            if (drow["LifeWorkload"] == DBNull.Value)
            {
                this.LifeWorkload = -1;
            }
            else
            {
                this.LifeWorkload = (decimal)drow["LifeWorkload"];
            }
            if (drow["MonthWorkload"] == DBNull.Value)
            {
                this.MonthWorkload = -1;
            }
            else
            {
                this.MonthWorkload = (decimal)drow["MonthWorkload"];
            }
            if (drow["DepreciateWorkload"] == DBNull.Value)
            {
                this.DepreciateWorkload = -1;
            }
            else
            {
                this.DepreciateWorkload = (decimal)drow["DepreciateWorkload"];
            }
            if (drow["WorkloadUnit"] == DBNull.Value)
            {
                this.WorkloadUnit = string.Empty;
            }
            else
            {
                this.WorkloadUnit = drow["WorkloadUnit"].ToString();
            }
            if (drow["SLFlag"] == DBNull.Value)
            {
                this.SLFlag = false;
            }
            else
            {
                this.SLFlag = (bool)drow["SLFlag"];
            }
            if (drow["UOPFlag"] == DBNull.Value)
            {
                this.UOPFlag = false;
            }
            else
            {
                this.UOPFlag = (bool)drow["UOPFlag"];
            }
            if (drow["DDBFlag"] == DBNull.Value)
            {
                this.DDBFlag = false;
            }
            else
            {
                this.DDBFlag = (bool)drow["DDBFlag"];
            }
            if (drow["SYDFlag"] == DBNull.Value)
            {
                this.SYDFlag = false;
            }
            else
            {
                this.SYDFlag = (bool)drow["SYDFlag"];
            }
            if (drow["OfficeFlag"] == DBNull.Value)
            {
                this.OfficeFlag = false;
            }
            else
            {
                this.OfficeFlag = (bool)drow["OfficeFlag"];
            }
            if (drow["ManufFlag"] == DBNull.Value)
            {
                this.ManufFlag = false;
            }
            else
            {
                this.ManufFlag = (bool)drow["ManufFlag"];
            }
            if (drow["PrdTypeName"] == DBNull.Value)
            {
                this.PrdTypeName = string.Empty;
            }
            else
            {
                this.PrdTypeName = drow["PrdTypeName"].ToString();
            }
            if (drow["DeptName"] == DBNull.Value)
            {
                this.DeptName = string.Empty;
            }
            else
            {
                this.DeptName = drow["DeptName"].ToString();
            }
            if (drow["MethodName"] == DBNull.Value)
            {
                this.MethodName = string.Empty;
            }
            else
            {
                this.MethodName = drow["MethodName"].ToString();
            }
            if (drow["UnitName"] == DBNull.Value)
            {
                this.UnitName = string.Empty;
            }
            else
            {
                this.UnitName = drow["UnitName"].ToString();
            }
        }
    }
}