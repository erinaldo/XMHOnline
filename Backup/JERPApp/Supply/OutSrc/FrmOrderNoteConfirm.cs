using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Supply.OutSrc
{
    public partial class FrmOrderNoteConfirm : Form
    {
        public FrmOrderNoteConfirm()
        {
            InitializeComponent();
            this.dgrdvNonConfirm.AutoGenerateColumns = false;
            this.ctrlQNonConfirm .SeachGridView =this.dgrdvNonConfirm ;
            this.dgrdvConfirm.AutoGenerateColumns = false;
            this.accNotes = new JERPData.Manufacture.OutSrcOrderNotes(); 
            this.SetPermit();
        }
        private JERPData.Manufacture.OutSrcOrderNotes accNotes; 
        private FrmOrderNoteConfirmOper frmOper;
        private Report.Bill.FrmOutSrcOrderNote frmDetail;
        private DataTable dtblNonConfirm,dtblConfirm;
        private string initwhereclause = " and (ConfirmPsnID is not null)";
        private string wherecluase = string.Empty;
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(651);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(652);
            if (this.enableBrowse)
            {
                this.dtpDateBegin.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                this.dtpDateEnd.Value = this.dtpDateBegin.Value.AddMonths(1).AddDays(-1);
                //加载数据
                this.wherecluase = this.initwhereclause;
                this.LoadConfirm();
                this.LoadNonConfirm();
                this.dgrdvNonConfirm.ContextMenuStrip = this.cMenu;
                this.dgrdvConfirm.ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                this.btnSearch.Click += new EventHandler(btnSearch_Click);
                this.pbar.OnPageIndexChanged += new EventHandler(pbar_OnPageIndexChanged);
               
            }            
            this.ColumnbtnConfirm.Visible = this.enableSave;
            this.ColumnbtnCancel.Visible = this.enableSave;
            if (this.enableSave)
            {
                this.dgrdvConfirm.CellContentClick += new DataGridViewCellEventHandler(dgrdvConfirm_CellContentClick);
                this.dgrdvNonConfirm.CellContentClick += new DataGridViewCellEventHandler(dgrdvNonConfirm_CellContentClick);
            }


        }

        void btnSearch_Click(object sender, EventArgs e)
        {
            this.wherecluase = this.initwhereclause;
            if (this.ckbSupplier.Checked)
            {
                this.wherecluase += " and (CompanyID=" + this.ctrlCompanyID.CompanyID.ToString() + ")";
            }
            if (this.ckbNoteCode.Checked)
            {
                this.wherecluase += " and (NoteCode like '%" + this.txtNoteCode.Text + "%')";
            }
            if (this.ckbDateNote.Checked)
            {
                this.wherecluase += " and (DateNote>='" + this.dtpDateBegin.Value.ToShortDateString()
                    + "' and DateNote<='" + this.dtpDateEnd.Value.ToShortDateString() + "')";
            }
            this.LoadConfirm ();
        }

        void pbar_OnPageIndexChanged(object sender, EventArgs e)
        {
            int cnt = 0;
            this.dtblConfirm = this.accNotes.GetDataOutSrcOrderNotesDescPagesFreeSearch(
                this.pbar .PageIndex ,
                this.pbar.PageSize,
                ref cnt,
                this.wherecluase).Tables [0];
            this.dgrdvConfirm.DataSource = this.dtblConfirm;
        }

        void dgrdvConfirm_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            long NoteID = (long)this.dtblConfirm .DefaultView[irow]["NoteID"];
            if (this.dgrdvConfirm.Columns[icol].Name == this.ColumnbtnCancel  .Name)
            {

                DialogResult rul = MessageBox.Show("您将取消当前的审核吗?", "操作确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rul == DialogResult.Yes)
                {
                    string errormsg=string.Empty ;
                    bool flag=this.accNotes.UpdateOutSrcOrderNotesCancelConfirm(ref errormsg, NoteID);
                    if (flag)
                    {
                        this.dtblConfirm.Rows.Remove (this.dtblConfirm.DefaultView[irow].Row);
                        this.LoadNonConfirm();
                    }
                   
                }
            }
            if (this.dgrdvConfirm .Columns[icol].Name == this.ColumnNoteCode .Name)
            {
                if (frmDetail == null)
                {
                    frmDetail = new JERPApp.Supply.OutSrc.Report.Bill.FrmOutSrcOrderNote();
                    new FrmStyle(frmDetail).SetPopFrmStyle(this);                   
                }
                frmDetail.Detail(NoteID);
                frmDetail.ShowDialog();
            }
        }

        void dgrdvNonConfirm_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            long NoteID = (long)this.dtblNonConfirm .DefaultView[irow]["NoteID"];
            if (this.dgrdvNonConfirm.Columns[icol].Name == this.ColumnbtnConfirm .Name)
            {
             
                if (this.frmOper == null)
                {
                    this.frmOper = new FrmOrderNoteConfirmOper();
                    new FrmStyle(frmOper).SetPopFrmStyle(this);
                    frmOper.AffterSave += new FrmOrderNoteConfirmOper.AffterSaveDelegate(frmOper_AffterSave);
                 
                }
                frmOper.ConfirmOper (NoteID);
                frmOper.ShowDialog();
            } 
           
        }

        void frmOper_AffterSave()
        {
            this.wherecluase = this.initwhereclause;
            this.LoadNonConfirm();
            this.LoadConfirm();
        }

        void mItemRefresh_Click(object sender, EventArgs e)
        {
            if (this.cMenu.SourceControl == this.dgrdvNonConfirm)
            {
                this.LoadNonConfirm();
            }
            if (this.cMenu.SourceControl == this.dgrdvConfirm)
            {
                this.wherecluase = this.initwhereclause;
                this.LoadConfirm();
            }
           
        }
        private void LoadNonConfirm()
        {

            this.dtblNonConfirm   = this.accNotes.GetDataOutSrcOrderNotesNonConfirm().Tables[0];
            this.dgrdvNonConfirm.DataSource = this.dtblNonConfirm ;

        }
        private void LoadConfirm()
        {
           int cnt=0;
           this.dtblConfirm = this.accNotes.GetDataOutSrcOrderNotesDescPagesFreeSearch(1,
               this.pbar.PageSize,
               ref cnt,
               this.wherecluase).Tables [0];
           this.dgrdvConfirm.DataSource = this.dtblConfirm;
           this.pbar.Init(1, cnt);

        }

   } 
}