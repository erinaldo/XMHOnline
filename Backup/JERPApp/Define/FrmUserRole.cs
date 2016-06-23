using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define
{
    public partial class FrmUserRole : Form
    {
        public FrmUserRole()
        {
            InitializeComponent();
          
            accRoleUser = new JERPData.Frame.RolesUsers();
            accRole = new JERPData.Frame.Roles();
            this.dgrdv.AutoGenerateColumns = false;
            this.dgrdv.ContextMenuStrip = this.cMenu;
            this.mRefresh.Click += new EventHandler(mRefresh_Click);
            LoadData();
            
        }

        void mRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
        private JERPData.Frame.RolesUsers  accRoleUser;
        private JERPData.Frame.Roles accRole;       
        private DataTable dtblRole;
        public short UserID
        {
            get
            {
                return this.userID;
            }
            set
            {
                this.userID = value;
                short roleID = 0;                 
                DataTable dtbl = this.accRoleUser.GetDataRolesUsersByUserID(this.userID).Tables [0];
                foreach (DataRow drow in this.dtblRole.Rows)
                {
                    drow["IsSelected"] = false ;
                    roleID = (short)drow["RoleID"];
                    if (dtbl.Select("RoleID=" + roleID.ToString()).Length > 0)
                    {
                        drow["IsSelected"] = true;
                    }
                }
                this.dtblRole.AcceptChanges();
                this.dgrdv.DataSource = this.dtblRole;
            }
        }
        private short userID;
        public string UserInfor
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
            this.dtblRole = this.accRole.GetDataRoles().Tables[0];
            DataColumn colum = new DataColumn("IsSelected", typeof(bool));
            colum.DefaultValue = false;
            this.dtblRole.Columns.Add(colum);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool flag = false;
            int iSuccess = 0;
            int iErr = 0;
            foreach (DataRow drow in this.dtblRole.Rows)
            {
                if (drow.RowState == DataRowState.Unchanged) continue;
                if ((bool)drow["IsSelected"] == (bool)drow["IsSelected",DataRowVersion.Original ]) continue;
                if ((bool)drow["IsSelected"])
                {
                    int id = -1;
                    flag=this.accRoleUser.InsertRolesUsers(ref id, (short)drow["RoleID"], this.userID);
                   
                }
                else
                {
                    flag = this.accRoleUser.DeleteRolesUsers((short)drow["RoleID", DataRowVersion.Original], this.userID);
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