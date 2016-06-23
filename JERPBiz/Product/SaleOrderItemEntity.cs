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
namespace JERPBiz.Product
{
    /// <描述>
    /// 表[SaleOrderItems]数据实体类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2016/4/26 8:17:46
    ///</时间>  
    public class SaleOrderItemEntity
    {
        public SaleOrderItemEntity()
        {
            this.accData = new JERPData.Product.SaleOrderItems();
        }
        private JERPData.Product.SaleOrderItems accData;
        public long ItemID = -1;
        public long NoteID = -1;
        public string PONo = string.Empty;
        public string ItemNo = string.Empty;
        public string CustomerRef = string.Empty;
        public string BatchNo = string.Empty;
        public int PrdID = -1;
        public decimal Quantity = 0;
        public decimal Price = 0;
        public decimal ItemAMT = 0;
        public DateTime DateTarget = DateTime.MinValue;
        public string Memo = string.Empty;
        public decimal DeliverPlanQty = 0;
        public decimal NonDeliverPlanQty = 0;
        public decimal FinishedQty = 0;
        public decimal NonFinishedQty = 0;
        public decimal HandleQty = 0;
        public decimal NonHandleQty = 0;
        public DateTime DateNote = DateTime.MinValue;
        public int MakerPsnID = -1;
        public int ConfirmPsnID = -1;
        public int CompanyID = -1;
        public int AreaID = -1;
        public int HandlePsnID = -1;
        public int SalePsnID = -1;
        public int MoneyTypeID = -1;
        public int SettleTypeID = -1;
        public int PriceTypeID = -1;
        public int DeliverTypeID = -1;
        public int DeliverAddressID = -1;
        public int FinanceAddressID = -1;
        public string ExpressRequire = string.Empty;
        public string SalePsn = string.Empty;
        public string MakerPsn = string.Empty;
        public string CompanyCode = string.Empty;
        public string CompanyAbbName = string.Empty;
        public string PrdCode = string.Empty;
        public string PrdName = string.Empty;
        public string PrdSpec = string.Empty;
        public string Model = string.Empty;
        public string UnitName = string.Empty;
        public void LoadData(long ItemID)
        {
            this.ItemID = ItemID;
            DataTable dtbl = this.accData.GetDataSaleOrderItemsByItemID(ItemID).Tables[0];
            if (dtbl.Rows.Count == 0)
            {
                this.NoteID = -1;
                this.PONo = string.Empty;
                this.ItemNo = string.Empty;
                this.CustomerRef = string.Empty;
                this.BatchNo = string.Empty;
                this.PrdID = -1;
                this.Quantity = 0;
                this.Price = 0;
                this.ItemAMT = 0;
                this.DateTarget = DateTime.MinValue;
                this.Memo = string.Empty;
                this.DeliverPlanQty = 0;
                this.NonDeliverPlanQty = 0;
                this.FinishedQty = 0;
                this.NonFinishedQty = 0;
                this.HandleQty = 0;
                this.NonHandleQty = 0;
                this.DateNote = DateTime.MinValue;
                this.MakerPsnID = -1;
                this.ConfirmPsnID = -1;
                this.CompanyID = -1;
                this.AreaID = -1;
                this.HandlePsnID = -1;
                this.SalePsnID = -1;
                this.MoneyTypeID = -1;
                this.SettleTypeID = -1;
                this.PriceTypeID = -1;
                this.DeliverTypeID = -1;
                this.DeliverAddressID = -1;
                this.FinanceAddressID = -1;
                this.ExpressRequire = string.Empty;
                this.SalePsn = string.Empty;
                this.MakerPsn = string.Empty;
                this.CompanyCode = string.Empty;
                this.CompanyAbbName = string.Empty;
                this.PrdCode = string.Empty;
                this.PrdName = string.Empty;
                this.PrdSpec = string.Empty;
                this.Model = string.Empty;
                this.UnitName = string.Empty;
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
            if (drow["ItemNo"] == DBNull.Value)
            {
                this.ItemNo = string.Empty;
            }
            else
            {
                this.ItemNo = drow["ItemNo"].ToString();
            }
            if (drow["CustomerRef"] == DBNull.Value)
            {
                this.CustomerRef = string.Empty;
            }
            else
            {
                this.CustomerRef = drow["CustomerRef"].ToString();
            }
            if (drow["BatchNo"] == DBNull.Value)
            {
                this.BatchNo = string.Empty;
            }
            else
            {
                this.BatchNo = drow["BatchNo"].ToString();
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
            if (drow["Price"] == DBNull.Value)
            {
                this.Price = 0;
            }
            else
            {
                this.Price = (decimal)drow["Price"];
            }
            if (drow["ItemAMT"] == DBNull.Value)
            {
                this.ItemAMT = 0;
            }
            else
            {
                this.ItemAMT = (decimal)drow["ItemAMT"];
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
            if (drow["DeliverPlanQty"] == DBNull.Value)
            {
                this.DeliverPlanQty = 0;
            }
            else
            {
                this.DeliverPlanQty = (decimal)drow["DeliverPlanQty"];
            }
            if (drow["NonDeliverPlanQty"] == DBNull.Value)
            {
                this.NonDeliverPlanQty = 0;
            }
            else
            {
                this.NonDeliverPlanQty = (decimal)drow["NonDeliverPlanQty"];
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
            if (drow["HandleQty"] == DBNull.Value)
            {
                this.HandleQty = 0;
            }
            else
            {
                this.HandleQty = (decimal)drow["HandleQty"];
            }
            if (drow["NonHandleQty"] == DBNull.Value)
            {
                this.NonHandleQty = 0;
            }
            else
            {
                this.NonHandleQty = (decimal)drow["NonHandleQty"];
            }
            if (drow["DateNote"] == DBNull.Value)
            {
                this.DateNote = DateTime.MinValue;
            }
            else
            {
                this.DateNote = (DateTime)drow["DateNote"];
            }
            if (drow["MakerPsnID"] == DBNull.Value)
            {
                this.MakerPsnID = -1;
            }
            else
            {
                this.MakerPsnID = (int)drow["MakerPsnID"];
            }
            if (drow["ConfirmPsnID"] == DBNull.Value)
            {
                this.ConfirmPsnID = -1;
            }
            else
            {
                this.ConfirmPsnID = (int)drow["ConfirmPsnID"];
            }
            if (drow["CompanyID"] == DBNull.Value)
            {
                this.CompanyID = -1;
            }
            else
            {
                this.CompanyID = (int)drow["CompanyID"];
            }
            if (drow["AreaID"] == DBNull.Value)
            {
                this.AreaID = -1;
            }
            else
            {
                this.AreaID = (int)drow["AreaID"];
            }
            if (drow["HandlePsnID"] == DBNull.Value)
            {
                this.HandlePsnID = -1;
            }
            else
            {
                this.HandlePsnID = (int)drow["HandlePsnID"];
            }
            if (drow["SalePsnID"] == DBNull.Value)
            {
                this.SalePsnID = -1;
            }
            else
            {
                this.SalePsnID = (int)drow["SalePsnID"];
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
            if (drow["DeliverTypeID"] == DBNull.Value)
            {
                this.DeliverTypeID = -1;
            }
            else
            {
                this.DeliverTypeID = (int)drow["DeliverTypeID"];
            }
            if (drow["DeliverAddressID"] == DBNull.Value)
            {
                this.DeliverAddressID = -1;
            }
            else
            {
                this.DeliverAddressID = (int)drow["DeliverAddressID"];
            }
            if (drow["FinanceAddressID"] == DBNull.Value)
            {
                this.FinanceAddressID = -1;
            }
            else
            {
                this.FinanceAddressID = (int)drow["FinanceAddressID"];
            }
            if (drow["ExpressRequire"] == DBNull.Value)
            {
                this.ExpressRequire = string.Empty;
            }
            else
            {
                this.ExpressRequire = drow["ExpressRequire"].ToString();
            }
            if (drow["SalePsn"] == DBNull.Value)
            {
                this.SalePsn = string.Empty;
            }
            else
            {
                this.SalePsn = drow["SalePsn"].ToString();
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
            if (drow["CompanyAbbName"] == DBNull.Value)
            {
                this.CompanyAbbName = string.Empty;
            }
            else
            {
                this.CompanyAbbName = drow["CompanyAbbName"].ToString();
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
        }
    }
}