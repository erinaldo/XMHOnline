using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Sale.Report
{
    public partial class FrmSaleOrderItemMonthRpt : Form
    {
        public FrmSaleOrderItemMonthRpt()
        {
            InitializeComponent();
            this.dgrdvTotal.AutoGenerateColumns = false;
            this.dgrdvPrdTotal .AutoGenerateColumns =false;
            this.accOrderItems = new JERPData.Product.SaleOrderItems();
             this.SetPermit();
        }

       
        private DataTable dtblCoReport,dtblPrdTotalRpt;
        private JERPData.Product.SaleOrderItems accOrderItems;
        private bool enableBrowse = false;
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(32);
            if (this.enableBrowse)
            {
                this.ctrlYearSel.Year = DateTime.Now.Year;
                this.ctrlYearSel.OnSelected += this.LoadData;
                this.btnPrint.Click += new EventHandler(btnPrint_Click);
                this.btnPrintAll.Click += new EventHandler(btnPrintAll_Click);              
                this.tabMain.SelectedIndexChanged += new EventHandler(tabMain_SelectedIndexChanged);
                this.LoadData();
            }

        }
        private void LoadData()
        {
            //产品合计
            this.dtblPrdTotalRpt = this.accOrderItems.GetDataSaleOrderItemsMonthQtyPivotPrd(this.ctrlYearSel.Year).Tables[0];
            string exp = string.Empty;
            DataRow drowNew = this.dtblPrdTotalRpt.NewRow();
            drowNew["PrdCode"] = "合计";
            for (int j = 1; j < 13; j++)
            {
                exp += "+ISNULL([" + j.ToString() + "],0)";
                drowNew[j.ToString()] = this.dtblPrdTotalRpt.Compute("SUM([" + j.ToString() + "])", "");
            }
            this.dtblPrdTotalRpt.Rows.Add(drowNew);
            this.dtblPrdTotalRpt.Columns.Add("TotalQty", typeof(decimal), exp);
            DataGridViewTextBoxColumn col;
            col = new DataGridViewTextBoxColumn();
            col.DataPropertyName = "TotalQty";
            col.HeaderText = "合计";
            col.Width = 80;
            this.dgrdvPrdTotal.Columns.Add(col);
            this.dgrdvPrdTotal.DataSource = this.dtblPrdTotalRpt;
            this.ctrlQFind.SeachGridView = this.dgrdvPrdTotal;
            //公司合计

            this.dtblCoReport =this.accOrderItems .GetDataSaleOrderItemsMonthQtyPivotCompany (this.ctrlYearSel .Year).Tables[0];
            exp = string.Empty;
            drowNew = this.dtblCoReport.NewRow();
            drowNew["CompanyAbbName"] = "合计";
            for (int j = 1; j < 13; j++)
            {
                exp += "+ISNULL([" + j.ToString () + "],0)";
                drowNew[j.ToString()] = this.dtblCoReport.Compute("SUM([" + j.ToString() + "])", "");
            }
            this.dtblCoReport.Rows.Add(drowNew);
            this.dtblCoReport.Columns.Add("TotalQty", typeof(decimal),exp);            
          
            col = new DataGridViewTextBoxColumn();
            col.DataPropertyName = "TotalQty";
            col.HeaderText = "合计";
            col.Width = 80;
            this.dgrdvTotal.Columns.Add(col);
            this.dgrdvTotal.DataSource = this.dtblCoReport ;
            
            while (this.tabMain.TabCount > 2)
            {
                this.tabMain.TabPages.RemoveAt(2);
            }
            for(int irow=0;irow<this.dtblCoReport .Rows .Count -1;irow++)
            {
                DataRow drow = this.dtblCoReport.Rows[irow];
                int CompanyID = (int)drow["CompanyID"];
                string CompanyAbbName = drow["CompanyAbbName"].ToString();
             
                DataTable dtbl = this.accOrderItems.GetDataSaleOrderItemsPrdMonthQtyPivotCompany(this.ctrlYearSel .Year ,CompanyID).Tables[0];
                JCommon.MyDataGridView dgrdv = new JCommon.MyDataGridView();           
                dgrdv.AutoGenerateColumns = false;
                dgrdv.ReadOnly = true;
                dgrdv.AllowUserToAddRows = false;
                dgrdv.Dock = DockStyle.Fill;
                new JCommon.MydbgrdvStyle(dgrdv).Decorate();

                col = new DataGridViewTextBoxColumn();
                col.HeaderText = "产品编号";
                col.Width = 80;
                col.DataPropertyName = "PrdCode";
                col.Frozen = true;
                dgrdv.Columns.Add(col);


                col = new DataGridViewTextBoxColumn();
                col.HeaderText = "产品名称";
                col.Width = 80;
                col.DataPropertyName = "PrdName";
                col.Frozen = true;
                dgrdv.Columns.Add(col);


                col = new DataGridViewTextBoxColumn();
                col.HeaderText = "产品规格";
                col.Width = 80;
                col.DataPropertyName = "PrdSpec";
                col.Frozen = true;
                dgrdv.Columns.Add(col);


                col = new DataGridViewTextBoxColumn();
                col.HeaderText = "机型";
                col.Width = 80;
                col.DataPropertyName = "Model";
                col.Frozen = true;
                dgrdv.Columns.Add(col);


                drowNew = dtbl.NewRow();
                drowNew["PrdCode"] = "合计";
                for (int j = 1; j < 13; j++)
                {
                    col = new DataGridViewTextBoxColumn();
                    col.HeaderText = j.ToString ()+"月";
                    col.Width = 80;
                    col.DataPropertyName = j.ToString ();
                    dgrdv.Columns.Add(col);
                    drowNew[j.ToString()] = dtbl.Compute("SUM([" + j.ToString() + "])", "");
                }
                dtbl.Rows.Add(drowNew);
                dtbl.Columns.Add("TotalQty", typeof(decimal), exp);    
                col = new DataGridViewTextBoxColumn();
                col.DataPropertyName = "TotalQty";
                col.HeaderText = "合计";
                col.Width = 80;
                dgrdv.Columns.Add(col);

                dgrdv.DataSource = dtbl;

                TabPage page = new TabPage();
                page.Text = CompanyAbbName ;
                page.Controls.Add(dgrdv);
              
                tabMain.TabPages.Add(page);


            }          
            this.ctrlTabNav.NavTabControl = this.tabMain;

        }
        void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabMain.SelectedTab == null) return;
            DataGridView dgrdv = (DataGridView)this.tabMain.SelectedTab.Controls[0];
            this.ctrlQFind.SeachGridView = dgrdv;
        }
        private void PrintCurrent(Office2003Helper.Excel2003 excel, int objSheet, TabPage page)
        {
            excel.SetCurSheet(objSheet);
            excel.SetCurSheetName(page.Text);
            excel.SetCellVal("D1", "客户月订单统计");
            DataGridView dgrdv = (DataGridView)page.Controls[0];
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeAutoFit(3, 1, rowIndex, colIndex, true, false);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
        }

        void btnPrint_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            TabPage page = this.tabMain.SelectedTab;
            this.PrintCurrent(excel, 1, page);
            excel.Show();
            FrmMsg.Hide();
        }
        void btnPrintAll_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            int sheetcount = excel.GetSheetsCount();
            if (sheetcount < this.tabMain.TabCount)
            {
                excel.NewSheetByCopy(1, tabMain.TabCount - sheetcount);
            }
            for (int i = 0; i < this.tabMain.TabCount; i++)
            {
                this.PrintCurrent(excel, i + 1, this.tabMain.TabPages[i]);
            }
            excel.SetCurSheet(1);
            excel.Show();
            FrmMsg.Hide();
        }
    }
}