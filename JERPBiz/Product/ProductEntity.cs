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
    /// 表[Product]数据实体类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2016/4/25 22:05:17
    ///</时间>  
    public class ProductEntity
    {
        public ProductEntity()
        {
            this.accData = new JERPData.Product.Product();
        }
        private JERPData.Product.Product accData;
        public int PrdID = -1;
        public int PrdTypeID = -1;
        public string PrdCode = string.Empty;
        public string PrdName = string.Empty;
        public string PrdSpec = string.Empty;
        public string Model = string.Empty;
        public string Surface = string.Empty;
        public string Manufacturer = string.Empty;
        public string DWGNo = string.Empty;
        public string AssistantCode = string.Empty;
        public bool TaxfreeFlag = false;
        public bool RohsFlag = false;
        public bool RohsRequireFlag = false;
        public string ICSolution = string.Empty;
        public decimal PrdWeight = 0;
        public bool SaleFlag = false;
        public int UnitID = -1;
        public DateTime DateRegister = DateTime.MinValue;
        public string FileCode = string.Empty;
        public string RegisterPsn = string.Empty;
        public string VersionCode = string.Empty;
        public string VersionRecord = string.Empty;
        public decimal MinPackingQty = 0;
        public decimal CostPrice = 0;
        public decimal SalePrice = 0;
        public string Supplier = string.Empty;
        public string SupplierPrdCode = string.Empty;
        public string Buyer = string.Empty;
        public string ManufProcessList = string.Empty;
        public string PurchasePriceInfor = string.Empty;
        public string ManufProcessCostPriceList = string.Empty;
        public int ManufDays = -1;
        public bool PrdSetFlag = false;
        public int PrdSetCount = -1;
        public int FileCount = -1;
        public int SalePriceFileCount = -1;
        public int ImgCount = -1;
        public int ManufImgCount = -1;
        public bool StopFlag = false;
        public string URL = string.Empty;
        public string Memo = string.Empty;
        public string UnitName = string.Empty;
        public string PrdTypeName = string.Empty;
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
                this.Model = string.Empty;
                this.Surface = string.Empty;
                this.Manufacturer = string.Empty;
                this.DWGNo = string.Empty;
                this.AssistantCode = string.Empty;
                this.TaxfreeFlag = false;
                this.RohsFlag = false;
                this.RohsRequireFlag = false;
                this.ICSolution = string.Empty;
                this.PrdWeight = 0;
                this.SaleFlag = false;
                this.UnitID = -1;
                this.DateRegister = DateTime.MinValue;
                this.FileCode = string.Empty;
                this.RegisterPsn = string.Empty;
                this.VersionCode = string.Empty;
                this.VersionRecord = string.Empty;
                this.MinPackingQty = 0;
                this.CostPrice = 0;
                this.SalePrice = 0;
                this.Supplier = string.Empty;
                this.SupplierPrdCode = string.Empty;
                this.Buyer = string.Empty;
                this.ManufProcessList = string.Empty;
                this.PurchasePriceInfor = string.Empty;
                this.ManufProcessCostPriceList = string.Empty;
                this.ManufDays = -1;
                this.PrdSetFlag = false;
                this.PrdSetCount = -1;
                this.FileCount = -1;
                this.SalePriceFileCount = -1;
                this.ImgCount = -1;
                this.ManufImgCount = -1;
                this.StopFlag = false;
                this.URL = string.Empty;
                this.Memo = string.Empty;
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
            if (drow["Surface"] == DBNull.Value)
            {
                this.Surface = string.Empty;
            }
            else
            {
                this.Surface = drow["Surface"].ToString();
            }
            if (drow["Manufacturer"] == DBNull.Value)
            {
                this.Manufacturer = string.Empty;
            }
            else
            {
                this.Manufacturer = drow["Manufacturer"].ToString();
            }
            if (drow["DWGNo"] == DBNull.Value)
            {
                this.DWGNo = string.Empty;
            }
            else
            {
                this.DWGNo = drow["DWGNo"].ToString();
            }
            if (drow["AssistantCode"] == DBNull.Value)
            {
                this.AssistantCode = string.Empty;
            }
            else
            {
                this.AssistantCode = drow["AssistantCode"].ToString();
            }
            if (drow["TaxfreeFlag"] == DBNull.Value)
            {
                this.TaxfreeFlag = false;
            }
            else
            {
                this.TaxfreeFlag = (bool)drow["TaxfreeFlag"];
            }
            if (drow["RohsFlag"] == DBNull.Value)
            {
                this.RohsFlag = false;
            }
            else
            {
                this.RohsFlag = (bool)drow["RohsFlag"];
            }
            if (drow["RohsRequireFlag"] == DBNull.Value)
            {
                this.RohsRequireFlag = false;
            }
            else
            {
                this.RohsRequireFlag = (bool)drow["RohsRequireFlag"];
            }
            if (drow["ICSolution"] == DBNull.Value)
            {
                this.ICSolution = string.Empty;
            }
            else
            {
                this.ICSolution = drow["ICSolution"].ToString();
            }
            if (drow["PrdWeight"] == DBNull.Value)
            {
                this.PrdWeight = 0;
            }
            else
            {
                this.PrdWeight = (decimal)drow["PrdWeight"];
            }
            if (drow["SaleFlag"] == DBNull.Value)
            {
                this.SaleFlag = false;
            }
            else
            {
                this.SaleFlag = (bool)drow["SaleFlag"];
            }
            if (drow["UnitID"] == DBNull.Value)
            {
                this.UnitID = -1;
            }
            else
            {
                this.UnitID = (int)drow["UnitID"];
            }
            if (drow["DateRegister"] == DBNull.Value)
            {
                this.DateRegister = DateTime.MinValue;
            }
            else
            {
                this.DateRegister = (DateTime)drow["DateRegister"];
            }
            if (drow["FileCode"] == DBNull.Value)
            {
                this.FileCode = string.Empty;
            }
            else
            {
                this.FileCode = drow["FileCode"].ToString();
            }
            if (drow["RegisterPsn"] == DBNull.Value)
            {
                this.RegisterPsn = string.Empty;
            }
            else
            {
                this.RegisterPsn = drow["RegisterPsn"].ToString();
            }
            if (drow["VersionCode"] == DBNull.Value)
            {
                this.VersionCode = string.Empty;
            }
            else
            {
                this.VersionCode = drow["VersionCode"].ToString();
            }
            if (drow["VersionRecord"] == DBNull.Value)
            {
                this.VersionRecord = string.Empty;
            }
            else
            {
                this.VersionRecord = drow["VersionRecord"].ToString();
            }
            if (drow["MinPackingQty"] == DBNull.Value)
            {
                this.MinPackingQty = 0;
            }
            else
            {
                this.MinPackingQty = (decimal)drow["MinPackingQty"];
            }
            if (drow["CostPrice"] == DBNull.Value)
            {
                this.CostPrice = 0;
            }
            else
            {
                this.CostPrice = (decimal)drow["CostPrice"];
            }
            if (drow["SalePrice"] == DBNull.Value)
            {
                this.SalePrice = 0;
            }
            else
            {
                this.SalePrice = (decimal)drow["SalePrice"];
            }
            if (drow["Supplier"] == DBNull.Value)
            {
                this.Supplier = string.Empty;
            }
            else
            {
                this.Supplier = drow["Supplier"].ToString();
            }
            if (drow["SupplierPrdCode"] == DBNull.Value)
            {
                this.SupplierPrdCode = string.Empty;
            }
            else
            {
                this.SupplierPrdCode = drow["SupplierPrdCode"].ToString();
            }
            if (drow["Buyer"] == DBNull.Value)
            {
                this.Buyer = string.Empty;
            }
            else
            {
                this.Buyer = drow["Buyer"].ToString();
            }
            if (drow["ManufProcessList"] == DBNull.Value)
            {
                this.ManufProcessList = string.Empty;
            }
            else
            {
                this.ManufProcessList = drow["ManufProcessList"].ToString();
            }
            if (drow["PurchasePriceInfor"] == DBNull.Value)
            {
                this.PurchasePriceInfor = string.Empty;
            }
            else
            {
                this.PurchasePriceInfor = drow["PurchasePriceInfor"].ToString();
            }
            if (drow["ManufProcessCostPriceList"] == DBNull.Value)
            {
                this.ManufProcessCostPriceList = string.Empty;
            }
            else
            {
                this.ManufProcessCostPriceList = drow["ManufProcessCostPriceList"].ToString();
            }
            if (drow["ManufDays"] == DBNull.Value)
            {
                this.ManufDays = -1;
            }
            else
            {
                this.ManufDays = (int)drow["ManufDays"];
            }
            if (drow["PrdSetFlag"] == DBNull.Value)
            {
                this.PrdSetFlag = false;
            }
            else
            {
                this.PrdSetFlag = (bool)drow["PrdSetFlag"];
            }
            if (drow["PrdSetCount"] == DBNull.Value)
            {
                this.PrdSetCount = -1;
            }
            else
            {
                this.PrdSetCount = (int)drow["PrdSetCount"];
            }
            if (drow["FileCount"] == DBNull.Value)
            {
                this.FileCount = -1;
            }
            else
            {
                this.FileCount = (int)drow["FileCount"];
            }
            if (drow["SalePriceFileCount"] == DBNull.Value)
            {
                this.SalePriceFileCount = -1;
            }
            else
            {
                this.SalePriceFileCount = (int)drow["SalePriceFileCount"];
            }
            if (drow["ImgCount"] == DBNull.Value)
            {
                this.ImgCount = -1;
            }
            else
            {
                this.ImgCount = (int)drow["ImgCount"];
            }
            if (drow["ManufImgCount"] == DBNull.Value)
            {
                this.ManufImgCount = -1;
            }
            else
            {
                this.ManufImgCount = (int)drow["ManufImgCount"];
            }
            if (drow["StopFlag"] == DBNull.Value)
            {
                this.StopFlag = false;
            }
            else
            {
                this.StopFlag = (bool)drow["StopFlag"];
            }
            if (drow["URL"] == DBNull.Value)
            {
                this.URL = string.Empty;
            }
            else
            {
                this.URL = drow["URL"].ToString();
            }
            if (drow["Memo"] == DBNull.Value)
            {
                this.Memo = string.Empty;
            }
            else
            {
                this.Memo = drow["Memo"].ToString();
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