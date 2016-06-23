using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Payable.Postage
{
    public partial class FrmReconciliation : Form
    {
        public FrmReconciliation()
        {
            InitializeComponent();
            this.dgrdvNonReconciliation.AutoGenerateColumns = false;            
            this.dgrdvReconciliation .AutoGenerateColumns = false;
            this.ctrlQReconciliation.SeachGridView = this.dgrdvReconciliation;
            this.accReconciliations = new JERPData.Finance.PostageReconciliations();
            this.accPostageNotes = new JERPData.Finance.PostageNotes();
            this.SetPermit();
        }
        private JERPData.Finance.PostageReconciliations accReconciliations;
        private JERPData.Finance.PostageNotes accPostageNotes;
        private DataTable dtblNonReconciliations, dtblReconciliations;
        private FrmReconciliationOper frmOper;
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存  
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(365);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(366);
          
            if (this.enableBrowse)
            {
                 
                this.dgrdvReconciliation .ContextMenuStrip = this.cMenu;
                this.dgrdvNonReconciliation.ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                this.LoadData();
                
            }
            this.lnkNew.Enabled = this.enableSave;
            this.ColumnBtnEdit.Visible = this.enableSave;
            if (this.enableSave)
            {
                this.lnkNew.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkNew_LinkClicked);
                this.dgrdvReconciliation .CellContentClick += new DataGridViewCellEventHandler(dgrdvReconciliation_CellContentClick);
            }
        }

        void lnkNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.frmOper == null)
            {
                this.frmOper = new FrmReconciliationOper();
                new FrmStyle(this.frmOper).SetPopFrmStyle(this);
                this.frmOper.AffterSave += this.LoadData;
            }
            this.frmOper.New();
            this.frmOper.ShowDialog();
        }

  
        private void LoadNonReconciliation()
        {
            while (this.dgrdvNonReconciliation.ColumnCount > 1)
            {
                this.dgrdvNonReconciliation.Columns.RemoveAt(1);
            }
            this.dtblNonReconciliations = this.accPostageNotes.GetDataPostageNotesNonReconciliationPivotMonthAMT().Tables[0];
            DataGridViewTextBoxColumn txt; 
            string columnname;
            for (int j = 1; j < this.dtblNonReconciliations.Columns.Count;j++ )
            {
                columnname = this.dtblNonReconciliations.Columns[j].ColumnName;
                txt = new DataGridViewTextBoxColumn();
                txt.DataPropertyName = columnname;
                txt.HeaderText = columnname;
                txt.Width = 70;
                this.dgrdvNonReconciliation.Columns.Add(txt);
            } 
            this.dgrdvNonReconciliation.DataSource = this.dtblNonReconciliations;
            this.ctrlQNonReconciliation.SeachGridView = this.dgrdvNonReconciliation;
            this.pageNonReconciliation.Text = "未对账["+this.dtblNonReconciliations.Rows.Count.ToString()+"]";
        }
        private void LoadReconciliation()
        {           
            this.dtblReconciliations = this.accReconciliations.GetDataPostageReconciliationsNonFinance ().Tables[0];
            this.dgrdvReconciliation.DataSource = this.dtblReconciliations;
            this.pageReconciliation.Text = "对账单[" + this.dtblReconciliations.Rows.Count.ToString() + "]";
        }
        private void LoadData()
        {
            this.LoadNonReconciliation();
            this.LoadReconciliation();
        }
        void mItemRefresh_Click(object sender, EventArgs e)
        {
            if (this.cMenu.SourceControl == this.dgrdvNonReconciliation)
            {
                this.LoadNonReconciliation ();
            }
            if (this.cMenu.SourceControl == this.dgrdvReconciliation)
            {
                this.LoadReconciliation();
            }
             
        }    
        void dgrdvReconciliation_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvReconciliation.Columns[icol].Name == this.ColumnBtnEdit.Name)
            {
                long ReconciliationID = (long)this.dtblReconciliations.DefaultView[irow]["ReconciliationID"];
                if (this.frmOper == null)
                {
                    this.frmOper = new FrmReconciliationOper();
                    new FrmStyle(this.frmOper).SetPopFrmStyle(this);
                    this.frmOper.AffterSave += this.LoadData;
                }
                this.frmOper.Edit(ReconciliationID);
                this.frmOper.ShowDialog();
               
            }
        }

      

    }
}