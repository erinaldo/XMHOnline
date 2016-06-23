using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Supply.Material.Report
{
    public partial class FrmPONonFinished : Form
    {
        public FrmPONonFinished()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accOrderItems = new JERPData.Material.BuyOrderItems(); 
            this.SetPermit();
        }

        private JERPData.Material.BuyOrderItems accOrderItems;
        private DataTable dtblItems;
        private JERPApp.Define.General.FrmSupplier frmSupplier;
        //权限码
        private bool enableBrowse = false;//浏览
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(266);
            if (this.enableBrowse)
            {
                this.LoadData();
                this.ctrlQFind.BeforeFilter += this.LoadData;
                this.dgrdv.ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                this.btnExplore.Click += new EventHandler(btnExplore_Click);
                this.ckbMyOrder.CheckedChanged += new EventHandler(ckbMyOrder_CheckedChanged);
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
            }
        }

        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex ;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnCompanyAbbName.Name)
            {
                if (frmSupplier == null)
                {
                    frmSupplier = new JERPApp.Define.General.FrmSupplier();
                    new FrmStyle(frmSupplier).SetPopFrmStyle(this);                    
                }
                frmSupplier.Detail((int)this.dtblItems.DefaultView[irow]["CompanyID"]);
                frmSupplier.ShowDialog();
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