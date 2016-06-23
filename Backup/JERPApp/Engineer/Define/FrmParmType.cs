using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Engineer.Define
{
    public partial class FrmParmType : Form
    {
        private DataTable dtblParmTypes;
        private JERPData.Product .ParmType accParmType;
        public FrmParmType()
        {
            InitializeComponent();
            this.accParmType = new JERPData.Product .ParmType();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.SetPermit();
        }
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存           

        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(173);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(174);
            if (this.enableBrowse)
            {
                this.LoadData();
                this.dgrdv.ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
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

        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
        private void LoadData()
        {
            DataSet dst = this.accParmType.GetDataParmType ();
            this.dtblParmTypes = dst.Tables[0];       
            this.dtblParmTypes.Columns["ParmTypeName"].AllowDBNull = false;
            this.dtblParmTypes.Columns["ParmTypeName"].Unique = true;
            this.dgrdv.DataSource = this.dtblParmTypes;
        }

     
  
        void dgrdv_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
           
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            bool flag = false;
            if (irow > this.dtblParmTypes .Rows.Count - 1) return;
            DataRow drow ;
            try
            {
                drow = this.dtblParmTypes.DefaultView[irow].Row;
            }
            catch
            {
                return;
            }
            if (drow.RowState == DataRowState.Unchanged) return;
            string errormsg=string.Empty ;
            if (drow == null) return;
            if (drow["ParmTypeID"] == DBNull.Value)
            {
                object objParmTypeID = DBNull.Value;
                flag = this.accParmType.InsertParmType(
                    ref errormsg,
                    ref objParmTypeID,
                    drow["ParmTypeName"],
                    drow["DefaultValue"],
                    drow["ItemValues"]);
                if (flag)
                {
                    drow["ParmTypeID"] = objParmTypeID;
                    if (this.affterSave != null) this.affterSave();
                }
                else
                {
                    MessageBox.Show(errormsg );
                    this.LoadData();
                }
            }
            else
            {
                flag = this.accParmType .UpdateParmType (
                    ref errormsg ,
                    drow["ParmTypeID"],
                    drow["ParmTypeName"],
                    drow["DefaultValue"],
                    drow["ItemValues"]);
                if (flag)
                {
                    if (this.affterSave != null) this.affterSave();
                }
                else
                {
                    MessageBox.Show(errormsg );
                    this.LoadData();
                }
            }
        }
        private void dgrdv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            bool flag = false;
            DataRow drow = this.dtblParmTypes  .DefaultView[irow].Row;
            string ErrorMsg = string.Empty;
            if (drow["ParmTypeID"] == DBNull.Value)
            {
           
                return;
            }

            int  ParmTypeID = (int)drow["ParmTypeID"];
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {
                flag = this.accParmType.DeleteParmType(ref ErrorMsg,
                    ParmTypeID);
                if (flag)
                {
                    if (this.affterSave != null)
                    {
                        this.affterSave();
                    }
                }
                else
                {
                   MessageBox .Show (ErrorMsg +"/n此记录已被其他业务引用，不能从数据库中删除");
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