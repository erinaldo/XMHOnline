using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Material.Report.Bill
{
    public partial class FrmOutSrcReceiveNote : Form  
    {
        public FrmOutSrcReceiveNote()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.NoteEntity = new JERPBiz.Manufacture.OutSrcReceiveNoteEntity();
            this.accItems = new JERPData.Manufacture.OutSrcReceiveItems();
            this.printhelper = new JERPBiz.Manufacture.OutSrcReceiveNotePrintHelper();
            this.btnExplore .Click  +=new EventHandler(btnExplore_Click);
        }
        private JERPBiz.Manufacture.OutSrcReceiveNoteEntity NoteEntity;
        private JERPData.Manufacture.OutSrcReceiveItems accItems;
        private JERPBiz.Manufacture .OutSrcReceiveNotePrintHelper  printhelper;
     
        private DataTable dtblItems;            
        public  void DetailNote(long NoteID)
        {
          
            this.NoteEntity.LoadData(NoteID);
            this.txtCompanyAbbName.Text = this.NoteEntity.CompanyAbbName;
            this.txtDateNote.Text = this.NoteEntity.DateNote.ToShortDateString();
            this.txtNoteCode.Text = this.NoteEntity.NoteCode;
            this.txtPONo.Text = this.NoteEntity.PONo;
            this.txtQCPsn.Text = this.NoteEntity.QCPsn;
            this.txtMakerPsn.Text = this.NoteEntity.MakerPsn;
            this.rchMemo.Text = this.NoteEntity.Memo;
            this.dtblItems = this.accItems.GetDataOutSrcReceiveItemsByNoteID(NoteID).Tables[0];
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