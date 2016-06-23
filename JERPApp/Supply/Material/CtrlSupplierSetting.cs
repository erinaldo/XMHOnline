using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Supply.Material
{
    public partial class CtrlSupplierSetting : UserControl
    {
        public CtrlSupplierSetting()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accSupplierPrdCode = new JERPData.Product.SupplierPrdCode();
            this.accPrds = new JERPData.Product.Product(); 
            this.ctrlQFind.BeforeFilter += this.LoadData;
            this.dgrdv.ContextMenuStrip = this.cMenu;
            this.mItemSupplier.Click += new EventHandler(mItemSupplier_Click); 
            this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
            this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
        }
        private JERPData.Product.Product accPrds;
        private JERPData.Product.SupplierPrdCode accSupplierPrdCode; 
        private DataTable dtblPrds;
        private JERPApp.Engineer.FrmSupplierPrdCode frmSupplierPrdCode;
        private JERPApp.Engineer.FrmBatchSupplier frmBatchSupplier;
        public delegate void AffterRefreshDelegate();
        private AffterRefreshDelegate affterRefresh;
        public event AffterRefreshDelegate AffterRefresh
        {
            add
            {
                affterRefresh += value;
            }
            remove
            {
                affterRefresh -= value;
            }
        }
        public void LoadData()
        {
            this.dtblPrds = this.accPrds.GetDataProductForSupplierSetting().Tables[0];
            this.dgrdv.DataSource = this.dtblPrds;

        }
        public int Count
        {
            get
            {
                return this.dtblPrds.Rows.Count;
            }
        }
        private string GetSupplier(int PrdID)
        {
            string supplier = string.Empty;
            this.accPrds.GetParmProductSupplier(PrdID, ref supplier);
            if (supplier == string.Empty) return "Œ¥…Ë÷√";
            return supplier;
        }
        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            object objPrdID = this.dtblPrds.DefaultView[irow]["PrdID"];
            if ((objPrdID == null) || (objPrdID == DBNull.Value)) return;
            string errormsg = string.Empty;
            if (this.dgrdv.Columns[icol].Name == this.ColumnSupplier.Name)
            {

                if (frmSupplierPrdCode == null)
                {
                    frmSupplierPrdCode = new JERPApp.Engineer.FrmSupplierPrdCode();
                    new FrmStyle(frmSupplierPrdCode).SetPopFrmStyle(this.ParentForm);
                }
                this.frmSupplierPrdCode.SupplierPrdCode((int)objPrdID);
                this.frmSupplierPrdCode.ShowDialog();
                this.dgrdv[icol, irow].Value = this.GetSupplier((int)objPrdID);
            }
          

        }
        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
            if (this.affterRefresh != null) this.affterRefresh();
        }
        void mItemSupplier_Click(object sender, EventArgs e)
        {
            if (frmBatchSupplier == null)
            {
                frmBatchSupplier = new JERPApp.Engineer.FrmBatchSupplier();
                new FrmStyle(frmBatchSupplier).SetPopFrmStyle(this.ParentForm );
                frmBatchSupplier.AffterSave += new JERPApp.Engineer.FrmBatchSupplier.AffterSaveDelegate(frmBatchSupplier_AffterSave);
            }
            frmBatchSupplier.BatchSupplier();
            frmBatchSupplier.ShowDialog();
        }

        void frmBatchSupplier_AffterSave(DataRow[] drowSuppliers, bool SettingFlag)
        {
            DataRow drow;
            string errormsg = string.Empty;
            for (int irow = 0; irow < this.dgrdv.Rows.Count; irow++)
            {
                if (this.dgrdv.Rows[irow].Selected)
                {
                    drow = this.dtblPrds.DefaultView[irow].Row;
                    if (drow["PrdID"] == DBNull.Value) continue;
                    foreach (DataRow drowSupplier in drowSuppliers)
                    {
                        if (SettingFlag)
                        {
                            this.accSupplierPrdCode.UpdateSupplierPrdCodeForSupplier(ref errormsg,
                                drow["PrdID"],
                                drowSupplier["CompanyID"]);

                        }
                        else
                        {
                            this.accSupplierPrdCode.UpdateSupplierPrdCodeCancelSupplier(
                                ref errormsg,
                                drow["PrdID"],
                                drowSupplier["CompanyID"]);
                        }
                    }
                    drow["Supplier"] = this.GetSupplier((int)drow["PrdID"]);
                }
            }
            this.frmBatchSupplier.Close();
        }
    }
}
