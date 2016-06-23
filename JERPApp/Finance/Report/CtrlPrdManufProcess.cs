using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Report
{
    public partial class CtrlPrdManufProcess : UserControl
    {
        public CtrlPrdManufProcess()
        {
            InitializeComponent();

            this.dgrdv.AutoGenerateColumns = false;
            this.accManufProcess = new JERPData.Manufacture.ManufProcess();
        }  
        private JERPData.Manufacture.ManufProcess accManufProcess;
        private DataTable dtblManufProcess;
        public void PrdManufProcess(int PrdID)
        {           
            this.dtblManufProcess = this.accManufProcess.GetDataManufProcessByPrdID(PrdID).Tables[0];
            this.dgrdv.DataSource = this.dtblManufProcess;
        }   
    }
}
