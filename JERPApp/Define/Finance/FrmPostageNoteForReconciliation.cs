using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Finance
{
    public partial class FrmPostageNoteForReconciliation : Form
    {
        public FrmPostageNoteForReconciliation()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false; 
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accNotes = new JERPData.Finance.PostageNotes();
            this.accReconciliation = new JERPData.Finance.PostageReconciliations ();
            this.ckbFiter.CheckedChanged += new EventHandler(ckbFiter_CheckedChanged);
            this.btnConfirm.Click += new EventHandler(btnConfirm_Click);
        }

     
        private JERPData.Finance.PostageNotes accNotes;
        private JERPData.Finance.PostageReconciliations accReconciliation;
        private long ReconciliationID=-1;
       
        private DataTable dtblRecords;
        public void ReconciliationNote(long ReconciliationID,int Year,int Month)
        {
            this.ReconciliationID = ReconciliationID;
            this.ckbFiter.Checked = false;
            this.dtpDateBegin.Value = new DateTime(Year, Month, 1);
            this.dtpDateEnd.Value = new DateTime(Year, Month, DateTime.DaysInMonth(Year, Month));
            this.LoadData();
           
        }
        private void LoadData()
        {
            this.dtblRecords = this.accNotes.GetDataPostageNotesNeedReconciliation(this.ReconciliationID).Tables[0];
            this.dgrdv.DataSource = this.dtblRecords;
        }
        private void FiterData()
        {
            
            DataRow[] drows= this.dtblRecords.Select("DateNote<'"+this.dtpDateBegin .Value.ToShortDateString ()+"' or DateNote>'"+this.dtpDateEnd .Value .ToShortDateString ()+"'");
            foreach (DataRow drow in drows)
            {
                this.dtblRecords.Rows.Remove(drow);
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

        public delegate void AffterEnterDelegate();
        private AffterEnterDelegate affterEnter;
        public event AffterEnterDelegate AffterEnter
        {
            add
            {
                affterEnter += value;
            }
            remove
            {
                affterEnter -= value;
            }
        }
        void btnConfirm_Click(object sender, EventArgs e)
        {
            string errormsg=string.Empty ;
            bool flag = false;
            foreach (DataRow drow in this.dtblRecords.Select("", "", DataViewRowState.CurrentRows))
            {
                flag=this.accNotes.UpdatePostageNotesForReconciliation(ref errormsg,
                    drow["NoteID"], this.ReconciliationID);
                if (!flag)
                {
                    MessageBox.Show(errormsg);
                }
            }
            if (this.affterEnter != null) this.affterEnter();
            this.Close();
        }

    }
}