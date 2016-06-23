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
    /// 表[RepairDeliverFormat]数据实体类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2015/9/3 22:19:40
    ///</时间>  
    public class RepairDeliverFormatEntity
    {
        public RepairDeliverFormatEntity()
        {
            this.accData = new JERPData.Product.RepairDeliverFormat();
        }
        private JERPData.Product.RepairDeliverFormat accData;
        public int FormatID = -1;
        public string TmpSheetName = string.Empty;
        public string NoteCodeCellName = string.Empty;
        public string CompanyNameCellName = string.Empty;
        public string DateNoteCellName = string.Empty;
        public string DeliverAddressCellName = string.Empty;
        public string FinanceAddressCellName = string.Empty;
        public string LinkmanCellName = string.Empty;
        public string TelephoneCellName = string.Empty;
        public string DeliverPsnCellName = string.Empty;
        public string SettleTypeCellName = string.Empty;
        public string MoneyTypeCellName = string.Empty;
        public string PriceTypeCellName = string.Empty;
        public string TotalAMTCellName = string.Empty;
        public string MakerPsnCellName = string.Empty;
        public string MemoCellName = string.Empty;
        public int ItemRowIndex = -1;
        public int ItemRowCount = -1;
        public void LoadData(int FormatID)
        {
            this.FormatID = FormatID;
            DataTable dtbl = this.accData.GetDataRepairDeliverFormatByFormatID(FormatID).Tables[0];
            if (dtbl.Rows.Count == 0)
            {
                this.TmpSheetName = string.Empty;
                this.NoteCodeCellName = string.Empty;
                this.CompanyNameCellName = string.Empty;
                this.DateNoteCellName = string.Empty;
                this.DeliverAddressCellName = string.Empty;
                this.FinanceAddressCellName = string.Empty;
                this.LinkmanCellName = string.Empty;
                this.TelephoneCellName = string.Empty;
                this.DeliverPsnCellName = string.Empty;
                this.SettleTypeCellName = string.Empty;
                this.MoneyTypeCellName = string.Empty;
                this.PriceTypeCellName = string.Empty;
                this.TotalAMTCellName = string.Empty;
                this.MakerPsnCellName = string.Empty;
                this.MemoCellName = string.Empty;
                this.ItemRowIndex = -1;
                this.ItemRowCount = -1;
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
            if (drow["CompanyNameCellName"] == DBNull.Value)
            {
                this.CompanyNameCellName = string.Empty;
            }
            else
            {
                this.CompanyNameCellName = drow["CompanyNameCellName"].ToString();
            }
            if (drow["DateNoteCellName"] == DBNull.Value)
            {
                this.DateNoteCellName = string.Empty;
            }
            else
            {
                this.DateNoteCellName = drow["DateNoteCellName"].ToString();
            }
            if (drow["DeliverAddressCellName"] == DBNull.Value)
            {
                this.DeliverAddressCellName = string.Empty;
            }
            else
            {
                this.DeliverAddressCellName = drow["DeliverAddressCellName"].ToString();
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
            if (drow["DeliverPsnCellName"] == DBNull.Value)
            {
                this.DeliverPsnCellName = string.Empty;
            }
            else
            {
                this.DeliverPsnCellName = drow["DeliverPsnCellName"].ToString();
            }
            if (drow["SettleTypeCellName"] == DBNull.Value)
            {
                this.SettleTypeCellName = string.Empty;
            }
            else
            {
                this.SettleTypeCellName = drow["SettleTypeCellName"].ToString();
            }
            if (drow["MoneyTypeCellName"] == DBNull.Value)
            {
                this.MoneyTypeCellName = string.Empty;
            }
            else
            {
                this.MoneyTypeCellName = drow["MoneyTypeCellName"].ToString();
            }
            if (drow["PriceTypeCellName"] == DBNull.Value)
            {
                this.PriceTypeCellName = string.Empty;
            }
            else
            {
                this.PriceTypeCellName = drow["PriceTypeCellName"].ToString();
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
            if (drow["MemoCellName"] == DBNull.Value)
            {
                this.MemoCellName = string.Empty;
            }
            else
            {
                this.MemoCellName = drow["MemoCellName"].ToString();
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