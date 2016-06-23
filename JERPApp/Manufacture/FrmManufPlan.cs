using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture
{
    public partial class FrmManufPlan : Form
    {
        public FrmManufPlan()
        {
            InitializeComponent();
            this.dgrdvOrder.AutoGenerateColumns = false;
            this.ctrlQSale.SeachGridView = this.dgrdvOrder;

            this.dgrdvPrdStore.AutoGenerateColumns = false;
            this.ctrlQPrdStore.SeachGridView = this.dgrdvPrdStore;

            this.dgrdvMtrStore.AutoGenerateColumns = false;
            this.ctrlQMtr.SeachGridView = this.dgrdvMtrStore;
 

            this.accItems = new JERPData.Product.SaleOrderItems();
            this.accPrdStore = new JERPData.Product.Store();
            this.accMtrStore = new JERPData.Material.Store();

            this.accManufPlans = new JERPData.Manufacture.ManufPlans ();


            this.SetPermit();
        }
        private JERPData.Product.SaleOrderItems accItems;
        private JERPData.Product.Store accPrdStore;
        private JERPData.Material.Store accMtrStore;
        private JERPData.Manufacture.ManufPlans   accManufPlans; 
        private FrmManufPlanFromSaleOrder frmSaleOper;
        private FrmManufPlanFromMtrBackupOrder frmMtrBackupOper;
        private FrmManufPlanFromPrdBackupOrder frmPrdBackupOper; 
        private FrmPackingPlanOper frmPackingOper;
        private DataTable dtblSales, dtblPrdStore,dtblMtrStore; 
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(376);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(377);
            if (this.enableBrowse)
            {

           
                //加载数据
                LoadData();
                this.dgrdvOrder.ContextMenuStrip = this.cMenu;
                this.dgrdvPrdStore .ContextMenuStrip = this.cMenu; 
                this.dgrdvMtrStore.ContextMenuStrip = this.cMenu;
                
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                this.lnkRefreshAll.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkRefreshAll_LinkClicked);
             
              
            }
          
            this.ColumnbtnOrder  .Visible = this.enableSave;
            this.ColumnbtnPrdStore .Visible = this.enableSave;
            this.lnkFinishedPrdNew.Enabled = this.enableSave;
            this.lnkPackingPlan.Enabled = this.enableSave;
            this.lnkMtrNew.Enabled = this.enableSave;
            if (this.enableSave)
            {
                this.lnkPackingPlan.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkPackingPlan_LinkClicked);
                this.lnkFinishedPrdNew.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkFinishedPrdNew_LinkClicked);
                this.lnkMtrNew.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkMtrNew_LinkClicked);
                this.dgrdvOrder.CellContentClick += new DataGridViewCellEventHandler(dgrdvOrder_CellContentClick);
                this.dgrdvPrdStore.CellContentClick += new DataGridViewCellEventHandler(dgrdvPrdStore_CellContentClick);
                this.dgrdvMtrStore.CellContentClick += new DataGridViewCellEventHandler(dgrdvMtr_CellContentClick);
            }
        }
 
    
        void lnkMtrNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (frmMtrBackupOper == null)
            {
                frmMtrBackupOper = new FrmManufPlanFromMtrBackupOrder();
                new FrmStyle(frmMtrBackupOper).SetPopFrmStyle(this);
                frmMtrBackupOper.AffterSave += this.LoadData;
            }
            frmMtrBackupOper.BackupOper();
            frmMtrBackupOper.ShowDialog();
        }

        void lnkFinishedPrdNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (frmPrdBackupOper == null)
            {
                frmPrdBackupOper = new FrmManufPlanFromPrdBackupOrder();
                new FrmStyle(frmPrdBackupOper).SetPopFrmStyle(this);
                frmPrdBackupOper.AffterSave += this.LoadData ;
            }
            frmPrdBackupOper.BackupOper();
            frmPrdBackupOper.ShowDialog();
        }

        void lnkPackingPlan_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (frmPackingOper == null)
            {
                frmPackingOper = new FrmPackingPlanOper();
                new FrmStyle(frmPackingOper).SetPopFrmStyle(this);
                frmPackingOper.AffterSave += new FrmPackingPlanOper.AffterSaveDelegate(frmPackingOper_AffterSave);
            }
            frmPackingOper.New();
            frmPackingOper.ShowDialog();
        }

        void frmPackingOper_AffterSave()
        {
            this.ctrlPackingPlan.RefreshData();
        }

        void mItemRefresh_Click(object sender, EventArgs e)
        {
            if (this.cMenu.SourceControl == this.dgrdvOrder)
            {
                this.LoadSale();
            }
            if (this.cMenu.SourceControl == this.dgrdvPrdStore )
            {
                this.LoadPrdStore ();
            }
            if (this.cMenu.SourceControl == this.dgrdvMtrStore )
            {
                this.LoadMtrStore ();
            }
          
           
        }
        private void LoadSale()
        {
            this.dtblSales = this.accItems.GetDataSaleOrderItemsForHandle().Tables[0];
            this.dgrdvOrder.DataSource = this.dtblSales;
            this.pageSale.Text = "销售订单[" + this.dtblSales.Rows.Count.ToString() + "]";
        }
        private void LoadPrdStore()
        {
            this.dtblPrdStore = this.accPrdStore.GetDataStoreSafeInventory().Tables[0];
            this.dgrdvPrdStore .DataSource = this.dtblPrdStore;
            this.pagePrdStore.Text = "成品备库[" + this.dtblPrdStore.Rows.Count.ToString() + "]";
        }
        private void LoadMtrStore()
        {
            this.dtblMtrStore = this.accMtrStore.GetDataStoreSafeInventoryForManuf ().Tables[0];
            this.dgrdvMtrStore.DataSource = this.dtblMtrStore;
            this.pageMtrStore.Text = "半成品备库[" + this.dtblMtrStore.Rows.Count.ToString() + "]";
        }
        private void LoadManufPlan()
        {
            this.ctrlManufPlan.RefreshData();
        }
        private void LoadPackingPlan()
        {
            this.ctrlPackingPlan.RefreshData();
        }
       
        private void LoadData()
        {
            this.LoadSale();
            this.LoadPrdStore();
            this.LoadMtrStore();
            this.LoadManufPlan();
            this.LoadPackingPlan();
        }

        void lnkRefreshAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {    
            this.LoadData();
        }

        void dgrdvOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvOrder.Columns[icol].Name ==this.ColumnbtnOrder.Name )
            {
                long ItemID = (long)this.dtblSales.DefaultView[irow]["ItemID"];
                if (frmSaleOper == null)
                {
                    frmSaleOper = new FrmManufPlanFromSaleOrder();
                    new FrmStyle(frmSaleOper).SetPopFrmStyle(this);
                    frmSaleOper.AffterSave += this.LoadData;
                }
                frmSaleOper.HandleOper(ItemID);
                frmSaleOper.ShowDialog();
            }
        }

      

        void dgrdvPrdStore_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvPrdStore .Columns[icol].Name ==this.ColumnbtnPrdStore.Name )
            {
                int  PrdID = (int )this.dtblPrdStore .DefaultView[irow]["PrdID"];
                decimal RequireQty = (decimal)this.dtblPrdStore.DefaultView[irow]["RequireQty"];
                if (frmPrdBackupOper == null)
                {
                    frmPrdBackupOper = new FrmManufPlanFromPrdBackupOrder();
                    new FrmStyle(frmPrdBackupOper).SetPopFrmStyle(this);
                    frmPrdBackupOper.AffterSave += this.LoadData ;
                }
                frmPrdBackupOper.BackupOper (PrdID ,RequireQty);
                frmPrdBackupOper.ShowDialog();
            }
        }

        void dgrdvMtr_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvMtrStore.Columns[icol].Name == this.ColumnbtnMtrStore .Name)
            {
                int PrdID = (int)this.dtblMtrStore .DefaultView[irow]["PrdID"];
                decimal RequireQty = (decimal)this.dtblMtrStore.DefaultView[irow]["RequireQty"];
                if (frmMtrBackupOper  == null)
                {
                    frmMtrBackupOper = new FrmManufPlanFromMtrBackupOrder();
                    new FrmStyle(frmMtrBackupOper).SetPopFrmStyle(this);
                    frmMtrBackupOper.AffterSave += this.LoadData;
                }
                frmMtrBackupOper.BackupOper(PrdID, RequireQty);
                frmMtrBackupOper.ShowDialog();
            }
        }


    }
}