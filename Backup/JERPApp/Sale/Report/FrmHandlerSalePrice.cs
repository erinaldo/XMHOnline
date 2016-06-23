using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Sale.Report
{
    public partial class FrmHandlerSalePrice : Form
    {
        public FrmHandlerSalePrice()
        {
            InitializeComponent();
            this.gridhelper = new JCommon.DataGridViewHelper();
            this.accPrice = new JERPData.Product.SalePriceItems();
            this.dtpDateFrom.Value = new DateTime(DateTime.Now.Year, 1, 1);           
            this.SetPermit();
        }
        private JCommon.DataGridViewHelper gridhelper;
        private JERPData.Product.SalePriceItems accPrice;
        private JERPApp.Define.Product.FrmMySalePriceElement frmElement;
        private bool enableBrowse = false;
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(397);
            if (this.enableBrowse)
            {
                new ToolTip().SetToolTip(this.btnElement, "加载价格元素");
                this.btnElement.Click += new EventHandler(btnElement_Click);
                this.dgrdv.CellPainting += new DataGridViewCellPaintingEventHandler(dgrdv_CellPainting);
                this.btnSearch.Click += new EventHandler(btnSearch_Click);
               
            }
          
        }

        void btnElement_Click(object sender, EventArgs e)
        {
            if (frmElement == null)
            {
                frmElement = new JERPApp.Define.Product.FrmMySalePriceElement();
                new FrmStyle(frmElement).SetPopFrmStyle(this);
                frmElement.AffterSelected += frmElement_AffterSelected;
            }
            frmElement.ShowDialog();
        }

        void frmElement_AffterSelected(DataRow drow)
        {
            this.ctrlCustomerID .CompanyID = (int)drow["CompanyID"];
            this.ctrlMoneyTypeID.MoneyTypeID = (int)drow["MoneyTypeID"];
            this.ctrlSettleTypeID.SettleTypeID = (int)drow["SettleTypeID"];
            this.ctrlPriceTypeID.PriceTypeID = (int)drow["PriceTypeID"];

        }

        void btnSearch_Click(object sender, EventArgs e)
        {            
            this.LoadData();
        }
      

        private DataTable dtblPrices;    
        void LoadData()
        {  
              this.dtblPrices = this.accPrice.GetDataSalePriceItemsPivotDateNote (this.ctrlCustomerID  .CompanyID  ,
              this.ctrlMoneyTypeID  .MoneyTypeID, this.ctrlSettleTypeID  .SettleTypeID, this.ctrlPriceTypeID .PriceTypeID,this.dtpDateFrom .Value .Date ).Tables[0];              
                for (int i = 8; i < this.dgrdv.Columns.Count; i++)
                {
                    this.dgrdv.Columns.RemoveAt(i);
                    i--;

                }
          
            this.dgrdv.DataSource = this.dtblPrices;
            for (int i = 8; i < this.dgrdv.Columns.Count; i++)
            {
                this.dgrdv.Columns[i].Width = 70;

            }
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.ctrlNextSpot.SeachGridView = this.dgrdv;
        }
     

        void dgrdv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if (irow > -1) return;
            if ((icol == 6) || (icol == 7))
            {
                gridhelper.MerageColumnHeaderSpan(this.dgrdv, e, 6, 7, "最新单价");
            }
        }
    
      
        private void btnPrint_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder  + @"GeneralShowSheet.xlt");
            excel.SetCellVal("C1", "产品销售单价");
            excel.SetCellVal("A2", "客户:" + this.ctrlCustomerID .CompanyAbbName);
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