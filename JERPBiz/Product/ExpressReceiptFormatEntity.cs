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
    /// 表[ExpressReceiptFormat]数据实体类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2015-05-31 06:59:12
    ///</时间>  
    public class ExpressReceiptFormatEntity
    {
        public ExpressReceiptFormatEntity()
        {
            this.accData = new JERPData.Product.ExpressReceiptFormat();
        }
        private JERPData.Product.ExpressReceiptFormat accData;
        public int FormatID = -1;
        public string TmpSheetName = string.Empty;
        public string NoteCodeCellName = string.Empty;
        public string DateNoteCellName = string.Empty;
        public string CompanyNameCellName = string.Empty;
        public string ReconciliationCodeCellName = string.Empty;
        public string MoneyTypeCellName = string.Empty;
        public string AmountCellName = string.Empty;
        public string MakerPsnCellName = string.Empty;
        public void LoadData(int FormatID)
        {
            this.FormatID = FormatID;
            DataTable dtbl = this.accData.GetDataExpressReceiptFormatByFormatID(FormatID).Tables[0];
            if (dtbl.Rows.Count == 0)
            {
                this.TmpSheetName = string.Empty;
                this.NoteCodeCellName = string.Empty;
                this.DateNoteCellName = string.Empty;
                this.CompanyNameCellName = string.Empty;
                this.ReconciliationCodeCellName = string.Empty;
                this.MoneyTypeCellName = string.Empty;
                this.AmountCellName = string.Empty;
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
            if (drow["AmountCellName"] == DBNull.Value)
            {
                this.AmountCellName = string.Empty;
            }
            else
            {
                this.AmountCellName = drow["AmountCellName"].ToString();
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