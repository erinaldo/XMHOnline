using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Payable.OtherRes
{
    public partial class FrmInvoice : Form
    {
        public FrmInvoice()
        {
            InitializeComponent();

            this.dgrdvInvoice.AutoGenerateColumns = false;
            this.ctrlQInvoice.SeachGridView = this.dgrdvInvoice;
            this.dgrdvNonInvoice.AutoGenerateColumns = false;
            this.accInvoices = new JERPData.OtherRes.BuyInvoices();
            this.accReceiveItems = new JERPData.OtherRes.BuyReceiveItems();
            this.SetPermit();
        }
        private JERPData.OtherRes.BuyInvoices accInvoices;
        private JERPData.OtherRes.BuyReceiveItems accReceiveItems;
        private DataTable  dtblNonInvoices,dtblInvoices;
        private FrmInvoiceOper frmOper;
        //È¨ÏÞÂë
        private bool enableBrowse = false;//ä¯ÀÀ
        private bool enableSave = false;//±£´æ  
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(516);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(517);
            this.ColumnBtnEdit.Visible = this.enableSave;
            if (this.enableBrowse)
            {
              
                this.dgrdvInvoice.ContextMenuStrip = this.cMenu;
                this.dgrdvNonInvoice.ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                this.LoadData();
            }
            this.lnkNew.Enabled = this.enableSave;
            if (this.enableSave)
            {
                this.lnkNew.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkNew_LinkClicked);
                this.dgrdvInvoice.CellContentClick += new DataGridViewCellEventHandler(dgrdvInvoice_CellContentClick);
                
            }
        }

        private void LoadNonInvoice()
        {
            while (this.dgrdvNonInvoice .ColumnCount > 3)
            {
                this.dgrdvNonInvoice.Columns.RemoveAt(3);
            }
            this.dtblNonInvoices = this.accReceiveItems.GetDataBuyReceiveItemsNonInvoicePivotMonthAMT().Tables[0];
       
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
        }
        private void LoadInvoice()
        {

            this.dtblInvoices = this.accInvoices.GetDataBuyInvoicesNonConfirm().Tables[0];
            this.dgrdvInvoice.DataSource = this.dtblInvoices; 
        }
        private void LoadData()
        {
            this.LoadNonInvoice();
            this.LoadInvoice();
           
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
                this.frmOper = new FrmInvoiceOper();
                new FrmStyle(this.frmOper).SetPopFrmStyle(this);
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
                    this.frmOper = new FrmInvoiceOper();
                    new FrmStyle(this.frmOper).SetPopFrmStyle(this);
                    this.frmOper.AffterSave += this.LoadData;
                }
                this.frmOper.Edit(InvoiceID);
                this.frmOper.ShowDialog();
            }
        }
    }
}