using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using JCommon;
using System.Data ;
namespace JERPBiz.Packing
{
    public class BoxPrinterHelper
    {
        public BoxPrinterHelper()
        {
            this.Printer = Config.ConfigInfo.GetBoxPrinter();
            this.accBoxs = new JERPData.Packing.Boxes();
            this.FormatEntity = new BoxFormatEntity();
            this.accFormatColumn = new JERPData.Packing.BoxFormatColumn();
        }
        private string Printer;
        private JERPData.Packing.Boxes accBoxs;
        private BoxFormatEntity FormatEntity;
        private DataTable dtblFormatColumn;
        private JERPData.Packing.BoxFormatColumn accFormatColumn;      
        private void ExportRow(DataRow drow, DataRow drowColumn)
        {
            int BarcodeX = (int)drowColumn["BarcodeX"];
            int BarcodeY = (int)drowColumn["BarcodeY"];
            int CaptionX = (int)drowColumn["CaptionX"];
            int CaptionY = (int)drowColumn["CaptionY"];
            string Barcode = drow["BoxCode"].ToString();
            string command = this.FormatEntity.BarcodeName 
                + " " + BarcodeX.ToString() 
                + "," + BarcodeY.ToString() 
                + ",L,"+this.FormatEntity .BarcodeVersion +",A,0,M2,S3,\"" 
                + Barcode + "\"";
            TSCPrintHelper.sendcommand(command);
            string caption = drow["PrdName"].ToString()+"[箱]";
            int FontSize = this.FormatEntity.FontSize;
            if (drowColumn["CaptionWidth"] == DBNull.Value)
            {
                TSCPrintHelper.windowsfont(CaptionX, CaptionY, FontSize, 0, 2, 0, "宋体", caption);
            }
            else
            {
                int l = caption.Length;
                int CaptionWidth = (int)drowColumn["CaptionWidth"];
                if (l <= CaptionWidth)
                {
                    TSCPrintHelper.windowsfont(CaptionX ,CaptionY ,FontSize , 0, 2, 0, "宋体", caption);
                }
                else
                {
                 
                    string prefix = caption.Substring(0, CaptionWidth );
                    TSCPrintHelper.windowsfont(CaptionX , CaptionY , FontSize , 0, 2, 0, "宋体", prefix);
                    string afterfix = caption.Remove(0, CaptionWidth);
                    TSCPrintHelper.windowsfont(CaptionX, CaptionY + FontSize,FontSize , 0, 2, 0, "宋体", afterfix);
                }
            }
            string errormsg=string .Empty ;
            this.accBoxs.UpdateBoxesForPrint(ref errormsg, drow["BoxCode"]);
        }
        
        public void Export(DataRow[] drows)
        {
            if (drows.Length == 0) return;
            this.FormatEntity.LoadData();
            this.dtblFormatColumn = this.accFormatColumn.GetDataBoxFormatColumn().Tables[0];
            if ((this.FormatEntity.FormatID == -1)
                || (this.dtblFormatColumn.Rows.Count == 0))
            {
                MessageBox.Show("未设格式参数");
                return;
            }
            DataTable dtblBarcode = drows[0].Table.Clone ();
            foreach (DataRow drow in drows)
            {
                dtblBarcode.ImportRow(drow);
                for (int i = 0; i < this.FormatEntity.Repeat; i++)
                {
                    dtblBarcode.ImportRow(drow);
                }
            }
            TSCPrintHelper.openport(this.Printer);
            TSCPrintHelper.clearbuffer();
            TSCPrintHelper.setup(
                this.FormatEntity.Width,
                this.FormatEntity.Height,
               "10",
               "10",
               "0",
               this.FormatEntity.Margin,
               this.FormatEntity.Offset);
            TSCPrintHelper.sendcommand("DIRECTION 1");
            int ln = dtblBarcode.Rows.Count;
            int irow = 0; 
            while (irow<ln)
            {
                TSCPrintHelper.clearbuffer();
                foreach (DataRow drowColumn in this.dtblFormatColumn.Rows )
                {
                    if (irow < ln)
                    {
                        this.ExportRow(dtblBarcode.Rows[irow], drowColumn);
                        irow++;
                    }
                    else
                    {
                        break;
                    }
                }
                TSCPrintHelper.printlabel("1", "1");

            } 
            TSCPrintHelper.clearbuffer();
            TSCPrintHelper.closeport();
        }

    }
}
