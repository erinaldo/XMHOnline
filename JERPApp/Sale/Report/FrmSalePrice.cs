using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Sale.Report
{
    public partial class FrmSalePrice : Form
    {
        public FrmSalePrice()
        {
            InitializeComponent(); 
            this.accPrice = new JERPData.Product.SalePriceItems();          
            this.SetPermit();

        } 
        private JERPData.Product.SalePriceItems accPrice; 
        private bool enableBrowse = false;
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(251);
            if (this.enableBrowse)
            {  
                this.btnSearch.Click += new EventHandler(btnSearch_Click);               
            }
          
        }
        
 
     
        void btnSearch_Click(object sender, EventArgs e)
        {            
            this.LoadData();
        }
      

        private DataTable dtblPrices;    
        void LoadData()
        {  
            this.dtblPrices = this.accPrice.GetDataSalePriceItemsPivotCustomer (
            this.ctrlMoneyTypeID  .MoneyTypeID, this.ctrlSettleTypeID  .SettleTypeID, this.ctrlPriceTypeID .PriceTypeID ).Tables[0];
            while (this.dgrdv.ColumnCount > 5)
            {
                this.dgrdv.Columns.RemoveAt(5);
            }          
            this.dgrdv.DataSource = this.dtblPrices;
            for (int i = 5; i < this.dgrdv.Columns.Count; i++)
            {
                this.dgrdv.Columns[i].Width = 70;

            }
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.ctrlNextSpot.SeachGridView = this.dgrdv;
        }
     
 
    
      
        private void btnPrint_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder  + @"GeneralShowSheet.xlt");
            excel.SetCellVal("C1", "产品加工单价"); 
            excel.SetCellVal("A3", "币种:" + this.ctrlMoneyTypeID.MoneyTypeName 
              + "   结算方式:" + this.ctrlSettleTypeID.SettleTypeName  
                 + "   单价类型:" + this.ctrlPriceTypeID .PriceTypeName );
            int rowIndex = 6;
            int colIndex = 1;
            excel.ImportGridData(this.dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(6, 1, rowIndex, colIndex);          
            excel.Show();
            FrmMsg.Hide();
        }
    }
}