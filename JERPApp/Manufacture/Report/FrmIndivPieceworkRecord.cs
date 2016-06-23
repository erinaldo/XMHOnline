using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture.Report
{
    public partial class FrmIndivPieceworkRecord : Form
    {
        public FrmIndivPieceworkRecord()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accPiecework = new JERPData.Manufacture.IndivPiecework();
            this.SetPermit();
        }
        private JERPData.Manufacture.IndivPiecework accPiecework;
        private DataTable dtblRecord;
        //权限码
        private bool enableBrowse = false;//浏览
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(154);
            if (this.enableBrowse)
            {

                this.ctrlBetweenDate.DateBegin = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                this.ctrlBetweenDate.DateEnd = this.ctrlBetweenDate.DateBegin.AddMonths(1).AddDays(-1);
                this.LoadData();
                this.ctrlBetweenDate.AffterEnter += this.LoadData;
                this.btnExport.Click += new EventHandler(btnExport_Click);
                this.btnSearch.Click += new EventHandler(btnSearch_Click);
            }

        }

        void btnSearch_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
        private void LoadData()
        {
            string whereclause=" and (DateManuf>='"+this.ctrlBetweenDate .DateBegin .ToShortDateString ()
                +"' and DateManuf<='"+this.ctrlBetweenDate .DateEnd .ToShortDateString ()+"')" ;
            if (this.ckbPsnID.Checked)
            {
                whereclause += " and (PsnID=" + this.ctrlPsnID.PsnID.ToString() + ")";
            } 
            if (this.ckbProcessTypeFlag.Checked)
            {
                whereclause += " and (ProcessTypeID=" + this.ctrlProcessTypeID.ProcessTypeID.ToString() + ")";
            }
            if (this.ckbPrdID.Checked)
            {
                whereclause += " and (PrdID=" + this.ctrlPrdID.PrdID.ToString() + ")";
            }
            this.dtblRecord = this.accPiecework.GetDataIndivPieceworkFreeSearch(whereclause).Tables[0];
            this.dgrdv.DataSource = this.dtblRecord;
        }

        void btnExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("C1", "个人计件记录");
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