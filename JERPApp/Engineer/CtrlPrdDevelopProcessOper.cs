using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Engineer
{
    public partial class CtrlPrdDevelopProcessOper : UserControl
    {
        public CtrlPrdDevelopProcessOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accDevelopProcess = new JERPData.Technology.DevelopProcess();
            this.accPrds = new JERPData.Product.Product();
            this.accProcessType = new JERPData.Technology.ProcessType();
            this.accTempletItems = new JERPData.Technology.ProcessTempletItems();
            this.SetColumnSrc();
            this.dgrdv.ContextMenuStrip = this.cMenu;
            this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
            this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
            this.btnLoad.Click += new EventHandler(btnLoad_Click);
        }

        private JERPData.Technology.ProcessType accProcessType;
        private JERPData.Technology.DevelopProcess accDevelopProcess;
        private JERPData.Product.Product accPrds;
        private JERPData.Technology.ProcessTempletItems accTempletItems;
        private DataTable dtblDevelopProcess, dtblProcessType;
        private int prdid = -1;
        private int PrdID
        {
            get
            {
                return this.prdid;
            }
            set
            {
                this.prdid = value;
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

        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.DevelopProcessOper(this.PrdID);
        } 
        private void SetColumnSrc()
        {
            this.dtblProcessType = this.accProcessType.GetDataProcessType().Tables[0];         
            this.ColumnProcessTypeID.DataSource = this.dtblProcessType;
            this.ColumnProcessTypeID.ValueMember = "ProcessTypeID";
            this.ColumnProcessTypeID.DisplayMember = "ProcessTypeName";
        }
        public void DevelopProcessOper(int PrdID)
        {
            this.PrdID = PrdID;
            this.dtblDevelopProcess = this.accDevelopProcess.GetDataDevelopProcessByPrdID(PrdID).Tables[0];
            this.dtblDevelopProcess.Columns["SerialNo"].Unique  = true;
            this.dtblDevelopProcess.Columns["SerialNo"].AllowDBNull = false;
            this.dgrdv.DataSource = this.dtblDevelopProcess;

        }

      
      
            
        private void dgrdv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            bool flag = false;
            DataRow drow = this.dtblDevelopProcess.DefaultView[irow].Row;
            string ErrorMsg = string.Empty;
            if (drow["DevelopProcessID"] == DBNull.Value)
            {
                return;
            }

            long DevelopProcessID = (long)drow["DevelopProcessID"];
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {
                flag = this.accDevelopProcess.DeleteDevelopProcess(ref ErrorMsg,
                    DevelopProcessID);
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
        void btnLoad_Click(object sender, EventArgs e)
        {
            DataTable dtblProcessTemplet = this.accTempletItems.GetDataProcessTempletItemsByTempletID(this.ctrlProcessTempletID.TempletID).Tables[0];
            foreach (DataRow drow in dtblProcessTemplet.Rows)
            {
                if (this.dtblDevelopProcess.Select("SerialNo=" + drow["SerialNo"].ToString() + " and ProcessTypeID=" + drow["ProcessTypeID"].ToString(), "", DataViewRowState.CurrentRows).Length > 0) continue;
                DataRow drowNew = this.dtblDevelopProcess.NewRow();
                drowNew["SerialNo"] = drow["SerialNo"];
                drowNew["ProcessTypeID"] = drow["ProcessTypeID"];
                drowNew["Memo"] = drow["Memo"];
                this.dtblDevelopProcess.Rows.Add(drowNew);
            }
        }      
        public void Save(int PrdID)
        {
            bool flag = true;
            string errormsg = string.Empty;
            object objDevelopProcessID = DBNull.Value;
            foreach (DataRow drow in this.dtblDevelopProcess.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow["DevelopProcessID"] == DBNull.Value)
                {
                    flag = this.accDevelopProcess.InsertDevelopProcess(ref errormsg,
                        ref objDevelopProcessID,
                        PrdID,
                        drow["SerialNo"],
                        drow["ProcessTypeID"],
                        drow["Memo"],
                        drow["DateTarget"],
                        drow["DateFinished"],
                        drow["FinishedRemark"]);
                    if (flag)
                    {
                        drow["DevelopProcessID"] = objDevelopProcessID;
                        drow.AcceptChanges();
                    }
                    else
                    {
                        MessageBox.Show(errormsg);
                    }
                }
                else
                {
                    flag = this.accDevelopProcess.UpdateDevelopProcess(ref errormsg,
                        drow["DevelopProcessID"],
                        drow["SerialNo"],
                        drow["ProcessTypeID"],
                        drow["Memo"],
                        drow["DateTarget"],
                        drow["DateFinished"],
                        drow["FinishedRemark"]);
                    if (flag)
                    {
                        drow.AcceptChanges();
                    }
                }
            }
        }
    }
}
