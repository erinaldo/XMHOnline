using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.ISO
{
    public partial class FrmFileStatus : Form
    {
        public FrmFileStatus()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFindBorrow.SeachGridView = this.dgrdv;
            this.accFiles = new JERPData.ISO .Files();
            this.accFileStatus = new JERPData.ISO.FileStatus();
            this.accXDept = new JERPData.ISO.FileTypeXDept();
            this.gridhelper = new JCommon.DataGridViewHelper();
            this.SetPermit();
        }
        private DataTable dtblFile, dtblFileStatus, dtblReport, dtblDept;
        private JERPData.ISO.Files accFiles;
        private JERPData.ISO.FileStatus accFileStatus;
        private JERPData.ISO.FileTypeXDept accXDept;
        private JCommon.DataGridViewHelper gridhelper;
        private JCommon.FrmExcelImport frmImport;
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存         

        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(429);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(430);
            if (this.enableBrowse)
            {
            
                this.dgrdv.CellPainting += new DataGridViewCellPaintingEventHandler(dgrdv_CellPainting);
                this.LoadData();
                this.dgrdv.Scroll += new ScrollEventHandler(dgrdv_Scroll);
                this.ctrlFileTypeID.AffterSelected += this.LoadData;

            }
           
            this.btnSave.Enabled = this.enableSave;
            this.btnExport.Enabled = this.enableSave;
            if (this.enableSave)
            {
             
                this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
                this.btnSave.Click += new EventHandler(btnSave_Click);
                this.btnExport.Click += new EventHandler(btnExport_Click);
                this.btnImport.Click += new EventHandler(btnImport_Click);
            }
        }

        void dgrdv_Scroll(object sender, ScrollEventArgs e)
        {
            this.dgrdv.Refresh();
        }
        void dgrdv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int i = e.Row.Index;
            object objFileID = this.dtblReport .DefaultView[i]["FileID"];
            if (objFileID == DBNull.Value)
            {
                e.Cancel = true;
                return;
            }
            string errormsg = string.Empty;
            if (MessageBox.Show("将要删除当前文档信息吗?如删除，将不复存在！", "操作确认",
        MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        == DialogResult.Yes)
            {
                bool flag = this.accFiles.DeleteFiles (
                    ref errormsg,
                    objFileID
                    );
                if (!flag)
                {
                    MessageBox.Show(errormsg);
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }

        }

 

        void dgrdv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if (irow > -1) return;
            int a_begin = 4;
            int a_end = a_begin + this.DetpCount - 1;
            int b_begin = a_end+1;
            int b_end = b_begin + this.DetpCount - 1;
            if ((icol >= a_begin) && (icol <=a_end))
            {
                this.gridhelper.MerageColumnHeaderSpan(this.dgrdv, e, a_begin, a_end, "文件发放");
            }
            if ((icol >= b_begin) && (icol <= b_end))
            {
                this.gridhelper.MerageColumnHeaderSpan(this.dgrdv, e, b_begin, b_end, "文件回收");
            }
          
        }
        private int DetpCount = 1;
        private void LoadData()
        {
           
            this.dtblDept =this.accXDept .GetDataFileTypeXDeptByFileTypeID(this.ctrlFileTypeID .FileTypeID ).Tables [0];
            this.dtblFile =this.accFiles .GetDataFilesByFileTypeID(this.ctrlFileTypeID .FileTypeID).Tables [0];
            
            this.dtblFileStatus = this.accFileStatus.GetDataFileStatusByFileTypeID (
                this.ctrlFileTypeID.FileTypeID).Tables[0];
            this.dtblReport = this.dtblFile.Copy();
            this.DetpCount = this.dtblDept.Rows.Count;
            
            while (this.dgrdv.ColumnCount > 4)
            {
                this.dgrdv.Columns.RemoveAt(4);
            }
            DataGridViewTextBoxColumn col;
            foreach (DataRow drow in this.dtblDept.Rows)
            {
                int DeptID = (int)drow["DeptID"];
                string DeptName=drow["DeptName"].ToString ();
                this.dtblReport.Columns.Add("A" + DeptID.ToString(), typeof(int));
                col = new DataGridViewTextBoxColumn();
                col.DataPropertyName = "A" + DeptID.ToString();
                col.HeaderText = DeptName;
                col.Width = 80;
                this.dgrdv.Columns.Add(col);
                
            }
            foreach (DataRow drow in this.dtblDept.Rows)
            {
                int DeptID = (int)drow["DeptID"];
                string DeptName= drow["DeptName"].ToString();
                this.dtblReport.Columns.Add("B" + DeptID.ToString(), typeof(int));
                col = new DataGridViewTextBoxColumn();
                col.DataPropertyName = "B" + DeptID.ToString();
                col.HeaderText = DeptName;
                col.Width = 80;
                this.dgrdv.Columns.Add(col);
            }
            col = new DataGridViewTextBoxColumn();
            col.DataPropertyName = "Memo";
            col.HeaderText = "备注";
            col.Width = 100;
            this.dgrdv.Columns.Add(col);
          
            foreach (DataRow drow in this.dtblReport.Rows)
            {
                int FileID = (int)drow["FileID"];
                foreach (DataRow drowDept in this.dtblDept.Rows)
                {
                    int DeptID = (int)drowDept["DeptID"];
                    DataRow[] drowFilters=this.dtblFileStatus.Select("FileID=" + FileID.ToString() + " and DeptID=" + DeptID.ToString() + "  and  IsUseFlag=True", "");
                    if (drowFilters.Length > 0)
                    {
                        drow["A" + DeptID.ToString()] = drowFilters[0]["Quantity"];
                    }
                   drowFilters = this.dtblFileStatus.Select("FileID=" + FileID.ToString() + " and DeptID=" + DeptID.ToString() + " and  IsUseFlag=False", "");
                    if (drowFilters.Length > 0)
                    {
                        drow["B" + DeptID.ToString()] = drowFilters[0]["Quantity"];
                    }
                }
                
            }
            this.dgrdv.DataSource = this.dtblReport;
            this.dtblReport.AcceptChanges ();
        }

        void btnExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "受控文件管理表");
            excel.SetCellVal("A2", "类型:" + this.ctrlFileTypeID.FileTypeName);
            int rowIndex = 3;           
            int colIndex = 1;
            excel.ImportGridData(dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeAutoFit(3, 1, rowIndex, colIndex, true, false);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            excel.Show();
            FrmMsg.Hide();
        }
        void btnImport_Click(object sender, EventArgs e)
        {
            if (frmImport == null)
            {
                this.frmImport = new JCommon.FrmExcelImport();
                new FrmStyle(frmImport).SetPopFrmStyle(this);
                this.frmImport.ImportHandle += new JCommon.FrmExcelImport.ImportDelegate(frmImport_ImportHandle);
                DataColumn[] columns = new DataColumn[this.dgrdv.ColumnCount-2];
                for (int j = 0; j < this.dgrdv.Columns .Count-2 ; j++)
                {
                    columns[j] = new DataColumn();
                    columns[j].ColumnName = this.dgrdv.Columns[j].DataPropertyName ;
                    columns[j].DataType = typeof(string);
                    columns[j].Caption = this.dgrdv.Columns[j].HeaderText;
                }
                this.frmImport.SetImportColumn(columns, "注意日期格式");
            }
            frmImport.ShowDialog();
        }

        void frmImport_ImportHandle(DataRow drow, out bool flag, out string msg)
        {

            flag = true;
            msg = "成功";           
            DataRow drowNew = this.dtblReport.NewRow();
            for (int j = 0; j < this.dgrdv.Columns.Count-2; j++)
            {
                drowNew[this.dgrdv.Columns[j].DataPropertyName] = drow[this.dgrdv.Columns[j].DataPropertyName];
            }
            this.dtblReport.Rows.Add(drowNew);
        }

        void btnSave_Click(object sender, EventArgs e)
        {
              DialogResult rul = MessageBox.Show("将进行保存,请确认你的操作!", "操作确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
              if (rul == DialogResult.Yes)
              {
                  bool flag = false;
                  string errormsg = string.Empty;
                  foreach (DataRow drow in this.dtblReport.Select("", "", DataViewRowState.CurrentRows))
                  {
                      if (drow.RowState == DataRowState.Unchanged) continue;
                      object objFileID = drow["FileID"];
                      if (objFileID == DBNull.Value)
                      {
                          flag = this.accFiles.InsertFiles(ref errormsg, 
                              ref objFileID,
                              this.ctrlFileTypeID .FileTypeID ,
                              drow["FileCode"],
                              drow["FileName"], 
                              drow["Version"],
                              drow["DateCreate"], 
                              drow["Memo"]);
                          if (flag)
                          {
                              drow["FileID"] = objFileID;
                          }
                      }
                      else
                      {
                          flag = this.accFiles.UpdateFiles(ref errormsg, objFileID, drow["FileCode"],
                              drow["FileName"], drow["Version"], drow["DateCreate"], drow["Memo"]);
                      }
                      if (objFileID == DBNull.Value) continue;
                      //保存状况
                      foreach (DataRow drowDept in this.dtblDept.Rows)
                      {
                          int DeptID = (int)drowDept["DeptID"];
                          if (drow["A" + DeptID.ToString()] == DBNull.Value)
                          {
                              this.accFileStatus.DeleteFileStatus(ref errormsg, objFileID, true, DeptID);
                          }
                          else
                          {
                              flag=this.accFileStatus.SaveFileStatus(ref errormsg, objFileID, true, DeptID, drow["A" + DeptID.ToString()]);
                              if (!flag)
                              {
                                  MessageBox.Show(errormsg);
                              }
                          }
                          
                          if (drow["B" + DeptID.ToString()] == DBNull.Value)
                          {
                              this.accFileStatus.DeleteFileStatus(ref errormsg, objFileID, false, DeptID);
                          }
                          else
                          {
                             
                              flag=this.accFileStatus.SaveFileStatus(ref errormsg, objFileID, false , DeptID, drow["B" + DeptID.ToString()]);
                             if (!flag)
                             {
                                 MessageBox.Show(errormsg);
                             }
                          }
                      }
                  }
                  MessageBox.Show("成功保存当前变更信息");
              }
        }

     

    }
}