using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Sale.Report
{
    public partial class FrmHandlerSaleOrderItem : Form
    {
        public FrmHandlerSaleOrderItem()
        {
            InitializeComponent();
            this.accItems = new JERPData.Product .SaleOrderItems();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.SetPermit();
        }
        private JERPData.Product.SaleOrderItems accItems;
        private JERPApp.Define.Product.FrmMySaleOrderItemSearchItem frmSearch = null;
        private DataTable dtblItems;
        private bool enableBrowse = false;       
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(400);
            if (this.enableBrowse)
            {
                this.lnkSearch.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkSearch_LinkClicked);
                this.btnExport.Click += new EventHandler(btnExport_Click);
            }
          
          
        }

     
        void lnkSearch_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (frmSearch == null)
            {
                frmSearch = new JERPApp.Define.Product.FrmMySaleOrderItemSearchItem();
                new FrmStyle(frmSearch).SetPopFrmStyle(this);
                frmSearch.AffterSearch +=frmSearch_AffterSearch;
            }
            frmSearch.ShowDialog();
        }

        void frmSearch_AffterSearch(string whereclasue)
        {
            whereclasue += " and (HandlePsnID=" + JERPBiz.Frame.UserBiz.PsnID.ToString() + ")";
            this.dtblItems = this.accItems.GetDataSaleOrderItemsFreeSearch(whereclasue).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
        }
     
        void btnExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("C1", "订单明细一览");
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(this.dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            excel.SetRangeAutoFit(3, 1, rowIndex, colIndex, true, false);
            FrmMsg.Hide();
            excel.Show();
        }

    }
}