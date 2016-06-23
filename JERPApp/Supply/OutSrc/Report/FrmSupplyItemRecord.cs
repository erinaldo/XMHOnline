using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Supply.OutSrc.Report
{
    public partial class FrmSupplyItemRecord : Form
    {
        public FrmSupplyItemRecord()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accSupplyItems = new JERPData.Material.OutSrcSupplyItems();
            this.SetPermit();
        }
        private JERPData.Material .OutSrcSupplyItems  accSupplyItems;
        private DataTable dtblRecords;
        //权限码
        private bool enableBrowse = false;//浏览
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(462);
            if (this.enableBrowse)
            {
                this.ctrlBetweenDate.DateBegin = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                this.ctrlBetweenDate.DateEnd = DateTime.Now.Date.AddDays (1);
                this.btnSearch.Click += new EventHandler(btnSearch_Click);
                this.btnExplore.Click += new EventHandler(btnExplore_Click);
                this.ctrlQFind.BeforeFilter += this.LoadData;
                this.LoadData();
            }
            
        }

        void btnSearch_Click(object sender, EventArgs e)
        { 
            this.LoadData();
        }
        private void LoadData()
        {
            string whereclause = " and (DateNote>='" + this.ctrlBetweenDate.DateBegin.Date.ToShortDateString() + "' and DateNote<='" + this.ctrlBetweenDate.DateEnd.ToShortDateString() + "')";
            if (this.ckbSupplierFlag.Checked)
            {
                whereclause += " and (CompanyID=" + this.ctrlSupplierID.CompanyID.ToString() + ")"; 
            } 
            if (this.ckbPrd.Checked)
            {
                whereclause += " and (PrdID=" + this.ctrlPrdID.PrdID.ToString() + ")";
            } 
            this.dtblRecords = this.accSupplyItems.GetDataOutSrcSupplyItemsFreeSearch  (whereclause).Tables[0]; 
            this.dgrdv.DataSource = this.dtblRecords;
            
        }
        void btnExplore_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "委外发料记录");
            string caption = "发料日期:" + this.ctrlBetweenDate.DateBegin.ToShortDateString() + "-" + this.ctrlBetweenDate.DateEnd.ToShortDateString();
            if (this.ckbSupplierFlag.Checked)
            {
                caption += "  委外商:" + this.ctrlSupplierID.CompanyAbbName;
            }
            if (this.ckbPrd.Checked)
            {
                caption += " 包含物料编号:" + this.ctrlPrdID.PrdEntity.PrdCode + " 名称:" + this.ctrlPrdID.PrdEntity.PrdName + " 规格:" + this.ctrlPrdID.PrdEntity.PrdSpec;
            }
            excel.SetCellVal("A2", caption);
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            FrmMsg.Hide();
            excel.Show();
        }
    }
}