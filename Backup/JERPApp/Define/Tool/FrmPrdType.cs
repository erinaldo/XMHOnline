using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Tool
{
    public partial class FrmPrdType : Form
    {
        private DataTable dtblPrdType;
        private JERPData.Tool.PrdType accPrdType;
        public FrmPrdType()
        {
            InitializeComponent();
            this.accPrdType = new JERPData.Tool.PrdType();
            this.dgrdv.AutoGenerateColumns = false;
            this.Shown += new EventHandler(FrmPrdType_Shown);
            this.dgrdv .UserDeletingRow +=new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
            this.dgrdv .RowValidated +=new DataGridViewCellEventHandler(dgrdv_RowValidated);
            this.FormClosed += new FormClosedEventHandler(FrmPrdType_FormClosed);
        }

        void FrmPrdType_Shown(object sender, EventArgs e)
        {
            this.LoadData();
        }

      
        private void LoadData()
        {
            this.dtblPrdType = this.accPrdType.GetDataPrdType ().Tables[0];
            this.dtblPrdType.Columns["PrdTypeName"].AllowDBNull = false;  
            this.dgrdv.DataSource = this.dtblPrdType;
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
                drow = this.dtblPrdType .DefaultView[irow].Row;
            }
            catch
            {
                return;
            }
            string errormsg = string.Empty;
            if (drow["PrdTypeID"] == DBNull.Value)
            {
                object objPrdTypeID = 0;
                flag = this.accPrdType.InsertPrdType (
                        ref errormsg,
                        ref objPrdTypeID,
                        drow["PrdTypeName"]);
                if (flag)
                {                   
                    drow["PrdTypeID"] = objPrdTypeID;
                }
                else
                {
                    MessageBox.Show(errormsg);
                   
                }
            }
            else
            {
                flag = this.accPrdType.UpdatePrdType (
                        ref errormsg,
                      drow["PrdTypeID"],
                      drow["PrdTypeName"]);
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

        void FrmPrdType_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.affterSave != null) this.affterSave();
        }
        private void dgrdv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            bool flag = false;
            DataRow drow = this.dtblPrdType  .DefaultView[irow].Row;
            if (drow["PrdTypeID"] == DBNull.Value)
            {
                e.Cancel = true;
                return;
            }
            int  PrdTypeID = (int)drow["PrdTypeID"];
            string errormsg = string.Empty;
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {

                flag = this.accPrdType.DeletePrdType (ref errormsg, PrdTypeID);
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