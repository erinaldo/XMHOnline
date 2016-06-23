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
    /// 表[ManufPlans]数据实体类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2016/5/21 9:11:36
    ///</时间>  
    public class ManufPlanEntity
    {
        public ManufPlanEntity()
        {
            this.accData = new JERPData.Manufacture.ManufPlans();
        }
        private JERPData.Manufacture.ManufPlans accData;
        public long ManufPlanID = -1;
        public DateTime DateNote = DateTime.MinValue;
        public long SaleOrderItemID = -1;
        public string PONo = string.Empty;
        public int CompanyID = -1;
        public int PrdID = -1;
        public decimal Quantity = 0;
        public DateTime DateTarget = DateTime.MinValue;
        public bool PrdStoreFlag = false;
        public bool MtrStoreFlag = false;
        public bool ManPlanFlag = false;
        public int MakerPsnID = -1;
        public string Memo = string.Empty;
        public bool BOMPlanFlag = false;
        public decimal FinishedQty = 0;
        public decimal NonFinishedQty = 0;
        public string PrdCode = string.Empty;
        public string PrdName = string.Empty;
        public string PrdSpec = string.Empty;
        public string Model = string.Empty;
        public string UnitName = string.Empty;
        public string MakerPsn = string.Empty;
        public string CompanyCode = string.Empty;
        public string ProcessInfor = string.Empty;
        public void LoadData(long ManufPlanID)
        {
            this.ManufPlanID = ManufPlanID;
            DataTable dtbl = this.accData.GetDataManufPlansByManufPlanID(ManufPlanID).Tables[0];
            if (dtbl.Rows.Count == 0)
            {
                this.DateNote = DateTime.MinValue;
                this.SaleOrderItemID = -1;
                this.PONo = string.Empty;
                this.CompanyID = -1;
                this.PrdID = -1;
                this.Quantity = 0;
                this.DateTarget = DateTime.MinValue;
                this.PrdStoreFlag = false;
                this.MtrStoreFlag = false;
                this.ManPlanFlag = false;
                this.MakerPsnID = -1;
                this.Memo = string.Empty;
                this.BOMPlanFlag = false;
                this.FinishedQty = 0;
                this.NonFinishedQty = 0;
                this.PrdCode = string.Empty;
                this.PrdName = string.Empty;
                this.PrdSpec = string.Empty;
                this.Model = string.Empty;
                this.UnitName = string.Empty;
                this.MakerPsn = string.Empty;
                this.CompanyCode = string.Empty;
                this.ProcessInfor = string.Empty;
                return;
            }
            DataRow drow = dtbl.Rows[0];
            if (drow["DateNote"] == DBNull.Value)
            {
                this.DateNote = DateTime.MinValue;
            }
            else
            {
                this.DateNote = (DateTime)drow["DateNote"];
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
            if (drow["Quantity"] == DBNull.Value)
            {
                this.Quantity = 0;
            }
            else
            {
                this.Quantity = (decimal)drow["Quantity"];
            }
            if (drow["DateTarget"] == DBNull.Value)
            {
                this.DateTarget = DateTime.MinValue;
            }
            else
            {
                this.DateTarget = (DateTime)drow["DateTarget"];
            }
            if (drow["PrdStoreFlag"] == DBNull.Value)
            {
                this.PrdStoreFlag = false;
            }
            else
            {
                this.PrdStoreFlag = (bool)drow["PrdStoreFlag"];
            }
            if (drow["MtrStoreFlag"] == DBNull.Value)
            {
                this.MtrStoreFlag = false;
            }
            else
            {
                this.MtrStoreFlag = (bool)drow["MtrStoreFlag"];
            }
            if (drow["ManPlanFlag"] == DBNull.Value)
            {
                this.ManPlanFlag = false;
            }
            else
            {
                this.ManPlanFlag = (bool)drow["ManPlanFlag"];
            }
            if (drow["MakerPsnID"] == DBNull.Value)
            {
                this.MakerPsnID = -1;
            }
            else
            {
                this.MakerPsnID = (int)drow["MakerPsnID"];
            }
            if (drow["Memo"] == DBNull.Value)
            {
                this.Memo = string.Empty;
            }
            else
            {
                this.Memo = drow["Memo"].ToString();
            }
            if (drow["BOMPlanFlag"] == DBNull.Value)
            {
                this.BOMPlanFlag = false;
            }
            else
            {
                this.BOMPlanFlag = (bool)drow["BOMPlanFlag"];
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
            if (drow["MakerPsn"] == DBNull.Value)
            {
                this.MakerPsn = string.Empty;
            }
            else
            {
                this.MakerPsn = drow["MakerPsn"].ToString();
            }
            if (drow["CompanyCode"] == DBNull.Value)
            {
                this.CompanyCode = string.Empty;
            }
            else
            {
                this.CompanyCode = drow["CompanyCode"].ToString();
            }
            if (drow["ProcessInfor"] == DBNull.Value)
            {
                this.ProcessInfor = string.Empty;
            }
            else
            {
                this.ProcessInfor = drow["ProcessInfor"].ToString();
            }
        }
    }
}