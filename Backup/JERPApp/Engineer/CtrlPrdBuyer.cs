using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Engineer
{
    public partial class CtrlPrdBuyer : UserControl
    {
        public CtrlPrdBuyer()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accPrd = new JERPData.Product.Product();
            this.accXBuyer = new JERPData.Product.ProductXBuyer ();
            this.accPsns = new JERPData.Hr.Personnel();
            this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
            this.SetColumnSrc();
        }      
        private JERPData.Product.Product accPrd;
        private JERPData.Product.ProductXBuyer  accXBuyer;
        private JERPData.Hr.Personnel  accPsns;
        private DataTable dtblXBuyer,dtblPsns;
        private void SetColumnSrc()
        {
            this.dtblPsns = this.accPsns.GetDataPersonnel ().Tables[0];
            this.dtblPsns.Columns.Add("Exp", typeof(string), "ISNULL(AssistantCode,'')+' '+ISNULL(PsnName,'')");
            this.ColumnPsnID .DataSource = this.dtblPsns;
            this.ColumnPsnID.ValueMember = "PsnID";
            this.ColumnPsnID.DisplayMember = "Exp";
        }
        public void PrdBuyer(int PrdID)
        {
            this.dtblXBuyer = this.accXBuyer.GetDataProductXBuyerByPrdID (PrdID).Tables[0];
            this.dgrdv.DataSource = this.dtblXBuyer;
            this.dtblXBuyer.Columns["PsnID"].AllowDBNull = false;
            this.dtblXBuyer.Columns["PsnID"].Unique = true;
        }
        void dgrdv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            bool flag = false;
            DataRow drow = this.dtblXBuyer .DefaultView[irow].Row;
            if (drow["ID"] == DBNull.Value)
            {
                return;
            }
            string errormsg = string.Empty;
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {
                flag = this.accXBuyer .DeleteProductXBuyer (ref errormsg, drow["ID"]);

            }
            else
            {
                e.Cancel = true;
            }
        }
        public void Save(int PrdID)
        {
            string errormsg=string.Empty ;
            bool flag = false;
            foreach (DataRow drow in this.dtblXBuyer.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow.RowState == DataRowState.Unchanged) continue;
                if (drow["ID"] == DBNull.Value)
                {
                    object objID = DBNull.Value;
                    flag=this.accXBuyer.InsertProductXBuyer (ref errormsg,
                        ref objID,
                        PrdID,
                        drow["PsnID"]);
                    if (flag)
                    {
                        drow["ID"] = objID;
                    }

                }
                else
                {
                    this.accXBuyer.UpdateProductXBuyer (ref errormsg,
                        drow["ID"], 
                        PrdID,
                        drow["PsnID"]);

                }
                drow.AcceptChanges();
            }
            this.accPrd.UpdateProductForBuyer (ref errormsg, PrdID);
        }
    }
}
