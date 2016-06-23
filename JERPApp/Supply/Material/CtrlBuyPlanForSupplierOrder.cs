using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Supply.Material
{
    public partial class CtrlBuyPlanForSupplierOrder : UserControl
    {
        public CtrlBuyPlanForSupplierOrder()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accBuyPlan = new JERPData.Material.BuyPlans();
            this.dgrdv.ContextMenuStrip = this.cMenu;
            this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
            this.lnkNew.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkNew_LinkClicked);
            this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
        }


        JERPData.Material.BuyPlans accBuyPlan;
        private DataTable dtblBuyPlan;
        private int CompanyID = -1;
        public delegate void AffterNewDelegate(int CompanyID);
        private AffterNewDelegate affterNew;
        public event AffterNewDelegate AffterNew
        {
            add
            {
                affterNew += value;
            }
            remove
            {
                affterNew -= value;
            }
        }
        private void LoadData()
        {
            this.dtblBuyPlan = this.accBuyPlan.GetDataBuyPlansForSupplierOrder(JERPBiz.Frame.UserBiz.PsnID,
              this.CompanyID).Tables[0];
            this.dgrdv.DataSource = this.dtblBuyPlan;
        }
        public void SupplierPlan(int CompanyID)
        {
            this.CompanyID = CompanyID;
            this.LoadData();
        }

        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnPrdCode.Name)
            {
                string url = this.dgrdv[this.ColumnURL.Name, irow].Value.ToString();
                if (url == string.Empty) return;
                System.Diagnostics.Process.Start(url);
            }
        }
        void lnkNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.affterNew != null) this.affterNew(this.CompanyID );
        }
    }
}
