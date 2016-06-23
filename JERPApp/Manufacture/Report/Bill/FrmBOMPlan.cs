using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture.Report.Bill
{
    public partial class FrmBOMPlan : Form
    {
        public FrmBOMPlan()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accBOMPlans = new JERPData.Manufacture.BOMPlans();
        }
        private JERPData.Manufacture.BOMPlans accBOMPlans;
        private DataTable dtblBOMPlans;
        public void BOMPlan(long ManufPlanID)
        {
            this.dtblBOMPlans = this.accBOMPlans.GetDataBOMPlansByManufPlanID(ManufPlanID).Tables[0];
            this.dgrdv.DataSource = this.dtblBOMPlans;
        }
    }
}