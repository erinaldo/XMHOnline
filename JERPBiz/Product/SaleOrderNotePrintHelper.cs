using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
namespace JERPBiz.Product
{
    public class SaleOrderNotePrintHelper
    {
        public SaleOrderNotePrintHelper()
        {
            this.NoteEntity = new SaleOrderNoteEntity();
            this.accItems = new JERPData.Product.SaleOrderItems();
            this.CustomerEntity = new JERPBiz.General.CustomerEntity();
            this.accFormat = new JERPData.Product.SaleOrderFormat();
            this.accFormatTitle = new JERPData.Product.SaleOrderFieldTitle();
            this.FormatEntity = new SaleOrderFormatEntity();
            this.TmpFileName = JERPData.ServerParameter.TempletFolder + "SaleOrderNote.xlt";
         
            
        }
        private JERPBiz.Product .SaleOrderNoteEntity   NoteEntity;
        private JERPData.Product.SaleOrderItems accItems;
        private JERPBiz.General.CustomerEntity CustomerEntity; 
        private JERPData.Product.SaleOrderFormat accFormat;
        private JERPData.Product.SaleOrderFieldTitle accFormatTitle;
        private SaleOrderFormatEntity FormatEntity;
        private string TmpFileName = string.Empty;
        
        public void ExportToExcel(long NoteID)
        {
            DataTable dtblFormat = this.accFormat.GetDataSaleOrderFormat().Tables[0];
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
            this.CustomerEntity.LoadData(this.NoteEntity.CompanyID);
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
            if (this.FormatEntity.PONoCellName   != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.PONoCellName , this.NoteEntity.PONo  );
            }
      
            if (this.FormatEntity.DateNoteCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.DateNoteCellName, this.NoteEntity.DateNote.ToShortDateString());
            }
            if (this.FormatEntity.CompanyNameCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.CompanyNameCellName, this.CustomerEntity.CompanyAllName);
            }
            if (this.FormatEntity.LegalPersonCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.LegalPersonCellName, this.CustomerEntity.LegalPerson);
            }
            if (this.FormatEntity.LinkmanCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.LinkmanCellName, this.CustomerEntity.Linkman);
            }
            if (this.FormatEntity.TelephoneCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.TelephoneCellName, "'" + this.CustomerEntity.Telephone);
            }
            if (this.FormatEntity.FaxCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.FaxCellName, "'" + this.CustomerEntity.Fax);
            }          
            if (this.FormatEntity.DeliverAddressCellName  != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.DeliverAddressCellName , this.NoteEntity.DeliverAddress );
            }          
            if (this.FormatEntity.FinanceAddressCellName  != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.FinanceAddressCellName, this.NoteEntity.FinanceAddress );
            }
            if (this.FormatEntity.MakerPsnCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.MakerPsnCellName, this.NoteEntity.MakerPsn);
            }
            if (this.FormatEntity.SalePsnCellName  != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.SalePsnCellName , this.NoteEntity.SalePsn);
            }
            if (this.FormatEntity.DeliverTypeCellName  != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.DeliverTypeCellName, this.NoteEntity.DeliverTypeName );
            } 
            if (this.FormatEntity.ExpressRequireCellName  != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.ExpressRequireCellName, this.NoteEntity.ExpressRequire );
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
            if (this.FormatEntity.MemoCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.MemoCellName, this.NoteEntity.Memo);
            }
            if (this.FormatEntity.TotalAMTCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.TotalAMTCellName, this.NoteEntity.TotalAMT);
            }
            //开始玩明细了呀

            DataTable dtblItems = this.accItems.GetDataSaleOrderItemsByNoteID(NoteID).Tables[0];
           
            int rowIndex = this.FormatEntity.ItemRowIndex ;
            if (dtblItems.Rows.Count > this.FormatEntity.ItemRowCount)
            {
                excel.InsertRows(rowIndex, dtblItems.Rows.Count - this.FormatEntity.ItemRowCount , true);
            }
            DataTable dtblColumns = this.accFormatTitle .GetDataSaleOrderFieldTitleByFormatID (FormatID).Tables[0];
           
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
            excel.Show();
        }

    }

}
