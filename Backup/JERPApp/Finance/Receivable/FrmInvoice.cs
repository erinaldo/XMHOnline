using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Receivable
{
    public partial class FrmInvoice : Form
    {
        public FrmInvoice()
        {
            InitializeComponent(); 
            this.SetPermit();
        }
       
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableCreate = false;//保存  
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(107);
            this.enableCreate = JERPBiz.Frame.PermitHelper.EnableFunction(108); 
            if (this.enableBrowse)
            {
                this.ctrlSaleInvoice.AffterRefresh += new CtrlSaleInvoice.AffterRefreshDelegate(ctrlSaleInvoice_AffterRefresh);
                this.ctrlRepairInvoice.AffterRefresh += new CtrlRepairInvoice.AffterRefreshDelegate(ctrlRepairInvoice_AffterRefresh);
                this.lnkRefreshAll .LinkClicked +=new LinkLabelLinkClickedEventHandler(lnkRefreshAll_LinkClicked);
                this.LoadData();
            }
            this.ctrlSaleInvoice.Enabled = this.enableCreate;
            this.ctrlRepairInvoice.Enabled = this.enableCreate;
        }
        private void LoadData()
        {
            this.ctrlSaleInvoice.LoadData();
            this.ctrlRepairInvoice.LoadData();
        }
        void ctrlRepairInvoice_AffterRefresh(int count)
        {
            this.pageRepair.Text = "维修发票[" + count.ToString() + "]";
        }

        void ctrlSaleInvoice_AffterRefresh(int count)
        {
            this.pageSale.Text = "销售发票[" + count.ToString() + "]";
        }

        void lnkRefreshAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.LoadData();    
        }
       
      

    }
}