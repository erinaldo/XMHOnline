using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture.Report
{
    public partial class CtrlIndivPieceworkLaborWageRpt : UserControl
    {
        public CtrlIndivPieceworkLaborWageRpt()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.dgrdv.ContextMenuStrip = this.cMenu;
            this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
            this.accIndivPiecework = new JERPData.Manufacture.IndivPiecework();
           
        }

     
        private JERPData.Manufacture.IndivPiecework  accIndivPiecework;
        private DataTable dtblReport;
        private int iDtbl=3;
        private int iGrid=2;    
        private DateTime DateBegin = DateTime.MinValue;
        private DateTime DateEnd = DateTime.MinValue;
        public void WageRpt(DateTime DateBegin,DateTime DateEnd)
        {
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
            this.dtblReport = this.accIndivPiecework.GetDataIndivPieceworkLaborWagePivotProcessType (this.DateBegin ,this.DateEnd).Tables[0];
            DataGridViewTextBoxColumn txt;
            DataRow drowNew = this.dtblReport.NewRow();
            drowNew["PsnCode"] = "合计";
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
   
    }
}
