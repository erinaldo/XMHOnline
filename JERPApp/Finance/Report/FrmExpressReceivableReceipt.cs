using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Report
{
    public partial class FrmExpressReceivableReceipt : Form
    {
        public FrmExpressReceivableReceipt()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accReceiptNotes = new JERPData.Product.ExpressReceiptNotes();
            this.SetPermit();
        }
        private JERPData.Product.ExpressReceiptNotes accReceiptNotes;
        private Bill.Product.FrmExpressReceiptNote frmDetail;
        private DataTable dtblReceiptNotes;
        private string whereclause = string.Empty;
        private bool enableBrowse = false;//ä¯ÀÀ
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(696);          
            if (this.enableBrowse)
            {
              
                this.btnSearch.Click += new EventHandler(btnSearch_Click);
                this.dtpDateBegin.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                this.dtpDateEnd.Value = this.dtpDateBegin.Value.AddMonths(1).AddDays(-1);
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
                this.pbar.OnPageIndexChanged += new EventHandler(pbar_OnPageIndexChanged);
                this.LoadData();
            }
          
        }


        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnNoteCode.Name)
            {
                long NoteID = (long)this.dtblReceiptNotes.DefaultView[irow]["NoteID"];           
                if (frmDetail == null)
                {
                    frmDetail = new JERPApp.Finance.Report.Bill.Product.FrmExpressReceiptNote();
                    new FrmStyle(frmDetail).SetPopFrmStyle(this);
                }
                frmDetail.Detail(NoteID);
                frmDetail.ShowDialog();
            }
        }
        private void LoadData()
        {
            int cnt=0;
            this.dtblReceiptNotes = this.accReceiptNotes.GetDataExpressReceiptNotesDescPagesFreeSearch (1,
                this.pbar.PageSize, ref cnt,
                this.whereclause).Tables[0];
            this.dgrdv.DataSource = this.dtblReceiptNotes;
            this.pbar.Init(1, cnt);
        }
        void pbar_OnPageIndexChanged(object sender, EventArgs e)
        {
            int cnt = 0;
            this.dtblReceiptNotes = this.accReceiptNotes.GetDataExpressReceiptNotesDescPagesFreeSearch(this.pbar.PageIndex,
                this.pbar.PageSize, ref cnt,
                this.whereclause).Tables[0];
            this.dgrdv.DataSource = this.dtblReceiptNotes;
        }
        void btnSearch_Click(object sender, EventArgs e)
        {

            this.whereclause =string.Empty;
            if (this.ckbSettleFlag.Checked)
            {
                if (this.radNonSettleFlag.Checked)
                {
                    this.whereclause += " and (SettlePsnID is null)";
                }
                if (this.radSettleFlag.Checked)
                {
                    this.whereclause += " and (SettlePsnID is not null)";
                }
            }
            if (this.ckbNoteCodeFlag.Checked)
            {
                this.whereclause += " and (NoteCode like '%" + this.txtNoteCode.Text + "%')";
            }
                   
            if (this.ckbReconciliationCodeFlag.Checked)
            {
                this.whereclause += " and (ReconciliationCode like '%" + this.txtReconciliationCode.Text + "%')";
            }          
            if (this.ckbExpressFlag.Checked)
            {
                this.whereclause += " and (CompanyID=" + this.ctrlExpressID.CompanyID.ToString() + ")";
            }
            if (this.ckbDateNoteFlag.Checked)
            {
                this.whereclause += " and (DateNote>='" + this.dtpDateBegin.Value.ToShortDateString()
                    + "' and DateNote<='" + this.dtpDateEnd.Value.ToShortDateString() + "')";
            }
            this.LoadData();
        }
    }
}