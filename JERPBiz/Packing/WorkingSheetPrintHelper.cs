using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
namespace JERPBiz.Packing
{
    public class WorkingSheetPrintHelper
    {
        public WorkingSheetPrintHelper()
        {
            this.WrkNoteEntity = new WorkingSheetEntity(); 
            this.accFormat = new JERPData.Packing.WorkingSheetFormat(); 
            this.FormatEntity = new WorkingSheetFormatEntity(); 
            this.TmpFileName = JERPData.ServerParameter.TempletFolder + "PackingSheet.xlt";
         
            
        }
        private JERPBiz.Packing .WorkingSheetEntity    WrkNoteEntity;  
        private JERPData.Packing.WorkingSheetFormat accFormat;  
        private WorkingSheetFormatEntity FormatEntity;
        private string TmpFileName = string.Empty;
        public void ExportToExcel(long WorkingSheetID)
        {
            DataTable dtblFormat = this.accFormat.GetDataWorkingSheetFormat ().Tables[0];
            if (dtblFormat.Rows.Count == 0)
            {
                MessageBox.Show("对不起，未设置任何订单格式");
                return;
            }
            int FormatID = General.FrmFormat.GetFormatID(dtblFormat);          
            this.FormatEntity.LoadData(FormatID);
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(this.TmpFileName);
            this.WrkNoteEntity.LoadData(WorkingSheetID);         
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
            if (this.FormatEntity.WorkingSheetCodeCellName!= string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.WorkingSheetCodeCellName  , this.WrkNoteEntity.WorkingSheetCode );
            }
            if (this.FormatEntity.DateNoteCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.DateNoteCellName, this.WrkNoteEntity.DateNote.ToShortDateString());
            }
         
            if (this.FormatEntity.CompanyNameCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.CompanyNameCellName,"'"+ this.WrkNoteEntity.CompanyCode);
            }         
            if (this.FormatEntity.PrdCodeCellName   != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.PrdCodeCellName ,"'"+ this.WrkNoteEntity.PrdCode );
            }
            if (this.FormatEntity.PrdNameCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.PrdNameCellName, "'" + this.WrkNoteEntity.PrdName);
            } 
            if (this.FormatEntity.ModelCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.ModelCellName, "'" + this.WrkNoteEntity.Model);
            }
            if (this.FormatEntity.PrdSpecCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.PrdSpecCellName, "'" + this.WrkNoteEntity.PrdSpec);
            }        
            
            if (this.FormatEntity.QuantityCellName  != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.QuantityCellName, this.WrkNoteEntity.Quantity);
            }
            if (this.FormatEntity.UnitNameCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.UnitNameCellName, this.WrkNoteEntity.UnitName);
            }
            if (this.FormatEntity.DateTargetCellName  != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.DateTargetCellName, this.WrkNoteEntity.DateTarget );
            }
            if (this.FormatEntity.PackingTypeCellName != string.Empty)
            {
                
                excel.SetCellVal(this.FormatEntity.PackingTypeCellName , this.WrkNoteEntity .PackingTypeName  );
            } 
            if (this.FormatEntity.MakerPsnCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.MakerPsnCellName, this.WrkNoteEntity.MakerPsn);
            } 
            if (this.FormatEntity.MemoCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.MemoCellName, this.WrkNoteEntity.Memo);
            } 
            excel.Show();
          
        }

    }

}
