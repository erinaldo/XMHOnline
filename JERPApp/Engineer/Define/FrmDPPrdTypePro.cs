using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Engineer.Define
{
    public partial class FrmDPPrdTypePro : Form
    {
        private static int m_Type = 20;
        public FrmDPPrdTypePro()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accDPPrdTypePro = new JERPData.Product.DPPrdTypePro();
            this.ctrlParentID.InitiaParam(m_Type);
            this.SetPermit();
        }


        private JERPData.Product.DPPrdTypePro accDPPrdTypePro;
        private DataTable dtblPrdType;

        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存


        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(26);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(27);
            if (this.enableBrowse)
            {
                this.LoadData();
                this.ctrlParentID.AffterSelected += this.LoadData;
                this.ctrlParentID.BeforeSelected += new JERPApp.Define.Product.CtrlDPTypeTreePro.BeforeSelectDelegate(ctrlParentID_BeforeSelected);
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
            this.dtblPrdType = this.accDPPrdTypePro.GetDataDPPrdTypeProByParentID(this.ctrlParentID.PrdTypeID).Tables[0];
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
            //if (frmAlterManuType == null)
            //{
            //    frmAlterManuType = new JERPApp.Define.Product.FrmManuPrdType();
            //    new FrmStyle(frmAlterManuType).SetPopFrmStyle(this);
            //    frmAlterManuType.AffterSelected += new JERPApp.Define.Product.FrmManuPrdType.AffterSelectedDelegate(frmAlterManuType_AffterSelected);
            //}
            //frmAlterManuType.ShowDialog();
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            string errormsg = string.Empty;
            int ParentID = this.ctrlParentID.PrdTypeID;
            bool flag = false;
            object objPrdTypeID = DBNull.Value;
            int rootID = 0;
            foreach (DataRow drow in this.dtblPrdType.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow.RowState == DataRowState.Unchanged) continue;
                if (drow["PrdTypeID"] == DBNull.Value)
                {
                    objPrdTypeID = DBNull.Value;
                     flag= this.accDPPrdTypePro.InsertDPPrdTypePro(
                     ref errormsg,
                     ref objPrdTypeID,
                     drow["PrdTypeCode"],
                     drow["PrdTypeName"],
                     m_Type,
                     ParentID,
                     rootID);
                    if (flag)
                    {
                        drow["PrdTypeID"] = objPrdTypeID;
                    }else{
                        MessageBox.Show(errormsg);
                        return;
                    }

                }
                else
                {
                    flag = this.accDPPrdTypePro.UpdateDPPrdTypePro(
                        ref errormsg,
                        drow["PrdTypeID"],
                        drow["PrdTypeCode"],
                        drow["PrdTypeName"]);
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

        void dgrdv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            bool flag = false;
            DataRow drow = this.dtblPrdType.DefaultView[irow].Row;
            string ErrorMsg = string.Empty;
            if (drow["PrdTypeID"] == DBNull.Value)
            {
                e.Cancel = true;
                return;
            }
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {
                flag = this.accDPPrdTypePro.DeleteDPPrdTypePro(ref ErrorMsg,
                    drow["PrdTypeID"]);
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
