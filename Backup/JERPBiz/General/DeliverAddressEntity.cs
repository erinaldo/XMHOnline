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
    /// 表[DeliverAddress]数据实体类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2014/4/14 15:53:59
    ///</时间>  
    public class DeliverAddressEntity
    {
        public DeliverAddressEntity()
        {
            this.accData = new JERPData.General.DeliverAddress();
        }
        private JERPData.General.DeliverAddress accData;
        public int DeliverAddressID = -1;
        public int CompanyID = -1;
        public string Address = string.Empty;
        public string Linkman = string.Empty;
        public string Telephone = string.Empty;
        public string Fax = string.Empty;
        public void LoadData(int DeliverAddressID)
        {
            this.DeliverAddressID = DeliverAddressID;
            DataTable dtbl = this.accData.GetDataDeliverAddressByDeliverAddressID(DeliverAddressID).Tables[0];
            if (dtbl.Rows.Count == 0)
            {
                this.CompanyID = -1;
                this.Address = string.Empty;
                this.Linkman = string.Empty;
                this.Telephone = string.Empty;
                this.Fax = string.Empty;
                return;
            }
            DataRow drow = dtbl.Rows[0];
            if (drow["CompanyID"] == DBNull.Value)
            {
                this.CompanyID = -1;
            }
            else
            {
                this.CompanyID = (int)drow["CompanyID"];
            }
            if (drow["Address"] == DBNull.Value)
            {
                this.Address = string.Empty;
            }
            else
            {
                this.Address = drow["Address"].ToString();
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
            if (drow["Fax"] == DBNull.Value)
            {
                this.Fax = string.Empty;
            }
            else
            {
                this.Fax = drow["Fax"].ToString();
            }
        }
    }
}