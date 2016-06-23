using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture.SemiPrd.Report
{
    public partial class FrmOutSrcInventory : Form
    {
        public FrmOutSrcInventory()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accItems = new JERPData.Manufacture.OutSrcOrderItems();
            
        }
        private JERPData.Manufacture.OutSrcOrderItems accItems;
        private DataTable dtblItems;
        public void OutSrcInventory(long ManufProcessID)
        {
            this.dtblItems = this.accItems.GetDataOutSrcOrderItemsNonFinishedByManufProcessID(ManufProcessID).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
        }
    }
}