using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store
{
    public partial class FrmBOMStore : Form
    {
        public FrmBOMStore()
        {
            InitializeComponent();  
            this.PrdEntity = new JERPBiz.Product.ProductEntity();
            this.bizMtrStore = new JERPBiz.Material.Store();
            this.bizPrdStore = new JERPBiz.Product.Store();
            this.accPackingType = new JERPData.Product.PackingType();
        }
         
        private JERPBiz.Product.ProductEntity PrdEntity;
        private JERPBiz.Product.Store bizPrdStore;
        private JERPBiz.Material.Store bizMtrStore;
        private JERPData.Product.PackingType accPackingType;
        private DataTable dtblPackingType;
        public void BOMStore(int PrdID)
        {
            this.PrdEntity.LoadData(PrdID);
            this.txtPrdCode.Text = this.PrdEntity.PrdCode;
            this.txtPrdName.Text = this.PrdEntity.PrdName;
            this.txtPrdSpec.Text = this.PrdEntity.PrdSpec;
            this.txtModel.Text = this.PrdEntity.Model;
            this.txtManufacturer.Text = this.PrdEntity.Manufacturer;
            this.txtSurface.Text = this.PrdEntity.Surface;
            this.txtUnitName.Text = this.PrdEntity.UnitName;
            this.txtMinPackingQty.Text = string.Format("{0:0.####}", this.PrdEntity.MinPackingQty);
            this.txtSupplier.Text = this.PrdEntity.Supplier;
            this.txtPrdStoreQty.Text = string.Format("{0:0.####}", this.bizPrdStore.GetPrdStoreQty(PrdID));
            this.txtMtrStoreQty.Text = string.Format("{0:0.####}", this.bizMtrStore.GetPrdStoreQty(PrdID));
            this.ctrlBOMStore.BOMStore(PrdID);
            while (this.tabMain.TabCount > 1)
            {
                this.tabMain.TabPages.RemoveAt(1);
            }
            this.dtblPackingType = this.accPackingType.GetDataPackingTypeByPrdID(PrdID).Tables[0];
            if (this.dtblPackingType.Rows.Count == 0) return;
            TabPage page;
            JERPApp.Define.Product.CtrlPackingTypeStore ctrlPackingStore;
            foreach (DataRow drow in this.dtblPackingType.Rows)
            {
                page = new TabPage();
                page.Text = "°ü×°[" + drow["PackingTypeName"].ToString() + "]";
                ctrlPackingStore = new JERPApp.Define.Product.CtrlPackingTypeStore();
                ctrlPackingStore.PackingBom((int)drow["PackingTypeID"]);
                page.Controls.Add(ctrlPackingStore);
                ctrlPackingStore.Dock = DockStyle.Fill;
                this.tabMain.TabPages .Add(page);
            }
        }
    }
}