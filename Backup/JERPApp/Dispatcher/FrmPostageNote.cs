using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Dispatcher
{
    public partial class FrmPostageNote : Form
    {
        public FrmPostageNote()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accNotes = new JERPData.Finance.PostageNotes();
            this.SetPermit();
        }
        private JERPData.Finance.PostageNotes accNotes;
        private DataTable dtblNotes;
        private string whereclause = string.Empty;
        private FrmPostageNoteOper frmOper;
        private FrmFromSaleDeliverNote frmFromSaleDeliver;
        private FrmFromRepairDeliverNote frmFromRepair;
        private FrmFromSaleReplenishNote frmFromReplenish;
        private FrmFromMtrBuyReturnNote frmFromMtr;
        private FrmFromPrdBuyReturnNote frmFromPrd;
        private FrmFromOtherResBuyReturnNote frmFromOtherRes;
        private JERPApp.Finance.Report.Bill.Finance.FrmPostageNote frmDetail;
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存  
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(130);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(131);
            this.lnkNew .Enabled = this.enableSave;
            if (this.enableBrowse)
            {
                this.LoadData();
                this.dgrdv.ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                this.ctrlNoteSearch.AffterSearch += new JCommon.ctrlNoteSearch.AffterSearchDelegate(ctrlNoteSearch_AffterSearch);
                this.pbar.OnPageIndexChanged += new EventHandler(pbar_OnPageIndexChanged);
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
            }
            if (this.enableSave)
            {
                this.lnkNew.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkNew_LinkClicked);
                this.lnkMtrReturn.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkMtrReturn_LinkClicked);
                this.lnkOtherResReturn.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkOtherResReturn_LinkClicked);
                this.lnkPrdReturn.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkPrdReturn_LinkClicked);
                this.lnkSaleDeliver.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkSaleDeliver_LinkClicked);
                this.lnkSaleRepair.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkSaleRepair_LinkClicked);
                this.lnkSaleReplenish.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkSaleReplenish_LinkClicked);
            }
        }
        void frmFrom_AffterSave()
        {
            this.whereclause = string.Empty;
            this.LoadData();
        }
        void lnkSaleReplenish_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.frmFromReplenish == null)
            {
                this.frmFromReplenish = new FrmFromSaleReplenishNote();
                new FrmStyle(frmFromReplenish).SetPopFrmStyle(this);
                frmFromReplenish.AffterSave += frmFrom_AffterSave;
            }
            frmFromReplenish.LoadData();
            frmFromReplenish.ShowDialog();
        }

       

        void lnkSaleRepair_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.frmFromRepair == null)
            {
                this.frmFromRepair = new FrmFromRepairDeliverNote();
                new FrmStyle(frmFromRepair).SetPopFrmStyle(this);
                frmFromRepair .AffterSave +=this.frmFrom_AffterSave ;
            }
            frmFromRepair.LoadData();
            frmFromRepair.ShowDialog();
        }

        void lnkSaleDeliver_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.frmFromSaleDeliver  == null)
            {
                this.frmFromSaleDeliver = new FrmFromSaleDeliverNote();
                new FrmStyle(frmFromSaleDeliver).SetPopFrmStyle(this);
                frmFromSaleDeliver.AffterSave += this.frmFrom_AffterSave;
            }
            frmFromSaleDeliver.LoadData();
            frmFromSaleDeliver.ShowDialog();
        }

        void lnkPrdReturn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            if (this.frmFromPrd  == null)
            {
                this.frmFromPrd = new FrmFromPrdBuyReturnNote();
                new FrmStyle(frmFromPrd).SetPopFrmStyle(this);
                frmFromPrd.AffterSave += this.frmFrom_AffterSave;
            }
            frmFromPrd.LoadData();
            frmFromPrd.ShowDialog();
        }

        void lnkOtherResReturn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            if (this.frmFromOtherRes  == null)
            {
                this.frmFromOtherRes = new FrmFromOtherResBuyReturnNote();
                new FrmStyle(frmFromOtherRes).SetPopFrmStyle(this);
                frmFromOtherRes.AffterSave += this.frmFrom_AffterSave;
            }
            frmFromOtherRes.LoadData();
            frmFromOtherRes.ShowDialog();
        }

        void lnkMtrReturn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            if (this.frmFromMtr  == null)
            {
                this.frmFromMtr = new FrmFromMtrBuyReturnNote();
                new FrmStyle(frmFromMtr).SetPopFrmStyle(this);
                frmFromMtr.AffterSave += this.frmFrom_AffterSave;
            }
            frmFromMtr.LoadData();
            frmFromMtr.ShowDialog();
        }

        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnbtnDetail.Name)
            {
                long NoteID=(long)this.dtblNotes .DefaultView [irow].Row ["NoteID"];
                if (frmDetail == null)
                {
                    frmDetail = new JERPApp.Finance.Report.Bill.Finance.FrmPostageNote();
                    new FrmStyle(frmDetail).SetPopFrmStyle(this);
                }
                frmDetail.DetailNote(NoteID);
                frmDetail.ShowDialog();
            }
        }

        void pbar_OnPageIndexChanged(object sender, EventArgs e)
        {
            int cnt = 0;
            this.dtblNotes  = this.accNotes.GetDataPostageNotesPagesDescFreeSearch (this .pbar .PageIndex , this.pbar.PageSize, ref cnt, this.whereclause).Tables[0];
            this.dgrdv.DataSource = this.dtblNotes;
        }

        void ctrlNoteSearch_AffterSearch(string whereclause)
        {
            this.whereclause = whereclause;
            this.LoadData();
        }

        void lnkNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
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
            this.whereclause = string.Empty;
            this.LoadData();
        }
        private void LoadData()
        {
            int cnt = 0;
            this.dtblNotes = this.accNotes.GetDataPostageNotesPagesDescFreeSearch(1, this.pbar.PageSize, ref cnt, this.whereclause).Tables[0];
            this.dgrdv.DataSource = this.dtblNotes;
            this.pbar.Init(1, cnt);
        }
        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.whereclause = string.Empty;
            this.LoadData();
        }
    }
}