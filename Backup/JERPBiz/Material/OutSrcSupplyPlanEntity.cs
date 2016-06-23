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
namespace JERPBiz.Material
{
    /// <描述>
    /// 表[OutSrcSupplyPlans]数据实体类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2015/12/26 15:05:57
    ///</时间>  
    public class OutSrcSupplyPlanEntity
    {
        public OutSrcSupplyPlanEntity()
        {
            this.accData = new JERPData.Material.OutSrcSupplyPlans();
        }
        private JERPData.Material.OutSrcSupplyPlans accData;
        public long OutSrcSupplyPlanID = -1;
        public long NoteID = -1;
        public long OutSrcOrderItemID = -1;
        public string PONo = string.Empty;
        public long WorkingSheetID = -1;
        public string WorkingSheetCode = string.Empty;
        public int PrdID = -1;
        public string PrdStatus = string.Empty;
        public decimal Quantity = 0;
        public string PrdCode = string.Empty;
        public string PrdName = string.Empty;
        public string PrdSpec = string.Empty;
        public string Model = string.Empty;
        public string UnitName = string.Empty;
        public void LoadData(long OutSrcSupplyPlanID)
        {
            this.OutSrcSupplyPlanID = OutSrcSupplyPlanID;
            DataTable dtbl = this.accData.GetDataOutSrcSupplyPlansByOutSrcSupplyPlanID(OutSrcSupplyPlanID).Tables[0];
            if (dtbl.Rows.Count == 0)
            {
                this.NoteID = -1;
                this.OutSrcOrderItemID = -1;
                this.PONo = string.Empty;
                this.WorkingSheetID = -1;
                this.WorkingSheetCode = string.Empty;
                this.PrdID = -1;
                this.PrdStatus = string.Empty;
                this.Quantity = 0;
                this.PrdCode = string.Empty;
                this.PrdName = string.Empty;
                this.PrdSpec = string.Empty;
                this.Model = string.Empty;
                this.UnitName = string.Empty;
                return;
            }
            DataRow drow = dtbl.Rows[0];
            if (drow["NoteID"] == DBNull.Value)
            {
                this.NoteID = -1;
            }
            else
            {
                this.NoteID = (long)drow["NoteID"];
            }
            if (drow["OutSrcOrderItemID"] == DBNull.Value)
            {
                this.OutSrcOrderItemID = -1;
            }
            else
            {
                this.OutSrcOrderItemID = (long)drow["OutSrcOrderItemID"];
            }
            if (drow["PONo"] == DBNull.Value)
            {
                this.PONo = string.Empty;
            }
            else
            {
                this.PONo = drow["PONo"].ToString();
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
            if (drow["PrdStatus"] == DBNull.Value)
            {
                this.PrdStatus = string.Empty;
            }
            else
            {
                this.PrdStatus = drow["PrdStatus"].ToString();
            }
            if (drow["Quantity"] == DBNull.Value)
            {
                this.Quantity = 0;
            }
            else
            {
                this.Quantity = (decimal)drow["Quantity"];
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