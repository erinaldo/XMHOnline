using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Product.Report
{
    public partial class FrmInventory : Form
    {
        public FrmInventory()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accStore = new JERPData.Product.Store();
            this.accBranchStore = new JERPData.Product.BranchStore(); 
            this.SetPermit();
        }
        private JERPData.Product.Store accStore; 
        private JERPData.Product.BranchStore accBranchStore;
        private DataTable dtblInventory, dtblBranchSotre;
        private FrmInventoryRecord frmRecord; 
        //权限码
        private bool enableBrowse = false;//浏览 
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(57); 
            if (this.enableBrowse)
            {
                this.dtblBranchSotre = this.accBranchStore.GetDataBranchStore().Tables[0];
                this.CreateGridColumn();
                //加载数据
                this.LoadInventory();
                this.LoadBranchInventory();
                this.ctrlQFind.BeforeFilter += ctrlQFind_BeforeFilter;
                this.dgrdv.ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
                this.btnExplore.Click += new EventHandler(btnExplore_Click);
            }

        }

        void ctrlQFind_BeforeFilter()
        {
            this.LoadInventory();
        }
        private void LoadBranchInventory()
        {
            TabPage page;
            CtrlBranchInventory ctrlBranchInventory;
            int BranchStoreID = -1;
            string BranchStoreName;
            foreach (DataRow drow in this.dtblBranchSotre.Rows)
            {
                BranchStoreID = (int)drow["BranchStoreID"];
                BranchStoreName = drow["BranchStoreName"].ToString();
                page = new TabPage();
                page.Text = BranchStoreName;
                ctrlBranchInventory = new CtrlBranchInventory();
                ctrlBranchInventory.BranchInventory(BranchStoreID, BranchStoreName);
                ctrlBranchInventory.AffterSelect += new CtrlBranchInventory.AffterSelectDelegate(ctrlBranchInventory_AffterSelect);
                page.Controls.Add(ctrlBranchInventory);
                ctrlBranchInventory.Dock = DockStyle.Fill;
                this.tabMain.TabPages .Add (page);
            }
            this.ctrlTabNav.NavTabControl = this.tabMain;
        }

        void ctrlBranchInventory_AffterSelect(int BranchStoreID, int PrdID)
        {
            
            if (this.frmRecord == null)
            {
                this.frmRecord = new FrmInventoryRecord();
                new FrmStyle(frmRecord).SetPopFrmStyle(this);
            }
            this.frmRecord.StoreRecord(PrdID,
                BranchStoreID,
                 DateTime.Now);
            this.frmRecord.ShowDialog();
        }
        private void CreateGridColumn()
        {
            
            DataGridViewLinkColumn  lnk;
            foreach (DataRow drow in this.dtblBranchSotre.Rows)
            {
                lnk = new DataGridViewLinkColumn();
                lnk.DataPropertyName = drow["BranchStoreID"].ToString();
                lnk.HeaderText = drow["BranchStoreName"].ToString();
                lnk.Width = 66;
                lnk.SortMode = DataGridViewColumnSortMode.Automatic;
                this.dgrdv.Columns.Add(lnk);
            }
            DataGridViewTextBoxColumn txt = new DataGridViewTextBoxColumn();
            txt.DataPropertyName = "-1";
            txt.HeaderText = "合计";
            txt.Width = 70;
            txt.SortMode = DataGridViewColumnSortMode.Automatic;
            this.dgrdv.Columns.Add(txt);
            this.ctrlQFind.SeachGridView = this.dgrdv;
        }
      
        private void LoadInventory()
        {
            this.dtblInventory = this.accStore.GetDataStorePivotBranchStoreID ().Tables[0];
            this.dgrdv.DataSource = this.dtblInventory;
            if (this.dtblInventory.Rows.Count == 0) return;
            DataRow drowNew = this.dtblInventory.NewRow();
            drowNew["PrdID"] = -1;
            drowNew["PrdCode"] = "合计";
            foreach (DataRow drow in this.dtblBranchSotre.Rows)
            {
                drowNew[drow["BranchStoreID"].ToString()] = this.dtblInventory.Compute("SUM([" + drow["BranchStoreID"].ToString() + "])", "");
            }
            drowNew["-1"] = this.dtblInventory.Compute("SUM([-1])", "");
            this.dtblInventory.Rows.Add(drowNew);
           

            
        }

        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadInventory();
        }

        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].GetType().Equals(typeof(DataGridViewLinkColumn)))
            {
                int PrdID = (int)this.dtblInventory.DefaultView[irow]["PrdID"];
                int BranchStoreID=int.Parse (this.dgrdv .Columns [icol].DataPropertyName );
                if (this.frmRecord == null)
                {
                    this.frmRecord = new FrmInventoryRecord();
                    new FrmStyle(frmRecord).SetPopFrmStyle(this);
                }
                this.frmRecord.StoreRecord(PrdID,
                    BranchStoreID,
                     DateTime.Now);
                this.frmRecord.ShowDialog();
            }
        }
        void btnExplore_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "产品库存表");         
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(this.dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            FrmMsg.Hide();
            excel.Show();
        }
    }
}