using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Supply.Material.Report
{
    public partial class FrmPOFinishedDetail : Form
    {
        public FrmPOFinishedDetail()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accItems = new JERPData.Material.BuyReceiveItems ();
        }
        private JERPData.Material.BuyReceiveItems  accItems;
        private DataTable dtblItems;
        public void DeliverItem(long BuyOrderItemID)
        {
            this.dtblItems = this.accItems.GetDataBuyReceiveItemsByBuyOrderItemID (BuyOrderItemID).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
        }
    }
}