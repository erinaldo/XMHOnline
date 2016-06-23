using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define
{
    public partial class FrmRoleUser : Form
    {
        public FrmRoleUser()
        {
            InitializeComponent();           
            accRoleUser = new JERPData.Frame.RolesUsers();
            accUser = new JERPData.Frame.Users ();
            this.dgrdv.AutoGenerateColumns = false;
            this.dgrdv.ContextMenuStrip = this.cMenu;
            this.mRefresh.Click += new EventHandler(mRefresh_Click);
            this.LoadData();
        }
        private JERPData.Frame.RolesUsers  accRoleUser;
        private JERPData.Frame.Users  accUser;       
        private DataTable dtblUser;
        private short roleID;
        public short RoleID
        {
            get
            {
                return this.roleID;
            }
            set
            {
                this.roleID = value;
                DataTable dt = this.accRoleUser.GetDataRolesUsersByRoleID(this.roleID).Tables[0];
                short userID = 0;
                foreach (DataRow drow in this.dtblUser.Rows)
                {
                    drow["IsSelected"] = false;
                    userID = (short)drow["UserID"];
                    if (dt.Select("UserID=" + userID.ToString()).Length > 0)
                    {
                        drow["IsSelected"] = true;
                    }
                }
                this.dtblUser.AcceptChanges();
                this.dgrdv.DataSource = this.dtblUser;
            }
        }
        void mRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
        public string roleInfor
        {
            set
            {
                this.Text = value;
            }
        }
        public  delegate void AffterSaveDelegate();
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
        private void LoadData()
        {
            
            this.dtblUser = this.accUser.GetDataUsers().Tables[0];
            DataColumn colum = new DataColumn("IsSelected", typeof(bool));
            colum.DefaultValue = false;
            this.dtblUser.Columns.Add(colum);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool flag = false;
            int iSuccess = 0;
            int iErr = 0;
            foreach (DataRow drow in this.dtblUser.Rows)
            {
                if (drow.RowState == DataRowState.Unchanged) continue;
                if ((bool)drow["IsSelected"] == (bool)drow["IsSelected",DataRowVersion.Original ]) continue;
                if ((bool)drow["IsSelected"])
                {
                    int id = -1;
                    flag = this.accRoleUser.InsertRolesUsers(ref id, this.roleID, (short)drow["UserID"]);
                   
                }
                else
                {
                    flag = this.accRoleUser.DeleteRolesUsers (this.roleID,(short)drow["UserID", DataRowVersion.Original]);
                }
                 if (flag)
                {
                    iSuccess++;
                    drow.AcceptChanges();
                }
                else
                {
                    iErr++;
                }
            }
            MessageBox.Show("成功操作;" + iSuccess.ToString() + "\n失败操作:" + iErr.ToString());
            if (this.affterSave != null)
            {
                this.affterSave();
            }
            this.Close();
        }
      

    }
}