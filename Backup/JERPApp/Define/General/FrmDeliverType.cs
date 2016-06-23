using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.General
{
    public partial class FrmDeliverType : Form
    {
        private DataTable dtblDeliverType;
        private JERPData.General.DeliverType accDeliverType;
        public FrmDeliverType()
        {
            InitializeComponent();
            this.accDeliverType = new JERPData.General.DeliverType();
            this.dgrdv.AutoGenerateColumns = false;            
            this.LoadData();
            this.dgrdv .UserDeletingRow +=new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
            this.dgrdv .RowValidated +=new DataGridViewCellEventHandler(dgrdv_RowValidated);
            this.FormClosed += new FormClosedEventHandler(FrmDeliverType_FormClosed);
        }

      
        private void LoadData()
        {
            this.dtblDeliverType = this.accDeliverType.GetDataDeliverType ().Tables[0];
            this.dtblDeliverType.Columns["DeliverTypeCode"].AllowDBNull = false;
            this.dtblDeliverType.Columns["DeliverTypeName"].AllowDBNull = false;           
            this.dgrdv.DataSource = this.dtblDeliverType;
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
                drow = this.dtblDeliverType .DefaultView[irow].Row;
            }
            catch
            {
                return;
            }
            string errormsg = string.Empty;
            if (drow["DeliverTypeID"] == DBNull.Value)
            {
                object objDeliverTypeID = 0;
                flag = this.accDeliverType.InsertDeliverType (
                        ref errormsg,
                        ref objDeliverTypeID,
                        drow["DeliverTypeCode"],
                        drow["DeliverTypeName"]);
                if (flag)
                {                   
                    drow["DeliverTypeID"] = objDeliverTypeID;
                }
                else
                {
                    MessageBox.Show(errormsg);
                   
                }
            }
            else
            {
                flag = this.accDeliverType.UpdateDeliverType (
                        ref errormsg,
                      drow["DeliverTypeID"],
                      drow["DeliverTypeCode"],
                      drow["DeliverTypeName"]);
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

        void FrmDeliverType_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.affterSave != null) this.affterSave();
        }
        private void dgrdv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            bool flag = false;
            DataRow drow = this.dtblDeliverType  .DefaultView[irow].Row;
            if (drow["DeliverTypeID"] == DBNull.Value)
            {
                e.Cancel = true;
                return;
            }
            int  DeliverTypeID = (int)drow["DeliverTypeID"];
            string errormsg = string.Empty;
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {

                flag = this.accDeliverType.DeleteDeliverType (ref errormsg, DeliverTypeID);
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