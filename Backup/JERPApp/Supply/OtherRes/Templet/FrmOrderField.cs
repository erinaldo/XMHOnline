using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Supply.OtherRes.Templet
{
    public partial class FrmOrderField : Form
    {
        private DataTable dtblFields;
        private JERPData.OtherRes.BuyOrderField accField;
        public FrmOrderField()
        {
            InitializeComponent();
            this.accField = new JERPData.OtherRes.BuyOrderField();
            this.dgrdv.AutoGenerateColumns = false;
            this.SetPermit();
        }
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存          

        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(493);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(494);
            if (this.enableBrowse)
            {
                this.LoadData();
            }
            this.dgrdv.ReadOnly = !this.enableSave;
            this.dgrdv.AllowUserToAddRows = this.enableSave;
            this.dgrdv.AllowUserToDeleteRows = this.enableSave;
            if (this.enableSave)
            {
                this.dgrdv.RowValidated += new DataGridViewCellEventHandler(dgrdv_RowValidated);
                this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
            }
        }

        
        private void LoadData()
        {           
            this.dtblFields = this.accField .GetDataBuyOrderField().Tables[0];
            this.dtblFields.Columns["FieldName"].AllowDBNull = false;
            this.dtblFields.Columns["FieldName"].Unique  = true;
            this.dtblFields.Columns["FieldCaption"].AllowDBNull = false;
            this.dtblFields.Columns["FieldCaption"].Unique = true;          
            this.dgrdv.DataSource = this.dtblFields;
        }  
        private void dgrdv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            bool flag = false;
            DataRow drow = this.dtblFields  .DefaultView[irow].Row;
            string ErrorMsg = string.Empty;
            if (drow["FieldID"] == DBNull.Value)
            {
            
                return;
            }
            int FieldID = (int)drow["FieldID"];
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {
                flag = this.accField.DeleteBuyOrderField   (ref ErrorMsg,
                    FieldID);
                if (flag)
                {
                    if (this.affterSave != null)
                    {
                        this.affterSave();
                    }
                }
                else
                {
                    MessageBox.Show(ErrorMsg);
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
        void dgrdv_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            DataRow drow = null;
            try
            {
                drow = this.dtblFields.DefaultView[irow].Row;
            }
            catch
            {
                return;
            }
            bool flag = false;
            string errormsg = string.Empty;
            if (drow["FieldID"] == DBNull.Value)
            {
                object objFieldID = DBNull.Value;
                flag = this.accField.InsertBuyOrderField (ref errormsg, ref objFieldID,
                        drow["FieldName"],
                        drow["FieldCaption"]);
                if (flag)
                {
                    drow["FieldID"] = objFieldID;
                    if (this.affterSave != null) this.affterSave();
                }
                else
                {
                    MessageBox.Show(errormsg);
                    this.LoadData();
                }
            }
            else
            {
                flag = this.accField.UpdateBuyOrderField(
                    ref errormsg,
                    drow["FieldID"],
                    drow["FieldName"],
                    drow["FieldCaption"]);
                if (flag)
                {
                    if (this.affterSave != null) this.affterSave();
                }
                else
                {
                    MessageBox.Show(errormsg);
                    this.LoadData();
                }
            }
            
        }

           
    }
}