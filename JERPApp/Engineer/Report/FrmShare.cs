using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Engineer.Report
{
    public partial class FrmShare : Form
    {
        public FrmShare()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accBom = new JERPData.Product.BOM();
            this.grdhelper = new JCommon.DataGridViewHelper();
            this.SetPermit();
        }
        private JERPData.Product.BOM accBom;
        private DataTable dtblBom;
        private JCommon.DataGridViewHelper grdhelper;
        //权限码
        private bool enableBrowse = false;//浏览
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(72);
            if (this.enableBrowse)
            {
                this.LoadData ();
                this.dgrdv.CellPainting += new DataGridViewCellPaintingEventHandler(dgrdv_CellPainting);
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                this.dgrdv .ContextMenuStrip = this.cMenu;             
                this.btnExport.Click += new EventHandler(btnExport_Click);
            }
        }

        void dgrdv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if (irow == -1)
            {
                if ((icol == 0) || (icol == 1) || (icol == 2) || (icol == 3))
                {
                    this.grdhelper.MerageColumnHeaderSpan(this.dgrdv, e, 0, 3, "共用物料");
                }
                if ((icol == 4) || (icol == 5) || (icol == 6))
                {
                    this.grdhelper.MerageColumnHeaderSpan(this.dgrdv, e, 4, 6, "使用产品");
                }
              
            }
        }

        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
        private void LoadData()
        {
            this.dtblBom = this.accBom.GetDataBOMForShare().Tables[0];
            int prdid = -1;
            int lastprdid = -1;
            foreach (DataRow drow in this.dtblBom .Rows )
            {
                prdid = (int)drow["PrdID"];
                if (prdid == lastprdid)
                {
                    drow["PrdCode"] = DBNull.Value;
                    drow["PrdName"] = DBNull.Value;
                    drow["PrdSpec"] = DBNull.Value; 
                    drow["Manufacturer"] = DBNull.Value;
                }
                lastprdid = prdid;
            }
            this.dgrdv.DataSource = this.dtblBom;
        }
        void btnExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "物料共用表");
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(this.dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeAutoFit(3, 1, rowIndex, colIndex, true, false);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            excel.Show();
            FrmMsg.Hide();
        }
    }
}