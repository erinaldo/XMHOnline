using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Supply.OutSrc.Report.Bill
{
    public partial class FrmOutSrcOrderNote : Form
    {
        public FrmOutSrcOrderNote()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accNotes = new JERPData.Manufacture.OutSrcOrderNotes();
            this.accItems = new JERPData.Manufacture.OutSrcOrderItems();
            this.NoteEntity = new JERPBiz.Manufacture.OutSrcOrderNoteEntity();
            this.printer = new JERPBiz.Manufacture.OutSrcOrderNotePrintHelper();
            this.lnkFile.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkFile_LinkClicked);
            this.btnExport.Click += new EventHandler(btnExport_Click);
        }

      
        private JERPData.Manufacture.OutSrcOrderNotes accNotes;
        private JERPData.Manufacture.OutSrcOrderItems accItems;
        private JERPBiz.Manufacture.OutSrcOrderNoteEntity NoteEntity;
        private JERPBiz.Manufacture.OutSrcOrderNotePrintHelper printer;
        private JCommon.FrmFileBrowse frmFileBrowse;
        private DataTable dtblItems;
        private long NoteID = -1;       
        public void Detail(long NoteID)
        {
            this.NoteID = NoteID;
            this.NoteEntity.LoadData(NoteID);
            this.txtNoteCode.Text = this.NoteEntity.NoteCode;
            this.txtCompanyAbbName.Text = this.NoteEntity.CompanyAbbName;
            this.txtOrderTypeName.Text = this.NoteEntity.OrderTypeName;
            this.txtDateNote.Text = this.NoteEntity.DateNote.ToShortDateString();
            this.txtMoneyTypeName.Text = this.NoteEntity.MoneyTypeName;
            this.txtSettleTypeName.Text = this.NoteEntity.SettleTypeName;
            this.txtPriceTypeName.Text = this.NoteEntity.PriceTypeName;         
            this.txtDateNote.Text = this.NoteEntity.DateNote.ToShortDateString();
            this.txtAdvanceAMT.Text = string.Format("{0:0.####}", this.NoteEntity.AdvanceAMT);
            this.rchMemo.Text = this.NoteEntity.Memo;
            this.txtMakerPsn.Text = this.NoteEntity.MakerPsn;
            this.dtblItems = this.accItems.GetDataOutSrcOrderItemsByNoteID(NoteID).Tables[0];
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
            this.frmFileBrowse.Browse(JERPData.ServerParameter.ERPFileFolder + @"\Supply\OutSrcOrderNote\" + this.NoteID.ToString());
            this.frmFileBrowse.ShowDialog();
        }
        void btnExport_Click(object sender, EventArgs e)
        {
            this.printer.ExportToExcel  (this.NoteID);
        }
    }
}