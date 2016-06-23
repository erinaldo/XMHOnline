using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Supply.Product.Report
{
    public partial class FrmPrdNonFinished : Form
    {
        public FrmPrdNonFinished()
        {
            InitializeComponent();
            this.accOrderItems = new JERPData.Product.BuyOrderItems();
            this.SetPermit();
        }

        private JERPData.Product.BuyOrderItems accOrderItems;
        private DataTable dtblItems;

        //权限码
        private bool enableBrowse = false;//浏览
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(92);
            if (this.enableBrowse)
            {
                this.LoadData();
                this.dgrdv.ContextMenuStrip = this.cMenu; ;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                this.btnExplore.Click += new EventHandler(btnExplore_Click);
            }
        }

        private void LoadData()
        {
            this.dtblItems = this.accOrderItems.GetDataBuyOrderItemsPrdNonFinishedQtyPivotCompany ().Tables[0];
            while (this.dgrdv.ColumnCount > 9)
            {
                this.dgrdv.Columns.RemoveAt(9);
            }
            this.dgrdv.DataSource = this.dtblItems;
            this.ctrlGridQFind.SeachGridView = this.dgrdv;
            this.ctrlSpot.SeachGridView = this.dgrdv;
        }

        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
        void btnExplore_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "产品采购欠数一览");           
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            excel.SetRangeAutoFit(3, 1, rowIndex, colIndex, true, true);
            FrmMsg.Hide();
            excel.Show();
        }
    }
}