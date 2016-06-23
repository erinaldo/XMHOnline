using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Engineer.Define
{
    public partial class FrmDevelopProcessTemplet : Form
    {

        public FrmDevelopProcessTemplet()
        {
            InitializeComponent();
            this.accProcessTemplet = new JERPData.Technology .ProcessTemplet();
            this.accTempletItems = new JERPData.Technology.ProcessTempletItems();
            this.accProcessType = new JERPData.Technology.ProcessType();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.SetPermit();
        }
        private DataTable dtblItems, dtblProcessType;
        private JERPData.Technology.ProcessTempletItems accTempletItems;
        private JERPData.Technology.ProcessTemplet accProcessTemplet;
        private JERPData.Technology.ProcessType accProcessType;
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存           

        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(721);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(722);
            if (this.enableBrowse)
            {
                this.SetColumnSrc();
                this.LoadData();
                this.ctrlTempletID.AllowDefine();
                this.ctrlTempletID.AffterSelected += this.LoadData;
               
            }          
            this.dgrdv.AllowUserToDeleteRows = enableSave;
            this.btnSave.Enabled = this.enableSave;
            if (this.enableSave)
            {
                this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
                this.btnSave.Click += new EventHandler(btnSave_Click);
            }

        }
      
        private void SetColumnSrc()
        {
            this.dtblProcessType = this.accProcessType.GetDataProcessType().Tables[0];
            this.dtblProcessType.Columns.Add("Exp", typeof(string), "ISNULL(ProcessTypeCode,'')+ISNULL(ProcessTypeName,'')");

            this.ColumnProcessTypeID.DataSource = this.dtblProcessType;
            this.ColumnProcessTypeID.ValueMember = "ProcessTypeID";
            this.ColumnProcessTypeID.DisplayMember = "Exp";

        }

        void ctrlTempletID_AffterSelected()
        {
            this.LoadData();
        }
        private void LoadData()
        {
            this.dtblItems = this.accTempletItems.GetDataProcessTempletItemsByTempletID(this.ctrlTempletID.TempletID).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
            
          
        }
        private bool ValidateData()
        {
            if (this.ctrlTempletID.TempletID == -1)
            {
                MessageBox.Show("对不起，未选择任何模板");
                return false;
            }
            return true;
        }    
       
        void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateData() == false) return;
            string errormsg = string.Empty;
            bool flag=false ;
            foreach (DataRow drow in this.dtblItems.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow.RowState == DataRowState.Unchanged) continue;
                if (drow["ItemID"] == DBNull.Value)
                {
                    object objItemID = DBNull.Value;
                    flag = this.accTempletItems.InsertProcessTempletItems(
                        ref errormsg,
                        ref objItemID,
                        this.ctrlTempletID.TempletID,
                        drow["SerialNo"],
                        drow["ProcessTypeID"],
                        drow["Memo"]);
                    if (flag)
                    {
                        drow["ItemID"] = objItemID;
                    }
                }
                else
                {
                    flag=this.accTempletItems .UpdateProcessTempletItems (ref errormsg ,
                        drow["ItemID"],
                       drow["SerialNo"],
                        drow["ProcessTypeID"],
                        drow["Memo"]);
                }
                if (!flag)
                {
                    MessageBox.Show(errormsg);
                }
            }

            MessageBox.Show("成功进行当前保存");
        }

  
    
        private void dgrdv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            bool flag = false;
            if (irow == this.dgrdv.RowCount - 1) return;
            DataRow drow = this.dtblProcessType  .DefaultView[irow].Row;
            string ErrorMsg = string.Empty;
            if (drow["ItemID"] == DBNull.Value)
            {
                return;
            }          
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No )
            {
                e.Cancel = true;
                return;

            }           
            flag = this.accProcessTemplet.DeleteProcessTemplet(ref ErrorMsg,
                drow["ItemID"]);
            if (!flag)
            {
               MessageBox .Show (ErrorMsg);
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