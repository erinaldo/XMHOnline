using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Sale.Define
{
    public partial class FrmProcessType : Form
    {
      
        public FrmProcessType()
        {
            InitializeComponent();
            this.accProcessType = new JERPData.General.CustomerProcessType ();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlGridQFind.SeachGridView = this.dgrdv;
            this.SetPermit();

        }
        private DataTable dtblProcessTypes;
        private JERPData.General .CustomerProcessType  accProcessType;
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(631);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(632);
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
                this.FormClosed += this.FrmProcessType_FormClosed;
                this.dgrdv.RowValidated += new DataGridViewCellEventHandler(dgrdv_RowValidated);
                this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);

            }
        }
        private void LoadData()
        {
            DataSet dst = this.accProcessType.GetDataCustomerProcessType();
            this.dtblProcessTypes = dst.Tables[0];    
            this.dtblProcessTypes.Columns["ProcessTypeName"].AllowDBNull = false;
            this.dtblProcessTypes.Columns["ProcessTypeName"].Unique = true;
            this.dgrdv.DataSource = this.dtblProcessTypes;
        }
        void dgrdv_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
           
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            bool flag = false;
            if (irow > this.dtblProcessTypes .Rows.Count - 1) return;
            DataRow drow ;
            try
            {
                drow = this.dtblProcessTypes.DefaultView[irow].Row;
            }
            catch
            {
                return;
            }
            if (drow.RowState == DataRowState.Unchanged) return;
            string errormsg=string.Empty ;
            if (drow == null) return;
            if (drow["ProcessTypeID"] == DBNull.Value)
            {
                object objProcessTypeID = DBNull.Value;
                flag = this.accProcessType.InsertCustomerProcessType (
                    ref errormsg,
                    ref objProcessTypeID,
                    drow["ProcessTypeName"]);
                if (flag)
                {
                    drow["ProcessTypeID"] = objProcessTypeID;
                }
                else
                {
                    MessageBox.Show(errormsg );
                }
            }
            else
            {
                flag = this.accProcessType.UpdateCustomerProcessType(
                    ref errormsg ,
                    drow["ProcessTypeID"],
                    drow["ProcessTypeName"]);
                if (flag)
                {
                    if (this.affterSave != null) this.affterSave();
                }
                else
                {
                    MessageBox.Show(errormsg );
                }
            }
        }
        private void dgrdv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            DataRow drow = this.dtblProcessTypes  .DefaultView[irow].Row;
            string ErrorMsg = string.Empty;
            if (drow["ProcessTypeID"]!= DBNull.Value)
            {
                MessageBox.Show("对不起,此记录已存在不能删除");
                return;
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
        void FrmProcessType_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.affterSave != null) this.affterSave();
        }

    }
}