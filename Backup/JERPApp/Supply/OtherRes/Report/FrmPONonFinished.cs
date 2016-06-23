using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Supply.OtherRes.Report
{
    public partial class FrmPONonFinished : Form
    {
        public FrmPONonFinished()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accOrderItems = new JERPData.OtherRes.BuyOrderItems();
            this.ctrlGridQFind.SeachGridView = this.dgrdv;
            this.SetPermit();
        }

        private JERPData.OtherRes.BuyOrderItems accOrderItems;
        private DataTable dtblItems;

        //权限码
        private bool enableBrowse = false;//浏览
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(497);
            if (this.enableBrowse)
            {
                this.LoadData();
                this.dgrdv.ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                this.btnExplore.Click += new EventHandler(btnExplore_Click);
                this.ckbMyOrder.CheckedChanged += new EventHandler(ckbMyOrder_CheckedChanged);
            }
        }

        void ckbMyOrder_CheckedChanged(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private void LoadData()
        {
            this.dtblItems = this.accOrderItems.GetDataBuyOrderItemsNonFinished ().Tables[0];           
            this.dgrdv.DataSource = this.dtblItems;
            if (this.ckbMyOrder.Checked)
            {
                DataRow[] drows = this.dtblItems.Select("MakerPsnID<>" + JERPBiz.Frame.UserBiz.PsnID.ToString ());
                foreach (DataRow drow in drows )
                {
                    this.dtblItems.Rows.Remove(drow);
                }
            }
        }

        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
        void btnExplore_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "P/O欠数一览");           
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