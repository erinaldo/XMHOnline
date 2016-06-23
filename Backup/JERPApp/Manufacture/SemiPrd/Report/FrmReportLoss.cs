using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture.SemiPrd.Report
{
    public partial class FrmReportLoss : Form
    {
        public FrmReportLoss()
        {
            InitializeComponent();
            this.dgrdvReport.AutoGenerateColumns = false;
            this.dgrdvRecord.AutoGenerateColumns = false;
            this.accReportItems = new JERPData.SemiPrd .ReportLossItems();
            this.SetPermit();
        }
        private JERPData.SemiPrd .ReportLossItems   accReportItems;
        private DataTable dtblRecords,dtblReports;
        private const int iReportIndex = 1;
        //权限码
        private bool enableBrowse = false;//浏览
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(384);
            if (this.enableBrowse)
            {
                this.ctrlBetweenDate .DateBegin =new DateTime (DateTime.Now .Year ,
                    DateTime.Now.Month ,1);           
                this.ctrlBetweenDate .DateEnd =DateTime .Now .Date ;
                this.ctrlBetweenDate .AffterEnter +=this.LoadData;
                this.LoadData();
                this.ctrlGridFind.SeachGridView = this.dgrdvRecord;
                this.tabMain.SelectedIndexChanged += new EventHandler(tabMain_SelectedIndexChanged);             
                this.btnExport.Click += new EventHandler(btnExport_Click);
            }

        }
      
        void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataGridView dgrdv =( DataGridView) (this.tabMain.SelectedTab.Controls[0]);
            this.ctrlGridFind.SeachGridView = dgrdv;
        }

       
        private void LoadData()
        {
            DataGridViewTextBoxColumn txtColumn;
          
            DateTime DateBegin=this.ctrlBetweenDate .DateBegin.Date ;
            DateTime DateEnd=this.ctrlBetweenDate .DateEnd.Date;
            this.dtblRecords = this.accReportItems.GetDataReportLossItemsRecord  (
                DateBegin, DateEnd).Tables[0];   
            this.dgrdvRecord.DataSource = dtblRecords;        
            while (this.dgrdvReport .ColumnCount >iReportIndex )
            {
                this.dgrdvReport.Columns.RemoveAt(iReportIndex);
            }
          
            this.dtblReports = this.accReportItems.GetDataReportLossItemsProcessTypePivotBadType (DateBegin,
                DateEnd).Tables[0];
            string ColumnName = string.Empty;
            for (int j = iReportIndex; j < this.dtblReports.Columns.Count; j++)
            {
                ColumnName = this.dtblReports.Columns[j].ColumnName;
                txtColumn = new DataGridViewTextBoxColumn();
                txtColumn.DataPropertyName = ColumnName;
                txtColumn.HeaderText = ColumnName;
                txtColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;               
                this.dgrdvReport .Columns.Add(txtColumn);
              
            }
         
            if (this.dtblReports.Rows.Count > 0)
            {
                DataRow drowNew = this.dtblReports.NewRow();
                drowNew["ProcessTypeName"] = "合计";
                for (int j = iReportIndex; j < this.dtblReports.Columns.Count; j++)
                {
                    ColumnName = this.dtblReports.Columns[j].ColumnName;
                    drowNew[ColumnName] = dtblReports.Compute("SUM([" + ColumnName + "])", "");                  
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
            excel.SetCellVal("D1", "产线报废报告");
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