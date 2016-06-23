using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Payable.OtherRes
{
    public partial class FrmInvoiceOper : Form
    {
        public FrmInvoiceOper()
        {
            InitializeComponent();
            this.accInvoices = new JERPData.OtherRes.BuyInvoices();
            this.accReceiveItems = new JERPData.OtherRes.BuyReceiveItems();
            this.InvoiceEntity = new JERPBiz.OtherRes.BuyInvoiceEntity();
            this.dgrdv.AutoGenerateColumns = false;       
            this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
            this.dgrdv.UserDeletedRow += new DataGridViewRowEventHandler(dgrdv_UserDeletedRow);
            this.dgrdv.MouseClick += new MouseEventHandler(dgrdv_MouseClick);
            this.btnDelete.Click += new EventHandler(btnDelete_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.Shown += new EventHandler(FrmInvoiceOper_Shown);
            this.btnNew.Click += new EventHandler(btnNew_Click);
            this.FormClosed += new FormClosedEventHandler(FrmInvoiceOper_FormClosed);
            foreach (DataGridViewColumn col in this.dgrdv.Columns)
            {
                col.ReadOnly = true;
            }
            this.ColumnPrice.ReadOnly = false;
            this.dgrdv.CellValueChanged += new DataGridViewCellEventHandler(dgrdv_CellValueChanged);
        }

       
     
        private JERPData.OtherRes.BuyInvoices accInvoices;
        private JERPData.OtherRes.BuyReceiveItems accReceiveItems;
        private JERPBiz.OtherRes.BuyInvoiceEntity InvoiceEntity;
        private JERPApp.Define.OtherRes.FrmBuyReceiveItemForInvoice  frmInvoiceItem;
        private FrmInvoiceNew frmNew;
        private DataTable dtblItems;
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

        private long invoiceID = -1;
        private long InvoiceID
        {
            get
            {
                return this.invoiceID;
            }
            set
            {
                this.invoiceID = value;
                this.btnDelete.Enabled = (value > -1);
                this.btnSave.Enabled = (value > -1);
            }
        }

        void dgrdv_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            this.SetTotalAMT();
            this.SetRemind();
        }
        private void SetRemind()
        {
            int cnt = 0;
            this.accReceiveItems.GetParmBuyReceiveItemsCountForInvoice(this.InvoiceID, ref cnt);
            this.pageDeliver.Text = "送货:" + cnt.ToString();
        }
        private void SetTotalAMT()
        {
            decimal TotalAMT = 0;
            decimal TaxAMT = 0;
            foreach(DataGridViewRow grow in this.dgrdv .Rows )
            {
               
                if (grow.Cells[this.ColumnItemAMT.Name].Value == DBNull.Value) continue;
                TotalAMT += (decimal)grow.Cells[this.ColumnItemAMT.Name].Value;
                TaxAMT += (decimal)grow.Cells[this.ColumnTaxAMT.Name].Value;
            }
            this.txtTotalAMT.Text = string.Format("{0:0.####}", TotalAMT);
            this.txtTaxAMT.Text = string.Format("{0:0.####}", TaxAMT);
            string errormsg=string .Empty ;
            this.accInvoices.UpdateBuyInvoicesForTotalAMT (ref errormsg,
                this.InvoiceID,
                TotalAMT,
                TaxAMT);
        }
        public void New()
        {
            this.InvoiceID = -1;
            this.txtCompanyAbbName.Text = string.Empty;
            this.txtInvoiceCode.Text = string.Empty;
            this.txtInvoiceName.Text = string.Empty;
            this.txtInvoiceTypeName.Text = string.Empty;
            this.txtMoneyTypeName.Text = string.Empty;
            this.txtMonth.Text = string.Empty;
            this.txtTaxAMT.Text = string.Empty;
            this.txtTotalAMT.Text = string.Empty;
            this.txtYear.Text = string.Empty;
            this.dtpDateNote.Value = DateTime.Now.Date;
            this.LoadItems();
            this.SetRemind();
        }
    
        public void Edit(long InvoiceID)
        {
            this.InvoiceID = InvoiceID;
            this.InvoiceEntity.LoadData(InvoiceID);
            this.txtInvoiceCode.Text = this.InvoiceEntity.InvoiceCode;
            this.txtInvoiceName.Text = this.InvoiceEntity.InvoiceName;              
            this.txtCompanyAbbName.Text = this.InvoiceEntity.CompanyAbbName;
            this.txtInvoiceTypeName.Text = this.InvoiceEntity.InvoiceTypeName;
            this.txtMoneyTypeName.Text = this.InvoiceEntity.MoneyTypeName;
            this.txtTotalAMT.Text = string.Format("{0:0.####}", this.InvoiceEntity.TotalAMT);
            this.txtTaxAMT.Text = string.Format("{0:0.####}", this.InvoiceEntity.TaxAMT);
            this.txtYear.Text = this.InvoiceEntity.Year.ToString();
            this.txtMonth.Text = this.InvoiceEntity.Month.ToString();
            this.dtpDateNote.Value = this.InvoiceEntity.DateNote;
            this.LoadItems();
            this.SetRemind();
        }
        private void LoadItems()
        {
            this.dtblItems = this.accReceiveItems.GetDataBuyReceiveItemsByInvoiceID(this.InvoiceID).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
          
        }
        void dgrdv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnPrice.Name)
            {
                long ItemID = (long)this.dtblItems.DefaultView[irow]["ItemID"];
                object objPrice = this.dgrdv[icol, irow].Value;
                if (objPrice != DBNull.Value)
                {
                    this.dgrdv[this.ColumnItemAMT.Name, irow].Value = (decimal)this.dgrdv[this.ColumnQuantity.Name, irow].Value * (decimal)objPrice;
                    this.dgrdv[this.ColumnTaxAMT.Name, irow].Value = (decimal)this.dgrdv[this.ColumnItemAMT.Name, irow].Value * (decimal)this.dgrdv[this.ColumnTaxRate.Name, irow].Value;
                }
                else
                {
                    this.dgrdv[this.ColumnItemAMT.Name, irow].Value = DBNull.Value;
                    this.dgrdv[this.ColumnTaxAMT.Name, irow].Value = DBNull.Value;
                }
                string errormsg=string.Empty;
                this.accReceiveItems.UpdateBuyReceiveItemsForPrice(ref errormsg,
                    ItemID, objPrice);
                this.SetTotalAMT();
            }
        }

        void dgrdv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            object objItemID = this.dtblItems.DefaultView[irow]["ItemID"];
            if (objItemID == DBNull.Value)
            {
                return;
            }
            string errormsg = string.Empty;
            bool flag = this.accReceiveItems .UpdateBuyReceiveItemsCancelInvoice (
                ref errormsg, objItemID);
            if (!flag)
            {
               
                MessageBox.Show(errormsg);
                e.Cancel = true;
            }
        }
        private void ShowNewFrm()
        {
            if (frmNew == null)
            {
                frmNew = new FrmInvoiceNew();
                new FrmStyle(frmNew).SetPopFrmStyle(this);
                frmNew.AffterSave += this.Edit;
            }
            frmNew.New();
            frmNew.ShowDialog();
        }

       
        void btnNew_Click(object sender, EventArgs e)
        {
            this.New();
            this.ShowNewFrm();
        }

    
        void FrmInvoiceOper_Shown(object sender, EventArgs e)
        {
            if (this.InvoiceID == -1)
            {
                this.ShowNewFrm();
            }
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            string errormsg = string.Empty;
            bool flag = false;
            flag = this.accInvoices.UpdateBuyInvoices  (ref errormsg,
                this.InvoiceID,
                this.txtInvoiceCode .Text ,
                this.txtInvoiceName .Text ,
                this.dtpDateNote .Value .Date ,
                this.txtTotalAMT .Text ,
                this.txtTaxAMT .Text ,
                 JERPBiz.Frame.UserBiz.PsnID);
            if (flag)
            {
                MessageBox.Show("成功保存！");
               
            }
            else
            {
                MessageBox.Show(errormsg);
            }
          
        }
        void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult rut = MessageBox.Show("你将删除当前发票及明细，你的删除将不能恢复，确认否?", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rut == DialogResult.Yes)
            {
                string errormsg = string.Empty;
                bool flag = false;
                flag = this.accInvoices.DeleteBuyInvoices(ref errormsg, this.InvoiceID);
                if (flag)
                {
                    MessageBox.Show("删除当前发票及明细！");
                }
                else
                {
                    MessageBox.Show(errormsg);
                }
              
                this.Close();
            }
        }
            
        void dgrdv_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.InvoiceID == -1) return;
            if (e.Button == MouseButtons.Right)
            {
                if (frmInvoiceItem == null)
                {
                    frmInvoiceItem = new JERPApp.Define.OtherRes.FrmBuyReceiveItemForInvoice();
                    new FrmStyle(frmInvoiceItem).SetPopFrmStyle(this);
                    frmInvoiceItem.AffterEnter += frmInvoiceItem_AffterEnter;
                }
                frmInvoiceItem.InvoiceItem(this.InvoiceID, this.InvoiceEntity.Year, this.InvoiceEntity.Month);
                frmInvoiceItem.ShowDialog();
            }
        }
        void frmInvoiceItem_AffterEnter()
        {
            this.LoadItems();
            this.SetTotalAMT();
            this.SetRemind();
        }
        void FrmInvoiceOper_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.InvoiceID > -1)
            {
               if (this.affterSave != null) this.affterSave();

            }
        }
    }
}