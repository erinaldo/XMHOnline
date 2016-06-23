using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Material.Report
{
    public partial class FrmOutSrcSupplyItemRecord : Form
    {
        public FrmOutSrcSupplyItemRecord()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accItems = new JERPData.Material.OutSrcSupplyItems();
            this.btnExplore.Click += new EventHandler(btnExplore_Click);
        }

        private JERPData.Material.OutSrcSupplyItems accItems;
        private DataTable dtlbItems;
        public void SupplyRecord(int CompanyID, int PrdID,DateTime DateBegin,DateTime DateEnd)
        {
            this.dtlbItems = this.accItems.GetDataOutSrcSupplyItemsPrdRecord(CompanyID, PrdID,
                DateBegin, DateEnd).Tables[0];
            this.dgrdv.DataSource = this.dtlbItems;

        }

        void btnExplore_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "委外发料记录");  
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            FrmMsg.Hide();
            excel.Show();
        }
    }
}