using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Common
{
    public partial class FrmMessageRecord : Form
    {
        public FrmMessageRecord()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accMsg = new JERPData.General.Message();
            int Year = DateTime.Now.Year;
            int Month = DateTime.Now.Month;
            int Day = DateTime.Now.Day;
            this.dtpDateBegin.Value = new DateTime(Year, Month, Day).AddDays(-1);
            this.dtpDateEnd.Value = new DateTime(Year, Month, Day, 23, 59, 59);
            this.btnSearch.Click += new EventHandler(btnSearch_Click);
            this.btnExport.Click += new EventHandler(btnExport_Click);
        }

       
        private JERPData.General.Message accMsg;
        private DataTable dtblRecords;
        void btnSearch_Click(object sender, EventArgs e)
        {
            string whereclause = string.Empty;
            int PsnID = JERPBiz.Frame.UserBiz.PsnID;
            if (this.ckbDateMsg.Checked)
            {
                whereclause += " and (DateMsg>='" + this.dtpDateBegin.Value.ToString() + "' and DateMsg<='" + this.dtpDateEnd.Value.ToString() + "')";
            }
            if (this.ckbFromPsn.Checked)
            {
                whereclause += " and (FromPsnID=" + this.ctrlFromPsnID.PsnID.ToString() + ")";
            }
            if (this.ckbToPsn.Checked)
            {
                whereclause += " and (ToPsnID=" + this.ctrlToPsnID.PsnID.ToString() + ")";
            }
            if (this.ckbReceiveFlag.Checked)
            {
                whereclause += " and (ReceiveFlag=0)";
                if (this.radReceiveFlag.Checked)
                {
                    whereclause += " and (ReceiveFlag=1)";
                }
            }
            this.dtblRecords = this.accMsg.GetDataMessageRecord(PsnID, whereclause).Tables[0];
            this.dgrdv.DataSource = this.dtblRecords;
        }
        void btnExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成Excel文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "我的信息记录");
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(this.dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            FrmMsg.Hide();
            excel.Show();
        }
    }
}