using System;
using System.Collections.Generic;
using System.Text;
using System.Data ;
using System.Windows.Forms ;
namespace JERPBiz.Manufacture
{
    public class ManufSchedulePrintHelper
    {
        public ManufSchedulePrintHelper()
        {
            this.ScheduleEntity = new ManufScheduleEntity();
            this.WrkEntity = new WorkingSheetEntity();
            this.FormatEntity = new ManufScheduleFormatEntity();
            this.accFormat = new JERPData.Manufacture.ManufScheduleFormat();
            this.TmpFileName = JERPData.ServerParameter.TempletFolder + "ManufSchedule.xlt";
        }
        private  ManufScheduleEntity ScheduleEntity;
        private WorkingSheetEntity WrkEntity;
        private ManufScheduleFormatEntity FormatEntity;
        private JERPData.Manufacture.ManufScheduleFormat accFormat;
        private string TmpFileName = string.Empty;
        private void ImportTmp( Office2003Helper.Excel2003 excel,int iSheet, long ManufScheduleID )
        {
            this.ScheduleEntity.LoadData(ManufScheduleID);
            this.WrkEntity .LoadData (this.ScheduleEntity .WorkingSheetID );
            excel.SetCurSheet(iSheet);
            if (this.FormatEntity.WorkingSheetCodeCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.WorkingSheetCodeCellName, "'" + this.ScheduleEntity.WorkingSheetCode);
            }
            if (this.FormatEntity.CompanyCodeCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.CompanyCodeCellName, "'" + this.ScheduleEntity.CompanyCode  );
            } 
            if (this.FormatEntity.PrdCodeCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.PrdCodeCellName, "'" + this.ScheduleEntity.PrdCode);
            }
            if (this.FormatEntity.PrdNameCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.PrdNameCellName, "'" + this.ScheduleEntity.PrdName);
            }
            if (this.FormatEntity.PrdSpecCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.PrdSpecCellName, "'" + this.ScheduleEntity.PrdSpec);
            } 
            if (this.FormatEntity.ModelCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.ModelCellName, "'" + this.ScheduleEntity.Model);
            }
            if (this.FormatEntity.PrdStatusCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.PrdStatusCellName, this.ScheduleEntity.PrdStatus);
            }
            if (this.FormatEntity.QuantityCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.QuantityCellName, this.ScheduleEntity.Quantity);
            }
            if (this.FormatEntity.PrdDateTargetCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.PrdDateTargetCellName , string.Format("{0:MM-dd H:mm}", this.WrkEntity.DateTarget));

            }
            if (this.FormatEntity.DateTargetCellName  != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.DateTargetCellName , string.Format("{0:MM-dd H:mm}", this.ScheduleEntity .DateTarget));

            }
            if (this.FormatEntity.MemoCellName  != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.MemoCellName , this.ScheduleEntity.Memo);
            }
            if (this.FormatEntity.LastPrdStatusCellName  != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.LastPrdStatusCellName , this.ScheduleEntity.LastPrdStatus);
            }
            if (this.FormatEntity.NextPrdStatusCellName  != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.NextPrdStatusCellName, this.ScheduleEntity.NextPrdStatus);
            }
          
        }
        public void ExportToExcel(long[] ManufScheduleIDs)
        {
            DataTable dtblFormat = this.accFormat.GetDataManufScheduleFormat ().Tables[0];
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
           
            if (ManufScheduleIDs.Length > 1)
            {
                excel.NewSheetByCopy(1, ManufScheduleIDs.Length - 1);
            }
            excel.SetCurSheet(1);
           
            for (int i = 0; i < ManufScheduleIDs.Length; i++)
            {
                this.ImportTmp(excel,i+1, ManufScheduleIDs[i]);                
            }
            excel.SetCurSheet(1);
            excel.Show();
        }
    }
}
