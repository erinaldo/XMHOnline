using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture.SemiPrd.Report
{
    public partial class FrmInventory : Form
    {
        public FrmInventory()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accStore = new JERPData.SemiPrd.Store();
            this.SetPermit();
        }
        private JERPData.SemiPrd.Store accStore;
        private DataTable dtblInventory;
        private FrmPrdInventory frmPrdInventory;
        private int iGrid = 5;
        private int iData = 6;
        //权限码
        private bool enableBrowse = false;//浏览
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(371);
            if (this.enableBrowse)
            {
               
                this.LoadData();
                this.dgrdv.ContextMenuStrip = this.cMenu;
                this.mRefresh.Click += new EventHandler(mRefresh_Click);
                this.btnExport.Click += new EventHandler(btnExport_Click);
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
            }

        }

        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnPrdCode.Name)
            {
                int PrdID = (int)this.dtblInventory.DefaultView[irow]["PrdID"];
                if (frmPrdInventory == null)
                {
                    frmPrdInventory = new FrmPrdInventory();
                    new FrmStyle(frmPrdInventory).SetPopFrmStyle(this);
                    
                }
                frmPrdInventory.PrdInventory(PrdID);
                frmPrdInventory.ShowDialog();
            }
        }

        void mRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
        private void LoadData()
        {
            while (this.dgrdv.ColumnCount > iGrid)
            {
                this.dgrdv.Columns.RemoveAt(iGrid);
            }
            this.dtblInventory = this.accStore.GetDataStorePivotProcessType().Tables[0];
            DataGridViewTextBoxColumn txtcol;
            string columnname;
            for (int j = iData; j < this.dtblInventory.Columns.Count; j++)
            {
                columnname =this.dtblInventory .Columns [j].ColumnName ;
                txtcol = new DataGridViewTextBoxColumn();
                txtcol.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                txtcol.DataPropertyName = columnname;
                txtcol.HeaderText = columnname;
                this.dgrdv.Columns.Add(txtcol);
            }
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.dgrdv.DataSource = this.dtblInventory;
        }
        void btnExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "半成品一览");
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            FrmMsg.Hide();
            excel.Show();
        }
    }
}