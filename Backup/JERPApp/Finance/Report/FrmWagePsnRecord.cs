using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Report
{
    public partial class FrmWagePsnRecord : Form
    {
        public FrmWagePsnRecord()
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
                txtcol.DataPropertyName = drow["WageTypeName"].ToString();
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
       
        public void MonthRecord(int Year,int Month,int PsnID,string PsnName)
        {
            this.Text = Year.ToString() + "年" + Month.ToString() + "月"+PsnName +"工资一览表";
            this.dtblItems = this.accItems.GetDataWageItemsMonthSinglePsnWagePivotWageType  (Year ,Month,PsnID  ).Tables[0];         
            this.dgrdv.DataSource = this.dtblItems;
           
        }
        public void YearRecord(int Year,int PsnID,string PsnName)
        {
            this.Text = Year.ToString() + "年"+PsnName +"工资一览表";
            this.dtblItems = this.accItems.GetDataWageItemsYearSinglePsnWagePivotWageType  (Year,PsnID ).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
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