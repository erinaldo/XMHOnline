using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture.Report
{
    public partial class CtrlWorkgroupFinishedPivotMonth : UserControl
    {
        public CtrlWorkgroupFinishedPivotMonth()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.dgrdv.ContextMenuStrip = this.cMenu;
            this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
            this.accInstruct = new JERPData.Manufacture.Instruct(); 
            this.btnExport.Click += new EventHandler(btnExport_Click);
            this.dgrdv.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdv_DataBindingComplete);
        }

        private JERPData.Manufacture.Instruct  accInstruct;
        private DataTable dtblRpt;
        private int iGrid = 3;
        private void CreateColumn()
        {
            DataGridViewTextBoxColumn txt;
            txt = new DataGridViewTextBoxColumn();
            txt.Width = 66;
            txt.DataPropertyName = "-1";
            txt.HeaderText = "合计";
            this.dgrdv.Columns.Add(txt);
            int m = DateTime.DaysInMonth(this.Year, this.Month);
            for (int j = 1; j < m+1; j++)
            {
                txt = new DataGridViewTextBoxColumn();
                txt.Width = 66;
                txt.DataPropertyName = j.ToString();
                txt.HeaderText = this.GetHeaderText(j);
                this.dgrdv.Columns.Add(txt);
            }
            this.ctrlQFind.SeachGridView = this.dgrdv;
        }
        private string GetHeaderText(int Day)
        {
         
            DateTime DateSchedule = new DateTime(this.Year, this.Month, Day); 
            string rut = Day.ToString();
            if (DateSchedule.DayOfWeek == DayOfWeek.Monday)
            {
                rut += @"(一)";
            }
            if (DateSchedule.DayOfWeek == DayOfWeek.Tuesday)
            {
                rut += @"(二)";
            }
            if (DateSchedule.DayOfWeek == DayOfWeek.Wednesday)
            {
                rut += @"(三)";
            }
            if (DateSchedule.DayOfWeek == DayOfWeek.Thursday)
            {
                rut += @"(四)";
            }
            if (DateSchedule.DayOfWeek == DayOfWeek.Friday)
            {
                rut += @"(五)";
            }
            if (DateSchedule.DayOfWeek == DayOfWeek.Saturday)
            {
                rut += @"(六)";
            }
            if (DateSchedule.DayOfWeek == DayOfWeek.Sunday)
            {
                rut += @"(日)";
            }
            return rut;
        }

        private int Year, Month;
        public void LoadData(int Year, int Month)
        {
            this.Year = Year;
            this.Month = Month;
            while (this.dgrdv.Columns.Count > this.iGrid )
            {
                this.dgrdv.Columns.RemoveAt(this.iGrid);
            }
            this.CreateColumn();
            this.LoadData();
        }
        private  void LoadData()
        {
            this.dtblRpt = this.accInstruct.GetDataInstructWorkgroupFinishedRpt (this.Year, this.Month).Tables[0];
            DataRow[] drows = this.dtblRpt.Select("TypeID=2 or TypeID=3", "");
            foreach(DataRow drow in drows )
            {
                drow["WorkgroupName"] = DBNull.Value;
            }
            this.dgrdv.DataSource = this.dtblRpt; 
        }

        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }

        void dgrdv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow grow in this.dgrdv.Rows)
            {
                if ((int)grow.Cells[this.ColumnTypeID.Name].Value ==3)
                {
                    for (int j = this.iGrid; j < this.dgrdv.ColumnCount; j++)
                    {
                        grow.Cells[j].Style.Format = "0.##%";
                    }
                }
            }
        }

        void btnExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("C1", "机组达成表");
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
