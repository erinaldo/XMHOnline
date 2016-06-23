using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Sale
{
    public partial class FrmProductForSale : Form
    {
        public FrmProductForSale()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accStore = new JERPData.Product.Store();
            this.SetPermit();
        }

     
        private JERPData.Product.Store   accStore;
        private DataTable dtblStore;
        private JCommon.FrmFileBrowse frmFileBrowse;
        private JCommon.FrmImgBrowse frmImgBrowse;
        private JERPApp.Store.Product.Report.FrmPrdInventory frmPrdInventory;
        //È¨ÏÞÂë
        private bool enableBrowse = false;//ä¯ÀÀ
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(123);
            if (this.enableBrowse)
            {
                this.dgrdv.ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                this.ctrlQFind.SeachGridView = this.dgrdv;  
                this.dgrdv .CellContentClick +=new DataGridViewCellEventHandler(dgrdv_CellContentClick);
                this.LoadData();
            }         
          
        }

        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }       
        private void LoadData()
        {
            this.dtblStore  = this.accStore .GetDataStoreForSaler().Tables[0];
            this.dgrdv.DataSource = this.dtblStore;
       
        }

        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            int PrdID = (int)this.dtblStore.DefaultView[irow]["PrdID"];
            if (this.dgrdv.Columns[icol].Name == this.ColumnlnkPriceFile.Name)
            {
                if (frmFileBrowse == null)
                {
                    frmFileBrowse = new JCommon.FrmFileBrowse();
                    frmFileBrowse.ReadOnly = true;
                    new FrmStyle(frmFileBrowse).SetPopFrmStyle(this);

                }
                frmFileBrowse.Browse(JERPData.ServerParameter.ERPFileFolder + @"\Product\PrdSaleFile\" + PrdID.ToString());
                frmFileBrowse.ShowDialog();
            }
            if (this.dgrdv.Columns[icol].Name == this.ColumnlnkImg.Name)
            {
                if (frmImgBrowse == null)
                {
                    frmImgBrowse = new JCommon.FrmImgBrowse();
                    frmImgBrowse.ReadOnly = true;
                    new FrmStyle(frmImgBrowse).SetPopFrmStyle(this);
                }
                frmImgBrowse.Browse(JERPData.ServerParameter.ERPFileFolder + @"\Product\PrdImg\" + PrdID.ToString());
                frmImgBrowse.ShowDialog();
            }
            if (this.dgrdv.Columns[icol].Name == this.ColumnInventoryQty .Name)
            {
                if (frmPrdInventory == null)
                {
                    frmPrdInventory = new JERPApp.Store.Product.Report.FrmPrdInventory();
                    new FrmStyle(frmPrdInventory).SetPopFrmStyle(this);                    
                }
                frmPrdInventory.PrdInventory(PrdID);
                frmPrdInventory.ShowDialog();
            }
        }


    }
}