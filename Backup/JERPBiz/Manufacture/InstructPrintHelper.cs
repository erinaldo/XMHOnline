using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
namespace JERPBiz.Manufacture
{
    public class InstructPrintHelper
    {
        public InstructPrintHelper()
        {
            
            this.accFormat = new JERPData.Manufacture.InstructFormat();
            this.accFormatTitle = new JERPData.Manufacture.InstructFieldTitle();
            this.FormatEntity = new InstructFormatEntity();
            this.accInstruct = new JERPData.Manufacture.Instruct();
            this.TmpFileName = JERPData.ServerParameter.TempletFolder + "Instruct.xlt"; 
            
        } 
        private JERPData.Manufacture.InstructFormat accFormat;
        private JERPData.Manufacture.InstructFieldTitle accFormatTitle;
        private JERPData.Manufacture.Instruct accInstruct;
        private InstructFormatEntity FormatEntity;
        private string TmpFileName = string.Empty;
        public void ExportToExcel()
        {
            DataTable dtblFormat = this.accFormat.GetDataInstructFormat ().Tables[0];
            if (dtblFormat.Rows.Count == 0)
            {
                MessageBox.Show("对不起，未设置任何订单格式");
                return;
            }           
            this.FormatEntity.LoadData();
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(this.TmpFileName);                
            if (this.FormatEntity.DateInstructCellName  != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.DateInstructCellName, DateTime.Now.ToShortDateString());
            }        
            if (this.FormatEntity.MakerPsnCellName  != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.MakerPsnCellName, JERPBiz .Frame .UserBiz .PsnName );
            }           
            //开始玩明细了呀
            int rowIndex = this.FormatEntity.ItemRowIndex ;
            DataTable dtblInstruct = this.accInstruct.GetDataInstructForExport().Tables[0];
            if (dtblInstruct.Rows .Count > this.FormatEntity.ItemRowCount)
            {
                excel.InsertRows(rowIndex, dtblInstruct.Rows.Count - this.FormatEntity.ItemRowCount, true);
            }
            DataTable dtblColumns = this.accFormatTitle.GetDataInstructFieldTitle ().Tables[0];
            int No = 0;
            for (int irow = 0; irow < dtblInstruct.Rows .Count  ; irow++)
            {
                DataRow drow = dtblInstruct.Rows[irow];
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
