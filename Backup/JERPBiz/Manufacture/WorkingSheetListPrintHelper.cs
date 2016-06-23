using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
namespace JERPBiz.Manufacture
{
    public class WorkingSheetListPrintHelper
    {
        public WorkingSheetListPrintHelper()
        {
            
            this.accFormat = new JERPData.Manufacture.WorkingSheetListFormat();
            this.accFormatTitle = new JERPData.Manufacture.WorkingSheetListFieldTitle();
            this.FormatEntity = new WorkingSheetListFormatEntity(); 
            this.TmpFileName = JERPData.ServerParameter.TempletFolder + "WorkingSheetList.xlt"; 
            
        } 
        private JERPData.Manufacture.WorkingSheetListFormat accFormat;
        private JERPData.Manufacture.WorkingSheetListFieldTitle accFormatTitle; 
        private WorkingSheetListFormatEntity FormatEntity;
        private string TmpFileName = string.Empty;
        public void ExportToExcel(DataRow[] drowWorkingSheets)
        {
            DataTable dtblFormat = this.accFormat.GetDataWorkingSheetListFormat ().Tables[0];
            if (dtblFormat.Rows.Count == 0)
            {
                MessageBox.Show("对不起，未设置任何订单格式");
                return;
            }
            int FormatID = General.FrmFormat.GetFormatID(dtblFormat);          
            this.FormatEntity.LoadData(FormatID);
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(this.TmpFileName);     
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
            if (this.FormatEntity.DateNoteCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.DateNoteCellName, DateTime .Now.ToShortDateString ());
            }        
            if (this.FormatEntity.MakerPsnCellName  != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.MakerPsnCellName, JERPBiz .Frame .UserBiz .PsnName );
            }           
            //开始玩明细了呀
            int rowIndex = this.FormatEntity.ItemRowIndex ;
            if (drowWorkingSheets .Length  > this.FormatEntity.ItemRowCount)
            {
                excel.InsertRows(rowIndex, drowWorkingSheets.Length - this.FormatEntity.ItemRowCount, true);
            }
            DataTable dtblColumns = this.accFormatTitle.GetDataWorkingSheetListFieldTitleByFormatID  (FormatID).Tables[0];
            int No = 0;
            for (int irow = 0; irow < drowWorkingSheets.Length ; irow++)
            {
                DataRow drow = drowWorkingSheets[irow];
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
