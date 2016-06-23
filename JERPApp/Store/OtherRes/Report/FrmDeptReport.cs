using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.OtherRes.Report
{
    public partial class FrmDeptReport : Form
    {
        public FrmDeptReport()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accStore = new JERPData.OtherRes.Store();
            this.SetPermit();
        }
        private JERPData.OtherRes.Store accStore;
        private DataTable dtblReport;
        private FrmDeptPrdReport frmDetail;
        private bool enableBrowse = false;//浏览
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(586);
            if (this.enableBrowse)
            {
                //加载数据               
                int Year = DateTime.Now.Year;
                int Month = DateTime.Now.Month;
                this.ctrlBetweenDate.DateBegin = new DateTime(Year, Month, 1);
                this.ctrlBetweenDate.DateEnd = DateTime.Now.Date;
                this.LoadData();               
                this.btnExplore.Click += new EventHandler(btnExplore_Click);
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
            }
        }

        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].GetType().Equals(typeof(DataGridViewLinkColumn)))
            {
                DataRow drow = this.dtblReport .DefaultView[irow].Row;
                if (this.frmDetail  == null)
                {
                    this.frmDetail = new FrmDeptPrdReport();
                    new FrmStyle(frmDetail).SetPopFrmStyle(this);
                }
                this.frmDetail.LoadData ((int)drow["DeptID"],
                    drow["DeptName"].ToString (),
                     this.ctrlBetweenDate .DateBegin.Date  ,
                     this.ctrlBetweenDate .DateEnd.Date  );
                this.frmDetail.ShowDialog();
            }
        }
        private void LoadData()
        {
            this.dtblReport  = this.accStore.GetDataStoreDeptReport (this.ctrlBetweenDate .DateBegin ,
                this.ctrlBetweenDate .DateEnd ).Tables[0];
            this.dgrdv.DataSource = this.dtblReport;
        }
        void btnExplore_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "部门领用报表");
            excel.SetCellVal("A2", "开始日期:" +this.ctrlBetweenDate .DateBegin .ToShortDateString ()+"  截止日期:"+this.ctrlBetweenDate .DateEnd .ToShortDateString ());
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            FrmMsg.Hide();
            excel.Show();
        }
    }
}