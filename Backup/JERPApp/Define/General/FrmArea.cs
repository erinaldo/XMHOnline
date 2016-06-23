using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.General
{
    public partial class FrmArea : Form
    {
        private DataTable dtblArea;
        private JERPData.General.Area accArea;
        public FrmArea()
        {
            InitializeComponent();
            this.accArea = new JERPData.General.Area();
            this.dgrdv.AutoGenerateColumns = false;            
            this.LoadData();
            this.dgrdv .UserDeletingRow +=new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
            this.dgrdv .RowValidated +=new DataGridViewCellEventHandler(dgrdv_RowValidated);
            this.FormClosed += new FormClosedEventHandler(FrmArea_FormClosed);
        }

      
        private void LoadData()
        {
            this.dtblArea = this.accArea.GetDataArea ().Tables[0];           
            this.dtblArea.Columns["AreaName"].AllowDBNull = false;      
            this.dgrdv.DataSource = this.dtblArea;
        }
      

        void dgrdv_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
        
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            bool flag = true;
            DataRow drow = null;
            try
            {
                drow = this.dtblArea .DefaultView[irow].Row;
            }
            catch
            {
                return;
            }
            string errormsg = string.Empty;
            if (drow["AreaID"] == DBNull.Value)
            {
                object objAreaID = 0;
                flag = this.accArea.InsertArea (
                        ref errormsg,
                        ref objAreaID,
                        drow["AreaName"]);
                if (flag)
                {                   
                    drow["AreaID"] = objAreaID;
                }
                else
                {
                    MessageBox.Show(errormsg);
                   
                }
            }
            else
            {
                flag = this.accArea.UpdateArea (
                        ref errormsg,
                      drow["AreaID"],
                      drow["AreaName"]);
                if (flag)
                {
                    if (this.affterSave != null) this.affterSave();
                }
                else
                {
                    MessageBox.Show(errormsg);
                
                }

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

        void FrmArea_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.affterSave != null) this.affterSave();
        }
        private void dgrdv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            bool flag = false;
            DataRow drow = this.dtblArea  .DefaultView[irow].Row;
            if (drow["AreaID"] == DBNull.Value)
            {
                e.Cancel = true;
                return;
            }
            int  AreaID = (int)drow["AreaID"];
            string errormsg = string.Empty;
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {

                flag = this.accArea.DeleteArea (ref errormsg, AreaID);
                if (!flag)
                {
                   MessageBox .Show (errormsg );
                }
            }
            else
            {
                e.Cancel = true;
            }
        }
    
    }
}