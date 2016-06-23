using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Sale.Report
{
    public partial class FrmSaleOrderItemFinishedDetail : Form
    {
        public FrmSaleOrderItemFinishedDetail()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accItems = new JERPData.Product.SaleDeliverItems();
        }
        private JERPData.Product.SaleDeliverItems accItems;
        private DataTable dtblItems;
        public void DeliverItem(long SaleOrderItemID)
        {
            this.dtblItems = this.accItems.GetDataSaleDeliverItemsBySaleOrderItemID(SaleOrderItemID).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
        }
    }
}