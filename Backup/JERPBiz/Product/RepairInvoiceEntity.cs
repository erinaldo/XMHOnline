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
    /// 表[RepairInvoices]数据实体类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2015/7/21 21:12:51
    ///</时间>  
    public class RepairInvoiceEntity
    {
        public RepairInvoiceEntity()
        {
            this.accData = new JERPData.Product.RepairInvoices();
        }
        private JERPData.Product.RepairInvoices accData;
        public long InvoiceID = -1;
        public string InvoiceCode = string.Empty;
        public string InvoiceName = string.Empty;
        public int SerialNo = -1;
        public int Year = -1;
        public int Month = -1;
        public DateTime DateNote = DateTime.MinValue;
        public int CompanyID = -1;
        public int FinanceAddressID = -1;
        public int MoneyTypeID = -1;
        public int InvoiceTypeID = -1;
        public decimal TotalAMT = 0;
        public decimal TaxAMT = 0;
        public int MakerPsnID = -1;
        public int ConfirmPsnID = -1;
        public string CompanyAbbName = string.Empty;
        public string CompanyAllName = string.Empty;
        public string FinanceAddress = string.Empty;
        public string MoneyTypeName = string.Empty;
        public string InvoiceTypeName = string.Empty;
        public string MakerPsn = string.Empty;
        public string ConfirmPsn = string.Empty;
        public void LoadData(long InvoiceID)
        {
            this.InvoiceID = InvoiceID;
            DataTable dtbl = this.accData.GetDataRepairInvoicesByInvoiceID(InvoiceID).Tables[0];
            if (dtbl.Rows.Count == 0)
            {
                this.InvoiceCode = string.Empty;
                this.InvoiceName = string.Empty;
                this.SerialNo = -1;
                this.Year = -1;
                this.Month = -1;
                this.DateNote = DateTime.MinValue;
                this.CompanyID = -1;
                this.FinanceAddressID = -1;
                this.MoneyTypeID = -1;
                this.InvoiceTypeID = -1;
                this.TotalAMT = 0;
                this.TaxAMT = 0;
                this.MakerPsnID = -1;
                this.ConfirmPsnID = -1;
                this.CompanyAbbName = string.Empty;
                this.CompanyAllName = string.Empty;
                this.FinanceAddress = string.Empty;
                this.MoneyTypeName = string.Empty;
                this.InvoiceTypeName = string.Empty;
                this.MakerPsn = string.Empty;
                this.ConfirmPsn = string.Empty;
                return;
            }
            DataRow drow = dtbl.Rows[0];
            if (drow["InvoiceCode"] == DBNull.Value)
            {
                this.InvoiceCode = string.Empty;
            }
            else
            {
                this.InvoiceCode = drow["InvoiceCode"].ToString();
            }
            if (drow["InvoiceName"] == DBNull.Value)
            {
                this.InvoiceName = string.Empty;
            }
            else
            {
                this.InvoiceName = drow["InvoiceName"].ToString();
            }
            if (drow["SerialNo"] == DBNull.Value)
            {
                this.SerialNo = -1;
            }
            else
            {
                this.SerialNo = (int)drow["SerialNo"];
            }
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
            if (drow["InvoiceTypeID"] == DBNull.Value)
            {
                this.InvoiceTypeID = -1;
            }
            else
            {
                this.InvoiceTypeID = (int)drow["InvoiceTypeID"];
            }
            if (drow["TotalAMT"] == DBNull.Value)
            {
                this.TotalAMT = 0;
            }
            else
            {
                this.TotalAMT = (decimal)drow["TotalAMT"];
            }
            if (drow["TaxAMT"] == DBNull.Value)
            {
                this.TaxAMT = 0;
            }
            else
            {
                this.TaxAMT = (decimal)drow["TaxAMT"];
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
            if (drow["InvoiceTypeName"] == DBNull.Value)
            {
                this.InvoiceTypeName = string.Empty;
            }
            else
            {
                this.InvoiceTypeName = drow["InvoiceTypeName"].ToString();
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