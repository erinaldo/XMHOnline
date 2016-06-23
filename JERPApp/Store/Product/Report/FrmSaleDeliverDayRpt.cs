using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Product.Report
{
    public partial class FrmSaleDeliverDayRpt : Form
    {
        public FrmSaleDeliverDayRpt()
        {
            InitializeComponent();
            this.accBranchStore = new JERPData.Product.BranchStore();
            this.SetPermit();
        }
        private JERPData.Product.BranchStore accBranchStore;
        private DataTable dtblBranchStore;
        //È¨ÏÞÂë
        private bool enableBrowse = false;//ä¯ÀÀ
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(527);
            if (this.enableBrowse)
            {
                this.ctrlYear.Year = DateTime.Now.Year;
                this.ctrlMonth.Month = DateTime.Now.Month;
                this.ctrlYear.OnSelected += this.LoadData;
                this.ctrlMonth.OnSelected += this.LoadData;
                this.dtblBranchStore = this.accBranchStore.GetDataBranchStore().Tables[0];
                TabPage page;
                CtrlSaleDeliverBranchStoreDayRpt ctrlBranchStoreRpt;
                foreach (DataRow drow in this.dtblBranchStore.Rows)
                {
                    page = new TabPage();
                    page.Tag =(int)drow["BranchStoreID"];
                    page.Text = drow["BranchStoreName"].ToString();
                    ctrlBranchStoreRpt = new CtrlSaleDeliverBranchStoreDayRpt();
                    page.Controls.Add(ctrlBranchStoreRpt);
                    ctrlBranchStoreRpt.Dock = DockStyle.Fill;
                    this.tabMain.TabPages.Add(page);
                }
                this.LoadData(); 
            }


        }
     
        private void LoadData()
        {
            int Year=this.ctrlYear .Year ;
            int Month=this.ctrlMonth .Month ;
            this.ctrlSaleDeliverDayRpt.LoadData(Year, Month);
            CtrlSaleDeliverBranchStoreDayRpt ctrlBranchStoreRpt;
            TabPage page;
            for (int i = 1; i < this.tabMain.TabPages.Count; i++)
            {
                page = this.tabMain.TabPages[i];
                ctrlBranchStoreRpt = (CtrlSaleDeliverBranchStoreDayRpt)page.Controls[0];
                ctrlBranchStoreRpt.LoadData(Year, Month,(int)page.Tag );
            }

        }


    }
}