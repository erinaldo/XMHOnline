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
    /// 表[SaleReconciliationFormat]数据实体类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2015/7/24 20:04:24
    ///</时间>  
    public class SaleReconciliationFormatEntity
    {
        public SaleReconciliationFormatEntity()
        {
            this.accData = new JERPData.Product.SaleReconciliationFormat();
        }
        private JERPData.Product.SaleReconciliationFormat accData;
        public int FormatID = -1;
        public string TmpSheetName = string.Empty;
        public string ReconciliationNameCellName = string.Empty;
        public string ReconciliationCodeCellName = string.Empty;
        public string CompanyNameCellName = string.Empty;
        public string FinanceAddressCellName = string.Empty;
        public string LinkmanCellName = string.Empty;
        public string TelephoneCellName = string.Empty;
        public string FaxCellName = string.Empty;
        public string MoneyTypeCellName = string.Empty;
        public string SettleTypeCellName = string.Empty;
        public string DateNoteCellName = string.Empty;
        public string DateSettleCellName = string.Empty;
        public int ItemBeginRowIndex = -1;
        public string DeliverAMTCellName = string.Empty;
        public string RepairAMTCellName = string.Empty;
        public string ReplaceExpressAMTCellName = string.Empty;
        public string ReturnAMTCellName = string.Empty;
        public string FineAMTCellName = string.Empty;
        public string TotalAMTCellName = string.Empty;
        public string TotalQtyCellName = string.Empty;
        public int RecordBeginRowIndex = -1;
        public string RecordDateColumnName = string.Empty;
        public string RecordCodeColumnName = string.Empty;
        public string RecordPsnColumnName = string.Empty;
        public string RecordAMTColumnName = string.Empty;
        public void LoadData(int FormatID)
        {
            this.FormatID = FormatID;
            DataTable dtbl = this.accData.GetDataSaleReconciliationFormatByFormatID(FormatID).Tables[0];
            if (dtbl.Rows.Count == 0)
            {
                this.TmpSheetName = string.Empty;
                this.ReconciliationNameCellName = string.Empty;
                this.ReconciliationCodeCellName = string.Empty;
                this.CompanyNameCellName = string.Empty;
                this.FinanceAddressCellName = string.Empty;
                this.LinkmanCellName = string.Empty;
                this.TelephoneCellName = string.Empty;
                this.FaxCellName = string.Empty;
                this.MoneyTypeCellName = string.Empty;
                this.SettleTypeCellName = string.Empty;
                this.DateNoteCellName = string.Empty;
                this.DateSettleCellName = string.Empty;
                this.ItemBeginRowIndex = -1;
                this.DeliverAMTCellName = string.Empty;
                this.RepairAMTCellName = string.Empty;
                this.ReplaceExpressAMTCellName = string.Empty;
                this.ReturnAMTCellName = string.Empty;
                this.FineAMTCellName = string.Empty;
                this.TotalAMTCellName = string.Empty;
                this.TotalQtyCellName = string.Empty;
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
            if (drow["FinanceAddressCellName"] == DBNull.Value)
            {
                this.FinanceAddressCellName = string.Empty;
            }
            else
            {
                this.FinanceAddressCellName = drow["FinanceAddressCellName"].ToString();
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
            if (drow["FaxCellName"] == DBNull.Value)
            {
                this.FaxCellName = string.Empty;
            }
            else
            {
                this.FaxCellName = drow["FaxCellName"].ToString();
            }
            if (drow["MoneyTypeCellName"] == DBNull.Value)
            {
                this.MoneyTypeCellName = string.Empty;
            }
            else
            {
                this.MoneyTypeCellName = drow["MoneyTypeCellName"].ToString();
            }
            if (drow["SettleTypeCellName"] == DBNull.Value)
            {
                this.SettleTypeCellName = string.Empty;
            }
            else
            {
                this.SettleTypeCellName = drow["SettleTypeCellName"].ToString();
            }
            if (drow["DateNoteCellName"] == DBNull.Value)
            {
                this.DateNoteCellName = string.Empty;
            }
            else
            {
                this.DateNoteCellName = drow["DateNoteCellName"].ToString();
            }
            if (drow["DateSettleCellName"] == DBNull.Value)
            {
                this.DateSettleCellName = string.Empty;
            }
            else
            {
                this.DateSettleCellName = drow["DateSettleCellName"].ToString();
            }
            if (drow["ItemBeginRowIndex"] == DBNull.Value)
            {
                this.ItemBeginRowIndex = -1;
            }
            else
            {
                this.ItemBeginRowIndex = (int)drow["ItemBeginRowIndex"];
            }
            if (drow["DeliverAMTCellName"] == DBNull.Value)
            {
                this.DeliverAMTCellName = string.Empty;
            }
            else
            {
                this.DeliverAMTCellName = drow["DeliverAMTCellName"].ToString();
            }
            if (drow["RepairAMTCellName"] == DBNull.Value)
            {
                this.RepairAMTCellName = string.Empty;
            }
            else
            {
                this.RepairAMTCellName = drow["RepairAMTCellName"].ToString();
            }
            if (drow["ReplaceExpressAMTCellName"] == DBNull.Value)
            {
                this.ReplaceExpressAMTCellName = string.Empty;
            }
            else
            {
                this.ReplaceExpressAMTCellName = drow["ReplaceExpressAMTCellName"].ToString();
            }
            if (drow["ReturnAMTCellName"] == DBNull.Value)
            {
                this.ReturnAMTCellName = string.Empty;
            }
            else
            {
                this.ReturnAMTCellName = drow["ReturnAMTCellName"].ToString();
            }
            if (drow["FineAMTCellName"] == DBNull.Value)
            {
                this.FineAMTCellName = string.Empty;
            }
            else
            {
                this.FineAMTCellName = drow["FineAMTCellName"].ToString();
            }
            if (drow["TotalAMTCellName"] == DBNull.Value)
            {
                this.TotalAMTCellName = string.Empty;
            }
            else
            {
                this.TotalAMTCellName = drow["TotalAMTCellName"].ToString();
            }
            if (drow["TotalQtyCellName"] == DBNull.Value)
            {
                this.TotalQtyCellName = string.Empty;
            }
            else
            {
                this.TotalQtyCellName = drow["TotalQtyCellName"].ToString();
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