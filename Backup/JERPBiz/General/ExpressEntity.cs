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
    /// 表[Express]数据实体类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2014/1/19 20:21:47
    ///</时间>  
    public class ExpressEntity
    {
        public ExpressEntity()
        {
            this.accData = new JERPData.General.Express();
        }
        private JERPData.General.Express accData;
        public int CompanyID = -1;
        public string CompanyName = string.Empty;
        public string ReceiveCompanyNameCellName = string.Empty;
        public string ReceiveAddressCellName = string.Empty;
        public string LinkmanCellName = string.Empty;
        public string TelephoneCellName = string.Empty;
        public void LoadData(int CompanyID)
        {
            this.CompanyID = CompanyID;
            DataTable dtbl = this.accData.GetDataExpressByCompanyID(CompanyID).Tables[0];
            if (dtbl.Rows.Count == 0)
            {
                this.CompanyName = string.Empty;
                this.ReceiveCompanyNameCellName = string.Empty;
                this.ReceiveAddressCellName = string.Empty;
                this.LinkmanCellName = string.Empty;
                this.TelephoneCellName = string.Empty;
                return;
            }
            DataRow drow = dtbl.Rows[0];
            if (drow["CompanyName"] == DBNull.Value)
            {
                this.CompanyName = string.Empty;
            }
            else
            {
                this.CompanyName = drow["CompanyName"].ToString();
            }
            if (drow["ReceiveCompanyNameCellName"] == DBNull.Value)
            {
                this.ReceiveCompanyNameCellName = string.Empty;
            }
            else
            {
                this.ReceiveCompanyNameCellName = drow["ReceiveCompanyNameCellName"].ToString();
            }
            if (drow["ReceiveAddressCellName"] == DBNull.Value)
            {
                this.ReceiveAddressCellName = string.Empty;
            }
            else
            {
                this.ReceiveAddressCellName = drow["ReceiveAddressCellName"].ToString();
            }
            if (drow["LinkmanCellName"] == DBNull.Value)
            {
                this.LinkmanCellName = string.Empty;
            }
            else
            {
                this.LinkmanCellName = drow["LinkmanCellName"].ToString();
            }
            if (drow["TelephoneCellName"] == DBNull.Value)
            {
                this.TelephoneCellName = string.Empty;
            }
            else
            {
                this.TelephoneCellName = drow["TelephoneCellName"].ToString();
            }
        }
    }
}