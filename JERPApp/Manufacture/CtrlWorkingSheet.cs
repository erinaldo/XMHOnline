using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture
{
    public partial class CtrlWorkingSheet : UserControl
    {
        public CtrlWorkingSheet()
        {
            InitializeComponent(); 
            this.dgrdvManufPlan.AutoGenerateColumns = false;
            this.ctrlQManufPlan.SeachGridView = this.dgrdvManufPlan;

            this.dgrdvWorkingSheet.AutoGenerateColumns = false;
            this.ctrlCheckedAll.SeachGridView = this.dgrdvWorkingSheet;
            this.ctrlQWorkingSheet.SeachGridView = this.dgrdvWorkingSheet;

            this.accWorkingSheets = new JERPData.Manufacture.WorkingSheets();
            this.accManufPlans = new JERPData.Manufacture.ManufPlans();
            this.accBOMPlans = new JERPData.Manufacture.BOMPlans();
            this.printerhelper = new JERPBiz.Manufacture.WorkingSheetPrintHelper();
            this.listprinthelper = new JERPBiz.Manufacture.WorkingSheetListPrintHelper();

            this.dgrdvManufPlan.ContextMenuStrip = this.cMenu;
            this.dgrdvWorkingSheet.ContextMenuStrip = this.cMenu;
            this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
            for (int j = 1; j < this.dgrdvWorkingSheet .ColumnCount; j++)
            {
                this.dgrdvWorkingSheet.Columns[j].ReadOnly = true;
            }
            this.btnExport.Click += new EventHandler(btnExport_Click);
            this.lnkAppend.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkAppend_LinkClicked);
            this.lnkBatchNew.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkBatchNew_LinkClicked);
            this.dgrdvManufPlan.CellContentClick += new DataGridViewCellEventHandler(dgrdvManufPlan_CellContentClick); 
            this.dgrdvWorkingSheet .CellContentClick += new DataGridViewCellEventHandler(dgrdvWorkingSheet_CellContentClick);
        } 
        
        private JERPData.Manufacture.WorkingSheets accWorkingSheets;
        private JERPData.Manufacture.ManufPlans accManufPlans;
        private JERPData.Manufacture.BOMPlans accBOMPlans;
        private JERPBiz.Manufacture.WorkingSheetPrintHelper printerhelper;
        private FrmAvailableManufQty frmAvailableManufQty;
        private JERPBiz.Manufacture.WorkingSheetListPrintHelper listprinthelper;
        private FrmWorkingSheetBatchNew frmBatchNew;
        private FrmWorkingSheetOper frmOper;
        private DataTable dtblManufPlans, dtblWorkingSheets;
        public delegate void AffterLoadDelegate(int ManufPlanCount);
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
            this.LoadManufPlan();
            this.LoadWorkingSheet();

        }
        private void SetManufAvailabeQty(DataRow drow)
        {
            decimal AvailableManufQty = 0;
            this.accBOMPlans.GetParmBOMPlanAvailableManufQty((long)drow["ManufPlanID"],
                      ref AvailableManufQty);
            drow["AvailableManufQty"] = AvailableManufQty;
        }
        private void LoadManufPlan()
        {
            this.dtblManufPlans = this.accManufPlans.GetDataManufPlansNonFinished ().Tables[0];
            this.dtblManufPlans.Columns.Add("AvailableManufQty", typeof(decimal));
            this.dgrdvManufPlan.DataSource = this.dtblManufPlans;
            foreach (DataRow drow in this.dtblManufPlans.Rows)
            {
                this.SetManufAvailabeQty(drow);
            }
            if (this.affterLoad != null) this.affterLoad(this.dtblManufPlans.Rows.Count);
        }
        private void LoadWorkingSheet()
        {
            this.dtblWorkingSheets = this.accWorkingSheets.GetDataWorkingSheetsNonFinished().Tables[0];
            this.dtblWorkingSheets.Columns.Add("CheckedFlag", typeof(bool));
            this.dgrdvWorkingSheet.DataSource = this.dtblWorkingSheets;

        }
        void lnkBatchNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.frmBatchNew == null)
            {
                frmBatchNew = new FrmWorkingSheetBatchNew();
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
                this.frmOper = new FrmWorkingSheetOper();
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
            if (this.cMenu.SourceControl == this.dgrdvManufPlan)
            {
                this.LoadManufPlan();
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
            if (this.dgrdvWorkingSheet.Columns[icol].Name == this.ColumnbtnEdit.Name)
            {

                this.CreateManufOper();
                frmOper.Edit(WorkingSheetID);
                frmOper.ShowDialog();
            }
            
            if (this.dgrdvWorkingSheet.Columns[icol].Name == this.ColumnbtnExport .Name)
            { 
                this.printerhelper.ExportToExcel(WorkingSheetID);
                string errormsg=string.Empty ;
                this.accWorkingSheets.UpdateWorkingSheetsForPublish(ref errormsg,
                    WorkingSheetID);
            }
        }

        void dgrdvManufPlan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            long ManufPlanID = (long)this.dtblManufPlans.DefaultView[irow]["ManufPlanID"]; 
            if (this.dgrdvManufPlan.Columns[icol].Name == this.ColumnbtnCreate.Name)
            {
                this.CreateManufOper();
                this.frmOper.New(ManufPlanID);
                this.frmOper.ShowDialog(); 

            }
            if (this.dgrdvManufPlan.Columns[icol].Name == this.ColumnAvailableManufQty.Name)
            { 
                if (frmAvailableManufQty == null)
                {
                    frmAvailableManufQty = new FrmAvailableManufQty();
                    new FrmStyle(frmAvailableManufQty).SetPopFrmStyle(this.ParentForm);
                }
                frmAvailableManufQty.AvailableManufQty(ManufPlanID);
                frmAvailableManufQty.ShowDialog();

                
            }
        }
        private void Export(DataRow[] drows)
        {
            FrmMsg.Show("正在生成Excel文档，请稍候......");
            this.listprinthelper.ExportToExcel(drows);
            FrmMsg.Hide();

        }
        void btnExport_Click(object sender, EventArgs e)
        {
            DataRow[] drows = this.dtblWorkingSheets.Select("CheckedFlag=1");
            string errormsg = string.Empty;
            foreach (DataRow drow in drows )
            {
                this.accWorkingSheets.UpdateWorkingSheetsForPublish(ref errormsg,
                    drow["WorkingSheetID"]);
            }
            this.Export(drows);
        }
    }
}
