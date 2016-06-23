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
    /// 表[PotentialCustomer]数据实体类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2016/1/5 8:37:10
    ///</时间>  
    public class PotentialCustomerEntity
    {
        public PotentialCustomerEntity()
        {
            this.accData = new JERPData.General.PotentialCustomer();
        }
        private JERPData.General.PotentialCustomer accData;
        public int CompanyID = -1;
        public DateTime DateRegister = DateTime.MinValue;
        public int SourceTypeID = -1;
        public int RegisterPsnID = -1;
        public string CompanyName = string.Empty;
        public string Linkman = string.Empty;
        public string Telephone = string.Empty;
        public string Mobile = string.Empty;
        public string QQ = string.Empty;
        public string Wechat = string.Empty;
        public string Email = string.Empty;
        public string URL = string.Empty;
        public string Address = string.Empty;
        public string Memo = string.Empty;
        public int LastSalePsnID = -1;
        public int SalePsnID = -1;
        public DateTime DateBegin = DateTime.MinValue;
        public int ProcessTypeID = -1;
        public DateTime DateContact = DateTime.MinValue;
        public string ResultContact = string.Empty;
        public DateTime DateNextContact = DateTime.MinValue;
        public bool PauseFlag = false;
        public bool SuccessFlag = false;
        public string LastSalePsn = string.Empty;
        public string SalePsn = string.Empty;
        public string RegisterPsn = string.Empty;
        public string ProcessTypeName = string.Empty;
        public string SourceTypeName = string.Empty;
        public void LoadData(int CompanyID)
        {
            this.CompanyID = CompanyID;
            DataTable dtbl = this.accData.GetDataPotentialCustomerByCompanyID(CompanyID).Tables[0];
            if (dtbl.Rows.Count == 0)
            {
                this.DateRegister = DateTime.MinValue;
                this.SourceTypeID = -1;
                this.RegisterPsnID = -1;
                this.CompanyName = string.Empty;
                this.Linkman = string.Empty;
                this.Telephone = string.Empty;
                this.Mobile = string.Empty;
                this.QQ = string.Empty;
                this.Wechat = string.Empty;
                this.Email = string.Empty;
                this.URL = string.Empty;
                this.Address = string.Empty;
                this.Memo = string.Empty;
                this.LastSalePsnID = -1;
                this.SalePsnID = -1;
                this.DateBegin = DateTime.MinValue;
                this.ProcessTypeID = -1;
                this.DateContact = DateTime.MinValue;
                this.ResultContact = string.Empty;
                this.DateNextContact = DateTime.MinValue;
                this.PauseFlag = false;
                this.SuccessFlag = false;
                this.LastSalePsn = string.Empty;
                this.SalePsn = string.Empty;
                this.RegisterPsn = string.Empty;
                this.ProcessTypeName = string.Empty;
                this.SourceTypeName = string.Empty;
                return;
            }
            DataRow drow = dtbl.Rows[0];
            if (drow["DateRegister"] == DBNull.Value)
            {
                this.DateRegister = DateTime.MinValue;
            }
            else
            {
                this.DateRegister = (DateTime)drow["DateRegister"];
            }
            if (drow["SourceTypeID"] == DBNull.Value)
            {
                this.SourceTypeID = -1;
            }
            else
            {
                this.SourceTypeID = (int)drow["SourceTypeID"];
            }
            if (drow["RegisterPsnID"] == DBNull.Value)
            {
                this.RegisterPsnID = -1;
            }
            else
            {
                this.RegisterPsnID = (int)drow["RegisterPsnID"];
            }
            if (drow["CompanyName"] == DBNull.Value)
            {
                this.CompanyName = string.Empty;
            }
            else
            {
                this.CompanyName = drow["CompanyName"].ToString();
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
            if (drow["Memo"] == DBNull.Value)
            {
                this.Memo = string.Empty;
            }
            else
            {
                this.Memo = drow["Memo"].ToString();
            }
            if (drow["LastSalePsnID"] == DBNull.Value)
            {
                this.LastSalePsnID = -1;
            }
            else
            {
                this.LastSalePsnID = (int)drow["LastSalePsnID"];
            }
            if (drow["SalePsnID"] == DBNull.Value)
            {
                this.SalePsnID = -1;
            }
            else
            {
                this.SalePsnID = (int)drow["SalePsnID"];
            }
            if (drow["DateBegin"] == DBNull.Value)
            {
                this.DateBegin = DateTime.MinValue;
            }
            else
            {
                this.DateBegin = (DateTime)drow["DateBegin"];
            }
            if (drow["ProcessTypeID"] == DBNull.Value)
            {
                this.ProcessTypeID = -1;
            }
            else
            {
                this.ProcessTypeID = (int)drow["ProcessTypeID"];
            }
            if (drow["DateContact"] == DBNull.Value)
            {
                this.DateContact = DateTime.MinValue;
            }
            else
            {
                this.DateContact = (DateTime)drow["DateContact"];
            }
            if (drow["ResultContact"] == DBNull.Value)
            {
                this.ResultContact = string.Empty;
            }
            else
            {
                this.ResultContact = drow["ResultContact"].ToString();
            }
            if (drow["DateNextContact"] == DBNull.Value)
            {
                this.DateNextContact = DateTime.MinValue;
            }
            else
            {
                this.DateNextContact = (DateTime)drow["DateNextContact"];
            }
            if (drow["PauseFlag"] == DBNull.Value)
            {
                this.PauseFlag = false;
            }
            else
            {
                this.PauseFlag = (bool)drow["PauseFlag"];
            }
            if (drow["SuccessFlag"] == DBNull.Value)
            {
                this.SuccessFlag = false;
            }
            else
            {
                this.SuccessFlag = (bool)drow["SuccessFlag"];
            }
            if (drow["LastSalePsn"] == DBNull.Value)
            {
                this.LastSalePsn = string.Empty;
            }
            else
            {
                this.LastSalePsn = drow["LastSalePsn"].ToString();
            }
            if (drow["SalePsn"] == DBNull.Value)
            {
                this.SalePsn = string.Empty;
            }
            else
            {
                this.SalePsn = drow["SalePsn"].ToString();
            }
            if (drow["RegisterPsn"] == DBNull.Value)
            {
                this.RegisterPsn = string.Empty;
            }
            else
            {
                this.RegisterPsn = drow["RegisterPsn"].ToString();
            }
            if (drow["ProcessTypeName"] == DBNull.Value)
            {
                this.ProcessTypeName = string.Empty;
            }
            else
            {
                this.ProcessTypeName = drow["ProcessTypeName"].ToString();
            }
            if (drow["SourceTypeName"] == DBNull.Value)
            {
                this.SourceTypeName = string.Empty;
            }
            else
            {
                this.SourceTypeName = drow["SourceTypeName"].ToString();
            }
        }
    }
}