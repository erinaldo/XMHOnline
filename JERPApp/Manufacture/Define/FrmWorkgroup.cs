using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture.Define
{
    public partial class FrmWorkgroup : Form
    {
        public FrmWorkgroup()
        {
            InitializeComponent();
            this.accWorkgroup = new JERPData.Manufacture.Workgroup();
            this.dgrdv.AutoGenerateColumns = false;
            this.SetPermit();
        }
        private DataTable dtblWorkgroups;
        private JERPData.Manufacture.Workgroup accWorkgroup;
       
        private void LoadData()
        {
          
            this.dtblWorkgroups = this.accWorkgroup.GetDataWorkgroup().Tables[0];
            this.dtblWorkgroups.Columns["WorkgroupCode"].AllowDBNull = false;
            this.dtblWorkgroups.Columns["WorkgroupCode"].Unique  = true;
            this.dtblWorkgroups.Columns["WorkgroupName"].AllowDBNull = false;
            this.dtblWorkgroups.Columns["WorkgroupName"].Unique = true;
            this.dgrdv.DataSource = this.dtblWorkgroups;
        }

   
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存           

        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(352);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(353);
            if (this.enableBrowse)
            {
                this.LoadData();
            }
            this.dgrdv.ReadOnly = !enableSave;
            this.dgrdv.AllowUserToAddRows = enableSave;
            this.dgrdv.AllowUserToDeleteRows = enableSave;
            if (this.enableSave)
            {
                this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
                this.dgrdv.RowValidated += new DataGridViewCellEventHandler(dgrdv_RowValidated);

            }
           
        }

        void dgrdv_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            DataRow drow = null;
            try
            {
                drow = this.dtblWorkgroups.DefaultView[irow].Row;
            }
            catch
            {
                return;
            }
            bool flag = false;          
            string errormsg = string.Empty;
            if (drow == null) return;
            if (drow["WorkgroupID"] == DBNull.Value)
            {
                object objWorkgroupID = 0; 
                flag = this.accWorkgroup.InsertWorkgroup(
                        ref errormsg,
                        ref objWorkgroupID,
                        drow["WorkgroupCode"],
                        drow["WorkgroupName"],
                        drow["Memo"]);
                if (flag)
                {
                    drow["WorkgroupID"] = objWorkgroupID;
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
                flag = this.accWorkgroup.UpdateWorkgroup(ref errormsg,
                            drow["WorkgroupID"],
                            drow["WorkgroupCode"],
                            drow["WorkgroupName"],
                            drow["Memo"]);
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
            DataRow drow = this.dtblWorkgroups  .DefaultView[irow].Row;
            string ErrorMsg = string.Empty;
            if (drow["WorkgroupID"] == DBNull.Value)
            {
             
                return;
            }

            int  WorkgroupID = (int)drow["WorkgroupID"];
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {
                flag = this.accWorkgroup.DeleteWorkgroup(ref ErrorMsg,
                    WorkgroupID);
                if (flag)
                {
                    if (this.affterSave != null)
                    {
                        this.affterSave();
                    }
                }
                else
                {
                   MessageBox .Show (ErrorMsg);
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