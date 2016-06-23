using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Engineer.Tool.Report.Bill
{
    public partial class FrmBuyReceiveNote : Form  
    {
        public FrmBuyReceiveNote()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.NoteEntity = new JERPBiz.Tool.BuyReceiveNoteEntity();
            this.accItems = new JERPData.Tool.BuyReceiveItems();
            this.printhelper = new JERPBiz.Tool.BuyReceiveNotePrintHelper();
            this.btnExplore .Click  +=new EventHandler(btnExplore_Click);
        }
        private JERPBiz.Tool.BuyReceiveNoteEntity NoteEntity;
        private JERPData.Tool.BuyReceiveItems accItems;
        private JERPBiz.Tool.BuyReceiveNotePrintHelper printhelper;
        private DataTable dtblItems;
        private long NoteID = -1;  
        public  void DetailNote(long NoteID)
        {
            this.NoteID = NoteID;
            this.NoteEntity.LoadData(NoteID);
            this.txtPONo.Text = this.NoteEntity.PONo;
            this.txtCompanyAbbName.Text = this.NoteEntity.CompanyAbbName;
            this.txtDateNote.Text = this.NoteEntity.DateNote.ToShortDateString();
            this.txtNoteCode.Text = this.NoteEntity.NoteCode;
            this.txtQCPsn.Text = this.NoteEntity.QCPsn;
            this.txtMakerPsn.Text = this.NoteEntity.MakerPsn;
            this.rchMemo.Text = this.NoteEntity.Memo;
            this.dtblItems = this.accItems.GetDataBuyReceiveItemsByNoteID(NoteID).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
        }

        void btnExplore_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            this.printhelper.ExportToExcel(this.NoteID);         
            FrmMsg.Hide();
        }
    }
}