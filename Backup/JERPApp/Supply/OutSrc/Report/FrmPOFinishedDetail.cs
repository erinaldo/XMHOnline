using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Supply.OutSrc.Report
{
    public partial class FrmPOFinishedDetail : Form
    {
        public FrmPOFinishedDetail()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accItems = new JERPData.Manufacture.OutSrcReceiveItems ();
        }
        private JERPData.Manufacture.OutSrcReceiveItems  accItems;
        private DataTable dtblItems;
        public void DeliverItem(long OutSrcOrderItemID)
        {
            this.dtblItems = this.accItems.GetDataOutSrcReceiveItemsByOutSrcOrderItemID (OutSrcOrderItemID).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
        }
    }
}