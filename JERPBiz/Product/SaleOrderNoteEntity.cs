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
    /// 表[SaleOrderNotes]数据实体类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2015/10/5 18:38:15
    ///</时间>  
    public class SaleOrderNoteEntity
    {
        public SaleOrderNoteEntity()
        {
            this.accData = new JERPData.Product.SaleOrderNotes();
        }
        private JERPData.Product.SaleOrderNotes accData;
        public long NoteID = -1;
        public int SerialNo = -1;
        public string NoteCode = string.Empty;
        public string PONo = string.Empty;
        public DateTime DateNote = DateTime.MinValue;
        public int CompanyID = -1;
        public int DeliverAddressID = -1;
        public int FinanceAddressID = -1;
        public int DeliverTypeID = -1;
        public string ExpressRequire = string.Empty;
        public int MoneyTypeID = -1;
        public int SettleTypeID = -1;
        public int PriceTypeID = -1;
        public int InvoiceTypeID = -1;
        public int MakerPsnID = -1;
        public int HandlePsnID = -1;
        public int SalePsnID = -1;
        public int AreaID = -1;
        public string Memo = string.Empty;
        public bool FinishedFlag = false;
        public decimal TotalAMT = 0;
        public decimal FinishedAMT = 0;
        public decimal NonFinishedAMT = 0;
        public decimal AdvanceAMT = 0;
        public decimal DeliverNoteAMT = 0;
        public string CompanyCode = string.Empty;
        public string CompanyAbbName = string.Empty;
        public string CompanyAllName = string.Empty;
        public string DeliverAddress = string.Empty;
        public string FinanceAddress = string.Empty;
        public string AreaName = string.Empty;
        public string DeliverTypeName = string.Empty;
        public string MoneyTypeName = string.Empty;
        public string SettleTypeName = string.Empty;
        public string PriceTypeName = string.Empty;
        public string InvoiceTypeName = string.Empty;
        public string MakerPsn = string.Empty;
        public string SalePsn = string.Empty;
        public void LoadData(long NoteID)
        {
            this.NoteID = NoteID;
            DataTable dtbl = this.accData.GetDataSaleOrderNotesByNoteID(NoteID).Tables[0];
            if (dtbl.Rows.Count == 0)
            {
                this.SerialNo = -1;
                this.NoteCode = string.Empty;
                this.PONo = string.Empty;
                this.DateNote = DateTime.MinValue;
                this.CompanyID = -1;
                this.DeliverAddressID = -1;
                this.FinanceAddressID = -1;
                this.DeliverTypeID = -1;
                this.ExpressRequire = string.Empty;
                this.MoneyTypeID = -1;
                this.SettleTypeID = -1;
                this.PriceTypeID = -1;
                this.InvoiceTypeID = -1;
                this.MakerPsnID = -1;
                this.HandlePsnID = -1;
                this.SalePsnID = -1;
                this.AreaID = -1;
                this.Memo = string.Empty;
                this.FinishedFlag = false;
                this.TotalAMT = 0;
                this.FinishedAMT = 0;
                this.NonFinishedAMT = 0;
                this.AdvanceAMT = 0;
                this.DeliverNoteAMT = 0;
                this.CompanyCode = string.Empty;
                this.CompanyAbbName = string.Empty;
                this.CompanyAllName = string.Empty;
                this.DeliverAddress = string.Empty;
                this.FinanceAddress = string.Empty;
                this.AreaName = string.Empty;
                this.DeliverTypeName = string.Empty;
                this.MoneyTypeName = string.Empty;
                this.SettleTypeName = string.Empty;
                this.PriceTypeName = string.Empty;
                this.InvoiceTypeName = string.Empty;
                this.MakerPsn = string.Empty;
                this.SalePsn = string.Empty;
                return;
            }
            DataRow drow = dtbl.Rows[0];
            if (drow["SerialNo"] == DBNull.Value)
            {
                this.SerialNo = -1;
            }
            else
            {
                this.SerialNo = (int)drow["SerialNo"];
            }
            if (drow["NoteCode"] == DBNull.Value)
            {
                this.NoteCode = string.Empty;
            }
            else
            {
                this.NoteCode = drow["NoteCode"].ToString();
            }
            if (drow["PONo"] == DBNull.Value)
            {
                this.PONo = string.Empty;
            }
            else
            {
                this.PONo = drow["PONo"].ToString();
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
            if (drow["MakerPsnID"] == DBNull.Value)
            {
                this.MakerPsnID = -1;
            }
            else
            {
                this.MakerPsnID = (int)drow["MakerPsnID"];
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
            if (drow["AreaID"] == DBNull.Value)
            {
                this.AreaID = -1;
            }
            else
            {
                this.AreaID = (int)drow["AreaID"];
            }
            if (drow["Memo"] == DBNull.Value)
            {
                this.Memo = string.Empty;
            }
            else
            {
                this.Memo = drow["Memo"].ToString();
            }
            if (drow["FinishedFlag"] == DBNull.Value)
            {
                this.FinishedFlag = false;
            }
            else
            {
                this.FinishedFlag = (bool)drow["FinishedFlag"];
            }
            if (drow["TotalAMT"] == DBNull.Value)
            {
                this.TotalAMT = 0;
            }
            else
            {
                this.TotalAMT = (decimal)drow["TotalAMT"];
            }
            if (drow["FinishedAMT"] == DBNull.Value)
            {
                this.FinishedAMT = 0;
            }
            else
            {
                this.FinishedAMT = (decimal)drow["FinishedAMT"];
            }
            if (drow["NonFinishedAMT"] == DBNull.Value)
            {
                this.NonFinishedAMT = 0;
            }
            else
            {
                this.NonFinishedAMT = (decimal)drow["NonFinishedAMT"];
            }
            if (drow["AdvanceAMT"] == DBNull.Value)
            {
                this.AdvanceAMT = 0;
            }
            else
            {
                this.AdvanceAMT = (decimal)drow["AdvanceAMT"];
            }
            if (drow["DeliverNoteAMT"] == DBNull.Value)
            {
                this.DeliverNoteAMT = 0;
            }
            else
            {
                this.DeliverNoteAMT = (decimal)drow["DeliverNoteAMT"];
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
            if (drow["AreaName"] == DBNull.Value)
            {
                this.AreaName = string.Empty;
            }
            else
            {
                this.AreaName = drow["AreaName"].ToString();
            }
            if (drow["DeliverTypeName"] == DBNull.Value)
            {
                this.DeliverTypeName = string.Empty;
            }
            else
            {
                this.DeliverTypeName = drow["DeliverTypeName"].ToString();
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
            if (drow["MakerPsn"] == DBNull.Value)
            {
                this.MakerPsn = string.Empty;
            }
            else
            {
                this.MakerPsn = drow["MakerPsn"].ToString();
            }
            if (drow["SalePsn"] == DBNull.Value)
            {
                this.SalePsn = string.Empty;
            }
            else
            {
                this.SalePsn = drow["SalePsn"].ToString();
            }
        }
    }
}