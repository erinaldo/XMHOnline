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
namespace JERPBiz.OtherRes
{
    /// <描述>
    /// 表[BuyReplenishNote]数据实体类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2014/4/3 16:27:42
    ///</时间>  
    public class BuyReplenishNoteEntity
    {
        public BuyReplenishNoteEntity()
        {
            this.accData = new JERPData.OtherRes.BuyReplenishNotes();
        }
        private JERPData.OtherRes.BuyReplenishNotes accData;
        public long NoteID = -1;
        public string NoteCode = string.Empty;
        public DateTime DateNote = DateTime.MinValue;
        public int CompanyID = -1;
        public int QCPsnID = -1;
        public int MakerPsnID = -1;
        public string Memo = string.Empty;
        public string CompanyCode = string.Empty;
        public string CompanyAbbName = string.Empty;
        public string CompanyAllName = string.Empty;
        public string QCPsn = string.Empty;
        public string MakerPsn = string.Empty;
        public void LoadData(long NoteID)
        {
            this.NoteID = NoteID;
            DataTable dtbl = this.accData.GetDataBuyReplenishNotesByNoteID(NoteID).Tables[0];
            if (dtbl.Rows.Count == 0)
            {
                this.NoteCode = string.Empty;
                this.DateNote = DateTime.MinValue;
                this.CompanyID = -1;
                this.QCPsnID = -1;
                this.MakerPsnID = -1;
                this.Memo = string.Empty;
                this.CompanyCode = string.Empty;
                this.CompanyAbbName = string.Empty;
                this.CompanyAllName = string.Empty;
                this.QCPsn = string.Empty;
                this.MakerPsn = string.Empty;
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
        }
    }
}