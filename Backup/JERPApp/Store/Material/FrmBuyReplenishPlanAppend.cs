using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Material
{
    public partial class FrmBuyReplenishPlanAppend : Form
    {
        public FrmBuyReplenishPlanAppend()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlCheckedAll.SeachGridView = this.dgrdv;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.btnAppend.Click += new EventHandler(btnAppend_Click);
            this.accReplenishPlans = new JERPData.Material.BuyReplenishPlans();
            for (int j = 1; j < this.dgrdv.ColumnCount; j++)
            {
                this.dgrdv.Columns[j].ReadOnly = true;
            }
        }

        private JERPData.Material.BuyReplenishPlans accReplenishPlans;
        private DataTable dtblPlans;
        public delegate void AffterAppendDelegate(DataRow drowPlan);
        private AffterAppendDelegate affterAppend;
        public event AffterAppendDelegate AffterAppend
        {
            add
            {
                affterAppend += value;
            }
            remove
            {
                affterAppend -= value;
            }
        }
        public void AppendOper(int CompanyID, DataRow[] drows)
        {
            this.dtblPlans = this.accReplenishPlans.GetDataBuyReplenishPlansForReplenish(CompanyID).Tables[0];
            DataRow[] drowPlans;
            foreach (DataRow drow in drows)
            {
                drowPlans = this.dtblPlans.Select("PrdID=" + drow["PrdID"].ToString());
                if (drowPlans .Length >0)
                {
                    drowPlans[0].Delete();
                }
            }
            this.dtblPlans.Columns.Add("CheckedFlag", typeof(bool));
            this.dgrdv.DataSource = this.dtblPlans;
        }

        void btnAppend_Click(object sender, EventArgs e)
        {
            DataRow[] drows = this.dtblPlans.Select("CheckedFlag=1");
            if (drows.Length == 0)
            {
                MessageBox.Show("未选择任何行");
                return;
            }
            foreach (DataRow drow in drows)
            {
                if (this.affterAppend != null) this.affterAppend(drow);
            }
            this.Close();
        }
    }
}