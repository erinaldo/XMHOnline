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
    /// 表[OutSrcOrderNotes]数据实体类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2015/10/6 9:19:18
    ///</时间>  
    public class OutSrcOrderNoteEntity
    {
        public OutSrcOrderNoteEntity()
        {
            this.accData = new JERPData.Manufacture.OutSrcOrderNotes();
        }
        private JERPData.Manufacture.OutSrcOrderNotes accData;
        public long NoteID = -1;
        public string NoteCode = string.Empty;
        public int SerialNo = -1;
        public DateTime DateNote = DateTime.MinValue;
        public int CompanyID = -1;
        public int OrderTypeID = -1;
        public string SupplierAddress = string.Empty;
        public string DeliverAddress = string.Empty;
        public int DeliverTypeID = -1;
        public string ExpressRequire = string.Empty;
        public int MoneyTypeID = -1;
        public int SettleTypeID = -1;
        public int PriceTypeID = -1;
        public int InvoiceTypeID = -1;
        public int MakerPsnID = -1;
        public int ConfirmPsnID = -1;
        public bool PrintFlag = false;
        public string Memo = string.Empty;
        public decimal AdvanceAMT = 0;
        public decimal DeliverAMT = 0;
        public decimal ReceiptAMT = 0;
        public string CompanyAbbName = string.Empty;
        public string CompanyAllName = string.Empty;
        public string MoneyTypeName = string.Empty;
        public string MoneyTypeCode = string.Empty;
        public string PriceTypeName = string.Empty;
        public string InvoiceTypeName = string.Empty;
        public string SettleTypeName = string.Empty;
        public string DeliverTypeName = string.Empty;
        public string MakerPsn = string.Empty;
        public string ConfirmPsn = string.Empty;
        public string OrderTypeName = string.Empty;
        public void LoadData(long NoteID)
        {
            this.NoteID = NoteID;
            DataTable dtbl = this.accData.GetDataOutSrcOrderNotesByNoteID(NoteID).Tables[0];
            if (dtbl.Rows.Count == 0)
            {
                this.NoteCode = string.Empty;
                this.SerialNo = -1;
                this.DateNote = DateTime.MinValue;
                this.CompanyID = -1;
                this.OrderTypeID = -1;
                this.SupplierAddress = string.Empty;
                this.DeliverAddress = string.Empty;
                this.DeliverTypeID = -1;
                this.ExpressRequire = string.Empty;
                this.MoneyTypeID = -1;
                this.SettleTypeID = -1;
                this.PriceTypeID = -1;
                this.InvoiceTypeID = -1;
                this.MakerPsnID = -1;
                this.ConfirmPsnID = -1;
                this.PrintFlag = false;
                this.Memo = string.Empty;
                this.AdvanceAMT = 0;
                this.DeliverAMT = 0;
                this.ReceiptAMT = 0;
                this.CompanyAbbName = string.Empty;
                this.CompanyAllName = string.Empty;
                this.MoneyTypeName = string.Empty;
                this.MoneyTypeCode = string.Empty;
                this.PriceTypeName = string.Empty;
                this.InvoiceTypeName = string.Empty;
                this.SettleTypeName = string.Empty;
                this.DeliverTypeName = string.Empty;
                this.MakerPsn = string.Empty;
                this.ConfirmPsn = string.Empty;
                this.OrderTypeName = string.Empty;
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
            if (drow["SerialNo"] == DBNull.Value)
            {
                this.SerialNo = -1;
            }
            else
            {
                this.SerialNo = (int)drow["SerialNo"];
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
            if (drow["OrderTypeID"] == DBNull.Value)
            {
                this.OrderTypeID = -1;
            }
            else
            {
                this.OrderTypeID = (int)drow["OrderTypeID"];
            }
            if (drow["SupplierAddress"] == DBNull.Value)
            {
                this.SupplierAddress = string.Empty;
            }
            else
            {
                this.SupplierAddress = drow["SupplierAddress"].ToString();
            }
            if (drow["DeliverAddress"] == DBNull.Value)
            {
                this.DeliverAddress = string.Empty;
            }
            else
            {
                this.DeliverAddress = drow["DeliverAddress"].ToString();
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
            if (drow["ConfirmPsnID"] == DBNull.Value)
            {
                this.ConfirmPsnID = -1;
            }
            else
            {
                this.ConfirmPsnID = (int)drow["ConfirmPsnID"];
            }
            if (drow["PrintFlag"] == DBNull.Value)
            {
                this.PrintFlag = false;
            }
            else
            {
                this.PrintFlag = (bool)drow["PrintFlag"];
            }
            if (drow["Memo"] == DBNull.Value)
            {
                this.Memo = string.Empty;
            }
            else
            {
                this.Memo = drow["Memo"].ToString();
            }
            if (drow["AdvanceAMT"] == DBNull.Value)
            {
                this.AdvanceAMT = 0;
            }
            else
            {
                this.AdvanceAMT = (decimal)drow["AdvanceAMT"];
            }
            if (drow["DeliverAMT"] == DBNull.Value)
            {
                this.DeliverAMT = 0;
            }
            else
            {
                this.DeliverAMT = (decimal)drow["DeliverAMT"];
            }
            if (drow["ReceiptAMT"] == DBNull.Value)
            {
                this.ReceiptAMT = 0;
            }
            else
            {
                this.ReceiptAMT = (decimal)drow["ReceiptAMT"];
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
            if (drow["MoneyTypeCode"] == DBNull.Value)
            {
                this.MoneyTypeCode = string.Empty;
            }
            else
            {
                this.MoneyTypeCode = drow["MoneyTypeCode"].ToString();
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
            if (drow["SettleTypeName"] == DBNull.Value)
            {
                this.SettleTypeName = string.Empty;
            }
            else
            {
                this.SettleTypeName = drow["SettleTypeName"].ToString();
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
            if (drow["ConfirmPsn"] == DBNull.Value)
            {
                this.ConfirmPsn = string.Empty;
            }
            else
            {
                this.ConfirmPsn = drow["ConfirmPsn"].ToString();
            }
            if (drow["OrderTypeName"] == DBNull.Value)
            {
                this.OrderTypeName = string.Empty;
            }
            else
            {
                this.OrderTypeName = drow["OrderTypeName"].ToString();
            }
        }
    }
}