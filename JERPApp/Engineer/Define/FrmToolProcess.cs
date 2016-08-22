using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Engineer.Define
{
    public partial class FrmToolProcess : Form
    {
        public FrmToolProcess()
        {
            InitializeComponent();
            this.accToolProcess = new JERPData.Product.ToolProcessTypeNew();
            this.dgrdv.AutoGenerateColumns = false;
            this.setpermit();
        }

        private JERPData.Product.ToolProcessTypeNew accToolProcess;
        private DataTable dtbToolProcess;
        ////权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存

        private void setpermit() {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(94);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(95);
            if (this.enableBrowse)
            {
                //加载数据
                LoadData();
            }
            this.dgrdv.AllowUserToAddRows = enableSave;
            this.dgrdv.AllowUserToDeleteRows = enableSave;
            this.dgrdv.ReadOnly = !enableSave;
            if (this.enableSave)
            {
                this.dgrdv.RowValidated += new DataGridViewCellEventHandler(dgrdv_RowValidated);
                this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
            } 
        }


        private void LoadData() {
            this.dtbToolProcess = this.accToolProcess.GetDataToolProcessTypeNew().Tables[0];
            this.dtbToolProcess.Columns["ToolProcessCode"].AllowDBNull = false;
            this.dtbToolProcess.Columns["ToolProcessCode"].Unique = true;
            this.dtbToolProcess.Columns["ToolProcessName"].AllowDBNull = false;
            this.dtbToolProcess.Columns["ToolProcessName"].Unique = true;
            this.dgrdv.DataSource = this.dtbToolProcess;
        }



        void dgrdv_RowValidated(object sender, DataGridViewCellEventArgs e)
        {

            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            bool flag = false;
            DataRow drow = null;
            try
            {
                drow = this.dtbToolProcess.DefaultView[irow].Row;
            }
            catch
            {
                return;
            }
            if (drow == null) return;
            if (drow.RowState == DataRowState.Unchanged) return;
            string errormsg = string.Empty;
            if (drow["ToolProcessID"] == DBNull.Value)
            {
                object objToolProcessID = DBNull.Value;
                flag = this.accToolProcess.InsertToolProcessTypeNew(ref errormsg, ref objToolProcessID,
                        drow["ToolProcessCode"],
                        drow["ToolProcessName"],
                        drow["ToolProcessMemo"]
                        );
                if (flag)
                {
                    drow["ToolProcessID"] = objToolProcessID;
                    if (this.affterSave != null) this.affterSave();
                }
                else
                {
                    MessageBox.Show(errormsg);
                    this.LoadData();
                }
            }
            else
            {
                flag = this.accToolProcess.UpdateToolProcessTypeNew(ref errormsg,
                            drow["ToolProcessID"],
                            drow["ToolProcessCode"],
                            drow["ToolProcessName"],
                            drow["ToolProcessMemo"]
                             );
                if (flag)
                {
                    if (this.affterSave != null) this.affterSave();
                }
                else
                {
                    MessageBox.Show(errormsg);
                    this.LoadData();
                }

            }
        }

        private void dgrdv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            bool flag = false;
            DataRow drow = this.dtbToolProcess.DefaultView[irow].Row;
            string ErrorMsg = string.Empty;
            if (drow["ToolProcessID"] == DBNull.Value)
            {
                e.Cancel = true;
                return;
            }

            int ToolProcessID = (int)drow["ToolProcessID"];
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {
                flag = this.accToolProcess.DeleteToolProcessTypeNew(ref ErrorMsg,
                    ToolProcessID);
                if (flag)
                {
                    if (this.affterSave != null)
                    {
                        this.affterSave();
                    }
                }
                else
                {
                    MessageBox.Show("此记录已被其他业务引用，不能从数据库中删除此单位");
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
    }
}
