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
    /// 表[SaleDeliverPlanNotes]数据实体类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2015/9/25 8:43:26
    ///</时间>  
    public class SaleDeliverPlanNoteEntity
    {
        public SaleDeliverPlanNoteEntity()
        {
            this.accData = new JERPData.Product.SaleDeliverPlanNotes();
        }
        private JERPData.Product.SaleDeliverPlanNotes accData;
        public long NoteID = -1;
        public DateTime DateTarget = DateTime.MinValue;
        public long SaleOrderNoteID = -1;
        public string PONo = string.Empty;
        public int CompanyID = -1;
        public int DeliverAddressID = -1;
        public int FinanceAddressID = -1;
        public int DeliverTypeID = -1;
        public string ExpressRequire = string.Empty;
        public int MoneyTypeID = -1;
        public int SettleTypeID = -1;
        public int PriceTypeID = -1;
        public int InvoiceTypeID = -1;
        public bool CashSettleFlag = false;
        public int MakerPsnID = -1;
        public string Memo = string.Empty;
        public string CompanyCode = string.Empty;
        public string CompanyAbbName = string.Empty;
        public string CompanyAllName = string.Empty;
        public string DeliverAddress = string.Empty;
        public string FinanceAddress = string.Empty;
        public string MoneyTypeName = string.Empty;
        public string SettleTypeName = string.Empty;
        public string PriceTypeName = string.Empty;
        public string InvoiceTypeName = string.Empty;
        public string DeliverTypeName = string.Empty;
        public string MakerPsn = string.Empty;
        public void LoadData(long NoteID)
        {
            this.NoteID = NoteID;
            DataTable dtbl = this.accData.GetDataSaleDeliverPlanNotesByNoteID(NoteID).Tables[0];
            if (dtbl.Rows.Count == 0)
            {
                this.DateTarget = DateTime.MinValue;
                this.SaleOrderNoteID = -1;
                this.PONo = string.Empty;
                this.CompanyID = -1;
                this.DeliverAddressID = -1;
                this.FinanceAddressID = -1;
                this.DeliverTypeID = -1;
                this.ExpressRequire = string.Empty;
                this.MoneyTypeID = -1;
                this.SettleTypeID = -1;
                this.PriceTypeID = -1;
                this.InvoiceTypeID = -1;
                this.CashSettleFlag = false;
                this.MakerPsnID = -1;
                this.Memo = string.Empty;
                this.CompanyCode = string.Empty;
                this.CompanyAbbName = string.Empty;
                this.CompanyAllName = string.Empty;
                this.DeliverAddress = string.Empty;
                this.FinanceAddress = string.Empty;
                this.MoneyTypeName = string.Empty;
                this.SettleTypeName = string.Empty;
                this.PriceTypeName = string.Empty;
                this.InvoiceTypeName = string.Empty;
                this.DeliverTypeName = string.Empty;
                this.MakerPsn = string.Empty;
                return;
            }
            DataRow drow = dtbl.Rows[0];
            if (drow["DateTarget"] == DBNull.Value)
            {
                this.DateTarget = DateTime.MinValue;
            }
            else
            {
                this.DateTarget = (DateTime)drow["DateTarget"];
            }
            if (drow["SaleOrderNoteID"] == DBNull.Value)
            {
                this.SaleOrderNoteID = -1;
            }
            else
            {
                this.SaleOrderNoteID = (long)drow["SaleOrderNoteID"];
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
            if (drow["DeliverTypeID"] == DBNull.Value)
            {
                this.DeliverTypeID = -1;
            }
            else
            {
                this.DeliverTypeID = (int)drow["DeliverTypeID"];
            }
            if (drow["ExpressRequire"] == DBNull.Value)
            {
                this.ExpressRequire = string.Empty;
            }
            else
            {
                this.ExpressRequire = drow["ExpressRequire"].ToString();
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
            if (drow["InvoiceTypeID"] == DBNull.Value)
            {
                this.InvoiceTypeID = -1;
            }
            else
            {
                this.InvoiceTypeID = (int)drow["InvoiceTypeID"];
            }
            if (drow["CashSettleFlag"] == DBNull.Value)
            {
                this.CashSettleFlag = false;
            }
            else
            {
                this.CashSettleFlag = (bool)drow["CashSettleFlag"];
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
            if (drow["CompanyAllName"] == DBNull.Value)
            {
                this.CompanyAllName = string.Empty;
            }
            else
            {
                this.CompanyAllName = drow["CompanyAllName"].ToString();
            }
            if (drow["DeliverAddress"] == DBNull.Value)
            {
                this.DeliverAddress = string.Empty;
            }
            else
            {
                this.DeliverAddress = drow["DeliverAddress"].ToString();
            }
            if (drow["FinanceAddress"] == DBNull.Value)
            {
                this.FinanceAddress = string.Empty;
            }
            else
            {
                this.FinanceAddress = drow["FinanceAddress"].ToString();
            }
            if (drow["MoneyTypeName"] == DBNull.Value)
            {
                this.MoneyTypeName = string.Empty;
            }
            else
            {
                this.MoneyTypeName = drow["MoneyTypeName"].ToString();
            }
            if (drow["SettleTypeName"] == DBNull.Value)
            {
                this.SettleTypeName = string.Empty;
            }
            else
            {
                this.SettleTypeName = drow["SettleTypeName"].ToString();
            }
            if (drow["PriceTypeName"] == DBNull.Value)
            {
                this.PriceTypeName = string.Empty;
            }
            else
            {
                this.PriceTypeName = drow["PriceTypeName"].ToString();
            }
            if (drow["InvoiceTypeName"] == DBNull.Value)
            {
                this.InvoiceTypeName = string.Empty;
            }
            else
            {
                this.InvoiceTypeName = drow["InvoiceTypeName"].ToString();
            }
            if (drow["DeliverTypeName"] == DBNull.Value)
            {
                this.DeliverTypeName = string.Empty;
            }
            else
            {
                this.DeliverTypeName = drow["DeliverTypeName"].ToString();
            }
            if (drow["MakerPsn"] == DBNull.Value)
            {
                this.MakerPsn = string.Empty;
            }
            else
            {
                this.MakerPsn = drow["MakerPsn"].ToString();
            }
        }
    }
}