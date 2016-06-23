using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Material.Report
{
    public partial class FrmOutSrcInventoryRpt : Form
    {
        public FrmOutSrcInventoryRpt()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accStores = new JERPData.Material.OutSrcStore ();
            this.SetPermit();
        }
        private JERPData.Material.OutSrcStore accStores;
        private FrmOutSrcSupplyItemRecord frmSupply;
        private FrmOutSrcInventoryRecord frmRecord;
        private DataTable dtblRpt;
        //权限码
        private bool enableBrowse = false;//浏览 
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(519);
            if (this.enableBrowse)
            {
                this.dtpDateBegin.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                this.dtpDateEnd.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddSeconds(-1);
                this.LoadData();
                this.ctrlSupplierID.AffterSelected += this.LoadData;
                this.dtpDateBegin.ValueChanged += this.dtpDate_ValueChanged;
                this.dtpDateEnd.ValueChanged += this.dtpDate_ValueChanged;
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
                this.btnExport.Click += new EventHandler(btnExport_Click);
            }

        }

        void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            this.LoadData();
        }

    
        private void LoadData()
        {
            this.dtblRpt  = this.accStores.GetDataOutSrcStoreReport  (
             this.ctrlSupplierID .CompanyID,
             this.dtpDateBegin.Value,
             this.dtpDateEnd.Value).Tables[0];
            this.dgrdv.DataSource = this.dtblRpt;
        }
        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            int PrdID = (int)this.dtblRpt.DefaultView[irow]["PrdID"];
            if (this.dgrdv.Columns[icol].Name == this.ColumnSupplyQty  .Name)
            {
                if (frmSupply  == null)
                {
                    frmSupply = new FrmOutSrcSupplyItemRecord();
                    new FrmStyle(frmSupply).SetPopFrmStyle(this);
                }
                frmSupply.SupplyRecord(this.ctrlSupplierID.CompanyID, PrdID,
                    this.dtpDateBegin.Value, this.dtpDateEnd.Value);
                frmSupply.ShowDialog();
            }
            if ((this.dgrdv.Columns[icol].Name == this.ColumnIntoQty .Name)
                ||(this.dgrdv.Columns[icol].Name == this.ColumnOutQty .Name))
            {
                if (frmRecord == null)
                {
                    frmRecord = new FrmOutSrcInventoryRecord();
                    new FrmStyle(frmRecord).SetPopFrmStyle(this);
                }
                 frmRecord.StoreRecord (this.ctrlSupplierID .CompanyID ,PrdID ,
                    this.dtpDateBegin.Value, 
                    this.dtpDateEnd.Value);
                 frmRecord.ShowDialog();

            }
        }
        void btnExport_Click(object sender, EventArgs e)
        {
            
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "委外库存报告");
            excel.SetCellVal("A3","委外商:" + this.ctrlSupplierID .CompanyAbbName+  "   起始日期:" + this.dtpDateBegin.Value.ToString()
               + " 截止日期:" + this.dtpDateEnd.Value.ToString() );
            int rowIndex = 4;
            int colIndex = 1;
            excel.ImportGridData(dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            excel.Show();
        }
    }
}