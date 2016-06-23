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
namespace JERPBiz.General
{
    /// <描述>
    /// 表[Customer]数据实体类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2016/1/5 8:32:46
    ///</时间>  
    public class CustomerEntity
    {
        public CustomerEntity()
        {
            this.accData = new JERPData.General.Customer();
        }
        private JERPData.General.Customer accData;
        public int CompanyID = -1;
        public string CompanyCode = string.Empty;
        public string CompanyAbbName = string.Empty;
        public string CompanyAllName = string.Empty;
        public string AssistantCode = string.Empty;
        public string LegalPerson = string.Empty;
        public int CustomerTypeID = -1;
        public DateTime DateRegister = DateTime.MinValue;
        public int AreaID = -1;
        public int SalePsnID = -1;
        public int HandlePsnID = -1;
        public string Linkman = string.Empty;
        public string Telephone = string.Empty;
        public string Mobile = string.Empty;
        public string Fax = string.Empty;
        public string QQ = string.Empty;
        public string Wechat = string.Empty;
        public string Email = string.Empty;
        public string URL = string.Empty;
        public string DeliverAddress = string.Empty;
        public string FinanceAddress = string.Empty;
        public string BankInfor = string.Empty;
        public string Memo = string.Empty;
        public decimal CreditAMT = 0;
        public decimal TotalMainAMT = 0;
        public DateTime DateLastOrder = DateTime.MinValue;
        public string SalePsn = string.Empty;
        public string HandlePsn = string.Empty;
        public string AreaName = string.Empty;
        public string CustomerTypeName = string.Empty;
        public void LoadData(int CompanyID)
        {
            this.CompanyID = CompanyID;
            DataTable dtbl = this.accData.GetDataCustomerByCompanyID(CompanyID).Tables[0];
            if (dtbl.Rows.Count == 0)
            {
                this.CompanyCode = string.Empty;
                this.CompanyAbbName = string.Empty;
                this.CompanyAllName = string.Empty;
                this.AssistantCode = string.Empty;
                this.LegalPerson = string.Empty;
                this.CustomerTypeID = -1;
                this.DateRegister = DateTime.MinValue;
                this.AreaID = -1;
                this.SalePsnID = -1;
                this.HandlePsnID = -1;
                this.Linkman = string.Empty;
                this.Telephone = string.Empty;
                this.Mobile = string.Empty;
                this.Fax = string.Empty;
                this.QQ = string.Empty;
                this.Wechat = string.Empty;
                this.Email = string.Empty;
                this.URL = string.Empty;
                this.DeliverAddress = string.Empty;
                this.FinanceAddress = string.Empty;
                this.BankInfor = string.Empty;
                this.Memo = string.Empty;
                this.CreditAMT = 0;
                this.TotalMainAMT = 0;
                this.DateLastOrder = DateTime.MinValue;
                this.SalePsn = string.Empty;
                this.HandlePsn = string.Empty;
                this.AreaName = string.Empty;
                this.CustomerTypeName = string.Empty;
                return;
            }
            DataRow drow = dtbl.Rows[0];
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
            if (drow["AssistantCode"] == DBNull.Value)
            {
                this.AssistantCode = string.Empty;
            }
            else
            {
                this.AssistantCode = drow["AssistantCode"].ToString();
            }
            if (drow["LegalPerson"] == DBNull.Value)
            {
                this.LegalPerson = string.Empty;
            }
            else
            {
                this.LegalPerson = drow["LegalPerson"].ToString();
            }
            if (drow["CustomerTypeID"] == DBNull.Value)
            {
                this.CustomerTypeID = -1;
            }
            else
            {
                this.CustomerTypeID = (int)drow["CustomerTypeID"];
            }
            if (drow["DateRegister"] == DBNull.Value)
            {
                this.DateRegister = DateTime.MinValue;
            }
            else
            {
                this.DateRegister = (DateTime)drow["DateRegister"];
            }
            if (drow["AreaID"] == DBNull.Value)
            {
                this.AreaID = -1;
            }
            else
            {
                this.AreaID = (int)drow["AreaID"];
            }
            if (drow["SalePsnID"] == DBNull.Value)
            {
                this.SalePsnID = -1;
            }
            else
            {
                this.SalePsnID = (int)drow["SalePsnID"];
            }
            if (drow["HandlePsnID"] == DBNull.Value)
            {
                this.HandlePsnID = -1;
            }
            else
            {
                this.HandlePsnID = (int)drow["HandlePsnID"];
            }
            if (drow["Linkman"] == DBNull.Value)
            {
                this.Linkman = string.Empty;
            }
            else
            {
                this.Linkman = drow["Linkman"].ToString();
            }
            if (drow["Telephone"] == DBNull.Value)
            {
                this.Telephone = string.Empty;
            }
            else
            {
                this.Telephone = drow["Telephone"].ToString();
            }
            if (drow["Mobile"] == DBNull.Value)
            {
                this.Mobile = string.Empty;
            }
            else
            {
                this.Mobile = drow["Mobile"].ToString();
            }
            if (drow["Fax"] == DBNull.Value)
            {
                this.Fax = string.Empty;
            }
            else
            {
                this.Fax = drow["Fax"].ToString();
            }
            if (drow["QQ"] == DBNull.Value)
            {
                this.QQ = string.Empty;
            }
            else
            {
                this.QQ = drow["QQ"].ToString();
            }
            if (drow["Wechat"] == DBNull.Value)
            {
                this.Wechat = string.Empty;
            }
            else
            {
                this.Wechat = drow["Wechat"].ToString();
            }
            if (drow["Email"] == DBNull.Value)
            {
                this.Email = string.Empty;
            }
            else
            {
                this.Email = drow["Email"].ToString();
            }
            if (drow["URL"] == DBNull.Value)
            {
                this.URL = string.Empty;
            }
            else
            {
                this.URL = drow["URL"].ToString();
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
            if (drow["BankInfor"] == DBNull.Value)
            {
                this.BankInfor = string.Empty;
            }
            else
            {
                this.BankInfor = drow["BankInfor"].ToString();
            }
            if (drow["Memo"] == DBNull.Value)
            {
                this.Memo = string.Empty;
            }
            else
            {
                this.Memo = drow["Memo"].ToString();
            }
            if (drow["CreditAMT"] == DBNull.Value)
            {
                this.CreditAMT = 0;
            }
            else
            {
                this.CreditAMT = (decimal)drow["CreditAMT"];
            }
            if (drow["TotalMainAMT"] == DBNull.Value)
            {
                this.TotalMainAMT = 0;
            }
            else
            {
                this.TotalMainAMT = (decimal)drow["TotalMainAMT"];
            }
            if (drow["DateLastOrder"] == DBNull.Value)
            {
                this.DateLastOrder = DateTime.MinValue;
            }
            else
            {
                this.DateLastOrder = (DateTime)drow["DateLastOrder"];
            }
            if (drow["SalePsn"] == DBNull.Value)
            {
                this.SalePsn = string.Empty;
            }
            else
            {
                this.SalePsn = drow["SalePsn"].ToString();
            }
            if (drow["HandlePsn"] == DBNull.Value)
            {
                this.HandlePsn = string.Empty;
            }
            else
            {
                this.HandlePsn = drow["HandlePsn"].ToString();
            }
            if (drow["AreaName"] == DBNull.Value)
            {
                this.AreaName = string.Empty;
            }
            else
            {
                this.AreaName = drow["AreaName"].ToString();
            }
            if (drow["CustomerTypeName"] == DBNull.Value)
            {
                this.CustomerTypeName = string.Empty;
            }
            else
            {
                this.CustomerTypeName = drow["CustomerTypeName"].ToString();
            }
        }
    }
}