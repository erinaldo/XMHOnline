using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture
{
    public partial class FrmAvailablePackingQty : Form
    {
        public FrmAvailablePackingQty()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.gridhelper = new JCommon.DataGridViewHelper();
            this.dgrdv.CellPainting += new DataGridViewCellPaintingEventHandler(dgrdv_CellPainting);
            this.accBOMPlans = new JERPData.Packing.BOMPlans();
        }

        private JERPData.Packing .BOMPlans accBOMPlans;
        private JCommon.DataGridViewHelper gridhelper;
        private DataTable dtblBom;
        public void AvailablePackingQty(long PackingPlanID)
        {
            this.dtblBom = this.accBOMPlans.GetDataBOMPlansAvailablePackingQty(PackingPlanID).Tables[0];
            this.dgrdv.DataSource = this.dtblBom;
            object objManufQty = this.dtblBom.Compute("Min(AvailablePackingQty)", "");
            this.txtAvailableManufQty.Text = string.Format("{0:0.####}", objManufQty);
        }

        void dgrdv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if(irow>-1)return;
            if ((icol == 3) || (icol == 4))
            {
                this.gridhelper.MerageColumnHeaderSpan(this.dgrdv, e, 3, 4, "”√¡ø");
            }
            
        }
    }
}