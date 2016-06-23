using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture
{
    public partial class FrmBOMPlan : Form
    {
        public FrmBOMPlan()
        {
            InitializeComponent(); 
            this.SetPermit();
        } 
 
           //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(342);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(343);
            if (this.enableBrowse)
            {
                this.ctrlManufBOMPlan.AffterLoad += new CtrlManufBOMPlan.AffterLoadDelegate(ctrlManufBOMPlan_AffterLoad);
                this.ctrlPackingBOMPlan.AffterLoad += new CtrlPackingBOMPlan.AffterLoadDelegate(ctrlPackingBOMPlan_AffterLoad);
                this.ctrlManufBOMPlan.LoadData();
                this.ctrlPackingBOMPlan.LoadData();
                this.lnkRefreshAll.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkRefreshAll_LinkClicked);
            }
            this.ctrlManufBOMPlan.Enabled = this.enableSave;
            this.ctrlPackingBOMPlan.Enabled = this.enableSave;
            
        }
        void ctrlManufBOMPlan_AffterLoad(int NonBOMPlanCount)
        {
            this.pageManufBOM.Text = "生产物料:" + NonBOMPlanCount.ToString();
        }
        void ctrlPackingBOMPlan_AffterLoad(int NonBOMPlanCount)
        {
            this.pagePackingBOM.Text = "包装物料:" + NonBOMPlanCount.ToString();
        }
        void lnkRefreshAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.ctrlManufBOMPlan.LoadData();
            this.ctrlPackingBOMPlan.LoadData();
        }

    }
}