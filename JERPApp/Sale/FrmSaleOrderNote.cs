using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Sale
{
    public partial class FrmSaleOrderNote : Form
    {
        public FrmSaleOrderNote()
        {
            InitializeComponent();
            this.dgrdvNote.AutoGenerateColumns = false;
            this.accNotes = new JERPData.Product.SaleOrderNotes();
            this.printer = new JERPBiz.Product.SaleOrderNotePrintHelper();
            this.SetPermit();
        }
        private JERPData.Product.SaleOrderNotes accNotes;
        private JERPApp.Define.Product.FrmMySaleOrderNoteFreeSearch frmSearch;
        private FrmSaleOrderNoteOper frmOper;
        private JERPBiz.Product.SaleOrderNotePrintHelper printer;
        private string whereclause = string.Empty;
        private string initwhareclause = string.Empty;
        private DataTable dtblNotes;
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(27);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(28);
            if (this.enableBrowse)
            {
                this.initwhareclause = " and ((MakerPsnID=" + JERPBiz.Frame.UserBiz.PsnID.ToString() 
                    + ") or (CompanyID in(select CompanyID from general.Customer where HandlePsnID="
                    +JERPBiz .Frame .UserBiz .PsnID .ToString ()+")))";
                this.whereclause = this.initwhareclause;
                this.AppendWhereclause();
                this.pbar.OnPageIndexChanged += new EventHandler(pbar_OnPageIndexChanged);
                this.lnkSearch.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkSearch_LinkClicked);
                //加载数据
                LoadData();
                this.radNonConfirm.CheckedChanged += this.rad_CheckedChanged;
                this.radNonDeliver.CheckedChanged  += this.rad_CheckedChanged;
                this.radFinished.CheckedChanged += this.rad_CheckedChanged;
                this.dgrdvNote.ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
            }
            this.lnkNew.Enabled = this.enableSave;       
            this.ColumnbtnEdit.Visible = this.enableSave;
            if (this.enableSave)
            {
                this.lnkNew.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkNew_LinkClicked);
                this.dgrdvNote.CellContentClick += new DataGridViewCellEventHandler(dgrdvNote_CellContentClick);
            }


        }

        void rad_CheckedChanged(object sender, EventArgs e)
        {
            this.whereclause = this.initwhareclause;
            this.AppendWhereclause();
            this.LoadData();
        }
        private void AppendWhereclause()
        {
            if (this.radNonConfirm.Checked)
            {
                this.whereclause += " and (exists(select NoteID from prd.SaleOrderItems where NoteID=a.NoteID and ConfirmPsnID is null))";
            }
            if (this.radNonDeliver.Checked)
            {
                this.whereclause += " and (exists(select NoteID from prd.SaleOrderItems where NoteID=a.NoteID and NonFinishedQty>0))";
            }
            if (this.radFinished.Checked)
            {
                this.whereclause += " and (not exists(select NoteID from prd.SaleOrderItems where NoteID=a.NoteID and NonFinishedQty>0))";
            }
        }
        void lnkSearch_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (frmSearch == null)
            {
                frmSearch = new JERPApp.Define.Product.FrmMySaleOrderNoteFreeSearch();
                new FrmStyle(frmSearch).SetPopFrmStyle(this);
                frmSearch.AffterSearch += frmSearch_AffterSearch;
            }
            frmSearch.ShowDialog();
        }

        void frmSearch_AffterSearch(string whereclause)
        {
            this.whereclause =this.initwhareclause + whereclause;
            this.AppendWhereclause();
            this.LoadData();
        }

        void dgrdvNote_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            long NoteID = (long)this.dtblNotes.DefaultView[irow]["NoteID"];
            if (this.dgrdvNote.Columns[icol].Name == this.ColumnbtnEdit.Name)
            {
             
                if (this.frmOper == null)
                {
                    this.frmOper = new FrmSaleOrderNoteOper();
                    new FrmStyle(frmOper).SetPopFrmStyle(this);
                    frmOper.AffterSave += new FrmSaleOrderNoteOper.AffterSaveDelegate(frmOper_AffterSave);
                }
                frmOper.EditNote(NoteID);
                frmOper.ShowDialog();
            }
            if (this.dgrdvNote.Columns[icol].Name == this.ColumnBtnExport .Name)
            {
                this.printer.ExportToExcel(NoteID);
                 
            } 
        }

        void frmOper_AffterSave()
        {
            this.radNonConfirm .Checked =true;
            this.whereclause = this.initwhareclause;
            this.AppendWhereclause ();
            this.LoadData();
        }


        void lnkNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.frmOper == null)
            {
                this.frmOper = new FrmSaleOrderNoteOper();
                new FrmStyle(frmOper).SetPopFrmStyle(this);
                frmOper.AffterSave += new FrmSaleOrderNoteOper.AffterSaveDelegate(frmOper_AffterSave);
            }
            frmOper.NewNote();
            frmOper.ShowDialog();
        }

        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.whereclause = this.initwhareclause;
            this.AppendWhereclause();
            this.LoadData();
        }

        private void LoadData()
        {
            int cnt=0;
            this.dtblNotes = this.accNotes.GetDataSaleOrderNotesDescPagesFreeSearch (1, this.pbar.PageSize, ref cnt,this.whereclause ).Tables [0];
            this.dgrdvNote.DataSource = this.dtblNotes;
            this.pbar.Init(1, cnt);

        }

        void pbar_OnPageIndexChanged(object sender, EventArgs e)
        {
            int cnt = 0;
            this.dtblNotes = this.accNotes.GetDataSaleOrderNotesDescPagesFreeSearch (this.pbar.PageIndex, this.pbar.PageSize, ref cnt,this.whereclause ).Tables[0];
            this.dgrdvNote.DataSource = this.dtblNotes;
        }
    }
}