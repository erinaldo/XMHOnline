using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Engineer.Define
{
    public partial class FrmModeProcess : Form
    {
        public FrmModeProcess()
        {
            InitializeComponent();
            this.accModeProcess = new JERPData.Product.ModelProcessTypeNew();
            this.dgrdv.AutoGenerateColumns = false;
            this.setpermit();
        }

        private JERPData.Product.ModelProcessTypeNew accModeProcess;
        private DataTable dtbModeProcess;
        ////权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存

        private void setpermit() {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(92);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(93);
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
            this.dtbModeProcess = this.accModeProcess.GetDataModeProcessTypeNew().Tables[0];
            this.dtbModeProcess.Columns["ModelProcessCode"].AllowDBNull = false;
            this.dtbModeProcess.Columns["ModelProcessCode"].Unique = true;
            this.dtbModeProcess.Columns["ModelProcessName"].AllowDBNull = false;
            this.dtbModeProcess.Columns["ModelProcessName"].Unique = true;
            this.dgrdv.DataSource = this.dtbModeProcess;
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
                drow = this.dtbModeProcess.DefaultView[irow].Row;
            }
            catch
            {
                return;
            }
            if (drow == null) return;
            if (drow.RowState == DataRowState.Unchanged) return;
            string errormsg = string.Empty;
            if (drow["ModelProcessID"] == DBNull.Value)
            {
                object objModelProcessID = DBNull.Value;
                flag = this.accModeProcess.InsertModeProcessTypeNew(ref errormsg, ref objModelProcessID,
                        drow["ModelProcessCode"],
                        drow["ModelProcessName"],
                        drow["ModelProcessMemo"]
                        );
                if (flag)
                {
                    drow["ModelProcessID"] = objModelProcessID;
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
                flag = this.accModeProcess.UpdateModeProcessTypeNew(ref errormsg,
                            drow["ModelProcessID"],
                            drow["ModelProcessCode"],
                            drow["ModelProcessName"],
                            drow["ModelProcessMemo"]
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
            DataRow drow = this.dtbModeProcess.DefaultView[irow].Row;
            string ErrorMsg = string.Empty;
            if (drow["ModelProcessID"] == DBNull.Value)
            {
                e.Cancel = true;
                return;
            }

            int ModelProcessID = (int)drow["ModelProcessID"];
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {
                flag = this.accModeProcess.DeleteModeProcessTypeNew(ref ErrorMsg,
                    ModelProcessID);
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
