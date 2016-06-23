using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Payable.OutSrc
{
    public partial class FrmLossSupplyInvoiceOper : Form
    {
        public FrmLossSupplyInvoiceOper()
        {
            InitializeComponent();
            this.accInvoices = new JERPData.Material.OutSrcLossSupplyInvoices();
            this.accSupplyItems = new JERPData.Material.OutSrcLossSupplyItems();
            this.InvoiceEntity = new JERPBiz.Material.OutSrcLossSupplyInvoiceEntity();
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

       
     
        private JERPData.Material .OutSrcLossSupplyInvoices  accInvoices;
        private JERPData.Material .OutSrcLossSupplyItems  accSupplyItems;
        private JERPBiz.Material .OutSrcLossSupplyInvoiceEntity InvoiceEntity;
        private JERPApp.Define.Material.FrmOutSrcLossSupplyItemForInvoice   frmInvoiceItem;
        private FrmLossSupplyInvoiceNew frmNew;
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
            this.SaveTotalAMT();
            this.SetRemind();
        }
        private void SetRemind()
        {
            int cnt = 0;
            this.accSupplyItems.GetParmOutSrcLossSupplyItemsCountForInvoice (this.InvoiceID, ref cnt);
            this.pageDeliver.Text = "超发料:" + cnt.ToString();
        }
        private void SetTotalAMT()
        {
            decimal TotalAMT = 0; 
            foreach(DataGridViewRow grow in this.dgrdv .Rows )
            { 
                if (grow.Cells[this.ColumnItemAMT.Name].Value == DBNull.Value) continue;
                TotalAMT += (decimal)grow.Cells[this.ColumnItemAMT.Name].Value; 
            }
            this.txtTotalAMT.Text = string.Format("{0:0.####}", TotalAMT); 
         
        }
        public void SaveTotalAMT()
        {
            string errormsg = string.Empty;
            decimal TotalAMT;
            if(!decimal .TryParse (this.txtTotalAMT .Text ,out TotalAMT ))
            {
                TotalAMT = 0;
            }
            this.accInvoices.UpdateOutSrcLossSupplyInvoicesForTotalAMT(ref errormsg,
                this.InvoiceID,
                TotalAMT);
        }
        public void New()
        {
            this.InvoiceID = -1;
            this.txtCompanyAbbName.Text = string.Empty;
            this.txtInvoiceCode.Text = string.Empty;
            this.txtInvoiceName.Text = string.Empty; 
            this.txtMoneyTypeName.Text = string.Empty;
            this.txtMonth.Text = string.Empty; 
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
            this.txtMoneyTypeName.Text = this.InvoiceEntity.MoneyTypeName;
            this.txtTotalAMT.Text = string.Format("{0:0.####}", this.InvoiceEntity.TotalAMT); 
            this.txtYear.Text = this.InvoiceEntity.Year.ToString();
            this.txtMonth.Text = this.InvoiceEntity.Month.ToString();
            this.dtpDateNote.Value = this.InvoiceEntity.DateNote;
            this.LoadItems();
            this.SetRemind();
        }
        private void LoadItems()
        {
            this.dtblItems = this.accSupplyItems.GetDataOutSrcLossSupplyItemsByInvoiceID(this.InvoiceID).Tables[0];
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
                    this.dgrdv[this.ColumnItemAMT.Name, irow].Value = (decimal)this.dgrdv[this.ColumnQuantity .Name, irow].Value * (decimal)objPrice;
                   
                }
                else
                {
                    this.dgrdv[this.ColumnItemAMT.Name, irow].Value = DBNull.Value; 
                } 
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
            bool flag = this.accSupplyItems.UpdateOutSrcLossSupplyItemsCancelInvoice  (
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
                frmNew = new FrmLossSupplyInvoiceNew();
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
            else
            {
                if (this.InvoiceEntity.ConfirmPsnID > -1)
                {
                    MessageBox.Show("此发票已审核不能变更");
                    this.Close();
                }
            }
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            string errormsg = string.Empty;
            bool flag = false;
            flag = this.accInvoices.UpdateOutSrcLossSupplyInvoices   (ref errormsg,
                this.InvoiceID,
                this.txtInvoiceCode .Text ,
                this.txtInvoiceName .Text ,
                this.dtpDateNote .Value .Date ,
                this.txtTotalAMT .Text , 
                 JERPBiz.Frame.UserBiz.PsnID);
            if (flag)
            {
                MessageBox.Show("成功保存！");
                foreach (DataRow drow in this.dtblItems.Rows)
                {
                    if (drow.RowState == DataRowState.Deleted) continue;
                    if (drow.RowState == DataRowState.Unchanged) continue; 
                    this.accSupplyItems.UpdateOutSrcLossSupplyItemsForPrice(ref errormsg,
                        drow["ItemID"], drow["Price"]);
                    drow.AcceptChanges();
                }
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
                flag = this.accInvoices.DeleteOutSrcLossSupplyInvoices (ref errormsg, this.InvoiceID);
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
                    frmInvoiceItem = new JERPApp.Define.Material.FrmOutSrcLossSupplyItemForInvoice();
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
            this.SaveTotalAMT();
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