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
namespace JERPBiz.Packing
{
    /// <描述>
    /// 表[BoxFormat]数据实体类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2015/11/30 9:58:28
    ///</时间>  
    public class BoxFormatEntity
    {
        public BoxFormatEntity()
        {
            this.accData = new JERPData.Packing.BoxFormat();
        }
        private JERPData.Packing.BoxFormat accData;
        public int FormatID = -1;
        public string Width = string.Empty;
        public string Height = string.Empty;
        public string Margin = string.Empty;
        public string Offset = string.Empty;
        public string BarcodeName = string.Empty;
        public string BarcodeVersion = string.Empty;
        public int FontSize = -1;
        public int Repeat = -1;
        public void LoadData()
        {
           
            DataTable dtbl = this.accData.GetDataBoxFormat().Tables[0];
            if (dtbl.Rows.Count == 0)
            {
                this.FormatID = -1;
                this.Width = string.Empty;
                this.Height = string.Empty;
                this.Margin = string.Empty;
                this.Offset = string.Empty;
                this.BarcodeName = string.Empty;
                this.BarcodeVersion = string.Empty;
                this.FontSize = -1;
                this.Repeat = -1;
                return;
            }
            DataRow drow = dtbl.Rows[0];
            this.FormatID = 1;
            if (drow["Width"] == DBNull.Value)
            {
                this.Width = string.Empty;
            }
            else
            {
                this.Width = drow["Width"].ToString();
            }
            if (drow["Height"] == DBNull.Value)
            {
                this.Height = string.Empty;
            }
            else
            {
                this.Height = drow["Height"].ToString();
            }
            if (drow["Margin"] == DBNull.Value)
            {
                this.Margin = string.Empty;
            }
            else
            {
                this.Margin = drow["Margin"].ToString();
            }
            if (drow["Offset"] == DBNull.Value)
            {
                this.Offset = string.Empty;
            }
            else
            {
                this.Offset = drow["Offset"].ToString();
            }
            if (drow["BarcodeName"] == DBNull.Value)
            {
                this.BarcodeName = string.Empty;
            }
            else
            {
                this.BarcodeName = drow["BarcodeName"].ToString();
            }
            if (drow["BarcodeVersion"] == DBNull.Value)
            {
                this.BarcodeVersion = string.Empty;
            }
            else
            {
                this.BarcodeVersion = drow["BarcodeVersion"].ToString();
            }
            if (drow["FontSize"] == DBNull.Value)
            {
                this.FontSize = -1;
            }
            else
            {
                this.FontSize = (int)drow["FontSize"];
            }
            if (drow["Repeat"] == DBNull.Value)
            {
                this.Repeat = -1;
            }
            else
            {
                this.Repeat = (int)drow["Repeat"];
            }
        }
    }
}