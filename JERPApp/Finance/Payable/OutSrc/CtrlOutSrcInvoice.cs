using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Payable.OutSrc
{
    public partial class CtrlOutSrcInvoice : UserControl 
    {
        public CtrlOutSrcInvoice()
        {
            InitializeComponent();

            this.dgrdvInvoice.AutoGenerateColumns = false;
            this.ctrlQInvoice.SeachGridView = this.dgrdvInvoice;
            this.dgrdvNonInvoice.AutoGenerateColumns = false;
            this.accInvoices = new JERPData.Manufacture.OutSrcInvoices();
            this.accReceiveItems = new JERPData.Manufacture.OutSrcReceiveItems();
            this.dgrdvInvoice.ContextMenuStrip = this.cMenu;
            this.dgrdvNonInvoice.ContextMenuStrip = this.cMenu;
            this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
            this.lnkNew.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkNew_LinkClicked);
            this.dgrdvInvoice.CellContentClick += new DataGridViewCellEventHandler(dgrdvInvoice_CellContentClick);
        }
        private JERPData.Manufacture.OutSrcInvoices accInvoices;
        private JERPData.Manufacture.OutSrcReceiveItems accReceiveItems;
        private DataTable  dtblNonInvoices,dtblInvoices;
        
        private FrmOutSrcInvoiceOper frmOper;
        public delegate void AffterRefreshDelegate(int count);
        private AffterRefreshDelegate affterRefresh;
        public event AffterRefreshDelegate AffterRefresh
        {
            add
            {
                affterRefresh += value;
            }
            remove
            {
                affterRefresh -= value;
            }
        } 
        public void LoadData()
        {
            this.LoadNonInvoice();
            this.LoadInvoice();
        }
        private void LoadNonInvoice()
        {
            while (this.dgrdvNonInvoice .ColumnCount > 3)
            {
                this.dgrdvNonInvoice.Columns.RemoveAt(3);
            }
            this.dtblNonInvoices = this.accReceiveItems.GetDataOutSrcReceiveItemsNonInvoicePivotMonthAMT().Tables[0];
       
            DataGridViewTextBoxColumn txt;
            string columnname;
            for (int j = 3; j < this.dtblNonInvoices .Columns.Count; j++)
            {
                columnname = this.dtblNonInvoices.Columns[j].ColumnName;
                txt = new DataGridViewTextBoxColumn();
                txt.DataPropertyName = columnname;
                txt.HeaderText = columnname;
                txt.Width = 70;
                this.dgrdvNonInvoice.Columns.Add(txt);
            }
            this.dgrdvNonInvoice.DataSource = this.dtblNonInvoices;
            this.ctrlQNonInvoice.SeachGridView = this.dgrdvNonInvoice; 
            if (this.affterRefresh != null) this.affterRefresh(this.dtblNonInvoices.Rows.Count);
        }
        private void LoadInvoice()
        {
            this.dtblInvoices = this.accInvoices.GetDataOutSrcInvoicesNonConfirm().Tables[0];
            this.dgrdvInvoice.DataSource = this.dtblInvoices; 
        }
           
        void mItemRefresh_Click(object sender, EventArgs e)
        {
            if (this.cMenu.SourceControl == this.dgrdvNonInvoice)
            {
                this.LoadNonInvoice();
            }
            if (this.cMenu.SourceControl == this.dgrdvInvoice)
            {
                this.LoadInvoice();
            }
        }
        void lnkNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.frmOper == null)
            {
                this.frmOper = new FrmOutSrcInvoiceOper();
                new FrmStyle(this.frmOper).SetPopFrmStyle(this.ParentForm );
                this.frmOper.AffterSave += this.LoadData;
            }
            this.frmOper.New();
            this.frmOper.ShowDialog();
        }
      
    
        void dgrdvInvoice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;          
            if (this.dgrdvInvoice.Columns[icol].Name == this.ColumnBtnEdit.Name)
            {
                long InvoiceID = (long)this.dtblInvoices.DefaultView[irow]["InvoiceID"];
                if (this.frmOper == null)
                {
                    this.frmOper = new FrmOutSrcInvoiceOper();
                    new FrmStyle(this.frmOper).SetPopFrmStyle(this.ParentForm);
                    this.frmOper.AffterSave += this.LoadData;
                }
                this.frmOper.Edit(InvoiceID);
                this.frmOper.ShowDialog();
            }
        }
    }
}