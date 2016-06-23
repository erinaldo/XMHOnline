using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Sale
{
    public partial class FrmCustomerSameSearch : Form
    {
        public FrmCustomerSameSearch()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accCustomer = new JERPData.General.Customer();
        }
        private JERPData.General.Customer accCustomer;
        private DataTable dtblCustomer;
        public void SameSearch(string whereclause)
        {
            this.dtblCustomer = this.accCustomer.GetDataCustomerByFreeSearch(whereclause).Tables[0];
            this.dgrdv.DataSource = this.dtblCustomer;
        }
    }
}