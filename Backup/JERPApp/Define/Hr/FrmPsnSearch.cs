using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Hr
{
    public partial class FrmPsnSearch : Form
    {
        public FrmPsnSearch()
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
            if (this.ckbPsnCode .Checked)
            {
                this.whereclause += "and (PsnCode like '%" + txtPsnCode.Text + "%')";
            }
            if (this.ckbCapDeptName.Checked)
            {
                this.whereclause += "and (DeptName like '%" + this.ctrlDeptID .DeptID .ToString ()+"%')";
            }
            if (this.ckbCapPosition.Checked)
            {
                this.whereclause += "and (Position like '%" + txtPosition.Text + "%')";
            }
            if (this.ckbCapDateHire.Checked)
            {
                this.whereclause += "and (DateHire>='" + tpkDateHireBegin.Value.ToShortDateString() + "' and DateHire<='" + tpkDateHireEnd.Value.ToShortDateString() + "')";
            }
            if (this.ckbCapProvince.Checked)
            {
                this.whereclause += "and (Province like '%" + txtProvince.Text + "%')";
            }
            if (this.ckbCapDiploma.Checked)
            {
                this.whereclause += "and (Diploma like '%" + txtDiploma.Text + "%')";
            }
            if (this.ckbCapDismissFlag.Checked)
            {
                if (this.radDissmiss.Checked)
                {
                    this.whereclause += "and (DateDismiss is not null)";
                }
                else
                {
                    this.whereclause += "and (DateDismiss is  null)";
                }
            }
            if (this.affterSearch != null) this.affterSearch(this.whereclause);
            this.Close();
        }
    }
}