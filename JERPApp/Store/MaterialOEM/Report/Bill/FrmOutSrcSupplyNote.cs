using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.MaterialOEM.Report.Bill
{
    public partial class FrmOutSrcSupplyNote : FrmBizBill 
    {
        public FrmOutSrcSupplyNote()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.NoteEntity = new JERPBiz.Material.OutSrcSupplyNoteEntity();
            this.accItems = new JERPData.Material.OutSrcSupplyItems();
            this.PrinterHelper =new JERPBiz.Material.OutSrcSupplyNotePrintHelper ();
            this.btnExplore .Click  +=new EventHandler(btnExplore_Click);
        }
        private JERPBiz.Material.OutSrcSupplyNoteEntity NoteEntity;
        private JERPData.Material.OutSrcSupplyItems accItems;
        private JERPBiz.Material.OutSrcSupplyNotePrintHelper PrinterHelper;
        private DataTable dtblItems;
        private long NoteID = -1;
        public override void DetailNote(long NoteID)
        {
            this.NoteID = NoteID;
            this.NoteEntity.LoadData(NoteID);
            this.txtCompanyAbbName.Text = this.NoteEntity.CompanyAbbName ;         
            this.txtDateNote.Text = this.NoteEntity.DateNote.ToShortDateString();
            this.txtNoteCode.Text = this.NoteEntity.NoteCode;
            this.txtMakerPsn.Text = this.NoteEntity.MakerPsn;    
            this.rchMemo.Text = this.NoteEntity.Memo;
            this.dtblItems = this.accItems.GetDataOutSrcSupplyItemsByNoteID(NoteID).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
        }

        void btnExplore_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            this.PrinterHelper.ExportToExcel(this.NoteID);
            FrmMsg.Hide();
          
        }
    }
}