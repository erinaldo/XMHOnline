using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.MaterialOEM.Report
{
    public partial class FrmInventory : Form
    {
        public FrmInventory()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accStore = new JERPData.Material.OEMStore(); 
            this.SetPermit();
        }
        private JERPData.Material.OEMStore accStore;  
        private DataTable dtblInventory, dtblCustomer;
        private FrmInventoryRecord frmRecord; 
        //权限码
        private bool enableBrowse = false;//浏览 
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(447); 
            if (this.enableBrowse)
            {
                this.dtblCustomer = this.accStore.GetDataOEMStoreCustomer  ().Tables[0];
                this.CreateGridColumn();
                //加载数据
                this.LoadInventory();
                this.LoadCustomerInventory();
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
        private void LoadCustomerInventory()
        {
            TabPage page;
            CtrlCustomerInventory ctrlCustomerInventory;
            int CompanyID = -1;
            string CompanyAbbName;
            foreach (DataRow drow in this.dtblCustomer.Rows)
            {
                CompanyID = (int)drow["CompanyID"];
                CompanyAbbName = drow["CompanyAbbName"].ToString();
                page = new TabPage();
                page.Text = CompanyAbbName;
                ctrlCustomerInventory = new CtrlCustomerInventory();
                ctrlCustomerInventory.CustomerInventory(CompanyID, CompanyAbbName);
                ctrlCustomerInventory.AffterSelect += new CtrlCustomerInventory.AffterSelectDelegate(ctrlCustomerInventory_AffterSelect);
                page.Controls.Add(ctrlCustomerInventory);
                ctrlCustomerInventory.Dock = DockStyle.Fill;
                this.tabMain.TabPages .Add (page);
            }
            this.ctrlTabNav.NavTabControl = this.tabMain;
        }

        void ctrlCustomerInventory_AffterSelect(int CompanyID, int PrdID)
        {
            
            if (this.frmRecord == null)
            {
                this.frmRecord = new FrmInventoryRecord();
                new FrmStyle(frmRecord).SetPopFrmStyle(this);
            }
            this.frmRecord.StoreRecord(PrdID,
                CompanyID,
                 DateTime.Now);
            this.frmRecord.ShowDialog();
        }
        private void CreateGridColumn()
        {
            
            DataGridViewLinkColumn  lnk;
            foreach (DataRow drow in this.dtblCustomer.Rows)
            {
                lnk = new DataGridViewLinkColumn();
                lnk.DataPropertyName = drow["CompanyID"].ToString();
                lnk.HeaderText = drow["CompanyAbbName"].ToString();
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
            this.dtblInventory = this.accStore.GetDataOEMStorePivotCompanyID ().Tables[0];
            this.dgrdv.DataSource = this.dtblInventory;
            if (this.dtblInventory.Rows.Count == 0) return;
            DataRow drowNew = this.dtblInventory.NewRow();
            drowNew["PrdID"] = -1;
            drowNew["PrdCode"] = "合计";
            foreach (DataRow drow in this.dtblCustomer.Rows)
            {
                drowNew[drow["CompanyID"].ToString()] = this.dtblInventory.Compute("SUM([" + drow["CompanyID"].ToString() + "])", "");
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
            excel.SetCellVal("D1", "客供原料库存表");         
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(this.dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            FrmMsg.Hide();
            excel.Show();
        }
    }
}