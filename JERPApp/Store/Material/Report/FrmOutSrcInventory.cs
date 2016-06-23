using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Material.Report
{
    public partial class FrmOutSrcInventory : Form
    {
        public FrmOutSrcInventory()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accStore = new JERPData.Material.OutSrcStore();
            this.accSupplier = new JERPData.General.Supplier();
            this.SetPermit();
        }
        private JERPData.Material.OutSrcStore accStore; 
        private JERPData.General .Supplier  accSupplier;
        private DataTable dtblInventory, dtblSupplier;
        private FrmOutSrcInventoryRecord frmRecord;
        //权限码
        private bool enableBrowse = false;//浏览 
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(653); 
            if (this.enableBrowse)
            {
                this.dtblSupplier = this.accSupplier.GetDataSupplierForOutSrc().Tables[0];
                this.CreateGridColumn(); 
                //加载数据
                this.LoadInventory();
                this.LoadSupplierInventory();
                this.ctrlQFind.BeforeFilter += ctrlQFind_BeforeFilter;
                this.dgrdv.ContextMenuStrip = this.cMenu;
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click); 
                this.btnExplore.Click += new EventHandler(btnExplore_Click);
            }

        }
        private void ShowRecord(int SupplierID, int PrdID)
        {
            DateTime DateBegin=new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime DateEnd=DateTime .Now ;
            if (frmRecord == null)
            {
                frmRecord = new FrmOutSrcInventoryRecord();
                new FrmStyle(frmRecord).SetPopFrmStyle(this);
            }
            frmRecord.StoreRecord(SupplierID, PrdID,
                DateBegin,
                DateEnd);
            frmRecord.ShowDialog();
        }
        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].GetType().Equals(typeof(DataGridViewLinkColumn)))
            {
                int SupplierID=int.Parse (this.dgrdv .Columns [icol].DataPropertyName );
                int PrdID = (int)this.dtblInventory.DefaultView[irow]["PrdID"];
                this.ShowRecord(SupplierID, PrdID);
            }
        }

        void ctrlQFind_BeforeFilter()
        {
            this.LoadInventory();
        }
        private void CreateGridColumn()
        {
           
            DataGridViewLinkColumn  lnk;
            foreach (DataRow drow in this.dtblSupplier.Rows)
            {
                lnk = new DataGridViewLinkColumn();
                lnk.DataPropertyName = drow["CompanyID"].ToString();
                lnk.HeaderText = drow["CompanyAbbName"].ToString();
                lnk.Width = 80;
                this.dgrdv.Columns.Add(lnk);
            }
            DataGridViewTextBoxColumn txt;
            txt = new DataGridViewTextBoxColumn();
            txt.DataPropertyName = "-1";
            txt.HeaderText = "合计";
            txt.Width = 66;
            this.dgrdv.Columns.Add(txt);
            this.ctrlQFind.SeachGridView = this.dgrdv;
        }
      
        private void LoadInventory()
        {
            this.dtblInventory = this.accStore.GetDataOutSrcStorePivotSupplierID().Tables[0];
            this.dgrdv.DataSource = this.dtblInventory;
            DataRow drowNew = this.dtblInventory.NewRow();
            drowNew["PrdID"] = -1;
            drowNew["PrdCode"] = "合计";
            foreach (DataRow drow in this.dtblSupplier .Rows)
            {
                drowNew[drow["CompanyID"].ToString()] = this.dtblInventory.Compute("SUM([" + drow["CompanyID"].ToString() + "])", "");
            }
            drowNew["-1"] = this.dtblInventory.Compute("SUM([-1])", "");
            this.dtblInventory.Rows.Add(drowNew);
        }
        private void LoadSupplierInventory()
        {
            TabPage page;
            CtrlOutSrcSupplierInventory  ctrlSupplierInventory;
            int SupplierID = -1;
            string SupplierName;
            foreach (DataRow drow in this.dtblSupplier .Rows)
            {
                SupplierID = (int)drow["CompanyID"];
                SupplierName = drow["CompanyAbbName"].ToString();
                page = new TabPage();
                page.Text = SupplierName;
                ctrlSupplierInventory = new CtrlOutSrcSupplierInventory();
                ctrlSupplierInventory.SupplierInventory (SupplierID, SupplierName);
                ctrlSupplierInventory.AffterSelect += new CtrlOutSrcSupplierInventory.AffterSelectDelegate(ctrlSupplierInventory_AffterSelect);
                page.Controls.Add(ctrlSupplierInventory);
                ctrlSupplierInventory.Dock = DockStyle.Fill;
                this.tabMain.TabPages.Add(page);
            }
        }

        void ctrlSupplierInventory_AffterSelect(int SupplierID, int PrdID)
        {
            this.ShowRecord(SupplierID, PrdID);
        }

      
        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadInventory();
        }     
        void btnExplore_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "委外库存表");         
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(this.dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            FrmMsg.Hide();
            excel.Show();
        }
    }
}