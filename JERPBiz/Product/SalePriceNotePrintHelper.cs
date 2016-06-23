using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
namespace JERPBiz.Product
{
    public class SalePriceNotePrintHelper
    {
        public SalePriceNotePrintHelper()
        {
            this.Printer = Config.ConfigInfo.GetNotePrinter();
            this.accItems = new JERPData.Product.SalePriceItems();
            this.NoteEntity = new JERPBiz.Product.SalePriceNoteEntity();
            this.CustomerEntity = new JERPBiz.General.CustomerEntity();
        }


        private JERPData.Product.SalePriceItems accItems;
        private JERPBiz.Product.SalePriceNoteEntity NoteEntity;
        private JERPBiz.General.CustomerEntity CustomerEntity;
        private Office2003Helper.Excel2003 excel;
        public string Printer = string.Empty;
      
        private string GetPrdInfor(string PrdName, string PrdSpec)
        {
            string rut = string.Empty;
            if (PrdName != string.Empty)
            {
                rut = PrdName;
            }
          
            if (PrdSpec != string.Empty)
            {
                if (rut != string.Empty)
                {
                    rut += @"
" + PrdSpec;
                }
                else
                {
                    rut = PrdSpec;
                }
            }
            return rut;
        }
        public void ExportToExcel(long  NoteID)
        {
            this.NoteEntity .LoadData(NoteID);
            this.CustomerEntity.LoadData(this.NoteEntity.CompanyID);
            excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"SalePriceNote.xlt");
            excel.SetCellVal("C4", this.CustomerEntity.CompanyAllName);
            excel.SetCellVal("B5", "'"+this.CustomerEntity.Telephone );
            excel.SetCellVal("E5", "'" + this.CustomerEntity.Fax );
            excel.SetCellVal("B6", "'" + this.NoteEntity.MoneyTypeName );
            excel.SetCellVal("D6", "'" + this.NoteEntity .SettleTypeName );
            excel.SetCellVal("G6", "'" + this.NoteEntity.PriceTypeName );
            excel.SetCellVal("J6", this.NoteEntity.DateNote.ToShortDateString ());
            excel.SetCellVal("A21", this.NoteEntity.Memo );
            excel.SetCellVal("A36", this.NoteEntity.DateNote .Year .ToString ()+"年___月___日");
            excel.SetCellVal("I36",this.NoteEntity.DateNote .Year .ToString ()+"年___月___日");
            //考虑一下如果超出第一页就要copy格式
            DataTable dtblItems = this.accItems.GetDataSalePriceItemsByNoteID (NoteID).Tables[0];
            
            if (dtblItems.Rows.Count > 11)
            {
                excel.InsertRows(10, dtblItems.Rows.Count - 11, true);
            }
            int No = 1;
            int rowIndex = 9;
            foreach (DataRow drow in dtblItems.Rows)
            {

                excel.SetCellVal("A" + rowIndex.ToString(), No);
                excel.SetCellVal("B" + rowIndex.ToString(), drow["PrdCode"]);                
                excel.SetCellVal("D" + rowIndex.ToString(), this.GetPrdInfor (drow["PrdName"].ToString (),drow["PrdSpec"].ToString ()));
                excel.SetCellVal("F" + rowIndex.ToString(), drow["UnitName"]); 
                excel.SetCellVal("H" + rowIndex.ToString(), drow["Price"]);
                excel.SetCellVal("I" + rowIndex.ToString(), drow["Memo"]);
                rowIndex++;
                No++;
            }
           
            excel.Show();
           
        }
    }

}
