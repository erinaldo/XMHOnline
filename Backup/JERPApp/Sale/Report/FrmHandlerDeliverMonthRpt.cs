using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Sale.Report
{
    public partial class FrmHandlerDeliverMonthRpt : Form
    {
        public FrmHandlerDeliverMonthRpt()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accDeliverItems = new JERPData.Product.SaleDeliverItems();
            this.SetPermit();
        }
        private JERPData.Product.SaleDeliverItems accDeliverItems;
        private FrmDeliverItemRptRecord frmRecord;
        private DataTable dtblItems;
        //权限码
        private bool enableBrowse = false;//浏览
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(396);
            if (this.enableBrowse)
            {
                this.ctrlQFind.SeachGridView = this.dgrdv;
                this.ctrlSpot.SeachGridView = this.dgrdv;
                this.ctrlYear.Year = DateTime.Now.Year;
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
                //加载数据               
                this.ctrlYear.OnSelected += this.LoadData;
                this.LoadData();
                this.btnExplore.Click += new EventHandler(btnExplore_Click);                
            }
        }

        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            int CompanyID = (int)this.dtblItems .DefaultView[irow]["CompanyID"];
            if (this.dgrdv .Columns[icol].GetType().Equals(typeof(DataGridViewLinkColumn)))
            {
                int Month = int.Parse(this.dgrdv.Columns[icol].DataPropertyName);
                if (frmRecord == null)
                {
                    frmRecord = new FrmDeliverItemRptRecord();
                    new FrmStyle(frmRecord).SetPopFrmStyle(this);
                }
                frmRecord.CompanyRptRecord(this.ctrlYear.Year, Month, CompanyID);
                frmRecord.ShowDialog();
            }
        }

        private void LoadData()
        {
            this.dtblItems = this.accDeliverItems.GetDataSaleDeliverItemsCompanyMonthRptByHandlePsnID  (this.ctrlYear.Year,
                JERPBiz .Frame .UserBiz .PsnID ).Tables[0];
            DataRow[] drows = this.dtblItems.Select("TypeCode='B'");
            foreach (DataRow drow in drows)
            {
                drow["CompanyCode"] = DBNull.Value;
                drow["CompanyAbbName"] = DBNull.Value;
            }
            this.dgrdv.DataSource = this.dtblItems;
            DataRow drowNewArea;
            DataRow drowNewAMT;
            if (dtblItems.Rows.Count > 0)
            {
                drowNewArea = this.dtblItems.NewRow();
                drowNewArea["CompanyID"] = -1;
                drowNewArea["CompanyCode"] = "合计";
                drowNewArea["TypeName"] = "数量";
                drowNewAMT = this.dtblItems.NewRow();
                drowNewAMT["CompanyID"] = -1;
                drowNewAMT["TypeName"] = "金额";
                for (int m = 1; m < 13; m++)
                {
                    drowNewArea[m.ToString()] = this.dtblItems.Compute("SUM([" + m.ToString() + "])", "TypeCode='A'");
                    drowNewAMT[m.ToString()] = this.dtblItems.Compute("SUM([" + m.ToString() + "])", "TypeCode='B'");
                }
                drowNewArea["Total"] = this.dtblItems.Compute("SUM(Total)", "TypeCode='A'");
                drowNewAMT["Total"] = this.dtblItems.Compute("SUM(Total)", "TypeCode='B'");
                this.dtblItems.Rows.Add(drowNewArea);
                this.dtblItems.Rows.Add(drowNewAMT);
            }
        }
        void btnExplore_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "月销售报表");
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