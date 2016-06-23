using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Report
{
    public partial class FrmRevenueAccountRecord : Form
    {
        public FrmRevenueAccountRecord()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accExpressAccount = new JERPData.Finance.RevenueAccount();
            this.btnExport .Click +=new EventHandler(btnExport_Click);
        }
        JERPData.Finance.RevenueAccount accExpressAccount;
        private DataTable dtblRecord;
        public void AccountRecord(int RevenueTypeID,int Year, int Month)
        {
            this.dtblRecord = this.accExpressAccount.GetDataRevenueAccountMonthRecord(RevenueTypeID,
                Year, Month).Tables[0];
            if (this.dtblRecord.Rows.Count > 0)
            {
                DataRow drowNew = this.dtblRecord.NewRow();
                drowNew["Summary"] = "合计";
                drowNew["DebitAMT"] = this.dtblRecord.Compute("SUM(DebitAMT)", "");
                drowNew["CreditAMT"] = this.dtblRecord.Compute("SUM(CreditAMT)", "");
                this.dtblRecord.Rows.Add(drowNew);
            }
            this.dgrdv.DataSource = this.dtblRecord;
        }
        void btnExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成Excel文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", this.Text);
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