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
namespace JERPBiz.Packing
{
    /// <描述>
    /// 表[Boxes]数据实体类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2016/5/24 16:09:31
    ///</时间>  
    public class BoxEntity
    {
        public BoxEntity()
        {
            this.accData = new JERPData.Packing.Boxes();
        }
        private JERPData.Packing.Boxes accData;
        public string BoxCode = string.Empty;
        public int SerialNo = -1;
        public DateTime DateCreate = DateTime.MinValue;
        public long WorkingSheetID = -1;
        public string WorkingSheetCode = string.Empty;
        public int PrdID = -1;
        public decimal Quantity = 0;
        public bool PrintFlag = false;
        public string PrdCode = string.Empty;
        public string PrdName = string.Empty;
        public string PrdSpec = string.Empty;
        public string Model = string.Empty;
        public string Manufacturer = string.Empty;
        public string UnitName = string.Empty;
        public void LoadData(string BoxCode)
        {
            this.BoxCode = BoxCode;
            DataTable dtbl = this.accData.GetDataBoxesByBoxCode(BoxCode).Tables[0];
            if (dtbl.Rows.Count == 0)
            {
                this.SerialNo = -1;
                this.DateCreate = DateTime.MinValue;
                this.WorkingSheetID = -1;
                this.WorkingSheetCode = string.Empty;
                this.PrdID = -1;
                this.Quantity = 0;
                this.PrintFlag = false;
                this.PrdCode = string.Empty;
                this.PrdName = string.Empty;
                this.PrdSpec = string.Empty;
                this.Model = string.Empty;
                this.Manufacturer = string.Empty;
                this.UnitName = string.Empty;
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
            if (drow["DateCreate"] == DBNull.Value)
            {
                this.DateCreate = DateTime.MinValue;
            }
            else
            {
                this.DateCreate = (DateTime)drow["DateCreate"];
            }
            if (drow["WorkingSheetID"] == DBNull.Value)
            {
                this.WorkingSheetID = -1;
            }
            else
            {
                this.WorkingSheetID = (long)drow["WorkingSheetID"];
            }
            if (drow["WorkingSheetCode"] == DBNull.Value)
            {
                this.WorkingSheetCode = string.Empty;
            }
            else
            {
                this.WorkingSheetCode = drow["WorkingSheetCode"].ToString();
            }
            if (drow["PrdID"] == DBNull.Value)
            {
                this.PrdID = -1;
            }
            else
            {
                this.PrdID = (int)drow["PrdID"];
            }
            if (drow["Quantity"] == DBNull.Value)
            {
                this.Quantity = 0;
            }
            else
            {
                this.Quantity = (decimal)drow["Quantity"];
            }
            if (drow["PrintFlag"] == DBNull.Value)
            {
                this.PrintFlag = false;
            }
            else
            {
                this.PrintFlag = (bool)drow["PrintFlag"];
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
            if (drow["Model"] == DBNull.Value)
            {
                this.Model = string.Empty;
            }
            else
            {
                this.Model = drow["Model"].ToString();
            }
            if (drow["Manufacturer"] == DBNull.Value)
            {
                this.Manufacturer = string.Empty;
            }
            else
            {
                this.Manufacturer = drow["Manufacturer"].ToString();
            }
            if (drow["UnitName"] == DBNull.Value)
            {
                this.UnitName = string.Empty;
            }
            else
            {
                this.UnitName = drow["UnitName"].ToString();
            }
        }
    }
}