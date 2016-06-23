using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Asset
{
    public partial class FrmPrdRepair : Form
    {
        public FrmPrdRepair()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accRecord = new JERPData.Asset.PrdRepairRecord();         
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.dgrdv .UserDeletingRow +=new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
            this.FormClosed += new FormClosedEventHandler(FrmPrdRepairRecord_FormClosed);
        }

     
        private JERPData.Asset.PrdRepairRecord accRecord;
        private DataTable dtblRecord;
        private int PrdID = -1;
        public void RepairRecord(int PrdID)
        {
            this.PrdID = PrdID;
            this.dtblRecord = this.accRecord.GetDataPrdRepairRecordByPrdID(PrdID).Tables[0];
            this.dgrdv.DataSource = this.dtblRecord;
        }
        public delegate void AffterSaveDelegate(int PrdID,object objDateLastRepair);
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
       
        void dgrdv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            bool flag = false;
            DataRow drow = this.dtblRecord .DefaultView[irow].Row;
            string ErrorMsg = string.Empty;
            if (drow["RecordID"] == DBNull.Value)
            {
                e.Cancel = true;
                return;
            }
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {
                flag = this.accRecord .DeletePrdRepairRecord (ref ErrorMsg,
                    drow["RecordID"]);
                if (!flag)
                {

                    MessageBox.Show(ErrorMsg);
                }
            }
            else
            {
                e.Cancel = true;
            }
        }
        private bool ValidateData()
        {

            DataRow[] drows = this.dtblRecord .Select("DateRepair is null", "");
            if (drows.Length > 0)
            {
                MessageBox.Show("日期不能为空");
                return false;
            }
            return true;
        }
        void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateData() == false) return;
            string errormsg = string.Empty;
            bool flag = false;
            foreach (DataRow drow in this.dtblRecord .Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow.RowState == DataRowState.Unchanged) continue;
                if (drow["RecordID"] == DBNull.Value)
                {
                    object objRecordID = DBNull.Value;
                    flag = this.accRecord .InsertPrdRepairRecord (
                        ref errormsg,
                        ref objRecordID,
                        this.PrdID ,
                        drow["DateRepair"],
                        drow["Remark"]);
                    if (flag)
                    {
                        drow["RecordID"] = objRecordID;
                        drow.AcceptChanges();
                    }

                }
                else
                {
                    this.accRecord .UpdatePrdRepairRecord (
                        ref errormsg ,
                        drow["RecordID"],
                        drow["DateRepair"],
                        drow["Remark"]);
                      
                 
                }
                if (flag)
                {
                    drow.AcceptChanges();
                }
                else
                {
                    MessageBox.Show(errormsg);
                }

            }
            MessageBox.Show("成功保存维修记录");
        }
        void FrmPrdRepairRecord_FormClosed(object sender, FormClosedEventArgs e)
        {
            object objDateLastRepair = DBNull.Value;
            DataRow[] drows = this.dtblRecord.Select("", "", DataViewRowState.CurrentRows);
            if (drows.Length > 0)
            {
                objDateLastRepair = drows[drows.Length - 1]["DateRepair"];
            }
            if (this.affterSave != null) this.affterSave(this.PrdID ,objDateLastRepair);
        }

    }
}