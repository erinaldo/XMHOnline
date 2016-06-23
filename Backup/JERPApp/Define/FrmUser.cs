using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define
{
    public partial class FrmUser : Form
    {
        public FrmUser()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            accUser = new JERPData.Frame.Users();
            this.SetPermit();
        }
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(1);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(2);
            if (this.enableBrowse)
            {
                InitColumns();
                this.ctrlQFind.SetSearchElement(this.dgrdv);
                LoadData();
                this.dgrdv.ContextMenuStrip = this.cMenu;
                this.mRefresh.Click += new EventHandler(mRefresh_Click);
                this.btnExport .Click +=new EventHandler(btnExport_Click);
                this.dgrdv .CellContentClick +=new DataGridViewCellEventHandler(dgrdv_CellContentClick);
                this.dgrdv .UserDeletingRow +=new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
            }
            this.dgrdv.AllowUserToAddRows = false;
            this.dgrdv.AllowUserToDeleteRows = false;
             this.RolelistColumn.Visible=this.enableSave ;
            this.dgrdv.ReadOnly = true;
            if (this.enableSave)
            {
                this.dgrdv.AllowUserToAddRows = true;
                this.dgrdv.AllowUserToDeleteRows = true;
                this.dgrdv.ReadOnly = false;
                this.dgrdv.RowValidated += new DataGridViewCellEventHandler(dgrdv_RowValidated);
            }
        }

        void mRefresh_Click(object sender, EventArgs e)
        {
            InitColumns();
            LoadData();
        }

       
        private FrmUserRole frmUserRole;
        private JERPData.Frame.Users accUser;
       
        private DataTable dtblUsers;
        
        private void InitColumns()
        {
            if (this.dtblUsers != null)
            {
                this.dtblUsers.Clear();
            }
            DataTable dtbl = (new JERPData.Hr.Personnel()).GetDataPersonnel ().Tables [0];
         
            this.ColumnPsnID.DataSource = dtbl;
            dtbl.Columns.Add("Exp", typeof(string), "ISNULL(AssistantCode,'')+ISNULL(PsnName,'')");
            this.ColumnPsnID.DisplayMember = "Exp";
            this.ColumnPsnID.ValueMember = "PsnID";
        }
        private void LoadData()
        {             
            this.dtblUsers = this.accUser.GetDataUsers().Tables[0];
            this.dtblUsers.Columns["PsnID"].Unique = true;
            this.dtblUsers.Columns["UserName"].AllowDBNull = false;
            this.dtblUsers.Columns["UserName"].Unique = true;
            this.dtblUsers.Columns["UserPassword"].AllowDBNull = false;
            this.dtblUsers.Columns["PsnID"].AllowDBNull = false;
            this.dgrdv.DataSource = this.dtblUsers;
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
                drow = this.dtblUsers .DefaultView[irow].Row;
            }
            catch
            {
                return;
            }
            if (drow.RowState == DataRowState.Unchanged) return;
            string errormsg = string.Empty;
            if (drow["UserID"]==DBNull .Value )
            {              
	            object  objUserID=null;
	            flag= this.accUser .InsertUsers(
                    ref errormsg ,
                    ref objUserID,
		            drow["UserName"],
		            drow["UserPassword"],
		            drow["PsnID"]);
	            if(flag)
	            {
		            drow["UserID"]=objUserID;
                    drow.AcceptChanges();
	            }
                else
                {
                    MessageBox.Show("添加用户失败");
                }
            }
            else 
            {
                flag =this.accUser.UpdateUsers(
                    ref errormsg ,
                    drow["UserID"],
                    drow["UserName"],
                    drow["UserPassword"],
                    drow["PsnID"]);
                if (flag)
                {
                    drow.AcceptChanges();
                }
                else
                {
                    MessageBox.Show("用户变更失败！");
                }
            }
               
          
        }

        private void dgrdv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int i= e.Row.Index;
            DataRow row = this.dtblUsers.Rows[i];
            bool flag=(row["UserID"]!=DBNull .Value );
            e.Cancel = flag;
            if (flag)
            {
                MessageBox.Show("对不起，此为数据库实际存在之数据，不允许删除");
            }
        }

        private void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int icol = e.ColumnIndex;
            int irow = e.RowIndex;
            if ((icol == -1) || (irow == -1)) return;
            if (this.dgrdv .Columns [icol ].Name ==this.RolelistColumn.Name)
            {
              
                DataRow drow=this.dtblUsers.DefaultView[irow].Row ;               
                if ((drow==null)||(drow["UserID"] == DBNull.Value))
                {
                    MessageBox.Show("因为数据库中该用户不存在，所以不能设置，请先错行保存！");
                    return;
                }
                short userID = (short)drow["UserID"];
                if (frmUserRole == null)
                {
                    frmUserRole = new FrmUserRole();
                    frmUserRole.AffterSave += new FrmUserRole.AffterSaveDelegate(frmUserRole_AffterSave);
                }
                frmUserRole.UserID = userID;
                frmUserRole.UserInfor = "登录名:" + (string)drow["UserName"];
                (new FrmStyle(frmUserRole )).SetPopFrmStyle(this);
                frmUserRole.ShowDialog();
            }
        }

        void frmUserRole_AffterSave()
        {
            this.LoadData();
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在打印中，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder  + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "系统用户表");
            int rowIndex = 2;
            int colIndex = 1;
            excel.ImportGridData(this.dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(2, 1, rowIndex, colIndex );
            excel.SetRangeAutoFit(2, 1, rowIndex, colIndex , true, true);

            FrmMsg.Hide();
            excel.Show();

        }
      
    }
}