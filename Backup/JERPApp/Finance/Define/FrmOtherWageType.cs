using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Define
{
    public partial class FrmOtherWageType : Form
    {
      
        public FrmOtherWageType()
        {
            InitializeComponent();
            this.accWageType = new JERPData.Finance.OtherWageType();
            this.dgrdv.AutoGenerateColumns = false;            
            this.SetPermit();
        }
        private DataTable dtblWageType;
        private JERPData.Finance.OtherWageType accWageType;
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存     
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(101);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(102);
            if (this.enableBrowse)
            {
                this.LoadData();               
            }           
            if (this.enableSave)
            {
                this.dgrdv .UserDeletingRow +=new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
                this.dgrdv .RowValidated +=new DataGridViewCellEventHandler(dgrdv_RowValidated);
                this.FormClosed += new FormClosedEventHandler(FrmOtherWageType_FormClosed);
            }
        }      
        private void LoadData()
        {
            this.dtblWageType = this.accWageType.GetDataOtherWageType().Tables[0];
            this.dtblWageType.Columns["WageTypeName"].AllowDBNull = false;
            this.dtblWageType.Columns["WageTypeName"].Unique  = true;
            this.dgrdv.DataSource = this.dtblWageType;
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
                drow = this.dtblWageType .DefaultView[irow].Row;
            }
            catch
            {
                return;
            }
            string errormsg = string.Empty;
            if (drow["WageTypeID"] == DBNull.Value)
            {
                object objWageTypeID = 0;
                flag = this.accWageType.InsertOtherWageType (
                        ref errormsg,
                        ref objWageTypeID,
                        drow["WageTypeName"]);
                if (flag)
                {
                    drow["WageTypeID"] = objWageTypeID;
                }
                else
                {
                    MessageBox.Show(errormsg);
                   
                }
            }
            else
            {
                flag = this.accWageType.UpdateOtherWageType (
                        ref errormsg,
                      drow["WageTypeID"],
                      drow["WageTypeName"]);
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

        void FrmOtherWageType_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.affterSave != null) this.affterSave();
        }
        private void dgrdv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            bool flag = false;
            DataRow drow = this.dtblWageType  .DefaultView[irow].Row;
            if (drow["WageTypeID"] == DBNull.Value)
            {
                return;
            }          
            string errormsg = string.Empty;
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {

                flag = this.accWageType.DeleteOtherWageType(ref errormsg, drow["WageTypeID"]);
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