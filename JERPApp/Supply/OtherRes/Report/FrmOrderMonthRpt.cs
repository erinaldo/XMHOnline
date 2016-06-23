using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Supply.OtherRes.Report
{
    public partial class FrmOrderMonthRpt : Form
    {
        public FrmOrderMonthRpt()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;          
            this.accOrderItems = new JERPData.OtherRes.BuyOrderItems ();
            this.SetPermit();
        }
        private JERPData.OtherRes.BuyOrderItems accOrderItems;
        private DataTable dtblRpt;
        //权限码
        private bool enableBrowse = false;//浏览
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(498);
            if (this.enableBrowse)
            {
              
                this.ctrlYear.Year = DateTime.Now.Year;
                //加载数据               
                this.ctrlYear.OnSelected += this.LoadData;
                this.LoadData();
                this.btnExplore.Click += new EventHandler(btnExplore_Click);
                this.ctrlQFind.SeachGridView = this.dgrdv;
                this.ctrlSpot.SeachGridView = this.dgrdv ;             
            }
        }

        private void LoadData()
        {
            string exp=string .Empty ;
            for(int m=1;m<13;m++)
            {
                exp +="+ISNULL(["+m.ToString ()+"],0)";
            }
            this.dtblRpt = this.accOrderItems.GetDataBuyOrderItemsQuantityPivotMonth(this.ctrlYear.Year).Tables[0];
            this.dtblRpt.Columns.Add("Total", typeof(decimal), exp);
            this.dgrdv.DataSource = this.dtblRpt;
         
        }
        void btnExplore_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "采购订单月报表");          
            excel.SetCellVal("A2", "年份:" + this.ctrlYear.Year.ToString());
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(this.dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            excel.SetRangeAutoFit(3, 1, rowIndex, colIndex, true, true);
            FrmMsg.Hide();
            excel.Show();
        }
    }
}