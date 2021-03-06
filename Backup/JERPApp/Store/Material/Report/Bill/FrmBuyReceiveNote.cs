using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Material.Report.Bill
{
    public partial class FrmBuyReceiveNote : FrmBizBill 
    {
        public FrmBuyReceiveNote()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.NoteEntity = new JERPBiz.Material.BuyReceiveNoteEntity();
            this.accItems = new JERPData.Material.BuyReceiveItems();
            this.printhelper = new JERPBiz.Material.BuyReceiveNotePrintHelper();
            this.btnExplore .Click  +=new EventHandler(btnExplore_Click);
        }
        private JERPBiz.Material.BuyReceiveNoteEntity NoteEntity;
        private JERPData.Material.BuyReceiveItems accItems;
        private JERPBiz.Material.BuyReceiveNotePrintHelper printhelper;
        private DataTable dtblItems;            
        public override void DetailNote(long NoteID)
        {
          
            this.NoteEntity.LoadData(NoteID);
            this.txtCompanyAbbName.Text = this.NoteEntity.CompanyAbbName;
            this.txtDateNote.Text = this.NoteEntity.DateNote.ToShortDateString();
            this.txtNoteCode.Text = this.NoteEntity.NoteCode;
            this.txtPONo.Text = this.NoteEntity.PONo;
            this.txtQCPsn.Text = this.NoteEntity.QCPsn;
            this.txtMakerPsn.Text = this.NoteEntity.MakerPsn;
            this.rchMemo.Text = this.NoteEntity.Memo;
            this.dtblItems = this.accItems.GetDataBuyReceiveItemsByNoteID(NoteID).Tables[0];
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