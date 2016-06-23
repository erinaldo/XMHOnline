using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Sale.Report
{
    public partial class FrmHandlerSaleDeliverItemRecord : Form
    {
        public FrmHandlerSaleDeliverItemRecord()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accDeliverItems = new JERPData.Product.SaleDeliverItems();
            this.SetPermit();
        }
        private JERPData.Product.SaleDeliverItems accDeliverItems;
        private DataTable dtblRecords;
     
        //权限码
        private bool enableBrowse = false;//浏览
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(399);
            if (this.enableBrowse)
            {
                DateTime now_ = DateTime.Now;
                DateTime datebegin = new DateTime(now_.Year, now_.Month, 1);
                if (now_.Day < 15)
                {
                    datebegin = datebegin.AddMonths(-1);
                }
                this.dtpDateBegin.Value = datebegin;
                this.dtpDateEnd.Value = now_;
                this.btnSearch.Click += new EventHandler(btnSearch_Click);
                this.LoadData();
                this.btnExplore.Click += new EventHandler(btnExplore_Click);
            }
        }
        void btnSearch_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
        private void LoadData()
        {
            string whereclause =" and (HandlePsnID="+JERPBiz .Frame .UserBiz .PsnID .ToString ()+")" ;
            if (this.ckbDateNote.Checked)
            {
               whereclause +=" and (DateNote>='" + this.dtpDateBegin.Value.ToShortDateString() + "' and DateNote<='" + this.dtpDateEnd.Value.ToShortDateString() + "')";
            }
            if (this.ckbCustomer.Checked)
            {
                whereclause += " and (CompanyID=" + this.ctrlCustomerID .CompanyID.ToString() + ")";
            }
            if (this.ckbExpressCompanyName.Checked)
            {
                whereclause += " and (ExpressCompanyID=" + this.ctrlExpressCompanyID.CompanyID.ToString() + ")";
            }
            this.dtblRecords = this.accDeliverItems.GetDataSaleDeliverItemsByFreeSearch (whereclause).Tables[0];           
            this.dgrdv.DataSource = this.dtblRecords;
        }
        void btnExplore_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "销售送货记录");
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeAutoFit(3, 1, rowIndex, colIndex,true,true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            FrmMsg.Hide();
            excel.Show();
        }
    }
}