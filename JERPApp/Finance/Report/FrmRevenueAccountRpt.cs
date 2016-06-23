using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Report
{
    public partial class FrmRevenueAccountRpt : Form 
    {
        public FrmRevenueAccountRpt()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accRevenueAccount = new JERPData.Finance.RevenueAccount();
            this.CreateColumn();
            this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
            this.btnExport.Click += new EventHandler(btnExport_Click);
        }

     
        private JERPData.Finance.RevenueAccount accRevenueAccount;
        private FrmRevenueAccountRecord frmRecord;
        private DataTable dtblReport;
        private void CreateColumn()
        {
            DataGridViewLinkColumn lnk;
            for (int j = 1; j < 13; j++)
            {
                lnk = new DataGridViewLinkColumn();
                lnk.HeaderText = j.ToString() + "月";
                lnk.DataPropertyName = j.ToString();
                lnk.DefaultCellStyle.Format = "#,###.####";
                lnk.Width = 66;
                this.dgrdv.Columns.Add(lnk);
            }
            DataGridViewTextBoxColumn txt = new DataGridViewTextBoxColumn();
            txt.HeaderText = "合计";
            txt.DataPropertyName = "TotalWage";
            txt.DefaultCellStyle.Format = "#,###.####";
            txt.Width = 70;
            this.dgrdv.Columns.Add(txt);
            this.ctrlQFind.SeachGridView = this.dgrdv;
        }
       
        public  void LoadData()
        {
            this.dtblReport = this.accRevenueAccount.GetDataRevenueAccountRevenueRptPivotMonth(DateTime .Now .Year ).Tables[0];
            string exp = string.Empty;
            if (this.dtblReport.Rows.Count > 0)
            {
                DataRow drowNew = this.dtblReport.NewRow();
                drowNew["RevenueTypeID"] = -1;
                drowNew["RevenueTypeName"] = "合计";
                for (int j = 1; j < 13; j++)
                {
                    exp += "+ISNULL([" + j.ToString() + "],0)";
                    drowNew[j.ToString()] = this.dtblReport.Compute("SUM([" + j.ToString() + "])", "");
                }
                this.dtblReport.Rows.Add(drowNew);
            }
            this.dtblReport.Columns.Add("TotalWage", typeof(decimal), exp);
            this.dgrdv.DataSource = this.dtblReport;
        }
      
        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if(this.dgrdv .Columns [icol].GetType ().Equals (typeof (DataGridViewLinkColumn )))
            {
                int RevenueTypeID=(int)this.dtblReport .DefaultView [irow]["RevenueTypeID"];
                int Month = int.Parse(this.dgrdv.Columns[icol].DataPropertyName);
                if (frmRecord == null)
                {
                    frmRecord = new FrmRevenueAccountRecord();
                    new FrmStyle(frmRecord).SetPopFrmStyle(this);                   
                }
                frmRecord.AccountRecord(RevenueTypeID, DateTime .Now .Year ,
                    Month);
                frmRecord.ShowDialog();
            }
        }
        void btnExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成Excel文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", this.Text);
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
