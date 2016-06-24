using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Engineer.Define
{
    public partial class FrmManuPrdType : Form
    {
        public FrmManuPrdType()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accManuPrdType = new JERPData.Product.ManuPrdType();
            this.SetPermit();
        }


        private JERPData.Product.ManuPrdType accManuPrdType;
        private DataTable dtblPrdType;
        private JERPApp.Define.Product.FrmManuPrdType frmAlterManuType;
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存


        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(11);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(12);
            if (this.enableBrowse)
            {
                this.LoadData();
                this.ctrlParentID.AffterSelected += this.LoadData;
                this.ctrlParentID.BeforeSelected += new JERPApp.Define.Product.CtrlCommonTypeTree.BeforeSelectDelegate(ctrlParentID_BeforeSelected);
                this.dgrdv.ContextMenuStrip = this.cMenu;
            }
            this.btnSave.Enabled = this.enableSave;
            this.dgrdv.AllowUserToDeleteRows = this.enableSave;
            this.dgrdv.ReadOnly = !this.enableSave;
            this.dgrdv.AllowUserToAddRows = this.enableSave;
            this.mItemAlterType.Enabled = this.enableSave;
            if (this.enableSave)
            {

                this.mItemAlterType.Click += new EventHandler(mItemAlterType_Click);
                this.btnSave.Click += new EventHandler(btnSave_Click);
                this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
            }
        }

  
        private void LoadData()
        {
            this.dtblPrdType = this.accManuPrdType.GetDataPrdTypeByParentID(this.ctrlParentID.PrdTypeID).Tables[0];
            this.dgrdv.DataSource = this.dtblPrdType;
        }

        void ctrlParentID_BeforeSelected(out bool CancelFlag)
        {

            foreach (DataRow drow in this.dtblPrdType.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow.RowState == DataRowState.Unchanged) continue;
                DialogResult rul = MessageBox.Show("存在未保存的项,是否需要保存再选择?", "操作提醒", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rul == DialogResult.OK)
                {
                    CancelFlag = true;
                }
                else
                {
                    CancelFlag = false;
                }
                return;
            }
            CancelFlag = false;
        }

        void mItemAlterType_Click(object sender,EventArgs e) {
            if (frmAlterManuType == null)
            {
                frmAlterManuType = new JERPApp.Define.Product.FrmManuPrdType();
                new FrmStyle(frmAlterManuType).SetPopFrmStyle(this);
                frmAlterManuType.AffterSelected += new JERPApp.Define.Product.FrmManuPrdType.AffterSelectedDelegate(frmAlterManuType_AffterSelected);
            }
            frmAlterManuType.ShowDialog();
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            string errormsg = string.Empty;
            int ParentID = this.ctrlParentID.PrdTypeID;
            bool flag = false;
            object objPrdTypeID = DBNull.Value;
            foreach (DataRow drow in this.dtblPrdType.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow.RowState == DataRowState.Unchanged) continue;
                if (drow["ManuPrdTypeID"] == DBNull.Value)
                {
                    objPrdTypeID = DBNull.Value;
                     flag= this.accManuPrdType.InsertPrdType(
                     ref errormsg,
                     ref objPrdTypeID,
                     drow["ManuPrdTypeCode"],
                     drow["ManuPrdTypeName"],
                     ParentID);
                    if (flag)
                    {
                        drow["ManuPrdTypeID"] = objPrdTypeID;
                    }else{
                        MessageBox.Show(errormsg);
                        return;
                    }

                }
                else
                {
                    flag= this.accManuPrdType.UpdatePrdType(
                        ref errormsg,
                        drow["ManuPrdTypeID"],
                        drow["ManuPrdTypeCode"],
                        drow["ManuPrdTypeName"],
                        ParentID);
                    if (!flag)
                    {
                        MessageBox.Show(errormsg);
                        return;
                    }
                }
                drow.AcceptChanges();
            }
            MessageBox.Show("成功进行保存操作");
        }



        void frmAlterManuType_AffterSelected()
        {
            int ParentID = this.frmAlterManuType.PrdTypeID;
            string errormsg = string.Empty;
            DataRow drow;
            foreach (DataGridViewRow grow in this.dgrdv.Rows)
            {
                if (grow.IsNewRow) continue;
                if (!grow.Selected) continue;
                drow = this.dtblPrdType.DefaultView[grow.Index].Row;
                if (this.GetAllowAlterFlag(drow, ParentID) == false)
                {
                    MessageBox.Show("对不起，不能将子集设为父集");
                    this.LoadData();
                    return;
                }
                if (drow["ManuPrdTypeID"] == DBNull.Value)
                {
                    object objPrdTypeID = DBNull.Value;
                    this.accManuPrdType.InsertPrdType(
                     ref errormsg,
                     ref objPrdTypeID,
                     drow["ManuPrdTypeCode"],
                     drow["ManuPrdTypeName"],
                     ParentID);
                }
                else
                {
                    this.accManuPrdType.UpdatePrdType(
                        ref errormsg,
                        drow["ManuPrdTypeID"],
                         drow["ManuPrdTypeCode"],
                        drow["ManuPrdTypeName"],
                        ParentID);
                }

            }
            MessageBox.Show("成功变换当前选中行的类别");
            this.LoadData();
            this.frmAlterManuType.Close();

        }

        private bool GetAllowAlterFlag(DataRow drow, int ParentID)
        {
            if (drow["ManuPrdTypeID"] == DBNull.Value) return true;
            bool flag = false;
            this.accManuPrdType.GetParmPrdTypeIsChildTree(ParentID, (int)drow["ManuPrdTypeID"], ref flag);
            return !flag;
        }

        void dgrdv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            bool flag = false;
            DataRow drow = this.dtblPrdType.DefaultView[irow].Row;
            string ErrorMsg = string.Empty;
            if (drow["ManuPrdTypeID"] == DBNull.Value)
            {
                e.Cancel = true;
                return;
            }
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {
                flag = this.accManuPrdType.DeletePrdType(ref ErrorMsg,
                    drow["ManuPrdTypeID"]);
                if (!flag)
                {

                    MessageBox.Show(ErrorMsg);
                    e.Cancel = true;
                    return;
                }
            }
            else
            {
                e.Cancel = true;
            }
        } 
    }
}
