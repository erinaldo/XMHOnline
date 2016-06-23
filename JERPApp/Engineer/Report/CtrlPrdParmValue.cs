using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Engineer.Report
{
    public partial class CtrlPrdParmValue : UserControl
    {
        public CtrlPrdParmValue()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accParmValue = new JERPData.Product.ParmValues();
        }

        private JERPData.Product.ParmValues accParmValue;
        private DataTable dtblParmValues;
        public void PrdParm(int PrdID)
        {
        
            this.dtblParmValues = this.accParmValue.GetDataParmValuesByPrdID(PrdID).Tables[0];
            this.dgrdv.DataSource = this.dtblParmValues;
        }
    }
}
