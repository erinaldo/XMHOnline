using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Service.Report
{
    public partial class FrmRepairItemRecord : Form
    {
        public FrmRepairItemRecord()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false; 
            this.accItems = new JERPData.Product.RepairItems();
            this.SetPermit();
        }
        private JERPData.Product.RepairItems accItems;
        private DataTable dtblRecords;
        private string whereclause = string.Empty;
        //权限码
        private bool enableBrowse = false;//浏览
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(545);
            if (this.enableBrowse)
            {
                DateTime now_ = DateTime.Now;
                DateTime datebegin = new DateTime(now_.Year, now_.Month, 1); 
                this.dtpDeliverBegin.Value = datebegin;
                this.dtpDeliverEnd.Value = now_;
                this.dtpReceiveBegin.Value = datebegin;
                this.dtpReceiveEnd.Value = now_;
                this.btnSearch.Click += new EventHandler(btnSearch_Click);
                this.LoadData();
                this.btnExplore.Click += new EventHandler(btnExplore_Click);
                this.pbar.OnPageIndexChanged += new EventHandler(pbar_OnPageIndexChanged);
            }
        }

     
        void btnSearch_Click(object sender, EventArgs e)
        { 
            this.LoadData();
        }
        private void LoadData()
        {
            this.whereclause = string.Empty;
            if (this.ckbDateReceive.Checked)
            {
                this.whereclause += " and (DateReceive>='" + this.dtpReceiveBegin.Value.ToShortDateString() + "' and DateReceive<='" + this.dtpReceiveEnd.Value.ToShortDateString() + "')";

            }
            if (this.ckbDateDeliver.Checked)
            {
                this.whereclause += " and (DateDeliver>='" + this.dtpDeliverBegin.Value.ToShortDateString() + "' and DateDeliver<='" + this.dtpDeliverEnd.Value.ToShortDateString() + "')";
            }
            if (this.ckbCustomer.Checked)
            {
                this.whereclause += " and (CompanyID=" + this.ctrlCompanyID.CompanyID.ToString() + ")";
            }
            if (this.ckbPrd.Checked)
            {
                this.whereclause += " and (PrdID=" + this.ctrlPrdID.PrdID.ToString() + ")";
            }
            int cnt = 0;
            this.dtblRecords = this.accItems.GetDataRepairItemsPagesFreeSearch   (1,this.pbar .PageSize ,ref cnt,this.whereclause).Tables[0];         
            this.dgrdv.DataSource = this.dtblRecords;
            this.pbar.Init(1, cnt);
        }
        void pbar_OnPageIndexChanged(object sender, EventArgs e)
        {
           
            int cnt = 0;
            this.dtblRecords = this.accItems.GetDataRepairItemsPagesFreeSearch(this.pbar .PageIndex , this.pbar.PageSize, ref cnt, this.whereclause).Tables[0];
            this.dgrdv.DataSource = this.dtblRecords;
        }
        void btnExplore_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "维修记录");
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