using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
namespace JERPBiz.Material
{
    public class BuyReceiveNotePrintHelper
    {
        public BuyReceiveNotePrintHelper()
        {
            this.NoteEntity = new BuyReceiveNoteEntity();
            this.accItems = new JERPData.Material.BuyReceiveItems();
            this.accFormat = new JERPData.Material.BuyReceiveFormat();
            this.accFormatTitle = new JERPData.Material.BuyReceiveFieldTitle();
            this.FormatEntity = new BuyReceiveFormatEntity();
            this.TmpFileName = JERPData.ServerParameter.TempletFolder + "MtrBuyReceiveNote.xlt";
         
            
        }
        private JERPBiz.Material .BuyReceiveNoteEntity   NoteEntity;
        private JERPData.Material.BuyReceiveItems accItems;
        private JERPData.Material.BuyReceiveFormat accFormat;
        private JERPData.Material.BuyReceiveFieldTitle accFormatTitle;
        private BuyReceiveFormatEntity FormatEntity;
        private string TmpFileName = string.Empty;
        
        public void ExportToExcel(long NoteID)
        {
            DataTable dtblFormat = this.accFormat.GetDataBuyReceiveFormat().Tables[0];
            if (dtblFormat.Rows.Count == 0)
            {
                MessageBox.Show("对不起，未设置任何订单格式");
                return;
            }
            int FormatID=General .FrmFormat .GetFormatID (dtblFormat );          
            this.FormatEntity.LoadData(FormatID);
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(this.TmpFileName);
            this.NoteEntity.LoadData(NoteID);       
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
            if (this.FormatEntity.PONoCellName  != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.PONoCellName, "'"+this.NoteEntity.PONo );
            }   
            if (this.FormatEntity.CompanyNameCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.CompanyNameCellName, this.NoteEntity.CompanyAllName);
            }          
            if (this.FormatEntity.QCPsnCellName  != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.QCPsnCellName, this.NoteEntity.QCPsn);
            }
            if (this.FormatEntity.MakerPsnCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.MakerPsnCellName, this.NoteEntity.MakerPsn);
            }
            if (this.FormatEntity.MoneyTypeCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.MoneyTypeCellName, this.NoteEntity.MoneyTypeName);
            }
            if (this.FormatEntity.SettleTypeCellName!= string.Empty)
            {              
                excel.SetCellVal(this.FormatEntity.SettleTypeCellName ,this.NoteEntity.SettleTypeName  );
            }
            if (this.FormatEntity.PriceTypeCellName  != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.PriceTypeCellName, this.NoteEntity.PriceTypeName);
            }
            if (this.FormatEntity.InvoiceTypeCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.InvoiceTypeCellName, this.NoteEntity.InvoiceTypeName);
            }
            if ((this.FormatEntity.TotalAMTCellName  != string.Empty)&&(this.NoteEntity .TotalAMT >0))
            {
                excel.SetCellVal(this.FormatEntity.TotalAMTCellName, this.NoteEntity .TotalAMT );
            }  
            if (this.FormatEntity.MemoCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.MemoCellName, this.NoteEntity.Memo);
            }
            //开始玩明细了呀

            DataTable dtblItems = this.accItems.GetDataBuyReceiveItemsByNoteID(NoteID).Tables[0];           
            int rowIndex = this.FormatEntity.ItemRowIndex ;
            if (dtblItems.Rows.Count > this.FormatEntity.ItemRowCount)
            {
                excel.InsertRows(rowIndex, dtblItems.Rows.Count - this.FormatEntity.ItemRowCount , true);
            }
            DataTable dtblColumns = this.accFormatTitle .GetDataBuyReceiveFieldTitleByFormatID (FormatID).Tables[0];
           
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
            }
            else
            {
                excel.Show();
            }
        }

    }

}
