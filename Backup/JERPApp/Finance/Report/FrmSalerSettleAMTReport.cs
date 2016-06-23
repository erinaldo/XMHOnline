using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Report
{
    public partial class FrmSalerSettleAMTReport : Form
    {
        public FrmSalerSettleAMTReport()
        {
            InitializeComponent();
            this.accReconcilaiton = new JERPData.Product.SaleReconciliations();
            this.accMoneyTypes = new JERPData.Finance.MoneyType();
            this.gridhelper = new JCommon.DataGridViewHelper();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlYear.Year = DateTime.Now.Year;
            this.SetPermit();
        }
        private JERPData.Product.SaleReconciliations  accReconcilaiton;
        private JERPData.Finance.MoneyType accMoneyTypes;
        private JCommon.DataGridViewHelper gridhelper;
        private DataTable dtblReport;
        //权限码
        private bool enableBrowse = false;//浏览
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(132);
            if (this.enableBrowse)
            {
                this.CreateColumn();
                this.LoadData();
                string MoneyTypeName=string.Empty ;
                this.accMoneyTypes.GetParmMoneyTypeMainMoneyTypeName(ref MoneyTypeName);
                this.txtMainMoneyTypeName.Text = MoneyTypeName;
                this.dgrdv.ContextMenuStrip = this.popmenu ;
                this.ctrlYear.OnSelected += this.LoadData;
                this.menuItemRefresh.Click += new EventHandler(menuItemRefresh_Click);
                this.btnExplore.Click += btnExport_Click;
                this.dgrdv.CellPainting += new DataGridViewCellPaintingEventHandler(dgrdv_CellPainting);
                this.dgrdv.Scroll += new ScrollEventHandler(dgrdv_Scroll);
            }


        }
        void menuItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
        private void CreateColumn()
        {
            DataGridViewTextBoxColumn column;
            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "T0";
            column.Tag = "上年";
            column.Width = 66;
            column.HeaderText = "应收";
            dgrdv.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "F0";
            column.Tag = "上年";
            column.Width = 66;
            column.HeaderText = "结款";
            dgrdv.Columns.Add(column);
            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "R0";
            column.Tag = "上年";

            column.Width = 66;
            column.HeaderText = "达成";
            column.DefaultCellStyle.Format = "0.##%";
            dgrdv.Columns.Add(column);

            for (int i = 1; i < 13; i++)
            {
                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "T" + i.ToString(); 
                column.Tag = i.ToString() + "月";
                column.Width = 66;
                column.HeaderText = "应收";
                dgrdv.Columns.Add(column);

                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "F" + i.ToString();
                column.Tag = i.ToString() + "月";
                column.Width = 66;
                column.HeaderText = "结款";
                dgrdv.Columns.Add(column);

                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "R" + i.ToString();
                column.Tag = i.ToString() + "月";
                column.Width = 66;
                column.HeaderText = "达成";
                column.DefaultCellStyle.Format = "0.##%";
                dgrdv.Columns.Add(column);
                
            }         
            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "T";
            column.Tag = "本年";
            column.Width = 66;
            column.HeaderText = "应收";
            dgrdv.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "F";
            column.Tag = "本年";
            column.Width = 66;
            column.HeaderText = "结款";
            dgrdv.Columns.Add(column);
            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "R";
            column.Tag = "本年";
            column.Width = 66;
            column.HeaderText = "达成";
            column.DefaultCellStyle.Format = "0.##%";
            dgrdv.Columns.Add(column);

            this.ctrlGridSpot.SeachGridView = this.dgrdv;
            this.ctrlQFind.SeachGridView = this.dgrdv;
        }
        private void LoadData()
        {
            this.dtblReport = this.accReconcilaiton.GetDataSaleReconciliationsSalerSettleAMTYearReport  (this.ctrlYear.Year).Tables[0];           
            this.dgrdv.DataSource = this.dtblReport;

        }
        void dgrdv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow > -1) || (icol <1)) return;
            string caption = this.dgrdv.Columns[icol].Tag.ToString();
            if (icol % 3 == 1)
            {
                this.gridhelper.MerageColumnHeaderSpan(this.dgrdv, e, icol, icol + 2, caption);
            }
            if (icol % 3 == 2)
            {
                this.gridhelper.MerageColumnHeaderSpan(this.dgrdv, e, icol - 1, icol + 1, caption);
            }
            if (icol % 3 == 0)
            {
                this.gridhelper.MerageColumnHeaderSpan(this.dgrdv, e, icol - 2, icol, caption);
            }  
        }

        void dgrdv_Scroll(object sender, ScrollEventArgs e)
        {
            this.dgrdv.Refresh();
        }
        void btnExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"SalerSettleAMTReport.xlt");
            excel.SetCellVal("A1", this.ctrlYear.Year.ToString() + "业务结款报告");
            int rowIndex = 4;
            int colIndex = 1;
            excel.ImportGridData(this.dgrdv, ref rowIndex, ref colIndex, false, false);
            excel.SetRangeInnerBorder(4, 1, rowIndex, colIndex);
            FrmMsg.Hide();
            excel.Show();
        }
    }
}