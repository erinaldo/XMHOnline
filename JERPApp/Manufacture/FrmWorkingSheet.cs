using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture
{
    public partial class FrmWorkingSheet : Form
    {
        public FrmWorkingSheet()
        {
            InitializeComponent();
            
            this.SetPermit();
        } 
       
      
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(241);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(242);
            if (this.enableBrowse)
            {
               
                this.ctrlWorkingSheet.AffterLoad += new CtrlWorkingSheet.AffterLoadDelegate(ctrlWorkingSheet_AffterLoad);
                this.ctrlPackingSheet.AffterLoad += new CtrlPackingSheet.AffterLoadDelegate(ctrlPackingSheet_AffterLoad);
                
                this.ctrlWorkingSheet.LoadData();
                this.ctrlPackingSheet.LoadData();
                this.lnkRefreshAll.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkRefreshAll_LinkClicked);
            }
            this.ctrlWorkingSheet.Enabled = this.enableSave;
            this.ctrlPackingSheet.Enabled = this.enableSave;
        }

        void lnkRefreshAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            this.ctrlWorkingSheet.LoadData();
            this.ctrlPackingSheet.LoadData();
        }

        void ctrlPackingSheet_AffterLoad(int PackingPlanCount)
        {
            this.pagePacking.Text = "包装制令:" + PackingPlanCount.ToString();
        }

        void ctrlWorkingSheet_AffterLoad(int ManufPlanCount)
        {
            this.pageManuf.Text = "生产制令:" + ManufPlanCount.ToString();
        }
    

    }
}