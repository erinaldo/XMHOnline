using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Engineer.Tool
{
    public partial class FrmOrderNote : Form
    {
        public FrmOrderNote()
        {
            InitializeComponent();
            this.dgrdvNonConfirm.AutoGenerateColumns = false;
            this.dgrdvNonPrint.AutoGenerateColumns = false;
            this.dgrdvPrint.AutoGenerateColumns = false;
            this.ctrlQNonConfirm.SeachGridView = this.dgrdvNonConfirm;
            this.ctrlQNonPrint.SeachGridView = this.dgrdvNonPrint;
            this.accNotes = new JERPData.Tool.BuyOrderNotes();
            this.printer = new JERPBiz.Tool.BuyOrderNotePrintHelper();
            this.SetPermit();
        }
        private JERPData.Tool.BuyOrderNotes accNotes;
        private JERPBiz.Tool.BuyOrderNotePrintHelper printer;
        private FrmOrderNoteOper frmOper;
        private Report.Bill.FrmBuyOrderNote frmDetail;
        private DataTable dtblNonConfirms, dtblNonPrints, dtblPrints; 
        private string iniwhereclause = " and (PrintFlag=1)";
        private string whereclause = string.Empty;
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(672);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(673);
            if (this.enableBrowse)
            {
                //加载数据      
                this.whereclause = this.iniwhereclause;
                this.LoadNonConfirm();
                this.LoadNonPrint();
                this.LoadPrint();
                this.dgrdvNonConfirm.ContextMenuStrip = this.cMenu;
                this.dgrdvNonPrint.ContextMenuStrip = this.cMenu;
                this.dgrdvPrint.ContextMenuStrip = this.cMenu;
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
                this.dgrdvNonPrint.CellContentClick += new DataGridViewCellEventHandler(dgrdvNonPrint_CellContentClick);
                this.dgrdvPrint.CellContentClick += new DataGridViewCellEventHandler(dgrdvPrint_CellContentClick);
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
            this.LoadPrint();
        }

        void pbar_OnPageIndexChanged(object sender, EventArgs e)
        {
            int cnt = 0;
            this.dtblPrints = this.accNotes.GetDataBuyOrderNotesDescPagesFreeSearch(this.pbar.PageIndex,
                this.pbar.PageSize, ref cnt, this.whereclause).Tables[0];
            this.dgrdvPrint.DataSource = this.dtblPrints;
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
                    frmOper.AffterSave += this.LoadNonConfirm ;
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
                frmOper.AffterSave += this.LoadNonConfirm ;
            }
            frmOper.NewNote();
            frmOper.ShowDialog();
        }

        void mItemRefresh_Click(object sender, EventArgs e)
        {
            if (this.cMenu.SourceControl == this.dgrdvNonConfirm)
            {
                this.LoadNonConfirm();
            }
            if (this.cMenu.SourceControl == this.dgrdvNonPrint)
            {
                this.LoadNonPrint();
            }
            if (this.cMenu.SourceControl == this.dgrdvPrint)
            {
                this.whereclause = this.iniwhereclause;
                this.LoadPrint();
            }
        }

        void lnkRefreshAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        { 
            this.LoadNonConfirm();
            this.LoadNonPrint();
            this.whereclause = this.iniwhereclause;
            this.LoadPrint();
        }
        private void LoadNonConfirm()
        {
            this.dtblNonConfirms = this.accNotes.GetDataBuyOrderNotesNonConfirm().Tables[0];
            this.dgrdvNonConfirm.DataSource = this.dtblNonConfirms;
            this.pageNonConfirm.Text = "未审核[" + this.dtblNonConfirms.Rows.Count.ToString() + "]";
        }
        private void LoadNonPrint()
        {
            this.dtblNonPrints = this.accNotes.GetDataBuyOrderNotesNonPrint().Tables[0];
            this.dgrdvNonPrint.DataSource = this.dtblNonPrints;
            this.pageNonPrint.Text = "未打印[" + this.dtblNonPrints.Rows.Count.ToString() + "]";
        }
        private void LoadPrint()
        {
            int cnt = 0;
            this.dtblPrints = this.accNotes.GetDataBuyOrderNotesDescPagesFreeSearch(1, this.pbar.PageSize,
                ref cnt, this.whereclause).Tables[0];
            this.dgrdvPrint.DataSource = this.dtblPrints;
            this.pbar.Init(1, cnt);
        }
        void ShowFrmDetail(long NoteID)
        {
            if (frmDetail == null)
            {
                frmDetail = new JERPApp.Engineer .Tool .Report.Bill.FrmBuyOrderNote();
                new FrmStyle(frmDetail).SetPopFrmStyle(this);
            }
            frmDetail.Detail(NoteID);
            frmDetail.ShowDialog();
        }
        void dgrdvNonPrint_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            long NoteID = (long)this.dtblNonPrints.DefaultView[irow]["NoteID"];
            if (this.dgrdvNonPrint.Columns[icol].Name == this.ColumnbtnPrint.Name)
            {

                FrmMsg.Show("正在生成打印文档，请稍候......");
                this.printer.ExportToExcel(NoteID);
                FrmMsg.Hide();

                string errormsg = string.Empty;
                this.accNotes.UpdateBuyOrderNotesForPrint(ref errormsg,
                    NoteID);
                this.LoadNonPrint();
                this.whereclause = this.iniwhereclause;
                this.LoadPrint();
            }
            if (this.dgrdvNonPrint.Columns[icol].DataPropertyName == "NoteCode")
            {
                this.ShowFrmDetail(NoteID);
            }
        }

        void dgrdvPrint_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvPrint.Columns[icol].DataPropertyName == "NoteCode")
            {
                long NoteID = (long)this.dtblPrints.DefaultView[irow]["NoteID"];
                this.ShowFrmDetail(NoteID);
            }
        }

    
    }
}