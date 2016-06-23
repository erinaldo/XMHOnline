using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Sale.Report
{
    public partial class FrmDeliverMonthRpt : Form
    {
        public FrmDeliverMonthRpt()
        {
            InitializeComponent();
            this.dgrdvCustomerAMT.AutoGenerateColumns = false;
            this.dgrdvPrdAMT.AutoGenerateColumns = false;
            this.dgrdvPrdQty.AutoGenerateColumns = false;
            this.accDeliverItems = new JERPData.Product.SaleDeliverItems();
            this.SetPermit();
        }
        private JERPData.Product.SaleDeliverItems accDeliverItems; 
        private DataTable dtblPrdQty,dtblPrdAMT,dtblCustomer;
        //权限码
        private bool enableBrowse = false;//浏览
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(33);
            if (this.enableBrowse)
            {
                this.CreateColumn(this.dgrdvPrdQty);
                this.CreateColumn(this.dgrdvPrdAMT);
                this.CreateColumn(this.dgrdvCustomerAMT);
                this.ctrlQFind.SeachGridView = this.dgrdvPrdQty ;
                this.ctrlSpot.SeachGridView = this.dgrdvPrdQty;
                this.ctrlYear.Year = DateTime.Now.Year;
                this.tabMain.SelectedIndexChanged += new EventHandler(tabMain_SelectedIndexChanged);
                //加载数据               
                this.ctrlYear.OnSelected += this.LoadData;
                this.LoadData();
                this.btnExplore.Click += new EventHandler(btnExplore_Click);                
            }
        }

      
        private void CreateColumn(DataGridView dgrdv)
        {
            DataGridViewTextBoxColumn txt;
            for (int j = 1; j <= 12; j++)
            {
                txt = new DataGridViewTextBoxColumn();
                txt.Width = 66;
                txt.HeaderText = j.ToString() + "月";
                txt.DataPropertyName = j.ToString();
                dgrdv.Columns.Add(txt);
            }
            txt = new DataGridViewTextBoxColumn();
            txt.Width = 70;
            txt.HeaderText = "合计";
            txt.DataPropertyName = "13";
            dgrdv.Columns.Add(txt);
        }

        private void LoadData()
        {
            string exp=string.Empty ;
           
            this.dtblPrdQty = this.accDeliverItems.GetDataSaleDeliverItemsPrdQtyPivotMonth(this.ctrlYear.Year).Tables[0];
            
            this.dgrdvPrdQty.DataSource = this.dtblPrdQty;

            this.dtblPrdAMT = this.accDeliverItems.GetDataSaleDeliverItemsPrdAMTPivotMonth (this.ctrlYear.Year).Tables[0];
           
            this.dgrdvPrdAMT.DataSource = this.dtblPrdAMT ;


            this.dtblCustomer  = this.accDeliverItems.GetDataSaleDeliverItemsSaleAMTPivotMonth(this.ctrlYear.Year).Tables[0];
            
            this.dgrdvCustomerAMT.DataSource = this.dtblCustomer;

        }
        void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataGridView dgrdv = (DataGridView)this.tabMain.SelectedTab.Controls[0];
            this.ctrlQFind.SeachGridView = dgrdv;
            this.ctrlSpot.SeachGridView = dgrdv;
        }
        void btnExplore_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1",this.ctrlYear .Year .ToString ()+"年"+this.tabMain .SelectedTab .Text +"月销售报表");         
            int rowIndex = 3;
            int colIndex = 1;
            DataGridView dgrdv = (DataGridView)this.tabMain.SelectedTab.Controls[0];
            excel.ImportGridData(dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            FrmMsg.Hide();
            excel.Show();
        }
    }
}