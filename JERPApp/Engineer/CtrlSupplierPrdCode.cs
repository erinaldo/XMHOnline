using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Engineer
{
    public partial class CtrlSupplierPrdCode : UserControl
    {
        public CtrlSupplierPrdCode()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accPrd = new JERPData.Product.Product();
            this.accSupplierPrdCode = new JERPData.Product.SupplierPrdCode();
            this.accSupplier = new JERPData.General.Supplier();
            this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
         
            this.SetColumnSrc();
        }

     
        private JERPData.Product.Product accPrd;
        private JERPData.Product.SupplierPrdCode accSupplierPrdCode;
        private JERPData.General.Supplier accSupplier;
        private DataTable dtblSupplierCode,dtblSupplier;
        private void SetColumnSrc()
        {
            this.dtblSupplier = this.accSupplier.GetDataSupplier().Tables[0];
            this.dtblSupplier.Columns.Add("Exp", typeof(string), "ISNULL(CompanyCode,'')+' '+ISNULL(CompanyAbbName,'')");
            this.ColumnCompanyID.DataSource = this.dtblSupplier;
            this.ColumnCompanyID.ValueMember = "CompanyID";
            this.ColumnCompanyID.DisplayMember = "Exp";
        }
        public void SupplierPrdCode(int PrdID)
        {
            this.dtblSupplierCode = this.accSupplierPrdCode.GetDataSupplierPrdCodeByPrdID(PrdID).Tables[0];
            this.dgrdv.DataSource = this.dtblSupplierCode;
            this.dtblSupplierCode.Columns["CompanyID"].AllowDBNull = false;
            this.dtblSupplierCode.Columns["CompanyID"].Unique = true;
        }
        void dgrdv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            bool flag = false;
            DataRow drow = this.dtblSupplierCode .DefaultView[irow].Row;
            if (drow["ID"] == DBNull.Value)
            {
                return;
            }
            string errormsg = string.Empty;
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {
                flag = this.accSupplierPrdCode .DeleteSupplierPrdCode(ref errormsg, drow["ID"]);

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
            foreach (DataRow drow in this.dtblSupplierCode.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow.RowState == DataRowState.Unchanged) continue;
                if (drow["ID"] == DBNull.Value)
                {
                    object objID = DBNull.Value;
                    flag=this.accSupplierPrdCode.InsertSupplierPrdCode(ref errormsg,
                        ref objID,
                        PrdID,
                        drow["CompanyID"],
                        drow["SupplierPrdCode"]);
                    if (flag)
                    {
                        drow["ID"] = objID;
                    }

                }
                else
                {
                    this.accSupplierPrdCode.UpdateSupplierPrdCode(ref errormsg,
                        drow["ID"],
                        drow["CompanyID"],
                        PrdID,
                        drow["SupplierPrdCode"]);

                }
                drow.AcceptChanges();
            }
            this.accPrd.UpdateProductForSupplierPrdCode(ref errormsg, PrdID);
        }
    }
}
