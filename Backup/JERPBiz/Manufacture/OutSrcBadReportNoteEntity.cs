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
    /// 表[OutSrcBadReportNote]数据实体类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2014/4/23 10:29:55
    ///</时间>  
    public class OutSrcBadReportNoteEntity
    {
        public OutSrcBadReportNoteEntity()
        {
            this.accData = new JERPData.Manufacture.OutSrcBadReportNotes();
        }
        private JERPData.Manufacture.OutSrcBadReportNotes accData;
        public long NoteID = -1;
        public DateTime DateNote = DateTime.MinValue;
        public string NoteCode = string.Empty;
        public int CompanyID = -1;
        public int ProcessTypeID = -1;
        public string QC = string.Empty;
        public int MakerPsnID = -1;
        public string Memo = string.Empty;
        public string MakerPsn = string.Empty;
        public string ProcessTypeName = string.Empty;
        public string CompanyAbbName = string.Empty;
        public void LoadData(long NoteID)
        {
            this.NoteID = NoteID;
            DataTable dtbl = this.accData.GetDataOutSrcBadReportNotesByNoteID(NoteID).Tables[0];
            if (dtbl.Rows.Count == 0)
            {
                this.DateNote = DateTime.MinValue;
                this.NoteCode = string.Empty;
                this.CompanyID = -1;
                this.ProcessTypeID = -1;
                this.QC = string.Empty;
                this.MakerPsnID = -1;
                this.Memo = string.Empty;
                this.MakerPsn = string.Empty;
                this.ProcessTypeName = string.Empty;
                this.CompanyAbbName = string.Empty;
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
            if (drow["ProcessTypeID"] == DBNull.Value)
            {
                this.ProcessTypeID = -1;
            }
            else
            {
                this.ProcessTypeID = (int)drow["ProcessTypeID"];
            }
            if (drow["QC"] == DBNull.Value)
            {
                this.QC = string.Empty;
            }
            else
            {
                this.QC = drow["QC"].ToString();
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
            if (drow["MakerPsn"] == DBNull.Value)
            {
                this.MakerPsn = string.Empty;
            }
            else
            {
                this.MakerPsn = drow["MakerPsn"].ToString();
            }
            if (drow["ProcessTypeName"] == DBNull.Value)
            {
                this.ProcessTypeName = string.Empty;
            }
            else
            {
                this.ProcessTypeName = drow["ProcessTypeName"].ToString();
            }
            if (drow["CompanyAbbName"] == DBNull.Value)
            {
                this.CompanyAbbName = string.Empty;
            }
            else
            {
                this.CompanyAbbName = drow["CompanyAbbName"].ToString();
            }
        }
    }
}