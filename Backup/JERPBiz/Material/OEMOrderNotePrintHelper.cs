using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
namespace JERPBiz.Material
{
    public class OEMOrderNotePrintHelper
    {
        public OEMOrderNotePrintHelper()
        {
            this.NoteEntity = new OEMOrderNoteEntity();
            this.accItems = new JERPData.Material.OEMOrderItems();
            this.CustomerEntity = new JERPBiz.General.CustomerEntity();
            this.accFormat = new JERPData.Material.OEMOrderFormat();
            this.FormatEntity = new OEMOrderFormatEntity();
            this.accFormatTitle = new JERPData.Material.OEMOrderFieldTitle();
            this.TmpFileName = JERPData.ServerParameter.TempletFolder + "MtrOEMOrderNote.xlt";


        }
        private JERPBiz.Material.OEMOrderNoteEntity NoteEntity;
        private JERPData.Material.OEMOrderItems accItems;
        private JERPBiz.General.CustomerEntity CustomerEntity;
        private JERPData.Material.OEMOrderFormat accFormat;
        private JERPBiz.Material.OEMOrderFormatEntity FormatEntity;
        private JERPData.Material.OEMOrderFieldTitle accFormatTitle;
        private string TmpFileName = string.Empty;
        public void ExportToExcel(long NoteID)
        {
            DataTable dtblFormat = this.accFormat.GetDataOEMOrderFormat().Tables[0];
            if (dtblFormat.Rows.Count == 0)
            {
                MessageBox.Show("对不起，未设置任何订单格式");
                return;
            }
            int FormatID = JERPBiz.General.FrmFormat.GetFormatID(dtblFormat);  
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
                excel.SetCellVal(this.FormatEntity.CompanyNameCellName, this.CustomerEntity.CompanyAllName);
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
            if (this.FormatEntity.EmailCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.EmailCellName, "'" + this.CustomerEntity.Email);
            }
            if (this.FormatEntity.MakerPsnCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.MakerPsnCellName, this.NoteEntity.MakerPsn);
            }
            if (this.FormatEntity.MemoCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.MemoCellName, this.NoteEntity.Memo);
            }
            //开始玩明细了呀

            DataTable dtblItems = this.accItems.GetDataOEMOrderItemsByNoteID(NoteID).Tables[0];
            int rowIndex = this.FormatEntity.ItemRowIndex;
            if (dtblItems.Rows.Count > this.FormatEntity.ItemRowCount)
            {
                excel.InsertRows(rowIndex, dtblItems.Rows.Count - this.FormatEntity.ItemRowCount, true);
            }
            DataTable dtblColumns = this.accFormatTitle.GetDataOEMOrderFieldTitleByFormatID(FormatID).Tables[0];

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
