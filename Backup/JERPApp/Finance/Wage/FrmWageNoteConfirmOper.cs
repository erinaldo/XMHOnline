using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Wage
{
    public partial class FrmWageNoteConfirmOper : Form
    {
        public FrmWageNoteConfirmOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accItems = new JERPData.Finance.WageItems();
            this.accNotes = new JERPData.Finance.WageNotes();
            this.NoteEntity = new JERPBiz.Finance.WageNoteEntity();
            this.accWageType = new JERPData.Finance.OtherWageType();
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.CreateColumn();
        }        
        private JERPData.Finance.WageNotes accNotes;
        private JERPData.Finance.WageItems accItems;
        private JERPBiz.Finance.WageNoteEntity NoteEntity;
        private JERPData.Finance.OtherWageType accWageType;
        private DataTable dtblItems,dtblWageType;
        private long noteid = -1;
        private long NoteID
        {
            get
            {
                return this.noteid;
            }
            set
            {
                this.noteid = value;
              
            }
        }
        public delegate void AffterSaveDelegate();
        protected AffterSaveDelegate affterSave;
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
    
        private void CreateColumn()
        {
            this.dtblWageType = this.accWageType.GetDataOtherWageType().Tables[0];
            DataGridViewTextBoxColumn txtcol;          
            foreach (DataRow drow in this.dtblWageType.Rows)
            {
                txtcol = new DataGridViewTextBoxColumn();
                txtcol.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                txtcol.DataPropertyName = drow["WageTypeName"].ToString();
                txtcol.HeaderText = drow["WageTypeName"].ToString();
                txtcol.DefaultCellStyle.Format = "0.#####"; 
                this.dgrdv.Columns.Add(txtcol);
            }
            txtcol = new DataGridViewTextBoxColumn();
            txtcol.Width = 60;
            txtcol.DataPropertyName = "TotalWage";
            txtcol.HeaderText = "合计";
            txtcol.DefaultCellStyle.Format  = "0.#####";      
            this.dgrdv.Columns.Add(txtcol);
            this.ctrlQFind.SeachGridView = this.dgrdv;
        }
       
        public void ConfirmOper(long NoteID)
        {
            this.NoteID = NoteID;
            this.NoteEntity.LoadData(NoteID);
            this.txtYear .Text  = this.NoteEntity.Year.ToString ();
            this.txtMonth .Text  = this.NoteEntity.Month.ToString ();
            this.txtDateBegin.Text  = this.NoteEntity.DateBegin.ToShortDateString ();
            this.txtDateEnd.Text = this.NoteEntity.DateEnd.ToShortDateString ();
            this.dtblItems = this.accItems.GetDataWageItemsPivotWageTypeByNoteID (this.NoteID).Tables[0];         
            this.dgrdv.DataSource = this.dtblItems;
           
        }
        void btnSave_Click(object sender, EventArgs e)
        {
            string errormsg = string.Empty;
            DialogResult rut = MessageBox.Show("即将对当前工资单进行审核，一经审核不能变更，确认否?", "审核确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rut == DialogResult.No) return;
            bool flag=this.accNotes.UpdateWageNotesForConfirm(ref errormsg, this.NoteID,
                JERPBiz.Frame.UserBiz.PsnID);            
            if (this.affterSave != null) this.affterSave();
            this.Close();
            MessageBox.Show("成功审核当前工资表");
        }
    
      
    }
}