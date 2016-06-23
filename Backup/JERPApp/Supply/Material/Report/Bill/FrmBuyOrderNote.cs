using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Supply.Material.Report.Bill
{
    public partial class FrmBuyOrderNote : Form
    {
        public FrmBuyOrderNote()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accNotes = new JERPData.Material.BuyOrderNotes();
            this.accItems = new JERPData.Material.BuyOrderItems();
            this.NoteEntity = new JERPBiz.Material.BuyOrderNoteEntity();
            this.printer = new JERPBiz.Material.BuyOrderNotePrintHelper();
            this.lnkFile.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkFile_LinkClicked);
            this.btnExport.Click += new EventHandler(btnExport_Click);
        }

      
        private JERPData.Material.BuyOrderNotes accNotes;
        private JERPData.Material.BuyOrderItems accItems;
        private JERPBiz.Material.BuyOrderNoteEntity NoteEntity;
        private JERPBiz.Material.BuyOrderNotePrintHelper printer;
        private JCommon.FrmFileBrowse frmFileBrowse;
        private DataTable dtblItems;
        private long NoteID = -1;       
        public void Detail(long NoteID)
        {
            this.NoteID = NoteID;
            this.NoteEntity.LoadData(NoteID);
            this.txtNoteCode.Text = this.NoteEntity.NoteCode; 
            this.txtCompanyAbbName.Text = this.NoteEntity.CompanyAbbName;
            this.txtDateNote.Text = this.NoteEntity.DateNote.ToShortDateString();
            this.txtMoneyTypeName.Text = this.NoteEntity.MoneyTypeName;
            this.txtSettleTypeName.Text = this.NoteEntity.SettleTypeName;
            this.txtPriceTypeName.Text = this.NoteEntity.PriceTypeName;
            this.txtInvoiceTypeName.Text = this.NoteEntity.InvoiceTypeName;
            this.txtDeliverAddress.Text = this.NoteEntity.DeliverAddress;
            this.txtDeliverTypeName.Text = this.NoteEntity.DeliverTypeName;
            this.txtExpressRequire.Text = this.NoteEntity.ExpressRequire;
            this.txtDateNote.Text = this.NoteEntity.DateNote.ToShortDateString();
            this.txtAdvanceAMT.Text = string.Format("{0:0.####}", this.NoteEntity.AdvanceAMT);
            this.rchMemo.Text = this.NoteEntity.Memo;
            this.txtMakerPsn.Text = this.NoteEntity.MakerPsn;
            this.dtblItems = this.accItems.GetDataBuyOrderItemsByNoteID(NoteID).Tables[0];
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
            this.frmFileBrowse.Browse(JERPData.ServerParameter.ERPFileFolder + @"\Supply\MtrOrderNote\" + this.NoteID.ToString());
            this.frmFileBrowse.ShowDialog();
        }
        void btnExport_Click(object sender, EventArgs e)
        {
            this.printer.ExportToExcel(this.NoteID);
        }
    }
}