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
namespace JERPBiz.Tool
{
    /// <描述>
    /// 表[Product]数据实体类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2015/7/21 14:54:58
    ///</时间>  
    public class ProductEntity
    {
        public ProductEntity()
        {
            this.accData = new JERPData.Tool.Product();
        }
        private JERPData.Tool.Product accData;
        public int PrdID = -1;
        public int PrdTypeID = -1;
        public string PrdCode = string.Empty;
        public string PrdName = string.Empty;
        public string PrdSpec = string.Empty;
        public int UnitID = -1;
        public string Manufacturer = string.Empty;
        public string ContactInfor = string.Empty;
        public string ResponsiblePsnName = string.Empty;
        public DateTime DateBatch = DateTime.MinValue;
        public int PositionID = -1;
        public int StatusID = -1;
        public string StatusSummary = string.Empty;
        public decimal MaxManufQty = 0;
        public decimal MaxRepairQty = 0;
        public decimal ManufQty = 0;
        public decimal RepairedQty = 0;
        public int RepairedCnt = -1;
        public bool AvailableManufFlag = false;
        public bool StopFlag = false;
        public int FileCount = -1;
        public int ImgCount = -1;
        public string PositionName = string.Empty;
        public string StatusName = string.Empty;
        public string PrdTypeName = string.Empty;
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
                this.Manufacturer = string.Empty;
                this.ContactInfor = string.Empty;
                this.ResponsiblePsnName = string.Empty;
                this.DateBatch = DateTime.MinValue;
                this.PositionID = -1;
                this.StatusID = -1;
                this.StatusSummary = string.Empty;
                this.MaxManufQty = 0;
                this.MaxRepairQty = 0;
                this.ManufQty = 0;
                this.RepairedQty = 0;
                this.RepairedCnt = -1;
                this.AvailableManufFlag = false;
                this.StopFlag = false;
                this.FileCount = -1;
                this.ImgCount = -1;
                this.PositionName = string.Empty;
                this.StatusName = string.Empty;
                this.PrdTypeName = string.Empty;
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
            if (drow["Manufacturer"] == DBNull.Value)
            {
                this.Manufacturer = string.Empty;
            }
            else
            {
                this.Manufacturer = drow["Manufacturer"].ToString();
            }
            if (drow["ContactInfor"] == DBNull.Value)
            {
                this.ContactInfor = string.Empty;
            }
            else
            {
                this.ContactInfor = drow["ContactInfor"].ToString();
            }
            if (drow["ResponsiblePsnName"] == DBNull.Value)
            {
                this.ResponsiblePsnName = string.Empty;
            }
            else
            {
                this.ResponsiblePsnName = drow["ResponsiblePsnName"].ToString();
            }
            if (drow["DateBatch"] == DBNull.Value)
            {
                this.DateBatch = DateTime.MinValue;
            }
            else
            {
                this.DateBatch = (DateTime)drow["DateBatch"];
            }
            if (drow["PositionID"] == DBNull.Value)
            {
                this.PositionID = -1;
            }
            else
            {
                this.PositionID = (int)drow["PositionID"];
            }
            if (drow["StatusID"] == DBNull.Value)
            {
                this.StatusID = -1;
            }
            else
            {
                this.StatusID = (int)drow["StatusID"];
            }
            if (drow["StatusSummary"] == DBNull.Value)
            {
                this.StatusSummary = string.Empty;
            }
            else
            {
                this.StatusSummary = drow["StatusSummary"].ToString();
            }
            if (drow["MaxManufQty"] == DBNull.Value)
            {
                this.MaxManufQty = 0;
            }
            else
            {
                this.MaxManufQty = (decimal)drow["MaxManufQty"];
            }
            if (drow["MaxRepairQty"] == DBNull.Value)
            {
                this.MaxRepairQty = 0;
            }
            else
            {
                this.MaxRepairQty = (decimal)drow["MaxRepairQty"];
            }
            if (drow["ManufQty"] == DBNull.Value)
            {
                this.ManufQty = 0;
            }
            else
            {
                this.ManufQty = (decimal)drow["ManufQty"];
            }
            if (drow["RepairedQty"] == DBNull.Value)
            {
                this.RepairedQty = 0;
            }
            else
            {
                this.RepairedQty = (decimal)drow["RepairedQty"];
            }
            if (drow["RepairedCnt"] == DBNull.Value)
            {
                this.RepairedCnt = -1;
            }
            else
            {
                this.RepairedCnt = (int)drow["RepairedCnt"];
            }
            if (drow["AvailableManufFlag"] == DBNull.Value)
            {
                this.AvailableManufFlag = false;
            }
            else
            {
                this.AvailableManufFlag = (bool)drow["AvailableManufFlag"];
            }
            if (drow["StopFlag"] == DBNull.Value)
            {
                this.StopFlag = false;
            }
            else
            {
                this.StopFlag = (bool)drow["StopFlag"];
            }
            if (drow["FileCount"] == DBNull.Value)
            {
                this.FileCount = -1;
            }
            else
            {
                this.FileCount = (int)drow["FileCount"];
            }
            if (drow["ImgCount"] == DBNull.Value)
            {
                this.ImgCount = -1;
            }
            else
            {
                this.ImgCount = (int)drow["ImgCount"];
            }
            if (drow["PositionName"] == DBNull.Value)
            {
                this.PositionName = string.Empty;
            }
            else
            {
                this.PositionName = drow["PositionName"].ToString();
            }
            if (drow["StatusName"] == DBNull.Value)
            {
                this.StatusName = string.Empty;
            }
            else
            {
                this.StatusName = drow["StatusName"].ToString();
            }
            if (drow["PrdTypeName"] == DBNull.Value)
            {
                this.PrdTypeName = string.Empty;
            }
            else
            {
                this.PrdTypeName = drow["PrdTypeName"].ToString();
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