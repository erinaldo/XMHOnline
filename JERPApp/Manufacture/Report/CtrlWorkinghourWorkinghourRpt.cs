using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture.Report
{
    public partial class CtrlWorkinghourWorkinghourRpt : UserControl
    {
        public CtrlWorkinghourWorkinghourRpt()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.dgrdv.ContextMenuStrip = this.cMenu;
            this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
            this.accWorkinghour = new JERPData.Manufacture.Workinghour();
           
        }

     
        private JERPData.Manufacture.Workinghour  accWorkinghour;
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
            this.dtblReport = this.accWorkinghour.GetDataWorkinghourWorkinghourPivotWorkinghourType (this.DateBegin ,this.DateEnd).Tables[0];
            DataGridViewTextBoxColumn txt;
            DataRow drowNew = this.dtblReport.NewRow();
            drowNew["PsnCode"] = "ºÏ¼Æ";
            string columnname;
            for (int j = this.iDtbl; j < this.dtblReport.Columns.Count; j++)
            {
                columnname = this.dtblReport.Columns[j].ColumnName;
                drowNew[j] = this.dtblReport.Compute("SUM([" + columnname + "])", "");
                txt = new DataGridViewTextBoxColumn();
                txt.HeaderText = columnname;
                txt.DataPropertyName = columnname;
                txt.DefaultCellStyle.Format = "#,###.####";
                txt.Width = 80;
                this.dgrdv.Columns.Add(txt);
            }
            this.dtblReport.Rows.Add(drowNew);
            this.dgrdv.DataSource = this.dtblReport;
            this.ctrlQFind.SeachGridView=this.dgrdv;
        }
        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
   
    }
}
