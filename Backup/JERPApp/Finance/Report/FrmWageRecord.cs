using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Report
{
    public partial class FrmWageRecord : Form
    {
        public FrmWageRecord()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accItems = new JERPData.Finance.WageItems();
            this.accWageType = new JERPData.Finance.OtherWageType();
            this.btnExport.Click += new EventHandler(btnExport_Click);
            this.CreateColumn();
        }
      
        private JERPData.Finance.WageItems accItems;
        private JERPData.Finance.OtherWageType accWageType;
        private DataTable dtblItems,dtblWageType;      
        private void CreateColumn()
        {
            this.dtblWageType = this.accWageType.GetDataOtherWageType().Tables[0];
            DataGridViewTextBoxColumn txtcol;          
            foreach (DataRow drow in this.dtblWageType.Rows)
            {
                txtcol = new DataGridViewTextBoxColumn();
                txtcol.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                txtcol.DataPropertyName = drow["WageTypeName"].ToString ();
                txtcol.HeaderText = drow["WageTypeName"].ToString();
                txtcol.DefaultCellStyle.Format = "0.#####"; 
                this.dgrdv.Columns.Add(txtcol);
            }
            txtcol = new DataGridViewTextBoxColumn();
            txtcol.Width = 60;
            txtcol.DataPropertyName = "TotalWage";
            txtcol.HeaderText = "合计";
            txtcol.DefaultCellStyle.Format  = "0.#####";      
            this.dgrdv.Columns.Add(txtcol);
            this.ctrlQFind.SeachGridView = this.dgrdv;
        }
        private void AddTotalRow()
        {
            if (this.dtblItems.Rows.Count == 0) return;
            DataRow drowNew = this.dtblItems.NewRow();
            drowNew["PsnCode"] = "合计";
            drowNew["TotalWage"] = this.dtblItems.Compute("SUM(TotalWage)", string.Empty);
            foreach (DataRow drow in this.dtblWageType.Rows)
            {
                drowNew[drow["WageTypeName"].ToString()] = this.dtblItems.Compute("SUM([" + drow["WageTypeName"].ToString() + "])", string.Empty);
            }
            this.dtblItems.Rows.Add(drowNew);
        }
        public void MonthRecord(int Year,int Month)
        {
            this.Text = Year.ToString() + "年" + Month.ToString() + "月工资一览表";
            this.dtblItems = this.accItems.GetDataWageItemsMonthPsnWagePivotWageType (Year ,Month ).Tables[0];
            this.AddTotalRow();
            this.dgrdv.DataSource = this.dtblItems;
           
        }
        public void YearRecord(int Year)
        {
            this.Text = Year.ToString() + "年工资一览表";
            this.dtblItems = this.accItems.GetDataWageItemsYearPsnWagePivotWageType (Year).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
            this.AddTotalRow();
        }
        void btnExport_Click(object sender, EventArgs e)
        {

            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", this.Text);
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(this.dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            excel.SetRangeAutoFit(3, 1, rowIndex, rowIndex, true, false);
            excel.Show();
            FrmMsg.Hide();
        }  
    }
}