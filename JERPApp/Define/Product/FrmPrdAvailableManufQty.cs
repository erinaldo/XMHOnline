using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Product
{
    public partial class FrmPrdAvailableManufQty : Form
    {
        public FrmPrdAvailableManufQty()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accBom = new JERPData.Product.BOM();
        }
        private JERPData.Product.BOM accBom;
        private DataTable dtblBom;
        public void PrdAvailableManufQty(int ParentID)
        {
            this.dtblBom = this.accBom.GetDataBOMPrdAvailableManufQty(ParentID).Tables[0];
            this.dgrdv.DataSource = this.dtblBom;
            object objManufQty = this.dtblBom.Compute("Min(AvailableManufQty)", "");
            this.txtAvailableManufQty.Text = string.Format("{0:0.####}", objManufQty);
        }
    }
}