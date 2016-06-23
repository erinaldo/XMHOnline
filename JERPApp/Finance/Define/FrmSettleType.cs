using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Define
{
    public partial class FrmSettleType : Form
    {
        private DataTable dtblSettleType;
        private JERPData.Finance .SettleType accSettleType;
        public FrmSettleType()
        {
            InitializeComponent();
            this.accSettleType = new JERPData.Finance .SettleType();
            this.dgrdv.AutoGenerateColumns = false;
            this.SetPermit();

        }
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(19);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(20);
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
                this.dgrdv.RowValidated += new DataGridViewCellEventHandler(dgrdv_RowValidated);
                this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);

            }


        }
       
        private void LoadData()
        {
            this.dtblSettleType = this.accSettleType.GetDataSettleType().Tables[0];           
            this.dtblSettleType.Columns["SettleTypeCode"].AllowDBNull = false;
            this.dtblSettleType.Columns["SettleTypeCode"].Unique  = true;
            this.dtblSettleType.Columns["SettleTypeName"].AllowDBNull = false;
            this.dtblSettleType.Columns["SettleTypeName"].Unique = true;
            this.dtblSettleType.Columns["CashSettleFlag"].DefaultValue  = false;
            this.dgrdv.DataSource = this.dtblSettleType;
        }

 

        void dgrdv_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
          
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            bool flag = false;
            DataRow drow = null;
            try
            {
                drow = this.dtblSettleType.DefaultView[irow].Row;
            }
            catch 
            {
                return;
            }
            if (drow == null) return;
            if (drow.RowState == DataRowState.Unchanged) return;
            string errormsg = string.Empty;
            if (drow["SettleTypeID"] == DBNull.Value)
            {
                object objSettleTypeID =DBNull .Value ;
                flag = this.accSettleType.InsertSettleType(ref errormsg, ref objSettleTypeID,
                        drow["SettleTypeCode"],
                        drow["SettleTypeName"],
                        drow["CashSettleFlag"]);
                if (flag)
                {
                    drow["SettleTypeID"] = objSettleTypeID;
                    if(this.affterSave !=null) this.affterSave ();
                }
                else
                {
                    MessageBox.Show(errormsg);
                    this.LoadData();
                }
            }
            else
            {
                flag=this.accSettleType.UpdateSettleType(ref errormsg,
                        drow["SettleTypeID"],
                        drow["SettleTypeCode"],
                        drow["SettleTypeName"],
                        drow["CashSettleFlag"]);
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

        private void dgrdv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            bool flag = false;
            DataRow drow = this.dtblSettleType  .DefaultView[irow].Row;
            string ErrorMsg = string.Empty;
            if (drow["SettleTypeID"] == DBNull.Value)
            {
                e.Cancel = true;
                return;
            }

            int  SettleTypeID = (int)drow["SettleTypeID"];
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {
                flag = this.accSettleType.DeleteSettleType(ref ErrorMsg,
                    SettleTypeID);
                if (flag)
                {
                    if (this.affterSave != null)
                    {
                        this.affterSave();
                    }
                }
                else
                {
                   MessageBox .Show ("此记录已被其他业务引用，不能从数据库中删除此单位");
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