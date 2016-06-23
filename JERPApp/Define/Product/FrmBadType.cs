using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Product
{
    public partial class FrmBadType : Form
    {
        private DataTable dtblBadTypes;
        private JERPData.Product.BadType accBadType;
        public FrmBadType()
        {
            InitializeComponent();
            this.accBadType = new JERPData.Product.BadType();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlGridQFind.SeachGridView = this.dgrdv;
            this.dgrdv.RowValidated += new DataGridViewCellEventHandler(dgrdv_RowValidated);
            this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
            this.FormClosed += new FormClosedEventHandler(FrmBadType_FormClosed);
            this.LoadData();

        }
      
        void FrmBadType_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.affterSave != null) this.affterSave();
        }

        public void LoadData()
        {
            DataSet dst = this.accBadType.GetDataBadType ();
            this.dtblBadTypes = dst.Tables[0];
            this.dtblBadTypes.Columns["BadTypeCode"].Unique = true;
            this.dtblBadTypes.Columns["BadTypeCode"].AllowDBNull = false;           
            this.dtblBadTypes.Columns["BadTypeName"].AllowDBNull = false;
            this.dtblBadTypes.Columns["BadTypeName"].Unique = true;
            this.dgrdv.DataSource = this.dtblBadTypes;
        }
        void dgrdv_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
           
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            bool flag = false;
            if (irow > this.dtblBadTypes .Rows.Count - 1) return;
            DataRow drow ;
            try
            {
                drow = this.dtblBadTypes.DefaultView[irow].Row;
            }
            catch
            {
                return;
            }
            if (drow.RowState == DataRowState.Unchanged) return;
            string errormsg=string.Empty ;
            if (drow == null) return;
            if (drow["BadTypeID"] == DBNull.Value)
            {
                object objBadTypeID = DBNull.Value;
                flag = this.accBadType.InsertBadType(
                    ref errormsg,
                    ref objBadTypeID,
                    drow["BadTypeCode"],
                    drow["BadTypeName"]);
                if (flag)
                {
                    drow["BadTypeID"] = objBadTypeID;
                }
                else
                {
                    MessageBox.Show(errormsg );
                }
            }
            else
            {
                flag = this.accBadType .UpdateBadType (
                    ref errormsg ,
                    drow["BadTypeID"],
                    drow["BadTypeCode"],
                    drow["BadTypeName"]);
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
            bool flag = false;
            DataRow drow = this.dtblBadTypes  .DefaultView[irow].Row;
            string ErrorMsg = string.Empty;
            if (drow["BadTypeID"] == DBNull.Value)
            {
                e.Cancel = true;
                return;
            }

            int  BadTypeID = (int)drow["BadTypeID"];
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {
                flag = this.accBadType.DeleteBadType(ref ErrorMsg,
                    BadTypeID);
                if (!flag)
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