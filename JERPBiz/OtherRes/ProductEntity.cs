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
namespace JERPBiz.OtherRes
{
    /// <描述>
    /// 表[Product]数据实体类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2016/3/1 22:47:44
    ///</时间>  
    public class ProductEntity
    {
        public ProductEntity()
        {
            this.accData = new JERPData.OtherRes.Product();
        }
        private JERPData.OtherRes.Product accData;
        public int PrdID = -1;
        public int PrdTypeID = -1;
        public string PrdName = string.Empty;
        public string PrdSpec = string.Empty;
        public string AssistantCode = string.Empty;
        public int UnitID = -1;
        public decimal CostPrice = 0;
        public decimal SafeStoreQty = 0;
        public decimal MinPackingQty = 0;
        public string Supplier = string.Empty;
        public string PurchasePriceInfor = string.Empty;
        public int FileCount = -1;
        public int ImgCount = -1;
        public string UnitName = string.Empty;
        public string PrdTypeName = string.Empty;
        public void LoadData(int PrdID)
        {
            this.PrdID = PrdID;
            DataTable dtbl = this.accData.GetDataProductByPrdID(PrdID).Tables[0];
            if (dtbl.Rows.Count == 0)
            {
                this.PrdTypeID = -1;
                this.PrdName = string.Empty;
                this.PrdSpec = string.Empty;
                this.AssistantCode = string.Empty;
                this.UnitID = -1;
                this.CostPrice = 0;
                this.SafeStoreQty = 0;
                this.MinPackingQty = 0;
                this.Supplier = string.Empty;
                this.PurchasePriceInfor = string.Empty;
                this.FileCount = -1;
                this.ImgCount = -1;
                this.UnitName = string.Empty;
                this.PrdTypeName = string.Empty;
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
            if (drow["AssistantCode"] == DBNull.Value)
            {
                this.AssistantCode = string.Empty;
            }
            else
            {
                this.AssistantCode = drow["AssistantCode"].ToString();
            }
            if (drow["UnitID"] == DBNull.Value)
            {
                this.UnitID = -1;
            }
            else
            {
                this.UnitID = (int)drow["UnitID"];
            }
            if (drow["CostPrice"] == DBNull.Value)
            {
                this.CostPrice = 0;
            }
            else
            {
                this.CostPrice = (decimal)drow["CostPrice"];
            }
            if (drow["SafeStoreQty"] == DBNull.Value)
            {
                this.SafeStoreQty = 0;
            }
            else
            {
                this.SafeStoreQty = (decimal)drow["SafeStoreQty"];
            }
            if (drow["MinPackingQty"] == DBNull.Value)
            {
                this.MinPackingQty = 0;
            }
            else
            {
                this.MinPackingQty = (decimal)drow["MinPackingQty"];
            }
            if (drow["Supplier"] == DBNull.Value)
            {
                this.Supplier = string.Empty;
            }
            else
            {
                this.Supplier = drow["Supplier"].ToString();
            }
            if (drow["PurchasePriceInfor"] == DBNull.Value)
            {
                this.PurchasePriceInfor = string.Empty;
            }
            else
            {
                this.PurchasePriceInfor = drow["PurchasePriceInfor"].ToString();
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
            if (drow["UnitName"] == DBNull.Value)
            {
                this.UnitName = string.Empty;
            }
            else
            {
                this.UnitName = drow["UnitName"].ToString();
            }
            if (drow["PrdTypeName"] == DBNull.Value)
            {
                this.PrdTypeName = string.Empty;
            }
            else
            {
                this.PrdTypeName = drow["PrdTypeName"].ToString();
            }
        }
    }
}