using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Material
{
    public partial class FrmOEMOrderItemSearchItem : Form
    {
        public FrmOEMOrderItemSearchItem()
        {
            InitializeComponent();
            DateTime today = DateTime.Now.Date;          
            this.dtpNoteBegin.Value = new DateTime(today.Year, today.Month, 1);
            this.dtpNoteEnd.Value = today;
        }
        private string whereclause = string.Empty;
        public delegate void AffterSearchDelegate(string whereclasue);
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
          
            if (this.ckbPONo.Checked)
            {
                this.whereclause += " and (PONo like '" + this.txtPONo.Text + "%')";
            }
            if (this.ckbCompany.Checked)
            {
                this.whereclause += " and (CompanyID=" + this.ctrlCustomerID .CompanyID.ToString() + ")";
            }
            if (this.ckbPrd.Checked)
            {
                this.whereclause += " and (PrdID=" + this.ctrlPrdID.PrdID.ToString() + ")";
            }
                        if (this.ckbDateTarget.Checked)
            {
                this.whereclause += " and(DateTarget >='" + this.dtpNoteBegin.Value.ToShortDateString() +
                    "' and DateTarget<= '" + this.dtpNoteEnd.Value.ToShortDateString() + "')";
            }
               
            if (this.affterSearch != null)
            {
                this.affterSearch(this.whereclause);
            }
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}