using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.QC.Report
{
    public partial class FrmPrdBuyBadReport : Form
    {
        public FrmPrdBuyBadReport()
        {
            InitializeComponent();
            this.dgrdvReport.AutoGenerateColumns = false;
            this.dgrdvRecord.AutoGenerateColumns = false;
            this.accReportItems = new JERPData.Product.BuyBadReportItems();
            this.accSupplier = new JERPData.General.Supplier();
            this.gridhelper = new JCommon.DataGridViewHelper();

            this.SetPermit();
        }
        private JERPData.Product.BuyBadReportItems  accReportItems;
        private JERPData.General.Supplier  accSupplier;
        private JCommon.DataGridViewHelper gridhelper;
        private DataTable dtblRecords,dtblReports,dtblCompanys;
        private const int iRecordIndex = 9;
        private const int iReportIndex = 7;
        //权限码
        private bool enableBrowse = false;//浏览
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(310);
            if (this.enableBrowse)
            {
                this.ctrlBetweenDate .DateBegin =new DateTime (DateTime.Now .Year ,
                    DateTime.Now.Month ,1);
                this.dgrdvReport.CellPainting += new DataGridViewCellPaintingEventHandler(dgrdvReport_CellPainting);
                this.ctrlBetweenDate .DateEnd =DateTime .Now .Date ;
                this.ctrlBetweenDate .AffterEnter +=this.LoadData;
                this.LoadData();
                this.ctrlGridFind.SeachGridView = this.dgrdvRecord;
                this.tabMain.SelectedIndexChanged += new EventHandler(tabMain_SelectedIndexChanged);             
                this.btnExport.Click += new EventHandler(btnExport_Click);
                this.dgrdvReport.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdvReport_DataBindingComplete);
            }

        }

        void dgrdvReport_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.dgrdvReport.Refresh();
        }

        void dgrdvReport_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            int icol = e.ColumnIndex;
            int irow = e.RowIndex;           
            if ((irow > -1)||(icol<iReportIndex )) return;
            int CompanyID = int.Parse(this.dgrdvReport.Columns[icol].Tag.ToString ());
            string CompanyAbbName = this.GetCompanyAbbName(CompanyID);            
            if (icol % 2 == 0)
            {
               
                this.gridhelper.MerageColumnHeaderSpan(
                        this.dgrdvReport, e, 
                        icol - 1, icol,                       
                        CompanyAbbName);
               
            }
            if (icol % 2 == 1)
            {

                this.gridhelper.MerageColumnHeaderSpan(
                    this.dgrdvReport, e,
                     icol, icol + 1,
                    CompanyAbbName);
            }
        }

      
        void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataGridView dgrdv =( DataGridView) (this.tabMain.SelectedTab.Controls[0]);
            this.ctrlGridFind.SeachGridView = dgrdv;
        }

        private string  GetCompanyAbbName(int CompanyID)
        {
            DataRow[] drows = this.dtblCompanys.Select("CompanyID=" + CompanyID.ToString () );
            if (drows.Length > 0)
            {
                return drows[0]["CompanyAbbName"].ToString ();
            }
            return string.Empty;
        }
        private void LoadData()
        {
            DataGridViewTextBoxColumn txtColumn;
            string ColumnName = string.Empty;
            while (this.dgrdvRecord.ColumnCount >iRecordIndex )
            {
                this.dgrdvRecord.Columns.RemoveAt(iRecordIndex);
            }
            DateTime DateBegin=this.ctrlBetweenDate .DateBegin.Date ;
            DateTime DateEnd=this.ctrlBetweenDate .DateEnd.Date;
            this.dtblRecords = this.accReportItems.GetDataBuyBadReportItemsPrdQtyPivotBadTypeBetweenDate (
                DateBegin, DateEnd).Tables[0];
            for (int j =iRecordIndex  ; j < this.dtblRecords.Columns.Count; j++)
            {
                ColumnName = this.dtblRecords.Columns[j].ColumnName;
                txtColumn = new DataGridViewTextBoxColumn();
                txtColumn.DataPropertyName = ColumnName;
                txtColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                txtColumn.HeaderText = ColumnName;
                txtColumn.DefaultCellStyle.Format = "###,###.#####";
                this.dgrdvRecord.Columns.Add(txtColumn);
            }
            DataRow drowNew;
            if (this.dtblRecords.Rows.Count > 0)
            {
                drowNew = this.dtblRecords.NewRow();
                drowNew["PrdCode"] = "合计";
                drowNew["Quantity"] = dtblRecords.Compute("SUM(Quantity)", "");
                drowNew["BadQty"] = dtblRecords.Compute("SUM(BadQty)", "");
                for (int j = iRecordIndex; j < this.dtblRecords.Columns.Count; j++)
                {
                    drowNew[j] = dtblRecords.Compute("SUM([" + this.dtblRecords.Columns[j].ColumnName + "])", "");
                }
                drowNew["BadRate"] = (decimal)drowNew["BadQty"] / (decimal)drowNew["Quantity"];
                this.dtblRecords.Rows.Add(drowNew);
            }
            this.dgrdvRecord.DataSource = dtblRecords;
            this.dtblCompanys = this.accSupplier.GetDataSupplier ().Tables[0];
            while (this.dgrdvReport .ColumnCount >iReportIndex )
            {
                this.dgrdvReport.Columns.RemoveAt(iReportIndex);
            }
            this.dtblReports = this.accReportItems.GetDataBuyBadReportItemsPrdRptPivotCompanyBetweenDate(DateBegin,
                DateEnd).Tables[0];

            for (int j = iReportIndex; j < this.dtblReports.Columns.Count; j++)
            {
                ColumnName = this.dtblReports.Columns[j].ColumnName;
                txtColumn = new DataGridViewTextBoxColumn();
                txtColumn.DataPropertyName = ColumnName;
                txtColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                txtColumn.Tag = ColumnName.Remove(0, 1);
                if (j % 2 == 1)
                {
                    txtColumn.HeaderText ="不良数";
                    txtColumn.DefaultCellStyle.Format = "###,###.#####";
                   
                }
                else
                {
                    txtColumn.HeaderText = "不良率";
                    txtColumn.DefaultCellStyle.Format = "0.####%";
                }
                this.dgrdvReport .Columns.Add(txtColumn);
              
            }
            decimal TotalQty, BadQty;
            object objBadQty;
            if (this.dtblReports.Rows.Count > 0)
            {
                drowNew = this.dtblReports.NewRow();
                drowNew["PrdCode"] = "合计";
                TotalQty = (decimal)dtblReports.Compute("SUM(Quantity)", "");
                drowNew["Quantity"] = TotalQty;
                BadQty = (decimal)dtblReports.Compute("SUM(BadQty)", "");
                drowNew["BadQty"] = BadQty;
                drowNew["BadRate"] = BadQty / TotalQty;
                for (int j = iReportIndex; j < this.dtblReports.Columns.Count; j = j + 2)
                {                     
                    objBadQty=dtblReports.Compute("SUM([" + this.dtblReports.Columns[j].ColumnName + "])", "");
                    if (objBadQty != DBNull.Value)
                    {
                        drowNew[j] = objBadQty;
                        drowNew[j + 1] = (decimal)objBadQty / TotalQty;
                    }
                }
                this.dtblReports.Rows.Add(drowNew);
            }
            this.dgrdvReport.DataSource = this.dtblReports;
        }
        void btnExport_Click(object sender, EventArgs e)
        {

            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "产品采购检品报告");
            excel.SetCellVal("A2", "从"+this.ctrlBetweenDate .DateBegin .ToShortDateString ()+"到"+this.ctrlBetweenDate .DateEnd .ToShortDateString ());
            int rowIndex = 3;
            int colIndex = 1;
            DataGridView dgrdv = (DataGridView)this.tabMain.SelectedTab.Controls[0];
            excel.ImportGridData(dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            excel.SetRangeAutoFit(3, 1, rowIndex, colIndex, true, true);
            FrmMsg.Hide();
            excel.Show();
        }

    }
}