using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture.Define
{
    public partial class FrmShift : Form
    {
        private DataTable dtblShifts;
        private JERPData.Manufacture .Shift accShift;
        public FrmShift()
        {
            InitializeComponent();
            this.accShift = new JERPData.Manufacture .Shift();
            this.dgrdv.AutoGenerateColumns = false;
            this.SetPermit();
        }
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存           

        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(352);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(353);
            if (this.enableBrowse)
            {
                this.LoadData();
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
        private void LoadData()
        {
            DataSet dst = this.accShift.GetDataShift ();
            this.dtblShifts = dst.Tables[0];
            this.dtblShifts.Columns["ShiftCode"].Unique = true;
            this.dtblShifts.Columns["ShiftCode"].AllowDBNull = false;           
            this.dtblShifts.Columns["ShiftName"].AllowDBNull = false;
            this.dtblShifts.Columns["ShiftName"].Unique = true;
            this.dgrdv.DataSource = this.dtblShifts;
        }

     
  
        void dgrdv_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
           
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            bool flag = false;
            if (irow > this.dtblShifts .Rows.Count - 1) return;
            DataRow drow ;
            try
            {
                drow = this.dtblShifts.DefaultView[irow].Row;
            }
            catch
            {
                return;
            }
            if (drow.RowState == DataRowState.Unchanged) return;
            string errormsg=string.Empty ;
            if (drow == null) return;
            if (drow["ShiftID"] == DBNull.Value)
            {
                object objShiftID = DBNull.Value;
                flag = this.accShift.InsertShift(
                    ref errormsg,
                    ref objShiftID,
                    drow["ShiftCode"],
                    drow["ShiftName"]);
                if (flag)
                {
                    drow["ShiftID"] = objShiftID;
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
                flag = this.accShift .UpdateShift (
                    ref errormsg ,
                    drow["ShiftID"],
                    drow["ShiftCode"],
                    drow["ShiftName"]);
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
            DataRow drow = this.dtblShifts  .DefaultView[irow].Row;
            string ErrorMsg = string.Empty;
            if (drow["ShiftID"] == DBNull.Value)
            {
           
                return;
            }

            int  ShiftID = (int)drow["ShiftID"];
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {
                flag = this.accShift.DeleteShift(ref ErrorMsg,
                    ShiftID);
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