using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Supply.OutSrc
{
    public partial class FrmOrderNote : Form
    {
        public FrmOrderNote()
        {
            InitializeComponent();
            this.dgrdvSchedule.AutoGenerateColumns = false;
            this.dgrdvNonConfirm.AutoGenerateColumns = false;
            this.dgrdvNonFinished.AutoGenerateColumns = false;
            this.dgrdvFinished.AutoGenerateColumns = false;
            this.ctrlQSchedule.SeachGridView = this.dgrdvSchedule;
            this.ctrlQNonConfirm .SeachGridView =this.dgrdvNonConfirm  ;
            this.ctrlQNonPrint.SeachGridView = this.dgrdvNonFinished;
            this.accNotes = new JERPData.Manufacture.OutSrcOrderNotes();
            this.accSchedule = new JERPData.Manufacture.ManufSchedules();
            this.printer = new JERPBiz.Manufacture.OutSrcOrderNotePrintHelper();
            this.SetPermit();
        }
        private JERPData.Manufacture.OutSrcOrderNotes accNotes;
        private JERPData.Manufacture.ManufSchedules accSchedule;
        private JERPBiz.Manufacture.OutSrcOrderNotePrintHelper printer;
        private FrmOrderNoteOper frmOper;
        private Report.Bill.FrmOutSrcOrderNote frmDetail;
        private DataTable dtblSchedules, dtblNonConfirms, dtblNonFinisheds, dtblFinisheds;
        private string iniwhereclause = "and (NoteID not in(select NoteID from manuf.OutSrcOrderItems where NonFinishedQty>0))";
        private string whereclause = string.Empty;
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(196);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(197);
            if (this.enableBrowse)
            {
                //加载数据
                this.whereclause = this.iniwhereclause;
                LoadData();
                this.dgrdvSchedule.ContextMenuStrip = this.cMenu;
                this.dgrdvNonConfirm.ContextMenuStrip = this.cMenu;
                this.dgrdvNonFinished.ContextMenuStrip = this.cMenu;
                this.dgrdvFinished.ContextMenuStrip = this.cMenu;
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
            this.dtblFinisheds = this.accNotes.GetDataOutSrcOrderNotesDescPagesFreeSearch (this.pbar.PageIndex,
                this.pbar.PageSize, ref cnt, this.whereclause).Tables[0];
            this.dgrdvFinished.DataSource = this.dtblFinisheds;
        }
        void dgrdvNonConfirm_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;            
            if (this.dgrdvNonConfirm .Columns[icol].Name == this.ColumnbtnEdit.Name)
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

        void lnkNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.frmOper == null)
            {
                this.frmOper = new FrmOrderNoteOper();
                new FrmStyle(frmOper).SetPopFrmStyle(this);
                frmOper.AffterSave += this.LoadData;
            }
            frmOper.NewNote();
            frmOper.ShowDialog();
        }

        void mItemRefresh_Click(object sender, EventArgs e)
        {
            if (this.cMenu.SourceControl == this.dgrdvSchedule)
            {
                this.LoadSchedule();
            }
            if (this.cMenu.SourceControl == this.dgrdvNonConfirm)
            {
                this.LoadNonConfirm();
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
            this.LoadSchedule();
            this.LoadNonConfirm();
            this.LoadNonFinished();
            this.whereclause = this.iniwhereclause;
            this.LoadFinished();
        }
        private void LoadSchedule()
        {
            this.dtblSchedules = this.accSchedule.GetDataManufSchedulesNonOutSrcOrder().Tables[0];
            this.dgrdvSchedule.DataSource = this.dtblSchedules;
            this.pageSchedule.Text = "未下单[" + this.dtblSchedules.Rows.Count.ToString() + "]";
        }
        private void LoadNonConfirm()
        {
            this.dtblNonConfirms = this.accNotes.GetDataOutSrcOrderNotesNonConfirm ().Tables[0];
            this.dgrdvNonConfirm.DataSource = this.dtblNonConfirms;
            this.pageNonConfirm.Text = "未审核[" + this.dtblNonConfirms.Rows.Count.ToString() + "]";
        }
        private void LoadNonFinished()
        {
            this.dtblNonFinisheds = this.accNotes.GetDataOutSrcOrderNotesNonFinished  ().Tables[0];
            this.dgrdvNonFinished.DataSource = this.dtblNonFinisheds;
            this.pageNonFinished.Text = "未完成[" + this.dtblNonFinisheds.Rows.Count.ToString() + "]";
        }
        private void LoadFinished()
        {
            int cnt = 0;
            this.dtblFinisheds = this.accNotes.GetDataOutSrcOrderNotesDescPagesFreeSearch (1, this.pbar.PageSize,
                ref cnt, this.whereclause).Tables[0];
            this.dgrdvFinished.DataSource = this.dtblFinisheds;
            this.pbar.Init(1, cnt);
        }
        private void LoadData()
        {
            this.LoadSchedule();
            this.LoadNonConfirm();
            this.LoadNonFinished();
            this.LoadFinished();

        }
        void ShowFrmDetail(long NoteID)
        {
            if (frmDetail == null)
            {
                frmDetail = new JERPApp.Supply.OutSrc.Report.Bill.FrmOutSrcOrderNote();
                new FrmStyle(frmDetail).SetPopFrmStyle(this);
            }
            frmDetail.Detail(NoteID);
            frmDetail.ShowDialog();
        }
        void dgrdvNonFinished_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            long NoteID = (long)this.dtblNonFinisheds.DefaultView[irow]["NoteID"];
            if (this.dgrdvNonFinished.Columns[icol].Name == this.ColumnbtnPrint.Name)
            {

                FrmMsg.Show("正在生成打印文档，请稍候......");
                this.printer.ExportToExcel(NoteID);
                FrmMsg.Hide();

                string errormsg = string.Empty;
                this.accNotes.UpdateOutSrcOrderNotesForPrint(ref errormsg,
                    NoteID);
                this.LoadNonFinished();
                this.whereclause = this.iniwhereclause;
                this.LoadFinished();
            }
            if (this.dgrdvNonFinished.Columns[icol].DataPropertyName == "NoteCode")
            {
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