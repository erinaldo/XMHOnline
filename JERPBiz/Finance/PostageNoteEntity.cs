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
    /// 表[PostageNote]数据实体类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2014/1/19 20:48:07
    ///</时间>  
    public class PostageNoteEntity
    {
        public PostageNoteEntity()
        {
            this.accData = new JERPData.Finance.PostageNotes();
        }
        private JERPData.Finance.PostageNotes accData;
        public long NoteID = -1;
        public DateTime DateNote = DateTime.MinValue;
        public string NoteCode = string.Empty;
        public int CompanyID = -1;
        public decimal Amount = -1;
        public long ReconciliationID = -1;
        public int MakerPsnID = -1;
        public string Memo = string.Empty;
        public string CompanyName = string.Empty;
        public string MakerPsn = string.Empty;
        public void LoadData(long NoteID)
        {
            this.NoteID = NoteID;
            DataTable dtbl = this.accData.GetDataPostageNotesByNoteID(NoteID).Tables[0];
            if (dtbl.Rows.Count == 0)
            {
                this.DateNote = DateTime.MinValue;
                this.NoteCode = string.Empty;
                this.CompanyID = -1;
                this.Amount = -1;
                this.ReconciliationID = -1;
                this.MakerPsnID = -1;
                this.Memo = string.Empty;
                this.CompanyName = string.Empty;
                this.MakerPsn = string.Empty;
                return;
            }
            DataRow drow = dtbl.Rows[0];
            if (drow["DateNote"] == DBNull.Value)
            {
                this.DateNote = DateTime.MinValue;
            }
            else
            {
                this.DateNote = (DateTime)drow["DateNote"];
            }
            if (drow["NoteCode"] == DBNull.Value)
            {
                this.NoteCode = string.Empty;
            }
            else
            {
                this.NoteCode = drow["NoteCode"].ToString();
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
            if (drow["ReconciliationID"] == DBNull.Value)
            {
                this.ReconciliationID = -1;
            }
            else
            {
                this.ReconciliationID = (long)drow["ReconciliationID"];
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
        }
    }
}