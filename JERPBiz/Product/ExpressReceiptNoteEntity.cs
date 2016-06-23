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
    /// 表[ExpressReceiptNotes]数据实体类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2016/4/23 13:54:54
    ///</时间>  
    public class ExpressReceiptNoteEntity
    {
        public ExpressReceiptNoteEntity()
        {
            this.accData = new JERPData.Product.ExpressReceiptNotes();
        }
        private JERPData.Product.ExpressReceiptNotes accData;
        public long NoteID = -1;
        public string NoteCode = string.Empty;
        public int SerialNo = -1;
        public DateTime DateNote = DateTime.MinValue;
        public long ReconciliationID = -1;
        public string ReconciliationCode = string.Empty;
        public int CompanyID = -1;
        public int MoneyTypeID = -1;
        public decimal Amount = 0;
        public int MakerPsnID = -1;
        public int BankID = -1;
        public string CompanyName = string.Empty;
        public string MoneyTypeName = string.Empty;
        public string MakerPsn = string.Empty;
        public string BankName = string.Empty;
        public string BankCode = string.Empty;
        public void LoadData(long NoteID)
        {
            this.NoteID = NoteID;
            DataTable dtbl = this.accData.GetDataExpressReceiptNotesByNoteID(NoteID).Tables[0];
            if (dtbl.Rows.Count == 0)
            {
                this.NoteCode = string.Empty;
                this.SerialNo = -1;
                this.DateNote = DateTime.MinValue;
                this.ReconciliationID = -1;
                this.ReconciliationCode = string.Empty;
                this.CompanyID = -1;
                this.MoneyTypeID = -1;
                this.Amount = 0;
                this.MakerPsnID = -1;
                this.BankID = -1;
                this.CompanyName = string.Empty;
                this.MoneyTypeName = string.Empty;
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
            if (drow["DateNote"] == DBNull.Value)
            {
                this.DateNote = DateTime.MinValue;
            }
            else
            {
                this.DateNote = (DateTime)drow["DateNote"];
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
            if (drow["Amount"] == DBNull.Value)
            {
                this.Amount = 0;
            }
            else
            {
                this.Amount = (decimal)drow["Amount"];
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
            if (drow["CompanyName"] == DBNull.Value)
            {
                this.CompanyName = string.Empty;
            }
            else
            {
                this.CompanyName = drow["CompanyName"].ToString();
            }
            if (drow["MoneyTypeName"] == DBNull.Value)
            {
                this.MoneyTypeName = string.Empty;
            }
            else
            {
                this.MoneyTypeName = drow["MoneyTypeName"].ToString();
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