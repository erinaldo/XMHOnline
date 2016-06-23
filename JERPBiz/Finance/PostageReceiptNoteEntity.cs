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
namespace JERPBiz.Finance
{
    /// <描述>
    /// 表[PostageReceiptNote]数据实体类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2015-06-04 12:05:05
    ///</时间>  
    public class PostageReceiptNoteEntity
    {
        public PostageReceiptNoteEntity()
        {
            this.accData = new JERPData.Finance.PostageReceiptNotes();
        }
        private JERPData.Finance.PostageReceiptNotes accData;
        public long NoteID = -1;
        public string NoteCode = string.Empty;
        public DateTime DateNote = DateTime.MinValue;
        public long ReconciliationID = -1;
        public string ReconciliationCode = string.Empty;
        public int CompanyID = -1;
        public decimal Amount = -1;
        public int MakerPsnID = -1;
        public long BankID = -1;
        public string CompanyName = string.Empty;
        public string MakerPsn = string.Empty;
        public string BankName = string.Empty;
        public string BankCode = string.Empty;
        public void LoadData(long NoteID)
        {
            this.NoteID = NoteID;
            DataTable dtbl = this.accData.GetDataPostageReceiptNotesByNoteID(NoteID).Tables[0];
            if (dtbl.Rows.Count == 0)
            {
                this.NoteCode = string.Empty;
                this.DateNote = DateTime.MinValue;
                this.ReconciliationID = -1;
                this.ReconciliationCode = string.Empty;
                this.CompanyID = -1;
                this.Amount = -1;
                this.MakerPsnID = -1;
                this.BankID = -1;
                this.CompanyName = string.Empty;
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
            if (drow["Amount"] == DBNull.Value)
            {
                this.Amount = -1;
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
                this.BankID = (long)drow["BankID"];
            }
            if (drow["CompanyName"] == DBNull.Value)
            {
                this.CompanyName = string.Empty;
            }
            else
            {
                this.CompanyName = drow["CompanyName"].ToString();
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