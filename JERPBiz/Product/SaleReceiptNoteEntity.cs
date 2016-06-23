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
    /// 表[SaleReceiptNotes]数据实体类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2016/4/22 13:04:52
    ///</时间>  
    public class SaleReceiptNoteEntity
    {
        public SaleReceiptNoteEntity()
        {
            this.accData = new JERPData.Product.SaleReceiptNotes();
        }
        private JERPData.Product.SaleReceiptNotes accData;
        public long NoteID = -1;
        public string NoteCode = string.Empty;
        public int SerialNo = -1;
        public int ReconciliationSerialNo = -1;
        public DateTime DateNote = DateTime.MinValue;
        public int CompanyID = -1;
        public int FinanceAddressID = -1;
        public long ReconciliationID = -1;
        public string ReconciliationCode = string.Empty;
        public int MoneyTypeID = -1;
        public decimal TotalAMT = 0;
        public decimal AdvanceAMT = 0;
        public decimal Amount = 0;
        public int ExpressCompanyID = -1;
        public int MakerPsnID = -1;
        public int BankID = -1;
        public long ExpressReconciliationID = -1;
        public string CompanyAbbName = string.Empty;
        public string FinanceAddress = string.Empty;
        public string MoneyTypeName = string.Empty;
        public string ExpressCompanyName = string.Empty;
        public string MakerPsn = string.Empty;
        public string BankName = string.Empty;
        public string BankCode = string.Empty;
        public void LoadData(long NoteID)
        {
            this.NoteID = NoteID;
            DataTable dtbl = this.accData.GetDataSaleReceiptNotesByNoteID(NoteID).Tables[0];
            if (dtbl.Rows.Count == 0)
            {
                this.NoteCode = string.Empty;
                this.SerialNo = -1;
                this.ReconciliationSerialNo = -1;
                this.DateNote = DateTime.MinValue;
                this.CompanyID = -1;
                this.FinanceAddressID = -1;
                this.ReconciliationID = -1;
                this.ReconciliationCode = string.Empty;
                this.MoneyTypeID = -1;
                this.TotalAMT = 0;
                this.AdvanceAMT = 0;
                this.Amount = 0;
                this.ExpressCompanyID = -1;
                this.MakerPsnID = -1;
                this.BankID = -1;
                this.ExpressReconciliationID = -1;
                this.CompanyAbbName = string.Empty;
                this.FinanceAddress = string.Empty;
                this.MoneyTypeName = string.Empty;
                this.ExpressCompanyName = string.Empty;
                this.MakerPsn = string.Empty;
                this.BankName = string.Empty;
                this.BankCode = string.Empty;
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
            if (drow["ReconciliationSerialNo"] == DBNull.Value)
            {
                this.ReconciliationSerialNo = -1;
            }
            else
            {
                this.ReconciliationSerialNo = (int)drow["ReconciliationSerialNo"];
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
            if (drow["FinanceAddressID"] == DBNull.Value)
            {
                this.FinanceAddressID = -1;
            }
            else
            {
                this.FinanceAddressID = (int)drow["FinanceAddressID"];
            }
            if (drow["ReconciliationID"] == DBNull.Value)
            {
                this.ReconciliationID = -1;
            }
            else
            {
                this.ReconciliationID = (long)drow["ReconciliationID"];
            }
            if (drow["ReconciliationCode"] == DBNull.Value)
            {
                this.ReconciliationCode = string.Empty;
            }
            else
            {
                this.ReconciliationCode = drow["ReconciliationCode"].ToString();
            }
            if (drow["MoneyTypeID"] == DBNull.Value)
            {
                this.MoneyTypeID = -1;
            }
            else
            {
                this.MoneyTypeID = (int)drow["MoneyTypeID"];
            }
            if (drow["TotalAMT"] == DBNull.Value)
            {
                this.TotalAMT = 0;
            }
            else
            {
                this.TotalAMT = (decimal)drow["TotalAMT"];
            }
            if (drow["AdvanceAMT"] == DBNull.Value)
            {
                this.AdvanceAMT = 0;
            }
            else
            {
                this.AdvanceAMT = (decimal)drow["AdvanceAMT"];
            }
            if (drow["Amount"] == DBNull.Value)
            {
                this.Amount = 0;
            }
            else
            {
                this.Amount = (decimal)drow["Amount"];
            }
            if (drow["ExpressCompanyID"] == DBNull.Value)
            {
                this.ExpressCompanyID = -1;
            }
            else
            {
                this.ExpressCompanyID = (int)drow["ExpressCompanyID"];
            }
            if (drow["MakerPsnID"] == DBNull.Value)
            {
                this.MakerPsnID = -1;
            }
            else
            {
                this.MakerPsnID = (int)drow["MakerPsnID"];
            }
            if (drow["BankID"] == DBNull.Value)
            {
                this.BankID = -1;
            }
            else
            {
                this.BankID = (int)drow["BankID"];
            }
            if (drow["ExpressReconciliationID"] == DBNull.Value)
            {
                this.ExpressReconciliationID = -1;
            }
            else
            {
                this.ExpressReconciliationID = (long)drow["ExpressReconciliationID"];
            }
            if (drow["CompanyAbbName"] == DBNull.Value)
            {
                this.CompanyAbbName = string.Empty;
            }
            else
            {
                this.CompanyAbbName = drow["CompanyAbbName"].ToString();
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
            if (drow["ExpressCompanyName"] == DBNull.Value)
            {
                this.ExpressCompanyName = string.Empty;
            }
            else
            {
                this.ExpressCompanyName = drow["ExpressCompanyName"].ToString();
            }
            if (drow["MakerPsn"] == DBNull.Value)
            {
                this.MakerPsn = string.Empty;
            }
            else
            {
                this.MakerPsn = drow["MakerPsn"].ToString();
            }
            if (drow["BankName"] == DBNull.Value)
            {
                this.BankName = string.Empty;
            }
            else
            {
                this.BankName = drow["BankName"].ToString();
            }
            if (drow["BankCode"] == DBNull.Value)
            {
                this.BankCode = string.Empty;
            }
            else
            {
                this.BankCode = drow["BankCode"].ToString();
            }
        }
    }
}