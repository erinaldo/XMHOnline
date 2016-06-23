using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Report
{
    public partial class FrmPayableReceipt : Form
    {
        public FrmPayableReceipt()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accOutSrcReceipt = new JERPData.Manufacture.OutSrcReceiptNotes();
            this.accPrdReceipt = new JERPData.Product.BuyReceiptNotes();
            this.accMtrReceipt = new JERPData.Material.BuyReceiptNotes();
            this.accOtherResReceipt = new JERPData.OtherRes.BuyReceiptNotes(); 
            this.accToolReceipt = new JERPData.Tool.BuyReceiptNotes();
            this.SetPermit();
        }
        private JERPData.Manufacture.OutSrcReceiptNotes accOutSrcReceipt;
        private JERPData.Material.BuyReceiptNotes accMtrReceipt;
        private JERPData.OtherRes.BuyReceiptNotes accOtherResReceipt; 
        private JERPData.Product.BuyReceiptNotes accPrdReceipt;
        private JERPData.Tool.BuyReceiptNotes accToolReceipt;
        private Bill.Manufacture.FrmOutSrcReceiptNote frmOutSrcDetail;
        private Bill.Material.FrmBuyReceiptNote frmMtrDetail;
        private Bill.OtherRes.FrmBuyReceiptNote frmOtherResDetail; 
        private Bill.Product.FrmBuyReceiptNote frmPrdDetail;
        private Bill.Tool.FrmBuyReceiptNote frmToolDetail;
        private int iOutSrc = 0, iMtr = 1, iOtherRes = 2,   iPrd = 3, iTool = 4;
        private DataTable dtblReceiptNotes;
        private string whereclause = string.Empty;
        private bool enableBrowse = false;//浏览
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(743);          
            if (this.enableBrowse)
            {
                DataTable dtblType = new DataTable();
                dtblType.Columns.Add("TypeID", typeof(int));
                dtblType.Columns.Add("TypeName", typeof(string));
                dtblType.Rows.Add(iOutSrc, "委外加工");
                dtblType.Rows.Add(iMtr, "原料采购");
                dtblType.Rows.Add(iOtherRes, "耗材采购"); 
                dtblType.Rows.Add(iPrd, "产品采购");
                dtblType.Rows.Add(iTool, "治具采购");
                this.cmbPayableType.DataSource = dtblType;
                this.cmbPayableType.ValueMember = "TypeID";
                this.cmbPayableType.DisplayMember = "TypeName";
                this.cmbPayableType.SelectedIndex = 0;
                this.btnSearch.Click += new EventHandler(btnSearch_Click);
                this.dtpDateBegin.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                this.dtpDateEnd.Value = this.dtpDateBegin.Value.AddMonths(1).AddDays(-1);
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
                this.pbar.OnPageIndexChanged += new EventHandler(pbar_OnPageIndexChanged);
                this.LoadData();
            }
          
        }
        private void ShowDetail(long NoteID)
        {
            int TypeID = (int)this.cmbPayableType.SelectedValue;
            if (TypeID == iOutSrc)
            {
                if (frmOutSrcDetail == null)
                {
                    frmOutSrcDetail = new JERPApp.Finance.Report.Bill.Manufacture.FrmOutSrcReceiptNote();
                    new FrmStyle(frmOutSrcDetail).SetPopFrmStyle(this);
                }
                frmOutSrcDetail.Detail(NoteID);
                frmOutSrcDetail.ShowDialog();
            }
            if (TypeID == iMtr)
            {
                if (frmMtrDetail == null)
                {
                    frmMtrDetail = new JERPApp.Finance.Report.Bill.Material.FrmBuyReceiptNote();
                    new FrmStyle(frmMtrDetail).SetPopFrmStyle(this);
                }
                frmMtrDetail.Detail(NoteID);
                frmMtrDetail.ShowDialog();
            }
            if (TypeID == iOtherRes)
            {
                if (frmOtherResDetail == null)
                {
                    frmOtherResDetail = new JERPApp.Finance.Report.Bill.OtherRes.FrmBuyReceiptNote();
                    new FrmStyle(frmOtherResDetail).SetPopFrmStyle(this);
                }
                frmOtherResDetail.Detail(NoteID);
                frmOtherResDetail.ShowDialog();
            }
             
            if (TypeID == iPrd)
            {
                if (frmPrdDetail == null)
                {
                    frmPrdDetail = new JERPApp.Finance.Report.Bill.Product.FrmBuyReceiptNote();
                    new FrmStyle(frmPrdDetail).SetPopFrmStyle(this);
                }
                frmPrdDetail.Detail(NoteID);
                frmPrdDetail.ShowDialog();
            }
            if (TypeID == iTool)
            {
                if (frmToolDetail == null)
                {
                    frmToolDetail = new JERPApp.Finance.Report.Bill.Tool.FrmBuyReceiptNote();
                    new FrmStyle(frmToolDetail).SetPopFrmStyle(this);
                }
                frmToolDetail.Detail(NoteID);
                frmToolDetail.ShowDialog();
            }
        }

        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnNoteCode.Name)
            {
                long NoteID = (long)this.dtblReceiptNotes.DefaultView[irow]["NoteID"];
                this.ShowDetail(NoteID);
               
            }
        }
        private void BindData(int pageIndex, ref int cnt)
        {
            int TypeID = (int)this.cmbPayableType.SelectedValue;
            if (TypeID == iOutSrc)
            {
                this.dtblReceiptNotes = this.accOutSrcReceipt .GetDataOutSrcReceiptNotesDescPagesFreeSearch(
                    pageIndex,
                    this.pbar.PageSize,
                    ref cnt,
                    this.whereclause).Tables[0];
            }
            if (TypeID == iMtr)
            {
                this.dtblReceiptNotes = this.accMtrReceipt.GetDataBuyReceiptNotesDescPagesFreeSearch(
                   pageIndex,
                   this.pbar.PageSize,
                   ref cnt,
                   this.whereclause).Tables[0];
            }
            if (TypeID == iOtherRes)
            {
                this.dtblReceiptNotes = this.accOtherResReceipt.GetDataBuyReceiptNotesDescPagesFreeSearch(
                   pageIndex,
                   this.pbar.PageSize,
                   ref cnt,
                   this.whereclause).Tables[0];
            } 
            if (TypeID == iPrd)
            {
                this.dtblReceiptNotes = this.accPrdReceipt.GetDataBuyReceiptNotesDescPagesFreeSearch(pageIndex,
                             this.pbar.PageSize, ref cnt,
                             this.whereclause).Tables[0];
            }
            if (TypeID == iTool)
            {
                this.dtblReceiptNotes = this.accToolReceipt.GetDataBuyReceiptNotesDescPagesFreeSearch(pageIndex,
                             this.pbar.PageSize, ref cnt,
                             this.whereclause).Tables[0];
            }
            this.dgrdv.DataSource = this.dtblReceiptNotes;
        }
        private void LoadData()
        {
            int cnt=0;
            this.BindData(1, ref cnt);
            this.pbar.Init(1, cnt);
        }
        void pbar_OnPageIndexChanged(object sender, EventArgs e)
        {
            int cnt = 0;
            this.BindData(this.pbar.PageIndex, ref cnt);
        }
        void btnSearch_Click(object sender, EventArgs e)
        {

            this.whereclause =string.Empty;
           
            if (this.ckbNoteCodeFlag.Checked)
            {
                this.whereclause += " and (NoteCode like '%" + this.txtNoteCode.Text + "%')";
            }
            if (this.ckbPONo.Checked)
            {
                this.whereclause += " and (PONo like '%" + this.txtPONo.Text + "%')";
            }
            if (this.ckbSaleDeliverNoteFlag.Checked)
            {
                this.whereclause += " and (ReceiveNoteCode like '%" + this.txtSaleDeliverNoteCode.Text + "%')";
            }
          
            if (this.ckbReconciliationCodeFlag.Checked)
            {
                this.whereclause += " and (ReconciliationCode like '%" + this.txtReconciliationCode.Text + "%')";
            }
            if (this.ckbSupplierFlag.Checked)
            {
                this.whereclause += " and (CompanyID=" + this.ctrlSupplierID.CompanyID.ToString() + ")";
            }          
            if (this.ckbDateNoteFlag.Checked)
            {
                this.whereclause += " and (DateNote>='" + this.dtpDateBegin.Value.ToShortDateString()
                    + "' and DateNote<='" + this.dtpDateEnd.Value.ToShortDateString() + "')";
            }
            this.LoadData();
        }
    }
}