using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Receivable
{
    public partial class FrmAdvanceAMTFromOrderNote : Form
    {
        public FrmAdvanceAMTFromOrderNote()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accNotes = new JERPData.Product.SaleOrderNotes(); 
            //¼ÓÔØÊý¾Ý
            this.tpkDateBegin.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            this.tpkDateEnd.Value = this.tpkDateBegin.Value.AddMonths(1).AddDays(-1);
            this.pbar.OnPageIndexChanged += new EventHandler(pbar_OnPageIndexChanged);
            this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
        }

     
        private JERPData.Product.SaleOrderNotes accNotes;
        private DataTable dtblNotes;
        private string iniwhereclause = " and (AdvanceAMT>0)";
        private string whereclause = string.Empty;
        public delegate void AffterSelectDelegate(long NoteID);
        private AffterSelectDelegate affterSelect;
        public event AffterSelectDelegate AffterSelect
        {
            add
            {
                affterSelect += value;
            }
            remove
            {
                affterSelect -= value;
            }
        }
        void btnSearch_Click(object sender, EventArgs e)
        {
            this.whereclause = this.iniwhereclause ;
            if (this.ckbNoteCode.Checked)
            {
                this.whereclause += "and (PONo like '%" + txtPONo.Text + "%')";
            }
            if (this.ckbCapDateNote.Checked)
            {
                this.whereclause += "and (DateNote>='" + tpkDateBegin.Value.ToShortDateString() + "' and DateNote<='" + tpkDateEnd.Value.ToShortDateString() + "')";
            }

            if (this.ckbCustomer.Checked)
            {
                this.whereclause += "and (CompanyID =" + this.ctrlCustomerID.CompanyID.ToString() + ")";
            }
            this.LoadData();
        }
        public void LoadData()
        {
            int record=0;
            this.dtblNotes = this.accNotes.GetDataSaleOrderNotesDescPagesFreeSearch(1, this.pbar.PageSize,
                ref record, this.whereclause).Tables[0];
            this.dgrdv.DataSource = this.dtblNotes;
            this.pbar.Init(1, record);

        }
        void pbar_OnPageIndexChanged(object sender, EventArgs e)
        {
            int record = 0;
            this.dtblNotes = this.accNotes.GetDataSaleOrderNotesDescPagesFreeSearch (this.pbar .PageIndex , this.pbar.PageSize,
                ref record, this.whereclause).Tables[0];
            this.dgrdv.DataSource = this.dtblNotes;
        }
        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnbtnSelect.Name)
            {
                long NoteID = (long)this.dtblNotes.DefaultView[irow]["NoteID"];
                if (this.affterSelect != null) this.affterSelect(NoteID);
                this.Close();
            }
        }

      
    }
}