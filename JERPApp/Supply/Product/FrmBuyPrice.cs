using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Supply.Product
{
    public partial class FrmBuyPrice : Form
    {
        public FrmBuyPrice()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accNotes = new JERPData.Product.BuyPriceNotes();
            this.dtpDateBegin.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            this.dtpDateEnd.Value = DateTime.Now.Date;
            this.SetPermit();
        }
        private JERPData.Product.BuyPriceNotes accNotes;
        private FrmBuyPriceOper frmOper;
        private DataTable dtblNotes;
        private string whereclause = string.Empty;
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(414);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(415);
            if (this.enableBrowse)
            {
              
                this.LoadData();
                this.dgrdv.ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);        
                this.btnSearch.Click += new EventHandler(btnSearch_Click);
                this.pbar.OnPageIndexChanged += new EventHandler(pbar_OnPageIndexChanged);
            }
            this.lnkNew.Enabled = this.enableSave;
            this.ColumnBtnEdit.Visible =this.enableSave ;
            if (this.enableSave)
            {
                this.FormClosed += new FormClosedEventHandler(FrmBuyPrice_FormClosed);
                this.lnkNew.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkNew_LinkClicked);
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
            }
        }

        void FrmBuyPrice_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.affterSave != null) this.affterSave();
        }
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
            this.whereclause = string.Empty;
            if (this.ckbNoteCode.Checked)
            {
                this.whereclause += " and (NoteCode like '%" + this.txtNoteCode.Text + "%')";
            }
            if (this.ckbCustomer.Checked)
            {
                this.whereclause += " and (CompanyID=" + this.ctrlCompanyID.CompanyID.ToString() + ")";
            }
            if (this.ckbDateNote.Checked)
            {
                this.whereclause += " and (DateNote>='" + this.dtpDateBegin.Value.ToShortDateString () + "' and DateNote<='" + this.dtpDateEnd.Value.Date.ToShortDateString() + "')";
            }
            this.LoadData();
        }
        private void LoadData()
        {
            int cnt = 0;
            this.dtblNotes = this.accNotes.GetDataBuyPriceNotesDescPagesFreeSearch(1, this.pbar.PageSize,
                ref cnt, this.whereclause).Tables[0];
            this.dgrdv.DataSource = this.dtblNotes;
            this.pbar.Init(1, cnt);
        }
        void pbar_OnPageIndexChanged(object sender, EventArgs e)
        {
            int cnt = 0;
            this.dtblNotes = this.accNotes.GetDataBuyPriceNotesDescPagesFreeSearch(this.pbar .PageIndex , this.pbar.PageSize,
                ref cnt, this.whereclause).Tables[0];
            this.dgrdv.DataSource = this.dtblNotes;
        }
        void lnkNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (frmOper == null)
            {
                frmOper = new FrmBuyPriceOper();
                new FrmStyle(frmOper).SetPopFrmStyle(this);
                frmOper.AffterSave += new FrmBuyPriceOper.AffterSaveDelegate(frmOper_AffterSave);
            }
            frmOper.NewNote();
            frmOper.ShowDialog();
        }

        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnBtnEdit.Name)
            {
                long NoteID = (long)this.dtblNotes.DefaultView[irow]["NoteID"];
                if (this.frmOper == null)
                {
                    frmOper = new FrmBuyPriceOper();
                    new FrmStyle(frmOper).SetPopFrmStyle(this);
                    frmOper.AffterSave += new FrmBuyPriceOper.AffterSaveDelegate(frmOper_AffterSave);
                }
                frmOper.EditNote(NoteID);
                frmOper.ShowDialog();
            }
        }

      
        void frmOper_AffterSave()
        {
            this.whereclause = string.Empty;
            this.ckbCustomer.Checked = false;
            this.ckbDateNote.Checked = false;
            this.ckbNoteCode.Checked = false;
            this.LoadData();
        }
        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.whereclause = string.Empty;
            this.ckbCustomer.Checked = false;
            this.ckbDateNote.Checked = false;
            this.ckbNoteCode.Checked = false;
            this.LoadData();
        }

    }
}