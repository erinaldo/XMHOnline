using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Payable.OutSrc
{
    public partial class FrmReconciliationCashOper : Form
    {
        public FrmReconciliationCashOper()
        {
            InitializeComponent();
            this.accReconciliations = new JERPData.Manufacture.OutSrcReconciliations();
            this.accLossSupplyItems = new JERPData.Material.OutSrcLossSupplyItems();
            this.accFineAMT = new JERPData.Manufacture.OutSrcFineAMTNotes();
            this.ctrlReceiveNoteReconciliationOper.AffterSelected += new CtrlReceiveNoteReconciliationOper.AffterSelectedDelegate(ctrlReceiveNoteReconciliationOper_AffterSelected);
            this.ReconciliationEntity = new JERPBiz.Manufacture.OutSrcReconciliationEntity();

            this.dgrdvLossSupply.AutoGenerateColumns = false;
            this.dgrdvFine.AutoGenerateColumns = false;


            this.dgrdvLossSupply.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdvLossSupply_UserDeletingRow);
            this.dgrdvLossSupply.UserDeletedRow += new DataGridViewRowEventHandler(dgrdvLossSupply_UserDeletedRow);
            this.dgrdvLossSupply.MouseClick += new MouseEventHandler(dgrdvLossSupply_MouseClick);

            this.dgrdvFine.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdvFine_UserDeletingRow);
            this.dgrdvFine.UserDeletedRow += new DataGridViewRowEventHandler(dgrdvFine_UserDeletedRow);
            this.dgrdvFine.MouseClick += new MouseEventHandler(dgrdvFine_MouseClick);


            this.btnDelete.Click += new EventHandler(btnDelete_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.FormClosed += new FormClosedEventHandler(FrmReconciliationOper_FormClosed); 
        }
        private JERPData.Manufacture.OutSrcReconciliations accReconciliations; 
        private JERPData.Manufacture.OutSrcFineAMTNotes accFineAMT;
        private JERPData.Material.OutSrcLossSupplyItems accLossSupplyItems;
        private JERPBiz.Manufacture.OutSrcReconciliationEntity ReconciliationEntity;
        private JERPApp.Define.Material.FrmOutSrcLossSupplyItemForReconciliation frmLossSupply;
        private JERPApp.Define.Manufacture.FrmOutSrcFineAMTForReconciliation frmFine;
        private DataTable  dtblLossSupplyAMT,dtblFineAMT;
        public delegate void AffterSaveDelegate();
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
        private long reconciliationid = 0;
        private long ReconciliationID
        {
            get
            {
                return this.reconciliationid;
            }
            set
            {
                this.reconciliationid = value;
                this.btnDelete.Enabled = (value > 0);
            }
        }
    
        public void Edit(long ReconciliationID)
        {
            this.ReconciliationID = ReconciliationID;
            this.ReconciliationEntity.LoadData(ReconciliationID);
            this.txtReconciliationCode.Text = this.ReconciliationEntity.ReconciliationCode;
            this.txtReconciliationName.Text = this.ReconciliationEntity.ReconciliationName;
            this.txtCompanyAbbName.Text = this.ReconciliationEntity.CompanyAbbName;
            this.txtYear.Text = this.ReconciliationEntity.Year.ToString();
            this.txtMonth.Text = this.ReconciliationEntity.Month.ToString();
            this.dtpDateNote .Value  = this.ReconciliationEntity.DateNote;
            this.dtpDateSettle.Value = this.ReconciliationEntity.DateSettle;
            this.txtMoneyTypeName.Text = this.ReconciliationEntity.MoneyTypeName;
            this.txtSettleTypeName.Text = this.ReconciliationEntity.SettleTypeName;
            this.txtDeliverAMT.Text = (this.ReconciliationEntity.DeliverAMT > 0) ? string.Format("{0:0.####}", this.ReconciliationEntity.DeliverAMT) : string.Empty;
            this.txtLossSupplyAMT.Text = (this.ReconciliationEntity.LossSupplyAMT  > 0) ? string.Format("{0:0.####}", this.ReconciliationEntity.LossSupplyAMT ) : string.Empty;
            this.txtFineAMT.Text = (this.ReconciliationEntity.FineAMT > 0) ? string.Format("{0:0.####}", this.ReconciliationEntity.FineAMT) : string.Empty;
            this.txtTotalAMT.Text = (this.ReconciliationEntity.TotalAMT > 0) ? string.Format("{0:#,##0.####}", this.ReconciliationEntity.TotalAMT) : string.Empty;

            this.SetRemindText();
            this.LoadLossSupply();
            this.LoadFine();
            this.ctrlReceiveNoteReconciliationOper.ReconciliationOper(ReconciliationID);
        }
        private void SetRemindText()
        {
            int cnt = 0;

            this.accLossSupplyItems.GetParmOutSrcLossSupplyItemsCountForReconciliation(this.ReconciliationID, ref cnt);
            this.pageLossSupply.Text = "超发料:" + cnt.ToString();

            cnt = 0;
            this.accFineAMT.GetParmOutSrcFineAMTNotesCountForReconciliation (this.ReconciliationID, ref cnt);
            this.pageFine .Text = "扣款:" + cnt.ToString();

        }
        void ctrlReceiveNoteReconciliationOper_AffterSelected(decimal TotalAMT)
        {
            this.txtDeliverAMT.Text = string.Format("{0:0.####}", TotalAMT);
            this.SetToatalAMT();
        }
        private void SetAMT(DataTable dtblItems, string fieldname, TextBox txt)
        {
            decimal AMT = 0;
            foreach (DataRow drow in dtblItems.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                AMT += (decimal)drow[fieldname];
            }
            txt.Text = string.Format("{0:0.####}", AMT);
            this.SetToatalAMT();
        }
        private void SetToatalAMT()
        {
            decimal deliveramt;
            if (!decimal.TryParse(this.txtDeliverAMT.Text, out deliveramt))
            {
                deliveramt = 0;
            }

            decimal losssupplyamt;
            if (!decimal.TryParse(this.txtLossSupplyAMT.Text, out losssupplyamt))
            {
                losssupplyamt = 0;
            }
            decimal fineamt;
            if (!decimal.TryParse(this.txtFineAMT.Text, out fineamt))
            {
                fineamt = 0;
            }
         
            this.txtTotalAMT.Text = string.Format("{0:0.####}", deliveramt -losssupplyamt -fineamt );
        }
        private void LoadLossSupply()
        {
            this.dtblLossSupplyAMT  = this.accLossSupplyItems.GetDataOutSrcLossSupplyItemsByReconciliationID (this.ReconciliationID).Tables[0];
            this.dgrdvLossSupply.DataSource = this.dtblLossSupplyAMT;
        }
        private void LoadFine()
        {
            this.dtblFineAMT = this.accFineAMT.GetDataOutSrcFineAMTNotesByReconciliationID  (this.ReconciliationID).Tables[0];
            this.dgrdvFine.DataSource = this.dtblFineAMT;
        }
        private void SaveAMT()
        {
            string errormsg = string.Empty;
            this.accReconciliations.UpdateOutSrcReconciliationsForAMT(ref errormsg, this.ReconciliationID);
        }

        void dgrdvLossSupply_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            object objNoteID = this.dtblLossSupplyAMT.DefaultView[irow]["NoteID"];
            if (objNoteID == DBNull.Value)
            {
                return;
            }
            string errormsg = string.Empty;
            bool flag = this.accLossSupplyItems.UpdateOutSrcLossSupplyItemsCancelReconciliation (
                ref errormsg, objNoteID);
            if (!flag)
            {

                MessageBox.Show(errormsg);
                e.Cancel = true;
            }

        }
        void dgrdvLossSupply_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            this.SetAMT(this.dtblLossSupplyAMT, "ItemAMT", this.txtLossSupplyAMT);
            this.SetRemindText();
        }
        void dgrdvLossSupply_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.ReconciliationID == 0) return;
            if (e.Button == MouseButtons.Right)
            {
                if (this.ReconciliationID > 0)
                {
                    if (frmLossSupply == null)
                    {
                        frmLossSupply = new JERPApp.Define.Material.FrmOutSrcLossSupplyItemForReconciliation();
                        new FrmStyle(frmLossSupply).SetPopFrmStyle(this);
                        frmLossSupply.AffterEnter += this.frmLossSupply_AffterEnter;
                    }
                    frmLossSupply.ReconciliationItem (this.ReconciliationID,this.ReconciliationEntity .Year ,this.ReconciliationEntity .Month );
                    frmLossSupply.ShowDialog();
                }
            }
        }
        void frmLossSupply_AffterEnter()
        {
            this.LoadLossSupply();
            this.SetAMT(this.dtblLossSupplyAMT, "ItemAMT", this.txtLossSupplyAMT);
            this.SetRemindText();
        }

        void dgrdvFine_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            object objNoteID = this.dtblFineAMT.DefaultView[irow]["NoteID"];
            if (objNoteID == DBNull.Value)
            {
                return;
            }
            string errormsg = string.Empty;
            bool flag = this.accFineAMT.UpdateOutSrcFineAMTNotesCancelReconciliation (
                ref errormsg, objNoteID);
            if (!flag)
            {

                MessageBox.Show(errormsg);
                e.Cancel = true;
            }

        }
        void dgrdvFine_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            this.SetAMT(this.dtblFineAMT, "Amount", this.txtFineAMT);
            this.SetRemindText();
        }
        void dgrdvFine_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.ReconciliationID == 0) return;
            if (e.Button == MouseButtons.Right)
            {
                if (this.ReconciliationID > 0)
                {
                    if (frmFine == null)
                    {
                        frmFine = new JERPApp.Define.Manufacture.FrmOutSrcFineAMTForReconciliation();
                        new FrmStyle(frmFine).SetPopFrmStyle(this);
                        frmFine.AffterConfirm += frmFine_AffterEnter;
                    }
                    frmFine.LoadReconciliaion(this.ReconciliationID);
                    frmFine.ShowDialog();
                }
            }
        }
        void frmFine_AffterEnter()
        {
            this.LoadFine();
            this.SetAMT(this.dtblFineAMT, "Amount", this.txtFineAMT);
            this.SetRemindText();
        }
    
   
        void btnSave_Click(object sender, EventArgs e)
        {
            string errormsg = string.Empty;
            bool flag = false;
            flag=this.accReconciliations.UpdateOutSrcReconciliations(ref errormsg, this.ReconciliationID,
                this.txtReconciliationCode.Text,
                this.txtReconciliationName .Text ,
                this.dtpDateNote.Value.Date,
                this.dtpDateSettle .Value .Date ,
                JERPBiz.Frame.UserBiz.PsnID);
            if (flag)
            {
                this.ctrlReceiveNoteReconciliationOper.Save();
                MessageBox.Show("成功进行单据的保存");
            }
            else
            {
                MessageBox.Show(errormsg);
            }
        }
        void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult rut = MessageBox.Show("你将删除当前对账单及明细，你的删除将不能恢复，确认否?", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rut == DialogResult.Yes)
            {
                string errormsg = string.Empty;
                bool flag = false;
                flag = this.accReconciliations.DeleteOutSrcReconciliations(ref errormsg, this.ReconciliationID);
                if (flag)
                {
                    MessageBox.Show("删除当前对账单及明细！");
                }
                else
                {
                    MessageBox.Show(errormsg);
                }
              
                this.Close();
            }
        }      
        void FrmReconciliationOper_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.ReconciliationID > 0)
            {
                this.SaveAMT();
               if (this.affterSave != null) this.affterSave();
            }
        }
    }
}