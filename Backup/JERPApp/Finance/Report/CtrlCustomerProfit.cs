using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Report
{
    public partial class CtrlCustomerProfit : UserControl
    {
        public CtrlCustomerProfit()
        {
            InitializeComponent();
            this.accItems = new JERPData.Product.SaleDeliverItems();
            this.dgrdv.AutoGenerateColumns = false;
            this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
            this.btnExport.Click += new EventHandler(btnExport_Click);
            this.Init();
        }

        JERPData.Product.SaleDeliverItems accItems;
        FrmSaleProfitDetail frmDetail;
        private DataTable dtblReports;
        private int Year = DateTime.Now.Year;
        private string totalexp = string.Empty;
        private void Init()
        {
            DataGridViewLinkColumn lnk;
            for (int j = 1; j < 13; j++)
            {
                totalexp += "+ISNULL([" + j.ToString() + "],0)";
                lnk = new DataGridViewLinkColumn();
                lnk.DataPropertyName = j.ToString();
                lnk.Tag = j;
                lnk.HeaderText  = j.ToString() + "月";
                lnk.Width = 66;
                this.dgrdv.Columns.Add(lnk);
            }
            lnk = new DataGridViewLinkColumn();
            lnk.DataPropertyName ="Total";
            lnk.Tag = -1;
            lnk.HeaderText = "合计";
            lnk.Width = 66;
            this.dgrdv.Columns.Add(lnk);
            this.ctrlQFind.SeachGridView = this.dgrdv;  
        }
        public void Report(int Year)
        {
            this.Year = Year;
            this.dtblReports = this.accItems.GetDataSaleDeliverItemsCustomerProfitPivotMonth(Year).Tables[0];
            this.dtblReports.Columns.Add("Total", typeof(decimal), totalexp);
            DataRow drowNew = this.dtblReports.NewRow();
            drowNew["CompanyID"] = -1;
            for (int j = 1; j < 13; j++)
            {
                drowNew[j.ToString()] = this.dtblReports.Compute("SUM([" + j.ToString() + "])", "");              
            }
           
            this.dtblReports.Rows.Add(drowNew);
            this.dgrdv.DataSource = this.dtblReports;
        }
        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].GetType().Equals(typeof(DataGridViewLinkColumn)))
            {
                int Month=(int)this.dgrdv.Columns [icol].Tag;
                DataRow drow = this.dtblReports.DefaultView[irow].Row;
                int CompanyID = (int)drow["CompanyID"];
                string whereclause = " and (Year(DateNote)="+this.Year .ToString ()+")";
                string whereinfor = "年份["+this.Year .ToString ()+"]";
                if (Month > -1)
                {
                    whereclause += " and (Month(DateNote)=" + Month.ToString() + ")";
                    whereinfor += ",月份[" + Month.ToString() + "]";
                }
                if (CompanyID> -1)
                {
                    whereclause += " and (CompanyID=" + CompanyID.ToString() + ")";
                    whereinfor += ",客户[" + drow["CompanyAbbName"].ToString() + "]";
                }
               
                whereinfor += "送货记录";
                if (frmDetail == null)
                {
                    frmDetail = new FrmSaleProfitDetail();
                    new FrmStyle(frmDetail).SetPopFrmStyle(this.ParentForm);
                }
                frmDetail.Record(whereclause, whereinfor);
                frmDetail.ShowDialog();
            }

        }
        void btnExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", this.Year.ToString() + "年客户毛利表");
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
