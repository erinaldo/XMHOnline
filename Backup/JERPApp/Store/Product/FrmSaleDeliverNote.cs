using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Product
{
    public partial class FrmSaleDeliverNote : Form
    {
        public FrmSaleDeliverNote()
        {
            InitializeComponent();
            this.dgrdvPO.AutoGenerateColumns = false;
            this.dgrdvSample.AutoGenerateColumns = false;
            this.dgrdvConfirm.AutoGenerateColumns = false;
            this.ctrlQConfirm .SeachGridView = this.dgrdvConfirm;
            this.dgrdvPlan.AutoGenerateColumns = false;
            this.ctrlGridOrder.SeachGridView = this.dgrdvPlan;
            this.accNotes = new JERPData.Product.SaleDeliverNotes();
            this.accPlanItems = new JERPData.Product.SaleDeliverPlanItems();
            this.printhelper = new JERPBiz.Product.SaleDeliverPrintHelper();
            this.SetPermit();
        }
        private  JERPData.Product.SaleDeliverNotes accNotes;
        private JERPData.Product.SaleDeliverPlanItems  accPlanItems;
        private JERPBiz.Product.SaleDeliverPrintHelper printhelper;
        private FrmSaleDeliverNoteOper frmOper;
        private FrmSaleDeliverNoteConfirm frmConfirm;
        private JERPApp.Store.Product.Report.Bill.FrmSaleDeliverNote frmDetail;
        private string whereclause = string.Empty;       
        private DataTable dtblNotes,dtblNoteSamples,dtblPlanItems,dtblConfirm;
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(41);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(42);
            if (this.enableBrowse)
            {
                this.whereclause = string.Empty;
                //加载数据
                this.LoadRecord();
                this.LoadPlanNote();
                this.LoadConfirm(); 
                this.ctrlGridOrder.BeforeFilter += this.LoadPlanNote;
                this.btnSearch.Click += new EventHandler(btnSearch_Click);
                this.dgrdvPO.ContextMenuStrip = this.cMenu;
                this.dgrdvPlan.ContextMenuStrip = this.cMenu;
                this.dgrdvConfirm.ContextMenuStrip = this.cMenu;
            
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                this.pbar.OnPageIndexChanged += new EventHandler(pbar_OnPageIndexChanged);
                this.pbarSample .OnPageIndexChanged +=new EventHandler(pbarSample_OnPageIndexChanged);

                this.dgrdvPO.CellContentClick += new DataGridViewCellEventHandler(dgrdvPO_CellContentClick);
                this.dgrdvSample.CellContentClick += new DataGridViewCellEventHandler(dgrdvSample_CellContentClick);
                this.lnkRefreshAll.Click += new EventHandler(lnkRefreshAll_Click);
            }
            this.ColumnlnkDeliverOper  .Visible  = this.enableSave;
            this.ColumnbtnEdit.Visible = this.enableSave;
            this.ColumnbtnConfirm.Visible = this.enableSave;
            if (this.enableSave)
            {
                this.dgrdvPlan.CellContentClick += new DataGridViewCellEventHandler(dgrdvPlan_CellContentClick);
                this.dgrdvConfirm.CellContentClick += new DataGridViewCellEventHandler(dgrdvConfirm_CellContentClick);
                
            }
        }

        void lnkRefreshAll_Click(object sender, EventArgs e)
        {
            this.LoadRecord();
            this.LoadPlanNote();
            this.LoadConfirm(); 
        }

       
        void dgrdvPlan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvPlan.Columns[icol].Name == this.ColumnlnkDeliverOper .Name)
            {
                long NoteID = (long)this.dtblPlanItems.DefaultView[irow]["NoteID"];
                if (this.frmOper == null)
                {
                    this.frmOper = new FrmSaleDeliverNoteOper();
                    new FrmStyle(frmOper).SetPopFrmStyle(this);
                    frmOper.AffterSave += new FrmSaleDeliverNoteOper.AffterSaveDelegate(frmOper_AffterSave);
                }
                frmOper.New (NoteID);
                frmOper.ShowDialog();
            }
        }       

        void frmOper_AffterSave()
        {
            this.whereclause = string.Empty;
            this.LoadRecord();
            this.LoadConfirm();
            this.LoadPlanNote();
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
                this.whereclause += " and (DateNote>='" + this.dtpDateBegin.Value.ToShortDateString() + "' and DateNote<='" + this.dtpDateEnd.Value.Date.ToShortDateString() + "')";
            }
            this.LoadRecord();
        }
        void dgrdvPO_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            long NoteID = (long)this.dtblNotes.DefaultView[irow]["NoteID"];
            if (this.dgrdvPO.Columns[icol].Name == this.ColumnbtnDetail.Name)
            { 
                if (this.frmDetail == null)
                {
                    this.frmDetail = new JERPApp.Store.Product.Report.Bill.FrmSaleDeliverNote();
                    new FrmStyle(frmDetail).SetPopFrmStyle(this);
                   
                }
                frmDetail.DetailNote (NoteID);
                frmDetail.ShowDialog();
            }
           
        }
        void dgrdvSample_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            long NoteID = (long)this.dtblNoteSamples .DefaultView[irow]["NoteID"];
            if (this.dgrdvSample.Columns[icol].Name == this.ColumnbtnDetailSample.Name)
            {
                if (this.frmDetail == null)
                {
                    this.frmDetail = new JERPApp.Store.Product.Report.Bill.FrmSaleDeliverNote();
                    new FrmStyle(frmDetail).SetPopFrmStyle(this);

                }
                frmDetail.DetailNote(NoteID);
                frmDetail.ShowDialog();
            }
           
        }
        void dgrdvConfirm_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            long NoteID = (long)this.dtblConfirm.DefaultView[irow]["NoteID"];
            if (this.dgrdvConfirm.Columns[icol].Name == this.ColumnbtnEdit .Name)
            { 
                if (frmOper == null)
                {
                    frmOper = new FrmSaleDeliverNoteOper();
                    new FrmStyle(frmOper).SetPopFrmStyle(this);
                    frmOper .AffterSave +=new FrmSaleDeliverNoteOper.AffterSaveDelegate(frmOper_AffterSave);
                }
                frmOper.Edit (NoteID);
                frmOper.ShowDialog();
            }
            if (this.dgrdvConfirm.Columns[icol].Name == this.ColumnbtnConfirm .Name)
            {
                if (frmConfirm  == null)
                {
                    frmConfirm = new FrmSaleDeliverNoteConfirm();
                    new FrmStyle(frmConfirm).SetPopFrmStyle(this);
                    frmConfirm.AffterSave += new FrmSaleDeliverNoteConfirm.AffterSaveDelegate(frmConfirm_AffterSave);
                }
                frmConfirm.ConfirmOper (NoteID);
                frmConfirm.ShowDialog();
            }
        }

        void frmConfirm_AffterSave()
        {
            this.LoadConfirm();
            this.LoadRecord();
        }
        void mItemRefresh_Click(object sender, EventArgs e)
        {
            if (this.cMenu.SourceControl == this.dgrdvPlan)
            {
                this.LoadPlanNote ();
            }
            if (this.cMenu.SourceControl == this.dgrdvPO)
            {
                this.whereclause = string.Empty;
                this.LoadRecord();
            }
            if (this.cMenu.SourceControl == this.dgrdvConfirm)
            {
                this.LoadConfirm();
            }
        }
        private void LoadPlanNote()
        {
            this.dtblPlanItems = this.accPlanItems.GetDataSaleDeliverPlanItemsNonDeliver  ().Tables[0];
            int cnt = 0;
            this.dtblPlanItems.Columns.Add("DeliverOper", typeof(string));
            long lastnoteid = -1;
            long noteid = -1;
            foreach (DataRow drow in this.dtblPlanItems.Rows)
            {
                noteid = (long)drow["NoteID"];
                if (noteid != lastnoteid)
                {
                    cnt.ToString();
                    drow["DeliverOper"] = "制单";
                }
                else
                {
                    drow["CompanyAbbName"] = DBNull.Value;
                    drow["PONo"] = DBNull.Value; 
                }
                lastnoteid = noteid;
            }
            this.dgrdvPlan.DataSource = this.dtblPlanItems;
            this.pagePlan.Text = "未出货[" + cnt.ToString() + "]";
        }
        private void LoadConfirm()
        {
            this.dtblConfirm  = this.accNotes.GetDataSaleDeliverNotesNonConfirm ().Tables[0];
            this.dgrdvConfirm.DataSource = this.dtblConfirm;
            this.pageConfirm .Text = "未审核[" + this.dtblConfirm.Rows.Count.ToString() + "]";
        }
        private void LoadRecord()
        {
           
            int cnt = 0;
            string clause=this.whereclause +" and (ConfirmPsnID is not null) and (SaleOrderNoteID is not null)";
            this.dtblNotes = this.accNotes.GetDataSaleDeliverNotesDescPagesFreeSearch(1, this.pbar.PageSize, ref cnt, clause ).Tables[0];
            this.dgrdvPO.DataSource = this.dtblNotes;
            this.pbar.Init(1, cnt);

            clause = this.whereclause + " and (ConfirmPsnID is not null) and (SaleOrderNoteID is  null)";
            this.dtblNoteSamples = this.accNotes.GetDataSaleDeliverNotesDescPagesFreeSearch(1, this.pbar.PageSize, ref cnt, clause).Tables[0];
            this.dgrdvSample.DataSource = this.dtblNoteSamples;
            this.pbarSample.Init(1, cnt);
        }

        void pbar_OnPageIndexChanged(object sender, EventArgs e)
        {
            int cnt = 0;
            string clause = this.whereclause + " and (ConfirmPsnID is not null) and (SaleOrderNoteID is not null)";
            this.dtblNotes = this.accNotes.GetDataSaleDeliverNotesDescPagesFreeSearch (this.pbar .PageIndex , this.pbar.PageSize, ref cnt,clause  ).Tables[0];
            this.dgrdvPO.DataSource = this.dtblNotes;
        }
        void pbarSample_OnPageIndexChanged(object sender, EventArgs e)
        {
            int cnt = 0;
            string clause = this.whereclause + " and (ConfirmPsnID is not null) and (SaleOrderNoteID is  null)";
            this.dtblNoteSamples  = this.accNotes.GetDataSaleDeliverNotesDescPagesFreeSearch(this.pbarSample .PageIndex, this.pbarSample.PageSize, ref cnt, clause).Tables[0];
            this.dgrdvSample.DataSource = this.dtblNoteSamples;
        }
    }
}