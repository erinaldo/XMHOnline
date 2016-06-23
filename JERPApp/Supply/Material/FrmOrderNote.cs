using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Supply.Material
{
    public partial class FrmOrderNote : Form
    {
        public FrmOrderNote()
        {
            InitializeComponent();
            this.dgrdvNonConfirm.AutoGenerateColumns = false; 
            this.dgrdvStore.AutoGenerateColumns = false;
            this.dgrdvNonFinished.AutoGenerateColumns = false;
            this.dgrdvFinished.AutoGenerateColumns = false; 
            this.ctrlQStore.SeachGridView = this.dgrdvStore;
            this.ctrlQNonConfirm.SeachGridView = this.dgrdvNonConfirm;
            this.ctrlQNonFinished.SeachGridView = this.dgrdvNonFinished;

            this.dgdvNonPrint.AutoGenerateColumns = false;
            this.ctrlNonPrint.SeachGridView = this.dgdvNonPrint;
            this.accNotes = new JERPData.Material.BuyOrderNotes();
            this.accBuyPlans = new JERPData.Material.BuyPlans();
            this.accStore = new JERPData.Material.Store();
            this.printer = new JERPBiz.Material.BuyOrderNotePrintHelper();
            this.SetPermit();
        }
        private JERPData.Material.BuyOrderNotes accNotes;
        private JERPData.Material.BuyPlans accBuyPlans;
        private JERPData.Material.Store accStore;
        private JERPBiz.Material.BuyOrderNotePrintHelper printer;
        private FrmOrderNoteOper frmOper;
        private Report.Bill.FrmBuyOrderNote frmDetail;
        private DataTable dtblNonConfirms,dtblNonPrints,dtblStores,dtblNonFinsheds,dtblFinisheds;
        private string iniwhereclause = " and (MakerPsnID="+JERPBiz .Frame .UserBiz.PsnID .ToString ()+") and (NoteID not in(select NoteID from mtr.BuyOrderItems where NonFinishedQty>0))";
        private string whereclause = string.Empty;
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(254);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(255);
            if (this.enableBrowse)
            {
                this.whereclause = this.iniwhereclause;
                //加载数据
                LoadData();
                this.dgrdvNonConfirm.ContextMenuStrip = this.cMenu; 
                this.dgrdvStore.ContextMenuStrip = this.cMenu;
                this.dgrdvNonFinished.ContextMenuStrip = this.cMenu;
                this.dgrdvFinished.ContextMenuStrip = this.cMenu;
                this.dgdvNonPrint.ContextMenuStrip = this.cMenu;
                this.dtpDateBegin.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                this.dtpDateEnd.Value = this.dtpDateBegin.Value.AddMonths(1).AddDays(-1).Date;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                this.lnkRefreshAll.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkRefreshAll_LinkClicked);
                this.btnSearch.Click += new EventHandler(btnSearch_Click);
                this.pbar.OnPageIndexChanged += new EventHandler(pbar_OnPageIndexChanged);
            }
            this.lnkNew.Enabled = this.enableSave;
            this.ColumnbtnEdit.Visible = this.enableSave;
            this.ColumnbtnPrint.Visible = this.enableSave;
            if (this.enableSave)
            {
                this.dgdvNonPrint.CellContentClick += new DataGridViewCellEventHandler(dgdvNonPrint_CellContentClick);
                this.lnkNew.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkNew_LinkClicked);
                this.dgrdvNonConfirm.CellContentClick += new DataGridViewCellEventHandler(dgrdvNonConfirm_CellContentClick);
                this.dgrdvNonFinished.CellContentClick += new DataGridViewCellEventHandler(dgrdvNonFinished_CellContentClick);
                this.dgrdvFinished.CellContentClick += new DataGridViewCellEventHandler(dgrdvFinished_CellContentClick);
            
            }


        }

        void btnSearch_Click(object sender, EventArgs e)
        {
            this.whereclause = this.iniwhereclause;
            if (this.ckbSupplier.Checked)
            {
                this.whereclause += " and (CompanyID=" + this.ctrlSupplierID.CompanyID.ToString() + ")";
            }
            if (this.ckbNoteCode.Checked)
            {
                this.whereclause += " and (NoteCode like '%" + this.txtNoteCode.Text + "%')";
            }
            if (this.ckbDateNote.Checked)
            {
                this.whereclause += " and (DateNote>='" + this.dtpDateBegin.Value.ToShortDateString()
                    + "' and DateNote<='" + this.dtpDateEnd.Value.ToShortDateString() + "')"; 

            }
            this.LoadFinished();
        }

        void pbar_OnPageIndexChanged(object sender, EventArgs e)
        {
            int cnt = 0;
            this.dtblFinisheds = this.accNotes.GetDataBuyOrderNotesDescPagesFreeSearch(this.pbar.PageIndex,
                this.pbar.PageSize, ref cnt, this.whereclause).Tables[0];
            this.dgrdvFinished.DataSource = this.dtblFinisheds;
        }
        void New(int CompanyID)
        {
            if (this.frmOper == null)
            {
                this.frmOper = new FrmOrderNoteOper();
                new FrmStyle(frmOper).SetPopFrmStyle(this);
                frmOper.AffterSave += this.LoadData;
            }
            frmOper.NewNote(CompanyID);
            frmOper.ShowDialog();
        }
        void lnkNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.New(-1);
        }

        void mItemRefresh_Click(object sender, EventArgs e)
        {
           
            if (this.cMenu.SourceControl == this.dgrdvStore)
            {
                this.LoadStore();
            }
            if (this.cMenu.SourceControl == this.dgrdvNonConfirm)
            {
                this.LoadNonConfirm();
            }
            if (this.cMenu.SourceControl == this.dgdvNonPrint )
            {
                this.LoadNonPrint();
            }
            if (this.cMenu.SourceControl == this.dgrdvNonFinished)
            {
                this.LoadNonFinished();
            }
            if (this.cMenu.SourceControl == this.dgrdvFinished)
            {
                this.whereclause = this.iniwhereclause;
                this.LoadFinished();
            }
        }
        void lnkRefreshAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
          
            this.LoadStore();
            this.LoadNonConfirm();
            this.LoadNonFinished();
            this.whereclause = this.iniwhereclause;
            this.LoadFinished(); 
            this.LoadPlan();
        }
        private void LoadPlan()
        {
            DataTable dtblSupplier = this.accBuyPlans.GetDataBuyPlansSupplierForOrder(JERPBiz.Frame.UserBiz.PsnID).Tables[0];
            for(int p=0;p<this.tabMain .TabPages .Count ;p++)
            {
                if (this.tabMain.TabPages[p].Tag == null)
                {
                    this.tabMain.TabPages.RemoveAt (p);
                    p--;
                }
            } 
            TabPage page;
            CtrlBuyPlanForSupplierOrder ctrSupplierPlan;
            foreach (DataRow drow in dtblSupplier.Rows)
            {
                page = new TabPage();
                page.Text = drow["CompanyAbbName"].ToString();
                ctrSupplierPlan = new CtrlBuyPlanForSupplierOrder();
                ctrSupplierPlan.Dock = DockStyle.Fill;
                ctrSupplierPlan.AffterNew += ctrSupplierPlan_AffterNew;
                ctrSupplierPlan.SupplierPlan((int)drow["CompanyID"]);
                page.Controls.Add(ctrSupplierPlan);
                this.tabMain.TabPages.Add(page);
            }
        }

        void ctrSupplierPlan_AffterNew(int CompanyID)
        {
            this.New(CompanyID);
        }
        private void LoadStore()
        {
            this.dtblStores = this.accStore.GetDataStoreSafeInventoryForPurchase (JERPBiz .Frame .UserBiz .PsnID ).Tables[0];
            this.dgrdvStore.DataSource = this.dtblStores;
            this.pageStore.Text = "安全库存[" + this.dtblStores.Rows.Count.ToString() + "]";
        }
        private void LoadNonConfirm()
        { 
            this.dtblNonConfirms = this.accNotes.GetDataBuyOrderNotesForAlter(JERPBiz .Frame.UserBiz .PsnID ).Tables[0];
            this.dgrdvNonConfirm.DataSource = this.dtblNonConfirms;
            this.pageNonConfirm.Text = "未审核[" + this.dtblNonConfirms.Rows.Count.ToString() + "]";
        }
        private void LoadNonPrint()
        {
            this.dtblNonPrints = this.accNotes.GetDataBuyOrderNotesNonPrint(JERPBiz.Frame.UserBiz.PsnID).Tables[0];
            this.dgdvNonPrint.DataSource = this.dtblNonPrints;
            this.pageNonPrint.Text = "未打印[" + this.dtblNonPrints.Rows.Count.ToString() + "]";
        }
        private void LoadNonFinished()
        {
            this.dtblNonFinsheds = this.accNotes.GetDataBuyOrderNotesNonFinishedByMakerPsnID  (JERPBiz .Frame .UserBiz .PsnID ).Tables[0];
            this.dgrdvNonFinished.DataSource = this.dtblNonFinsheds;
            this.pageNonFinished.Text = "未完成[" + this.dtblNonFinsheds.Rows.Count.ToString() + "]";
        }
        private void LoadFinished()
        {
            int cnt = 0;
            this.dtblFinisheds = this.accNotes.GetDataBuyOrderNotesDescPagesFreeSearch(1, this.pbar.PageSize,
                ref cnt, this.whereclause).Tables[0];
            this.dgrdvFinished.DataSource = this.dtblFinisheds;
            this.pbar.Init(1, cnt);
        }
        private void LoadData()
        {
            this.LoadPlan();
            this.LoadStore();
            this.LoadNonConfirm();
            this.LoadNonPrint();
            this.LoadNonFinished();
            this.LoadFinished();
        }


        void dgrdvNonConfirm_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvNonConfirm.Columns[icol].Name == this.ColumnbtnEdit.Name)
            {
                long NoteID = (long)this.dtblNonConfirms.DefaultView[irow]["NoteID"];
                if (this.frmOper == null)
                {
                    this.frmOper = new FrmOrderNoteOper();
                    new FrmStyle(frmOper).SetPopFrmStyle(this);
                    frmOper.AffterSave += this.LoadData;
                }
                frmOper.EditNote(NoteID);
                frmOper.ShowDialog();
            }

        }
        void ShowFrmDetail(long NoteID)
        {
            if (frmDetail == null)
            {
                frmDetail = new JERPApp.Supply.Material.Report.Bill.FrmBuyOrderNote();
                new FrmStyle(frmDetail).SetPopFrmStyle(this);
            }
            frmDetail.Detail(NoteID);
            frmDetail.ShowDialog();
        }

        void dgdvNonPrint_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;

            long NoteID = (long)this.dtblNonPrints.DefaultView[irow]["NoteID"];
            if (this.dgdvNonPrint  .Columns[icol].Name == this.ColumnbtnPrint.Name)
            {

                FrmMsg.Show("正在生成打印文档，请稍候......");
                this.printer.ExportToExcel(NoteID);
                FrmMsg.Hide(); 
                string errormsg = string.Empty;
                this.accNotes.UpdateBuyOrderNotesForPrint(ref errormsg,
                    NoteID);
                this.LoadNonPrint(); 
            }
            if (this.dgdvNonPrint.Columns[icol].DataPropertyName == "NoteCode")
            {  
                this.ShowFrmDetail(NoteID);
            }
        }

     
        void dgrdvNonFinished_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return; 
            if (this.dgrdvNonFinished .Columns[icol].DataPropertyName == "NoteCode")
            {
                long NoteID = (long)this.dtblNonFinsheds.DefaultView[irow]["NoteID"];
                this.ShowFrmDetail(NoteID);
            }
        }

        void dgrdvFinished_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvFinished.Columns[icol].DataPropertyName == "NoteCode")
            {
                long NoteID = (long)this.dtblFinisheds.DefaultView[irow]["NoteID"];
                this.ShowFrmDetail(NoteID);
            }
        }    
    }
}