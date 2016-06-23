using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture.Report.Bill
{
    public partial class FrmPackingBOM : Form
    {
        public FrmPackingBOM()
        {
            InitializeComponent();

            this.accBOM = new JERPData.Packing .BOM();
            this.ctrlQFind.SeachGridView = this.dgrdv;
        }

      
        private JERPData.Packing .BOM  accBOM;
        private DataTable dtblPackingBOM;  
        public void BOMDetail(long WorkingSheetID)
        { 
            this.dtblPackingBOM = this.accBOM.GetDataBOMForOutStore(WorkingSheetID).Tables[0]; 
            this.dgrdv .DataSource = this.dtblPackingBOM;
        
        }
    }
}