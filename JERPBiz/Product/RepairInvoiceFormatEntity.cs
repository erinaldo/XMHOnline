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
    /// 表[RepairInvoiceFormat]数据实体类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2015/7/24 20:03:31
    ///</时间>  
    public class RepairInvoiceFormatEntity
    {
        public RepairInvoiceFormatEntity()
        {
            this.accData = new JERPData.Product.RepairInvoiceFormat();
        }
        private JERPData.Product.RepairInvoiceFormat accData;
        public int FormatID = -1;
        public string TmpSheetName = string.Empty;
        public string InvoiceCodeCellName = string.Empty;
        public string InvoiceNameCellName = string.Empty;
        public string CompanyNameCellName = string.Empty;
        public string FinanceAddressCellName = string.Empty;
        public string MoneyTypeCellName = string.Empty;
        public string InvoiceTypeCellName = string.Empty;
        public string DateNoteCellName = string.Empty;
        public string LinkmanCellName = string.Empty;
        public string TelephoneCellName = string.Empty;
        public string FaxCellName = string.Empty;
        public int ItemBeginRowIndex = -1;
        public string TotalQtyCellName = string.Empty;
        public string TotalAMTCellName = string.Empty;
        public string TaxAMTCellName = string.Empty;
        public bool FieldGroupFlag = false;
        public void LoadData(int FormatID)
        {
            this.FormatID = FormatID;
            DataTable dtbl = this.accData.GetDataRepairInvoiceFormatByFormatID(FormatID).Tables[0];
            if (dtbl.Rows.Count == 0)
            {
                this.TmpSheetName = string.Empty;
                this.InvoiceCodeCellName = string.Empty;
                this.InvoiceNameCellName = string.Empty;
                this.CompanyNameCellName = string.Empty;
                this.FinanceAddressCellName = string.Empty;
                this.MoneyTypeCellName = string.Empty;
                this.InvoiceTypeCellName = string.Empty;
                this.DateNoteCellName = string.Empty;
                this.LinkmanCellName = string.Empty;
                this.TelephoneCellName = string.Empty;
                this.FaxCellName = string.Empty;
                this.ItemBeginRowIndex = -1;
                this.TotalQtyCellName = string.Empty;
                this.TotalAMTCellName = string.Empty;
                this.TaxAMTCellName = string.Empty;
                this.FieldGroupFlag = false;
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
            if (drow["InvoiceCodeCellName"] == DBNull.Value)
            {
                this.InvoiceCodeCellName = string.Empty;
            }
            else
            {
                this.InvoiceCodeCellName = drow["InvoiceCodeCellName"].ToString();
            }
            if (drow["InvoiceNameCellName"] == DBNull.Value)
            {
                this.InvoiceNameCellName = string.Empty;
            }
            else
            {
                this.InvoiceNameCellName = drow["InvoiceNameCellName"].ToString();
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
            if (drow["MoneyTypeCellName"] == DBNull.Value)
            {
                this.MoneyTypeCellName = string.Empty;
            }
            else
            {
                this.MoneyTypeCellName = drow["MoneyTypeCellName"].ToString();
            }
            if (drow["InvoiceTypeCellName"] == DBNull.Value)
            {
                this.InvoiceTypeCellName = string.Empty;
            }
            else
            {
                this.InvoiceTypeCellName = drow["InvoiceTypeCellName"].ToString();
            }
            if (drow["DateNoteCellName"] == DBNull.Value)
            {
                this.DateNoteCellName = string.Empty;
            }
            else
            {
                this.DateNoteCellName = drow["DateNoteCellName"].ToString();
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
            if (drow["ItemBeginRowIndex"] == DBNull.Value)
            {
                this.ItemBeginRowIndex = -1;
            }
            else
            {
                this.ItemBeginRowIndex = (int)drow["ItemBeginRowIndex"];
            }
            if (drow["TotalQtyCellName"] == DBNull.Value)
            {
                this.TotalQtyCellName = string.Empty;
            }
            else
            {
                this.TotalQtyCellName = drow["TotalQtyCellName"].ToString();
            }
            if (drow["TotalAMTCellName"] == DBNull.Value)
            {
                this.TotalAMTCellName = string.Empty;
            }
            else
            {
                this.TotalAMTCellName = drow["TotalAMTCellName"].ToString();
            }
            if (drow["TaxAMTCellName"] == DBNull.Value)
            {
                this.TaxAMTCellName = string.Empty;
            }
            else
            {
                this.TaxAMTCellName = drow["TaxAMTCellName"].ToString();
            }
            if (drow["FieldGroupFlag"] == DBNull.Value)
            {
                this.FieldGroupFlag = false;
            }
            else
            {
                this.FieldGroupFlag = (bool)drow["FieldGroupFlag"];
            }
        }
    }
}