using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define
{
    public partial class FrmRole : Form
    {
        public FrmRole()
        {
            InitializeComponent();
            this.accRoles = new JERPData.Frame.Roles();
            this.dgrdv.AutoGenerateColumns = false;
            this.SetPermit();
        }
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(3);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(4);
            if (this.enableBrowse)
            {
                this.ctrlQFind.SetSearchElement(this.dgrdv);
                //加载数据
                LoadData();
                this.dgrdv.ContextMenuStrip = cMenu;
                this.mRefresh.Click += new EventHandler(mRefresh_Click);
            }
            this.dgrdv.AllowUserToAddRows = false;
            this.dgrdv.AllowUserToDeleteRows = false;
            this.dgrdv.ReadOnly = true;
            if (this.enableSave)
            {
                this.dgrdv.AllowUserToAddRows = true ;
                this.dgrdv.AllowUserToDeleteRows = true;
                this.dgrdv.ReadOnly = false;
                this.dgrdv.RowValidated += new DataGridViewCellEventHandler(dgrdv_RowValidated);
            }

            this.RoleValueSetColumn.Visible = this.enableSave;
            this.UserSetColumn.Visible = this.enableSave;
        }

        void mRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }

      
        private void LoadData()
        {
            DataSet dst = this.accRoles.GetDataRoles();
            this.dtblRoles = dst.Tables[0];
            this.dgrdv.DataSource = dtblRoles;
            this.dtblRoles.Columns ["RoleName"].AllowDBNull =false;
            this.dtblRoles.Columns ["RoleName"].Unique =true;
        }
        private DataTable dtblRoles;
        private JERPData.Frame.Roles accRoles;

        void dgrdv_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            bool flag = false;           
            StringBuilder sb = new StringBuilder("0");
            sb.Append('0', 10000);
            sb[1] = '0';
            string initRoleValue=sb.ToString ();
            DataRow drow = null;
            try
            {
                drow = this.dtblRoles.DefaultView[irow].Row;
            }
            catch 
            {
                return;
            }
            if (drow.RowState == DataRowState.Unchanged) return;
            if(drow["RoleID"]==DBNull.Value)
            {
                    object roleID = 0;                  
                    if (drow["RoleValue"] == DBNull.Value)
                    {
                        drow["RoleValue"] = initRoleValue;
                    }
                    flag = this.accRoles .InsertRoles(ref roleID,
                                    drow["RoleName"],
                                    drow["SubjectKey"],
                                    drow["RoleValue"],
                                    drow["Description"]);
                    if (flag)
                    {
                        drow.AcceptChanges();
                        drow["RoleID"] = roleID;                      
                    }
                    else
                    {
                       MessageBox.Show ("添加当前角色失败！");
                    }
            }
            else 
            {
                    flag = this.accRoles.UpdateRoles (drow["RoleID"],
                                     drow["RoleName"],
                                     drow["SubjectKey"],                                   
                                     drow["Description"]);
                    if (flag)
                    {
                        drow.AcceptChanges();
                    }
                    else
                    {                      
                        MessageBox.Show ("更新角色失败！");
                    }                
            }
           
        }

        private void dgrdv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (e.ColumnIndex == 0)
            {
                if (this.dgrdv[0, e.RowIndex].Value == DBNull.Value) return;
                string rolename=this.dgrdv .Rows[e.RowIndex ].Cells [0].Value.ToString ();
                this.dgrdv.Rows[e.RowIndex].Cells[1].Value = JCommon.Chinese.GetSpell(rolename);
            }
        }
        FrmRoleUser frmRoleUser = null;
        FrmRoleValue frmRoleValue = null;
        private void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1)||(icol==-1)) return;
            DataRow drow = this.dtblRoles.DefaultView[irow].Row;         
            if ((drow == null) || (drow["RoleID"] == DBNull.Value))
            {
                MessageBox.Show("因为数据库中该角色不存在，所以不能设置，请先错行保存！");
                return;
            }
           
            string rolename=(string)drow["RoleName"];
            short roleID = (short)drow["RoleID"];
            if (this.dgrdv .Columns [icol ].Name  == this.UserSetColumn .Name )
            {

                if (frmRoleUser == null)
                {
                    frmRoleUser = new FrmRoleUser();                   
                    frmRoleUser.AffterSave += new FrmRoleUser.AffterSaveDelegate(frmRoleUser_AffterSave);
                    (new FrmStyle(frmRoleUser)).SetPopFrmStyle(this);
                }
                frmRoleUser.RoleID = roleID;
                frmRoleUser.roleInfor = rolename;
                frmRoleUser.ShowDialog();
            }
            if (this.dgrdv.Columns[icol].Name == this.RoleValueSetColumn.Name)
            {
                if (frmRoleValue == null)
                {
                    frmRoleValue = new FrmRoleValue();
                    new FrmStyle(frmRoleValue).SetPopFrmStyle(this);
                }
                frmRoleValue.SetRoleValue(roleID);
                frmRoleValue.ShowDialog();
            }
        }

        void frmRoleUser_AffterSave()
        {
            this.LoadData();
        }

        private void dgrdv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
             int irow = e.Row.Index;
            object objID = this.dtblRoles. DefaultView[irow]["RoleID"];
            if (objID == DBNull.Value)
            {               
                return;
            }
            DialogResult rlt = MessageBox.Show("将要删除当前当前记录吗，你的删除将不能恢复！\n是，删除；否，取消!", "操作确认",
    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rlt== DialogResult.Yes)
            {
                bool flag = this.accRoles .DeleteRoles ((short )objID);
                if (flag)
                {
                    MessageBox.Show("成功删除当前记录");

                }
                else
                {
                    MessageBox.Show("对不起，此记录被其他业务引用，不能删除");
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }  
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在打印中，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder  + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "系统角色表");
            int rowIndex =2;
            int rowcount = this.dgrdv.Rows.Count - 1;
            excel.SetCellVal("A2", "角色名称");
            excel.SetCellVal("B2", "角色内容");
            excel.SetCellVal("C2", "人员设置");
        
            for (int i = 0; i < rowcount; i++)
            {
                rowIndex++;              
                excel.SetCellVal(rowIndex,  1, "'" + this.dgrdv[this .RoleNameColumn .Name , i].FormattedValue);
                excel.SetCellVal(rowIndex, 2, "'" + this.dgrdv[this.DescriptionColumn.Name, i].FormattedValue);
            }
            excel.SetRangeInnerCellSize(200, 20, 2, 2, rowIndex, 2);
           
            excel.SetRangeWrap(true, 2, 2, rowIndex, 2); 
            excel.SetRangeInnerBorder(2, 1, rowIndex, 3);
            excel.SetRangeAutoFit(2, 1, rowIndex, 2, true, true);
         
            FrmMsg.Hide();
            excel.Show();
            
        }

        private void dgrdv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.DescriptionColumn.Name)
            {
                string descript=this.dgrdv [this.DescriptionColumn .Name ,irow].Value .ToString ();
                JCommon.FrmDetail.ShowDialog(ref descript,false);
                this.dgrdv[this.DescriptionColumn.Name, irow].Value = descript;
            }
        }
    }
}