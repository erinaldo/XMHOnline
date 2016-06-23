using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Product
{
    public partial class FrmParmTemplet : Form
    {
       
        public FrmParmTemplet()
        {
            InitializeComponent();
            this.accParmTemplet = new JERPData.Product.ParmTemplet();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlGridQFind.SeachGridView = this.dgrdv;
            this.FormClosed += new FormClosedEventHandler(FrmParmTemplet_FormClosed);
            this.LoadData();      
            this.dgrdv.RowValidated += new DataGridViewCellEventHandler(dgrdv_RowValidated);
            this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);

        }
        private DataTable dtblParmTemplets;
        private JERPData.Product.ParmTemplet accParmTemplet;
        void FrmParmTemplet_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.affterSave != null) this.affterSave();
        }

        private void LoadData()
        {
            DataSet dst = this.accParmTemplet.GetDataParmTemplet ();
            this.dtblParmTemplets = dst.Tables[0];      
            this.dtblParmTemplets.Columns["TempletName"].AllowDBNull = false;
            this.dtblParmTemplets.Columns["TempletName"].Unique = true;
            this.dgrdv.DataSource = this.dtblParmTemplets;
        }
        void dgrdv_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
           
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            bool flag = false;
            DataRow drow ;
            try
            {
                drow = this.dtblParmTemplets.DefaultView[irow].Row;
            }
            catch
            {
                return;
            }
            if (drow == null) return;
            if (drow.RowState == DataRowState.Unchanged) return;
            string errormsg=string.Empty ;
         
            if (drow["TempletID"] == DBNull.Value)
            {
                object objTempletID = DBNull.Value;
                flag = this.accParmTemplet.InsertParmTemplet(
                    ref errormsg,
                    ref objTempletID,
                    drow["TempletName"]);
                if (flag)
                {
                    drow["TempletID"] = objTempletID;
                }
                else
                {
                    MessageBox.Show(errormsg );
                }
            }
            else
            {
                flag = this.accParmTemplet .UpdateParmTemplet (
                    ref errormsg ,
                    drow["TempletID"],
                    drow["TempletName"]);
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
            DataRow drow = this.dtblParmTemplets  .DefaultView[irow].Row;
            string ErrorMsg = string.Empty;
            if (drow["TempletID"] == DBNull.Value)
            {
              
                return;
            }

            int  TempletID = (int)drow["TempletID"];
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {
                flag = this.accParmTemplet.DeleteParmTemplet(ref ErrorMsg,
                    TempletID);
                if (!flag)
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