using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.ISO
{
    public partial class FrmFileType : Form
    {
       
        public FrmFileType()
        {
            InitializeComponent();
            this.accFileType = new JERPData.ISO.FileType();
            this.accXDept = new JERPData.ISO.FileTypeXDept();
            this.accDept = new JERPData.Hr.Department();
            this.dgrdv.AutoGenerateColumns = false;
            this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
            this.FormClosed += new FormClosedEventHandler(FrmFileType_FormClosed);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.CreateColumn();
            this.LoadData();
        }

        private DataTable dtblXDepts,dtblDept;
        private JERPData.ISO.FileType accFileType;
        private JERPData.ISO.FileTypeXDept accXDept;
        private JERPData.Hr.Department accDept;
        private void CreateColumn()
        {
            this.dtblDept = this.accDept.GetDataDepartment().Tables[0];
            DataGridViewCheckBoxColumn ckbcol;
            foreach (DataRow drow in this.dtblDept.Rows)
            {
                ckbcol = new DataGridViewCheckBoxColumn();
                ckbcol.DataPropertyName = drow["DeptID"].ToString();
                ckbcol.HeaderText = drow["DeptName"].ToString();
                ckbcol.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                this.dgrdv.Columns.Add(ckbcol);
            }

        }
        private void LoadData()
        {
            this.dtblXDepts = this.accXDept.GetDataFileTypeXDeptPivotDept().Tables[0];
            this.dtblXDepts.Columns["FileTypeCode"].AllowDBNull = false;
            this.dtblXDepts.Columns["FileTypeCode"].Unique = true;
            this.dtblXDepts.Columns["FileTypeName"].AllowDBNull = false;
            this.dtblXDepts.Columns["FileTypeName"].Unique = true;
            this.dgrdv.DataSource = this.dtblXDepts;
            this.ctrlQFind.SeachGridView = this.dgrdv;
        }
        private void dgrdv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            bool flag = false;
            DataRow drow = this.dtblXDepts.DefaultView[irow].Row;
            string ErrorMsg = string.Empty;
            if (drow["FileTypeID"] == DBNull.Value)
            {      
                return;
            }
            int  FileTypeID = (int)drow["FileTypeID"];
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {
                flag = this.accFileType.DeleteFileType(ref ErrorMsg,
                    FileTypeID);
                if (!flag)
                {
                    
                    MessageBox.Show(ErrorMsg);
                }
            }
            else
            {
                e.Cancel = true;
            }
        }  
        public delegate void AffterSaveDelegate();
        private AffterSaveDelegate affterSave;
        public event AffterSaveDelegate AffterSave
        {
            add
            {
                affterSave += value;
            }
            remove
            {
                affterSave -= value;
            }
        }
        void FrmFileType_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.affterSave != null) this.affterSave();
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            string errormsg=string.Empty ;
            bool flag = false;
            foreach (DataRow drow in this.dtblXDepts.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow.RowState == DataRowState.Unchanged) continue;
                object objFileTypeID = drow["FileTypeID"];
                if (objFileTypeID == DBNull.Value)
                {
                    flag = this.accFileType.InsertFileType(
                        ref errormsg,
                        ref objFileTypeID,
                        drow["FileTypeCode"],
                        drow["FileTypeName"]);
                    if (flag)
                    {
                        drow["FileTypeID"] = objFileTypeID;
                    }
                }
                else
                {
                    flag=this.accFileType .UpdateFileType (
                        ref errormsg ,
                        drow["FileTypeID"],
                        drow["FileTypeCode"],
                        drow["FileTypeName"]);

                }
                if (flag)
                {
                    foreach (DataRow deptcolumn in this.dtblDept.Rows )
                    {
                        int DeptID=(int)deptcolumn["DeptID"];
                        if (drow[DeptID.ToString()] == DBNull.Value) continue;
                        flag = (bool)drow[DeptID .ToString ()];
                        if (flag)
                        {
                            this.accXDept.SaveFileTypeXDept(ref errormsg,
                                objFileTypeID ,
                                DeptID);
                        }
                        else
                        {
                            this.accXDept.DeleteFileTypeXDept(ref errormsg,
                                objFileTypeID,
                                DeptID);
                        }
                    }
                }
            }
            MessageBox.Show("成功保存当前文件类型及发放部门");
        }
    }
}