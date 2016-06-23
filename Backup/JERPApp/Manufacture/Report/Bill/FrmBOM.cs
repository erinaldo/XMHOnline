using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture.Report.Bill
{
    public partial class FrmBOM : Form
    {
        public FrmBOM()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accManufBOM = new JERPData.Manufacture.BOM();
        } 
        private JERPData.Manufacture.BOM accManufBOM;
        private DataTable dtblBOM;    
        public void BOMDetail(long ManufScheduleID)
        { 
            this.dtblBOM = this.accManufBOM.GetDataBOMForOutStore (ManufScheduleID).Tables[0];
            this.dgrdv.DataSource = this.dtblBOM;
       
        }
    }
}