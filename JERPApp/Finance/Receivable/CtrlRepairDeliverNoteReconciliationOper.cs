using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Receivable
{
    public partial class CtrlRepairDeliverNoteReconciliationOper : UserControl
    {
        public CtrlRepairDeliverNoteReconciliationOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accRepairNotes = new JERPData.Product.RepairDeliverNotes();
            this.ReconciliationEntity = new JERPBiz.Product.SaleReconciliationEntity();
            this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
            this.dgrdv .CellValueChanged += new DataGridViewCellEventHandler(dgrdv_CellValueChanged);
        }
        private JERPData.Product.RepairDeliverNotes accRepairNotes;
        private DataTable dtblRepairNotes;
        private JERPBiz.Product.SaleReconciliationEntity ReconciliationEntity;
        private JERPApp.Store.Product.Report.Bill.FrmRepairDeliverNote frmDetail;
        private long ReconciliationID = -1;
        public delegate void AffterSelectedDelegate(decimal TotalAMT);
        private AffterSelectedDelegate affterSelected;
        public event AffterSelectedDelegate AffterSelected
        {
            add
            {
                affterSelected += value;
            }
            remove
            {
                affterSelected -= value;
            }
        }
        public void ReconciliationOper(long ReconciliationID)
        {
            this.ReconciliationID = ReconciliationID;
            this.ReconciliationEntity.LoadData(ReconciliationID);
            this.dtblRepairNotes = this.accRepairNotes.GetDataRepairDeliverNotesForReconciliation (
                 this.ReconciliationEntity.CompanyID,
                 this.ReconciliationEntity.FinanceAddressID,
                 this.ReconciliationEntity.MoneyTypeID).Tables[0];
            this.dtblRepairNotes.Columns.Add("CheckedFlag", typeof(bool));
            foreach (DataRow drowNote in this.dtblRepairNotes.Rows)
            {
                drowNote["CheckedFlag"] = false;
            } 
            DataTable dtblTmp = this.accRepairNotes.GetDataRepairDeliverNotesByReconciliationID(ReconciliationID).Tables[0];
            dtblTmp.Columns.Add("CheckedFlag", typeof(bool));
            foreach (DataRow drow in dtblTmp.Rows)
            {
                drow["CheckedFlag"] = true;
                this.dtblRepairNotes.ImportRow(drow);
            }
            this.dgrdv.DataSource = this.dtblRepairNotes;
        }
        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnNoteCode.Name)
            {
                long NoteID = (long)this.dtblRepairNotes.DefaultView[irow]["NoteID"];
                if (frmDetail == null)
                {
                    frmDetail = new JERPApp.Store.Product.Report.Bill.FrmRepairDeliverNote();
                    new FrmStyle(frmDetail).SetPopFrmStyle(this);
                }
                this.frmDetail.DetailNote(NoteID);
                this.frmDetail.ShowDialog();
            }

        }
        void dgrdv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            decimal TotalAMT = 0;
            foreach (DataGridViewRow grow in this.dgrdv .Rows)
            {
                if (grow.Cells[this.ColumnCheckedFlag.Name].Value == DBNull.Value) continue;
                if ((bool)grow.Cells[this.ColumnCheckedFlag.Name].Value)
                {
                    TotalAMT += (decimal)grow.Cells[this.ColumnTotalAMT.Name].Value;
                }
            }
            if (this.affterSelected != null) this.affterSelected(TotalAMT);
        }
        public void Save()
        {
            string errormsg = string.Empty;
            foreach (DataRow drow in this.dtblRepairNotes.Rows)
            {
                if (drow.RowState == DataRowState.Unchanged) continue;
                if ((bool)drow["CheckedFlag"])
                {
                    this.accRepairNotes.UpdateRepairDeliverNotesForReconciliation(ref errormsg,
                        drow["NoteID"],
                        this.ReconciliationID);
                }
                else
                {
                    this.accRepairNotes.UpdateRepairDeliverNotesCancelReconciliation(ref errormsg,
                       drow["NoteID"]);
                }
                drow.AcceptChanges();
            }
        }
    }
}
