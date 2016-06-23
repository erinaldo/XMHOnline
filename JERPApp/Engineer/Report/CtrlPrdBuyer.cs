using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Engineer.Report
{
    public partial class CtrlPrdBuyer : UserControl
    {
        public CtrlPrdBuyer()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false; 
            this.accXBuyer = new JERPData.Product.ProductXBuyer ();   
        }       
        private JERPData.Product.ProductXBuyer  accXBuyer; 
        private DataTable dtblBuyer;        
        public void PrdBuyer(int PrdID)
        {
            this.dtblBuyer= this.accXBuyer.GetDataProductXBuyerByPrdID (PrdID).Tables[0];
            this.dgrdv.DataSource = this.dtblBuyer;
          
        }
      
    }
}
