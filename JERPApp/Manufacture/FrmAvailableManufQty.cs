using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture
{
    public partial class FrmAvailableManufQty : Form
    {
        public FrmAvailableManufQty()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accBOMPlans = new JERPData.Manufacture.BOMPlans();
        }
        private JERPData.Manufacture.BOMPlans accBOMPlans;
        private DataTable dtblBom;
        public void AvailableManufQty(long ManufPlanID)
        {
            this.dtblBom = this.accBOMPlans.GetDataBOMPlansAvailableManufQty(ManufPlanID).Tables[0];
            this.dgrdv.DataSource = this.dtblBom;
            object objManufQty = this.dtblBom.Compute("Min(AvailableManufQty)", "");
            this.txtAvailableManufQty.Text = string.Format("{0:0.####}", objManufQty);
        }
    }
}