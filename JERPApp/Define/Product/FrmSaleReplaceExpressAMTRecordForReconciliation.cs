using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Product
{
    public partial class FrmSaleReplaceExpressAMTRecordForReconciliation : Form
    {
        public FrmSaleReplaceExpressAMTRecordForReconciliation()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accRecords = new JERPData.Product.SaleReplaceExpressAMTRecord();
            int Year = DateTime.Now.Year;
            int Month = DateTime.Now.Month;
            this.dtpBegin.Value = new DateTime(Year, Month, 1);
            this.dtpDateEnd.Value = new DateTime(Year, Month, DateTime .DaysInMonth (Year ,Month ));
            this.ckbFiter.CheckedChanged += new EventHandler(ckbFiter_CheckedChanged);
            this.btnConfirm.Click += new EventHandler(btnConfirm_Click);
        }

       
        private JERPData.Product.SaleReplaceExpressAMTRecord   accRecords;
        private DataTable dtblItems;
        private long ReconciliationID = -1;
        public void LoadReconciliaion(long ReconciliationID)
        {
            this.ReconciliationID = ReconciliationID;          
            this.LoadData();
        }
        private void LoadData()
        {

            this.dtblItems = this.accRecords.GetDataSaleReplaceExpressAMTRecordForReconciliation   (
             this.ReconciliationID 
                ).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
        }
        private void FiterData()
        {

            DataRow[] drows = this.dtblItems.Select("DateNote<'" + this.dtpBegin.Value.ToShortDateString() + "' or DateNote>'" + this.dtpDateEnd.Value.ToShortDateString() + "'");
            foreach (DataRow drow in drows)
            {
                this.dtblItems.Rows.Remove(drow);
            }
        }

        void ckbFiter_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbFiter.Checked)
            {
                FiterData();
            }
            else
            {
                this.LoadData();
            }
        }
        public delegate void AffterConfirmDelegate();
        private AffterConfirmDelegate affterConfirm;
        public event AffterConfirmDelegate AffterConfirm
        {
            add
            {
                affterConfirm += value;
            }
            remove
            {
                affterConfirm -= value;
            }
        }    
        void btnConfirm_Click(object sender, EventArgs e)
        {
            string errormsg=string.Empty ;
            foreach (DataRow drow in this.dtblItems.Select("", "", DataViewRowState.CurrentRows))
            {
                this.accRecords.UpdateSaleReplaceExpressAMTRecordForReconciliation  (ref errormsg, drow["RecordID"],
                    this.ReconciliationID);
            }
            if (this.affterConfirm != null) this.affterConfirm();
            this.Close();
        }
    }
}