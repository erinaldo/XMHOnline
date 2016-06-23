using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Material.Report
{
    public partial class FrmOutStoreDayRpt : Form
    {
        public FrmOutStoreDayRpt()
        {
            InitializeComponent();
            this.accOutStoreItems = new JERPData.Material.OutStoreItems();
            this.SetPermit();
        }
        private JERPData.Material.OutStoreItems accOutStoreItems;
        private DataTable dtblRpt;
        //权限码
        private bool enableBrowse = false;//浏览
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(330);
            if (this.enableBrowse)
            {
                this.ctrlYear.Year = DateTime.Now.Year;
                this.ctrlMonth.Month = DateTime.Now.Month;
                this.ctrlYear.OnSelected += this.LoadData;
                this.ctrlMonth.OnSelected += this.LoadData;
                this.CreateGridColumn();
                this.ctrlQFind.SeachGridView = this.dgrdv;
                this.LoadData();
                this.btnExport .Click += new EventHandler(btnExport_Click); 
            }


        }
        private void CreateGridColumn()
        {
            this.dgrdv.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn txtcolumn;
            txtcolumn = new DataGridViewTextBoxColumn();
            txtcolumn.DataPropertyName = "PrdCode";
            txtcolumn.HeaderText = "物料编号";
            txtcolumn.Width = 100;
            txtcolumn.Frozen = true;
            this.dgrdv.Columns.Add(txtcolumn);

            txtcolumn = new DataGridViewTextBoxColumn();
            txtcolumn.DataPropertyName = "PrdName";
            txtcolumn.HeaderText = "物料名称";
            txtcolumn.Width = 80;
            txtcolumn.Frozen = true;
            this.dgrdv.Columns.Add(txtcolumn);
         
            txtcolumn = new DataGridViewTextBoxColumn();
            txtcolumn.DataPropertyName = "PrdName";
            txtcolumn.HeaderText = "物料规格";
            txtcolumn.Width = 100;
            txtcolumn.Frozen = true;
            this.dgrdv.Columns.Add(txtcolumn);

            txtcolumn = new DataGridViewTextBoxColumn();
            txtcolumn.DataPropertyName = "Model";
            txtcolumn.HeaderText = "机型";
            txtcolumn.Width = 66;
            txtcolumn.Frozen = true;
            this.dgrdv.Columns.Add(txtcolumn);
       
            txtcolumn = new DataGridViewTextBoxColumn();
            txtcolumn.DataPropertyName = "Manufacturer";
            txtcolumn.HeaderText = "品牌";
            txtcolumn.Width = 66;
            txtcolumn.Frozen = true;
            this.dgrdv.Columns.Add(txtcolumn);

            for (int j = 1; j < 32; j++)
            {
                txtcolumn = new DataGridViewTextBoxColumn();
                txtcolumn.DataPropertyName = j.ToString();
                txtcolumn.HeaderText = j.ToString ()+"日";
                txtcolumn.Width = 66;
                this.dgrdv.Columns.Add(txtcolumn);
            }
            txtcolumn = new DataGridViewTextBoxColumn();
            txtcolumn.DataPropertyName = "Total";
            txtcolumn.HeaderText = "合计";
            txtcolumn.Width = 66;
            this.dgrdv.Columns.Add(txtcolumn);
        }
        private void LoadData()
        {
            string totalexp = "";
            for (int j = 1; j < 32; j++)
            {
                totalexp += "+ISNULL([" + j.ToString() + "],0)";
            }
          
            this.dtblRpt = this.accOutStoreItems.GetDataOutStoreItemsPivotDay (this.ctrlYear.Year,this.ctrlMonth .Month ).Tables[0];
            this.dtblRpt.Columns.Add("Total", typeof(decimal), totalexp);
            if (this.dtblRpt.Rows.Count > 0)
            {
                DataRow drowNew = this.dtblRpt.NewRow();
                drowNew["Manufacturer"] = "合计";
                for (int j = 1; j < 32; j++)
                {
                    drowNew[j.ToString()] = this.dtblRpt.Compute("SUM([" + j.ToString() + "])", "");
                }
                this.dtblRpt.Rows.Add(drowNew);
            }
           
            this.dgrdv.DataSource = this.dtblRpt;
        }
     


        void btnExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "生产领料日报");        
            excel.SetCellVal("A2", "年份:" + this.ctrlYear.Year .ToString ()+" 月份:"+this.ctrlMonth .Month .ToString ());
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(this.dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            FrmMsg.Hide();
            excel.Show();
        }
    }
}