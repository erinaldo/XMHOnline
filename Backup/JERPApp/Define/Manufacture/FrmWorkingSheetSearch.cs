using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Manufacture
{
    public partial class FrmWorkingSheetSearch : Form
    {
        public FrmWorkingSheetSearch()
        {
            InitializeComponent();
            this.dtpDateBegin.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            this.dtpDateEnd.Value = DateTime.Now.Date;
            
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
            if (this.ckbWorkingSheetCode .Checked )
            {
                this.whereclause += "and (WorkingSheetCode like '%"+this.txtWorkingSheetCode .Text +"%') ";               
            }
            if (this.ckbCustomer .Checked)
            {
                this.whereclause += "and (CompanyID="+this.ctrlCompanyID .CompanyID .ToString ()+")";
            }
            if (this.ckbDateWorkingSheet.Checked)
            {
                this.whereclause += "and (DateNote>='"+this.dtpDateBegin .Value .Date.ToShortDateString ()+ "' and DateNote<='"+
                    this.dtpDateEnd .Value .Date .ToShortDateString ()+"')";
            }
            if (this.ckbPONo .Checked)
            {
                this.whereclause += "and (PONo like '%" + this.txtPONo .Text + "%')";
            }
            if (this.ckbPrdID.Checked)
            {
                this.whereclause += " and (PrdID=" + this.ctrlPrdID.PrdID.ToString() + ")";
            }
            if (this.ckbNonFinishedFlag.Checked)
            {
                this.whereclause += " and (NonFinishedQty>0)";
            }
            if (this.affterSearch != null)
            {                
                this.affterSearch(this.whereclause);
            }
            this.Close();
        }
    }
}