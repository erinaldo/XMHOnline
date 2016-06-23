using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Manufacture
{
    public partial class FrmOutSrcOrderType : Form
    {
        private DataTable dtblOutSrcOrderType;
        private JERPData.Manufacture.OutSrcOrderType accOutSrcOrderType;
        public FrmOutSrcOrderType()
        {
            InitializeComponent();
            this.accOutSrcOrderType = new JERPData.Manufacture.OutSrcOrderType();
            this.dgrdv.AutoGenerateColumns = false;            
            this.LoadData();
            this.dgrdv .UserDeletingRow +=new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
            this.dgrdv .RowValidated +=new DataGridViewCellEventHandler(dgrdv_RowValidated);
            this.FormClosed += new FormClosedEventHandler(FrmOutSrcOrderType_FormClosed);
        }

      
        private void LoadData()
        {
            this.dtblOutSrcOrderType = this.accOutSrcOrderType.GetDataOutSrcOrderType ().Tables[0];
            this.dtblOutSrcOrderType.Columns["OrderTypeCode"].AllowDBNull = false;  
            this.dtblOutSrcOrderType.Columns["OrderTypeName"].AllowDBNull = false;  
            this.dgrdv.DataSource = this.dtblOutSrcOrderType;
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
                drow = this.dtblOutSrcOrderType .DefaultView[irow].Row;
            }
            catch
            {
                return;
            }
            string errormsg = string.Empty;
            if (drow["OrderTypeID"] == DBNull.Value)
            {
                object objOrderTypeID = 0;
                flag = this.accOutSrcOrderType.InsertOutSrcOrderType (
                        ref errormsg,
                        ref objOrderTypeID,
                        drow["OrderTypeCode"],
                        drow["OrderTypeName"]);
                if (flag)
                {                   
                    drow["OrderTypeID"] = objOrderTypeID;
                }
                else
                {
                    MessageBox.Show(errormsg);
                   
                }
            }
            else
            {
                flag = this.accOutSrcOrderType.UpdateOutSrcOrderType (
                        ref errormsg,
                      drow["OrderTypeID"],
                      drow["OrderTypeCode"],
                      drow["OrderTypeName"]);
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

        void FrmOutSrcOrderType_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.affterSave != null) this.affterSave();
        }
        private void dgrdv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            bool flag = false;
            DataRow drow = this.dtblOutSrcOrderType  .DefaultView[irow].Row;
            if (drow["OrderTypeID"] == DBNull.Value)
            {
                e.Cancel = true;
                return;
            }
            int  OrderTypeID = (int)drow["OrderTypeID"];
            string errormsg = string.Empty;
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {

                flag = this.accOutSrcOrderType.DeleteOutSrcOrderType (ref errormsg, OrderTypeID);
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