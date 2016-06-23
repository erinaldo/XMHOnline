using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
namespace JERPBiz.Material
{
    public class OutSrcSupplyNotePrintHelper
    {
        public OutSrcSupplyNotePrintHelper()
        {
            this.NoteEntity = new OutSrcSupplyNoteEntity();
            this.SupplierEntity = new JERPBiz.General.SupplierEntity();
            this.accFormat = new JERPData.Material.OutSrcSupplyFormat();
            this.accFormatTitle = new JERPData.Material.OutSrcSupplyFieldTitle();
            this.FormatEntity = new OutSrcSupplyFormatEntity();
            this.accItems = new JERPData.Material.OutSrcSupplyItems();
            this.accPlans = new JERPData.Material.OutSrcSupplyPlans();
            this.TmpFileName = JERPData.ServerParameter.TempletFolder + "MtrOutSrcSupplyNote.xlt";
         
            
        }
        private JERPBiz.Material .OutSrcSupplyNoteEntity   NoteEntity;
        private JERPBiz.General.SupplierEntity SupplierEntity; 
        private JERPData.Material.OutSrcSupplyFormat accFormat;
        private JERPData.Material.OutSrcSupplyFieldTitle accFormatTitle;
        private JERPData.Material.OutSrcSupplyItems accItems;
        private JERPData.Material.OutSrcSupplyPlans accPlans;
        private OutSrcSupplyFormatEntity FormatEntity;
        private string TmpFileName = string.Empty;
        
        public void ExportToExcel(long NoteID)
        {
            DataTable dtblFormat = this.accFormat.GetDataOutSrcSupplyFormat().Tables[0];
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
            this.SupplierEntity.LoadData(this.NoteEntity.CompanyID   );
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
            if (this.FormatEntity.SupplierCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.SupplierCellName, this.SupplierEntity.CompanyAllName  );
            }
            if (this.FormatEntity.SupplierAddressCellName   != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.SupplierAddressCellName, this.NoteEntity.SupplierAddress);
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
            if (this.FormatEntity.MakerPsnCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.MakerPsnCellName, this.NoteEntity.MakerPsn);
            }     
            if (this.FormatEntity.MemoCellName != string.Empty)
            {
                excel.SetCellVal(this.FormatEntity.MemoCellName, this.NoteEntity.Memo);
            }
            //开始玩明细了呀
            DataTable dtblItems = this.accItems.GetDataOutSrcSupplyItemsForExport (NoteID).Tables[0];
           
          
            DataTable dtblColumns = this.accFormatTitle .GetDataOutSrcSupplyFieldTitleByFormatID (FormatID).Tables[0];
            //先将表换成列数 
           
            if (this.FormatEntity.AssemblyColumnName != string.Empty)
            { 

                string AssemblyColumnName=this.FormatEntity.AssemblyColumnName;
                int AssemblyIndex = excel.GetColumnIndex(AssemblyColumnName);
                DataTable dtblPlans = this.accPlans.GetDataOutSrcSupplyPlansByNoteID(NoteID).Tables[0];
                if ((dtblPlans.Rows.Count > 0) && (AssemblyIndex > 0))
                {
                    int ColumnIndex = 0;
                    foreach (DataRow drow in dtblColumns.Rows)
                    {
                        ColumnIndex = excel.GetColumnIndex(drow["ColumnName"].ToString());
                        if (ColumnIndex >= AssemblyIndex)
                        {
                            drow["ColumnName"] = excel.GetColumnName (ColumnIndex + dtblPlans.Rows.Count);
                        }
                    }
                    DataRow drowNew;
                    for(int i=0;i<dtblPlans .Rows .Count ;i++)
                    {
                        DataRow drow = dtblPlans.Rows[i];
                        drowNew = dtblColumns.NewRow();
                        drowNew["SerialNoFlag"] = false; 
                        drowNew["ColumnName"] = excel.GetColumnName(AssemblyIndex + i);
                        drowNew["FieldTitle"] = drow["PrdName"].ToString() + "\n" +
                            drow["PrdSpec"].ToString() + string.Format("({0:0.####})", drow["Quantity"]);
                        drowNew["Fieldlist"] = drow["OutSrcSupplyPlanID"].ToString();
                        dtblColumns.Rows.Add(drowNew);
                    }
                    //加上那些个列
                    excel.InsertColumns(AssemblyColumnName, AssemblyColumnName, dtblPlans.Rows.Count);
                }
            }
        
            int No = 0;
            int rowIndex = this.FormatEntity.ItemRowIndex;
           
            //这里呢,要设一下标题
            rowIndex--;
            foreach (DataRow drow in dtblColumns.Rows)
            {
                excel.SetCellVal(drow["ColumnName"].ToString() + rowIndex.ToString(), drow["FieldTitle"].ToString());
            } 
            rowIndex++;
            if (dtblItems.Rows.Count > this.FormatEntity.ItemRowCount)
            {
                excel.InsertRows(rowIndex, dtblItems.Rows.Count - this.FormatEntity.ItemRowCount, true);
            }
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
