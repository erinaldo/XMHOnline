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
    /// 表[RepairDeliverNotes]数据实体类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2016/5/6 8:47:09
    ///</时间>  
    public class RepairDeliverNoteEntity
    {
        public RepairDeliverNoteEntity()
        {
            this.accData = new JERPData.Product.RepairDeliverNotes();
        }
        private JERPData.Product.RepairDeliverNotes accData;
        public long NoteID = -1;
        public int SerialNo = -1;
        public string NoteCode = string.Empty;
        public DateTime DateNote = DateTime.MinValue;
        public int CompanyID = -1;
        public int DeliverAddressID = -1;
        public int FinanceAddressID = -1;
        public int MoneyTypeID = -1;
        public int SettleTypeID = -1;
        public int PriceTypeID = -1;
        public int DeliverTypeID = -1;
        public string ExpressRequire = string.Empty;
        public int ExpressCompanyID = -1;
        public string ExpressCode = string.Empty;
        public int DeliverPsnID = -1;
        public bool CashSettleFlag = false;
        public decimal TotalAMT = 0;
        public int MakerPsnID = -1;
        public int ConfirmPsnID = -1;
        public string Memo = string.Empty;
        public long ReconciliationID = -1;
        public string CompanyCode = string.Empty;
        public string CompanyAbbName = string.Empty;
        public string CompanyAllName = string.Empty;
        public string DeliverAddress = string.Empty;
        public string FinanceAddress = string.Empty;
        public string MoneyTypeName = string.Empty;
        public string SettleTypeName = string.Empty;
        public string PriceTypeName = string.Empty;
        public string DeliverTypeName = string.Empty;
        public string DeliverPsn = string.Empty;
        public string MakerPsn = string.Empty;
        public string ConfirmPsn = string.Empty;
        public string ExpressCompanyName = string.Empty;
        public void LoadData(long NoteID)
        {
            this.NoteID = NoteID;
            DataTable dtbl = this.accData.GetDataRepairDeliverNotesByNoteID(NoteID).Tables[0];
            if (dtbl.Rows.Count == 0)
            {
                this.SerialNo = -1;
                this.NoteCode = string.Empty;
                this.DateNote = DateTime.MinValue;
                this.CompanyID = -1;
                this.DeliverAddressID = -1;
                this.FinanceAddressID = -1;
                this.MoneyTypeID = -1;
                this.SettleTypeID = -1;
                this.PriceTypeID = -1;
                this.DeliverTypeID = -1;
                this.ExpressRequire = string.Empty;
                this.ExpressCompanyID = -1;
                this.ExpressCode = string.Empty;
                this.DeliverPsnID = -1;
                this.CashSettleFlag = false;
                this.TotalAMT = 0;
                this.MakerPsnID = -1;
                this.ConfirmPsnID = -1;
                this.Memo = string.Empty;
                this.ReconciliationID = -1;
                this.CompanyCode = string.Empty;
                this.CompanyAbbName = string.Empty;
                this.CompanyAllName = string.Empty;
                this.DeliverAddress = string.Empty;
                this.FinanceAddress = string.Empty;
                this.MoneyTypeName = string.Empty;
                this.SettleTypeName = string.Empty;
                this.PriceTypeName = string.Empty;
                this.DeliverTypeName = string.Empty;
                this.DeliverPsn = string.Empty;
                this.MakerPsn = string.Empty;
                this.ConfirmPsn = string.Empty;
                this.ExpressCompanyName = string.Empty;
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
            if (drow["DeliverAddressID"] == DBNull.Value)
            {
                this.DeliverAddressID = -1;
            }
            else
            {
                this.DeliverAddressID = (int)drow["DeliverAddressID"];
            }
            if (drow["FinanceAddressID"] == DBNull.Value)
            {
                this.FinanceAddressID = -1;
            }
            else
            {
                this.FinanceAddressID = (int)drow["FinanceAddressID"];
            }
            if (drow["MoneyTypeID"] == DBNull.Value)
            {
                this.MoneyTypeID = -1;
            }
            else
            {
                this.MoneyTypeID = (int)drow["MoneyTypeID"];
            }
            if (drow["SettleTypeID"] == DBNull.Value)
            {
                this.SettleTypeID = -1;
            }
            else
            {
                this.SettleTypeID = (int)drow["SettleTypeID"];
            }
            if (drow["PriceTypeID"] == DBNull.Value)
            {
                this.PriceTypeID = -1;
            }
            else
            {
                this.PriceTypeID = (int)drow["PriceTypeID"];
            }
            if (drow["DeliverTypeID"] == DBNull.Value)
            {
                this.DeliverTypeID = -1;
            }
            else
            {
                this.DeliverTypeID = (int)drow["DeliverTypeID"];
            }
            if (drow["ExpressRequire"] == DBNull.Value)
            {
                this.ExpressRequire = string.Empty;
            }
            else
            {
                this.ExpressRequire = drow["ExpressRequire"].ToString();
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
            if (drow["CashSettleFlag"] == DBNull.Value)
            {
                this.CashSettleFlag = false;
            }
            else
            {
                this.CashSettleFlag = (bool)drow["CashSettleFlag"];
            }
            if (drow["TotalAMT"] == DBNull.Value)
            {
                this.TotalAMT = 0;
            }
            else
            {
                this.TotalAMT = (decimal)drow["TotalAMT"];
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
            if (drow["Memo"] == DBNull.Value)
            {
                this.Memo = string.Empty;
            }
            else
            {
                this.Memo = drow["Memo"].ToString();
            }
            if (drow["ReconciliationID"] == DBNull.Value)
            {
                this.ReconciliationID = -1;
            }
            else
            {
                this.ReconciliationID = (long)drow["ReconciliationID"];
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
            if (drow["DeliverAddress"] == DBNull.Value)
            {
                this.DeliverAddress = string.Empty;
            }
            else
            {
                this.DeliverAddress = drow["DeliverAddress"].ToString();
            }
            if (drow["FinanceAddress"] == DBNull.Value)
            {
                this.FinanceAddress = string.Empty;
            }
            else
            {
                this.FinanceAddress = drow["FinanceAddress"].ToString();
            }
            if (drow["MoneyTypeName"] == DBNull.Value)
            {
                this.MoneyTypeName = string.Empty;
            }
            else
            {
                this.MoneyTypeName = drow["MoneyTypeName"].ToString();
            }
            if (drow["SettleTypeName"] == DBNull.Value)
            {
                this.SettleTypeName = string.Empty;
            }
            else
            {
                this.SettleTypeName = drow["SettleTypeName"].ToString();
            }
            if (drow["PriceTypeName"] == DBNull.Value)
            {
                this.PriceTypeName = string.Empty;
            }
            else
            {
                this.PriceTypeName = drow["PriceTypeName"].ToString();
            }
            if (drow["DeliverTypeName"] == DBNull.Value)
            {
                this.DeliverTypeName = string.Empty;
            }
            else
            {
                this.DeliverTypeName = drow["DeliverTypeName"].ToString();
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
            if (drow["ConfirmPsn"] == DBNull.Value)
            {
                this.ConfirmPsn = string.Empty;
            }
            else
            {
                this.ConfirmPsn = drow["ConfirmPsn"].ToString();
            }
            if (drow["ExpressCompanyName"] == DBNull.Value)
            {
                this.ExpressCompanyName = string.Empty;
            }
            else
            {
                this.ExpressCompanyName = drow["ExpressCompanyName"].ToString();
            }
        }
    }
}