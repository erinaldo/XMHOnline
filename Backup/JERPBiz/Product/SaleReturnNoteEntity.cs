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
    /// 表[SaleReturnNotes]数据实体类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2016/3/8 21:54:04
    ///</时间>  
    public class SaleReturnNoteEntity
    {
        public SaleReturnNoteEntity()
        {
            this.accData = new JERPData.Product.SaleReturnNotes();
        }
        private JERPData.Product.SaleReturnNotes accData;
        public long NoteID = -1;
        public string NoteCode = string.Empty;
        public DateTime DateNote = DateTime.MinValue;
        public int CompanyID = -1;
        public int MoneyTypeID = -1;
        public int ReturnHandleTypeID = -1;
        public bool CashSettleFlag = false;
        public decimal TotalAMT = 0;
        public int QCPsnID = -1;
        public int MakerPsnID = -1;
        public int PrinterPsnID = -1;
        public int FinancePsnID = -1;
        public string Memo = string.Empty;
        public string CompanyAbbName = string.Empty;
        public string MoneyTypeName = string.Empty;
        public string ReturnHandleTypeName = string.Empty;
        public string QCPsn = string.Empty;
        public string MakerPsn = string.Empty;
        public string PrinterPsn = string.Empty;
        public string FinancePsn = string.Empty;
        public void LoadData(long NoteID)
        {
            this.NoteID = NoteID;
            DataTable dtbl = this.accData.GetDataSaleReturnNotesByNoteID(NoteID).Tables[0];
            if (dtbl.Rows.Count == 0)
            {
                this.NoteCode = string.Empty;
                this.DateNote = DateTime.MinValue;
                this.CompanyID = -1;
                this.MoneyTypeID = -1;
                this.ReturnHandleTypeID = -1;
                this.CashSettleFlag = false;
                this.TotalAMT = 0;
                this.QCPsnID = -1;
                this.MakerPsnID = -1;
                this.PrinterPsnID = -1;
                this.FinancePsnID = -1;
                this.Memo = string.Empty;
                this.CompanyAbbName = string.Empty;
                this.MoneyTypeName = string.Empty;
                this.ReturnHandleTypeName = string.Empty;
                this.QCPsn = string.Empty;
                this.MakerPsn = string.Empty;
                this.PrinterPsn = string.Empty;
                this.FinancePsn = string.Empty;
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
            if (drow["ReturnHandleTypeID"] == DBNull.Value)
            {
                this.ReturnHandleTypeID = -1;
            }
            else
            {
                this.ReturnHandleTypeID = (int)drow["ReturnHandleTypeID"];
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
            if (drow["QCPsnID"] == DBNull.Value)
            {
                this.QCPsnID = -1;
            }
            else
            {
                this.QCPsnID = (int)drow["QCPsnID"];
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
            if (drow["FinancePsnID"] == DBNull.Value)
            {
                this.FinancePsnID = -1;
            }
            else
            {
                this.FinancePsnID = (int)drow["FinancePsnID"];
            }
            if (drow["Memo"] == DBNull.Value)
            {
                this.Memo = string.Empty;
            }
            else
            {
                this.Memo = drow["Memo"].ToString();
            }
            if (drow["CompanyAbbName"] == DBNull.Value)
            {
                this.CompanyAbbName = string.Empty;
            }
            else
            {
                this.CompanyAbbName = drow["CompanyAbbName"].ToString();
            }
            if (drow["MoneyTypeName"] == DBNull.Value)
            {
                this.MoneyTypeName = string.Empty;
            }
            else
            {
                this.MoneyTypeName = drow["MoneyTypeName"].ToString();
            }
            if (drow["ReturnHandleTypeName"] == DBNull.Value)
            {
                this.ReturnHandleTypeName = string.Empty;
            }
            else
            {
                this.ReturnHandleTypeName = drow["ReturnHandleTypeName"].ToString();
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
            if (drow["FinancePsn"] == DBNull.Value)
            {
                this.FinancePsn = string.Empty;
            }
            else
            {
                this.FinancePsn = drow["FinancePsn"].ToString();
            }
        }
    }
}