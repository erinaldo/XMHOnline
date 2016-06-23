using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
namespace JERPBiz.Product
{
    public class SaleDeliverPrintHelper
    {
        public SaleDeliverPrintHelper()
        {
            this.accDeliverFormat = new JERPData.Product.SaleDeliverFormat();
            this.accDeliverTitle = new JERPData.Product.SaleDeliverFieldTitle();
            this.accDeliverItems = new JERPData.Product.SaleDeliverItems();
            this.accDeliverFormat = new JERPData.Product.SaleDeliverFormat();
            this.CustomerEntity = new JERPBiz.General.CustomerEntity();
            this.DeliverNoteEntity = new SaleDeliverNoteEntity();
            this.accFormat = new JERPData.Product.SaleDeliverFormat();
            this.DeliverAddressEntity = new JERPBiz.General.DeliverAddressEntity();
            this.FormatEntity = new SaleDeliverFormatEntity();
            this.Printer = Config.ConfigInfo.GetNotePrinter();
        }

        private JERPData.Product.SaleDeliverFormat accDeliverFormat;
        private JERPData.Product.SaleDeliverFieldTitle accDeliverTitle;
        private JERPData.Product.SaleDeliverItems accDeliverItems;
        private JERPData.Product.SaleDeliverFormat accFormat;
        private JERPBiz.General.CustomerEntity CustomerEntity;
        private JERPBiz.General.DeliverAddressEntity DeliverAddressEntity;
        private SaleDeliverNoteEntity DeliverNoteEntity;
        private SaleDeliverFormatEntity FormatEntity;
        private Office2003Helper.Excel2003 excel;
        public  string Printer = string.Empty;
        public void ExportToExcel(long  NoteID)
        {
            this.DeliverNoteEntity.LoadData(NoteID);
            DataTable dtblFormat = this.accFormat.GetDataSaleDeliverFormatByCompanyID(this.DeliverNoteEntity.CompanyID).Tables[0];
            if (dtblFormat.Rows.Count == 0)
            {
                MessageBox.Show("对不起，未设置任何送货格式");
                return;
            }
            int FormatID = General.FrmFormat.GetFormatID(dtblFormat);          
            this.FormatEntity.LoadData(FormatID);
            this.CustomerEntity.LoadData(this.DeliverNoteEntity.CompanyID);
            this.DeliverAddressEntity.LoadData(this.DeliverNoteEntity.DeliverAddressID);
            excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + "SaleDeliverNote.xlt");
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
                excel.SetCellVal(this.FormatEntity.NoteCodeCellName, this.DeliverNoteEntity.NoteCode);
            } 
          
            if (this.FormatEntity.DateNoteCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.DateNoteCellName, this.DeliverNoteEntity.DateNote.ToShortDateString());
            }

            if (this.FormatEntity.PONoCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.PONoCellName, "'"+this.DeliverNoteEntity.PONo);
            }
            if (this.FormatEntity.CompanyNameCellName  != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.CompanyNameCellName, this.DeliverNoteEntity.CompanyAllName  );
            }
            if (this.FormatEntity.MoneyTypeCellName  != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.MoneyTypeCellName, "'" + this.DeliverNoteEntity.MoneyTypeName );
            }
            if (this.FormatEntity.SettleTypeCellName  != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.SettleTypeCellName, this.DeliverNoteEntity .SettleTypeName );
            } 
            if (this.FormatEntity.PriceTypeCellName  != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.PriceTypeCellName , this.DeliverNoteEntity.PriceTypeName );
            }
            if (this.FormatEntity.InvoiceTypeCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.InvoiceTypeCellName, this.DeliverNoteEntity.InvoiceTypeName);
            }
            if (this.FormatEntity.LinkmanCellName  != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.LinkmanCellName , this.DeliverAddressEntity .Linkman );
            }
            if (this.FormatEntity.TelephoneCellName  != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.TelephoneCellName , "'"+this.DeliverAddressEntity .Telephone );
            } 
            if (this.FormatEntity.DeliverAddressCellName   != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.DeliverAddressCellName , this.DeliverAddressEntity.Address );
            }
            if (this.FormatEntity.DeliverPsnCellName  != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.DeliverPsnCellName , this.DeliverNoteEntity.DeliverPsn );
            }
        
            if (this.FormatEntity.SalePsnCellName  != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.SalePsnCellName , this.DeliverNoteEntity.SalePsn );
            }
            if (this.FormatEntity.MakerPsnCellName  != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.MakerPsnCellName, this.DeliverNoteEntity.MakerPsn );
            }
            if (this.FormatEntity.MemoCellName  != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.MemoCellName , this.DeliverNoteEntity.Memo );
            }
           
         
            //考虑一下如果超出第一页就要copy格式
            DataTable dtblItems = this.accDeliverItems.GetDataSaleDeliverItemsByNoteID(NoteID).Tables[0];
            if (this.FormatEntity.TotalAMTCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.TotalAMTCellName, dtblItems.Compute("SUM(ItemAMT)", ""));
            }
            if (this.FormatEntity.TotalQtyCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.TotalQtyCellName , dtblItems .Compute ("SUM(Quantity)",""));
            }
             DataTable dtblColumns = this.accDeliverTitle.GetDataSaleDeliverFieldTitleByFormatID(FormatID).Tables[0];
            int RowCount = dtblItems.Rows.Count;
            int ItemRowCount = this.FormatEntity.ItemRowCount; 
            /////开始玩明细了呀           
            int rowIndex = this.FormatEntity.ItemRowIndex;
            if (RowCount > ItemRowCount)
            {
                excel.InsertRows(rowIndex, RowCount-ItemRowCount, true);
            }
            int No = 0; 
            for (int irow = 0; irow <dtblItems .Rows .Count ; irow++)
            {
                DataRow drow = dtblItems.Rows[irow] ;      
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
                    
                        values = column["Fieldlist"].ToString().Split('+');
                        for (int i = 0; i < values.Length; i++)
                        {
                            if (i == 0)
                            {
                                value = drow[values[i]].ToString();
                            }
                            else
                            {
                                if (drow[values[i]] != DBNull.Value)
                                {
                                    value += "\n" + drow[values[i]].ToString();
                                }
                            }
                        }
                      
                    }
                    excel.SetCellVal(columnName + rowIndex.ToString(), value);
                } 
                rowIndex++;
                
               
            }
            excel.Printer = this.Printer;
            DialogResult rlt = MessageBox.Show("直接打印吗！\n是，确认；否，取消!", "操作确认",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rlt == DialogResult.Yes)
            {
              
               excel.PrintCurSheet();
               excel.Dispose();
            }
            else
            {
               excel.Show();
            }
        }
    }

}
