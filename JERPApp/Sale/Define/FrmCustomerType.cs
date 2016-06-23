using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Sale.Define
{
    public partial class FrmCustomerType : Form
    {
     
        public FrmCustomerType()
        {
            InitializeComponent();
            this.accCustomerType = new JERPData.General.CustomerType();
            this.dgrdv.AutoGenerateColumns = false;
            this.LoadData();
            this.SetPermit();
        }
        private DataTable dtblCustomerType;
        private JERPData.General.CustomerType accCustomerType;
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(707);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(708);
            if (this.enableBrowse)
            {
                //加载数据
                LoadData();
            }
            this.dgrdv.AllowUserToAddRows = enableSave;
            this.dgrdv.AllowUserToDeleteRows = enableSave;
            this.dgrdv.ReadOnly = !enableSave;
            if (this.enableSave)
            {
                this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
                this.dgrdv.RowValidated += new DataGridViewCellEventHandler(dgrdv_RowValidated);
                this.FormClosed += new FormClosedEventHandler(FrmCustomerType_FormClosed);
        
            }
        }
      
        private void LoadData()
        {
            this.dtblCustomerType = this.accCustomerType.GetDataCustomerType ().Tables[0];           
            this.dtblCustomerType.Columns["CustomerTypeName"].AllowDBNull = false;
            this.dgrdv.DataSource = this.dtblCustomerType;
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
                drow = this.dtblCustomerType .DefaultView[irow].Row;
            }
            catch
            {
                return;
            }
            string errormsg = string.Empty;
            if (drow["CustomerTypeID"] == DBNull.Value)
            {
                object objCustomerTypeID = 0;
                flag = this.accCustomerType.InsertCustomerType (
                        ref errormsg,
                        ref objCustomerTypeID,
                        drow["CustomerTypeName"]);
                if (flag)
                {                   
                    drow["CustomerTypeID"] = objCustomerTypeID;
                }
                else
                {
                    MessageBox.Show(errormsg);
                   
                }
            }
            else
            {
                flag = this.accCustomerType.UpdateCustomerType (
                        ref errormsg,
                      drow["CustomerTypeID"],
                      drow["CustomerTypeName"]);
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

        void FrmCustomerType_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.affterSave != null) this.affterSave();
        }
        private void dgrdv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            bool flag = false;
            DataRow drow = this.dtblCustomerType  .DefaultView[irow].Row;
            if (drow["CustomerTypeID"] == DBNull.Value)
            {
                e.Cancel = true;
                return;
            }
            int  CustomerTypeID = (int)drow["CustomerTypeID"];
            string errormsg = string.Empty;
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {

                flag = this.accCustomerType.DeleteCustomerType (ref errormsg, CustomerTypeID);
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