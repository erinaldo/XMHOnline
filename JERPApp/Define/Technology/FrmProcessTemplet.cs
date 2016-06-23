using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Technology
{
    public partial class FrmProcessTemplet : Form
    {
        private DataTable dtblProcessTemplet;
        private JERPData.Technology.ProcessTemplet accProcessTemplet;
        public FrmProcessTemplet()
        {
            InitializeComponent();
            this.accProcessTemplet = new JERPData.Technology.ProcessTemplet();
            this.dgrdv.AutoGenerateColumns = false;            
            this.LoadData();
            this.dgrdv .UserDeletingRow +=new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
            this.dgrdv .RowValidated +=new DataGridViewCellEventHandler(dgrdv_RowValidated);
            this.FormClosed += new FormClosedEventHandler(FrmProcessTemplet_FormClosed);
        }

      
        private void LoadData()
        {
            this.dtblProcessTemplet = this.accProcessTemplet.GetDataProcessTemplet ().Tables[0];
             this.dtblProcessTemplet.Columns["TempletName"].AllowDBNull = false;  
            this.dgrdv.DataSource = this.dtblProcessTemplet;
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
                drow = this.dtblProcessTemplet .DefaultView[irow].Row;
            }
            catch
            {
                return;
            }
            string errormsg = string.Empty;
            if (drow["TempletID"] == DBNull.Value)
            {
                object objTempletID = 0;
                flag = this.accProcessTemplet.InsertProcessTemplet (
                        ref errormsg,
                        ref objTempletID,
                        drow["TempletName"]);
                if (flag)
                {                   
                    drow["TempletID"] = objTempletID;
                }
                else
                {
                    MessageBox.Show(errormsg);
                   
                }
            }
            else
            {
                flag = this.accProcessTemplet.UpdateProcessTemplet (
                        ref errormsg,
                      drow["TempletID"],
                      drow["TempletName"]);
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

        void FrmProcessTemplet_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.affterSave != null) this.affterSave();
        }
        private void dgrdv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            bool flag = false;
            DataRow drow = this.dtblProcessTemplet  .DefaultView[irow].Row;
            if (drow["TempletID"] == DBNull.Value)
            {
                e.Cancel = true;
                return;
            }
            int  TempletID = (int)drow["TempletID"];
            string errormsg = string.Empty;
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {

                flag = this.accProcessTemplet.DeleteProcessTemplet (ref errormsg, TempletID);
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