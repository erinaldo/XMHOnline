using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Engineer.Define
{
    public partial class FrmMachineProcess : Form
    {
        public FrmMachineProcess()
        {
            InitializeComponent();
            this.accMachineProcess = new JERPData.Product.MachineProcessTypeNew();
            this.dgrdv.AutoGenerateColumns = false;
            this.setpermit();
        }

        private JERPData.Product.MachineProcessTypeNew accMachineProcess;
        private DataTable dtblMachineProcess;
        ////权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存

        private void setpermit() {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(90);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(91);
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
            this.dtblMachineProcess = this.accMachineProcess.GetDataMachineProcessTypeNew().Tables[0];
            this.dtblMachineProcess.Columns["MachineProcessCode"].AllowDBNull = false;
            this.dtblMachineProcess.Columns["MachineProcessCode"].Unique = true;
            this.dtblMachineProcess.Columns["MachineProcessName"].AllowDBNull = false;
            this.dtblMachineProcess.Columns["MachineProcessName"].Unique = true;
            this.dgrdv.DataSource = this.dtblMachineProcess;
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
                drow = this.dtblMachineProcess.DefaultView[irow].Row;
            }
            catch
            {
                return;
            }
            if (drow == null) return;
            if (drow.RowState == DataRowState.Unchanged) return;
            string errormsg = string.Empty;
            if (drow["MachineProcessID"] == DBNull.Value)
            {
                object objMachineProcessID = DBNull.Value;
                flag = this.accMachineProcess.InsertMachineProcessTypeNew(ref errormsg, ref objMachineProcessID,
                        drow["MachineProcessCode"],
                        drow["MachineProcessName"],
                        drow["MachineProcessMemo"]
                        );
                if (flag)
                {
                    drow["MachineProcessID"] = objMachineProcessID;
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
                flag = this.accMachineProcess.UpdateMachineProcessTypeNew(ref errormsg,
                            drow["MachineProcessID"],
                            drow["MachineProcessCode"],
                            drow["MachineProcessName"],
                            drow["MachineProcessMemo"]
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
            DataRow drow = this.dtblMachineProcess.DefaultView[irow].Row;
            string ErrorMsg = string.Empty;
            if (drow["MachineProcessID"] == DBNull.Value)
            {
                e.Cancel = true;
                return;
            }

            int MachineProcessID = (int)drow["MachineProcessID"];
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {
                flag = this.accMachineProcess.DeleteMachineProcessTypeNew(ref ErrorMsg,
                    MachineProcessID);
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
