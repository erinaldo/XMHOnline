using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Supply.Product.Report
{
    public partial class FrmOrderMonthRpt : Form
    {
        public FrmOrderMonthRpt()
        {
            InitializeComponent();
            this.dgrdvQty.AutoGenerateColumns = false;
            this.dgrdvAMT.AutoGenerateColumns = false;
            this.accOrderItems = new JERPData.Product.BuyOrderItems ();
            this.SetPermit();
        }
        private JERPData.Product.BuyOrderItems accOrderItems;
        private DataTable dtblRptQty, dtblRptAMT;
        //权限码
        private bool enableBrowse = false;//浏览
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(90);
            if (this.enableBrowse)
            {
                this.tabMain.SelectedIndexChanged += new EventHandler(tabMain_SelectedIndexChanged); 
                this.ctrlYear.Year = DateTime.Now.Year;
                //加载数据               
                this.ctrlYear.OnSelected += this.LoadData;
                this.LoadData();
                this.btnExplore.Click += new EventHandler(btnExplore_Click);
                this.ctrlQFind.SeachGridView = this.dgrdvQty;
                this.ctrlSpot.SeachGridView = this.dgrdvQty;             
            }
        }

        void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataGridView dgrdv = this.tabMain.SelectedTab.Controls[0] as DataGridView;
            this.ctrlQFind.SeachGridView = dgrdv;
            this.ctrlSpot.SeachGridView = dgrdv;
        }
        private void LoadData()
        {
            string exp=string .Empty ;
            for(int m=1;m<13;m++)
            {
                exp +="+ISNULL(["+m.ToString ()+"],0)";
            }
            this.dtblRptQty = this.accOrderItems.GetDataBuyOrderItemsQuantityPivotMonth(this.ctrlYear.Year).Tables[0];
            this.dtblRptQty.Columns.Add("Total", typeof(decimal), exp);
            this.dgrdvQty.DataSource = this.dtblRptQty;
            this.dtblRptAMT = this.accOrderItems.GetDataBuyOrderItemsAmountPivotMonth(this.ctrlYear.Year).Tables[0];
            this.dtblRptAMT.Columns.Add("Total", typeof(decimal), exp);
            this.dgrdvAMT.DataSource = this.dtblRptAMT;
        }
        void btnExplore_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "采购订单月报表");
            TabPage page = this.tabMain.SelectedTab;
            DataGridView dgrdv = page.Controls[0] as DataGridView;
            excel.SetCellVal("A2", "年份:" + this.ctrlYear.Year.ToString() + " " + page.Text);
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