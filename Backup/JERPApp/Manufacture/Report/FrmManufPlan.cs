using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture.Report
{
    public partial class FrmManufPlan : Form
    {
        public FrmManufPlan()
        {
            InitializeComponent();
            this.accManufPlans = new JERPData.Manufacture.ManufPlans();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQManufPlan.SeachGridView = this.dgrdv;
            this.SetPermit();
        }
        private Report.Bill.FrmManufPlan frmManufPlan;
        private JERPData.Manufacture.ManufPlans accManufPlans;
        private string whereclause = string.Empty; 
        private DataTable dtblManufPlans;
        //È¨ÏÞÂë
        private bool enableBrowse = false;//ä¯ÀÀ
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(246);
            if (this.enableBrowse)
            {
                this.dtpDateBegin.Value = DateTime.Now.Date.AddDays(-10);
                this.dtpDateEnd.Value = DateTime.Now.Date.AddDays(1);
                this.LoadData();
                this.pbar.OnPageIndexChanged += new EventHandler(pbar_OnPageIndexChanged);
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdvManufPlan_CellContentClick);  
                this.btnSearch.Click += new EventHandler(btnSearch_Click);
            }

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
            if (this.ckbWorkingSheet.Checked)
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
            this.LoadData();
        }
        private void LoadData()
        {
            int cnt = 0;
            this.dtblManufPlans = this.accManufPlans.GetDataManufPlansDescPagesFreeSearch(1,
                this.pbar.PageSize, ref cnt, this.whereclause).Tables[0];
            this.dgrdv.DataSource = this.dtblManufPlans;
            this.pbar.Init(1, cnt);
        }
        void dgrdvManufPlan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            long ManufPlanID = (long)this.dtblManufPlans.DefaultView[irow]["ManufPlanID"]; 
            if (this.dgrdv.Columns[icol].Name == this.ColumnbtnDetail.Name)
            {
                if (frmManufPlan == null)
                {
                    frmManufPlan = new JERPApp.Manufacture.Report.Bill.FrmManufPlan();
                    new FrmStyle(frmManufPlan).SetPopFrmStyle(this);
                }
                frmManufPlan.ManufPlan(ManufPlanID);
                frmManufPlan.ShowDialog();
            }
        }
        void pbar_OnPageIndexChanged(object sender, EventArgs e)
        {
            int cnt = 0;
            this.dtblManufPlans = this.accManufPlans.GetDataManufPlansDescPagesFreeSearch(this.pbar.PageIndex,
                this.pbar.PageSize, ref cnt, this.whereclause).Tables[0];
            this.dgrdv.DataSource = this.dtblManufPlans;
        }
    }
}