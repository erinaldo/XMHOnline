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
    /// 表[Supplier]数据实体类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2016/1/6 9:43:43
    ///</时间>  
    public class SupplierEntity
    {
        public SupplierEntity()
        {
            this.accData = new JERPData.General.Supplier();
        }
        private JERPData.General.Supplier accData;
        public int CompanyID = -1;
        public string CompanyCode = string.Empty;
        public string CompanyAbbName = string.Empty;
        public string CompanyAllName = string.Empty;
        public string LegalPerson = string.Empty;
        public bool MtrFlag = false;
        public bool PrdFlag = false;
        public bool OtherResFlag = false;
        public bool ToolFlag = false;
        public bool OutSrcFlag = false;
        public bool SolutionFlag = false;
        public string Linkman = string.Empty;
        public string Telephone = string.Empty;
        public string Mobile = string.Empty;
        public string Fax = string.Empty;
        public string QQ = string.Empty;
        public string Wechat = string.Empty;
        public string Email = string.Empty;
        public string URL = string.Empty;
        public string Address = string.Empty;
        public string BankInfor = string.Empty;
        public string Memo = string.Empty;
        public DateTime DateLastOrder = DateTime.MinValue;
        public void LoadData(int CompanyID)
        {
            this.CompanyID = CompanyID;
            DataTable dtbl = this.accData.GetDataSupplierByCompanyID(CompanyID).Tables[0];
            if (dtbl.Rows.Count == 0)
            {
                this.CompanyCode = string.Empty;
                this.CompanyAbbName = string.Empty;
                this.CompanyAllName = string.Empty;
                this.LegalPerson = string.Empty;
                this.MtrFlag = false;
                this.PrdFlag = false;
                this.OtherResFlag = false;
                this.ToolFlag = false;
                this.OutSrcFlag = false;
                this.SolutionFlag = false;
                this.Linkman = string.Empty;
                this.Telephone = string.Empty;
                this.Mobile = string.Empty;
                this.Fax = string.Empty;
                this.QQ = string.Empty;
                this.Wechat = string.Empty;
                this.Email = string.Empty;
                this.URL = string.Empty;
                this.Address = string.Empty;
                this.BankInfor = string.Empty;
                this.Memo = string.Empty;
                this.DateLastOrder = DateTime.MinValue;
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
            if (drow["LegalPerson"] == DBNull.Value)
            {
                this.LegalPerson = string.Empty;
            }
            else
            {
                this.LegalPerson = drow["LegalPerson"].ToString();
            }
            if (drow["MtrFlag"] == DBNull.Value)
            {
                this.MtrFlag = false;
            }
            else
            {
                this.MtrFlag = (bool)drow["MtrFlag"];
            }
            if (drow["PrdFlag"] == DBNull.Value)
            {
                this.PrdFlag = false;
            }
            else
            {
                this.PrdFlag = (bool)drow["PrdFlag"];
            }
            if (drow["OtherResFlag"] == DBNull.Value)
            {
                this.OtherResFlag = false;
            }
            else
            {
                this.OtherResFlag = (bool)drow["OtherResFlag"];
            }
            if (drow["ToolFlag"] == DBNull.Value)
            {
                this.ToolFlag = false;
            }
            else
            {
                this.ToolFlag = (bool)drow["ToolFlag"];
            }
            if (drow["OutSrcFlag"] == DBNull.Value)
            {
                this.OutSrcFlag = false;
            }
            else
            {
                this.OutSrcFlag = (bool)drow["OutSrcFlag"];
            }
            if (drow["SolutionFlag"] == DBNull.Value)
            {
                this.SolutionFlag = false;
            }
            else
            {
                this.SolutionFlag = (bool)drow["SolutionFlag"];
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
            if (drow["Address"] == DBNull.Value)
            {
                this.Address = string.Empty;
            }
            else
            {
                this.Address = drow["Address"].ToString();
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
            if (drow["DateLastOrder"] == DBNull.Value)
            {
                this.DateLastOrder = DateTime.MinValue;
            }
            else
            {
                this.DateLastOrder = (DateTime)drow["DateLastOrder"];
            }
        }
    }
}