using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture
{
    public partial class CtrlPackingSheet : UserControl
    {
        public CtrlPackingSheet()
        {
            InitializeComponent(); 
            this.dgrdvPackingPlan.AutoGenerateColumns = false;
            this.ctrlQManufPlan.SeachGridView = this.dgrdvPackingPlan;

            this.dgrdvWorkingSheet.AutoGenerateColumns = false;
            this.ctrlCheckedAll.SeachGridView = this.dgrdvWorkingSheet;
            this.ctrlQPackingSheet.SeachGridView = this.dgrdvWorkingSheet;

            this.accWorkingSheets = new JERPData.Packing.WorkingSheets();
            this.accPackingPlans = new JERPData.Packing.PackingPlans();
            this.accBOMPlans = new JERPData.Packing.BOMPlans();

            this.printhelper = new JERPBiz.Packing.WorkingSheetPrintHelper();
            this.printlisthelper = new JERPBiz.Packing.WorkingSheetListPrintHelper();

            this.dgrdvPackingPlan.ContextMenuStrip = this.cMenu;
            this.dgrdvWorkingSheet.ContextMenuStrip = this.cMenu;
            this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
            for (int j = 1; j < this.dgrdvWorkingSheet .ColumnCount; j++)
            {
                this.dgrdvWorkingSheet.Columns[j].ReadOnly = true;
            }
            this.btnExport.Click += new EventHandler(btnExport_Click);
            this.lnkAppend.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkAppend_LinkClicked);
            this.lnkBatchNew.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkBatchNew_LinkClicked);
            this.dgrdvPackingPlan.CellContentClick += new DataGridViewCellEventHandler(dgrdvPackingPlan_CellContentClick); 
            this.dgrdvWorkingSheet .CellContentClick += new DataGridViewCellEventHandler(dgrdvWorkingSheet_CellContentClick);
        } 
        
        private JERPData.Packing .WorkingSheets accWorkingSheets;
        private JERPData.Packing .PackingPlans accPackingPlans;
        private JERPData.Packing .BOMPlans accBOMPlans;
        private JERPBiz.Packing.WorkingSheetPrintHelper printhelper;
        private JERPBiz.Packing.WorkingSheetListPrintHelper printlisthelper;
        private FrmAvailablePackingQty frmAvailablePackingQty; 
        private FrmPackingSheetBatchNew frmBatchNew;
        private FrmPackingSheetOper frmOper;
        private DataTable dtblPackingPlans, dtblWorkingSheets;
        public delegate void AffterLoadDelegate(int PackingPlanCount);
        private AffterLoadDelegate affterLoad;
        public event AffterLoadDelegate AffterLoad
        {
            add
            {
                affterLoad += value;
            }
            remove
            {
                affterLoad -= value;
            }
        }
        public void LoadData()
        {
            this.LoadPackingPlan();
            this.LoadWorkingSheet();

        }
        private void SetPackingAvailabeQty(DataRow drow)
        {
            decimal AvailablePackingQty = 0;
            this.accBOMPlans.GetParmBOMPlanAvailablePackingQty  ((long)drow["PackingPlanID"],
                      ref AvailablePackingQty);
            drow["AvailablePackingQty"] = AvailablePackingQty;
        }
        private void LoadPackingPlan()
        {
            this.dtblPackingPlans = this.accPackingPlans.GetDataPackingPlansNonFinished  ().Tables[0];
            this.dtblPackingPlans.Columns.Add("AvailablePackingQty", typeof(decimal));
            this.dgrdvPackingPlan.DataSource = this.dtblPackingPlans;
            foreach (DataRow drow in this.dtblPackingPlans.Rows)
            {
                this.SetPackingAvailabeQty(drow);
            }
            if (this.affterLoad != null) this.affterLoad(this.dtblPackingPlans.Rows.Count);
        }
        private void LoadWorkingSheet()
        {
            this.dtblWorkingSheets = this.accWorkingSheets.GetDataWorkingSheetsNonFinished ().Tables[0];
            this.dtblWorkingSheets.Columns.Add("CheckedFlag", typeof(bool));
            this.dgrdvWorkingSheet.DataSource = this.dtblWorkingSheets;

        }
        void lnkBatchNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.frmBatchNew == null)
            {
                frmBatchNew = new FrmPackingSheetBatchNew();
                new FrmStyle(frmBatchNew).SetPopFrmStyle(this.ParentForm);
                frmBatchNew.AffterSave += this.LoadData;
            }
            frmBatchNew.LoadData();
            frmBatchNew.ShowDialog();
        }
        private void CreateManufOper()
        {
            if (this.frmOper == null)
            {
                this.frmOper = new FrmPackingSheetOper();
                new FrmStyle(frmOper).SetPopFrmStyle(this);
                this.frmOper.AffterSave += this.LoadData;
            }
        }
        void lnkAppend_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.CreateManufOper();
            frmOper.New();
            frmOper.ShowDialog();
        }
        void mItemRefresh_Click(object sender, EventArgs e)
        {
            if (this.cMenu.SourceControl == this.dgrdvPackingPlan)
            {
                this.LoadPackingPlan();
            } 
            if (this.cMenu.SourceControl == this.dgrdvWorkingSheet )
            {
                this.LoadWorkingSheet ();
            }
        }
        void dgrdvWorkingSheet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            long WorkingSheetID = (long)this.dtblWorkingSheets.DefaultView[irow]["WorkingSheetID"]; 
            if (this.dgrdvWorkingSheet .Columns[icol].Name == this.ColumnbtnEdit.Name)
            {
                this.CreateManufOper();
                frmOper.Edit(WorkingSheetID);
                frmOper.ShowDialog(); 
            }
            if (this.dgrdvWorkingSheet.Columns[icol].Name == this.ColumnbtnPrint.Name)
            { 
                this.printhelper.ExportToExcel(WorkingSheetID);
                string errormsg = string.Empty;
                this.accWorkingSheets.UpdateWorkingSheetsForPublish(ref errormsg,
                    WorkingSheetID);
            }
        }
        void dgrdvPackingPlan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            long PackingPlanID = (long)this.dtblPackingPlans.DefaultView[irow]["PackingPlanID"]; 
            if (this.dgrdvPackingPlan.Columns[icol].Name == this.ColumnbtnCreate.Name)
            {
                this.CreateManufOper();
                this.frmOper.New(PackingPlanID);
                this.frmOper.ShowDialog(); 

            }
            if (this.dgrdvPackingPlan.Columns[icol].Name == this.ColumnAvailableManufQty.Name)
            { 
                if (frmAvailablePackingQty == null)
                {
                    frmAvailablePackingQty = new FrmAvailablePackingQty();
                    new FrmStyle(frmAvailablePackingQty).SetPopFrmStyle(this.ParentForm);
                }
                frmAvailablePackingQty.AvailablePackingQty (PackingPlanID);
                frmAvailablePackingQty.ShowDialog();

                
            }
        }
        private void Export(DataRow[] drows)
        {
            this.printlisthelper.ExportToExcel(drows);

        }
        void btnExport_Click(object sender, EventArgs e)
        {

            DataRow[] drows = this.dtblWorkingSheets.Select("CheckedFlag=1");
            string errormsg = string.Empty;
            foreach (DataRow drow in drows)
            {
                this.accWorkingSheets.UpdateWorkingSheetsForPublish  (ref errormsg,
                    drow["WorkingSheetID"]);
            }
            this.Export(drows);
        }
    }
}
