using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Product.Report.Bill
{
    public partial class FrmSaleReplenishNote : FrmBizBill 
    {
        public FrmSaleReplenishNote()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.NoteEntity = new JERPBiz.Product.SaleReplenishNoteEntity();
            this.accItems = new JERPData.Product.SaleReplenishItems();
            this.printhelper = new JERPBiz.Product.SaleReplenishPrintHelper();
            this.btnExplore .Click  +=new EventHandler(btnExplore_Click);
        }
        private JERPBiz.Product.SaleReplenishNoteEntity NoteEntity;
        private JERPData.Product.SaleReplenishItems accItems;
        private JERPBiz.Product.SaleReplenishPrintHelper  printhelper;
        private DataTable dtblItems;            
        public override void DetailNote(long NoteID)
        {
          
            this.NoteEntity.LoadData(NoteID);
            this.txtCompanyAbbName.Text = this.NoteEntity.CompanyAbbName;
          
            this.txtDateNote.Text = this.NoteEntity.DateNote.ToShortDateString();
            this.txtNoteCode.Text = this.NoteEntity.NoteCode;
            this.txtMakerPsn.Text = this.NoteEntity.MakerPsn;
            this.rchMemo.Text = this.NoteEntity.Memo;
            this.dtblItems = this.accItems.GetDataSaleReplenishItemsByNoteID(NoteID).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
        }

        void btnExplore_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            this.printhelper.ExportToExcel(this.NoteEntity.NoteID);
            FrmMsg.Hide();
        }
    }
}