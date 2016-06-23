using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Engineer
{
    public partial class FrmMaxPrdCode : Form
    {
        public FrmMaxPrdCode()
        {
            InitializeComponent();
            this.ctrlPrdName.AffterSelected +=ctrlPrdName_AffterSelected;
            this.accPrds = new JERPData.Product.Product();
        }
        private JERPData.Product.Product accPrds;
        void ctrlPrdName_AffterSelected()
        {
            string PrdCode = string.Empty;
            this.accPrds.GetParmProductMaxPrdCode(this.ctrlPrdName.PrdName, ref PrdCode);
            this.txtPrdCode.Text = PrdCode;
        }
        

    }
}