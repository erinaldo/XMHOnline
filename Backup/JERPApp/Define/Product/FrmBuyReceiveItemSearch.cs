using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Product
{
    public partial class FrmBuyReceiveItemSearch : Form
    {
        public FrmBuyReceiveItemSearch()
        {
            InitializeComponent();
            this.tpkDateNoteBegin.Value = DateTime.Now.Date;
            this.tpkDateNoteEnd.Value = DateTime.Now.Date;
            this.btnSearch.Click += this.btnSearch_Click;
        }
        private string whereclause = string.Empty;
        public delegate void AffterSearchDelegate(string whereclause);
        private AffterSearchDelegate affterSearch;
        public event AffterSearchDelegate AffterSearch
        {
            add
            {
                affterSearch += value;
            }
            remove
            {
                affterSearch -= value;
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.whereclause = string.Empty;
            if (this.ckbCapPONo.Checked)
            {
                this.whereclause += "and (PONo like '%" + txtPONo.Text + "%')";
            }        
            if (this.ckbCapPrdID.Checked)
            {
                this.whereclause += "and (PrdID =" + this.ctrlPrdID .PrdID .ToString () + ")";
            }
            if (this.ckbCapCompanyID.Checked)
            {
                this.whereclause += "and (CompanyID =" + this.ctrlSupplierID .CompanyID .ToString () + ")";
            }
            if (this.ckbCapNoteCode.Checked)
            {
                this.whereclause += "and (NoteCode like '%" + txtNoteCode.Text + "%')";
            }
            if (this.ckbCapDateNote.Checked)
            {
                this.whereclause += "and (DateNote>='" + tpkDateNoteBegin.Value.ToShortDateString() + "' and DateNote<='" + tpkDateNoteEnd.Value.ToShortDateString() + "')";
            }
            if (this.affterSearch != null) this.affterSearch(this.whereclause);
            this.Close();
        }
    }
}