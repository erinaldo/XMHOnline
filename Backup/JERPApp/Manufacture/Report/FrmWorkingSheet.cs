using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture.Report
{
    public partial class FrmWorkingSheet : Form
    {
        public FrmWorkingSheet()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accWorkingSheets = new JERPData.Manufacture.WorkingSheets();
            this.SetPermit();
        }

        private JERPData.Manufacture.WorkingSheets accWorkingSheets;
        private Bill.FrmWorkingSheet   frmWorkingSheet;
        private JERPApp.Define.Manufacture.FrmWorkingSheetSearch frmSearch;
        private DataTable dtblWorkingSheets;
        private string whereclause = string.Empty;
        
        //权限码
        private bool enableBrowse = false;//浏览
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(340);
            if (this.enableBrowse)
            {
                this.whereclause = "and (NonFinishedQty>0)";
                this.LoadData();
                this.lnkSearch.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkSearch_LinkClicked);
                this.btnExport.Click += new EventHandler(btnExport_Click);
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
                this.pbar.OnPageIndexChanged += new EventHandler(pbar_OnPageIndexChanged);
            }


        }
        public void LoadData(string whereclause)
        {
            this.whereclause = whereclause;
            this.LoadData();
        }
        private  void LoadData()
        {
            int cnt = 0;
            this.dtblWorkingSheets = this.accWorkingSheets.GetDataWorkingSheetsDescPagesFreeSearch  (1,this.pbar .PageSize ,ref cnt, this.whereclause ).Tables[0];
            this.dgrdv.DataSource = this.dtblWorkingSheets;
            this.pbar.Init(1, cnt);
        }

        void pbar_OnPageIndexChanged(object sender, EventArgs e)
        {
            int cnt = 0;
            this.dtblWorkingSheets = this.accWorkingSheets.GetDataWorkingSheetsDescPagesFreeSearch(this.pbar.PageIndex, this.pbar.PageSize, ref cnt,  this.whereclause).Tables[0];
            this.dgrdv.DataSource = this.dtblWorkingSheets;
        }
        void lnkSearch_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (frmSearch == null)
            {
                frmSearch = new JERPApp.Define.Manufacture.FrmWorkingSheetSearch();
                new FrmStyle(frmSearch).SetPopFrmStyle(this);
                frmSearch.AffterSearch += new JERPApp.Define.Manufacture.FrmWorkingSheetSearch.AffterSearchDelegate(frmSearch_AffterSearch);
            }
            frmSearch.ShowDialog();
        }

        void frmSearch_AffterSearch(string whereclause)
        {
            this.whereclause = whereclause;
            this.LoadData();
        }
       
        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name ==this.ColumnWorkingSheetCode.Name )
            {
                long WorkingSheetID = (long)this.dtblWorkingSheets.DefaultView[irow]["WorkingSheetID"];
                if (this.frmWorkingSheet  == null)
                {
                    this.frmWorkingSheet = new JERPApp.Manufacture.Report.Bill.FrmWorkingSheet();
                    new FrmStyle(this.frmWorkingSheet).SetPopFrmStyle(this);                    
                }
                this.frmWorkingSheet.WorkingSheet  (WorkingSheetID);
                this.frmWorkingSheet.ShowDialog();
            }
        }

        void btnExport_Click(object sender, EventArgs e)
        {
            if (this.dtblWorkingSheets.Rows.Count == 0) return;
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "生产制令单");
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            FrmMsg.Hide();
            excel.Show();
        }
    }
}