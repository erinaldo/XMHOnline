using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Product.Report
{
    public partial class CtrlIntoStoreBranchStoreDayRpt : UserControl 
    {
        public CtrlIntoStoreBranchStoreDayRpt()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accIntoStoreItems = new JERPData.Product.IntoStoreItems();
            this.CreateGridColumn();
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.dgrdv.ContextMenuStrip = this.cMenu;
            this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
            this.btnExport.Click += new EventHandler(btnExport_Click); 
        }

        private JERPData.Product.IntoStoreItems accIntoStoreItems;
        private DataTable dtblRpt; 
        private int  Year,Month,BranchStoreID;
        private void CreateGridColumn()
        { 
            DataGridViewTextBoxColumn txtcolumn;
            for (int j = 1; j < 32; j++)
            {
                txtcolumn = new DataGridViewTextBoxColumn();
                txtcolumn.DataPropertyName = j.ToString();
                txtcolumn.HeaderText = j.ToString ();
                txtcolumn.Width =54;
                this.dgrdv.Columns.Add(txtcolumn);
            }
            txtcolumn = new DataGridViewTextBoxColumn();
            txtcolumn.DataPropertyName = "Total";
            txtcolumn.HeaderText = "合计";
            txtcolumn.Width = 60;
            this.dgrdv.Columns.Add(txtcolumn);
        }
        public  void LoadData(int Year,int Month,int BranchStoreID)
        {
            this.Year =Year ;
            this.Month =Month ;
            this.BranchStoreID =BranchStoreID ;
            this.LoadData ();
        }
        private void LoadData()
        {
            string totalexp = "";
            for (int j = 1; j < 32; j++)
            {
                totalexp += "+ISNULL([" + j.ToString() + "],0)";
            }
          
            this.dtblRpt = this.accIntoStoreItems.GetDataIntoStoreItemsBranchStorePivotDay  (this.Year, this.Month ,this.BranchStoreID ).Tables[0];
            this.dtblRpt.Columns.Add("Total", typeof(decimal), totalexp);
            if (this.dtblRpt.Rows.Count > 0)
            {
                DataRow drowNew = this.dtblRpt.NewRow();
                drowNew["Model"] = "合计";
                for (int j = 1; j < 32; j++)
                {
                    drowNew[j.ToString()] = this.dtblRpt.Compute("SUM([" + j.ToString() + "])", "");
                }
                this.dtblRpt.Rows.Add(drowNew);
            }
            this.dgrdv.DataSource = this.dtblRpt;
        }

        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }

        void btnExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "生产入库日报");         
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(this.dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            FrmMsg.Hide();
            excel.Show();
        }
    }
}