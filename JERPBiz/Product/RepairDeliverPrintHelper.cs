using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
namespace JERPBiz.Product
{
    public class RepairDeliverPrintHelper
    {
        public RepairDeliverPrintHelper()
        {
            this.accDeliverFormat = new JERPData.Product.RepairDeliverFormat();
            this.accDeliverTitle = new JERPData.Product.RepairDeliverFieldTitle();
            this.accDeliverItems = new JERPData.Product.RepairDeliverItems();
            this.accDeliverFormat = new JERPData.Product.RepairDeliverFormat();
            this.CustomerEntity = new JERPBiz.General.CustomerEntity();
            this.DeliverNoteEntity = new RepairDeliverNoteEntity();
            this.accFormat = new JERPData.Product.RepairDeliverFormat();
            this.FormatEntity = new RepairDeliverFormatEntity();
            this.DeliverAddressEntity = new JERPBiz.General.DeliverAddressEntity();
            this.Printer = Config.ConfigInfo.GetNotePrinter();
        }

        private JERPData.Product.RepairDeliverFormat accDeliverFormat;
        private JERPData.Product.RepairDeliverFieldTitle accDeliverTitle;
        private JERPData.Product.RepairDeliverItems accDeliverItems;
        private JERPData.Product.RepairDeliverFormat accFormat;
        private JERPBiz.General.CustomerEntity CustomerEntity;
        private RepairDeliverNoteEntity DeliverNoteEntity;
        private RepairDeliverFormatEntity FormatEntity;
        private JERPBiz.General.DeliverAddressEntity DeliverAddressEntity;
        private Office2003Helper.Excel2003 excel;
        public  string Printer = string.Empty;
        public void ExportToExcel(long  NoteID)
        {
            this.DeliverNoteEntity.LoadData(NoteID);
            DataTable dtblFormat = this.accFormat.GetDataRepairDeliverFormatByCompanyID(this.DeliverNoteEntity.CompanyID).Tables[0];
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
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder  + "RepairDeliverNote.xlt");
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
           
            if (this.FormatEntity.CompanyNameCellName  != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.CompanyNameCellName, this.DeliverNoteEntity.CompanyAllName);
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
           
            if (this.FormatEntity.MoneyTypeCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.MoneyTypeCellName, "'" + this.DeliverNoteEntity.MoneyTypeName);
            }
            if (this.FormatEntity.SettleTypeCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.SettleTypeCellName, this.DeliverNoteEntity.SettleTypeName);
            }
            if (this.FormatEntity.PriceTypeCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.PriceTypeCellName, this.DeliverNoteEntity.PriceTypeName);
            }
            if (this.FormatEntity.MakerPsnCellName  != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.MakerPsnCellName, this.DeliverNoteEntity.MakerPsn );
            }
            if (this.FormatEntity.MemoCellName  != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.MemoCellName , this.DeliverNoteEntity.Memo );
            }
            if (this.FormatEntity.TotalAMTCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.TotalAMTCellName, this.DeliverNoteEntity.TotalAMT);
            }
         
            //考虑一下如果超出第一页就要copy格式
            DataTable dtblItems = this.accDeliverItems.GetDataRepairDeliverItemsByNoteID(NoteID).Tables[0];      
             DataTable dtblColumns = this.accDeliverTitle.GetDataRepairDeliverFieldTitleByFormatID(FormatID).Tables[0];
            int RowCount = dtblItems.Rows.Count;
            int ItemRowCount = this.FormatEntity.ItemRowCount;
           
            /////开始玩明细了呀           
            int rowIndex = this.FormatEntity.ItemRowIndex;
            if (RowCount > ItemRowCount)
            {
                excel.InsertRows(rowIndex, RowCount - ItemRowCount, true);
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
                                value += "\n" + drow[values[i]].ToString();
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
