using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Product.Report
{
    public partial class FrmPrdInventory : Form
    {
        public FrmPrdInventory()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accStore = new JERPData.Product.Store();
        }
        private JERPData.Product.Store accStore;
        private DataTable dtblInventory;
        public void PrdInventory(int PrdID)
        {
            this.dtblInventory = this.accStore.GetDataStoreInventoryQtyByPrdID(PrdID).Tables[0];
            this.dgrdv.DataSource = this.dtblInventory;
        }
    }
}