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
    /// 表[PriceType]数据实体类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2015-01-07 08:57:57
    ///</时间>  
    public class PriceTypeEntity
    {
        public PriceTypeEntity()
        {
            this.accData = new JERPData.Finance.PriceType();
        }
        private JERPData.Finance.PriceType accData;
        public int PriceTypeID = -1;
        public string PriceTypeCode = string.Empty;
        public string PriceTypeName = string.Empty;
        public decimal TaxRate = -1;
        public void LoadData(int PriceTypeID)
        {
            this.PriceTypeID = PriceTypeID;
            DataTable dtbl = this.accData.GetDataPriceTypeByPriceTypeID(PriceTypeID).Tables[0];
            if (dtbl.Rows.Count == 0)
            {
                this.PriceTypeCode = string.Empty;
                this.PriceTypeName = string.Empty;
                this.TaxRate = -1;
                return;
            }
            DataRow drow = dtbl.Rows[0];
            if (drow["PriceTypeCode"] == DBNull.Value)
            {
                this.PriceTypeCode = string.Empty;
            }
            else
            {
                this.PriceTypeCode = drow["PriceTypeCode"].ToString();
            }
            if (drow["PriceTypeName"] == DBNull.Value)
            {
                this.PriceTypeName = string.Empty;
            }
            else
            {
                this.PriceTypeName = drow["PriceTypeName"].ToString();
            }
            if (drow["TaxRate"] == DBNull.Value)
            {
                this.TaxRate = -1;
            }
            else
            {
                this.TaxRate = (decimal)drow["TaxRate"];
            }
        }
    }
}