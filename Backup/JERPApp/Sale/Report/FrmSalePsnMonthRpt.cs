using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Sale.Report
{
    public partial class FrmSalePsnMonthRpt : Form
    {
        public FrmSalePsnMonthRpt()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accDeliverItems = new JERPData.Product.SaleDeliverItems();
            this.SetPermit();
        }
        private JERPData.Product.SaleDeliverItems accDeliverItems;
        private FrmSalePsnMonthDetail  frmRecord;
        private DataTable dtblItems;
        //权限码
        private bool enableBrowse = false;//浏览
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(128);
            if (this.enableBrowse)
            {
                this.ctrlQFind.SeachGridView = this.dgrdv;
                this.ctrlSpot.SeachGridView = this.dgrdv;
                this.ctrlYear.Year = DateTime.Now.Year;
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
                //加载数据               
                this.ctrlYear.OnSelected += this.LoadData;
                this.ctrlMoneyTypeID.AffterSelected += this.LoadData;
                this.LoadData();
                this.btnExplore.Click += new EventHandler(btnExplore_Click);                
            }
        }

        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;         
            if (this.dgrdv .Columns[icol].GetType().Equals(typeof(DataGridViewLinkColumn)))
            {
                int PsnID = (int)this.dtblItems.DefaultView[irow]["PsnID"];
                int Month = int.Parse(this.dgrdv.Columns[icol].DataPropertyName);
                string PsnInfor = this.dgrdv[this.ColumnPsnCode.Name, irow].Value.ToString() +
                    this.dgrdv[this.ColumnPsnName.Name, irow].Value.ToString();
                if (frmRecord == null)
                {
                    frmRecord = new FrmSalePsnMonthDetail();
                    new FrmStyle(frmRecord).SetPopFrmStyle(this);
                }
                frmRecord.ReportDetail (this.ctrlYear.Year, Month, PsnID,PsnInfor );
                frmRecord.ShowDialog();
            }
        }

        private void LoadData()
        {
            this.dtblItems = this.accDeliverItems.GetDataSaleDeliverItemsSalePsnAMTPivotMonth (this.ctrlYear.Year,
                this.ctrlMoneyTypeID .MoneyTypeID ).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
          
            DataRow drowNew;
            string exp = string.Empty;
            if (dtblItems.Rows.Count > 0)
            {
                drowNew = this.dtblItems.NewRow();
                drowNew["PsnID"] = -1;
                drowNew["PsnCode"] = "合计";
                for (int m = 1; m < 13; m++)
                {
                    drowNew[m.ToString()] = this.dtblItems.Compute("SUM([" + m.ToString() + "])","");
                    exp += "+ISNULL([" + m.ToString() + "],0)";
                }
                this.dtblItems.Rows.Add(drowNew);
            }
            this.dtblItems.Columns.Add("TotalAMT", typeof(decimal));
        }
        void btnExplore_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "业务员销售报表");
            excel.SetCellVal("A2", "年份:" + this.ctrlYear .Year .ToString ());
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            FrmMsg.Hide();
            excel.Show();
        }
    }
}