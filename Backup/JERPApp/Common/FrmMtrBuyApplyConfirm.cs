using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Common
{
    public partial class FrmMtrBuyApplyConfirm : Form
    {
        public FrmMtrBuyApplyConfirm()
        {
            InitializeComponent();
            this.dgrdvNonConfirm.AutoGenerateColumns = false;
            this.dgrdvConfirm.AutoGenerateColumns = false;
            this.accNotes = new JERPData.Material.BuyOrderApplyNotes ();
            this.SetPermit();
        }
        private JERPData.Material.BuyOrderApplyNotes accNotes;
        private FrmMtrBuyApplyConfirmOper frmOper;
        private Supply.Material.Report.Bill.FrmBuyOrderApplyNote frmDetail;
        private string whereclause = string.Empty;
        private string iniwhereclause = "and (ConfirmPsnID is not null)";
        private DataTable dtblNonConfirms,dtblConfirm;
        //权限码
        private bool enableBrowse = false;//浏览 
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(558); 
            if (this.enableBrowse)
            {
                //加载数据
                this.LoadNonConfirm();
                this.whereclause = iniwhereclause;
                this.LoadConfirm();
                this.dgrdvNonConfirm.ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                this.pbar.OnPageIndexChanged += new EventHandler(pbar_OnPageIndexChanged);
                this.dgrdvNonConfirm.CellContentClick += new DataGridViewCellEventHandler(dgrdvNonConfirm_CellContentClick);
                this.dgrdvConfirm.CellContentClick += new DataGridViewCellEventHandler(dgrdvConfirm_CellContentClick);
                this.btnSearch.Click += new EventHandler(btnSearch_Click);
            } 
        }

        void btnSearch_Click(object sender, EventArgs e)
        {
            this.whereclause = this.iniwhereclause;
            if (this.ckbDateNote.Checked)
            {
                this.whereclause += " and (DateNote>='" + this.dtpDateBegin.Value.ToShortDateString() + "' and DateNote<='" + this.dtpDateEnd.Value.ToShortDateString() + " ')";
                
            }
            if (this.ckbDept.Checked)
            {
                this.whereclause += " and (DeptID=" + this.ctrlDeptID.DeptID.ToString() + ")";
            }
            if (this.ckbMakerPsn.Checked)
            {
                this.whereclause += " and (MakerPsnID=" + this.ctrlPersonnel1.PsnID.ToString() + ")";
            }
            this.LoadConfirm();
        } 
        private void LoadNonConfirm()
        {

            this.dtblNonConfirms = this.accNotes.GetDataBuyOrderApplyNotesNonConfirm().Tables[0];
            this.dgrdvNonConfirm.DataSource = this.dtblNonConfirms;
        }
        private void LoadConfirm()
        {
            int cnt = 0;
            this.dtblConfirm =this.accNotes.GetDataBuyOrderApplyNotesDescPagesFreeSearch(1, this.pbar.PageSize,
                ref cnt, this.whereclause).Tables[0];
            this.dgrdvConfirm.DataSource = this.dtblConfirm;
            this.pbar.Init(1, cnt);

        }
        void mItemRefresh_Click(object sender, EventArgs e)
        {
            if (this.cMenu.SourceControl == this.dgrdvNonConfirm)
            {
                this.LoadNonConfirm();
            }
            if (this.cMenu.SourceControl == this.dgrdvConfirm)
            {
                this.whereclause = this.iniwhereclause;
                this.LoadConfirm();
            }
        }
        void pbar_OnPageIndexChanged(object sender, EventArgs e)
        {
            int cnt = 0;
            this.dtblConfirm = this.accNotes.GetDataBuyOrderApplyNotesDescPagesFreeSearch(this.pbar .PageIndex , this.pbar.PageSize,
                ref cnt, this.whereclause).Tables[0];
            this.dgrdvConfirm.DataSource = this.dtblConfirm;
        }

        void dgrdvNonConfirm_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvNonConfirm.Columns[icol].Name == this.ColumnbtnEdit .Name)
            {
                long NoteID =(long) this.dtblNonConfirms.DefaultView[irow]["NoteID"];
                if (this.frmOper == null)
                {
                    this.frmOper = new FrmMtrBuyApplyConfirmOper();
                    new FrmStyle(frmOper).SetPopFrmStyle(this);
                    frmOper.AffterSave += new FrmMtrBuyApplyConfirmOper.AffterSaveDelegate(frmOper_AffterSave);
                }
                frmOper.ConfirmOper (NoteID);
                frmOper.ShowDialog();
            }
        }

        void frmOper_AffterSave()
        {
            this.LoadNonConfirm();
            this.whereclause =this.iniwhereclause;
            this.LoadConfirm();
        }
        void dgrdvConfirm_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvConfirm .Columns[icol].Name == this.ColumnbtnDetail.Name)
            {
                long NoteID = (long)this.dtblConfirm .DefaultView[irow]["NoteID"];
                if (this.frmDetail  == null)
                {
                    this.frmDetail = new JERPApp.Supply.Material.Report.Bill.FrmBuyOrderApplyNote();
                    new FrmStyle(frmDetail).SetPopFrmStyle(this); 
                }
                frmDetail.Detail (NoteID);
                frmDetail.ShowDialog();
            }
        }

      

    }
}