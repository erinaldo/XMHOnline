using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Dispatcher
{
    public partial class FrmFromRepairDeliverNote : Form
    {
        public FrmFromRepairDeliverNote()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accNotes = new JERPData.Product.RepairDeliverNotes();
            this.accReplaceExpress = new JERPData.Product.SaleReplaceExpressAMTRecord(); 
            this.accReceivableAccount = new JERPData.Finance.ReceivableAccount();
            this.MoneyTypeParm = new JERPBiz.Finance.MoneyTypeParm();
            this.dtpDateBegin.Value = DateTime.Now.AddDays(-1).Date;
            this.dtpDateEnd.Value = DateTime.Now.AddDays(1).Date;
            this.pbar.OnPageIndexChanged += new EventHandler(pbar_OnPageIndexChanged);
            this.btnSearch.Click += new EventHandler(btnSearch_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            for (int j = 1; j < this.dgrdv.ColumnCount; j++)
            {
                this.dgrdv.Columns[j].ReadOnly = true;
            }
            this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
        }

        private JERPData.Product.RepairDeliverNotes accNotes;  
        private JERPData.Product.SaleReplaceExpressAMTRecord accReplaceExpress;
        private JERPData.Finance.ReceivableAccount accReceivableAccount;
        private JERPBiz.Finance.MoneyTypeParm MoneyTypeParm;
        private DataTable dtblNotes;
        private FrmPostageNoteOper frmOper;
        private JERPApp.Store .Product.Report.Bill.FrmRepairDeliverNote  frmDetail;
        private string iniwhereclause = " and (ExpressCode is null)";
        private string whereclause = " and (ExpressCode is null)";
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
            this.whereclause = this.iniwhereclause ;
            if (this.ckbNoteCodeFlag.Checked)
            {
                this.whereclause += " and (NoteCode like '%" + this.txtNoteCode.Text + "%')";
            }
            if (this.ckbCustomerFlag.Checked)
            {
                this.whereclause += " and (CompanyID=" + this.ctrlCustomerID.CompanyID.ToString() + ")";
            }
            if (this.ckbDateNoteFlag.Checked)
            {
                this.whereclause += " and (DateNote>=' " + this.dtpDateBegin.Value.ToShortDateString() + "' and " +
                    "DateNote<='" + this.dtpDateEnd.Value.ToShortDateString() + "'";
            }
            this.LoadData();
        } 
        void pbar_OnPageIndexChanged(object sender, EventArgs e)
        {
            int cnt = 0;
            this.dtblNotes = this.accNotes.GetDataRepairDeliverNotesDescPagesFreeSearch(this.pbar .PageIndex, this.pbar.PageSize, ref cnt, this.whereclause).Tables[0];
            this.dtblNotes.Columns.Add("CheckedFlag", typeof(bool)); 
            this.dgrdv.DataSource = this.dtblNotes;
        } 
        public  void LoadData()
        {
            int cnt = 0;
            this.dtblNotes = this.accNotes.GetDataRepairDeliverNotesDescPagesFreeSearch (1,this.pbar.PageSize ,ref cnt,this.whereclause).Tables[0];
            this.dtblNotes.Columns.Add("CheckedFlag", typeof(bool));
            this.dgrdv.DataSource = this.dtblNotes;
            this.pbar.Init(1, cnt);
        }
        private bool ValidateData()
        {
            if (this.txtReplaceExpressAMT.Text != string.Empty)
            {
                decimal d;
                if (!decimal.TryParse(this.txtReplaceExpressAMT.Text, out d)
                    || (d < 0))
                {
                    MessageBox.Show("对不起，代付运费输入有误");
                    return false;
                }
            }

            DataRow[] drows = this.dtblNotes.Select("CheckedFlag=1");
            if (drows.Length == 0)
            {
                MessageBox.Show("未选择任何送货单");
                return false;
            }
            int lastcompanyid = (int)drows[0]["CompanyID"];
            for (int i = 1; i < drows.Length; i++)
            {
                if (lastcompanyid != (int)drows[i]["CompanyID"])
                {
                    MessageBox.Show("对不起，选择的客户必须一致");
                    return false;
                }
            }
            return true;
        }
        void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateData() == false) return;
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
            DataRow[] drows = this.dtblNotes.Select("CheckedFlag=1");
            int CompanyID = (int)drows[0]["CompanyID"];
            string Memo = "维修送货单:";
            string errormsg = string.Empty;
            foreach (DataRow drow in drows)
            {
                this.accNotes.UpdateRepairDeliverNotesForExpress (
                    ref errormsg,
                    drow["NoteID"],
                    ExpressCompanyID,
                    ExpressCode);

                Memo += drow["NoteCode"].ToString() + ";";
            }
            if (this.txtReplaceExpressAMT.Text != string.Empty)
            {
                //代付运费
                decimal ReplaceAMT = decimal.Parse(this.txtReplaceExpressAMT.Text);
                if (ReplaceAMT > 0)
                {
                    object objRecordID = -1;
                    this.accReplaceExpress.InsertSaleReplaceExpressAMTRecord(
                        ref errormsg,
                        ref objRecordID,
                        CompanyID,
                        ExpressNoteID ,
                        ReplaceAMT,
                        Memo);
                    //应收账款
                    this.accReceivableAccount.InsertReceivableAccountForDebit(
                        ref errormsg,
                        "代付运费",
                        CompanyID,
                        this.MoneyTypeParm.GetMainMoneyTypeID(),
                        ReplaceAMT,
                        JERPBiz.Frame.UserBiz.PsnID);
                }
            }
            if (this.affterSave != null) this.affterSave();
            this.txtReplaceExpressAMT.Text = string.Empty;
            MessageBox.Show("成功进行快递设置");
            this.LoadData();
            this.frmOper.Close();
        }
        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnNoteCode.Name)
            {
                long NoteID = (long)this.dtblNotes.DefaultView[irow]["NoteID"];
                if (frmDetail == null)
                {
                    frmDetail = new JERPApp.Store.Product.Report.Bill.FrmRepairDeliverNote ();
                    new FrmStyle(frmDetail).SetPopFrmStyle(this);
                }
                frmDetail.DetailNote(NoteID);
                frmDetail.ShowDialog();
            }
        }
    }
}