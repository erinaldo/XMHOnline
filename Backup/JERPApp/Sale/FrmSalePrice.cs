using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Sale
{
    public partial class FrmSalePrice : Form
    {
        public FrmSalePrice()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accNotes = new JERPData.Product.SalePriceNotes();
            this.dtpDateBegin.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            this.dtpDateEnd.Value = DateTime.Now.Date;
            this.SetPermit();
        }
        private JERPData.Product.SalePriceNotes accNotes;
        private FrmSalePriceOper frmOper;
        private DataTable dtblNotes;
        private string whereclause = string.Empty;
        private string InitWhereclause = string.Empty;
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(249);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(250);
            if (this.enableBrowse)
            {
                this.InitWhereclause = "and (MakerPsnID=" + JERPBiz.Frame.UserBiz.PsnID.ToString() + ")";
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
                this.FormClosed += new FormClosedEventHandler(FrmSalePrice_FormClosed);
                this.lnkNew.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkNew_LinkClicked);
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
            }
        }

        void FrmSalePrice_FormClosed(object sender, FormClosedEventArgs e)
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
            this.whereclause = this.InitWhereclause ;
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
            this.dtblNotes = this.accNotes.GetDataSalePriceNotesDescPagesFreeSearch(1, this.pbar.PageSize,
                ref cnt, this.whereclause).Tables[0];
            this.dgrdv.DataSource = this.dtblNotes;
            this.pbar.Init(1, cnt);
        }
        void pbar_OnPageIndexChanged(object sender, EventArgs e)
        {
            int cnt = 0;
            this.dtblNotes = this.accNotes.GetDataSalePriceNotesDescPagesFreeSearch(this.pbar .PageIndex , this.pbar.PageSize,
                ref cnt, this.whereclause).Tables[0];
            this.dgrdv.DataSource = this.dtblNotes;
        }
        void lnkNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (frmOper == null)
            {
                frmOper = new FrmSalePriceOper();
                new FrmStyle(frmOper).SetPopFrmStyle(this);
                frmOper.AffterSave += new FrmSalePriceOper.AffterSaveDelegate(frmOper_AffterSave);
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
                    frmOper = new FrmSalePriceOper();
                    new FrmStyle(frmOper).SetPopFrmStyle(this);
                    frmOper.AffterSave += new FrmSalePriceOper.AffterSaveDelegate(frmOper_AffterSave);
                }
                frmOper.EditNote(NoteID);
                frmOper.ShowDialog();
            }
        }

      
        void frmOper_AffterSave()
        {
            this.whereclause = this.InitWhereclause;
            this.ckbCustomer.Checked = false;
            this.ckbDateNote.Checked = false; 
            this.LoadData();
        }
        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.whereclause = this.InitWhereclause;
            this.ckbCustomer.Checked = false;
            this.ckbDateNote.Checked = false; 
            this.LoadData();
        }

    }
}