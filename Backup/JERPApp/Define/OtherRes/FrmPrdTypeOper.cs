using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.OtherRes
{
    public partial class FrmPrdTypeOper : Form
    {
        public FrmPrdTypeOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accPrdType = new JERPData.OtherRes .PrdType();
            this.ctrlParentID.AffterSelected += this.LoadData;
            this.ctrlParentID.BeforeSelected += new CtrlPrdTypeParent.BeforeSelectDelegate(ctrlParentID_BeforeSelected);
            this.LoadData();

            this.dgrdv.ContextMenuStrip  = this.cMenu;
            this.mItemAlterType.Click += new EventHandler(mItemAlterType_Click); 
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
        }

        private JERPData.OtherRes .PrdType accPrdType;
        private DataTable dtblPrdType;
        private JERPApp.Define.OtherRes.FrmPrdType frmAlterType;
        void mItemAlterType_Click(object sender, EventArgs e)
        {
            if (frmAlterType == null)
            {
                frmAlterType = new FrmPrdType();
                new FrmStyle(frmAlterType).SetPopFrmStyle(this);
                frmAlterType.AffterSelected += frmAlterType_AffterSelected;
            }
            frmAlterType.ShowDialog();
        }
         
        private bool GetAllowAlterFlag(DataRow drow,int ParentID)
        {
            if (drow["PrdTypeID"] == DBNull.Value) return true;
            bool flag = false;
            this.accPrdType.GetParmPrdTypeIsChildTree(ParentID ,(int)drow["PrdTypeID"], ref flag);
            return !flag;
        }
        void frmAlterType_AffterSelected()
        {
            int ParentID = this.frmAlterType.PrdTypeID;
            string errormsg = string.Empty;
            DataRow drow;
            foreach (DataGridViewRow grow in this.dgrdv.Rows)
            {
                if (grow.IsNewRow) continue;
                if (!grow.Selected) continue;
                drow = this.dtblPrdType .DefaultView[grow.Index].Row;
                if (this.GetAllowAlterFlag(drow, ParentID)==false)
                {
                    MessageBox .Show ("对不起，不能将子集设为父集");
                    this.LoadData();
                    return;
                }
                if (drow["PrdTypeID"] == DBNull.Value)
                {
                    object objPrdTypeID = DBNull.Value;
                    this.accPrdType.InsertPrdType(
                     ref errormsg,
                     ref objPrdTypeID,
                     drow["PrdTypeName"],
                     ParentID);
                }
                else
                {
                    this.accPrdType.UpdatePrdType(
                        ref errormsg,
                        drow["PrdTypeID"],
                        drow["PrdTypeName"],
                        ParentID);
                }

            }
            MessageBox.Show("成功变换当前选中行的类别");
            this.LoadData(); 
            this.frmAlterType.Close();

        }

        void btnSave_Click(object sender, EventArgs e)
        {
            string errormsg = string.Empty;
            int ParentID = this.ctrlParentID.PrdTypeID;
            bool flag = false;
            object objPrdTypeID = DBNull.Value;
            foreach (DataRow drow in this.dtblPrdType .Rows )
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow.RowState == DataRowState.Unchanged) continue;
                if (drow["PrdTypeID"] == DBNull.Value)
                {
                    objPrdTypeID = DBNull.Value;
                    flag=this.accPrdType.InsertPrdType(
                     ref errormsg,
                     ref objPrdTypeID,
                     drow["PrdTypeName"],
                     ParentID);
                    if (flag)
                    {
                        drow["PrdTypeID"] = objPrdTypeID;
                    }

                }
                else
                {
                    this.accPrdType.UpdatePrdType(
                        ref errormsg,
                        drow["PrdTypeID"],
                        drow["PrdTypeName"],
                        ParentID);
                }
                drow.AcceptChanges();
            }
            MessageBox.Show("成功进行保存操作");
        }


      
        private void LoadData()
        {
            this.dtblPrdType = this.accPrdType.GetDataPrdTypeByParentID(this.ctrlParentID.PrdTypeID).Tables[0];
            this.dgrdv.DataSource = this.dtblPrdType;
        }

        void ctrlParentID_BeforeSelected(out bool CancelFlag)
        {

            foreach (DataRow drow in this.dtblPrdType .Rows)
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
        void dgrdv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            bool flag = false;
            DataRow drow = this.dtblPrdType .DefaultView[irow].Row;
            string ErrorMsg = string.Empty;
            if (drow["PrdTypeID"] == DBNull.Value)
            {
                e.Cancel = true;
                return;
            }
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {
                flag = this.accPrdType .DeletePrdType (ref ErrorMsg,
                    drow["PrdTypeID"]);
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

    }
}