using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Material.Report.Bill
{
    public partial class FrmOutSrcLossSupplyNote : FrmBizBill 
    {
        public FrmOutSrcLossSupplyNote()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.NoteEntity = new JERPBiz.Material.OutSrcLossSupplyNoteEntity ();
            this.accItems = new JERPData.Material.OutSrcLossSupplyItems();
            this.printhelper = new JERPBiz.Material.OutSrcLossSupplyNotePrintHelper();
            this.btnExplore .Click  +=new EventHandler(btnExplore_Click);
        }
        private JERPBiz.Material.OutSrcLossSupplyNoteEntity  NoteEntity;
        private JERPData.Material.OutSrcLossSupplyItems accItems;
        private JERPBiz.Material.OutSrcLossSupplyNotePrintHelper printhelper;
        private DataTable dtblItems;
        private long NoteID = -1;
        public override void DetailNote(long NoteID)
        {
            this.NoteID = NoteID;
            this.NoteEntity.LoadData(NoteID);
            this.txtDateNote.Text = this.NoteEntity.DateNote.ToShortDateString();
            this.txtNoteCode.Text = this.NoteEntity.NoteCode;
            this.txtCompanyAbbName.Text = this.NoteEntity.CompanyAbbName;
            this.txtSupplierAddress.Text = this.NoteEntity.SupplierAddress;
            this.txtMakerPsn.Text = this.NoteEntity.MakerPsn;   
            this.rchMemo.Text = this.NoteEntity.Memo;
            this.dtblItems = this.accItems.GetDataOutSrcLossSupplyItemsByNoteID (NoteID).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
        }
        void btnExplore_Click(object sender, EventArgs e)
        { 
            this.printhelper.ExportToExcel(this.NoteID);
        }
    }
}