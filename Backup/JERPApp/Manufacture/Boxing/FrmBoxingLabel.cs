using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture.Boxing
{
    public partial class FrmBoxingLabel : Form
    {
        public FrmBoxingLabel()
        {
            InitializeComponent();
            this.dgrdvBox.AutoGenerateColumns = false;
            this.dgrdvBoxItem.AutoGenerateColumns = false;
            this.dgrdvWorkingSheet.AutoGenerateColumns = false;
            this.dgrdvPackingSheet.AutoGenerateColumns = false;
            this.dgrdvBoxItemNonPrint.AutoGenerateColumns = false;
            this.dgrdvBoxNonPrint.AutoGenerateColumns = false;
            this.ctrlQWorkingSheet.SeachGridView = this.dgrdvWorkingSheet;
            this.ctrlPackingSheet.SeachGridView = this.dgrdvPackingSheet;
            this.ctrlQBox.SeachGridView = this.dgrdvBox;
            this.ctrlQBoxItemNonPrint.SeachGridView = this.dgrdvBoxItemNonPrint;
            this.ctrlBoxItemFind.SeachGridView = this.dgrdvBoxItem;
            this.ctrlQBoxNonPrint.SeachGridView = this.dgrdvBoxNonPrint;
            this.accWorkingSheets = new JERPData.Manufacture.WorkingSheets();
            this.accPackingSheets = new JERPData.Packing.WorkingSheets();
            this.accBoxes = new JERPData.Packing.Boxes();
            this.accBoxItems = new JERPData.Packing.BoxItems();
            this.BoxItemPrintHelper = new JERPBiz.Packing.BoxItemPrinterHelper();
            this.BoxPrintHelper = new JERPBiz.Packing.BoxPrinterHelper();
            this.SetPermit();
        }
        private JERPData.Manufacture.WorkingSheets accWorkingSheets;
        private JERPData.Packing.WorkingSheets accPackingSheets;
        private JERPData.Packing.Boxes accBoxes;
        private JERPData.Packing.BoxItems accBoxItems;
        private JERPBiz.Packing.BoxItemPrinterHelper BoxItemPrintHelper;
        private JERPBiz.Packing.BoxPrinterHelper BoxPrintHelper;
        private FrmBoxNew frmBoxNew;
        private FrmBoxAppend frmBoxAppend;
        private FrmBoxItemNew frmBoxItemNew; 
        private FrmBoxItemAppend frmBoxItemAppend;
        private FrmBoxItemDetail frmBoxItemDetail;
        private FrmBoxDetail frmBoxDetail; 
        private DataTable dtblBoxes, dtblBoxItems, dtblNonPrintBoxes, dtblNonPrintBoxItems, dtblWorkingSheets,dtblPackingSheets;

        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(323);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(324);
            if (this.enableBrowse)
            {
                this.ctrlBetweenDate.DateBegin = DateTime.Now.Date;
                this.ctrlBetweenDate.DateEnd = DateTime.Now.AddDays(1).Date;

                this.LoadWorkingSheet();
                this.LoadPackingSheet();
                this.LoadBoxData ();
                this.LoadBoxItemData ();
                this.LoadBoxItemNonPrintData();
                this.LoadBoxNonPrintData();
                this.ctrlQBox.BeforeFilter += this.LoadBoxData;
                this.dgrdvWorkingSheet.ContextMenuStrip = this.cMenu;
                this.dgrdvBox.ContextMenuStrip = this.cMenu;
                this.dgrdvBoxItemNonPrint.ContextMenuStrip = this.cMenu;
                this.dgrdvBoxNonPrint.ContextMenuStrip = this.cMenu;
                this.dgrdvBoxItem.ContextMenuStrip = this.cMenu;
                this.lnkRefreshAll.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkRefreshAll_LinkClicked);
                this.mItmeRefresh.Click += new EventHandler(mItmeRefresh_Click);
                this.ctrlBetweenDate.AffterEnter += this.LoadBoxItemData;
            }
            
            this.ColumnbtnPrdCreate.Visible = this.enableSave ;
            this.ColumnbtnBoxCreate.Visible = this.enableSave;
            this.lblAppendBox.Enabled = this.enableSave;
            this.lnkAppendBoxItem.Enabled = this.enableSave;
            this.btnBoxItemPrint.Enabled = this.enableSave;
            this.btnBoxPrint.Enabled = this.enableSave;
            if (this.enableSave)
            {
                this.btnBoxPrint.Click += new EventHandler(btnBoxPrint_Click);
                this.btnBoxItemPrint.Click += new EventHandler(btnBoxItemPrint_Click);
                this.lblAppendBox.LinkClicked += new LinkLabelLinkClickedEventHandler(lblAppendBox_LinkClicked);
                this.lnkAppendBoxItem.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkAppendBoxItem_LinkClicked);
                this.dgrdvBox.CellContentClick += new DataGridViewCellEventHandler(dgrdvBox_CellContentClick);
                this.dgrdvWorkingSheet .CellContentClick += new DataGridViewCellEventHandler(dgrdvWorkingSheet_CellContentClick);
                this.dgrdvPackingSheet .CellContentClick +=new DataGridViewCellEventHandler(dgrdvPackingSheet_CellContentClick);
                this.dgrdvBoxItem.CellContentClick += new DataGridViewCellEventHandler(dgrdvBoxItem_CellContentClick);
            }
        } 
        void btnBoxItemPrint_Click(object sender, EventArgs e)
        {
            DialogResult rul = MessageBox.Show("即将输出产品标签，请确认打印机及卷纸的设置", "操作确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (rul == DialogResult.Cancel) return;
            DataRow[] drows = this.dtblNonPrintBoxItems.Select();
            this.BoxItemPrintHelper.Export(drows);
        }

        void btnBoxPrint_Click(object sender, EventArgs e)
        {
            DialogResult rul = MessageBox.Show("即将输出外箱标签，请确认打印机及卷纸的设置", "操作确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (rul == DialogResult.Cancel) return;
            DataRow[] drows = this.dtblNonPrintBoxes .Select();
            this.BoxPrintHelper.Export(drows);
        }

        void lnkRefreshAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.LoadWorkingSheet();
            this.LoadPackingSheet();
            this.LoadBoxData();
            this.LoadBoxItemData(); 
            this.LoadBoxNonPrintData();
            this.LoadBoxItemNonPrintData();
        }

  
        private void LoadWorkingSheet()
        {
            this.dtblWorkingSheets = this.accWorkingSheets.GetDataWorkingSheetsNeedBarcode().Tables[0];
            this.dgrdvWorkingSheet.DataSource = this.dtblWorkingSheets;
            this.pageWorkingSheet.Text = "产品未制[" + this.dtblWorkingSheets.Rows.Count.ToString() + "]";
        }
        private void LoadPackingSheet()
        {
            this.dtblPackingSheets  = this.accPackingSheets .GetDataWorkingSheetsNeedBarcode().Tables[0];
            this.dgrdvPackingSheet.DataSource = this.dtblPackingSheets;
            this.pagePackingSheet.Text = "外箱未制[" + this.dtblPackingSheets.Rows.Count.ToString() + "]";
        }
        private void LoadBoxNonPrintData()
        {
            this.dtblNonPrintBoxes = this.accBoxes.GetDataBoxesNonPrint().Tables[0];
            this.dgrdvBoxNonPrint.DataSource = this.dtblNonPrintBoxes;
            this.pageBoxNonPrint.Text = "未打印外箱[" + this.dtblNonPrintBoxes.Rows.Count.ToString() + "]";
        }
        private void LoadBoxItemNonPrintData()
        {
            this.dtblNonPrintBoxItems = this.accBoxItems.GetDataBoxItemsNonPrint().Tables[0];
            this.dgrdvBoxItemNonPrint.DataSource = this.dtblNonPrintBoxItems;
            this.pageBoxItemNonPrint.Text = "未打印产品[" + this.dtblNonPrintBoxItems.Rows.Count.ToString() + "]";
        }
        private void LoadBoxData()
        { 
            this.dtblBoxes = this.accBoxes.GetDataBoxesProduct().Tables[0];
            this.dgrdvBox .DataSource = this.dtblBoxes;
         
        }
        private void LoadBoxItemData()
        {
            
            this.dtblBoxItems = this.accBoxItems.GetDataBoxItemsGroupPrdByDate  (this.ctrlBetweenDate .DateBegin ,this.ctrlBetweenDate .DateEnd ).Tables[0];
            this.dgrdvBoxItem.DataSource = this.dtblBoxItems;
            
        }
        void mItmeRefresh_Click(object sender, EventArgs e)
        {
            if (this.cMenu.SourceControl == this.dgrdvWorkingSheet)
            {
                this.LoadWorkingSheet();
            }
            if (this.cMenu.SourceControl == this.dgrdvPackingSheet)
            {
                this.LoadPackingSheet();
            }
            if (this.cMenu.SourceControl == this.dgrdvBox )
            {
                this.LoadBoxData();
            }
            if (this.cMenu.SourceControl == this.dgrdvBoxItem )
            {
                this.LoadBoxItemData();
            }
            if (this.cMenu.SourceControl == this.dgrdvBoxNonPrint )
            {
                this.LoadBoxNonPrintData ();
            }
            if (this.cMenu.SourceControl == this.dgrdvBoxItemNonPrint )
            {
                this.LoadBoxItemNonPrintData ();
            }
        }

     

        void dgrdvWorkingSheet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvWorkingSheet.Columns[icol].Name == this.ColumnbtnPrdCreate.Name)
            {
                long WorkingSheetID = (long)this.dtblWorkingSheets.DefaultView[irow]["WorkingSheetID"];
                if (frmBoxItemNew == null)
                {
                    frmBoxItemNew = new FrmBoxItemNew();
                    new FrmStyle(frmBoxItemNew).SetPopFrmStyle(this);
                    frmBoxItemNew.AffterSave += this.LoadWorkingSheet;
                    frmBoxItemNew.AffterSave += this.LoadBoxItemData;
                    frmBoxItemNew.AffterSave += this.LoadBoxItemNonPrintData;
                }
                frmBoxItemNew.BarcodeOper(WorkingSheetID);
                frmBoxItemNew.ShowDialog();
            }
        }

        void dgrdvPackingSheet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvPackingSheet.Columns[icol].Name == this.ColumnbtnBoxCreate.Name)
            {
                long WorkingSheetID = (long)this.dtblPackingSheets .DefaultView[irow]["WorkingSheetID"];
                if (frmBoxNew == null)
                {
                    frmBoxNew = new FrmBoxNew();
                    new FrmStyle(frmBoxNew).SetPopFrmStyle(this);
                    frmBoxNew.AffterSave += this.LoadPackingSheet; 
                    frmBoxNew.AffterSave += this.LoadBoxData;
                    frmBoxNew.AffterSave += this.LoadBoxNonPrintData;
                }
                frmBoxNew.BarcodeOper(WorkingSheetID);
                frmBoxNew.ShowDialog();
            }
        }
        void lnkAppendBoxItem_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (frmBoxItemAppend == null)
            {
                frmBoxItemAppend = new FrmBoxItemAppend();
                new FrmStyle(frmBoxItemAppend).SetPopFrmStyle(this);
                frmBoxItemAppend.AffterSave += this.LoadBoxItemNonPrintData;
                frmBoxItemAppend.AffterSave += this.LoadBoxItemData;
            }
            frmBoxItemAppend.New();
            frmBoxItemAppend.ShowDialog();
        } 
        void lblAppendBox_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (frmBoxAppend == null)
            {
                frmBoxAppend = new FrmBoxAppend();
                new FrmStyle(frmBoxAppend).SetPopFrmStyle(this);
                frmBoxAppend.AffterSave += this.LoadBoxData;
                frmBoxAppend.AffterSave += this.LoadBoxNonPrintData;
            }
            frmBoxAppend.New();
            frmBoxAppend.ShowDialog();
        }
        void dgrdvBoxItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvBoxItem .Columns[icol].Name == this.ColumnQuantity.Name)
            {
                int PrdID = (int)this.dtblBoxItems.DefaultView[irow]["PrdID"];
                DateTime DateCreate = (DateTime)this.dtblBoxItems.DefaultView[irow]["DateCreate"];
                if (frmBoxItemDetail == null)
                {
                    frmBoxItemDetail = new FrmBoxItemDetail();
                    new FrmStyle(frmBoxItemDetail).SetPopFrmStyle(this);
                }
                frmBoxItemDetail.Detail(PrdID, DateCreate);
                frmBoxItemDetail.ShowDialog();
            }
        }
        void dgrdvBox_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {  
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvBox .Columns[icol].Name == this.ColumnCount .Name)
            {
                int PrdID = (int)this.dtblBoxes.DefaultView[irow]["PrdID"];
                if (frmBoxDetail == null)
                {
                    frmBoxDetail = new FrmBoxDetail();
                    new FrmStyle(frmBoxDetail).SetPopFrmStyle(this);
                }
                frmBoxDetail.Detail(PrdID);
                frmBoxDetail.ShowDialog();
            }
        }
    }
}