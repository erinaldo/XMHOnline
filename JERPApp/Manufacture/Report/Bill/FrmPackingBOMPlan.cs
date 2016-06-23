using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture.Report.Bill
{
    public partial class FrmPackingBOMPlan : Form
    {
        public FrmPackingBOMPlan()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.gridhelper = new JCommon.DataGridViewHelper();
            this.dgrdv.CellPainting += new DataGridViewCellPaintingEventHandler(dgrdv_CellPainting);
        
            this.accBOMPlans = new JERPData.Packing.BOMPlans ();
        }
        private JERPData.Packing .BOMPlans accBOMPlans;
        private DataTable dtblBOMPlans;
        private JCommon.DataGridViewHelper gridhelper;
        public void BOMPlan(long PackingPlanID)
        {
            this.dtblBOMPlans = this.accBOMPlans.GetDataBOMPlansByPackingPlanID  (PackingPlanID).Tables[0];
            this.dgrdv.DataSource = this.dtblBOMPlans;
        }
        void dgrdv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if (irow > -1) return;
            if ((icol == 6) || (icol == 7))
            {
                this.gridhelper.MerageColumnHeaderSpan(this.dgrdv, e, 6, 7, "”√¡ø±»");
            }
        }
    }
}