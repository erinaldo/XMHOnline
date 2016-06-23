using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
namespace JERPBiz.Manufacture
{
    public class OutSrcOrderNotePrintHelper
    {
        public OutSrcOrderNotePrintHelper()
        {
            this.NoteEntity = new OutSrcOrderNoteEntity();
            this.accItems = new JERPData.Manufacture.OutSrcOrderItems();
            this.SupplierEntity = new JERPBiz.General.SupplierEntity();
            this.accFormat = new JERPData.Manufacture.OutSrcOrderFormat();
            this.accFormatTitle = new JERPData.Manufacture.OutSrcOrderFieldTitle();
            this.FormatEntity = new OutSrcOrderFormatEntity();
            this.TmpFileName = JERPData.ServerParameter.TempletFolder + "OutSrcOrderNote.xlt";
         
            
        }
        private JERPBiz.Manufacture .OutSrcOrderNoteEntity   NoteEntity;
        private JERPData.Manufacture.OutSrcOrderItems accItems;
        private JERPBiz.General.SupplierEntity SupplierEntity; 
        private JERPData.Manufacture.OutSrcOrderFormat accFormat;
        private JERPData.Manufacture.OutSrcOrderFieldTitle accFormatTitle;
        private OutSrcOrderFormatEntity FormatEntity;
        private string TmpFileName = string.Empty;
       
        public void ExportToExcel(long NoteID)
        {
            DataTable dtblFormat = this.accFormat.GetDataOutSrcOrderFormat().Tables[0];
            if (dtblFormat.Rows.Count == 0)
            {
                MessageBox.Show("对不起，未设置任何订单格式");
                return;
            } 
            int FormatID = General.FrmFormat.GetFormatID(dtblFormat);  
            this.FormatEntity.LoadData(FormatID);
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(this.TmpFileName);
            this.NoteEntity.LoadData(NoteID);
            this.SupplierEntity.LoadData(this.NoteEntity.CompanyID);
            //先把周边的搞定
            for (int i = 1; i <= excel.GetSheetsCount(); i++)
            {
                if (excel.GetSheetName(i).Trim() != FormatEntity.TmpSheetName)
                {
                    excel.DeleteSheet(i);
                    i--;
                }
            }
            excel.SetCurSheet(FormatEntity.TmpSheetName);
            if (this.FormatEntity.NoteCodeCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.NoteCodeCellName, this.NoteEntity.NoteCode);
            }
            if (this.FormatEntity.DateNoteCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.DateNoteCellName, this.NoteEntity.DateNote.ToShortDateString());
            }
            if (this.FormatEntity.CompanyNameCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.CompanyNameCellName, this.SupplierEntity.CompanyAllName);
            } 
            if (this.FormatEntity.OrderTypeCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.OrderTypeCellName, this.NoteEntity.OrderTypeName);
            }          
            if (this.FormatEntity.SupplierAddressCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.SupplierAddressCellName,  this.NoteEntity .SupplierAddress );
            }
            if (this.FormatEntity.DeliverAddressCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.DeliverAddressCellName, this.NoteEntity.DeliverAddress);
            }
            if (this.FormatEntity.DeliverTypeCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.DeliverTypeCellName, this.NoteEntity.DeliverTypeName);
            }
            if (this.FormatEntity.ExpressRequireCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.ExpressRequireCellName, this.NoteEntity.ExpressRequire);
            } 
        
            if (this.FormatEntity.LinkmanCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.LinkmanCellName, this.SupplierEntity.Linkman);
            }
            if (this.FormatEntity.TelephoneCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.TelephoneCellName, "'" + this.SupplierEntity.Telephone);
            }
                   
          
            if (this.FormatEntity.MoneyTypeCellName  != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.MoneyTypeCellName, this.NoteEntity.MoneyTypeName );
            }
            if (this.FormatEntity.SettleTypeCellName  != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.SettleTypeCellName, this.NoteEntity.SettleTypeName );
            }
            if (this.FormatEntity.PriceTypeCellName  != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.PriceTypeCellName , this.NoteEntity.PriceTypeName );
            }
            if (this.FormatEntity.InvoiceTypeCellName  != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.InvoiceTypeCellName, this.NoteEntity.InvoiceTypeName );
            }
            if (this.FormatEntity.MemoCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.MemoCellName, this.NoteEntity.Memo);
            }
            if (this.FormatEntity.MakerPsnCellName  != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.MakerPsnCellName, this.NoteEntity.MakerPsn );
            }
           
         
            //开始玩明细了呀

            DataTable dtblItems = this.accItems.GetDataOutSrcOrderItemsByNoteID(NoteID).Tables[0];           
            int rowIndex = this.FormatEntity.ItemRowIndex ;
            if (dtblItems.Rows.Count > this.FormatEntity.ItemRowCount)
            {
                excel.InsertRows(rowIndex, dtblItems.Rows.Count - this.FormatEntity.ItemRowCount , true);
            }
            DataTable dtblColumns = this.accFormatTitle .GetDataOutSrcOrderFieldTitleByFormatID (FormatID).Tables[0];
           
            int No = 0;
            for (int irow = 0; irow < dtblItems.Rows.Count; irow++)
            {
                DataRow drow = dtblItems.Rows[irow];
                No++;
                foreach (DataRow column in dtblColumns.Rows)
                {
                    string columnName = column["ColumnName"].ToString();
                    //如果没有，不用管它
                    string value = string.Empty;
                    string[] values;
                    //序号
                    if ((bool)column["SerialNoFlag"])
                    {
                        value = No.ToString();
                    }
                    else
                    {
                        if (column["Fieldlist"].ToString() == string.Empty) continue;
                        values = column["Fieldlist"].ToString().Split('+');
                        for (int i = 0; i < values.Length; i++)
                        {
                            if (i == 0)
                            {
                                value = drow[values[i]].ToString();
                            }
                            else
                            {
                                value += "\n" + drow[values[i]].ToString();
                            }
                        }
                    }
                    excel.SetCellVal(columnName + rowIndex.ToString(), value);
                }   
                rowIndex++;
            }
         
            excel.Printer = Config.ConfigInfo.GetNotePrinter();
            DialogResult rlt = MessageBox.Show("直接打印吗！\n是，确认；否，取消!", "操作确认",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rlt == DialogResult.Yes)
            {
                excel.PrintCurSheet();
                excel.Dispose();
                return;
            }             
            excel.Show();
        }

    }

}
