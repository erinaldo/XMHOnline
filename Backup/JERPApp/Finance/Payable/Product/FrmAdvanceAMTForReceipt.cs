using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Payable.Product
{
    public partial class FrmAdvanceAMTForReceipt : Form
    {
        public FrmAdvanceAMTForReceipt()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlGridCheckBox.SeachGridView = this.dgrdv;
            this.accRecords = new JERPData.Product.BuyAdvanceAMTRecords();
            this.btnSave.Click += new EventHandler(btnSave_Click);
        }

        private JERPData.Product.BuyAdvanceAMTRecords  accRecords;
        private DataTable dtblNotes;
        public delegate void AffterSaveDelegate(DataRow[] drows);
        private AffterSaveDelegate affterSave;
        public event AffterSaveDelegate AffterSave
        {
            add
            {
                affterSave += value;
            }
            remove
            {
                affterSave -= value;
            }
        }
        private decimal NonFinishedAMT = 0;
        public void AdvanceOper(int CompanyID, int MoneyTypeID, decimal NonFinishedAMT)
        {
            this.NonFinishedAMT = NonFinishedAMT;
            this.dtblNotes = this.accRecords.GetDataBuyAdvanceAMTRecordsForReceipt (CompanyID, MoneyTypeID).Tables[0];
            this.dtblNotes.Columns.Add("CheckedFlag", typeof(bool));
            this.dgrdv.DataSource = this.dtblNotes;

        }

        void btnSave_Click(object sender, EventArgs e)
        {
            decimal AdvanceAMT = 0;
            foreach (DataGridViewRow grow in this.dgrdv .Rows)
            {
                if (grow.Cells[this.ColumnCheckedFlag.Name].Value == DBNull.Value) continue;
                if (!(bool)grow.Cells[this.ColumnCheckedFlag.Name].Value) continue;
                AdvanceAMT += (decimal)grow.Cells[this.ColumnAmount.Name].Value;
            }
            if (AdvanceAMT > NonFinishedAMT)
            {
                MessageBox.Show("对不起,预付款不能大于未完成金额");
                return;
            }
            if (this.affterSave != null) this.affterSave(this.dtblNotes.Select("CheckedFlag=1"));
            this.Close();
        }
    }
}