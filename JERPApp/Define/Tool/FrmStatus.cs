using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Tool
{
    public partial class FrmStatus : Form
    {
        private DataTable dtblStatuss;
        private JERPData.Tool.Status accStatus;
        public FrmStatus()
        {
            InitializeComponent();
            this.accStatus = new JERPData.Tool.Status();
            this.dgrdv.AutoGenerateColumns = false;
            this.dgrdv.RowValidated +=new DataGridViewCellEventHandler(dgrdv_RowValidated);
            this.dgrdv .UserDeletingRow +=new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
            LoadData();
        }
      
        private void LoadData()
        {
            DataSet dst = this.accStatus.GetDataStatus ();
            this.dtblStatuss = dst.Tables[0];       
            this.dtblStatuss.Columns["StatusName"].AllowDBNull = false;
            this.dtblStatuss.Columns["StatusName"].Unique = true;
            this.dtblStatuss.Columns["AvailableManufFlag"].DefaultValue = true;
            this.dgrdv.DataSource = this.dtblStatuss;
        }

     
  
        void dgrdv_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
           
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            bool flag = false;
            if (irow > this.dtblStatuss .Rows.Count - 1) return;
            DataRow drow ;
            try
            {
                drow = this.dtblStatuss.DefaultView[irow].Row;
            }
            catch
            {
                return;
            }
            if (drow.RowState == DataRowState.Unchanged) return;
            string errormsg=string.Empty ;
            if (drow == null) return;
            if (drow["StatusID"] == DBNull.Value)
            {
                object objStatusID = DBNull.Value;
                flag = this.accStatus.InsertStatus(
                    ref errormsg,
                    ref objStatusID,
                    drow["StatusName"],
                    drow["AvailableManufFlag"]);
                if (flag)
                {
                    drow["StatusID"] = objStatusID;
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
                flag = this.accStatus .UpdateStatus (
                    ref errormsg ,
                    drow["StatusID"],
                    drow["StatusName"],
                    drow["AvailableManufFlag"]);
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
            DataRow drow = this.dtblStatuss.DefaultView[irow].Row;
            string ErrorMsg = string.Empty;
            if (drow["StatusID"] == DBNull.Value)
            {      
                return;
            }

            int  StatusID = (int)drow["StatusID"];
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {
                flag = this.accStatus.DeleteStatus(ref ErrorMsg,
                    StatusID);
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