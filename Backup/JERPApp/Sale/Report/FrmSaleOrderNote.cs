using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Sale.Report
{
    public partial class FrmSaleOrderNote : Form
    {
        public FrmSaleOrderNote()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accNotes = new JERPData.Product.SaleOrderNotes();
            int Year=DateTime .Now .Year ;
            int Month=DateTime .Now .Month ;
            this.dtpDateBegin.Value = new DateTime(Year, Month, 1);
            this.dtpDateEnd.Value = new DateTime(Year, Month, DateTime.DaysInMonth(Year, Month));
            this.SetPermit();
        }
        private string whereclause = string.Empty;
        private JERPData.Product.SaleOrderNotes accNotes;
        private Bill.FrmSaleOrderNote  frmDetail; 
        private DataTable dtblNotes;
        private bool enableBrowse = false;
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(78);
            if (this.enableBrowse)
            {
                this.btnSearch_Click(this.btnSearch, null);
                this.btnSearch.Click += new EventHandler(btnSearch_Click);
                this.pbar.OnPageIndexChanged += new EventHandler(pbar_OnPageIndexChanged);
                this.dgrdv.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdv_DataBindingComplete);
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
            }


        }

     
        private void LoadData()
        {
            int cnt=0;
            this.dtblNotes = this.accNotes.GetDataSaleOrderNotesPagesFreeSearch(1,
                this.pbar.PageSize, ref cnt, this.whereclause).Tables[0];
            this.dgrdv.DataSource = this.dtblNotes;
            this.pbar.Init(1, cnt); 
        }
   
        void pbar_OnPageIndexChanged(object sender, EventArgs e)
        {
            int cnt = 0;
            this.dtblNotes = this.accNotes.GetDataSaleOrderNotesPagesFreeSearch(this.pbar .PageIndex ,
                this.pbar.PageSize, ref cnt, this.whereclause).Tables[0];
            this.dgrdv.DataSource = this.dtblNotes; 
        }

        void dgrdv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow grow in this.dgrdv.Rows)
            {
                if (grow.Cells[this.ColumnFinishedFlag.Name].Value  == DBNull.Value) return;
                grow.ErrorText =(bool)grow.Cells [this.ColumnFinishedFlag .Name ].Value?string.Empty:"Î´Íê³É" ;
            }
        }
        void btnSearch_Click(object sender, EventArgs e)
        {
            this.whereclause = string.Empty;
            if (this.ckbDateNote.Checked)
            {
                this.whereclause +=" and (DateNote>='"+this.dtpDateBegin .Value .ToShortDateString ()+"' and DateNote<='"+this.dtpDateEnd .Value .ToShortDateString ()+"')";
            }
            if (this.ckbMoneyType .Checked)
            {
                this.whereclause += " and (MoneyTypeID=" + this.ctrlMoneyTypeID.MoneyTypeID  + ")";
            }
            if (this.ckbCustomer.Checked)
            {
                this.whereclause += " and (CompanyID=" + this.ctrlCustomerID.CompanyID + ")";
            }
            if (this.ckbFinished.Checked)
            {

                if (this.radFinishedFlag.Checked)
                {
                    this.whereclause += " and (FinishedFlag=1)";
                }
                else
                {
                    this.whereclause += " and (FinishedFlag=0)";
                }
            }
            this.LoadData();

        }
        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            long NoteID = (long)this.dtblNotes.DefaultView[irow]["NoteID"];
            if (this.dgrdv.Columns[icol].Name == this.ColumnNoteCode.Name)
            {
               
                if (frmDetail == null)
                {
                    frmDetail = new JERPApp.Sale.Report.Bill.FrmSaleOrderNote();
                    new FrmStyle(frmDetail).SetPopFrmStyle(this);
                }
                frmDetail.Detail(NoteID);
                frmDetail.ShowDialog();
            }
       
        }


    }
}