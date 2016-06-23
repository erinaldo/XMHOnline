using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Sale.Report
{
    public partial class FrmSaleOrderItemNonFinished : Form
    {
        public FrmSaleOrderItemNonFinished()
        {
            InitializeComponent();
            this.accItems = new JERPData.Product.SaleOrderItems();
            this.dgrdv.AutoGenerateColumns = false; 
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.SetPermit();
        }
        private JERPData.Product.SaleOrderItems accItems;
        private DataTable dtblItems;
        private void LoadData()
        {
            FrmMsg.Show("正在加载数据，请稍候....");
          
            this.dtblItems = this.accItems.GetDataSaleOrderItemsNonFinished().Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
            foreach (DataRow drow in this.dtblItems.Rows)
            {
               
                int CompanyID = (int)drow["CompanyID"];
                if ((this.ckbCustomer.Checked)&&(CompanyID !=this.ctrlCustomerID .CompanyID ))
                {
                    drow.Delete();
                    continue;
                }

            }
            FrmMsg.Hide();
        }
        private bool enableBrowse = false;  
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(31);          
            if (this.enableBrowse)
            {
               
                this.dgrdv.ContextMenuStrip = this.cMenu;
                this.mRefresh.Click += new EventHandler(mRefresh_Click);
                this.LoadData();
                this.btnExport.Click += new EventHandler(btnExport_Click);
                this.ckbCustomer.CheckedChanged += new EventHandler(ckbCustomer_CheckedChanged);
                this.ctrlCustomerID.AffterSelected += new JERPApp.Define.General.CtrlCustomer.AffterSelectedDelegate(ctrlCustomerID_AffterSelected);
            }          
        }

     
        void ctrlCustomerID_AffterSelected()
        {
            if (this.ckbCustomer.Checked)
            {
                this.LoadData();
            }
        }

        void ckbCustomer_CheckedChanged(object sender, EventArgs e)
        {
            this.LoadData();
        }
        void btnExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在打印中，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter .TempletFolder  + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "P/O欠数一览表");         
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(this.dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            excel.SetRangeAutoFit(3, 1, rowIndex, colIndex, true, false);           
            excel.Show();
            FrmMsg.Hide();
        }
        void mRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }

    }
}