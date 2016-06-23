using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Tool
{
    public partial class FrmBuyOrderNoteFreeSearch : Form
    {
        public FrmBuyOrderNoteFreeSearch()
        {
            InitializeComponent();
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
                this.whereclause += "and (NoteCode like '%" + txtNoteCode.Text + "%')";
            }
            if (this.ckbCapDateNote.Checked)
            {
                this.whereclause += "and (DateNote>='" + tpkDateNoteBegin.Value.ToShortDateString() + "' and DateNote<='" + tpkDateNoteEnd.Value.ToShortDateString() + "')";
            }
           
            if (this.ckbCapCompanyID.Checked)
            {
                this.whereclause += "and (CompanyID =" + this.ctrlSupplierID  .CompanyID .ToString () + ")";
            }
            if (this.ckbPrdID .Checked)
            {
                this.whereclause += "and (NoteID in(select NoteID from otherRes.BuyOrderItems where PrdID =" + this.ctrlPrdID .PrdID.ToString() + "))";
            }
            if (this.affterSearch != null) this.affterSearch(this.whereclause);
            this.Close();
        }
    }
}