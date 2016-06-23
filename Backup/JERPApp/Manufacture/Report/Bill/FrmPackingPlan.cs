using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture.Report.Bill
{
    public partial class FrmPackingPlan : Form
    {
        public FrmPackingPlan()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accWorkingSheet = new JERPData.Packing .WorkingSheets();
            this.PackingPlanEntity = new JERPBiz.Packing .PackingPlanEntity();
        }
        private JERPData.Packing .WorkingSheets accWorkingSheet;
        private JERPBiz.Packing.PackingPlanEntity PackingPlanEntity;
        private DataTable dtblWorkingSheet;
        private long PackingPlanID = -1;
        public void PackingPlan(long PackingPlanID)
        {
            this.PackingPlanID = PackingPlanID;
            this.PackingPlanEntity.LoadData(PackingPlanID);
            this.txtDateNote.Text = this.PackingPlanEntity.DateNote.ToShortDateString();
            this.txtCompanyCode.Text = this.PackingPlanEntity.CompanyCode;
            this.txtDateTarget.Text = this.PackingPlanEntity.DateTarget.ToShortDateString();
            this.txtPrdCode.Text = this.PackingPlanEntity.PrdCode;
            this.txtPrdName.Text = this.PackingPlanEntity.PrdName;
            this.txtPrdSpec.Text = this.PackingPlanEntity.PrdSpec;
            this.txtModel.Text = this.PackingPlanEntity.Model;
            this.txtPackingTypeName.Text = this.PackingPlanEntity.PackingTypeName;
            this.txtQuantity.Text = string.Format("{0:0.####}", this.PackingPlanEntity.Quantity);
            this.dtblWorkingSheet =this.accWorkingSheet .GetDataWorkingSheetsByPackingPlanID  (PackingPlanID ).Tables [0];
            this.dgrdv.DataSource = this.dtblWorkingSheet;
        }
    }
}