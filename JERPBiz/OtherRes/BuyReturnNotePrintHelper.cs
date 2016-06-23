using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
namespace JERPBiz.OtherRes
{
    public class BuyReturnNotePrintHelper
    {
        public BuyReturnNotePrintHelper()
        {
            this.NoteEntity = new BuyReturnNoteEntity();
            this.accItems = new JERPData.OtherRes.BuyReturnItems();
            this.SupplierEntity = new JERPBiz.General.SupplierEntity();
            this.accFormat = new JERPData.OtherRes.BuyReturnFormat();
            this.accFormatTitle = new JERPData.OtherRes.BuyReturnFieldTitle();
            this.FormatEntity = new BuyReturnFormatEntity();
            this.TmpFileName = JERPData.ServerParameter.TempletFolder + "OtherResBuyReturnNote.xlt";
         
            
        }
        private JERPBiz.OtherRes .BuyReturnNoteEntity   NoteEntity;
        private JERPData.OtherRes.BuyReturnItems accItems;
        private JERPBiz.General.SupplierEntity SupplierEntity; 
        private JERPData.OtherRes.BuyReturnFormat accFormat;
        private JERPData.OtherRes.BuyReturnFieldTitle accFormatTitle;
        private BuyReturnFormatEntity FormatEntity;
        private string TmpFileName = string.Empty;
        
        public void ExportToExcel(long NoteID)
        {
            DataTable dtblFormat = this.accFormat.GetDataBuyReturnFormat().Tables[0];
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
            if (this.FormatEntity.AddressCellName  != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.AddressCellName , this.SupplierEntity.Address );
            }
            if (this.FormatEntity.LinkmanCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.LinkmanCellName, this.SupplierEntity.Linkman);
            }
            if (this.FormatEntity.TelephoneCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.TelephoneCellName, "'" + this.SupplierEntity.Telephone);
            }
                   
            if (this.FormatEntity.MakerPsnCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.MakerPsnCellName, this.NoteEntity.MakerPsn);
            }
         
            if (this.FormatEntity.ReturnHandleTypeCellName  != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.ReturnHandleTypeCellName, this.NoteEntity.ReturnHandleTypeName );
            }
            if (this.FormatEntity.MoneyTypeCellName  != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.MoneyTypeCellName,this.NoteEntity .MoneyTypeName );
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

            DataTable dtblItems = this.accItems.GetDataBuyReturnItemsByNoteID(NoteID).Tables[0];           
            int rowIndex = this.FormatEntity.ItemRowIndex ;
            if (dtblItems.Rows.Count > this.FormatEntity.ItemRowCount)
            {
                excel.InsertRows(rowIndex, dtblItems.Rows.Count - this.FormatEntity.ItemRowCount , true);
            }
            DataTable dtblColumns = this.accFormatTitle .GetDataBuyReturnFieldTitleByFormatID (FormatID).Tables[0];
           
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
