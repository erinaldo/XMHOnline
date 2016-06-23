using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Sale.Report
{
    public partial class FrmCustomerRegisterRpt : Form
    {
        public FrmCustomerRegisterRpt()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.ctrlYear.Year = DateTime.Now.Year;
            this.accCustomers = new JERPData.General.Customer();
            this.SetPermit();
        }
        private JERPData.General.Customer accCustomers;
        private DataTable dtblRpt;
        //权限码
        private bool enableBrowse = false;//浏览
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(583);
            if (this.enableBrowse)
            {
                this.ctrlYear.OnSelected += this.LoadData;   
                this.LoadData();
                this.btnExport .Click += btnExport_Click;
            }
        }
        private void LoadData()
        {
            this.dtblRpt = this.accCustomers.GetDataCustomerSalerRegisterPivotMonth(this.ctrlYear.Year).Tables[0];
            string exp = string.Empty;
            if (this.dtblRpt.Rows.Count > 0)
            {
                DataRow drowNew = this.dtblRpt.NewRow();               
                drowNew["PsnCode"] = "合计";
                for (int j = 1; j < 13; j++)
                {
                    drowNew[j.ToString()] = this.dtblRpt.Compute("SUM([" + j.ToString() + "])", "");
                    exp += "+ISNULL([" + j.ToString() + "],0)";
                }
                this.dtblRpt.Rows.Add(drowNew);
            }
            this.dtblRpt.Columns.Add("Total", typeof(int),exp); 
            this.dgrdv.DataSource = this.dtblRpt;
        }
        void btnExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成Excel文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "客户注册一览");
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