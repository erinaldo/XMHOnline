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
    /// 表[PackingType]数据实体类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2014/3/20 7:09:00
    ///</时间>  
    public class PackingTypeEntity
    {
        public PackingTypeEntity()
        {
            this.accData = new JERPData.Product.PackingType();
        }
        private JERPData.Product.PackingType accData;
        public int PackingTypeID = -1;
        public int PrdID = -1;
        public string PackingTypeName = string.Empty;
        public string Description = string.Empty;
        public string PrdCode = string.Empty;
        public string PrdName = string.Empty;
        public string PrdSpec = string.Empty;
        public void LoadData(int PackingTypeID)
        {
            this.PackingTypeID = PackingTypeID;
            DataTable dtbl = this.accData.GetDataPackingTypeByPackingTypeID(PackingTypeID).Tables[0];
            if (dtbl.Rows.Count == 0)
            {
                this.PrdID = -1;
                this.PackingTypeName = string.Empty;
                this.Description = string.Empty;
                this.PrdCode = string.Empty;
                this.PrdName = string.Empty;
                this.PrdSpec = string.Empty;
                return;
            }
            DataRow drow = dtbl.Rows[0];
            if (drow["PrdID"] == DBNull.Value)
            {
                this.PrdID = -1;
            }
            else
            {
                this.PrdID = (int)drow["PrdID"];
            }
            if (drow["PackingTypeName"] == DBNull.Value)
            {
                this.PackingTypeName = string.Empty;
            }
            else
            {
                this.PackingTypeName = drow["PackingTypeName"].ToString();
            }
            if (drow["Description"] == DBNull.Value)
            {
                this.Description = string.Empty;
            }
            else
            {
                this.Description = drow["Description"].ToString();
            }
            if (drow["PrdCode"] == DBNull.Value)
            {
                this.PrdCode = string.Empty;
            }
            else
            {
                this.PrdCode = drow["PrdCode"].ToString();
            }
            if (drow["PrdName"] == DBNull.Value)
            {
                this.PrdName = string.Empty;
            }
            else
            {
                this.PrdName = drow["PrdName"].ToString();
            }
            if (drow["PrdSpec"] == DBNull.Value)
            {
                this.PrdSpec = string.Empty;
            }
            else
            {
                this.PrdSpec = drow["PrdSpec"].ToString();
            }
        }
    }
}