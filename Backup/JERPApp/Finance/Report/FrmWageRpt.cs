using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Report
{
    public partial class FrmWageRpt : Form
    {
        public FrmWageRpt()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.CreateColumn();
            this.accWageItems = new JERPData.Finance.WageItems();
            this.SetPermit();
        }
        private JERPData.Finance.WageItems accWageItems;
        private DataTable dtblReport;
        private FrmWageRecord frmRecord;
        private FrmWagePsnRecord frmPsnRecord;
        //权限码
        private bool enableBrowse = false;//浏览
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(325);
            if (this.enableBrowse)
            {
                this.dgrdv.ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                this.ctrlYear.Year = DateTime.Now.Year;
                this.ctrlYear.OnSelected += this.LoadData;
                this.LoadData();
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);

                frmPsnRecord = new FrmWagePsnRecord();
                new FrmStyle(this.frmPsnRecord).SetPopFrmStyle(this);

                frmRecord = new FrmWageRecord();
                new FrmStyle(this.frmRecord).SetPopFrmStyle(this);
            }

        }
        private void LoadData()
        {
            this.dtblReport = this.accWageItems.GetDataWageItemsPsnWagePivotMonth(this.ctrlYear.Year).Tables[0];
            string exp = string.Empty;           
           
            if (this.dtblReport.Rows.Count > 0)
            {
                DataRow drowNew = this.dtblReport.NewRow();
                drowNew["PsnID"] = -1;
                drowNew["PsnCode"] = "合计";
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
        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].GetType ().Equals (typeof (DataGridViewLinkColumn )))
            {
                int PsnID = (int)this.dtblReport .DefaultView[irow]["PsnID"];
                string PsnName=this.dtblReport .DefaultView[irow]["PsnName"].ToString ();
                int Month = (int)this.dgrdv.Columns[icol].Tag;
                int Year = this.ctrlYear.Year;            
                if (PsnID == -1)
                {
                    if (Month == -1)
                    {
                        frmRecord.YearRecord(Year);
                        frmRecord.ShowDialog();
                    }
                    else
                    {
                        frmRecord.MonthRecord(Year, Month);
                        frmRecord.ShowDialog();
                    }
                }
                else
                {
                    if (Month == -1)
                    {
                        frmPsnRecord.YearRecord(Year, PsnID, PsnName);
                        frmPsnRecord.ShowDialog();
                    }
                    else
                    {
                        frmPsnRecord.MonthRecord (Year,Month,PsnID, PsnName);
                        frmPsnRecord.ShowDialog();
                    }
                }
            }
        }
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
                lnk.Tag = j;
                this.dgrdv.Columns.Add(lnk);
            }
            lnk = new DataGridViewLinkColumn();
            lnk.HeaderText = "合计";
            lnk.DataPropertyName ="TotalWage";
            lnk.DefaultCellStyle.Format = "#,###.####";
            lnk.Width = 70;
            lnk.Tag = -1;
            this.dgrdv.Columns.Add(lnk);
            this.ctrlQFind.SeachGridView = this.dgrdv;
        }
       
    }
}