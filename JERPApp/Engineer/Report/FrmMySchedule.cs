using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Engineer.Report
{
    public partial class FrmMySchedule : Form
    {
        public FrmMySchedule()
        {
            InitializeComponent();        
            this.SetPermit();
        }  
        private bool enableBrowse = false;//‰Ø¿¿
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(723);
            if (this.enableBrowse)
            {

                this.ctrlDevelopScheduleForPsn.ContextMenuStrip = this.cMenu;
                //º”‘ÿ ˝æ›
                LoadData();            
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
               
            }
        }
        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
        private void LoadData()
        {
            this.ctrlDevelopScheduleForPsn.Schedule(JERPBiz.Frame.UserBiz.PsnID);

        }
  
    }
}