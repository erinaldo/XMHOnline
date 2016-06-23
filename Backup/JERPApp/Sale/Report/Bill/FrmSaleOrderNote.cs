using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Sale.Report.Bill
{
    public partial class FrmSaleOrderNote : Form
    {
        public FrmSaleOrderNote()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accNotes = new JERPData.Product.SaleOrderNotes();
            this.accItems = new JERPData.Product.SaleOrderItems();
            this.NoteEntity = new JERPBiz.Product.SaleOrderNoteEntity();
            this.printer = new JERPBiz.Product.SaleOrderNotePrintHelper();
            this.lnkFile.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkFile_LinkClicked);
            this.btnExport.Click += new EventHandler(btnExport_Click);
        }

      
        private JERPData.Product.SaleOrderNotes accNotes;
        private JERPData.Product.SaleOrderItems accItems;
        private JERPBiz.Product.SaleOrderNoteEntity NoteEntity;
        private JERPBiz.Product.SaleOrderNotePrintHelper printer;
        private JCommon.FrmFileBrowse frmFileBrowse;

        private DataTable dtblItems;
        private long NoteID = -1;       
        public void Detail(long NoteID)
        {
            this.NoteID = NoteID;
            this.NoteEntity.LoadData(NoteID);
            this.txtNoteCode.Text = this.NoteEntity.NoteCode;
            this.txtPONo.Text = this.NoteEntity.PONo;
            this.txtCompanyAbbName.Text = this.NoteEntity.CompanyAbbName;
            this.txtDateNote.Text = this.NoteEntity.DateNote.ToShortDateString();
            this.txtMoneyTypeName.Text = this.NoteEntity.MoneyTypeName;
            this.txtSettleTypeName.Text = this.NoteEntity.SettleTypeName;
            this.txtPriceTypeName.Text = this.NoteEntity.PriceTypeName;
            this.txtDeliverAddress.Text = this.NoteEntity.DeliverAddress;
            this.txtFinanceAddress.Text = this.NoteEntity.FinanceAddress;
            this.txtDeliverTypeName.Text  = this.NoteEntity.DeliverTypeName;
            this.txtExpressRequire.Text = this.NoteEntity.ExpressRequire;
            this.txtAdvanceAMT.Text = string.Format("{0:0.####}", this.NoteEntity.AdvanceAMT);
            this.rchMemo.Text = this.NoteEntity.Memo;
            this.dtblItems = this.accItems.GetDataSaleOrderItemsByNoteID(NoteID).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
        }
        void lnkFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.frmFileBrowse == null)
            {
                this.frmFileBrowse = new JCommon.FrmFileBrowse();
                new FrmStyle(frmFileBrowse).SetPopFrmStyle(this);
                this.frmFileBrowse.ReadOnly = true;
            }
            this.frmFileBrowse.Browse(JERPData.ServerParameter.ERPFileFolder + @"\Sale\OrderNote\" + this.NoteID.ToString());
            this.frmFileBrowse.ShowDialog();
        }
        void btnExport_Click(object sender, EventArgs e)
        {
            this.printer.ExportToExcel(this.NoteID);
        }
    }
}