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
    /// 表[SaleReceiptFormat]数据实体类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2016/1/17 17:23:05
    ///</时间>  
    public class SaleReceiptFormatEntity
    {
        public SaleReceiptFormatEntity()
        {
            this.accData = new JERPData.Product.SaleReceiptFormat();
        }
        private JERPData.Product.SaleReceiptFormat accData;
        public int FormatID = -1;
        public string TmpSheetName = string.Empty;
        public string NoteCodeCellName = string.Empty;
        public string DateNoteCellName = string.Empty;
        public string CompanyNameCellName = string.Empty;
        public string ReconciliationCodeCellName = string.Empty;
        public string MoneyTypeCellName = string.Empty;
        public string TotalAMTCellName = string.Empty;
        public string AdvanceAMTCellName = string.Empty;
        public string AmountCellName = string.Empty;
        public string ExpressCompanyNameCellName = string.Empty;
        public string MakerPsnCellName = string.Empty;
        public void LoadData(int FormatID)
        {
            this.FormatID = FormatID;
            DataTable dtbl = this.accData.GetDataSaleReceiptFormatByFormatID(FormatID).Tables[0];
            if (dtbl.Rows.Count == 0)
            {
                this.TmpSheetName = string.Empty;
                this.NoteCodeCellName = string.Empty;
                this.DateNoteCellName = string.Empty;
                this.CompanyNameCellName = string.Empty;
                this.ReconciliationCodeCellName = string.Empty;
                this.MoneyTypeCellName = string.Empty;
                this.TotalAMTCellName = string.Empty;
                this.AdvanceAMTCellName = string.Empty;
                this.AmountCellName = string.Empty;
                this.ExpressCompanyNameCellName = string.Empty;
                this.MakerPsnCellName = string.Empty;
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
            if (drow["NoteCodeCellName"] == DBNull.Value)
            {
                this.NoteCodeCellName = string.Empty;
            }
            else
            {
                this.NoteCodeCellName = drow["NoteCodeCellName"].ToString();
            }
            if (drow["DateNoteCellName"] == DBNull.Value)
            {
                this.DateNoteCellName = string.Empty;
            }
            else
            {
                this.DateNoteCellName = drow["DateNoteCellName"].ToString();
            }
            if (drow["CompanyNameCellName"] == DBNull.Value)
            {
                this.CompanyNameCellName = string.Empty;
            }
            else
            {
                this.CompanyNameCellName = drow["CompanyNameCellName"].ToString();
            }
            if (drow["ReconciliationCodeCellName"] == DBNull.Value)
            {
                this.ReconciliationCodeCellName = string.Empty;
            }
            else
            {
                this.ReconciliationCodeCellName = drow["ReconciliationCodeCellName"].ToString();
            }
            if (drow["MoneyTypeCellName"] == DBNull.Value)
            {
                this.MoneyTypeCellName = string.Empty;
            }
            else
            {
                this.MoneyTypeCellName = drow["MoneyTypeCellName"].ToString();
            }
            if (drow["TotalAMTCellName"] == DBNull.Value)
            {
                this.TotalAMTCellName = string.Empty;
            }
            else
            {
                this.TotalAMTCellName = drow["TotalAMTCellName"].ToString();
            }
            if (drow["AdvanceAMTCellName"] == DBNull.Value)
            {
                this.AdvanceAMTCellName = string.Empty;
            }
            else
            {
                this.AdvanceAMTCellName = drow["AdvanceAMTCellName"].ToString();
            }
            if (drow["AmountCellName"] == DBNull.Value)
            {
                this.AmountCellName = string.Empty;
            }
            else
            {
                this.AmountCellName = drow["AmountCellName"].ToString();
            }
            if (drow["ExpressCompanyNameCellName"] == DBNull.Value)
            {
                this.ExpressCompanyNameCellName = string.Empty;
            }
            else
            {
                this.ExpressCompanyNameCellName = drow["ExpressCompanyNameCellName"].ToString();
            }
            if (drow["MakerPsnCellName"] == DBNull.Value)
            {
                this.MakerPsnCellName = string.Empty;
            }
            else
            {
                this.MakerPsnCellName = drow["MakerPsnCellName"].ToString();
            }
        }
    }
}