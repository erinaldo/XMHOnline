using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define
{
    public partial class FrmUnit : Form
    {
        private DataTable dtblUnits;
        private JERPData.General.Unit accUnits;
        public FrmUnit()
        {
            InitializeComponent();
            this.accUnits = new JERPData.General.Unit();
            this.dgrdv.AutoGenerateColumns = false;
            this.SetPermit();
        }
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(21);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(22);
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
            
            this.dtblUnits = this.accUnits.GetDataUnit().Tables[0];
            this.dtblUnits.Columns["UnitName"].AllowDBNull = false;
            this.dtblUnits.Columns["UnitName"].Unique = true;
            this.dtblUnits.Columns["IntegerFlag"].DefaultValue = false;
            this.dgrdv.DataSource = this.dtblUnits;
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
                drow = this.dtblUnits .DefaultView[irow].Row;
            }
            catch
            {
                return;
            }
            if (drow.RowState == DataRowState.Unchanged) return;
            string errormsg = string.Empty;
            if (drow["UnitID"] == DBNull.Value)
            {
                object objUnitID = DBNull.Value;
                flag = this.accUnits.InsertUnit(ref errormsg ,ref objUnitID,
                             drow["UnitName"],
                             drow["IntegerFlag"]);
                if (flag)
                {
                    drow["UnitID"] = objUnitID;
                    if (this.affterSave != null) this.affterSave();
                }
                else
                {
                    MessageBox.Show(errormsg );
                }
            }
            else
            {
                flag = this.accUnits.UpdateUnit(ref errormsg,
                    drow["UnitID"],
                    drow["UnitName"],
                    drow["IntegerFlag"]);

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
        private void dgrdv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            bool flag = false;
            DataRow drow = this.dtblUnits  .DefaultView[irow].Row;
            if (drow["UnitID"] == DBNull.Value)
            {
                e.Cancel = true;
                return;
            }
            string errormsg = string.Empty;
            int  UnitID = (int)drow["UnitID"];
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，且会影响其他业务的进行,系统不建议删除！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {

                flag = this.accUnits.DeleteUnit(ref errormsg,UnitID);
                if (flag)
                {
                    if (this.affterSave != null) this.affterSave();
                }
                else
                {
                   MessageBox .Show (errormsg );
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