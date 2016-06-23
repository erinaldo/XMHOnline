using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Report
{
    public partial class CtrlSaleReconciliationRpt : UserControl
    {
        public CtrlSaleReconciliationRpt()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accReconcilaiton = new JERPData.Product.SaleReconciliations();
            this.gridhelper = new JCommon.DataGridViewHelper();
            this.dgrdv.ContextMenuStrip = this.cMenu;
            this.CreateColumn();           
            this.dgrdv.CellPainting += new DataGridViewCellPaintingEventHandler(dgrdv_CellPainting);
            this.dgrdv.Scroll += new ScrollEventHandler(dgrdv_Scroll);
            this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
            this.btnExplore.Click += new EventHandler(btnExplore_Click);
        }

        private JERPData.Product.SaleReconciliations accReconcilaiton;
        private JCommon.DataGridViewHelper gridhelper;
        private DataTable dtblRpt;
        private void CreateColumn()
        {
            DataGridViewTextBoxColumn column;
            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "D0";
            column.Tag = "上年";
            column.Width = 66; ;
            column.HeaderText = "应收";
            this.dgrdv.Columns.Add(column);
            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "S0";
            column.Tag = "上年";
            column.Width = 66; ;
            column.HeaderText = "已收";
            this.dgrdv.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "N0";
            column.Tag = "上年";
            column.Width = 66; ;
            column.HeaderText = "未收";
            this.dgrdv.Columns.Add(column);

            for (int i = 1; i < 13; i++)
            {
                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "D" + i.ToString();
                column.Tag = i.ToString() + "月";
                column.Width = 66; ;
                column.HeaderText = "应收";
                this.dgrdv.Columns.Add(column);
                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "S" + i.ToString();
                column.Tag = i.ToString() + "月";
                column.Width = 66; ;
                column.HeaderText = "已收";
                this.dgrdv.Columns.Add(column);
                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "N" + i.ToString();
                column.Tag = i.ToString() + "月";
                column.Width = 66; ;
                column.HeaderText = "未收";
                this.dgrdv.Columns.Add(column);
            }
            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "D";
            column.Tag = "本年";
            column.Width = 66; ;
            column.HeaderText = "应收";
            this.dgrdv.Columns.Add(column);
            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "S";
            column.Tag = "本年";
            column.Width = 66; ;
            column.HeaderText = "已收";
            this.dgrdv.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "N";
            column.Tag = "本年";
            column.Width = 66; ;
            column.HeaderText = "未收";
            this.dgrdv.Columns.Add(column);
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.ctrlSpot.SeachGridView = this.dgrdv;
        }
        void dgrdv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow > -1) || (icol < 4)) return;
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

        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
        private int Year = -1;
        public  void ReconciliationRpt(int Year)
        {
            this.Year = Year;
            this.LoadData();
        }
        private void LoadData()
        {
            this.dtblRpt = this.accReconcilaiton.GetDataSaleReconciliationsYearReport(this.Year).Tables[0];
            this.dgrdv.DataSource = this.dtblRpt;
        }
        void btnExplore_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"ReceivableReconciliationReport.xlt");
            excel.SetCellVal("A1", Year.ToString() + "年客户对账表");
            int rowIndex = 4;
            int colIndex = 1;
            excel.ImportGridData(this.dgrdv, ref rowIndex, ref colIndex, false, false);
            excel.SetRangeInnerBorder(4, 1, rowIndex, colIndex);
            FrmMsg.Hide();
            excel.Show();
        }
    }
}
