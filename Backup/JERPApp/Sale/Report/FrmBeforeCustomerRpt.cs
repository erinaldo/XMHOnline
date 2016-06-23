using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Sale.Report
{
    public partial class FrmBeforeCustomerRpt : Form
    {
        public FrmBeforeCustomerRpt()
        {
            InitializeComponent();
            this.dgrdvProcess.AutoGenerateColumns = false;
            this.dgrdvRegister.AutoGenerateColumns = false;
            this.accCustomer = new JERPData.General.PotentialCustomer();
            this.accProcessTypes = new JERPData.General.CustomerProcessType();
            this.SetPermit();
        }
        private JERPData.General.PotentialCustomer accCustomer;
        private JERPData.General.CustomerProcessType accProcessTypes;
        private DataTable dtblProcessRpt,dtblRegisterRpt, dtblProcessType;
        //权限码
        private bool enableBrowse = false;//浏览
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(638);
            if (this.enableBrowse)
            {
                this.CreateColumn();
                this.ctrlQFind.SeachGridView = this.dgrdvProcess;
                this.LoadData();
                this.btnExport.Click += new EventHandler(btnExport_Click);
                this.tabMain.SelectedIndexChanged += new EventHandler(tabMain_SelectedIndexChanged);
             
            }
        }

        void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage page = this.tabMain.SelectedTab;
            DataGridView dgrdv = (DataGridView)page.Controls[0];
            this.ctrlQFind.SeachGridView = dgrdv;
        }
        private void LoadData()
        {
            this.dtblProcessRpt = this.accCustomer.GetDataPotentialCustomerPsnProcessRpt().Tables[0];
            this.dgrdvProcess.DataSource = this.dtblProcessRpt;

            this.dtblRegisterRpt = this.accCustomer.GetDataPotentialCustomerPsnRegisterMonthRpt(DateTime.Now.Year).Tables[0];
            this.dgrdvRegister.DataSource = this.dtblRegisterRpt;

        }
        void btnExport_Click(object sender, EventArgs e)
        {
            TabPage page = this.tabMain.SelectedTab;
            DataGridView dgrdv = (DataGridView)page.Controls[0];
            FrmMsg.Show("正在生成Excel文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", page.Text );
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            excel.SetRangeAutoFit(3, 1, rowIndex, colIndex, true, true);
            FrmMsg.Hide();
            excel.Show();
        }
        private void CreateColumn()
        {
            this.dtblProcessType = this.accProcessTypes.GetDataCustomerProcessType().Tables[0];
            DataGridViewTextBoxColumn txt;
            foreach (DataRow drow in this.dtblProcessType.Rows)
            {
                txt = new DataGridViewTextBoxColumn();
                txt.DataPropertyName = drow["ProcessTypeID"].ToString();
                txt.HeaderText = drow["ProcessTypeName"].ToString();
                txt.Width = 80;
                this.dgrdvProcess.Columns.Add(txt);
            }
            txt = new DataGridViewTextBoxColumn();
            txt.DataPropertyName = "-1";
            txt.HeaderText = "合计";
            this.dgrdvProcess.Columns.Add(txt);

            for (int j = 1; j < 13; j++)
            {
                txt = new DataGridViewTextBoxColumn();
                txt.DataPropertyName = j.ToString();
                txt.HeaderText = j.ToString() + "月";
                txt.Width = 54;
                this.dgrdvRegister .Columns.Add(txt);
            }
            txt = new DataGridViewTextBoxColumn();
            txt.DataPropertyName = "13";
            txt.HeaderText = "合计";
            this.dgrdvRegister.Columns.Add(txt);
        }
    }
}