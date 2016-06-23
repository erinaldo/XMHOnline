using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
namespace JERPBiz.Product
{
    public class SaleReceiptPrintHelper
    {
        public SaleReceiptPrintHelper()
        {
            this.accReceipt = new JERPData.Product.SaleReceiptNotes();
            this.accFormat = new JERPData.Product.SaleReceiptFormat();
            this.ReceiptNoteEntity = new SaleReceiptNoteEntity();
            this.TmpFileName = JERPData.ServerParameter.TempletFolder + "SaleReceiptNote.xlt";
            this.FormatEntity = new SaleReceiptFormatEntity();
            
        }
        private JERPData.Product.SaleReceiptFormat accFormat;
        private JERPData.Product.SaleReceiptNotes accReceipt;
        private SaleReceiptNoteEntity ReceiptNoteEntity;
        private SaleReceiptFormatEntity FormatEntity;
        private string TmpFileName = string.Empty;
        private Office2003Helper.Excel2003 excel;
        public void ExportToExcel(long NoteID)
        {
         
            DataTable dtblFormat = this.accFormat.GetDataSaleReceiptFormat ().Tables[0];
            if (dtblFormat.Rows.Count == 0)
            {
                MessageBox.Show("对不起，未设置任何送货格式");
                return;
            }
            int FormatID = General.FrmFormat.GetFormatID(dtblFormat);
            this.FormatEntity.LoadData(FormatID);        
            excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(this.TmpFileName);
            for (int i = 1; i <= excel.GetSheetsCount(); i++)
            {
                if (excel.GetSheetName(i).Trim() != FormatEntity.TmpSheetName)
                {
                    excel.DeleteSheet(i);
                    i--;
                }
            }
            excel.SetCurSheet(FormatEntity.TmpSheetName);
            this.ReceiptNoteEntity.LoadData(NoteID);
            if (this.FormatEntity.NoteCodeCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.NoteCodeCellName, this.ReceiptNoteEntity.NoteCode);
            }

            if (this.FormatEntity.DateNoteCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.DateNoteCellName, this.ReceiptNoteEntity.DateNote);
            }
          
            if (this.FormatEntity.CompanyNameCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.CompanyNameCellName, this.ReceiptNoteEntity.CompanyAbbName);
            }
            if (this.FormatEntity.MoneyTypeCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.MoneyTypeCellName, "'" + this.ReceiptNoteEntity.MoneyTypeName);
            }
           

            if (this.FormatEntity.ReconciliationCodeCellName  != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.ReconciliationCodeCellName, "'"+this.ReceiptNoteEntity.ReconciliationCode  );
            }
            if (this.FormatEntity.TotalAMTCellName  != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.TotalAMTCellName, this.ReceiptNoteEntity .TotalAMT );
            }
            if (this.FormatEntity.AdvanceAMTCellName  != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.AdvanceAMTCellName, this.ReceiptNoteEntity.AdvanceAMT );
            }
            if (this.FormatEntity.AmountCellName  != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.AmountCellName, this.ReceiptNoteEntity.Amount);
            }
            if (this.FormatEntity.MakerPsnCellName  != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.MakerPsnCellName, this.ReceiptNoteEntity.MakerPsn );
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
