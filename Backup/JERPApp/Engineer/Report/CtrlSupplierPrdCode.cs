using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Engineer.Report
{
    public partial class CtrlSupplierPrdCode : UserControl
    {
        public CtrlSupplierPrdCode()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false; 
            this.accSupplierPrdCode = new JERPData.Product.SupplierPrdCode();   
        }       
        private JERPData.Product.SupplierPrdCode accSupplierPrdCode; 
        private DataTable dtblSupplierCode;
        
        public void SupplierPrdCode(int PrdID)
        {
            this.dtblSupplierCode = this.accSupplierPrdCode.GetDataSupplierPrdCodeByPrdID(PrdID).Tables[0];
            this.dgrdv.DataSource = this.dtblSupplierCode;
          
        }
      
    }
}
