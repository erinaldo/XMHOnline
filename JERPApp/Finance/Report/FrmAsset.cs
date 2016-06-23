using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Report
{
    public partial class FrmAsset : Form
    {
        public FrmAsset()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accAsset = new JERPData.Asset .Product ();
            this.SetPermit();
        }
        private JERPData.Asset .Product  accAsset;
        private FrmAssetRepair frmRepair;
        private DataTable dtblAsset;
        //权限码
        private bool enableBrowse = false;//浏览
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(311);
            if (this.enableBrowse)
            {
                this.dgrdv.ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                this.LoadData();
                this.btnExport .Click +=new EventHandler(btnExport_Click);
                this.dgrdv .CellContentClick +=new DataGridViewCellEventHandler(dgrdv_CellContentClick);
            }
          
        }

        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnDateLastRepair.Name)
            {
                int PrdID = (int)this.dtblAsset.DefaultView[irow]["PrdID"];
                if (frmRepair == null)
                {
                    frmRepair = new FrmAssetRepair();
                    new FrmStyle(frmRepair).SetPopFrmStyle(this);
                    
                }
                frmRepair.RepairRecord(PrdID);
                frmRepair.ShowDialog();
            }
        }


        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
        private void LoadData()
        {
            this.dtblAsset  = this.accAsset.GetDataProduct  ().Tables[0];   
            this.dgrdv.DataSource = this.dtblAsset ;

        }     
        void btnExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成Excel文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "资产一览");
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