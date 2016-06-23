using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture.Report.Bill
{
    public partial class FrmManufScheduleWIP : Form
    {
        public FrmManufScheduleWIP()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accWIP = new JERPData.Manufacture.WIP();

        }
        private JERPData.Manufacture.WIP accWIP;
        private DataTable dtblWIP;
        public void ScheduleWIP(long ManufScheduleID)
        {
            this.dtblWIP = this.accWIP.GetDataWIPByManufScheduleID(ManufScheduleID).Tables[0];
            this.dgrdv.DataSource = this.dtblWIP;
        }
    }
}