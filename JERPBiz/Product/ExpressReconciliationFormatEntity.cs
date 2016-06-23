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
    /// 表[ExpressReconciliationFormat]数据实体类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2015-05-31 07:01:03
    ///</时间>  
    public class ExpressReconciliationFormatEntity
    {
        public ExpressReconciliationFormatEntity()
        {
            this.accData = new JERPData.Product.ExpressReconciliationFormat();
        }
        private JERPData.Product.ExpressReconciliationFormat accData;
        public int FormatID = -1;
        public string TmpSheetName = string.Empty;
        public string ReconciliationNameCellName = string.Empty;
        public string ReconciliationCodeCellName = string.Empty;
        public string CompanyNameCellName = string.Empty;
        public string MoneyTypeCellName = string.Empty;
        public string DateNoteCellName = string.Empty;
        public int ItemBeginRowIndex = -1;
        public string TotalAMTCellName = string.Empty;
        public string MakerPsnCellName = string.Empty;
        public int RecordBeginRowIndex = -1;
        public string RecordDateColumnName = string.Empty;
        public string RecordCodeColumnName = string.Empty;
        public string RecordPsnColumnName = string.Empty;
        public string RecordAMTColumnName = string.Empty;
        public void LoadData(int FormatID)
        {
            this.FormatID = FormatID;
            DataTable dtbl = this.accData.GetDataExpressReconciliationFormatByFormatID(FormatID).Tables[0];
            if (dtbl.Rows.Count == 0)
            {
                this.TmpSheetName = string.Empty;
                this.ReconciliationNameCellName = string.Empty;
                this.ReconciliationCodeCellName = string.Empty;
                this.CompanyNameCellName = string.Empty;
                this.MoneyTypeCellName = string.Empty;
                this.DateNoteCellName = string.Empty;
                this.ItemBeginRowIndex = -1;
                this.TotalAMTCellName = string.Empty;
                this.MakerPsnCellName = string.Empty;
                this.RecordBeginRowIndex = -1;
                this.RecordDateColumnName = string.Empty;
                this.RecordCodeColumnName = string.Empty;
                this.RecordPsnColumnName = string.Empty;
                this.RecordAMTColumnName = string.Empty;
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
            if (drow["ReconciliationNameCellName"] == DBNull.Value)
            {
                this.ReconciliationNameCellName = string.Empty;
            }
            else
            {
                this.ReconciliationNameCellName = drow["ReconciliationNameCellName"].ToString();
            }
            if (drow["ReconciliationCodeCellName"] == DBNull.Value)
            {
                this.ReconciliationCodeCellName = string.Empty;
            }
            else
            {
                this.ReconciliationCodeCellName = drow["ReconciliationCodeCellName"].ToString();
            }
            if (drow["CompanyNameCellName"] == DBNull.Value)
            {
                this.CompanyNameCellName = string.Empty;
            }
            else
            {
                this.CompanyNameCellName = drow["CompanyNameCellName"].ToString();
            }
            if (drow["MoneyTypeCellName"] == DBNull.Value)
            {
                this.MoneyTypeCellName = string.Empty;
            }
            else
            {
                this.MoneyTypeCellName = drow["MoneyTypeCellName"].ToString();
            }
            if (drow["DateNoteCellName"] == DBNull.Value)
            {
                this.DateNoteCellName = string.Empty;
            }
            else
            {
                this.DateNoteCellName = drow["DateNoteCellName"].ToString();
            }
            if (drow["ItemBeginRowIndex"] == DBNull.Value)
            {
                this.ItemBeginRowIndex = -1;
            }
            else
            {
                this.ItemBeginRowIndex = (int)drow["ItemBeginRowIndex"];
            }
            if (drow["TotalAMTCellName"] == DBNull.Value)
            {
                this.TotalAMTCellName = string.Empty;
            }
            else
            {
                this.TotalAMTCellName = drow["TotalAMTCellName"].ToString();
            }
            if (drow["MakerPsnCellName"] == DBNull.Value)
            {
                this.MakerPsnCellName = string.Empty;
            }
            else
            {
                this.MakerPsnCellName = drow["MakerPsnCellName"].ToString();
            }
            if (drow["RecordBeginRowIndex"] == DBNull.Value)
            {
                this.RecordBeginRowIndex = -1;
            }
            else
            {
                this.RecordBeginRowIndex = (int)drow["RecordBeginRowIndex"];
            }
            if (drow["RecordDateColumnName"] == DBNull.Value)
            {
                this.RecordDateColumnName = string.Empty;
            }
            else
            {
                this.RecordDateColumnName = drow["RecordDateColumnName"].ToString();
            }
            if (drow["RecordCodeColumnName"] == DBNull.Value)
            {
                this.RecordCodeColumnName = string.Empty;
            }
            else
            {
                this.RecordCodeColumnName = drow["RecordCodeColumnName"].ToString();
            }
            if (drow["RecordPsnColumnName"] == DBNull.Value)
            {
                this.RecordPsnColumnName = string.Empty;
            }
            else
            {
                this.RecordPsnColumnName = drow["RecordPsnColumnName"].ToString();
            }
            if (drow["RecordAMTColumnName"] == DBNull.Value)
            {
                this.RecordAMTColumnName = string.Empty;
            }
            else
            {
                this.RecordAMTColumnName = drow["RecordAMTColumnName"].ToString();
            }
        }
    }
}