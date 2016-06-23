using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture
{
    public partial class CtrlPackingPlan : UserControl
    {
        public CtrlPackingPlan()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accPackingPlans = new JERPData.Packing.PackingPlans ();
            this.dtpDateBegin.Value = DateTime.Now.Date.AddDays(-3);
            this.dtpDateEnd.Value = DateTime.Now.Date.AddDays(1);
            this.whereclause = string.Empty;
            this.dgrdv.ContextMenuStrip = this.cMenu;
            this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
            this.btnSearch.Click += new EventHandler(btnSearch_Click);
            this.pbar.OnPageIndexChanged += new EventHandler(pbar_OnPageIndexChanged);
            this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
        }

        private JERPData.Packing.PackingPlans  accPackingPlans;
        private JERPApp.Manufacture.FrmPackingPlanOper frmOper;
        private Report.Bill.FrmPackingPlan frmPackingPlan;
        private DataTable dtblPackingPlans;
        private string whereclause = string.Empty;
        void mItemRefresh_Click(object sender, EventArgs e)
        { 
                this.whereclause = string.Empty;
                this.LoadData(); 
        }
        public void RefreshData()
        {
            this.whereclause = string.Empty;
            this.LoadData();
            
        }
        private   void LoadData()
        {
            int cnt = 0;
            this.dtblPackingPlans = this.accPackingPlans.GetDataPackingPlansDescPagesFreeSearch (1,
                this.pbar.PageSize, ref cnt, this.whereclause).Tables[0];
            this.dgrdv.DataSource = this.dtblPackingPlans;
            this.pbar.Init(1, cnt);
        }

        void pbar_OnPageIndexChanged(object sender, EventArgs e)
        {
            int cnt = 0;
            this.dtblPackingPlans = this.accPackingPlans.GetDataPackingPlansDescPagesFreeSearch (this.pbar.PageIndex,
                this.pbar.PageSize, ref cnt, this.whereclause).Tables[0];
            this.dgrdv.DataSource = this.dtblPackingPlans;
        }
        void btnSearch_Click(object sender, EventArgs e)
        {
            this.whereclause = string.Empty;
            if (this.ckbPrd.Checked)
            {
                this.whereclause += " and (PrdID=" + this.ctrlPrdID.PrdID.ToString() + ")";
            }
            if (this.ckbDateNote.Checked)
            {
                this.whereclause += " and (DateNote>='" + this.dtpDateBegin.Value.ToShortDateString() + "' and DateNote<='" +
                    this.dtpDateEnd.Value.ToShortDateString() + "')";
            }
          
            if (this.ckbBOMFlag.Checked)
            {
                if (this.radBOMFlag.Checked)
                {
                    this.whereclause += " and (BOMPlanFlag=1)";
                }

                if (this.radNonBOMPlan.Checked)
                {
                    this.whereclause += " and (BOMPlanFlag=0)";
                }

            }
            if (this.ckbFinished.Checked)
            {
                if (this.radFinishedFlag.Checked)
                {
                    this.whereclause += " and (NonFinishedQty>0)";
                }
                if (this.radNonFinishedFlag.Checked)
                {
                    this.whereclause += " and (NonFinishedQty=0)";
                }

            }
            this.LoadData ();
        }

        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            long PackingPlanID = (long)this.dtblPackingPlans.DefaultView[irow]["PackingPlanID"];
            if (this.dgrdv.Columns[icol].Name == this.ColumnbtnEdit.Name)
            {

                if (frmOper == null)
                {
                    frmOper = new FrmPackingPlanOper();
                    frmOper.AffterSave += this.RefreshData ;
                    new FrmStyle(frmOper).SetPopFrmStyle(this.ParentForm );
                }
                frmOper.Edit(PackingPlanID);
                frmOper.ShowDialog();

            }
            if (this.dgrdv.Columns[icol].Name == this.ColumnFinishedQty.Name)
            {
                if (frmPackingPlan == null)
                {
                    frmPackingPlan = new JERPApp.Manufacture.Report.Bill.FrmPackingPlan();
                    new FrmStyle(frmPackingPlan).SetPopFrmStyle(this.ParentForm);
                }
                frmPackingPlan.PackingPlan (PackingPlanID);
                frmPackingPlan.ShowDialog();
            }
        }
    }
}
