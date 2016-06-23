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
    /// 表[OutSrcOrderItems]数据实体类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2016/5/3 22:53:29
    ///</时间>  
    public class OutSrcOrderItemEntity
    {
        public OutSrcOrderItemEntity()
        {
            this.accData = new JERPData.Manufacture.OutSrcOrderItems();
        }
        private JERPData.Manufacture.OutSrcOrderItems accData;
        public long ItemID = -1;
        public long NoteID = -1;
        public string PONo = string.Empty;
        public long ManufScheduleID = -1;
        public long WorkingSheetID = -1;
        public string WorkingSheetCode = string.Empty;
        public int CustomerID = -1;
        public int PrdID = -1;
        public long ManufProcessID = -1;
        public string PrdStatus = string.Empty;
        public decimal Quantity = 0;
        public decimal Price = 0;
        public decimal FinishedQty = 0;
        public decimal NonFinishedQty = 0;
        public bool BOMRequireFlag = false;
        public decimal BOMFinishedQty = 0;
        public decimal BOMNonFinishedQty = 0;
        public DateTime DateTarget = DateTime.MinValue;
        public string Memo = string.Empty;
        public DateTime DateNote = DateTime.MinValue;
        public int CompanyID = -1;
        public int MoneyTypeID = -1;
        public int SettleTypeID = -1;
        public int PriceTypeID = -1;
        public int OrderTypeID = -1;
        public int MakerPsnID = -1;
        public string SupplierAddress = string.Empty;
        public string PrdCode = string.Empty;
        public string PrdName = string.Empty;
        public string PrdSpec = string.Empty;
        public string Model = string.Empty;
        public string MouldCode = string.Empty;
        public string UnitName = string.Empty;
        public string Customer = string.Empty;
        public string CompanyAbbName = string.Empty;
        public void LoadData(long ItemID)
        {
            this.ItemID = ItemID;
            DataTable dtbl = this.accData.GetDataOutSrcOrderItemsByItemID(ItemID).Tables[0];
            if (dtbl.Rows.Count == 0)
            {
                this.NoteID = -1;
                this.PONo = string.Empty;
                this.ManufScheduleID = -1;
                this.WorkingSheetID = -1;
                this.WorkingSheetCode = string.Empty;
                this.CustomerID = -1;
                this.PrdID = -1;
                this.ManufProcessID = -1;
                this.PrdStatus = string.Empty;
                this.Quantity = 0;
                this.Price = 0;
                this.FinishedQty = 0;
                this.NonFinishedQty = 0;
                this.BOMRequireFlag = false;
                this.BOMFinishedQty = 0;
                this.BOMNonFinishedQty = 0;
                this.DateTarget = DateTime.MinValue;
                this.Memo = string.Empty;
                this.DateNote = DateTime.MinValue;
                this.CompanyID = -1;
                this.MoneyTypeID = -1;
                this.SettleTypeID = -1;
                this.PriceTypeID = -1;
                this.OrderTypeID = -1;
                this.MakerPsnID = -1;
                this.SupplierAddress = string.Empty;
                this.PrdCode = string.Empty;
                this.PrdName = string.Empty;
                this.PrdSpec = string.Empty;
                this.Model = string.Empty;
                this.MouldCode = string.Empty;
                this.UnitName = string.Empty;
                this.Customer = string.Empty;
                this.CompanyAbbName = string.Empty;
                return;
            }
            DataRow drow = dtbl.Rows[0];
            if (drow["NoteID"] == DBNull.Value)
            {
                this.NoteID = -1;
            }
            else
            {
                this.NoteID = (long)drow["NoteID"];
            }
            if (drow["PONo"] == DBNull.Value)
            {
                this.PONo = string.Empty;
            }
            else
            {
                this.PONo = drow["PONo"].ToString();
            }
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
            if (drow["WorkingSheetCode"] == DBNull.Value)
            {
                this.WorkingSheetCode = string.Empty;
            }
            else
            {
                this.WorkingSheetCode = drow["WorkingSheetCode"].ToString();
            }
            if (drow["CustomerID"] == DBNull.Value)
            {
                this.CustomerID = -1;
            }
            else
            {
                this.CustomerID = (int)drow["CustomerID"];
            }
            if (drow["PrdID"] == DBNull.Value)
            {
                this.PrdID = -1;
            }
            else
            {
                this.PrdID = (int)drow["PrdID"];
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
            if (drow["Quantity"] == DBNull.Value)
            {
                this.Quantity = 0;
            }
            else
            {
                this.Quantity = (decimal)drow["Quantity"];
            }
            if (drow["Price"] == DBNull.Value)
            {
                this.Price = 0;
            }
            else
            {
                this.Price = (decimal)drow["Price"];
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
            if (drow["DateTarget"] == DBNull.Value)
            {
                this.DateTarget = DateTime.MinValue;
            }
            else
            {
                this.DateTarget = (DateTime)drow["DateTarget"];
            }
            if (drow["Memo"] == DBNull.Value)
            {
                this.Memo = string.Empty;
            }
            else
            {
                this.Memo = drow["Memo"].ToString();
            }
            if (drow["DateNote"] == DBNull.Value)
            {
                this.DateNote = DateTime.MinValue;
            }
            else
            {
                this.DateNote = (DateTime)drow["DateNote"];
            }
            if (drow["CompanyID"] == DBNull.Value)
            {
                this.CompanyID = -1;
            }
            else
            {
                this.CompanyID = (int)drow["CompanyID"];
            }
            if (drow["MoneyTypeID"] == DBNull.Value)
            {
                this.MoneyTypeID = -1;
            }
            else
            {
                this.MoneyTypeID = (int)drow["MoneyTypeID"];
            }
            if (drow["SettleTypeID"] == DBNull.Value)
            {
                this.SettleTypeID = -1;
            }
            else
            {
                this.SettleTypeID = (int)drow["SettleTypeID"];
            }
            if (drow["PriceTypeID"] == DBNull.Value)
            {
                this.PriceTypeID = -1;
            }
            else
            {
                this.PriceTypeID = (int)drow["PriceTypeID"];
            }
            if (drow["OrderTypeID"] == DBNull.Value)
            {
                this.OrderTypeID = -1;
            }
            else
            {
                this.OrderTypeID = (int)drow["OrderTypeID"];
            }
            if (drow["MakerPsnID"] == DBNull.Value)
            {
                this.MakerPsnID = -1;
            }
            else
            {
                this.MakerPsnID = (int)drow["MakerPsnID"];
            }
            if (drow["SupplierAddress"] == DBNull.Value)
            {
                this.SupplierAddress = string.Empty;
            }
            else
            {
                this.SupplierAddress = drow["SupplierAddress"].ToString();
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
            if (drow["MouldCode"] == DBNull.Value)
            {
                this.MouldCode = string.Empty;
            }
            else
            {
                this.MouldCode = drow["MouldCode"].ToString();
            }
            if (drow["UnitName"] == DBNull.Value)
            {
                this.UnitName = string.Empty;
            }
            else
            {
                this.UnitName = drow["UnitName"].ToString();
            }
            if (drow["Customer"] == DBNull.Value)
            {
                this.Customer = string.Empty;
            }
            else
            {
                this.Customer = drow["Customer"].ToString();
            }
            if (drow["CompanyAbbName"] == DBNull.Value)
            {
                this.CompanyAbbName = string.Empty;
            }
            else
            {
                this.CompanyAbbName = drow["CompanyAbbName"].ToString();
            }
        }
    }
}