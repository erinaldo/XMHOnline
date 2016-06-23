using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.OtherRes.Report
{
    public partial class FrmDeptPrdReport : Form
    {
        public FrmDeptPrdReport()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accStore = new JERPData.OtherRes.Store();
            this.btnExplore.Click += new EventHandler(btnExplore_Click);
        }  
        private JERPData.OtherRes.Store accStore;
        private DataTable dtblReport;
        public  void LoadData(int DeptID,string DeptName,DateTime DateBegin,DateTime DateEnd)
        {
            this.txtDeptName.Text = DeptName;
            this.txtDateBegin.Text = DateBegin.ToShortDateString();
            this.txtDateEnd.Text = DateEnd.ToShortDateString();
            this.dtblReport = this.accStore.GetDataStoreDeptPrdReport (DeptID,DateBegin ,DateEnd).Tables[0];
            this.dgrdv.DataSource = this.dtblReport;
        }
        void btnExplore_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "部门存货报表");
            excel.SetCellVal("A2", "部门:" + this.txtDeptName .Text +" 开始日期:"+this.txtDateBegin .Text +" 截止日期:"+this.txtDateEnd .Text );
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            FrmMsg.Hide();
            excel.Show();
        }
    }
}