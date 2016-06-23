using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Payable.Tool
{
    public partial class FrmReconciliationCashOper : Form
    {
        public FrmReconciliationCashOper()
        {
            InitializeComponent();
            this.accReconciliations = new JERPData.Tool.BuyReconciliations(); 
            this.accFineAMT = new JERPData.Tool.BuyFineAMTNotes();
            this.ReconciliationEntity = new JERPBiz.Tool.BuyReconciliationEntity();

           

            this.dgrdvFine.AutoGenerateColumns = false;
            this.dgrdvFine.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdvFine_UserDeletingRow);
            this.dgrdvFine.UserDeletedRow += new DataGridViewRowEventHandler(dgrdvFine_UserDeletedRow);
            this.dgrdvFine.MouseClick += new MouseEventHandler(dgrdvFine_MouseClick);


            this.btnDelete.Click += new EventHandler(btnDelete_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.FormClosed += new FormClosedEventHandler(FrmReconciliationOper_FormClosed);
            this.ctrlReceiveNoteReconciliationOper.AffterSelected += new CtrlReceiveNoteReconciliationOper.AffterSelectedDelegate(ctrlReceiveNoteReconciliationOper_AffterSelected);
        }

       
        private JERPData.Tool.BuyReconciliations accReconciliations; 
        private JERPData.Tool.BuyFineAMTNotes accFineAMT;
        private JERPBiz.Tool.BuyReconciliationEntity ReconciliationEntity;  
        private JERPApp.Define.Tool.FrmBuyFineAMTForReconciliation frmFine;
        private DataTable  dtblFineAMT;
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
            this.txtFineAMT.Text = (this.ReconciliationEntity.FineAMT > 0) ? string.Format("{0:0.####}", this.ReconciliationEntity.FineAMT) : string.Empty;
            this.txtTotalAMT.Text = (this.ReconciliationEntity.TotalAMT > 0) ? string.Format("{0:#,##0.####}", this.ReconciliationEntity.TotalAMT) : string.Empty;

            this.SetRemindText(); 
            this.LoadFine();
        }
        private void SetRemindText()
        {
            int cnt = 0; 
            this.accFineAMT.GetParmBuyFineAMTNotesCountForReconciliation (this.ReconciliationID, ref cnt);
            this.pageFine .Text = "扣款:" + cnt.ToString();
          
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
        void ctrlReceiveNoteReconciliationOper_AffterSelected(decimal TotalAMT)
        {
            this.txtDeliverAMT.Text = string.Format("{0:0.####}", TotalAMT);
            this.SetToatalAMT();
        }

       

        private void SetToatalAMT()
        {
            decimal TotalAMT = 0;
            decimal tmp;
            if (decimal.TryParse(this.txtDeliverAMT.Text, out tmp) == false)
            {
                tmp = 0;
            } 
            TotalAMT += tmp;
            tmp = 0;
            foreach (DataRow drow in this.dtblFineAMT.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                tmp += (decimal)drow["Amount"];
            }
            this.txtFineAMT.Text = string.Format("{0:0.####}", tmp);
            TotalAMT += -tmp;
            this.txtTotalAMT.Text = string.Format("{0:0.####}", TotalAMT);
        }
        
      
        private void LoadFine()
        {
            this.dtblFineAMT = this.accFineAMT.GetDataBuyFineAMTNotesByReconciliationID  (this.ReconciliationID).Tables[0];
            this.dgrdvFine.DataSource = this.dtblFineAMT;
        }
        private void SaveAMT()
        {
            string errormsg = string.Empty;
            this.accReconciliations.UpdateBuyReconciliationsForAMT(ref errormsg, this.ReconciliationID);
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
            bool flag = this.accFineAMT.UpdateBuyFineAMTNotesCancelReconciliation (
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
                        frmFine = new JERPApp.Define.Tool.FrmBuyFineAMTForReconciliation();
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
            flag=this.accReconciliations.UpdateBuyReconciliations(ref errormsg, this.ReconciliationID,
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
                flag = this.accReconciliations.DeleteBuyReconciliations(ref errormsg, this.ReconciliationID);
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