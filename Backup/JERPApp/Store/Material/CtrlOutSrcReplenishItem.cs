using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Material
{
    public partial class CtrlOutSrcReplenishItem : UserControl
    {
        public CtrlOutSrcReplenishItem()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.dgrdv.ContextMenuStrip = this.cMenu;
            this.accItems = new JERPData.Material.OutSrcSupplyItems();
            this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
            this.lnkNew.Click += new EventHandler(lnkNew_Click);
        }
        private JERPData.Material.OutSrcSupplyItems accItems;
        private int CompanyID = -1;
        private DataTable dtblItems;
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
        public void ReplenishItem(int CompanyID)
        {
            this.CompanyID = CompanyID;
            this.LoadData();
        }
        private void LoadData()
        {
            this.dtblItems = this.accItems.GetDataOutSrcSupplyItemsForReplenish(this.CompanyID).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
        }
        void lnkNew_Click(object sender, EventArgs e)
        {
            if (this.affterNew != null) this.affterNew(this.CompanyID);
        }

        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }

    }
}
