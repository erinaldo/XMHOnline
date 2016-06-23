using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Supply.Material
{
    public partial class FrmPurchaseSetting: Form
    {
        public FrmPurchaseSetting()
        {
            InitializeComponent(); 
            this.SetPermit();
        } 
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(387);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(388);
            if (this.enableBrowse)
            {
                this.ctrlBuyer.AffterRefresh += new CtrlBuyerSetting.AffterRefreshDelegate(ctrlBuyer_AffterRefresh);
                this.ctrlSupplier.AffterRefresh += new CtrlSupplierSetting.AffterRefreshDelegate(ctrlSupplier_AffterRefresh);
                //加载数据
                LoadData();
                this.lnkRefreshAll.Click += new EventHandler(lnkRefreshAll_Click);
            }      
           
        }

        void ctrlSupplier_AffterRefresh()
        {
            this.pageSupplier.Text = "未设供应商[" + ctrlSupplier.Count.ToString() + "]";
        }

        void ctrlBuyer_AffterRefresh()
        {
            this.pageBuyer.Text = "未设采购员[" + this.ctrlBuyer.Count.ToString() + "]";
        }

        void lnkRefreshAll_Click(object sender, EventArgs e)
        {
            this.LoadData();
        } 
        private void LoadData()
        {
            this.ctrlSupplier.LoadData();
            this.pageSupplier.Text = "未设供应商[" + ctrlSupplier.Count.ToString() + "]";

            this.ctrlBuyer.LoadData();
            this.pageBuyer.Text = "未设采购员[" + this.ctrlBuyer.Count.ToString() + "]";

            
        }
 
      
    }
}