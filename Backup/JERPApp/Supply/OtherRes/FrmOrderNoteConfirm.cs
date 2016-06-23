using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Supply.OtherRes
{
    public partial class FrmOrderNoteConfirm : Form
    {
        public FrmOrderNoteConfirm()
        {
            InitializeComponent();
            this.dgrdvNonConfirm.AutoGenerateColumns = false;     
            this.dgrdvConfirm.AutoGenerateColumns = false; 
            this.ctrlQNonConfirm.SeachGridView = this.dgrdvNonConfirm; 
            this.accNotes = new JERPData.OtherRes.BuyOrderNotes(); 
            this.SetPermit();
        }
        private JERPData.OtherRes.BuyOrderNotes accNotes; 
        private FrmOrderNoteConfirmOper frmOper;
        private Report.Bill.FrmBuyOrderNote frmDetail;
        private DataTable dtblNonConfirms ,dtblConfirms;
        private string iniwhereclause = " and (ConfirmPsnID is not null)";
        private string whereclause = string.Empty;
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(483);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(484);
            if (this.enableBrowse)
            {
                this.whereclause = this.iniwhereclause;
                //加载数据
                LoadData();
                this.dgrdvNonConfirm.ContextMenuStrip = this.cMenu;
                this.dgrdvConfirm.ContextMenuStrip = this.cMenu;
                this.dtpDateBegin.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                this.dtpDateEnd.Value = this.dtpDateBegin.Value.AddMonths(1).AddDays(-1).Date;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                this.btnSearch.Click += new EventHandler(btnSearch_Click);
                this.pbar.OnPageIndexChanged += new EventHandler(pbar_OnPageIndexChanged);
            }
            this.ColumnbtnConfirm.Visible = this.enableSave;
            this.ColumnbtnCancel.Visible = this.enableSave;
            if (this.enableSave)
            {
                this.dgrdvNonConfirm.CellContentClick += new DataGridViewCellEventHandler(dgrdvNonConfirm_CellContentClick);
                this.dgrdvConfirm.CellContentClick += new DataGridViewCellEventHandler(dgrdvConfirm_CellContentClick);
            
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
            this.LoadConfirm();
        }

        void pbar_OnPageIndexChanged(object sender, EventArgs e)
        {
            int cnt = 0;
            this.dtblConfirms = this.accNotes.GetDataBuyOrderNotesDescPagesFreeSearch(this.pbar.PageIndex,
                this.pbar.PageSize, ref cnt, this.whereclause).Tables[0];
            this.dgrdvConfirm.DataSource = this.dtblConfirms;
        }
 
        void mItemRefresh_Click(object sender, EventArgs e)
        {
          
            if (this.cMenu.SourceControl == this.dgrdvNonConfirm)
            {
                this.LoadNonConfirm();
            }
          
            if (this.cMenu.SourceControl == this.dgrdvConfirm)
            {
                this.whereclause = this.iniwhereclause;
                this.LoadConfirm();
            }
        }
       
        private void LoadNonConfirm()
        { 
            this.dtblNonConfirms = this.accNotes.GetDataBuyOrderNotesNonConfirm ().Tables[0];
            this.dgrdvNonConfirm.DataSource = this.dtblNonConfirms;
        }
       
        private void LoadConfirm()
        {
            int cnt = 0;
            this.dtblConfirms = this.accNotes.GetDataBuyOrderNotesDescPagesFreeSearch(1, this.pbar.PageSize,
                ref cnt, this.whereclause).Tables[0];
            this.dgrdvConfirm.DataSource = this.dtblConfirms;
            this.pbar.Init(1, cnt);
        }
        private void LoadData()
        { 
            this.LoadNonConfirm(); 
            this.LoadConfirm();
        }


        void dgrdvNonConfirm_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvNonConfirm.Columns[icol].Name == this.ColumnbtnConfirm.Name)
            {
                long NoteID = (long)this.dtblNonConfirms.DefaultView[irow]["NoteID"];
                if (this.frmOper == null)
                {
                    this.frmOper = new FrmOrderNoteConfirmOper();
                    new FrmStyle(frmOper).SetPopFrmStyle(this);
                    frmOper.AffterSave += new FrmOrderNoteConfirmOper.AffterSaveDelegate(frmOper_AffterSave);
                }
                frmOper.ConfirmOper(NoteID);
                frmOper.ShowDialog();
            }

        }

        void frmOper_AffterSave()
        {
            this.whereclause = this.iniwhereclause;
            this.LoadData();
        }
      
 
        void dgrdvConfirm_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            long NoteID = (long)this.dtblConfirms.DefaultView[irow]["NoteID"];
            if (this.dgrdvConfirm.Columns[icol].Name == this.ColumnbtnCancel.Name)
            {
                DialogResult rut = MessageBox.Show("即将取消当前订单审核,一经取消可以变更订单内容!", "审核确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rut == DialogResult.Cancel) return;
                string errormsg = string.Empty;
                bool flag = this.accNotes.UpdateBuyOrderNotesCancelConfirm(ref errormsg,
                    NoteID);
                if (flag)
                {
                    MessageBox.Show("成功取消当前审核");
                    this.whereclause = this.iniwhereclause;
                    this.LoadData();
                }

            }
            if (this.dgrdvConfirm.Columns[icol].DataPropertyName == "NoteCode")
            {
               
                if (frmDetail == null)
                {
                    frmDetail = new JERPApp.Supply.OtherRes.Report.Bill.FrmBuyOrderNote();
                    new FrmStyle(frmDetail).SetPopFrmStyle(this);
                }
                frmDetail.Detail(NoteID);
                frmDetail.ShowDialog();
            }
        }



    
    }
}