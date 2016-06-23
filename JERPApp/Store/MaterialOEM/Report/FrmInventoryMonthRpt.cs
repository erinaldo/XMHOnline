using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.MaterialOEM.Report
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
            this.accStore = new JERPData.Material.OEMStore();
            this.SetPermit();
        }
        private JERPData.Material.OEMStore accStore;
        private DataTable dtblReport;
        //权限码
        private bool enableBrowse = false;//浏览
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(448);
            if (this.enableBrowse)
            {
            
                //加载数据
                LoadData();
                this.ctrlYear.OnSelected += this.LoadData;
                this.ctrlMonth.OnSelected += this.LoadData;
                this.ctrlCompanyID.AffterSelected += this.LoadData;
                this.btnExplore.Click += new EventHandler(btnExplore_Click);
            }


        }
        public void InventoryMonthRpt(int CompanyID,int Year, int Month)
        {
            this.ctrlYear.Year = Year;
            this.ctrlMonth.Month = Month;
            this.ctrlCompanyID.CompanyID = CompanyID;
            this.LoadData();
        }
    
        private void LoadData()
        {
            this.dtblReport = this.accStore.GetDataOEMStoreMonthRpt(this.ctrlYear.Year, this.ctrlMonth.Month,this.ctrlCompanyID .CompanyID ).Tables[0];
            this.dgrdv.DataSource = this.dtblReport;
           
        }
        void btnExplore_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "客供物料库存月报表");
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