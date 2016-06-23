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
namespace JERPBiz.Finance
{
    /// <描述>
    /// 表[SettleType]数据实体类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2014-12-23 09:38:37
    ///</时间>  
    public class SettleTypeEntity
    {
        public SettleTypeEntity()
        {
            this.accData = new JERPData.Finance.SettleType();
        }
        private JERPData.Finance.SettleType accData;
        public int SettleTypeID = -1;
        public string SettleTypeCode = string.Empty;
        public string SettleTypeName = string.Empty;
        public bool CashSettleFlag = false;
        public void LoadData(int SettleTypeID)
        {
            this.SettleTypeID = SettleTypeID;
            DataTable dtbl = this.accData.GetDataSettleTypeBySettleTypeID(SettleTypeID).Tables[0];
            if (dtbl.Rows.Count == 0)
            {
                this.SettleTypeCode = string.Empty;
                this.SettleTypeName = string.Empty;
                this.CashSettleFlag = false;
                return;
            }
            DataRow drow = dtbl.Rows[0];
            if (drow["SettleTypeCode"] == DBNull.Value)
            {
                this.SettleTypeCode = string.Empty;
            }
            else
            {
                this.SettleTypeCode = drow["SettleTypeCode"].ToString();
            }
            if (drow["SettleTypeName"] == DBNull.Value)
            {
                this.SettleTypeName = string.Empty;
            }
            else
            {
                this.SettleTypeName = drow["SettleTypeName"].ToString();
            }
            if (drow["CashSettleFlag"] == DBNull.Value)
            {
                this.CashSettleFlag = false;
            }
            else
            {
                this.CashSettleFlag = (bool)drow["CashSettleFlag"];
            }
        }
    }
}