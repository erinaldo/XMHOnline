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
namespace JERPBiz.Tool
{
    /// <描述>
    /// 表[BuyFineAMTNote]数据实体类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2013-12-27 23:20:13
    ///</时间>  
    public class BuyFineAMTNoteEntity
    {
        public BuyFineAMTNoteEntity()
        {
            this.accData = new JERPData.Tool.BuyFineAMTNotes();
        }
        private JERPData.Tool.BuyFineAMTNotes accData;
        public long NoteID = -1;
        public int SerialNo = -1;
        public string NoteCode = string.Empty;
        public DateTime DateNote = DateTime.MinValue;
        public int CompanyID = -1;
        public int MoneyTypeID = -1;
        public decimal Amount = -1;
        public string Summary = string.Empty;
        public int MakerPsnID = -1;
        public long ReconciliationID = -1;
        public string CompanyAbbName = string.Empty;
        public string MoneyTypeName = string.Empty;
        public string MakerPsn = string.Empty;
        public void LoadData(long NoteID)
        {
            this.NoteID = NoteID;
            DataTable dtbl = this.accData.GetDataBuyFineAMTNotesByNoteID(NoteID).Tables[0];
            if (dtbl.Rows.Count == 0)
            {
                this.SerialNo = -1;
                this.NoteCode = string.Empty;
                this.DateNote = DateTime.MinValue;
                this.CompanyID = -1;
                this.MoneyTypeID = -1;
                this.Amount = -1;
                this.Summary = string.Empty;
                this.MakerPsnID = -1;
                this.ReconciliationID = -1;
                this.CompanyAbbName = string.Empty;
                this.MoneyTypeName = string.Empty;
                this.MakerPsn = string.Empty;
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
                this.Amount = -1;
            }
            else
            {
                this.Amount = (decimal)drow["Amount"];
            }
            if (drow["Summary"] == DBNull.Value)
            {
                this.Summary = string.Empty;
            }
            else
            {
                this.Summary = drow["Summary"].ToString();
            }
            if (drow["MakerPsnID"] == DBNull.Value)
            {
                this.MakerPsnID = -1;
            }
            else
            {
                this.MakerPsnID = (int)drow["MakerPsnID"];
            }
            if (drow["ReconciliationID"] == DBNull.Value)
            {
                this.ReconciliationID = -1;
            }
            else
            {
                this.ReconciliationID = (long)drow["ReconciliationID"];
            }
            if (drow["CompanyAbbName"] == DBNull.Value)
            {
                this.CompanyAbbName = string.Empty;
            }
            else
            {
                this.CompanyAbbName = drow["CompanyAbbName"].ToString();
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
        }
    }
}