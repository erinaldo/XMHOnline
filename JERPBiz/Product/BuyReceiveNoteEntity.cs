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
    /// 表[BuyReceiveNotes]数据实体类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2016/1/18 17:19:45
    ///</时间>  
    public class BuyReceiveNoteEntity
    {
        public BuyReceiveNoteEntity()
        {
            this.accData = new JERPData.Product.BuyReceiveNotes();
        }
        private JERPData.Product.BuyReceiveNotes accData;
        public long NoteID = -1;
        public string NoteCode = string.Empty;
        public DateTime DateNote = DateTime.MinValue;
        public long BuyOrderNoteID = -1;
        public string PONo = string.Empty;
        public int CompanyID = -1;
        public int QCPsnID = -1;
        public int MoneyTypeID = -1;
        public int SettleTypeID = -1;
        public int PriceTypeID = -1;
        public int InvoiceTypeID = -1;
        public bool CashSettleFlag = false;
        public decimal TotalAMT = 0;
        public int MakerPsnID = -1;
        public int PrinterPsnID = -1;
        public string Memo = string.Empty;
        public long ReconciliationID = -1;
        public string CompanyCode = string.Empty;
        public string CompanyAbbName = string.Empty;
        public string CompanyAllName = string.Empty;
        public string MoneyTypeName = string.Empty;
        public string SettleTypeName = string.Empty;
        public string PriceTypeName = string.Empty;
        public string InvoiceTypeName = string.Empty;
        public string QCPsn = string.Empty;
        public string MakerPsn = string.Empty;
        public string PrinterPsn = string.Empty;
        public void LoadData(long NoteID)
        {
            this.NoteID = NoteID;
            DataTable dtbl = this.accData.GetDataBuyReceiveNotesByNoteID(NoteID).Tables[0];
            if (dtbl.Rows.Count == 0)
            {
                this.NoteCode = string.Empty;
                this.DateNote = DateTime.MinValue;
                this.BuyOrderNoteID = -1;
                this.PONo = string.Empty;
                this.CompanyID = -1;
                this.QCPsnID = -1;
                this.MoneyTypeID = -1;
                this.SettleTypeID = -1;
                this.PriceTypeID = -1;
                this.InvoiceTypeID = -1;
                this.CashSettleFlag = false;
                this.TotalAMT = 0;
                this.MakerPsnID = -1;
                this.PrinterPsnID = -1;
                this.Memo = string.Empty;
                this.ReconciliationID = -1;
                this.CompanyCode = string.Empty;
                this.CompanyAbbName = string.Empty;
                this.CompanyAllName = string.Empty;
                this.MoneyTypeName = string.Empty;
                this.SettleTypeName = string.Empty;
                this.PriceTypeName = string.Empty;
                this.InvoiceTypeName = string.Empty;
                this.QCPsn = string.Empty;
                this.MakerPsn = string.Empty;
                this.PrinterPsn = string.Empty;
                return;
            }
            DataRow drow = dtbl.Rows[0];
            if (drow["NoteCode"] == DBNull.Value)
            {
                this.NoteCode = string.Empty;
            }
            else
            {
                this.NoteCode = drow["NoteCode"].ToString();
            }
            if (drow["DateNote"] == DBNull.Value)
            {
                this.DateNote = DateTime.MinValue;
            }
            else
            {
                this.DateNote = (DateTime)drow["DateNote"];
            }
            if (drow["BuyOrderNoteID"] == DBNull.Value)
            {
                this.BuyOrderNoteID = -1;
            }
            else
            {
                this.BuyOrderNoteID = (long)drow["BuyOrderNoteID"];
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
            if (drow["QCPsnID"] == DBNull.Value)
            {
                this.QCPsnID = -1;
            }
            else
            {
                this.QCPsnID = (int)drow["QCPsnID"];
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
            if (drow["TotalAMT"] == DBNull.Value)
            {
                this.TotalAMT = 0;
            }
            else
            {
                this.TotalAMT = (decimal)drow["TotalAMT"];
            }
            if (drow["MakerPsnID"] == DBNull.Value)
            {
                this.MakerPsnID = -1;
            }
            else
            {
                this.MakerPsnID = (int)drow["MakerPsnID"];
            }
            if (drow["PrinterPsnID"] == DBNull.Value)
            {
                this.PrinterPsnID = -1;
            }
            else
            {
                this.PrinterPsnID = (int)drow["PrinterPsnID"];
            }
            if (drow["Memo"] == DBNull.Value)
            {
                this.Memo = string.Empty;
            }
            else
            {
                this.Memo = drow["Memo"].ToString();
            }
            if (drow["ReconciliationID"] == DBNull.Value)
            {
                this.ReconciliationID = -1;
            }
            else
            {
                this.ReconciliationID = (long)drow["ReconciliationID"];
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
            if (drow["QCPsn"] == DBNull.Value)
            {
                this.QCPsn = string.Empty;
            }
            else
            {
                this.QCPsn = drow["QCPsn"].ToString();
            }
            if (drow["MakerPsn"] == DBNull.Value)
            {
                this.MakerPsn = string.Empty;
            }
            else
            {
                this.MakerPsn = drow["MakerPsn"].ToString();
            }
            if (drow["PrinterPsn"] == DBNull.Value)
            {
                this.PrinterPsn = string.Empty;
            }
            else
            {
                this.PrinterPsn = drow["PrinterPsn"].ToString();
            }
        }
    }
}