using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Wage
{
    public partial class FrmWageNoteConfirm : Form
    {
        public FrmWageNoteConfirm()
        {
            InitializeComponent();
            this.dgrdvConfirm.AutoGenerateColumns = false;
            this.dgrdv.AutoGenerateColumns = false;
            this.accNotes = new JERPData.Finance.WageNotes();
            this.SetPermit();
        }
        private JERPData.Finance.WageNotes accNotes;
        private FrmWageNoteConfirmOper frmOper;
        private JERPApp.Finance.Report.Bill.FrmWageNote frmDetail;
        private DataTable dtblNotes,dtblConfirmNotes;
        private string whereclause =" and (ConfirmPsnID is not null)";
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(619);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(620);
            if (this.enableBrowse)
            {
                this.dtpDateNote.Value = DateTime.Now.Date;
                this.ctrlYear.Year = DateTime.Now.Year;
                this.ctrlMonth.Month = DateTime.Now.Month;
                //加载数据
                LoadData();
                this.dgrdv.ContextMenuStrip = this.cMenu;
                this.dgrdvConfirm.ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                this.pbar.OnPageIndexChanged += new EventHandler(pbar_OnPageIndexChanged);
                this.btnSearch.Click += new EventHandler(btnSearch_Click);
            }
            this.ColumnbtnConfirm .Visible = this.enableSave;
            if (this.enableSave)
            {
                this.dgrdvConfirm.CellContentClick += new DataGridViewCellEventHandler(dgrdvConfirm_CellContentClick);
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
            }


        }

      
        void btnSearch_Click(object sender, EventArgs e)
        {
            this.whereclause = " and (ConfirmPsnID is not null)";
            if (this.ckbYear.Checked)
            {
                this.whereclause += " and (Year=" + this.ctrlYear.Year.ToString() + ")";
            }
            if (this.ckbMonth.Checked)
            {
                this.whereclause += " and (Month=" + this.ctrlMonth.Month.ToString() + ")";
            }
            if (this.ckbDateNote.Checked)
            {
                this.whereclause += " and (DateBegin<='" + this.dtpDateNote.Value.ToShortDateString() + "' and DateEnd>='" + this.dtpDateNote.Value.ToShortDateString() + "')";

            }
            this.LoadData();
        }
      

        void frmOper_AffterSave()
        {
            this.whereclause = " and (ConfirmPsnID is not null)";
            this.LoadData();
        }
        void dgrdvConfirm_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvConfirm.Columns[icol].Name == this.ColumnbtnDetail.Name)
            {
                long NoteID = (long)this.dtblConfirmNotes.DefaultView[irow]["NoteID"];
                if (frmDetail == null)
                {
                    frmDetail = new JERPApp.Finance.Report.Bill.FrmWageNote();
                    new FrmStyle(frmDetail).SetPopFrmStyle(this);                    
                }
                frmDetail.Detail(NoteID);
                frmDetail.ShowDialog();
            }
        }

        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;           
            if (this.dgrdv .Columns[icol].Name == this.ColumnbtnConfirm .Name)
            {
                long NoteID = (long)this.dtblNotes .DefaultView[irow]["NoteID"];
                if (this.frmOper == null)
                {
                    this.frmOper = new FrmWageNoteConfirmOper();
                    new FrmStyle(frmOper).SetPopFrmStyle(this);
                    frmOper.AffterSave +=frmOper_AffterSave;
                }
                frmOper.ConfirmOper (NoteID);
                frmOper.ShowDialog();
            } 
           
        }
        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private void LoadData()
        {
            this.dtblNotes = this.accNotes.GetDataWageNotesNonConfirm().Tables[0];
            this.dgrdv.DataSource = this.dtblNotes;

            int cnt = 0;
            this.dtblConfirmNotes = this.accNotes.GetDataWageNotesDescPagesFreeSearch (1,this.pbar .PageSize ,ref cnt,this.whereclause).Tables [0];
            this.dgrdvConfirm.DataSource = this.dtblConfirmNotes;
            this.pbar.Init(1, cnt);

        }

        void pbar_OnPageIndexChanged(object sender, EventArgs e)
        {
            int cnt = 0;
            this.dtblConfirmNotes = this.accNotes.GetDataWageNotesDescPagesFreeSearch (this.pbar .PageIndex , this.pbar.PageSize, ref cnt,this.whereclause).Tables[0];
            this.dgrdvConfirm.DataSource = this.dtblConfirmNotes;
        }

    
    }
}