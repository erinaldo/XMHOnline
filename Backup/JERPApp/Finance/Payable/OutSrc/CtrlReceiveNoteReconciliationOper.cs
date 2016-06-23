using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Payable.OutSrc
{
    public partial class CtrlReceiveNoteReconciliationOper : UserControl
    {
        public CtrlReceiveNoteReconciliationOper()
        {
            InitializeComponent(); 
            this.dgrdvNote.AutoGenerateColumns = false;
            this.dgrdvItem.AutoGenerateColumns = false;
            this.accReceiveNotes = new JERPData.Manufacture.OutSrcReceiveNotes();
            this.accOrderItems = new JERPData.Manufacture.OutSrcOrderItems();
            this.ReconciliationEntity = new JERPBiz.Manufacture.OutSrcReconciliationEntity();
            this.dgrdvNote.CellContentClick += new DataGridViewCellEventHandler(dgrdvNote_CellContentClick);
            this.dgrdvNote.CellValueChanged += new DataGridViewCellEventHandler(dgrdvNote_CellValueChanged);
        }

        private JERPData.Manufacture.OutSrcReceiveNotes accReceiveNotes;
        private JERPData.Manufacture.OutSrcOrderItems accOrderItems;
        private JERPApp.Store.Material .Report.Bill.FrmOutSrcReceiveNote frmDetail;
        private JERPBiz.Manufacture.OutSrcReconciliationEntity ReconciliationEntity;
        private DataTable dtblReceiveNotes, dtblOrderItems;
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
            this.dtblReceiveNotes = this.accReceiveNotes.GetDataOutSrcReceiveNotesForReconciliation (
              this.ReconciliationEntity .OutSrcOrderNoteID,
              this.ReconciliationEntity .CompanyID,
              this.ReconciliationEntity .MoneyTypeID,
              this.ReconciliationEntity .SettleTypeID ).Tables[0];
            this.dtblReceiveNotes.Columns.Add("CheckedFlag", typeof(bool));
            foreach (DataRow drowNote in this.dtblReceiveNotes.Rows)
            {
                drowNote["CheckedFlag"] = false ;
            }
            DataTable dtblTmp = this.accReceiveNotes.GetDataOutSrcReceiveNotesByReconciliationID(ReconciliationID).Tables[0];
            dtblTmp .Columns .Add ("CheckedFlag",typeof (bool));
            foreach (DataRow drow in dtblTmp.Rows)
            {
                drow["CheckedFlag"] = true;
                this.dtblReceiveNotes.ImportRow(drow);
            }
            this.dgrdvNote.DataSource = this.dtblReceiveNotes;


            this.dtblOrderItems = this.accOrderItems.GetDataOutSrcOrderItemsByNoteID(this.ReconciliationEntity .OutSrcOrderNoteID).Tables[0];
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
                long NoteID = (long)this.dtblReceiveNotes .DefaultView[irow]["NoteID"];
                if (frmDetail == null)
                {
                    frmDetail = new JERPApp.Store.Material.Report.Bill.FrmOutSrcReceiveNote();
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
            foreach (DataRow drow in this.dtblReceiveNotes.Rows)
            {
                if (drow.RowState == DataRowState.Unchanged) continue;
                if ((bool)drow["CheckedFlag"])
                {
                    this.accReceiveNotes.UpdateOutSrcReceiveNotesForReconciliation(ref errormsg,
                        drow["NoteID"],
                        this.ReconciliationID);
                }
                else
                {
                    this.accReceiveNotes.UpdateOutSrcReceiveNotesCancelReconciliation (ref errormsg,
                       drow["NoteID"] );
                }
                drow.AcceptChanges();
            }
            

        }
    }

}
