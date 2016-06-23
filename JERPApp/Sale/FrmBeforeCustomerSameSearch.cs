using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Sale
{
    public partial class FrmBeforeCustomerSameSearch : Form
    {
        public FrmBeforeCustomerSameSearch()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accCustomer = new JERPData.General.PotentialCustomer ();
        }
        private JERPData.General.PotentialCustomer accCustomer;
        private DataTable dtblCustomer;
        public void SameSearch(string whereclause)
        {
            this.dtblCustomer = this.accCustomer.GetDataPotentialCustomerFreeSearch (whereclause).Tables[0];
            this.dgrdv.DataSource = this.dtblCustomer;
        }
    }
}