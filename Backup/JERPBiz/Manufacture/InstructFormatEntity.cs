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
    /// 表[InstructFormat]数据实体类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2016/6/10 11:56:21
    ///</时间>  
    public class InstructFormatEntity
    {
        public InstructFormatEntity()
        {
            this.accData = new JERPData.Manufacture.InstructFormat();
        }
        private JERPData.Manufacture.InstructFormat accData;
        public string DateInstructCellName = string.Empty;
        public string MakerPsnCellName = string.Empty;
        public int ItemRowIndex = -1;
        public int ItemRowCount = -1;
        public void LoadData()
        {
            DataTable dtbl = this.accData.GetDataInstructFormat().Tables[0];
            if (dtbl.Rows.Count == 0)
            {
                this.DateInstructCellName = string.Empty;
                this.MakerPsnCellName = string.Empty;
                this.ItemRowIndex = -1;
                this.ItemRowCount = -1;
                return;
            }
            DataRow drow = dtbl.Rows[0];
            if (drow["DateInstructCellName"] == DBNull.Value)
            {
                this.DateInstructCellName  = string.Empty;
            }
            else
            {
                this.DateInstructCellName = drow["DateInstructCellName"].ToString();
            }
            if (drow["MakerPsnCellName"] == DBNull.Value)
            {
                this.MakerPsnCellName = string.Empty;
            }
            else
            {
                this.MakerPsnCellName = drow["MakerPsnCellName"].ToString();
            }
            if (drow["ItemRowIndex"] == DBNull.Value)
            {
                this.ItemRowIndex = -1;
            }
            else
            {
                this.ItemRowIndex = (int)drow["ItemRowIndex"];
            }
            if (drow["ItemRowCount"] == DBNull.Value)
            {
                this.ItemRowCount = -1;
            }
            else
            {
                this.ItemRowCount = (int)drow["ItemRowCount"];
            }
        }
    }
}