using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Report
{
    public partial class FrmSaleProfitDetail : Form
    {
        public FrmSaleProfitDetail()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accItems = new JERPData.Product .SaleDeliverItems();
            this.btnExport.Click += new EventHandler(btnExport_Click);
        }

        private JERPData.Product.SaleDeliverItems accItems;
        private DataTable dtblItems;

        public void Record(string whereclause,string whereinfor)
        {
            this.Text = whereinfor;
            this.dtblItems = this.accItems.GetDataSaleDeliverItemsByFreeSearch  (whereclause).Tables[0];
            if (this.dtblItems.Rows.Count > 0)
            {
                DataRow drowNew = this.dtblItems.NewRow();
                drowNew["NoteCode"] = "合计";
                drowNew["ItemMainAMT"] = this.dtblItems.Compute("SUM(ItemMainAMT)", "");
                drowNew["CostAMT"] = this.dtblItems.Compute("SUM(CostAMT)", "");
                drowNew["ProfitAMT"] = this.dtblItems.Compute("SUM(ProfitAMT)", "");
                this.dtblItems.Rows.Add(drowNew);
            }
            this.dgrdv.DataSource = this.dtblItems;
          
        }

        void btnExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", this.Text);
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(this.dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            excel.SetRangeAutoFit(3, 1, rowIndex, rowIndex, true, false);
            excel.Show();
            FrmMsg.Hide();
        }
    }
}