using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.QC.Report
{
    public partial class FrmOutSrcBadReport : Form
    {
        public FrmOutSrcBadReport()
        {
            InitializeComponent();
            this.dgrdvReport.AutoGenerateColumns = false;
            this.dgrdvProcessType.AutoGenerateColumns = false;
            this.accReportItems = new JERPData.Manufacture.OutSrcBadReportItems();
            this.accSupplier = new JERPData.General.Supplier();
            this.gridhelper = new JCommon.DataGridViewHelper();

            this.SetPermit();
        }
        private JERPData.Manufacture.OutSrcBadReportItems  accReportItems;
        private JERPData.General.Supplier  accSupplier;
        private JCommon.DataGridViewHelper gridhelper;
        private DataTable dtblReports,dtblProcessTypeRpt,dtblCompanys;
        private const int iReportIndex =8;
        private const int iOutSrcRptIndex = 4;
        //权限码
        private bool enableBrowse = false;//浏览
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(223);
            if (this.enableBrowse)
            {
                this.dtblCompanys = this.accSupplier.GetDataSupplierForOutSrc().Tables[0];
                this.ctrlBetweenDate .DateBegin =new DateTime (DateTime.Now .Year ,
                    DateTime.Now.Month ,1);
                this.dgrdvReport.CellPainting += new DataGridViewCellPaintingEventHandler(dgrdvReport_CellPainting);
                this.dgrdvProcessType.CellPainting += new DataGridViewCellPaintingEventHandler(dgrdvProcessType_CellPainting);
                this.ctrlBetweenDate .DateEnd =DateTime .Now .Date ;
                this.ctrlBetweenDate .AffterEnter +=this.LoadData;
                this.LoadData();
                this.ctrlGridFind.SeachGridView = this.dgrdvReport ;
                this.tabMain.SelectedIndexChanged += new EventHandler(tabMain_SelectedIndexChanged);             
                this.btnExport.Click += new EventHandler(btnExport_Click);
                this.dgrdvReport.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdvReport_DataBindingComplete);
                this.dgrdvProcessType.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdvProcessType_DataBindingComplete);
            }

        }

        void dgrdvProcessType_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.dgrdvProcessType.Refresh();
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
                    icol, icol + 1,
                  CompanyAbbName);

               
            }
            if (icol % 2 == 1)
            { 
                this.gridhelper.MerageColumnHeaderSpan(
                       this.dgrdvReport, e,
                       icol - 1, icol,
                       CompanyAbbName);
            }
        }
        void dgrdvProcessType_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            int icol = e.ColumnIndex;
            int irow = e.RowIndex;
            if ((irow > -1) || (icol < iOutSrcRptIndex )) return;
            int CompanyID = int.Parse(this.dgrdvProcessType .Columns[icol].Tag.ToString());
            string CompanyAbbName = this.GetCompanyAbbName(CompanyID);
            if (icol % 2 == 0)
            {
                this.gridhelper.MerageColumnHeaderSpan(
                       this.dgrdvProcessType , e,
                       icol, icol + 1,
                       CompanyAbbName);
            }
            if (icol % 2 == 1)
            {
                this.gridhelper.MerageColumnHeaderSpan(
                                 this.dgrdvProcessType, e,
                                 icol - 1, icol,
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
  
        private void LoadItemXCompany()
        {
            DataGridViewTextBoxColumn txtColumn;
            string ColumnName = string.Empty; 
            DateTime DateBegin = this.ctrlBetweenDate.DateBegin.Date;
            DateTime DateEnd = this.ctrlBetweenDate.DateEnd.Date;
            while (this.dgrdvReport.ColumnCount > iReportIndex)
            {
                this.dgrdvReport.Columns.RemoveAt(iReportIndex);
            }
            this.dtblReports = this.accReportItems.GetDataOutSrcBadReportItemsPivotCompanyBetweenDate (DateBegin,
                DateEnd).Tables[0];

            for (int j = iReportIndex; j < this.dtblReports.Columns.Count; j++)
            {
                ColumnName = this.dtblReports.Columns[j].ColumnName;
                txtColumn = new DataGridViewTextBoxColumn();
                txtColumn.DataPropertyName = ColumnName;
                txtColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                txtColumn.Tag = ColumnName.Remove(0, 1);
                if (j % 2 == 0)
                {
                    txtColumn.HeaderText = "不良率";
                    txtColumn.DefaultCellStyle.Format = "0.####%";
                }
                else
                {

                    txtColumn.HeaderText = "不良数";
                    txtColumn.DefaultCellStyle.Format = "###,###.#####";
                }
                this.dgrdvReport.Columns.Add(txtColumn);

            }
            decimal TotalQty, BadQty;
            object objBadQty;
            DataRow drowNew;
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
                    objBadQty = dtblReports.Compute("SUM([" + this.dtblReports.Columns[j].ColumnName + "])", "");
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
        private void LoadProcessTypeXCompany()
        {
            DataGridViewTextBoxColumn txtColumn;
            string ColumnName = string.Empty;
            while (this.dgrdvProcessType .ColumnCount > iOutSrcRptIndex )
            {
                this.dgrdvProcessType.Columns.RemoveAt(iOutSrcRptIndex);
            }
            DateTime DateBegin = this.ctrlBetweenDate.DateBegin.Date;
            DateTime DateEnd = this.ctrlBetweenDate.DateEnd.Date;
            this.dtblProcessTypeRpt  = this.accReportItems.GetDataOutSrcBadReportItemsProcessTypeRptPivotCompanyBetweenDate (DateBegin,
                DateEnd).Tables[0];
            DataRow drowNew;
            for (int j = iOutSrcRptIndex; j < this.dtblProcessTypeRpt .Columns.Count; j++)
            {
                ColumnName = this.dtblProcessTypeRpt.Columns[j].ColumnName;
                txtColumn = new DataGridViewTextBoxColumn();
                txtColumn.DataPropertyName = ColumnName;
                txtColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                txtColumn.Tag = ColumnName.Remove(0, 1);
                if (j % 2 == 0)
                {
                    txtColumn.HeaderText = "不良数";
                    txtColumn.DefaultCellStyle.Format = "###,###.#####";
                  
                }
                else
                {
                    txtColumn.HeaderText = "不良率";
                    txtColumn.DefaultCellStyle.Format = "0.####%";
                }
                this.dgrdvProcessType.Columns.Add(txtColumn);

            }
            decimal TotalQty, BadQty;
            object objBadQty;
            if (this.dtblProcessTypeRpt .Rows.Count > 0)
            {
                drowNew = this.dtblProcessTypeRpt .NewRow();
                drowNew["ProcessTypeName"] = "合计";
                TotalQty = (decimal)dtblProcessTypeRpt.Compute("SUM(Quantity)", "");
                drowNew["Quantity"] = TotalQty;
                BadQty = (decimal)dtblProcessTypeRpt.Compute("SUM(BadQty)", "");
                drowNew["BadQty"] = BadQty;
                drowNew["BadRate"] = BadQty / TotalQty;
                for (int j = iOutSrcRptIndex ; j < this.dtblProcessTypeRpt.Columns.Count; j = j + 2)
                {
                    objBadQty = this.dtblProcessTypeRpt.Compute("SUM([" + this.dtblProcessTypeRpt.Columns[j].ColumnName + "])", "");
                    if (objBadQty != DBNull.Value)
                    {
                        drowNew[j] = objBadQty;
                        drowNew[j + 1] = (decimal)objBadQty / TotalQty;
                    }
                }
                this.dtblProcessTypeRpt.Rows.Add(drowNew);
            }
            this.dgrdvProcessType.DataSource = this.dtblProcessTypeRpt;
        }
        private void LoadData()
        {
          
            this.LoadItemXCompany();
            this.LoadProcessTypeXCompany();
            
        }
        void btnExport_Click(object sender, EventArgs e)
        {

            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "委外品检报告");
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