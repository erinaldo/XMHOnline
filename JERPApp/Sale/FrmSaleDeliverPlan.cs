using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Sale
{
    public partial class FrmSaleDeliverPlan : Form
    {
        public FrmSaleDeliverPlan()
        {
            InitializeComponent(); 
          
            this.dgrdvPlan.AutoGenerateColumns = false;
            this.ctrlQPlan.SeachGridView = this.dgrdvPlan;
            this.dgrdvOrder.AutoGenerateColumns = false;
            this.ctrlQOrder.SeachGridView = this.dgrdvOrder;
            this.accNotes = new JERPData.Product.SaleDeliverPlanNotes();
            this.accOrderNotes = new JERPData.Product.SaleOrderNotes();
           
            this.SetPermit();
        }
        private JERPData.Product.SaleDeliverPlanNotes accNotes;
        private JERPData.Product.SaleOrderNotes accOrderNotes; 
        private FrmSaleDeliverPlanOper frmOper;
        private FrmSaleDeliverPlanTmpOper frmTmpOper;
        private DataTable dtblPlanNotes, dtblOrderNotes;
        private FrmSaleDeliverPlanBatch frmBatchOper;
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(25);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(26);
            if (this.enableBrowse)
            {
               
                //加载数据
                this.LoadPlanData();
                this.LoadOrderData(); 
                this.ctrlQPlan.BeforeFilter += this.LoadOrderData ;
                this.ctrlQOrder.BeforeFilter += this.LoadOrderData; 
                this.dgrdvOrder.ContextMenuStrip = this.cMenu;
                this.dgrdvPlan.ContextMenuStrip = this.cMenu;
            
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click); 
                this.dgrdvPlan.CellContentClick += new DataGridViewCellEventHandler(dgrdvPlan_CellContentClick);
            }
            this.ColumnbtnDeliver.Visible  = this.enableSave;
            this.ColumnbtnEdit .Visible = this.enableSave; 
            this.lnkNonNew.Enabled = this.enableSave;
            this.lnkBatchNew.Enabled = this.enableSave;
            if (this.enableSave)
            {
                this.lnkBatchNew.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkBatchNew_LinkClicked);  
                this.dgrdvOrder.CellContentClick += new DataGridViewCellEventHandler(dgrdvOrder_CellContentClick);
                this.lnkNonNew.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkNonNew_LinkClicked);
            }
        }

        void lnkBatchNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (frmBatchOper == null)
            {
                frmBatchOper = new FrmSaleDeliverPlanBatch();
                new FrmStyle(frmBatchOper).SetPopFrmStyle(this);
                frmBatchOper.AffterSave += new FrmSaleDeliverPlanBatch.AffterSaveDelegate(frmBatchOper_AffterSave);
            }
            frmBatchOper.LoadData();
            frmBatchOper.ShowDialog();
        }

        void frmBatchOper_AffterSave()
        {
            this.LoadOrderData();
            this.LoadPlanData();
        }
       
        void frmOper_AffterSave()
        {
            this.LoadPlanData();
            this.LoadOrderData();
        }

        void dgrdvOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvOrder.Columns[icol].Name == this.ColumnbtnDeliver.Name)
            {
                long SaleOrderNoteID = (long)this.dtblOrderNotes.DefaultView[irow]["NoteID"];
                if (this.frmOper == null)
                {
                    this.frmOper = new FrmSaleDeliverPlanOper();
                    new FrmStyle(frmOper).SetPopFrmStyle(this);
                    frmOper.AffterSave += new FrmSaleDeliverPlanOper.AffterSaveDelegate(frmOper_AffterSave);
                }
                long NoteID = -1;
                this.accNotes.GetParmSaleDeliverPlanNotesNoteIDBySaleOrderNoteID(SaleOrderNoteID, ref NoteID);
                if (NoteID == -1)
                {
                    this.frmOper.NewNote(SaleOrderNoteID);
                }
                else
                {
                    this.frmOper.Edit(NoteID);
                }
                this.frmOper.ShowDialog();
            }
        }       

      

        void lnkNonNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (frmTmpOper == null)
            {
                frmTmpOper = new FrmSaleDeliverPlanTmpOper();
                new FrmStyle(frmTmpOper).SetPopFrmStyle(this);
                frmTmpOper.AffterSave += new FrmSaleDeliverPlanTmpOper.AffterSaveDelegate(frmTmpOper_AffterSave);
            }
            frmTmpOper.NewNote();
            frmTmpOper.ShowDialog();
        }

        void frmTmpOper_AffterSave()
        {
            this.LoadPlanData();
        }

      
         void dgrdvPlan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvPlan.Columns[icol].Name == this.ColumnbtnEdit .Name)
            {
                long NoteID = (long)this.dtblPlanNotes .DefaultView[irow]["NoteID"];
                if (this.dtblPlanNotes.DefaultView[irow]["SaleOrderNoteID"] == DBNull.Value)
                {
                    if (frmTmpOper == null)
                    {
                        frmTmpOper = new FrmSaleDeliverPlanTmpOper();
                        new FrmStyle(frmTmpOper).SetPopFrmStyle(this);
                        frmTmpOper.AffterSave += new FrmSaleDeliverPlanTmpOper.AffterSaveDelegate(frmTmpOper_AffterSave);
                    }
                    frmTmpOper.Edit (NoteID );
                    frmTmpOper.ShowDialog();
                }
                else
                {
                    if (this.frmOper == null)
                    {
                        this.frmOper = new FrmSaleDeliverPlanOper();
                        new FrmStyle(frmOper).SetPopFrmStyle(this);
                        frmOper.AffterSave += new FrmSaleDeliverPlanOper.AffterSaveDelegate(frmOper_AffterSave);
                    }
                    this.frmOper.Edit(NoteID);
                    this.frmOper.ShowDialog();
                }
            }

        }
  
        void mItemRefresh_Click(object sender, EventArgs e)
        {
            if (this.cMenu.SourceControl == this.dgrdvOrder)
            {
                this.LoadOrderData  ();
            }
          
            if (this.cMenu.SourceControl == this.dgrdvPlan)
            {
                this.LoadPlanData ();
            }
        }
        private void LoadOrderData()
        {
            this.dtblOrderNotes = this.accOrderNotes.GetDataSaleOrderNotesForDeliverApply (JERPBiz .Frame .UserBiz .PsnID ).Tables[0];
            this.dgrdvOrder.DataSource = this.dtblOrderNotes;
            this.pageOrder.Text = "订单申请[" + this.dtblOrderNotes.Rows.Count.ToString() + "]";
        }      
        private void LoadPlanData()
        {
            this.dtblPlanNotes = this.accNotes.GetDataSaleDeliverPlanNotesForAlter(JERPBiz.Frame.UserBiz.PsnID).Tables[0];
            this.dgrdvPlan.DataSource = this.dtblPlanNotes;
            this.pagePlan .Text = "申请变更[" + this.dtblPlanNotes.Rows.Count.ToString() + "]";
        }

        
    }
}