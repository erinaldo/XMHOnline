using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Receivable
{
    public partial class FrmSaleInvoiceOper : Form
    {
        public FrmSaleInvoiceOper()
        {
            InitializeComponent();
            this.accInvoices = new JERPData.Product.SaleInvoices();
            this.accDeliverItems = new JERPData.Product.SaleDeliverItems();
            this.InvoiceEntity = new JERPBiz.Product.SaleInvoiceEntity();
            this.printhelper = new JERPBiz.Product.SaleInvoicePrintHelper();

            this.dgrdv.AutoGenerateColumns = false;       
            this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
            this.dgrdv.UserDeletedRow += new DataGridViewRowEventHandler(dgrdv_UserDeletedRow);
            this.dgrdv.MouseClick += new MouseEventHandler(dgrdv_MouseClick);
            this.dgrdv.CellValueChanged += new DataGridViewCellEventHandler(dgrdv_CellValueChanged);

            this.btnDelete.Click += new EventHandler(btnDelete_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnExport.Click += this.btnExplore_Click;
            this.FormClosed += new FormClosedEventHandler(FrmSaleInvoiceOper_FormClosed);

            foreach (DataGridViewColumn col in this.dgrdv.Columns)
            {
                col.ReadOnly = true;
            }
            this.ColumnPrice.ReadOnly = false;
          
        
        }

        private JERPData.Product.SaleInvoices accInvoices;
        private JERPData.Product.SaleDeliverItems accDeliverItems;
        private JERPBiz.Product.SaleInvoiceEntity InvoiceEntity;
        private JERPBiz.Product.SaleInvoicePrintHelper printhelper;
        private JERPApp.Define.Product.FrmSaleDeliverItemForInvoice frmSaleItem;
        private DataTable dtblDeliverItems;
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
        private void SetTotalAMT()
        {
            decimal TotalAMT = 0;
            decimal TaxAMT = 0;
            foreach (DataGridViewRow grow in this.dgrdv.Rows)
            {

                if (grow.Cells[this.ColumnItemAMT.Name].Value != DBNull.Value)
                {
                    TotalAMT += (decimal)grow.Cells[this.ColumnItemAMT.Name].Value;
                }
                if (grow.Cells[this.ColumnTaxAMT.Name].Value != DBNull.Value)
                {
                    TaxAMT += (decimal)grow.Cells[this.ColumnTaxAMT.Name].Value;
                }
            }      
            this.txtTotalAMT.Text = string.Format("{0:0.####}", TotalAMT);
            this.txtTaxAMT.Text = string.Format("{0:0.####}", TaxAMT);
            string errormsg=string .Empty ;
            this.accInvoices.UpdateSaleInvoicesForTotalAMT (ref errormsg,
                this.InvoiceID,
                TotalAMT,
                TaxAMT);
        }
        private void SetRemind()
        {
            int cnt = 0;
            this.accDeliverItems.GetParmSaleDeliverItemsCountForInvoice(this.InvoiceID, ref cnt);
            this.pageSale.Text = "送货明细[" + cnt.ToString()+"]";

        }
        public void Edit(long InvoiceID)
        {
            this.InvoiceID = InvoiceID;
            this.InvoiceEntity.LoadData(InvoiceID);
            this.txtInvoiceCode.Text = this.InvoiceEntity.InvoiceCode;
            this.txtInvoiceName.Text = this.InvoiceEntity.InvoiceName;
            this.txtDateNote.Text = this.InvoiceEntity.DateNote.ToShortDateString();            
            this.txtCompanyAbbName.Text = this.InvoiceEntity.CompanyAbbName;
            this.txtFinanceAddress.Text = this.InvoiceEntity.FinanceAddress;
            this.txtMoneyTypeName.Text = this.InvoiceEntity.MoneyTypeName;
            this.txtInvoiceTypeName.Text = this.InvoiceEntity.InvoiceTypeName;
            this.txtTotalAMT.Text = string.Format("{0:0.####}", this.InvoiceEntity.TotalAMT);
            this.txtTaxAMT.Text = string.Format("{0:0.####}", this.InvoiceEntity.TaxAMT);
            this.txtYear.Text = this.InvoiceEntity.Year.ToString();
            this.txtMonth.Text = this.InvoiceEntity.Month.ToString();
          
            this.LoadSaleItems();
            this.SetRemind();
        }
        private void LoadSaleItems()
        {
            this.dtblDeliverItems = this.accDeliverItems.GetDataSaleDeliverItemsByInvoiceID(this.InvoiceID).Tables[0];
            this.dgrdv.DataSource = this.dtblDeliverItems;
          
        }
        void dgrdv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnPrice.Name)
            {
                long ItemID = (long)this.dtblDeliverItems.DefaultView[irow]["ItemID"];
                object objPrice = this.dgrdv[icol, irow].Value;
                if (objPrice != DBNull.Value)
                {
                    this.dgrdv[this.ColumnItemAMT.Name, irow].Value = (decimal)this.dgrdv[this.ColumnQuantity .Name, irow].Value * (decimal)objPrice;
                    this.dgrdv[this.ColumnTaxAMT.Name, irow].Value = (decimal)this.dgrdv[this.ColumnItemAMT.Name, irow].Value * (decimal)this.dgrdv[this.ColumnTaxRate.Name, irow].Value;
                }
                else
                {
                    this.dgrdv[this.ColumnItemAMT.Name, irow].Value = DBNull.Value;
                    this.dgrdv[this.ColumnTaxAMT.Name, irow].Value = DBNull.Value;
                }
                string errormsg = string.Empty;
                this.accDeliverItems .UpdateSaleDeliverItemsForPrice (ref errormsg,
                    ItemID, objPrice);
                this.SetTotalAMT();
            }
        }
        void dgrdv_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            this.SetTotalAMT();
            this.SetRemind();            
        }  
        void dgrdv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            object objItemID = this.dtblDeliverItems.DefaultView[irow]["ItemID"];
            if (objItemID == DBNull.Value)
            {
                return;
            }
            string errormsg = string.Empty;
            bool flag = this.accDeliverItems .UpdateSaleDeliverItemsCancelInvoice (
                ref errormsg, objItemID);
            if (!flag)
            {
               
                MessageBox.Show(errormsg);
                e.Cancel = true;
            }
        }
        void dgrdv_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (frmSaleItem == null)
                {
                    frmSaleItem = new JERPApp.Define.Product.FrmSaleDeliverItemForInvoice();
                    new FrmStyle(frmSaleItem).SetPopFrmStyle(this);
                    frmSaleItem.AffterEnter += frmSaleItem_AffterEnter;
                }
                frmSaleItem.InvoiceItem(this.InvoiceID, this.InvoiceEntity.Year, this.InvoiceEntity.Month);
                frmSaleItem.ShowDialog();
            }
        }
        void frmSaleItem_AffterEnter()
        {
            this.LoadSaleItems();
            this.SetTotalAMT();
            this.SetRemind();
        }

      
        void btnSave_Click(object sender, EventArgs e)
        {
            string errormsg = string.Empty;
            bool flag = false;
            flag = this.accInvoices.UpdateSaleInvoices(ref errormsg,
                this.InvoiceID,
                this.txtInvoiceName .Text ,
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
                flag = this.accInvoices.DeleteSaleInvoices(ref errormsg, this.InvoiceID);
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
        void btnExplore_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            this.printhelper.ExportToExcel(new long[] { this.InvoiceID });
            FrmMsg.Hide();
        }
        void FrmSaleInvoiceOper_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.InvoiceID > -1)
            {
               if (this.affterSave != null) this.affterSave();

            }
        }
    }
}