using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture.Tool
{
    public partial class FrmRepairRecord : Form
    {
        public FrmRepairRecord()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accRecords = new JERPData.Tool .RepairRecords();
        }
        private JERPData.Tool .RepairRecords accRecords;
        private DataTable dtblRecords;
        public void RepairRecord(int PrdID)
        {
            this.dtblRecords = this.accRecords.GetDataRepairRecordsByPrdID (PrdID).Tables[0];
            this.dgrdv.DataSource = this.dtblRecords;
        }
   
    }
}