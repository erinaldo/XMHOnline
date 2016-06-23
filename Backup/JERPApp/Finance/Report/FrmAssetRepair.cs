using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Report
{
    public partial class FrmAssetRepair : Form
    {
        public FrmAssetRepair()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accRecord = new JERPData.Asset.PrdRepairRecord();         
         
        }

     
        private JERPData.Asset.PrdRepairRecord accRecord;
        private DataTable dtblRecord;
        public void RepairRecord(int PrdID)
        {
           
            this.dtblRecord = this.accRecord.GetDataPrdRepairRecordByPrdID (PrdID).Tables[0];
            this.dgrdv.DataSource = this.dtblRecord;
        }
      

    }
}