using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Payable.Postage
{
    public partial class FrmReconciliationOper : Form
    {
        public FrmReconciliationOper()
        {
            InitializeComponent();
            this.accReconciliations = new JERPData.Finance.PostageReconciliations();
            this.accNotes = new JERPData.Finance.PostageNotes();       
            this.ReconciliationEntity = new JERPBiz.Finance.PostageReconciliationEntity();
            this.dgrdv.AutoGenerateColumns = false;         
            this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
            this.dgrdv.UserDeletedRow += new DataGridViewRowEventHandler(dgrdv_UserDeletedRow);
            this.dgrdv.MouseClick += new MouseEventHandler(dgrdv_MouseClick);           
            this.btnDelete.Click += new EventHandler(btnDelete_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnNew .Click +=new EventHandler(btnNew_Click);
            this.Shown += new EventHandler(FrmReconciliationOper_Shown);
            this.FormClosed += new FormClosedEventHandler(FrmReconciliationOper_FormClosed);
        }

     

        private JERPData.Finance.PostageReconciliations accReconciliations;
        private JERPData.Finance.PostageNotes accNotes;
        private FrmReconciliationNew frmNew;
        private JERPBiz.Finance.PostageReconciliationEntity ReconciliationEntity;
        private JERPApp.Define .Finance.FrmPostageNoteForReconciliation   frmPostageNote;
        private DataTable dtblNotes;
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
        private long reconciliationid =0;
        private long ReconciliationID
        {
            get
            {
                return this.reconciliationid;
            }
            set
            {
                this.reconciliationid = value;
                this.btnDelete.Enabled = (value >0);
            }
        }
        private void LoadRecord()
        {
            this.dtblNotes = this.accNotes.GetDataPostageNotesByReconciliationID(this.ReconciliationID).Tables[0];
            this.dgrdv.DataSource = this.dtblNotes;
        }
        public void New()
        {
            this.ReconciliationID = 0;
            this.txtReconciliationCode.Text = string.Empty;
            this.txtReconciliationName.Text = string.Empty;
            this.txtCompanyName.Text = string.Empty;
            this.txtTotalAMT.Text = string.Empty;
            this.SetRemindText();
            this.LoadRecord();
        }
        public void Edit(long ReconciliationID)
        {
            this.ReconciliationID = ReconciliationID;
            this.ReconciliationEntity.LoadData(ReconciliationID);
            this.txtReconciliationCode.Text = this.ReconciliationEntity.ReconciliationCode;
            this.txtReconciliationName.Text = this.ReconciliationEntity.ReconciliationName;
            this.txtCompanyName.Text = this.ReconciliationEntity.CompanyName;
            this.txtYear.Text = this.ReconciliationEntity.Year.ToString();
            this.txtMonth.Text = this.ReconciliationEntity.Month.ToString();
            this.dtpDateNote .Value  = this.ReconciliationEntity.DateNote;
            this.dtpDateSettle.Value = this.ReconciliationEntity.DateSettle ;
            this.txtTotalAMT.Text = string.Format("{0:0.####}", this.ReconciliationEntity.TotalAMT);
            this.SetRemindText();
            this.LoadRecord();
        
        }
        private void SetRemindText()
        {
            int cnt=0;
            this.accNotes.GetParmPostageNotesCountForReconciliation(this.ReconciliationID, ref cnt);
            this.tabReceive.Text = "未做:" + cnt.ToString();
         
        }
        private void ComputeAMT()
        {
            decimal totalamt = 0;
            foreach (DataRow drow in this.dtblNotes.Rows)
            {
                if(drow.RowState ==DataRowState .Deleted )continue ;
                totalamt += (decimal)drow["Amount"];
            }
            this.txtTotalAMT.Text = string.Format("{0:0.####}", totalamt);
        }
        private void SaveTotalAMT()
        {
            string errormsg=string.Empty ;
            this.accReconciliations.UpdatePostageReconciliationsForTotalAMT(ref errormsg, this.ReconciliationID);

        }
        private void ShowFrmNew()
        {
            if (this.frmNew == null)
            {
                this.frmNew = new FrmReconciliationNew();
                new FrmStyle(frmNew).SetPopFrmStyle(this);
                this.frmNew.AffterSave += this.Edit;
            }
            frmNew.New();
            frmNew.ShowDialog();
        }
        void btnNew_Click(object sender, EventArgs e)
        {
            this.New();
            this.ShowFrmNew();
        }

        void FrmReconciliationOper_Shown(object sender, EventArgs e)
        {
            if (this.ReconciliationID == 0)
            {
                this.ShowFrmNew();
            }
        }
        void dgrdv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            object objNoteID = this.dtblNotes.DefaultView[irow]["NoteID"];
            if (objNoteID == DBNull.Value)
            {
                return;
            }
            string errormsg = string.Empty;
            bool flag = this.accNotes .UpdatePostageNotesCancelReconciliation (
                ref errormsg, objNoteID);
            if (!flag)
            {
                MessageBox.Show(errormsg);
                e.Cancel = true;
            }
            else
            {
                this.SaveTotalAMT();
                this.SetRemindText();
            }
        }

        void dgrdv_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            this.ComputeAMT();
        }

        void dgrdv_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                if (this.ReconciliationID > 0)
                {
                    if (frmPostageNote  == null)
                    {
                        frmPostageNote = new JERPApp.Define.Finance.FrmPostageNoteForReconciliation();
                        new FrmStyle(frmPostageNote).SetPopFrmStyle(this);
                        frmPostageNote.AffterEnter += new JERPApp.Define.Finance.FrmPostageNoteForReconciliation.AffterEnterDelegate(frmPostageNote_AffterEnter);
                    }
                    frmPostageNote.ReconciliationNote (this.ReconciliationID, this.ReconciliationEntity.Year, this.ReconciliationEntity.Month);
                    frmPostageNote.ShowDialog();
                }
            }
        }

        void frmPostageNote_AffterEnter()
        {
            this.LoadRecord();
            this.ComputeAMT();
            this.SetRemindText();
        }



        void btnSave_Click(object sender, EventArgs e)
        {
            string errormsg = string.Empty;
            bool flag = false;
            flag=this.accReconciliations.UpdatePostageReconciliations(
                ref errormsg,
                this.ReconciliationID, 
                this.txtReconciliationCode.Text,
                this.txtReconciliationName .Text ,
                this.dtpDateNote.Value.Date,
                this.dtpDateSettle .Value .Date ,
                JERPBiz.Frame.UserBiz.PsnID);
            if (flag)
            {
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
                flag = this.accReconciliations.DeletePostageReconciliations (ref errormsg, this.ReconciliationID);
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
            if (this.ReconciliationID > -1)
            {
                this.SaveTotalAMT();
                if (this.affterSave != null) this.affterSave();
            }
        }

    }
}