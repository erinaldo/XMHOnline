using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture.Report
{
    public partial class FrmWorkgroupRpt : Form
    {
        public FrmWorkgroupRpt()
        {
            InitializeComponent();
            this.SetPermit();
        }
        private bool enableBrowse = false;
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(715);
            if (this.enableBrowse)
            {
                this.ctrlYear.Year = DateTime.Now.Year;
                this.ctrlMonth.Month = DateTime.Now.Month;
                this.LoadData();
                this.ctrlYear.OnSelected += this.LoadData;
                this.ctrlMonth.OnSelected += this.LoadData;
            }

        }
        private void LoadData()
        {
            int Year=this.ctrlYear .Year ,Month=this.ctrlMonth .Month ;
            this.ctrlWorkgroupFinishedRpt.LoadData(Year, Month);
            this.ctrlWorkgroupWorkingHour.LoadData(Year, Month);
        }
    }
}