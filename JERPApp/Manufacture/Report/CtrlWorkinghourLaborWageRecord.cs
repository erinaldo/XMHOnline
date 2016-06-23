using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture.Report
{
    public partial class CtrlWorkinghourLaborWageRecord : UserControl
    {
        public CtrlWorkinghourLaborWageRecord()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.dgrdv.ContextMenuStrip = this.cMenu;
            this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
            this.accWorkinghour = new JERPData.Manufacture.Workinghour();
            this.btnExport.Click += new EventHandler(btnExport_Click);
           
        }

     
        private JERPData.Manufacture.Workinghour  accWorkinghour;
        private DataTable dtblReport;
        private int iDtbl=1;
        private int iGrid=1;    
        private DateTime DateBegin = DateTime.MinValue;
        private DateTime DateEnd = DateTime.MinValue;
        private int PsnID = -1;
        private string PsnInfor = string.Empty;
        public void WageRecord(int PsnID,string PsnInfor,DateTime DateBegin,DateTime DateEnd)
        {
            this.PsnID = PsnID;
            this.PsnInfor = PsnInfor;
            this.DateBegin = DateBegin;
            this.DateEnd = DateEnd;
            this.LoadData();
        }
        private void LoadData()
        {
            while (this.dgrdv.ColumnCount > this.iGrid )
            {
                this.dgrdv.Columns.RemoveAt(this.iGrid);
            }
            this.dtblReport = this.accWorkinghour.GetDataWorkinghourPsnLaborWagePivotWorkinghourType(this.PsnID ,this.DateBegin ,this.DateEnd).Tables[0];
            DataGridViewTextBoxColumn txt;
            DataRow drowNew = this.dtblReport.NewRow();
            drowNew["DateManuf"] = "合计";
            string columnname;
            string totalexp = string.Empty;
            for (int j = this.iDtbl; j < this.dtblReport.Columns.Count; j++)
            {
                columnname = this.dtblReport.Columns[j].ColumnName;
                totalexp += "+ISNULL([" + columnname + "],0)";
                drowNew[j] = this.dtblReport.Compute("SUM([" + columnname + "])", "");
                txt = new DataGridViewTextBoxColumn();
                txt.HeaderText = columnname;
                txt.DataPropertyName = columnname;
                txt.DefaultCellStyle.Format = "#,###.####";
                txt.Width = 80;
                this.dgrdv.Columns.Add(txt);
            }

            this.dtblReport.Columns.Add("Total", typeof(decimal),totalexp);
            this.dtblReport.Rows.Add(drowNew);
            txt = new DataGridViewTextBoxColumn();
            txt.HeaderText = "合计";
            txt.DataPropertyName = "Total";
            txt.DefaultCellStyle.Format = "#,###.####";
            txt.Width = 80;
            this.dgrdv.Columns.Add(txt);
            this.dgrdv.DataSource = this.dtblReport;
            this.ctrlQFind.SeachGridView = this.dgrdv;
        }
        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
        void btnExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("C1", this.PsnInfor + "[" + this.DateBegin.ToShortDateString() + "-" + this.DateEnd.ToShortDateString() + "]计时工资一览");
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
