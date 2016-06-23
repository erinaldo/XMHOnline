using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Product.Report
{
    public partial class FrmInventoryMonthRpt : Form
    {
        public FrmInventoryMonthRpt()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.ctrlYear.Year = DateTime.Now.Year;
            this.ctrlMonth.Month = DateTime.Now.Month;
            this.accStore = new JERPData.Product.Store();
            this.grdhelper = new JCommon.DataGridViewHelper();
            this.SetPermit();
        }
        private JERPData.Product.Store accStore;
        private JCommon.DataGridViewHelper grdhelper;
        private DataTable dtblReport;
        //权限码
        private bool enableBrowse = false;//浏览
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(58);
            if (this.enableBrowse)
            {
                this.dgrdv.CellPainting += new DataGridViewCellPaintingEventHandler(dgrdv_CellPainting);
                //加载数据
                LoadData();
                this.ctrlYear.OnSelected += this.LoadData;
                this.ctrlMonth.OnSelected += this.LoadData;
                this.btnExplore.Click += new EventHandler(btnExplore_Click);
            }


        }
        public void InventoryMonthRpt(int Year, int Month)
        {
            this.ctrlYear.Year = Year;
            this.ctrlMonth.Month = Month;
            this.LoadData();
        }
        void dgrdv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if (irow == -1)
            {
                if ((icol == 5) || (icol == 6))
                {
                    this.grdhelper.MerageColumnHeaderSpan(this.dgrdv, e, 5, 6, "上月结存");
                }
                if ((icol == 7) || (icol == 8))
                {
                    this.grdhelper.MerageColumnHeaderSpan(this.dgrdv, e, 7, 8, "入  库");
                }
                if ((icol == 9)||(icol == 10))
                {
                    this.grdhelper.MerageColumnHeaderSpan(this.dgrdv, e, 9, 10, "出  库");
                }
                if ((icol == 11) || (icol == 12))
                {
                    this.grdhelper.MerageColumnHeaderSpan(this.dgrdv, e, 11, 12, "本月结存");
                }
            }
        }
        private void LoadData()
        {
            this.dtblReport = this.accStore.GetDataStoreMonthRpt(this.ctrlYear.Year, this.ctrlMonth.Month).Tables[0];
            this.dgrdv.DataSource = this.dtblReport;
            if (this.dtblReport.Rows.Count > 0)
            {
                DataRow drowNew = this.dtblReport.NewRow();
                drowNew["PrdCode"] = "合计";
                drowNew["LastInventoryQty"] = this.dtblReport.Compute("SUM(LastInventoryQty)", "");
                drowNew["LastInventoryAMT"] = this.dtblReport.Compute("SUM(LastInventoryAMT)", "");
                drowNew["IntoQty"] = this.dtblReport.Compute("SUM(IntoQty)", "");
                drowNew["IntoAMT"] = this.dtblReport.Compute("SUM(IntoAMT)", "");
                drowNew["OutQty"] = this.dtblReport.Compute("SUM(OutQty)", "");
                drowNew["OutAMT"] = this.dtblReport.Compute("SUM(OutAMT)", "");
                drowNew["InventoryQty"] = this.dtblReport.Compute("SUM(InventoryQty)", "");
                drowNew["InventoryAMT"] = this.dtblReport.Compute("SUM(InventoryAMT)", "");
                this.dtblReport.Rows.Add(drowNew);
            }
        }
        void btnExplore_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "产品库存月报表");
            excel.SetCellVal("A2", this.ctrlYear .Year .ToString ()+"年"+this.ctrlMonth .Month +"月");
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            FrmMsg.Hide();
            excel.Show();
        }
    }
}