using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Tool
{
    public partial class FrmPosition : Form
    {
        private DataTable dtblPositions;
        private JERPData.Tool.Position accPosition;
        public FrmPosition()
        {
            InitializeComponent();
            this.accPosition = new JERPData.Tool.Position();
            this.dgrdv.AutoGenerateColumns = false;
            this.dgrdv.RowValidated +=new DataGridViewCellEventHandler(dgrdv_RowValidated);
            this.dgrdv .UserDeletingRow +=new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
            LoadData();
        }
      
        private void LoadData()
        {
            this.dtblPositions = this.accPosition.GetDataPosition().Tables[0];
            this.dtblPositions.Columns["PositionName"].AllowDBNull = false;
            this.dtblPositions.Columns["PositionName"].Unique = true;
            this.dgrdv.DataSource = this.dtblPositions;
        }

     
  
        void dgrdv_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
           
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            bool flag = false;
            if (irow > this.dtblPositions .Rows.Count - 1) return;
            DataRow drow ;
            try
            {
                drow = this.dtblPositions.DefaultView[irow].Row;
            }
            catch
            {
                return;
            }
            if (drow.RowState == DataRowState.Unchanged) return;
            string errormsg=string.Empty ;
            if (drow == null) return;
            if (drow["PositionID"] == DBNull.Value)
            {
                object objPositionID = DBNull.Value;
                flag = this.accPosition.InsertPosition(
                    ref errormsg,
                    ref objPositionID,
                    drow["PositionName"]);
                if (flag)
                {
                    drow["PositionID"] = objPositionID;
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
                flag = this.accPosition .UpdatePosition (
                    ref errormsg ,
                    drow["PositionID"],
                    drow["PositionName"]);
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
            DataRow drow = this.dtblPositions  .DefaultView[irow].Row;
            string ErrorMsg = string.Empty;
            if (drow["PositionID"] == DBNull.Value)
            {
        
                return;
            }

            int  PositionID = (int)drow["PositionID"];
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {
                flag = this.accPosition.DeletePosition(ref ErrorMsg,
                    PositionID);
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