using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture.Report
{
    public partial class FrmPsnBadRpt : Form
    {
        public FrmPsnBadRpt()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accIndivPiecework = new JERPData.Manufacture.IndivPiecework();
            this.SetPermit();
        }
        private JERPData.Manufacture.IndivPiecework accIndivPiecework;
        private DataTable dtblReport;
        private int iGrid = 2;
        private int iData = 3;
        //权限码
        private bool enableBrowse = false;//浏览
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(367);
            if (this.enableBrowse)
            {

                this.ctrlBetweenDate.DateBegin = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                this.ctrlBetweenDate.DateEnd = this.ctrlBetweenDate.DateBegin.AddMonths(1).AddDays(-1);
                this.LoadData();
                this.ctrlBetweenDate.AffterEnter += this.LoadData;
                this.btnExport.Click += new EventHandler(btnExport_Click);
            }

        }

        private void LoadData()
        {

            while (this.dgrdv.ColumnCount > this.iGrid)
            {
                this.dgrdv.Columns.RemoveAt(this.iGrid);
            }
            this.dtblReport = this.accIndivPiecework.GetDataIndivPieceworkPsnBadRatePivotProcessType  (this.ctrlBetweenDate.DateBegin.Date,
                this.ctrlBetweenDate.DateEnd.Date).Tables[0];
            DataGridViewTextBoxColumn txt;
            string columnname;
            for (int j = this.iData; j < this.dtblReport.Columns.Count; j++)
            {
                columnname = this.dtblReport .Columns[j].ColumnName;
                txt = new DataGridViewTextBoxColumn();
                txt.HeaderText = columnname;
                txt.DataPropertyName = columnname;
                txt.DefaultCellStyle.Format = "0.##%";
                txt.Width = 80;
                this.dgrdv.Columns.Add(txt);
            }          
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.dgrdv.DataSource = this.dtblReport;
        }

        void btnExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("C1", this.ctrlBetweenDate.DateBegin .ToShortDateString() + "-" + this.ctrlBetweenDate.DateEnd.ToShortDateString() + "]产量报告");
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(this.dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            excel.SetRangeAutoFit(3, 1, rowIndex, colIndex, true, false);
            FrmMsg.Hide();
            excel.Show();
        }
    }
}