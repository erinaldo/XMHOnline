using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Material.Report
{
    public partial class FrmOutSrcStoreCheckRpt : Form
    {
        public FrmOutSrcStoreCheckRpt()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accItems = new JERPData.Material.OutSrcStoreCheckItems();
            this.SetPermit();
        }
        private JERPData.Material.OutSrcStoreCheckItems accItems;
        private Bill.FrmOutSrcStoreCheckNote frmCheckNote;
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
            this.dtblRpt  = this.accItems .GetDataOutSrcStoreCheckItemsPrdLastRecord (
                this.ctrlSupplierID .CompanyID ,
             this.dtpDateBegin.Value, this.dtpDateEnd.Value).Tables[0];
            this.dgrdv.DataSource = this.dtblRpt;
        }
        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnNoteCode .Name)
            {
               long NoteID =(long)this.dtblRpt .DefaultView[irow]["NoteID"];
               if (frmCheckNote == null)
               {
                   frmCheckNote = new JERPApp.Store.Material.Report.Bill.FrmOutSrcStoreCheckNote();
                   new FrmStyle(frmCheckNote).SetPopFrmStyle(this);                   
               }
               frmCheckNote.DetailNote(NoteID);
               frmCheckNote.ShowDialog();
            }
        }
        void btnExport_Click(object sender, EventArgs e)
        {
            
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "委外盘点报告");
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