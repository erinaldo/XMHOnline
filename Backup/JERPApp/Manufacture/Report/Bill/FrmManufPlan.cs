using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture.Report.Bill
{
    public partial class FrmManufPlan : Form
    {
        public FrmManufPlan()
        {
            InitializeComponent();
            this.accWorkingSheet = new JERPData.Manufacture.WorkingSheets();
            this.ManufPlanEntity = new JERPBiz.Manufacture.ManufPlanEntity();
        }
        private JERPData.Manufacture.WorkingSheets accWorkingSheet;
        private JERPBiz.Manufacture.ManufPlanEntity ManufPlanEntity;
        private DataTable dtblWorkingSheet;
        private long ManufPlanID = -1;
        public void ManufPlan(long ManufPlanID)
        {
            this.ManufPlanID = ManufPlanID;
            this.ManufPlanEntity.LoadData(ManufPlanID);
            this.txtDateNote.Text = this.ManufPlanEntity.DateNote.ToShortDateString();
            this.txtCompanyCode.Text = this.ManufPlanEntity.CompanyCode;
            this.txtDateTarget.Text = this.ManufPlanEntity.DateTarget.ToShortDateString();
            this.txtPrdCode.Text = this.ManufPlanEntity.PrdCode;
            this.txtPrdName.Text = this.ManufPlanEntity.PrdName;
            this.txtPrdSpec.Text = this.ManufPlanEntity.PrdSpec;
            this.txtModel.Text = this.ManufPlanEntity.Model;
            this.txtQuantity.Text = string.Format("{0:0.####}", this.ManufPlanEntity.Quantity);
            this.dtblWorkingSheet =this.accWorkingSheet .GetDataWorkingSheetsByManufPlanID (ManufPlanID ).Tables [0];
            this.tabMain.Controls.Clear();
            CtrlWorkingSheet ctrlWorkingSheet;
            TabPage page;
            foreach (DataRow drow in this.dtblWorkingSheet.Rows)
            {
                page = new TabPage();
                page.Text = drow["WorkingSheetCode"].ToString();
                ctrlWorkingSheet = new CtrlWorkingSheet();
                ctrlWorkingSheet.WorkingSheet((long)drow["WorkingSheetID"]);
                page.Controls.Add(ctrlWorkingSheet);
                ctrlWorkingSheet.Dock = DockStyle.Fill;
                this.tabMain.TabPages.Add(page);
            }
        }
    }
}