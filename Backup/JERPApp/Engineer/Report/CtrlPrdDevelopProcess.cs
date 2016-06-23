using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Engineer.Report
{
    public partial class CtrlPrdDevelopProcess : UserControl
    {
        public CtrlPrdDevelopProcess()
        {
            InitializeComponent();

            this.dgrdv.AutoGenerateColumns = false;
            this.accDevelopProcess = new JERPData.Technology.DevelopProcess();
        }  
        private JERPData.Technology.DevelopProcess accDevelopProcess;
        private DataTable dtblDevelopProcess;
        public void PrdDevelopProcess(int PrdID)
        {           
            this.dtblDevelopProcess = this.accDevelopProcess.GetDataDevelopProcessByPrdID(PrdID).Tables[0];
            this.dgrdv.DataSource = this.dtblDevelopProcess;
        }   
    }
}
