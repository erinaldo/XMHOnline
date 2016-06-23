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
namespace JERPBiz.Manufacture
{
    /// <描述>
    /// 表[ManufScheduleFormat]数据实体类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2016/6/10 20:29:15
    ///</时间>  
    public class ManufScheduleFormatEntity
    {
        public ManufScheduleFormatEntity()
        {
            this.accData = new JERPData.Manufacture.ManufScheduleFormat();
        }
        private JERPData.Manufacture.ManufScheduleFormat accData;
        public int FormatID = -1;
        public string TmpSheetName = string.Empty;
        public string WorkingSheetCodeCellName = string.Empty;
        public string CompanyCodeCellName = string.Empty;
        public string PrdCodeCellName = string.Empty;
        public string PrdNameCellName = string.Empty;
        public string PrdSpecCellName = string.Empty;
        public string ModelCellName = string.Empty;
        public string PrdStatusCellName = string.Empty;
        public string QuantityCellName = string.Empty;
        public string UnitNameCellName = string.Empty;
        public string PrdDateTargetCellName = string.Empty;
        public string DateTargetCellName = string.Empty;
        public string MemoCellName = string.Empty;
        public string LastPrdStatusCellName = string.Empty;
        public string NextPrdStatusCellName = string.Empty;
        public void LoadData(int FormatID)
        {
            this.FormatID = FormatID;
            DataTable dtbl = this.accData.GetDataManufScheduleFormatByFormatID(FormatID).Tables[0];
            if (dtbl.Rows.Count == 0)
            {
                this.TmpSheetName = string.Empty;
                this.WorkingSheetCodeCellName = string.Empty;
                this.CompanyCodeCellName = string.Empty;
                this.PrdCodeCellName = string.Empty;
                this.PrdNameCellName = string.Empty;
                this.PrdSpecCellName = string.Empty;
                this.ModelCellName = string.Empty;
                this.PrdStatusCellName = string.Empty;
                this.QuantityCellName = string.Empty;
                this.UnitNameCellName = string.Empty;
                this.PrdDateTargetCellName = string.Empty;
                this.DateTargetCellName = string.Empty;
                this.MemoCellName = string.Empty;
                this.LastPrdStatusCellName = string.Empty;
                this.NextPrdStatusCellName = string.Empty;
                return;
            }
            DataRow drow = dtbl.Rows[0];
            if (drow["TmpSheetName"] == DBNull.Value)
            {
                this.TmpSheetName = string.Empty;
            }
            else
            {
                this.TmpSheetName = drow["TmpSheetName"].ToString();
            }
            if (drow["WorkingSheetCodeCellName"] == DBNull.Value)
            {
                this.WorkingSheetCodeCellName = string.Empty;
            }
            else
            {
                this.WorkingSheetCodeCellName = drow["WorkingSheetCodeCellName"].ToString();
            }
            if (drow["CompanyCodeCellName"] == DBNull.Value)
            {
                this.CompanyCodeCellName = string.Empty;
            }
            else
            {
                this.CompanyCodeCellName = drow["CompanyCodeCellName"].ToString();
            }
            if (drow["PrdCodeCellName"] == DBNull.Value)
            {
                this.PrdCodeCellName = string.Empty;
            }
            else
            {
                this.PrdCodeCellName = drow["PrdCodeCellName"].ToString();
            }
            if (drow["PrdNameCellName"] == DBNull.Value)
            {
                this.PrdNameCellName = string.Empty;
            }
            else
            {
                this.PrdNameCellName = drow["PrdNameCellName"].ToString();
            }
            if (drow["PrdSpecCellName"] == DBNull.Value)
            {
                this.PrdSpecCellName = string.Empty;
            }
            else
            {
                this.PrdSpecCellName = drow["PrdSpecCellName"].ToString();
            }
            if (drow["ModelCellName"] == DBNull.Value)
            {
                this.ModelCellName = string.Empty;
            }
            else
            {
                this.ModelCellName = drow["ModelCellName"].ToString();
            }
            if (drow["PrdStatusCellName"] == DBNull.Value)
            {
                this.PrdStatusCellName = string.Empty;
            }
            else
            {
                this.PrdStatusCellName = drow["PrdStatusCellName"].ToString();
            }
            if (drow["QuantityCellName"] == DBNull.Value)
            {
                this.QuantityCellName = string.Empty;
            }
            else
            {
                this.QuantityCellName = drow["QuantityCellName"].ToString();
            }
            if (drow["UnitNameCellName"] == DBNull.Value)
            {
                this.UnitNameCellName = string.Empty;
            }
            else
            {
                this.UnitNameCellName = drow["UnitNameCellName"].ToString();
            }
            if (drow["PrdDateTargetCellName"] == DBNull.Value)
            {
                this.PrdDateTargetCellName = string.Empty;
            }
            else
            {
                this.PrdDateTargetCellName = drow["PrdDateTargetCellName"].ToString();
            }
            if (drow["DateTargetCellName"] == DBNull.Value)
            {
                this.DateTargetCellName = string.Empty;
            }
            else
            {
                this.DateTargetCellName = drow["DateTargetCellName"].ToString();
            }
            if (drow["MemoCellName"] == DBNull.Value)
            {
                this.MemoCellName = string.Empty;
            }
            else
            {
                this.MemoCellName = drow["MemoCellName"].ToString();
            }
            if (drow["LastPrdStatusCellName"] == DBNull.Value)
            {
                this.LastPrdStatusCellName = string.Empty;
            }
            else
            {
                this.LastPrdStatusCellName = drow["LastPrdStatusCellName"].ToString();
            }
            if (drow["NextPrdStatusCellName"] == DBNull.Value)
            {
                this.NextPrdStatusCellName = string.Empty;
            }
            else
            {
                this.NextPrdStatusCellName = drow["NextPrdStatusCellName"].ToString();
            }
        }
    }
}