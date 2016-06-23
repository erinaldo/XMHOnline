using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
namespace JERPBiz.Tool
{
    public class BuyOrderNotePrintHelper
    {
        public BuyOrderNotePrintHelper()
        {
            this.NoteEntity = new BuyOrderNoteEntity();
            this.accItems = new JERPData.Tool.BuyOrderItems();
            this.SupplierEntity = new JERPBiz.General.SupplierEntity();
            this.accFormat = new JERPData.Tool.BuyOrderFormat();
            this.accFormatTitle = new JERPData.Tool.BuyOrderFieldTitle();
            this.FormatEntity = new BuyOrderFormatEntity();
            this.TmpFileName = JERPData.ServerParameter.TempletFolder + "ToolBuyOrderNote.xlt";
         
            
        }
        private JERPBiz.Tool .BuyOrderNoteEntity   NoteEntity;
        private JERPData.Tool.BuyOrderItems accItems;
        private JERPBiz.General.SupplierEntity SupplierEntity; 
        private JERPData.Tool.BuyOrderFormat accFormat;
        private JERPData.Tool.BuyOrderFieldTitle accFormatTitle;
        private BuyOrderFormatEntity FormatEntity;
        private string TmpFileName = string.Empty;
        
        public void ExportToExcel(long NoteID)
        {
            DataTable dtblFormat = this.accFormat.GetDataBuyOrderFormat().Tables[0];
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
            if (this.FormatEntity.LegalPersonCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.LegalPersonCellName, this.SupplierEntity.LegalPerson);
            }
            if (this.FormatEntity.LinkmanCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.LinkmanCellName, this.SupplierEntity.Linkman);
            }
            if (this.FormatEntity.TelephoneCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.TelephoneCellName, "'" + this.SupplierEntity.Telephone);
            }
            if (this.FormatEntity.FaxCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.FaxCellName, "'" + this.SupplierEntity.Fax);
            }
            if (this.FormatEntity.SupplierAddressCellName   != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.SupplierAddressCellName  , "'" + this.SupplierEntity.Address);
            }
            if (this.FormatEntity.DeliverAddressCellName  != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.DeliverAddressCellName ,this.NoteEntity .DeliverAddress);
            }
            if (this.FormatEntity.DeliverTypeCellName  != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.DeliverTypeCellName , this.NoteEntity.DeliverTypeName );
            } 
            if (this.FormatEntity.ExpressRequireCellName  != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.ExpressRequireCellName, this.NoteEntity.ExpressRequire );
            } 

            if (this.FormatEntity.MakerPsnCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.MakerPsnCellName, this.NoteEntity.MakerPsn);
            }
            if (this.FormatEntity.ConfirmPsnCellName != string.Empty)
            {
                //图片路径
                string dir = JERPData.ServerParameter.ERPFileFolder + @"\Hr\SignImg\" + this.NoteEntity.ConfirmPsnID.ToString();
                if (System.IO.Directory.Exists(dir))
                {
                    string[] AllFiles = System.IO.Directory.GetFiles(dir);
                    if (AllFiles.Length > 0)
                    {
                        excel.InsertPicture(this.FormatEntity.ConfirmPsnCellName,
                            AllFiles[0]);
                    }
                }
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
            if (this.FormatEntity.InvoiceTypeCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.InvoiceTypeCellName, this.NoteEntity.InvoiceTypeName);
            }
            if (this.FormatEntity.MemoCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.MemoCellName, this.NoteEntity.Memo);
            }
            //开始玩明细了呀

            DataTable dtblItems = this.accItems.GetDataBuyOrderItemsByNoteID(NoteID).Tables[0];          
            int rowIndex = this.FormatEntity.ItemRowIndex ;
            if (dtblItems.Rows.Count > this.FormatEntity.ItemRowCount)
            {
                excel.InsertRows(rowIndex, dtblItems.Rows.Count - this.FormatEntity.ItemRowCount , true);
            }
            DataTable dtblColumns = this.accFormatTitle .GetDataBuyOrderFieldTitleByFormatID (FormatID).Tables[0];
           
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
