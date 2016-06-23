using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Product.Report.Bill
{
    public partial class FrmSaleDeliverNote :FrmBizBill  
    {
        public FrmSaleDeliverNote()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.NoteEntity = new JERPBiz.Product.SaleDeliverNoteEntity();
            this.accItems = new JERPData.Product.SaleDeliverItems();
            this.PrinterHelper = new JERPBiz.Product.SaleDeliverPrintHelper();
            this.btnExplore .Click  +=new EventHandler(btnExplore_Click);
        }
        private JERPBiz.Product.SaleDeliverNoteEntity NoteEntity;
        private JERPData.Product.SaleDeliverItems accItems;
        private JERPBiz.Product.SaleDeliverPrintHelper PrinterHelper;
        private DataTable dtblItems;            
        public override  void DetailNote(long NoteID)
        {
          
            this.NoteEntity.LoadData(NoteID);
            this.txtPONo.Text = this.NoteEntity.PONo;
            this.txtCompanyAbbName.Text = this.NoteEntity.CompanyAbbName;
            this.txtDateNote.Text = this.NoteEntity.DateNote.ToShortDateString();
            this.txtNoteCode.Text = this.NoteEntity.NoteCode;
            this.txtMakerPsn.Text = this.NoteEntity.MakerPsn;
            this.txtDeliverPsn.Text = this.NoteEntity.DeliverPsn;
            this.txtMoneyTypeName.Text = this.NoteEntity.MoneyTypeName;
            this.txtTotalAMT.Text = string.Format("{0:0.#####}", this.NoteEntity.TotalAMT);
            this.txtExpressCompanyName.Text = this.NoteEntity.ExpressCompanyName;
            this.txtExpressCode.Text = this.NoteEntity.ExpressCode;
            this.rchMemo.Text = this.NoteEntity.Memo;
            this.dtblItems = this.accItems.GetDataSaleDeliverItemsByNoteID(NoteID).Tables[0];
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