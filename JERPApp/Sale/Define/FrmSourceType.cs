using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Sale.Define
{
    public partial class FrmSourceType : Form
    {
      
        public FrmSourceType()
        {
            InitializeComponent();
            this.accSourceType = new JERPData.General.CustomerSourceType ();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlGridQFind.SeachGridView = this.dgrdv;   
            this.SetPermit();
        }
        private DataTable dtblSourceTypes;
        private JERPData.General .CustomerSourceType  accSourceType;
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(629);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(630);
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
                this.FormClosed += new FormClosedEventHandler(FrmSourceType_FormClosed);
                this.dgrdv.RowValidated += new DataGridViewCellEventHandler(dgrdv_RowValidated);
                this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);

            }
        }
       
        private void LoadData()
        {
            DataSet dst = this.accSourceType.GetDataCustomerSourceType  ();
            this.dtblSourceTypes = dst.Tables[0];    
            this.dtblSourceTypes.Columns["SourceTypeName"].AllowDBNull = false;
            this.dtblSourceTypes.Columns["SourceTypeName"].Unique = true;
            this.dgrdv.DataSource = this.dtblSourceTypes;
        }
        void dgrdv_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
           
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            bool flag = false;
            if (irow > this.dtblSourceTypes .Rows.Count - 1) return;
            DataRow drow ;
            try
            {
                drow = this.dtblSourceTypes.DefaultView[irow].Row;
            }
            catch
            {
                return;
            }
            if (drow.RowState == DataRowState.Unchanged) return;
            string errormsg=string.Empty ;
            if (drow == null) return;
            if (drow["SourceTypeID"] == DBNull.Value)
            {
                object objSourceTypeID = DBNull.Value;
                flag = this.accSourceType.InsertCustomerSourceType (
                    ref errormsg,
                    ref objSourceTypeID,
                    drow["SourceTypeName"]);
                if (flag)
                {
                    drow["SourceTypeID"] = objSourceTypeID;
                }
                else
                {
                    MessageBox.Show(errormsg );
                }
            }
            else
            {
                flag = this.accSourceType.UpdateCustomerSourceType(
                    ref errormsg ,
                    drow["SourceTypeID"],
                    drow["SourceTypeName"]);
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
            DataRow drow = this.dtblSourceTypes  .DefaultView[irow].Row;
            string ErrorMsg = string.Empty;
            if (drow["SourceTypeID"]!= DBNull.Value)
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
        void FrmSourceType_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.affterSave != null) this.affterSave();
        }

    }
}