using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Dispatcher
{
    public partial class FrmFromMtrBuyReturnNote : Form
    {
        public FrmFromMtrBuyReturnNote()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accNotes = new JERPData.Material.BuyReturnNotes();
            this.dtpDateBegin.Value = DateTime.Now.AddDays(-1).Date;
            this.dtpDateEnd.Value = DateTime.Now.AddDays(1).Date; 
            this.pbar.OnPageIndexChanged += new EventHandler(pbar_OnPageIndexChanged);
            this.btnSearch.Click += new EventHandler(btnSearch_Click);
            this.btnSave .Click+=new EventHandler(btnSave_Click);
            for (int j = 1; j < this.dgrdv.ColumnCount; j++)
            {
                this.dgrdv.Columns[j].ReadOnly = true;
            }
            this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
        }

       

        private JERPData.Material.BuyReturnNotes accNotes;
        private DataTable dtblNotes; 
        private FrmPostageNoteOper frmOper;
        private JERPApp.Store.Material.Report.Bill.FrmBuyReturnNote frmDetail;
        private string iniwhereclause = " and (ExpressCompanyID is null)";
        private string whereclause = " and (ExpressCompanyID is null)";
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
        void btnSearch_Click(object sender, EventArgs e)
        {
            this.whereclause = this.iniwhereclause ;
            if (this.ckbNoteCodeFlag.Checked)
            {
                this.whereclause += " and (NoteCode like '%" + this.txtNoteCode.Text + "%')";
            }
            if (this.ckbSupplierFlag.Checked)
            {
                this.whereclause += " and (CompanyID=" + this.ctrlSupplierID.CompanyID.ToString() + ")";
            }
            if (this.ckbDateNoteFlag.Checked)
            {
                this.whereclause += " and (DateNote>=' " + this.dtpDateBegin.Value.ToShortDateString() + "' and " +
                    "DateNote<='" + this.dtpDateEnd.Value.ToShortDateString() + "'";
            }
            this.LoadData();
        }
 
        void pbar_OnPageIndexChanged(object sender, EventArgs e)
        {
            int cnt = 0;
            this.dtblNotes = this.accNotes.GetDataBuyReturnNotesDescPagesFreeSearch(this.pbar .PageIndex, this.pbar.PageSize, ref cnt, this.whereclause).Tables[0];
            this.dtblNotes.Columns.Add("CheckedFlag", typeof(bool));
            this.dgrdv.DataSource = this.dtblNotes;
        }

       
        public  void LoadData()
        {
            int cnt = 0;
            this.dtblNotes = this.accNotes.GetDataBuyReturnNotesDescPagesFreeSearch (1,this.pbar.PageSize ,ref cnt,this.whereclause).Tables[0];
            this.dgrdv.DataSource = this.dtblNotes;
            this.dtblNotes.Columns.Add("CheckedFlag", typeof(bool));
            this.pbar.Init(1, cnt);
        }
        private bool ValidateData()
        {
            

            DataRow[] drows = this.dtblNotes.Select("CheckedFlag=1");
            if (drows.Length == 0)
            {
                MessageBox.Show("未选择任何送货单");
                return false;
            }
            int lastcompanyid = (int)drows[0]["CompanyID"];
            for (int i = 1; i < drows.Length; i++)
            {
                if (lastcompanyid != (int)drows[i]["CompanyID"])
                {
                    MessageBox.Show("对不起，选择的供应商必须一致");
                    return false;
                }
            }
            return true;
        }
        void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateData() == false) return;
            if (this.frmOper == null)
            {
                this.frmOper = new FrmPostageNoteOper();
                new FrmStyle(frmOper).SetPopFrmStyle(this);
                this.frmOper.AffterSave += new FrmPostageNoteOper.AffterSaveDelegate(frmOper_AffterSave);
            }
            this.frmOper.NewNote();
            this.frmOper.ShowDialog();
        }

        void frmOper_AffterSave(long ExpressNoteID, int ExpressCompanyID, string ExpressCode)
        {
            DataRow[] drows = this.dtblNotes.Select("CheckedFlag=1"); 
            string errormsg = string.Empty;
            foreach (DataRow drow in drows)
            {
                this.accNotes.UpdateBuyReturnNotesForExpress (
                    ref errormsg,
                    drow["NoteID"],
                    ExpressCompanyID,
                    ExpressCode);
            }
            if (this.affterSave != null) this.affterSave();
            this.LoadData();
            this.frmOper.Close();
        }
        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnNoteCode.Name)
            {
                long NoteID = (long)this.dtblNotes.DefaultView[irow]["NoteID"];
                if (frmDetail == null)
                {
                    frmDetail = new JERPApp.Store.Material.Report.Bill.FrmBuyReturnNote();
                    new FrmStyle(frmDetail).SetPopFrmStyle(this);
                }
                frmDetail.DetailNote(NoteID);
                frmDetail.ShowDialog();
            }
        }
    }
}