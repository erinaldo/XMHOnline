using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Supply.OutSrc.Report
{
    public partial class FrmReceiveItemRecord : Form
    {
        public FrmReceiveItemRecord()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accReceiveItems = new JERPData.Manufacture.OutSrcReceiveItems();
            this.SetPermit();
        }
        private JERPData.Manufacture.OutSrcReceiveItems accReceiveItems;
        private DataTable dtblRecords;
        //权限码
        private bool enableBrowse = false;//浏览
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(209);
            if (this.enableBrowse)
            {
                this.ctrlSupplierID.AppendAll();
                this.ctrlBetweenDate.DateBegin = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                this.ctrlBetweenDate.DateEnd = DateTime.Now.Date;
                this.LoadData();
                this.ctrlBetweenDate.AffterEnter += this.LoadData;
                this.ctrlSupplierID.AffterSelected += this.LoadData;
                this.btnExplore.Click += new EventHandler(btnExplore_Click);
            }
            
        }

      
        private void LoadData()
        {
            this.dtblRecords = this.accReceiveItems.GetDataOutSrcReceiveItemsBetweenDate (this.ctrlBetweenDate.DateBegin.Date ,
                this.ctrlBetweenDate.DateEnd.Date ).Tables[0];
            if (this.ctrlSupplierID.CompanyID > -1)
            {
                DataRow[] drows = this.dtblRecords.Select("CompanyID<>" + this.ctrlSupplierID.CompanyID.ToString());
                foreach (DataRow drow in drows)
                {
                    drow.Delete();
                }
            }
            this.dgrdv.DataSource = this.dtblRecords;
            
        }
        void btnExplore_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "委外收货记录");
            excel.SetCellVal("A2", "从" + this.ctrlBetweenDate.DateBegin.ToShortDateString() + "到" + this.ctrlBetweenDate.DateEnd.ToShortDateString());
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            FrmMsg.Hide();
            excel.Show();
        }
    }
}