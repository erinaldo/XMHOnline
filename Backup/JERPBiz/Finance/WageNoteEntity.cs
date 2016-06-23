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
    /// 表[WageNote]数据实体类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2014-12-21 13:47:31
    ///</时间>  
    public class WageNoteEntity
    {
        public WageNoteEntity()
        {
            this.accData = new JERPData.Finance.WageNotes();
        }
        private JERPData.Finance.WageNotes accData;
        public long NoteID = -1;
        public int Year = -1;
        public int Month = -1;
        public DateTime DateBegin = DateTime.MinValue;
        public DateTime DateEnd = DateTime.MinValue;
        public int MakerPsnID = -1;
        public int ConfirmPsnID = -1;
        public string MakerPsn = string.Empty;
        public string ConfirmPsn = string.Empty;
        public void LoadData(long NoteID)
        {
            this.NoteID = NoteID;
            DataTable dtbl = this.accData.GetDataWageNotesByNoteID(NoteID).Tables[0];
            if (dtbl.Rows.Count == 0)
            {
                this.Year = -1;
                this.Month = -1;
                this.DateBegin = DateTime.MinValue;
                this.DateEnd = DateTime.MinValue;
                this.MakerPsnID = -1;
                this.ConfirmPsnID = -1;
                this.MakerPsn = string.Empty;
                this.ConfirmPsn = string.Empty;
                return;
            }
            DataRow drow = dtbl.Rows[0];
            if (drow["Year"] == DBNull.Value)
            {
                this.Year = -1;
            }
            else
            {
                this.Year = (int)drow["Year"];
            }
            if (drow["Month"] == DBNull.Value)
            {
                this.Month = -1;
            }
            else
            {
                this.Month = (int)drow["Month"];
            }
            if (drow["DateBegin"] == DBNull.Value)
            {
                this.DateBegin = DateTime.MinValue;
            }
            else
            {
                this.DateBegin = (DateTime)drow["DateBegin"];
            }
            if (drow["DateEnd"] == DBNull.Value)
            {
                this.DateEnd = DateTime.MinValue;
            }
            else
            {
                this.DateEnd = (DateTime)drow["DateEnd"];
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
        }
    }
}