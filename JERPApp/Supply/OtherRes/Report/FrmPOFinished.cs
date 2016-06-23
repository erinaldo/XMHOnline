using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Supply.OtherRes.Report
{
    public partial class FrmPOFinished : Form
    {
        public FrmPOFinished()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accItems = new JERPData.OtherRes.BuyOrderItems();
            this.SetPermit();
        }
        private JERPData.OtherRes.BuyOrderItems accItems;
        private DataTable dtblReport;
        private FrmPOFinishedDetail frmDetail;
        private int iGrid = 9, iData = 10;
        //权限码
        private bool enableBrowse = false;//浏览
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(513);
            if (this.enableBrowse)
            {
                this.dtpDateBegin .Value  = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                this.dtpDateEnd.Value  = DateTime.Now.Date;
                this.LoadData();
                this.ctrlCompanyID.AffterSelected += this.LoadData;
                this.dtpDateBegin.ValueChanged += this.dtpDate_ValueChanged;
                this.dtpDateEnd.ValueChanged += this.dtpDate_ValueChanged;
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
                this.btnExport.Click += new EventHandler(btnExport_Click);
                
            }
        }

        void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            this.LoadData();
        }
        private void LoadData()
        {
            while  (this.dgrdv.Columns.Count > iGrid)
            {
                this.dgrdv.Columns.RemoveAt(iGrid);
            }
            this.dtblReport = this.accItems.GetDataBuyOrderItemsDeliverReport(this.ctrlCompanyID.CompanyID,
                this.dtpDateBegin.Value.Date, this.dtpDateEnd.Value.Date).Tables[0];
            this.dgrdv.DataSource = this.dtblReport;
            if (this.dtblReport.Rows.Count == 0) return;
            DataGridViewTextBoxColumn txt;
            string ColumnName = string.Empty;
            for (int j = iData; j < this.dtblReport.Columns.Count; j++)
            {
                txt = new DataGridViewTextBoxColumn();
                ColumnName = this.dtblReport.Columns[j].ColumnName;
                txt.DataPropertyName = ColumnName;
                txt.HeaderText = ColumnName;
                txt.Width = 60;
                txt.DefaultCellStyle.Format = "0.####";
                txt.SortMode = DataGridViewColumnSortMode.Automatic;
                this.dgrdv.Columns.Add(txt);
            }
            DataRow drowNew = this.dtblReport.NewRow();
            drowNew["ItemID"] = -1;
            drowNew["UnitName"] = "合计";
            drowNew["Quantity"] = this.dtblReport.Compute("SUM(Quantity)", "");
            drowNew["NonFinishedQty"] = this.dtblReport.Compute("SUM(NonFinishedQty)", "");
            drowNew["FinishedQty"] = this.dtblReport.Compute("SUM(FinishedQty)", "");
            drowNew["FinishedAMT"] = this.dtblReport.Compute("SUM(FinishedAMT)", "");
            for (int j = iData; j < this.dtblReport.Columns.Count; j++)
            {
                ColumnName = this.dtblReport.Columns[j].ColumnName;
                drowNew[ColumnName] = this.dtblReport.Compute("SUM([" + ColumnName + "])", "");
            }
            this.dtblReport.Rows.Add(drowNew);
        }

        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnFinishedQty.Name)
            {
                long ItemID = (long)this.dtblReport.DefaultView[irow]["ItemID"];
                if (frmDetail == null)
                {
                    frmDetail = new FrmPOFinishedDetail();
                    new FrmStyle(frmDetail).SetPopFrmStyle(this);                    
                }
                frmDetail.DeliverItem(ItemID);
                frmDetail.ShowDialog();
            }
        }
        void btnExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成Excel文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "订单完成报告");
            excel.SetCellVal("A2", "供应商:"+this.ctrlCompanyID .CompanyAbbName +" 订单日期:"+this.dtpDateBegin .Value .ToShortDateString ()+"到"+this.dtpDateEnd .Value .ToShortDateString ());
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            excel.SetRangeAutoFit(3, 1, rowIndex, colIndex, true, true);
            FrmMsg.Hide();
            excel.Show();
        }
    }
}