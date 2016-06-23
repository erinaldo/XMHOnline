using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Material
{
    public partial class FrmOutSrcSupplyNote : Form
    {
        public FrmOutSrcSupplyNote()
        {
            InitializeComponent();
            this.dgrdvConfirm.AutoGenerateColumns = false;
            this.dgrdvOrder.AutoGenerateColumns = false; 
            this.dgrdvNonConfirm.AutoGenerateColumns = false; 
            this.accNotes = new JERPData.Material.OutSrcSupplyNotes(); 
            this.accOutSrcOrderItems = new JERPData.Manufacture .OutSrcOrderItems ();
            this.accItems = new JERPData.Material.OutSrcSupplyItems();
            this.SetPermit();
        }
        private JERPData.Material.OutSrcSupplyNotes accNotes;
        private JERPData.Manufacture .OutSrcOrderItems  accOutSrcOrderItems;
        private JERPData.Material.OutSrcSupplyItems accItems; 
        private FrmOutSrcSupplyNoteOper frmOper;
        private FrmOutSrcSupplyConfirm frmConfirm;
        private FrmOutSrcSupplyNoteReplenishOper frmReplenish; 
        private JERPApp.Store.Material.Report.Bill.FrmOutSrcSupplyNote frmDetail;
        private string whereclause = string.Empty;
        private string initwherecluase = " and (ConfirmPsnID is not null)";
        private DataTable dtblOrderItems,dtblConfirms,dtblNonConfirms;
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(533);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(534);
            if (this.enableBrowse)
            {
                this.whereclause = this.initwherecluase;
                //加载数据
                this.LoadNonConfirm();
                this.LoadConfirm();
                this.LoadPlan();
                this.LoadReplenish();
                this.dtpDateBegin.Value = DateTime.Now.Date.AddDays(-2);
                this.dtpDateEnd.Value = DateTime.Now.Date.AddDays (-1);
                this.dgrdvConfirm.CellContentClick += new DataGridViewCellEventHandler(dgrdvConfirm_CellContentClick);
                this.pbar.OnPageIndexChanged += new EventHandler(pbar_OnPageIndexChanged);
                this.dgrdvOrder.ContextMenuStrip = this.cMenu;
                this.dgrdvConfirm.ContextMenuStrip = this.cMenu;
                this.dgrdvNonConfirm.ContextMenuStrip = this.cMenu;
                this.btnSearch.Click += new EventHandler(btnSearch_Click);
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                this.lnkRefreshAll.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkRefreshAll_LinkClicked);
            }
          
            this.ColumnbtnEdit .Visible = this.enableSave;
            this.ColumnbtnCreate.Visible = this.enableSave;
            this.ColumnbtnConfirm.Visible = this.enableSave;
            if (this.enableSave)
            { 
                this.dgrdvOrder.CellContentClick += new DataGridViewCellEventHandler(dgrdvOrder_CellContentClick); 
                this.dgrdvNonConfirm.CellContentClick += new DataGridViewCellEventHandler(dgrdvNonConfirm_CellContentClick); 
            }

        }

        void btnSearch_Click(object sender, EventArgs e)
        {
            this.whereclause = this.initwherecluase;
            if (this.ckbDateNote.Checked)
            {
                this.whereclause += " and (DateNote>='" + this.dtpDateBegin.Value.ToShortDateString() + "' and DateNote<='" + this.dtpDateEnd.Value.ToShortDateString() + "')";
            }
            if (this.ckbSupplier.Checked)
            {
                this.whereclause += " and (CompanyID=" + this.ctrlSupplierID.CompanyID + ")";
            }
            this.LoadConfirm();
        }

        void lnkRefreshAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.whereclause = this.initwherecluase;
            this.LoadPlan();
            this.LoadConfirm();
            this.LoadReplenish();
            this.LoadNonConfirm();
        }
 

        void mItemRefresh_Click(object sender, EventArgs e)
        {
            if (this.cMenu.SourceControl == this.dgrdvOrder )
            {
                this.LoadPlan();
            } 
            if (this.cMenu.SourceControl == this.dgrdvNonConfirm )
            {
                this.LoadNonConfirm();
            }
            if (this.cMenu.SourceControl == this.dgrdvConfirm)
            {
                this.whereclause =this.initwherecluase ;
                this.LoadConfirm();
            }
        }

        void pbar_OnPageIndexChanged(object sender, EventArgs e)
        {
            int cnt = 0;
            this.dtblConfirms = this.accNotes.GetDataOutSrcSupplyNotesDescPagesFreeSearch (this.pbar .PageIndex , this.pbar.PageSize, ref cnt,this.whereclause ).Tables[0];
            this.dgrdvConfirm.DataSource = this.dtblConfirms;
        }

        void dgrdvConfirm_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvConfirm.Columns[icol].Name == this.ColumnNoteCode .Name)
            {
                long NoteID =(long) this.dtblConfirms.DefaultView[irow]["NoteID"];
                if (this.frmDetail  == null)
                {
                    this.frmDetail = new JERPApp.Store.Material.Report.Bill.FrmOutSrcSupplyNote();
                    new FrmStyle(frmDetail).SetPopFrmStyle(this);                   
                }
                frmDetail.DetailNote (NoteID);
                frmDetail.ShowDialog();
            }
        }
        private void dgrdvNonConfirm_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            long NoteID = (long)this.dtblNonConfirms.DefaultView[irow]["NoteID"];
            if (this.dgrdvNonConfirm.Columns[icol].Name == this.ColumnbtnConfirm .Name)
            {
                if (frmConfirm == null)
                {
                    frmConfirm = new FrmOutSrcSupplyConfirm();
                    new FrmStyle(frmConfirm).SetPopFrmStyle(this);
                    frmConfirm.AffterSave += new FrmOutSrcSupplyConfirm.AffterSaveDelegate(frmConfirm_AffterSave);
                }
                frmConfirm.ConfirmOper(NoteID);
                frmConfirm.ShowDialog();
            }
            if (this.dgrdvNonConfirm.Columns[icol].Name == this.ColumnbtnEdit.Name)
            {
                if (this.frmOper == null)
                {
                    this.frmOper = new FrmOutSrcSupplyNoteOper();
                    new FrmStyle(frmOper).SetPopFrmStyle(this);
                    frmOper.AffterSave += this.frmOper_AffterSave;
                }
                frmOper.Edit(NoteID);
                frmOper.ShowDialog();
            }
        }

        void frmConfirm_AffterSave()
        {
            this.LoadNonConfirm(); 
            this.LoadReplenish();
            this.whereclause = this.initwherecluase;
            this.LoadConfirm();
        }
 
        void dgrdvOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvOrder.Columns[icol].Name == this.ColumnbtnCreate .Name)
            {
                int  CompanyID = (int )this.dtblOrderItems.DefaultView[irow]["CompanyID"];
                string CompanyAbbName = this.dtblOrderItems.DefaultView[irow]["CompanyAbbName"].ToString();
                if (this.frmOper == null)
                {
                    this.frmOper = new FrmOutSrcSupplyNoteOper();
                    new FrmStyle(frmOper).SetPopFrmStyle(this);
                    frmOper.AffterSave +=this.frmOper_AffterSave;
                }
                frmOper.New (CompanyID ,CompanyAbbName );
                frmOper.ShowDialog();
            }
        }
     
        void frmOper_AffterSave()
        {
            this.LoadPlan(); 
            this.LoadReplenish();
            this.LoadNonConfirm();
        }
        private void LoadPlan()
        {
            this.dtblOrderItems = this.accOutSrcOrderItems.GetDataOutSrcOrderItemsNeedSupplyBOM ().Tables[0];
            this.dgrdvOrder.DataSource = this.dtblOrderItems;
            
        }
        private void LoadReplenish()
        {
            while (this.tabMain.TabPages .Count  > 2)
            {
                this.tabMain.TabPages.RemoveAt(2);
            }
            DataTable dtblSupplier = this.accItems.GetDataOutSrcSupplyItemsNonFinishedSupplier  ().Tables[0];
            CtrlOutSrcReplenishItem ctrlItem;
            TabPage page;
            foreach (DataRow drow in dtblSupplier.Rows)
            {
                ctrlItem = new CtrlOutSrcReplenishItem();
                ctrlItem.AffterNew += new CtrlOutSrcReplenishItem.AffterNewDelegate(ctrlItem_AffterNew);
                ctrlItem.ReplenishItem((int)drow["CompanyID"]);
                page = new TabPage();
                page.Text = drow["CompanyAbbName"].ToString() + "(补)";
                page.Controls.Add(ctrlItem);
                ctrlItem.Dock = DockStyle.Fill;
                this.tabMain.TabPages.Add(page);
            }
        }

        void ctrlItem_AffterNew(int CompanyID)
        {
            if (frmReplenish == null)
            {
                frmReplenish = new FrmOutSrcSupplyNoteReplenishOper();
                new FrmStyle(frmReplenish).SetPopFrmStyle(this);
                frmReplenish.AffterSave += frmReplenish_AffterSave;
            }
            frmReplenish.NewNote(CompanyID);
            frmReplenish.ShowDialog();
        }

        void frmReplenish_AffterSave()
        {
            this.whereclause = this.initwherecluase;
            this.LoadConfirm();
            this.LoadReplenish();
            this.LoadNonConfirm();
        }
        private void LoadConfirm()
        {
            int cnt = 0;
            this.dtblConfirms = this.accNotes.GetDataOutSrcSupplyNotesDescPagesFreeSearch(1,this.pbar .PageSize ,ref cnt,this.whereclause ).Tables [0];
            this.dgrdvConfirm.DataSource = this.dtblConfirms;
            this.pbar.Init(1, cnt);
        }
        private void LoadNonConfirm()
        {
            this.dtblNonConfirms = this.accNotes.GetDataOutSrcSupplyNotesNonConfirm ().Tables[0];
            this.dgrdvNonConfirm.DataSource = this.dtblNonConfirms;

        }
     
    }
}