using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Engineer
{
    public partial class FrmBatchSupplier : Form
    {
        public FrmBatchSupplier()
        {
            InitializeComponent();
            this.accSupplier = new JERPData.General.Supplier();
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnCancel.Click += new EventHandler(btnCancel_Click);
            this.SetColumnSrc();
        }
        private JERPData.General.Supplier accSupplier;
        private DataTable dtblSupplierItems,dtblSupplier;
        public delegate void AffterSaveDelegate(DataRow[] drowSuppliers,bool SettingFlag);
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
        bool ValidateData()
        {

            if (this.dtblSupplierItems .Select("", "", DataViewRowState.CurrentRows).Length == 0)
            {
                MessageBox.Show("对不起供应商未选择");
                return false;
            }
            return true;
        }
        private void SetColumnSrc()
        {
            this.dtblSupplier = this.accSupplier.GetDataSupplierForMaterial().Tables[0];
            this.dtblSupplier.Columns.Add("Exp", typeof(string), "ISNULL(CompanyCode,'')+ISNULL(CompanyAbbName,'')");
            this.ColumnCompanyID.DataSource = this.dtblSupplier;
            this.ColumnCompanyID.ValueMember = "CompanyID";
            this.ColumnCompanyID.DisplayMember  = "Exp";
        }
        public void BatchSupplier()
        {
            this.dtblSupplierItems = new DataTable();
            this.dtblSupplierItems.Columns.Add("CompanyID", typeof(int));
            this.dtblSupplierItems.Columns["CompanyID"].AllowDBNull = false;
            this.dtblSupplierItems.Columns["CompanyID"].Unique  = true;
            this.dgrdv.DataSource = this.dtblSupplierItems;
        }
        void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateData() == false) return;
            string errormsg = string.Empty;
            DialogResult rul = MessageBox.Show("即将批量设定所选产品的供应商，请确认！", "操作确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return;
            DataRow[] drows = this.dtblSupplierItems.Select("", "", DataViewRowState.CurrentRows);
            this.affterSave(drows, true);
        }
        void btnCancel_Click(object sender, EventArgs e)
        {
            if (ValidateData() == false) return;
            string errormsg = string.Empty;
            DialogResult rul = MessageBox.Show("即将批量取消所选产品的供应商，请确认！", "操作确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return;
            DataRow[] drows = this.dtblSupplierItems.Select("", "", DataViewRowState.CurrentRows);
            this.affterSave(drows, false);
        }

    }
}