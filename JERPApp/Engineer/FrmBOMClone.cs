using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Engineer
{
    public partial class FrmBOMClone : Form
    {
        public FrmBOMClone()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accBOM = new JERPData.Product.BOM();
            this.btnImport.Click += new EventHandler(btnImport_Click);
            this.ctrlPrdID.AffterSelected += new JERPApp.Define.Product.CtrlProduct.AffterSelectedDelegate(ctrlPrdID_AffterSelected);
        } 
        private JERPData.Product.BOM accBOM;
        private DataTable dtblBom;
        public delegate void AffterImportSaveDelegate(DataRow drow);
        private AffterImportSaveDelegate affterImport;
        public event AffterImportSaveDelegate AffterImport
        {
            add
            {
                affterImport += value;
            }
            remove
            {
                affterImport -= value;
            }
        }
        public void BOMClone()
        {
            this.ctrlPrdID.PrdID = -1;
            this.ctrlPrdID_AffterSelected();

        }
        void ctrlPrdID_AffterSelected()
        {
            this.ctrlManufProcessID.LoadData(this.ctrlPrdID.PrdID);
            this.dtblBom = this.accBOM.GetDataBOMByManufProcessID(this.ctrlManufProcessID.ManufProcessID ).Tables[0];
            this.dtblBom.Columns.Add("Mark", typeof(Image));
            this.dtblBom.Columns["ParentFlag"].DefaultValue = false;
            foreach (DataRow drow in this.dtblBom.Rows)
            {
                if ((bool)drow["ParentFlag"])
                {
                    drow["Mark"] = global::JERPApp.Properties.Resources.plus;
                }
                else
                {
                    drow["Mark"] = global::JERPApp.Properties.Resources.subtract;
                }
            }
            this.dgrdv.DataSource = this.dtblBom;
        }

        void btnImport_Click(object sender, EventArgs e)
        {
           
            if (this.dtblBom == null) return;
            foreach (DataRow drow in this.dtblBom.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue; 
                if (this.affterImport != null) this.affterImport(drow);
            }
            MessageBox.Show("成功导入物料");
            this.Close();
        }
    }
}