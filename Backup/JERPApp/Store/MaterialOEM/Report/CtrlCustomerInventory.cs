using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.MaterialOEM.Report
{
    public partial class CtrlCustomerInventory : UserControl
    {
        public CtrlCustomerInventory()
        {
            InitializeComponent();

            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accStore = new JERPData.Material.OEMStore();
            this.ctrlQFind.BeforeFilter += this.LoadData;
            this.dgrdv.ContextMenuStrip = this.cMenu;
            this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
            this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
            this.btnExplore.Click += new EventHandler(btnExplore_Click);
 
        }
        private JERPData.Material.OEMStore accStore;
        private DataTable dtblInventory;
        private int CompanyID = -1;
        private string CompanyAbbName = string.Empty;
        public void CustomerInventory(int CompanyID, string CompanyAbbName)
        {
            this.CompanyID = CompanyID;
            this.CompanyAbbName = CompanyAbbName;
            this.LoadData();
        }
        private void LoadData()
        {
            this.dtblInventory = this.accStore.GetDataOEMStoreInventoryByCompanyID  (this.CompanyID).Tables[0];
            this.dgrdv.DataSource = this.dtblInventory;
            if (this.dtblInventory.Rows.Count == 0) return;
            DataRow drowNew = this.dtblInventory.NewRow();
            drowNew["PrdID"] = -1;
            drowNew["PrdCode"] = "合计"; 
            drowNew["InventoryQty"] = this.dtblInventory.Compute("SUM(InventoryQty)", ""); 
            this.dtblInventory.Rows.Add(drowNew);

        }
        public delegate void AffterSelectDelegate(int CompanyID, int PrdID);
        private AffterSelectDelegate affterSelect;
        public event AffterSelectDelegate AffterSelect
        {
            add
            {
                affterSelect += value;
            }
            remove
            {
                affterSelect -= value;
            }
        }
        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }

        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].GetType().Equals(typeof(DataGridViewLinkColumn)))
            {
                int PrdID = (int)this.dtblInventory.DefaultView[irow]["PrdID"];
                if (this.affterSelect != null) this.affterSelect(this.CompanyID, PrdID);
                
            }
        }
        void btnExplore_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "客供库存表");
            excel.SetCellVal("A1", "客户:"+this.CompanyAbbName);
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(this.dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            FrmMsg.Hide();
            excel.Show();
        }
    }
}
