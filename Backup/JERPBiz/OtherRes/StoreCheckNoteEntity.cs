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
    /// 表[StoreCheckNotes]数据实体类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2015/12/1 19:20:23
    ///</时间>  
    public class StoreCheckNoteEntity
    {
        public StoreCheckNoteEntity()
        {
            this.accData = new JERPData.OtherRes.StoreCheckNotes();
        }
        private JERPData.OtherRes.StoreCheckNotes accData;
        public long NoteID = -1;
        public int SerialNo = -1;
        public string NoteCode = string.Empty;
        public DateTime DateNote = DateTime.MinValue;
        public int BranchStoreID = -1;
        public int MakerPsnID = -1;
        public string CheckPersons = string.Empty;
        public int ConfirmPsnID = -1;
        public string Memo = string.Empty;
        public string BranchStoreName = string.Empty;
        public string MakerPsn = string.Empty;
        public string ConfirmPsn = string.Empty;
        public void LoadData(long NoteID)
        {
            this.NoteID = NoteID;
            DataTable dtbl = this.accData.GetDataStoreCheckNotesByNoteID(NoteID).Tables[0];
            if (dtbl.Rows.Count == 0)
            {
                this.SerialNo = -1;
                this.NoteCode = string.Empty;
                this.DateNote = DateTime.MinValue;
                this.BranchStoreID = -1;
                this.MakerPsnID = -1;
                this.CheckPersons = string.Empty;
                this.ConfirmPsnID = -1;
                this.Memo = string.Empty;
                this.BranchStoreName = string.Empty;
                this.MakerPsn = string.Empty;
                this.ConfirmPsn = string.Empty;
                return;
            }
            DataRow drow = dtbl.Rows[0];
            if (drow["SerialNo"] == DBNull.Value)
            {
                this.SerialNo = -1;
            }
            else
            {
                this.SerialNo = (int)drow["SerialNo"];
            }
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
            if (drow["BranchStoreID"] == DBNull.Value)
            {
                this.BranchStoreID = -1;
            }
            else
            {
                this.BranchStoreID = (int)drow["BranchStoreID"];
            }
            if (drow["MakerPsnID"] == DBNull.Value)
            {
                this.MakerPsnID = -1;
            }
            else
            {
                this.MakerPsnID = (int)drow["MakerPsnID"];
            }
            if (drow["CheckPersons"] == DBNull.Value)
            {
                this.CheckPersons = string.Empty;
            }
            else
            {
                this.CheckPersons = drow["CheckPersons"].ToString();
            }
            if (drow["ConfirmPsnID"] == DBNull.Value)
            {
                this.ConfirmPsnID = -1;
            }
            else
            {
                this.ConfirmPsnID = (int)drow["ConfirmPsnID"];
            }
            if (drow["Memo"] == DBNull.Value)
            {
                this.Memo = string.Empty;
            }
            else
            {
                this.Memo = drow["Memo"].ToString();
            }
            if (drow["BranchStoreName"] == DBNull.Value)
            {
                this.BranchStoreName = string.Empty;
            }
            else
            {
                this.BranchStoreName = drow["BranchStoreName"].ToString();
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