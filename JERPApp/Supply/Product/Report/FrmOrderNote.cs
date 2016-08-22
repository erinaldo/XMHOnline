using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Supply.Product.Report
{
    public partial class FrmOrderNote : Form
    {
        public FrmOrderNote()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accNotes = new JERPData.Product.BuyOrderNotes();
            this.SetPermit();
        }
        private JERPData.Product.BuyOrderNotes accNotes;
        private Report.Bill.FrmBuyOrderNote frmDetail;
        private string whereclause = string.Empty;
        private DataTable dtblNotes;
           //权限码
        private bool enableBrowse = false;//浏览 
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(529); 
            if (this.enableBrowse)
            {
             
                //加载数据
                LoadData();
                this.dtpDateBegin.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                this.dtpDateEnd.Value = this.dtpDateBegin.Value.AddMonths(1).AddDays(-1).Date;
                this.btnSearch.Click += new EventHandler(btnSearch_Click);
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
            }
        }

       

        void btnSearch_Click(object sender, EventArgs e)
        {
            this.whereclause = string.Empty;
            if (this.ckbSupplier.Checked)
            {
                this.whereclause += " and (CompanyID=" + this.ctrlSupplierID.CompanyID.ToString() + ")";
            }
            if (this.ckbNoteCode.Checked)
            {
                this.whereclause += " and (NoteCode like '%" + this.txtNoteCode.Text + "%')";
            }
            if (this.ckbDateNote.Checked)
            {
                this.whereclause += " and (DateNote>='" + this.dtpDateBegin.Value.ToShortDateString()
                    + "' and DateNote<='" + this.dtpDateEnd.Value.ToShortDateString() + "')";
            }
            if (this.ckbMakerPsn.Checked)
            { 
                this.whereclause += " and (MakerPsnID=" + this.ctrlMakerPsnID.PsnID.ToString() + ")"; 
            }
            if (this.ckbConfirmPsn .Checked)
            {
                this.whereclause += " and (ConfirmPsnID=" + this.ctrlConfirmPsnID .PsnID.ToString() + ")";
            }
            if (this.ckbStatus.Checked)
            {
                if (this.radNonConfirmFlag.Checked)
                {
                    this.whereclause += " and (ConfirmPsnID is null)";
                }
                if (this.radNonFinishedFlag.Checked)
                {
                    this.whereclause += " and (NoteID in(select NoteID from prd.BuyOrderItems where NonFinishedQty>0))";
                }
                if (this.radFinishedFlag.Checked)
                {
                    this.whereclause += " and (NoteID not in(select NoteID from prd.BuyOrderItems where NonFinishedQty>0))";
                }
            }
            this.LoadData();
        }
        private void LoadData()
        {
            int cnt = 0;
            this.dtblNotes  = this.accNotes.GetDataBuyOrderNotesDescPagesFreeSearch(1, this.pbar.PageSize,
                ref cnt, this.whereclause).Tables[0];
            this.dgrdv .DataSource = this.dtblNotes ;
            this.pbar.Init(1, cnt);
        }
        void pbar_OnPageIndexChanged(object sender, EventArgs e)
        {
            int cnt = 0;
            this.dtblNotes = this.accNotes.GetDataBuyOrderNotesDescPagesFreeSearch(this.pbar.PageIndex,
                this.pbar.PageSize, ref cnt, this.whereclause).Tables[0];
            this.dgrdv .DataSource = this.dtblNotes;
        }
        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv .Columns[icol].Name ==this.ColumnlnkNoteCode.Name )
            {
                long NoteID = (long)this.dtblNotes .DefaultView[irow]["NoteID"]; 
                if (frmDetail == null)
                {
                    frmDetail = new JERPApp.Supply.Product.Report.Bill.FrmBuyOrderNote();
                    new FrmStyle(frmDetail).SetPopFrmStyle(this);
                }
                frmDetail.Detail(NoteID);
                frmDetail.ShowDialog();
            }
        }
    }
}