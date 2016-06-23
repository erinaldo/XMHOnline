using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Receivable
{
    public partial class CtrlSaleDeliverNoteReconciliationOper : UserControl
    {
        public CtrlSaleDeliverNoteReconciliationOper()
        {
            InitializeComponent(); 
            this.dgrdvNote.AutoGenerateColumns = false;
            this.dgrdvItem.AutoGenerateColumns = false;
            this.accDeliverNotes = new JERPData.Product.SaleDeliverNotes();
            this.accOrderItems = new JERPData.Product.SaleOrderItems();
            this.ReconciliationEntity = new JERPBiz.Product.SaleReconciliationEntity();
            this.dgrdvNote.CellContentClick += new DataGridViewCellEventHandler(dgrdvNote_CellContentClick);
            this.dgrdvNote.CellValueChanged += new DataGridViewCellEventHandler(dgrdvNote_CellValueChanged);
        }

        private JERPData.Product.SaleDeliverNotes accDeliverNotes;
        private JERPData.Product.SaleOrderItems accOrderItems;
        private JERPApp.Store.Product.Report.Bill.FrmSaleDeliverNote frmDetail;
        private JERPBiz.Product.SaleReconciliationEntity ReconciliationEntity;
        private DataTable dtblDeliverNotes, dtblOrderItems;
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
        private long ReconciliationID = -1; 
        public void ReconciliationOper(long ReconciliationID)
        {
            this.ReconciliationID = ReconciliationID;
            this.ReconciliationEntity.LoadData(ReconciliationID);           
            this.dtblDeliverNotes = this.accDeliverNotes.GetDataSaleDeliverNotesForReconciliation (
              this.ReconciliationEntity .SaleOrderNoteID,
              this.ReconciliationEntity .CompanyID,
              this.ReconciliationEntity .FinanceAddressID,
              this.ReconciliationEntity .MoneyTypeID).Tables[0];
            this.dtblDeliverNotes.Columns.Add("CheckedFlag", typeof(bool));
            foreach (DataRow drowNote in this.dtblDeliverNotes.Rows)
            {
                drowNote["CheckedFlag"] = false ;
            }
            DataTable dtblTmp = this.accDeliverNotes.GetDataSaleDeliverNotesByReconciliationID(ReconciliationID).Tables[0];
            dtblTmp.Columns.Add("CheckedFlag", typeof(bool));
            foreach (DataRow drow in dtblTmp.Rows)
            {
                drow["CheckedFlag"] = true;
                this.dtblDeliverNotes.ImportRow(drow);
            }
            this.dgrdvNote.DataSource = this.dtblDeliverNotes;


            this.dtblOrderItems = this.accOrderItems.GetDataSaleOrderItemsByNoteID(this.ReconciliationEntity .SaleOrderNoteID).Tables[0];
            this.dgrdvItem.DataSource = this.dtblOrderItems;
            if (this.dtblOrderItems.Rows.Count > 1)
            {
                DataRow drowNew = this.dtblOrderItems.NewRow();
                drowNew["PrdCode"] = "ºÏ¼Æ";
                drowNew["Quantity"] = this.dtblOrderItems.Compute("SUM(Quantity)", "");
                drowNew["FinishedQty"] = this.dtblOrderItems.Compute("SUM(FinishedQty)", "");
                drowNew["NonFinishedQty"] = this.dtblOrderItems.Compute("SUM(NonFinishedQty)", "");
                this.dtblOrderItems.Rows.InsertAt(drowNew, 0);
            }
        }
        void dgrdvNote_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvNote.Columns[icol].Name == this.ColumnNoteCode.Name)
            {
                long NoteID = (long)this.dtblDeliverNotes .DefaultView[irow]["NoteID"];
                if (frmDetail == null)
                {
                    frmDetail = new JERPApp.Store.Product.Report.Bill.FrmSaleDeliverNote();
                    new FrmStyle(frmDetail).SetPopFrmStyle(this.ParentForm );
                }
                this.frmDetail.DetailNote(NoteID);
                this.frmDetail.ShowDialog();
            }

        }

        void dgrdvNote_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            decimal TotalAMT = 0;
            foreach (DataGridViewRow grow in this.dgrdvNote.Rows)
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
            foreach (DataRow drow in this.dtblDeliverNotes.Rows)
            {
                if (drow.RowState == DataRowState.Unchanged) continue;
                if ((bool)drow["CheckedFlag"])
                {
                    this.accDeliverNotes.UpdateSaleDeliverNotesForReconciliation(ref errormsg,
                        drow["NoteID"],
                        this.ReconciliationID);
                }
                else
                {
                    this.accDeliverNotes.UpdateSaleDeliverNotesCancelReconciliation (ref errormsg,
                       drow["NoteID"] );
                }
                drow.AcceptChanges();
            }
            

        }
    }

}
