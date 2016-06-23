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
namespace JERPBiz.Material
{
    /// <描述>
    /// 表[BuyOrderApplyNotes]数据实体类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2016/6/6 22:01:16
    ///</时间>  
    public class BuyOrderApplyNoteEntity
    {
        public BuyOrderApplyNoteEntity()
        {
            this.accData = new JERPData.Material.BuyOrderApplyNotes();
        }
        private JERPData.Material.BuyOrderApplyNotes accData;
        public long NoteID = -1;
        public DateTime DateNote = DateTime.MinValue;
        public int DeptID = -1;
        public string Memo = string.Empty;
        public int MakerPsnID = -1;
        public int ConfirmPsnID = -1;
        public string DeptName = string.Empty;
        public string MakerPsn = string.Empty;
        public string ConfirmPsn = string.Empty;
        public void LoadData(long NoteID)
        {
            this.NoteID = NoteID;
            DataTable dtbl = this.accData.GetDataBuyOrderApplyNotesByNoteID(NoteID).Tables[0];
            if (dtbl.Rows.Count == 0)
            {
                this.DateNote = DateTime.MinValue;
                this.DeptID = -1;
                this.Memo = string.Empty;
                this.MakerPsnID = -1;
                this.ConfirmPsnID = -1;
                this.DeptName = string.Empty;
                this.MakerPsn = string.Empty;
                this.ConfirmPsn = string.Empty;
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
            if (drow["DeptID"] == DBNull.Value)
            {
                this.DeptID = -1;
            }
            else
            {
                this.DeptID = (int)drow["DeptID"];
            }
            if (drow["Memo"] == DBNull.Value)
            {
                this.Memo = string.Empty;
            }
            else
            {
                this.Memo = drow["Memo"].ToString();
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
            if (drow["DeptName"] == DBNull.Value)
            {
                this.DeptName = string.Empty;
            }
            else
            {
                this.DeptName = drow["DeptName"].ToString();
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