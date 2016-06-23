using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.QC.Report
{
    public partial class FrmManufBadReport : Form
    {
        public FrmManufBadReport()
        {
            InitializeComponent();
            this.dgrdvReport.AutoGenerateColumns = false;
            this.dgrdvRecord.AutoGenerateColumns = false;
            this.dgrdvProcessType.AutoGenerateColumns = false;
            this.accReportItems = new JERPData.Manufacture.ManufBadReportItems();
            this.accProcessType = new JERPData.Manufacture.ProcessType();
            this.accBadType = new JERPData.Product.BadType();
            this.gridhelper = new JCommon.DataGridViewHelper();

            this.SetPermit();
        }
        private JERPData.Manufacture.ManufBadReportItems  accReportItems;
        private JERPData.Manufacture.ProcessType  accProcessType;
        private JERPData.Product.BadType accBadType;
        private JCommon.DataGridViewHelper gridhelper;
        private DataTable dtblRecords,dtblReports,dtblProcessTypeRpt,dtblProcessTypes,dtblBadTypes;
        private const int iRecordIndex = 9;
        private const int iReportIndex =8;
        private const int iManufRptIndex = 4;
        //权限码
        private bool enableBrowse = false;//浏览
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(182);
            if (this.enableBrowse)
            {
                this.dtblProcessTypes = this.accProcessType.GetDataProcessType ().Tables[0];
                this.dtblBadTypes = this.accBadType.GetDataBadType().Tables[0];
                this.ctrlBetweenDate .DateBegin =new DateTime (DateTime.Now .Year ,
                    DateTime.Now.Month ,1);
                this.dgrdvReport.CellPainting += new DataGridViewCellPaintingEventHandler(dgrdvReport_CellPainting);
                this.dgrdvProcessType.CellPainting += new DataGridViewCellPaintingEventHandler(dgrdvProcessType_CellPainting);
                this.ctrlBetweenDate .DateEnd =DateTime .Now .Date ;
                this.ctrlBetweenDate .AffterEnter +=this.LoadData;
                this.LoadData();
                this.ctrlGridFind.SeachGridView = this.dgrdvRecord;
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
            int ProcessTypeID = int.Parse(this.dgrdvReport.Columns[icol].Tag.ToString ());
            string ProcessTypeName = this.GetProcessTypeName(ProcessTypeID);
            if (icol % 2 == 0)
            {

                this.gridhelper.MerageColumnHeaderSpan(
                  this.dgrdvReport, e,
                  icol , icol+1,
                  ProcessTypeName);
            }
            if (icol % 2 == 1)
            {
                this.gridhelper.MerageColumnHeaderSpan(
                       this.dgrdvReport, e,
                       icol-1, icol,
                       ProcessTypeName);
            }
           
            
        }
        void dgrdvProcessType_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            int icol = e.ColumnIndex;
            int irow = e.RowIndex;
            if ((irow > -1) || (icol < iManufRptIndex )) return;
            int BadTypeID = int.Parse(this.dgrdvProcessType .Columns[icol].Tag.ToString());
            string BadTypeName = this.GetBadTypeName(BadTypeID);
            if (icol % 2 == 0)
            {
                this.gridhelper.MerageColumnHeaderSpan(
                       this.dgrdvProcessType , e,
                       icol - 1, icol,
                       BadTypeName);
            }
            if (icol % 2 == 1)
            {
                this.gridhelper.MerageColumnHeaderSpan(
                     this.dgrdvProcessType, e,                   
                     icol, icol + 1,
                     BadTypeName);
            }
        }
      
        void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataGridView dgrdv =( DataGridView) (this.tabMain.SelectedTab.Controls[0]);
            this.ctrlGridFind.SeachGridView = dgrdv;
        }

        private string  GetProcessTypeName(int ProcessTypeID)
        {
            DataRow[] drows = this.dtblProcessTypes.Select("ProcessTypeID=" + ProcessTypeID.ToString () );
            if (drows.Length > 0)
            {
                return drows[0]["ProcessTypeName"].ToString ();
            }
            return string.Empty;
        }
        private string GetBadTypeName(int BadTypeID)
        {
            DataRow[] drows = this.dtblBadTypes.Select("BadTypeID=" + BadTypeID.ToString());
            if (drows.Length > 0)
            {
                return drows[0]["BadTypeName"].ToString();
            }
            return string.Empty;
        }
        private void LoadRecord()
        {
            DataGridViewTextBoxColumn txtColumn;
            string ColumnName = string.Empty;
            while (this.dgrdvRecord.ColumnCount > iRecordIndex)
            {
                this.dgrdvRecord.Columns.RemoveAt(iRecordIndex);
            }
            DateTime DateBegin = this.ctrlBetweenDate.DateBegin.Date;
            DateTime DateEnd = this.ctrlBetweenDate.DateEnd.Date;
            this.dtblRecords = this.accReportItems.GetDataManufBadReportItemsPivotBadTypeBetweenDate(
                DateBegin, DateEnd).Tables[0];
            for (int j = iRecordIndex; j < this.dtblRecords.Columns.Count; j++)
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

        }
        private void LoadReport()
        {
            DataGridViewTextBoxColumn txtColumn;
            string ColumnName = string.Empty; 
            DateTime DateBegin = this.ctrlBetweenDate.DateBegin.Date;
            DateTime DateEnd = this.ctrlBetweenDate.DateEnd.Date;
            while (this.dgrdvReport.ColumnCount > iReportIndex)
            {
                this.dgrdvReport.Columns.RemoveAt(iReportIndex);
            }
            this.dtblReports = this.accReportItems.GetDataManufBadReportItemsPrdRptPivotProcessTypeBetweenDate(DateBegin,
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
                    txtColumn.HeaderText = "不良数";
                    txtColumn.DefaultCellStyle.Format = "###,###.#####";
                }
                else
                {                  

                    txtColumn.HeaderText = "不良率";
                    txtColumn.DefaultCellStyle.Format = "0.####%";
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
        private void LoadProcessTypeRpt()
        {
            DataGridViewTextBoxColumn txtColumn;
            string ColumnName = string.Empty;
            while (this.dgrdvProcessType .ColumnCount > iManufRptIndex )
            {
                this.dgrdvProcessType.Columns.RemoveAt(iManufRptIndex);
            }
            DateTime DateBegin = this.ctrlBetweenDate.DateBegin.Date;
            DateTime DateEnd = this.ctrlBetweenDate.DateEnd.Date;
            this.dtblProcessTypeRpt  = this.accReportItems.GetDataManufBadReportItemsProcessTypeRptPivotBadTypeBetweenDate (DateBegin,
                DateEnd).Tables[0];
            DataRow drowNew;
            for (int j = iManufRptIndex; j < this.dtblProcessTypeRpt .Columns.Count; j++)
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
                for (int j = iManufRptIndex ; j < this.dtblProcessTypeRpt.Columns.Count; j = j + 2)
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
            this.LoadRecord();
            this.LoadReport();
            this.LoadProcessTypeRpt();
            
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