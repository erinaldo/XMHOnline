using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture
{
    public partial class CtrlPackingBOMPlan : UserControl
    {
        public CtrlPackingBOMPlan()
        {
            InitializeComponent();
            this.dgrdvNonBOMPlan.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdvNonBOMPlan;
            this.dgrdvBOMPlan.AutoGenerateColumns = false; 
            this.accPackingPlans = new JERPData.Packing .PackingPlans();
            this.dtpDateBegin.Value = DateTime.Now.Date.AddDays(-3);
            this.dtpDateEnd.Value = DateTime.Now.Date.AddDays(1);
            this.dgrdvNonBOMPlan.ContextMenuStrip = this.cMenu;
            this.dgrdvBOMPlan.ContextMenuStrip = this.cMenu;
            this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
            this.ctrlQFind.BeforeFilter += this.LoadNonBOMPlan;
            this.btnSearch.Click += new EventHandler(btnSearch_Click);
            this.lnkNonPlanBOM.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkNonPlanBOM_LinkClicked);
            this.lnkBatchBOMPlan.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkBatchBOMPlan_LinkClicked);
            this.dgrdvBOMPlan.CellContentClick += new DataGridViewCellEventHandler(dgrdvBOMPlan_CellContentClick);
            this.pbar.OnPageIndexChanged += new EventHandler(pbar_OnPageIndexChanged);
            this.dgrdvNonBOMPlan.CellContentClick += new DataGridViewCellEventHandler(dgrdvNonBOMPlan_CellContentClick); 
        }

        private JERPData.Packing .PackingPlans accPackingPlans;
        private DataTable dtblNonBOMPlans, dtblBOMPlans;
        private string whereclause = string.Empty;
        private string iniwhereclause = " and (BOMPlanFlag=1)";
        private FrmBOMPlanForPacking frmOper;
        private FrmBatchPackingBOMPlanOper frmBatchOper; 
        private Report.Bill.FrmPackingBOMPlan frmBOMDetail;
        public delegate void AffterLoadDelegate(int NonBOMPlanCount);
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
            this.LoadNonBOMPlan();
            this.whereclause = this.iniwhereclause;
            this.LoadBOMPlan();

        }
       
        private void LoadBOMPlan()
        {
            int cnt = 0;
            this.dtblBOMPlans = this.accPackingPlans.GetDataPackingPlansDescPagesFreeSearch(
                1, this.pbar.PageSize, ref cnt, this.whereclause).Tables[0];
            this.dgrdvBOMPlan.DataSource = this.dtblBOMPlans;
            this.pbar.Init(1, cnt);
        }
        void pbar_OnPageIndexChanged(object sender, EventArgs e)
        {
            int cnt = 0;
            this.dtblBOMPlans = this.accPackingPlans.GetDataPackingPlansDescPagesFreeSearch(
               this.pbar.PageIndex, this.pbar.PageSize, ref cnt, this.whereclause).Tables[0];

            this.dgrdvBOMPlan.DataSource = this.dtblBOMPlans;
        }
        private void LoadNonBOMPlan()
        {
            this.dtblNonBOMPlans = this.accPackingPlans.GetDataPackingPlansNeedBOMPlan().Tables[0];
            this.dgrdvNonBOMPlan.DataSource = this.dtblNonBOMPlans;
            if (this.affterLoad != null) this.affterLoad(this.dtblNonBOMPlans.Rows.Count);
        }
        void mItemRefresh_Click(object sender, EventArgs e)
        {
            if (this.cMenu.SourceControl == this.dgrdvNonBOMPlan)
            {
                this.LoadNonBOMPlan ();
            } 
            if (this.cMenu.SourceControl == this.dgrdvBOMPlan )
            {
                this.whereclause = this.iniwhereclause;
                this.LoadBOMPlan();
            }

        }
        void lnkNonPlanBOM_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (frmOper == null)
            {
                frmOper = new FrmBOMPlanForPacking();
                new FrmStyle(frmOper).SetPopFrmStyle(this.ParentForm);
                frmOper.AffterSave += this.LoadData;

            }
            frmOper.PackingPlan();
            frmOper.ShowDialog();
        }

        void lnkBatchBOMPlan_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
             
            if (frmBatchOper == null)
            {
                frmBatchOper = new FrmBatchPackingBOMPlanOper();
                new FrmStyle(frmBatchOper).SetPopFrmStyle(this.ParentForm );
                frmBatchOper.AffterSave += this.LoadData;
            }
            frmBatchOper.LoadData();
            frmBatchOper.ShowDialog();
        }

      
        void btnSearch_Click(object sender, EventArgs e)
        {
            this.whereclause = this.iniwhereclause;
            if (this.ckbPrd.Checked)
            {
                this.whereclause += " and (PrdID=" + this.ctrlPrdID.PrdID.ToString() + ")";
            }
            if (this.ckbDateNote.Checked)
            {
                this.whereclause += " and (DateNote>='" + this.dtpDateBegin.Value.ToShortDateString() + "' and DateNote<='" +
                    this.dtpDateEnd.Value.ToShortDateString() + "')";
            }
           
            this.LoadBOMPlan();
        }

        void dgrdvBOMPlan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            long PackingPlanID = (long)this.dtblBOMPlans.DefaultView[irow]["PackingPlanID"]; 
            if (this.dgrdvBOMPlan.Columns[icol].Name == this.ColumnbtnDetail.Name)
            { 
                if (frmBOMDetail == null)
                {
                    frmBOMDetail = new JERPApp.Manufacture.Report.Bill.FrmPackingBOMPlan();
                    new FrmStyle(frmBOMDetail).SetPopFrmStyle(this.ParentForm );
                }
                frmBOMDetail.BOMPlan(PackingPlanID);
                frmBOMDetail.ShowDialog(); 
            }

        }
        void dgrdvNonBOMPlan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvNonBOMPlan.Columns[icol].Name == this.ColumnbtnBOMPlan.Name)
            {
                long PackingPlanID = (long)this.dtblNonBOMPlans.DefaultView[irow]["PackingPlanID"]; 
                if (frmOper == null)
                {
                    frmOper = new FrmBOMPlanForPacking();
                    new FrmStyle(frmOper).SetPopFrmStyle(this.ParentForm);
                    frmOper.AffterSave += this.LoadData;

                }
                frmOper.PackingPlan (PackingPlanID);
                frmOper.ShowDialog();
           
            }
        }
 
    }
}
