using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Material
{
    public partial class FrmOutSrcLossSupplyNote : Form
    {
        public FrmOutSrcLossSupplyNote()
        {
            InitializeComponent();
            this.dgrdvNonConfirm.AutoGenerateColumns = false;
            this.dgrdvConfirm.AutoGenerateColumns = false;
            this.accNotes = new JERPData.Material.OutSrcLossSupplyNotes ();
            this.SetPermit();
        }
        private JERPData.Material.OutSrcLossSupplyNotes  accNotes;
        private FrmOutSrcLossSupplyNoteOper  frmOper;
        private JERPApp.Store.Material.Report.Bill.FrmOutSrcLossSupplyNote  frmDetail;
        private DataTable dtblConfirms,dtblNonConfirm;
        private string whereclause = string.Empty;
        private string iniwhereclause = " and (ConfirmPsnID is not null)";
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(372);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(373);
            if (this.enableBrowse)
            {
                this.whereclause = this.iniwhereclause;
                //加载数据
                this.LoadNonConfirm();
                this.LoadConfirm();
                this.dtpDateBegin.Value = DateTime.Now.AddDays(-3);
                this.dtpDateEnd.Value = DateTime.Now.AddDays(1);
                this.btnSearch.Click += new EventHandler(btnSearch_Click);
                this.lnkRefreshAll.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkRefreshAll_LinkClicked);
            }
            
            if (this.enableSave)
            {
                this.dgrdvNonConfirm.CellContentClick += new DataGridViewCellEventHandler(dgrdvNonConfirm_CellContentClick);
              
                this.dgrdvConfirm.CellContentClick += new DataGridViewCellEventHandler(dgrdvConfirm_CellContentClick);
            }

        }

        void lnkRefreshAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.LoadNonConfirm();
            this.whereclause = this.iniwhereclause;
            this.LoadConfirm();
        }


        void btnSearch_Click(object sender, EventArgs e)
        {
            this.whereclause = this.iniwhereclause;
            if (this.ckbSupplier.Checked)
            {
                this.whereclause += " and (CompanyID=" + this.ctrlSupplierID.CompanyID.ToString() + ")";
            }
            if (this.ckbDateNote.Checked)
            {
                this.whereclause += " and (DateNote>='" + this.dtpDateBegin.Value.ToShortDateString() + "' and DateNote<='" + this.dtpDateEnd.Value.ToShortDateString() + "')";
            }
            this.LoadConfirm();
        }
         

        void pbar_OnPageIndexChanged(object sender, EventArgs e)
        {
            int cnt = 0;
            this.dtblConfirms =this.accNotes.GetDataOutSrcLossSupplyNotesDescPagesFreeSearch  (this.pbar.PageIndex, this.pbar.PageSize, ref cnt,this.whereclause ).Tables [0];
            this.dgrdvConfirm.DataSource = this.dtblConfirms;
        
        }
        void dgrdvConfirm_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvConfirm.Columns[icol].Name == this.ColumnbtnDetail.Name)
            {
                long NoteID =(long) this.dtblConfirms.DefaultView[irow]["NoteID"];
                if (this.frmDetail  == null)
                {
                    this.frmDetail = new JERPApp.Store.Material.Report.Bill.FrmOutSrcLossSupplyNote();
                    new FrmStyle(frmDetail).SetPopFrmStyle(this);
                 
                }
                frmDetail.DetailNote(NoteID);
                frmDetail.ShowDialog();
            }
        }

        void dgrdvNonConfirm_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvNonConfirm .Columns[icol].Name == this.ColumnbtnConfirm .Name)
            {
                long NoteID = (long)this.dtblNonConfirm.DefaultView[irow]["NoteID"];
                if (this.frmOper == null)
                {
                    this.frmOper = new FrmOutSrcLossSupplyNoteOper();
                    new FrmStyle(frmOper).SetPopFrmStyle(this);
                    frmOper.AffterSave += frmOper_AffterSave;
                }
                frmOper.ConfirmOper(NoteID);
                frmOper.ShowDialog();
            }
        }
      
        void frmOper_AffterSave()
        {
            this.whereclause = this.iniwhereclause;
            this.LoadConfirm();
            this.LoadNonConfirm();
        }

        private void LoadNonConfirm()
        {
            this.dtblNonConfirm = this.accNotes.GetDataOutSrcLossSupplyNotesNonConfirm().Tables[0];
            this.dgrdvNonConfirm.DataSource = this.dtblNonConfirm;
        }
        private void LoadConfirm()
        {
            int cnt = 0;
            this.dtblConfirms = this.accNotes.GetDataOutSrcLossSupplyNotesDescPagesFreeSearch   (1,this.pbar .PageSize ,ref cnt,this.whereclause ).Tables [0];
            this.dgrdvConfirm.DataSource = this.dtblConfirms;
            this.pbar.Init(1, cnt);
        }

    }
}