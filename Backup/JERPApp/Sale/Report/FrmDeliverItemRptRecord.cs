using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Sale.Report
{
    public partial class FrmDeliverItemRptRecord : Form
    {
        public FrmDeliverItemRptRecord()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accDeliverItems = new JERPData.Product.SaleDeliverItems();
           
        }
        private JERPData.Product.SaleDeliverItems accDeliverItems;
        private DataTable dtblRecords;    
        public  void CompanyRptRecord(int Year,int Month,int CompanyID)
        {
            this.dtblRecords = this.accDeliverItems.GetDataSaleDeliverItemsMonthRecordByCompany (Year,
                Month,CompanyID ).Tables[0];
            this.dgrdv.DataSource = this.dtblRecords;
        }
     
        void btnExplore_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "送货记录");          
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            FrmMsg.Hide();
            excel.Show();
        }
    }
}