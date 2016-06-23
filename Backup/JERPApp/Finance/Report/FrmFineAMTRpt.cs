using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Report
{
    public partial class FrmFineAMTRpt : Form
    {
        public FrmFineAMTRpt()
        {
            InitializeComponent();
            this.ctrlYear.Year = DateTime.Now.Year;
            this.accSaleFine = new JERPData.Product.SaleFineAMTNotes();
            this.accOutSrcFine = new JERPData.Manufacture.OutSrcFineAMTNotes();
            this.accMtrFine = new JERPData.Material.BuyFineAMTNotes(); 
            this.accOtherResFine = new JERPData.OtherRes.BuyFineAMTNotes();
            this.accPrdFine = new JERPData.Product.BuyFineAMTNotes();
            this.SetPermit();
        }
        private JERPData.Product.SaleFineAMTNotes accSaleFine;
        private JERPData.Manufacture .OutSrcFineAMTNotes accOutSrcFine;
        private JERPData.Material.BuyFineAMTNotes accMtrFine; 
        private JERPData.OtherRes .BuyFineAMTNotes accOtherResFine;
        private JERPData.Product.BuyFineAMTNotes accPrdFine;
        private FrmSaleFineAMTRecord frmSaleRecord;
        private FrmOutSrcFineAMTRecord frmOutSrcRecord;
        private FrmMtrBuyFineAMTRecord frmMtrRecord; 
        private FrmOtherResBuyFineAMTRecord frmOtherResRecord;
        private FrmPrdBuyFineAMTRecord frmPrdRecord;
        private string exp = string.Empty;
        private DataTable dtblSaleFine, dtblOutSrcFine, dtblMtrFine, dtblPrdFine,dtblOtherResFine;
        //È¨ÏÞÂë
        private bool enableBrowse = false;//ä¯ÀÀ
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(341);
            if (this.enableBrowse)
            {
                foreach (TabPage page in this.tabMain.TabPages)
                {
                    DataGridView dgrdv =(DataGridView)page.Controls[0];
                    dgrdv.AutoGenerateColumns = false;
                    this.SetDatagridView(dgrdv);
                } 
                for (int i = 1; i < 13; i++)
                {
                    exp += "+ISNULL([" + i.ToString() + "],0)";
                }
                this.ctrlQFind.SeachGridView = this.dgrdvSale;
                this.tabMain.SelectedIndexChanged += new EventHandler(tabMain_SelectedIndexChanged);
                this.LoadData();
                this.dgrdvSale.CellContentClick += new DataGridViewCellEventHandler(dgrdvSale_CellContentClick);
                this.dgrdvMtr .CellContentClick +=new DataGridViewCellEventHandler(dgrdvMtr_CellContentClick);
                this.dgrdvOutSrc .CellContentClick +=new DataGridViewCellEventHandler(dgrdvOutSrc_CellContentClick);
                this.dgrdvOtherRes .CellContentClick +=new DataGridViewCellEventHandler(dgrdvOtherRes_CellContentClick);
                this.dgrdvPrd .CellContentClick +=new DataGridViewCellEventHandler(dgrdvPrd_CellContentClick);
            }

        }

        void dgrdvSale_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvSale.Columns[icol].GetType().Equals(typeof(DataGridViewLinkColumn)))
            {
                int Month =int.Parse (this.dgrdvSale.Columns[icol].DataPropertyName);
                int CompanyID=(int)this.dtblSaleFine .DefaultView [irow]["CompanyID"];
                int MoneyTypeID=(int)this.dtblSaleFine .DefaultView [irow]["MoneyTypeID"];
                if (this.frmSaleRecord == null)
                {
                    this.frmSaleRecord = new FrmSaleFineAMTRecord();
                    new FrmStyle(frmSaleRecord).SetPopFrmStyle(this);                    
                }
                this.frmSaleRecord.FineRecord(this.ctrlYear.Year,
                    Month,
                    CompanyID,
                    MoneyTypeID);
                this.frmSaleRecord.ShowDialog();

            }
        }
        void dgrdvOutSrc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvOutSrc.Columns[icol].GetType().Equals(typeof(DataGridViewLinkColumn)))
            {
                int Month = int.Parse(this.dgrdvOutSrc.Columns[icol].DataPropertyName);
                int CompanyID = (int)this.dtblOutSrcFine.DefaultView[irow]["CompanyID"];
                int MoneyTypeID = (int)this.dtblOutSrcFine.DefaultView[irow]["MoneyTypeID"];
                if (this.frmOutSrcRecord == null)
                {
                    this.frmOutSrcRecord = new FrmOutSrcFineAMTRecord();
                    new FrmStyle(frmOutSrcRecord).SetPopFrmStyle(this);
                }
                this.frmOutSrcRecord.FineRecord(this.ctrlYear.Year,
                    Month,
                    CompanyID,
                    MoneyTypeID);
                this.frmOutSrcRecord.ShowDialog();

            }
        }
        void dgrdvMtr_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvMtr.Columns[icol].GetType().Equals(typeof(DataGridViewLinkColumn)))
            {
                int Month = int.Parse(this.dgrdvMtr.Columns[icol].DataPropertyName);
                int CompanyID = (int)this.dtblMtrFine.DefaultView[irow]["CompanyID"];
                int MoneyTypeID = (int)this.dtblMtrFine.DefaultView[irow]["MoneyTypeID"];
                if (this.frmMtrRecord == null)
                {
                    this.frmMtrRecord = new FrmMtrBuyFineAMTRecord();
                    new FrmStyle(frmMtrRecord).SetPopFrmStyle(this);
                }
                this.frmMtrRecord.FineRecord(this.ctrlYear.Year,
                    Month,
                    CompanyID,
                    MoneyTypeID);
                this.frmMtrRecord.ShowDialog();

            }
        }
          void dgrdvOtherRes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvOtherRes.Columns[icol].GetType().Equals(typeof(DataGridViewLinkColumn)))
            {
                int Month = int.Parse(this.dgrdvOtherRes.Columns[icol].DataPropertyName);
                int CompanyID = (int)this.dtblOtherResFine.DefaultView[irow]["CompanyID"];
                int MoneyTypeID = (int)this.dtblOtherResFine.DefaultView[irow]["MoneyTypeID"];
                if (this.frmOtherResRecord == null)
                {
                    this.frmOtherResRecord = new FrmOtherResBuyFineAMTRecord();
                    new FrmStyle(frmOtherResRecord).SetPopFrmStyle(this);
                }
                this.frmOtherResRecord.FineRecord(this.ctrlYear.Year,
                    Month,
                    CompanyID,
                    MoneyTypeID);
                this.frmOtherResRecord.ShowDialog();

            }
        }
        void dgrdvPrd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvPrd.Columns[icol].GetType().Equals(typeof(DataGridViewLinkColumn)))
            {
                int Month = int.Parse(this.dgrdvPrd.Columns[icol].DataPropertyName);
                int CompanyID = (int)this.dtblPrdFine.DefaultView[irow]["CompanyID"];
                int MoneyTypeID = (int)this.dtblPrdFine.DefaultView[irow]["MoneyTypeID"];
                if (this.frmPrdRecord == null)
                {
                    this.frmPrdRecord = new FrmPrdBuyFineAMTRecord();
                    new FrmStyle(frmPrdRecord).SetPopFrmStyle(this);
                }
                this.frmPrdRecord.FineRecord(this.ctrlYear.Year,
                    Month,
                    CompanyID,
                    MoneyTypeID);
                this.frmPrdRecord.ShowDialog();

            }
        }
        void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabMain.SelectedIndex == -1) return;
            DataGridView dgrdv =(DataGridView)this.tabMain .SelectedTab.Controls[0];
            this.ctrlQFind.SeachGridView = dgrdv;
        }
        private void SetDatagridView(DataGridView dgrdv)
        {
         
            DataGridViewLinkColumn lnk;
            for (int i = 1; i < 13; i++)
            {
                lnk = new DataGridViewLinkColumn();
                lnk.DataPropertyName = i.ToString();
                lnk.Tag = i;
                lnk.HeaderText = i.ToString() + "ÔÂ";
                lnk.Width = 66;
                dgrdv.Columns.Add(lnk);
            }       
        }
        private void LoadData()
        {
            this.dtblSaleFine = this.accSaleFine.GetDataSaleFineAMTNotesPivotMonth(this.ctrlYear.Year).Tables[0];
            this.dtblSaleFine.Columns.Add("TotalAMT", typeof(decimal), this.exp);
            this.dgrdvSale.DataSource = this.dtblSaleFine;

            this.dtblOutSrcFine = this.accOutSrcFine.GetDataOutSrcFineAMTNotesPivotMonth(this.ctrlYear.Year).Tables[0];
            this.dtblOutSrcFine.Columns.Add("TotalAMT", typeof(decimal), this.exp);
            this.dgrdvOutSrc.DataSource = this.dtblOutSrcFine;

            this.dtblMtrFine = this.accMtrFine.GetDataBuyFineAMTNotesPivotMonth(this.ctrlYear.Year).Tables[0];
            this.dtblMtrFine.Columns.Add("TotalAMT", typeof(decimal), this.exp);
            this.dgrdvMtr.DataSource = this.dtblMtrFine;

         
            this.dtblOtherResFine = this.accOtherResFine.GetDataBuyFineAMTNotesPivotMonth(this.ctrlYear.Year).Tables[0];
            this.dtblOtherResFine.Columns.Add("TotalAMT", typeof(decimal), this.exp);
            this.dgrdvOtherRes.DataSource = this.dtblOtherResFine;

            this.dtblPrdFine = this.accPrdFine.GetDataBuyFineAMTNotesPivotMonth(this.ctrlYear.Year).Tables[0];
            this.dtblPrdFine.Columns.Add("TotalAMT", typeof(decimal), this.exp);
            this.dgrdvPrd.DataSource = this.dtblPrdFine;
        }
       
    }
}