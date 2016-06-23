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
    /// 表[SaleReplenishNote]数据实体类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2015-04-15 15:49:54
    ///</时间>  
    public class SaleReplenishNoteEntity
    {
        public SaleReplenishNoteEntity()
        {
            this.accData = new JERPData.Product.SaleReplenishNotes();
        }
        private JERPData.Product.SaleReplenishNotes accData;
        public long NoteID = -1;
        public string NoteCode = string.Empty;
        public int SerialNo = -1;
        public DateTime DateNote = DateTime.MinValue;
        public int CompanyID = -1;
        public int DeliverAddressID = -1;
        public int ExpressCompanyID = -1;
        public string ExpressCode = string.Empty;
        public int DeliverPsnID = -1;
        public int SalePsnID = -1;
        public int MakerPsnID = -1;
        public int PrinterPsnID = -1;
        public string Memo = string.Empty;
        public string CompanyAbbName = string.Empty;
        public string CompanyAllName = string.Empty;
        public string DeliverAddress = string.Empty;
        public string DeliverPsn = string.Empty;
        public string MakerPsn = string.Empty;
        public string SalePsn = string.Empty;
        public string PrintPsn = string.Empty;
        public string ExpressCompany = string.Empty;
        public void LoadData(long NoteID)
        {
            this.NoteID = NoteID;
            DataTable dtbl = this.accData.GetDataSaleReplenishNotesByNoteID(NoteID).Tables[0];
            if (dtbl.Rows.Count == 0)
            {
                this.NoteCode = string.Empty;
                this.SerialNo = -1;
                this.DateNote = DateTime.MinValue;
                this.CompanyID = -1;
                this.DeliverAddressID = -1;
                this.ExpressCompanyID = -1;
                this.ExpressCode = string.Empty;
                this.DeliverPsnID = -1;
                this.SalePsnID = -1;
                this.MakerPsnID = -1;
                this.PrinterPsnID = -1;
                this.Memo = string.Empty;
                this.CompanyAbbName = string.Empty;
                this.CompanyAllName = string.Empty;
                this.DeliverAddress = string.Empty;
                this.DeliverPsn = string.Empty;
                this.MakerPsn = string.Empty;
                this.SalePsn = string.Empty;
                this.PrintPsn = string.Empty;
                this.ExpressCompany = string.Empty;
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
            if (drow["CompanyID"] == DBNull.Value)
            {
                this.CompanyID = -1;
            }
            else
            {
                this.CompanyID = (int)drow["CompanyID"];
            }
            if (drow["DeliverAddressID"] == DBNull.Value)
            {
                this.DeliverAddressID = -1;
            }
            else
            {
                this.DeliverAddressID = (int)drow["DeliverAddressID"];
            }
            if (drow["ExpressCompanyID"] == DBNull.Value)
            {
                this.ExpressCompanyID = -1;
            }
            else
            {
                this.ExpressCompanyID = (int)drow["ExpressCompanyID"];
            }
            if (drow["ExpressCode"] == DBNull.Value)
            {
                this.ExpressCode = string.Empty;
            }
            else
            {
                this.ExpressCode = drow["ExpressCode"].ToString();
            }
            if (drow["DeliverPsnID"] == DBNull.Value)
            {
                this.DeliverPsnID = -1;
            }
            else
            {
                this.DeliverPsnID = (int)drow["DeliverPsnID"];
            }
            if (drow["SalePsnID"] == DBNull.Value)
            {
                this.SalePsnID = -1;
            }
            else
            {
                this.SalePsnID = (int)drow["SalePsnID"];
            }
            if (drow["MakerPsnID"] == DBNull.Value)
            {
                this.MakerPsnID = -1;
            }
            else
            {
                this.MakerPsnID = (int)drow["MakerPsnID"];
            }
            if (drow["PrinterPsnID"] == DBNull.Value)
            {
                this.PrinterPsnID = -1;
            }
            else
            {
                this.PrinterPsnID = (int)drow["PrinterPsnID"];
            }
            if (drow["Memo"] == DBNull.Value)
            {
                this.Memo = string.Empty;
            }
            else
            {
                this.Memo = drow["Memo"].ToString();
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
            if (drow["DeliverAddress"] == DBNull.Value)
            {
                this.DeliverAddress = string.Empty;
            }
            else
            {
                this.DeliverAddress = drow["DeliverAddress"].ToString();
            }
            if (drow["DeliverPsn"] == DBNull.Value)
            {
                this.DeliverPsn = string.Empty;
            }
            else
            {
                this.DeliverPsn = drow["DeliverPsn"].ToString();
            }
            if (drow["MakerPsn"] == DBNull.Value)
            {
                this.MakerPsn = string.Empty;
            }
            else
            {
                this.MakerPsn = drow["MakerPsn"].ToString();
            }
            if (drow["SalePsn"] == DBNull.Value)
            {
                this.SalePsn = string.Empty;
            }
            else
            {
                this.SalePsn = drow["SalePsn"].ToString();
            }
            if (drow["PrintPsn"] == DBNull.Value)
            {
                this.PrintPsn = string.Empty;
            }
            else
            {
                this.PrintPsn = drow["PrintPsn"].ToString();
            }
            if (drow["ExpressCompany"] == DBNull.Value)
            {
                this.ExpressCompany = string.Empty;
            }
            else
            {
                this.ExpressCompany = drow["ExpressCompany"].ToString();
            }
        }
    }
}