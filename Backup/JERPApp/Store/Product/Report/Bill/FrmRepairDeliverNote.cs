using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Product.Report.Bill
{
    public partial class FrmRepairDeliverNote :Form   
    {
        public FrmRepairDeliverNote()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.NoteEntity = new JERPBiz.Product.RepairDeliverNoteEntity();
            this.accItems = new JERPData.Product.RepairDeliverItems();
            this.PrinterHelper = new JERPBiz.Product.RepairDeliverPrintHelper();
            this.btnExplore .Click  +=new EventHandler(btnExplore_Click);
        }
        private JERPBiz.Product.RepairDeliverNoteEntity NoteEntity;
        private JERPData.Product.RepairDeliverItems accItems;
        private JERPBiz.Product.RepairDeliverPrintHelper PrinterHelper;
        private DataTable dtblItems;            
        public void  DetailNote(long NoteID)
        {
          
            this.NoteEntity.LoadData(NoteID);
            this.txtCompanyAbbName.Text = this.NoteEntity.CompanyAbbName;
            this.txtDateNote.Text = this.NoteEntity.DateNote.ToShortDateString();
            this.txtNoteCode.Text = this.NoteEntity.NoteCode;
            this.txtMakerPsn.Text = this.NoteEntity.MakerPsn;
            this.txtDeliverPsn.Text = this.NoteEntity.DeliverPsn;
            this.txtExpressCompanyName.Text = this.NoteEntity.ExpressCompanyName;
            this.txtExpressCode.Text = this.NoteEntity.ExpressCode;
            this.txtTotalAMT.Text =((this.NoteEntity .TotalAMT ==-1)?string.Empty :string.Format ("{0:0.####}", this.NoteEntity.TotalAMT));
            this.rchMemo.Text = this.NoteEntity.Memo;
            this.dtblItems = this.accItems.GetDataRepairDeliverItemsByNoteID(NoteID).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
        }

        void btnExplore_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            this.PrinterHelper.ExportToExcel(this.NoteEntity.NoteID);
            FrmMsg.Hide();
        }
    }
}