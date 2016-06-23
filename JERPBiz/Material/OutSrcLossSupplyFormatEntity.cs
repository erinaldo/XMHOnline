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
    /// 表[OutSrcLossSupplyFormat]数据实体类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2015/11/8 17:01:07
    ///</时间>  
    public class OutSrcLossSupplyFormatEntity
    {
        public OutSrcLossSupplyFormatEntity()
        {
            this.accData = new JERPData.Material.OutSrcLossSupplyFormat();
        }
        private JERPData.Material.OutSrcLossSupplyFormat accData;
        public int FormatID = -1;
        public string TmpSheetName = string.Empty;
        public string NoteCodeCellName = string.Empty;
        public string DateNoteCellName = string.Empty;
        public string SupplierCellName = string.Empty;
        public string SupplierAddressCellName = string.Empty;
        public string LinkmanCellName = string.Empty;
        public string TelephoneCellName = string.Empty;
        public string FaxCellName = string.Empty;
        public string MakerPsnCellName = string.Empty;
        public string MemoCellName = string.Empty;
        public int ItemRowIndex = -1;
        public int ItemRowCount = -1;
        public void LoadData(int FormatID)
        {
            this.FormatID = FormatID;
            DataTable dtbl = this.accData.GetDataOutSrcLossSupplyFormatByFormatID(FormatID).Tables[0];
            if (dtbl.Rows.Count == 0)
            {
                this.TmpSheetName = string.Empty;
                this.NoteCodeCellName = string.Empty;
                this.DateNoteCellName = string.Empty;
                this.SupplierCellName = string.Empty;
                this.SupplierAddressCellName = string.Empty;
                this.LinkmanCellName = string.Empty;
                this.TelephoneCellName = string.Empty;
                this.FaxCellName = string.Empty;
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
            if (drow["DateNoteCellName"] == DBNull.Value)
            {
                this.DateNoteCellName = string.Empty;
            }
            else
            {
                this.DateNoteCellName = drow["DateNoteCellName"].ToString();
            }
            if (drow["SupplierCellName"] == DBNull.Value)
            {
                this.SupplierCellName = string.Empty;
            }
            else
            {
                this.SupplierCellName = drow["SupplierCellName"].ToString();
            }
            if (drow["SupplierAddressCellName"] == DBNull.Value)
            {
                this.SupplierAddressCellName = string.Empty;
            }
            else
            {
                this.SupplierAddressCellName = drow["SupplierAddressCellName"].ToString();
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