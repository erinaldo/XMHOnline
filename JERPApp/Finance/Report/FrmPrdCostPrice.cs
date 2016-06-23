using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Report
{
    public partial class FrmPrdCostPrice : Form
    {
        public FrmPrdCostPrice()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accPrds = new JERPData.Product.Product();
            this.SetPermit();
        }
        private JERPData.Product.Product accPrds;
        private DataTable dtblPrds;
        private FrmPrdCostPriceDetail frmDetail;
        //权限码
        private bool enableBrowse = false;//浏览
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(364);
            if (this.enableBrowse)
            {
                this.ctrlPrdTypeID.AffterSelected += this.LoadData;
                this.LoadData();
                this.dgrdv.ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
                this.btnExport .Click +=new EventHandler(btnExport_Click);
            }
        }

        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }

        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnManufProcessCostPriceList.Name)
            {
                int PrdID = (int)this.dtblPrds.DefaultView[irow]["PrdID"];
                if (this.frmDetail == null)
                {
                    this.frmDetail = new FrmPrdCostPriceDetail();
                    new FrmStyle(this.frmDetail).SetPopFrmStyle(this);
                }
                this.frmDetail.PrdDetail(PrdID);
                this.frmDetail.ShowDialog();
            }
        }
        private void LoadData()
        {
            this.dtblPrds = this.accPrds.GetDataProductByPrdTypeID(this.ctrlPrdTypeID.PrdTypeID).Tables[0];
            this.dgrdv.DataSource = this.dtblPrds;
        }
        void btnExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成Excel文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "产品成本一览");
            excel.SetCellVal("A2", "类别:"+this.ctrlPrdTypeID .PrdTypeName );
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