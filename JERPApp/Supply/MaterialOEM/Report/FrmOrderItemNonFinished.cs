using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Supply.MaterialOEM.Report
{
    public partial class FrmOrderItemNonFinished : Form
    {
        public FrmOrderItemNonFinished()
        {
            InitializeComponent();
            this.accOrderItems = new JERPData.Material.OEMOrderItems();
            this.SetPermit();
        }
        private JERPData.Material.OEMOrderItems  accOrderItems;
        private DataTable dtblCompanys;
        //权限码
        private bool enableBrowse = false;//浏览
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(428);
            if (this.enableBrowse)
            {
                //建立起类别
                this.CreateTabPage();
                //加载数据
                LoadData();             
                this.btnExplore.Click += new EventHandler(btnExplore_Click);             
                this.tabMain.SelectedIndexChanged += new EventHandler(tabMain_SelectedIndexChanged);
                if (this.tabMain.TabCount > 0)
                {
                    this.tabMain_SelectedIndexChanged(this.tabMain, null);
                }
            }


        }

     
     
        private void CreateTabPage()
        {
            this.tabMain.TabPages.Clear();
            this.dtblCompanys = this.accOrderItems.GetDataOEMOrderItemsNonFinishedCompany ().Tables[0];
            JCommon.MyDataGridView dgrdv;
            DataGridViewTextBoxColumn txtcol;
            TabPage page;
            foreach (DataRow drow in this.dtblCompanys.Rows)
            {
                dgrdv = new JCommon.MyDataGridView();
                dgrdv.Dock = DockStyle.Fill;
                dgrdv.ReadOnly = true;
                dgrdv.AllowUserToAddRows = false;
                dgrdv.AllowUserToDeleteRows = false;
                dgrdv.AutoGenerateColumns = false;


                txtcol = new DataGridViewTextBoxColumn();
                txtcol.DataPropertyName = "PONo";
                txtcol.HeaderText = "订单编号";
                txtcol.Width = 80;
                dgrdv.Columns.Add(txtcol);



            
                txtcol = new DataGridViewTextBoxColumn();
                txtcol.DataPropertyName = "PrdCode";
                txtcol.HeaderText = "物料编号";
                txtcol.Width = 100;
                dgrdv.Columns.Add(txtcol);

                txtcol = new DataGridViewTextBoxColumn();
                txtcol.DataPropertyName = "PrdName";
                txtcol.HeaderText = "物料名称";
                txtcol.Width = 80;
                dgrdv.Columns.Add(txtcol);

                txtcol = new DataGridViewTextBoxColumn();
                txtcol.DataPropertyName = "PrdSpec";
                txtcol.HeaderText = "物料规格";
                txtcol.Width = 100;
                dgrdv.Columns.Add(txtcol);

                txtcol = new DataGridViewTextBoxColumn();
                txtcol.DataPropertyName = "Model";
                txtcol.HeaderText = "机型";
                txtcol.Width = 80;
                dgrdv.Columns.Add(txtcol);

                txtcol = new DataGridViewTextBoxColumn();
                txtcol.DataPropertyName = "Manufacturer";
                txtcol.HeaderText = "品牌";
                txtcol.Width = 66;
                dgrdv.Columns.Add(txtcol);

                txtcol = new DataGridViewTextBoxColumn();
                txtcol.DataPropertyName = "Quantity";
                txtcol.HeaderText = "P/O";
                txtcol.Width = 66;
                dgrdv.Columns.Add(txtcol);

                txtcol = new DataGridViewTextBoxColumn();
                txtcol.DataPropertyName = "FinishedQty";
                txtcol.HeaderText = "到货";
                txtcol.Width = 66;
                dgrdv.Columns.Add(txtcol);

                txtcol = new DataGridViewTextBoxColumn();
                txtcol.DataPropertyName = "NonFinishedQty";
                txtcol.HeaderText = "欠数";
                txtcol.Width = 66;
                dgrdv.Columns.Add(txtcol);

                txtcol = new DataGridViewTextBoxColumn();
                txtcol.DataPropertyName = "UnitName";
                txtcol.HeaderText = "单位";
                txtcol.Width = 54;
                dgrdv.Columns.Add(txtcol);

                page = new TabPage();
                page.Text = drow["CompanyAbbName"].ToString();
                page.Controls.Add(dgrdv);
                page.Tag = (int)drow["CompanyID"];
                this.tabMain.TabPages.Add(page);
            }
        }
        void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            JCommon.MyDataGridView dgrdv = (JCommon.MyDataGridView)this.tabMain .SelectedTab .Controls[0];
            this.ctrlQFind.SeachGridView = dgrdv;
        }

        private void LoadData()
        {
            foreach (TabPage page in this.tabMain.TabPages)
            {
                int CompanyID = (int)page.Tag;
                JCommon.MyDataGridView dgrdv = (JCommon.MyDataGridView)page.Controls[0];
                DataTable dtblItems = this.accOrderItems.GetDataOEMOrderItemsNonFinishedByCompanyID (CompanyID).Tables[0];
                dgrdv.DataSource = dtblItems;
            }         
        }
        void btnExplore_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "客供物料一览表");
            TabPage page = this.tabMain.SelectedTab;
            JCommon.MyDataGridView dgrdv = (JCommon.MyDataGridView)page.Controls[0];
            excel.SetCellVal("A2", "客户:"+page.Text);
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            FrmMsg.Hide();
            excel.Show();
        }


    }
}