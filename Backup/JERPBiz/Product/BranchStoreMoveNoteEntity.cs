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
    /// 表[BranchStoreMoveNote]数据实体类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2013-02-15 16:13:18
    ///</时间>  
    public class BranchStoreMoveNoteEntity
    {
        public BranchStoreMoveNoteEntity()
        {
            this.accData = new JERPData.Product.BranchStoreMoveNotes();
        }
        private JERPData.Product.BranchStoreMoveNotes accData;
        public long NoteID = -1;
        public string NoteCode = string.Empty;
        public int SerialNo = -1;
        public DateTime DateNote = DateTime.MinValue;
        public int OutBranchStoreID = -1;
        public int IntoBranchStoreID = -1;
        public int MakerPsnID = -1;
        public string Memo = string.Empty;
        public string OutBranchStoreName = string.Empty;
        public string IntoBranchStoreName = string.Empty;
        public string MakerPsn = string.Empty;
        public void LoadData(long NoteID)
        {
            this.NoteID = NoteID;
            DataTable dtbl = this.accData.GetDataBranchStoreMoveNotesByNoteID(NoteID).Tables[0];
            if (dtbl.Rows.Count == 0)
            {
                this.NoteCode = string.Empty;
                this.SerialNo = -1;
                this.DateNote = DateTime.MinValue;
                this.OutBranchStoreID = -1;
                this.IntoBranchStoreID = -1;
                this.MakerPsnID = -1;
                this.Memo = string.Empty;
                this.OutBranchStoreName = string.Empty;
                this.IntoBranchStoreName = string.Empty;
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
            if (drow["OutBranchStoreID"] == DBNull.Value)
            {
                this.OutBranchStoreID = -1;
            }
            else
            {
                this.OutBranchStoreID = (int)drow["OutBranchStoreID"];
            }
            if (drow["IntoBranchStoreID"] == DBNull.Value)
            {
                this.IntoBranchStoreID = -1;
            }
            else
            {
                this.IntoBranchStoreID = (int)drow["IntoBranchStoreID"];
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
            if (drow["OutBranchStoreName"] == DBNull.Value)
            {
                this.OutBranchStoreName = string.Empty;
            }
            else
            {
                this.OutBranchStoreName = drow["OutBranchStoreName"].ToString();
            }
            if (drow["IntoBranchStoreName"] == DBNull.Value)
            {
                this.IntoBranchStoreName = string.Empty;
            }
            else
            {
                this.IntoBranchStoreName = drow["IntoBranchStoreName"].ToString();
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