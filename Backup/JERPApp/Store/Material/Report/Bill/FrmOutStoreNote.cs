using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Material.Report.Bill
{
    public partial class FrmOutStoreNote : FrmBizBill 
    {
        public FrmOutStoreNote()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.NoteEntity = new JERPBiz.Material.OutStoreNoteEntity();
            this.accItems = new JERPData.Material.OutStoreItems();
            this.printerhelper = new JERPBiz.Material.OutStoreNotePrintHelper();
            this.btnExplore .Click  +=new EventHandler(btnExplore_Click);
        }
        private JERPBiz.Material.OutStoreNoteEntity NoteEntity;
        private JERPData.Material.OutStoreItems accItems;
        private JERPBiz.Material.OutStoreNotePrintHelper printerhelper;
        private DataTable dtblItems;
     
        public override void DetailNote(long NoteID)
        {
            this.NoteEntity.LoadData(NoteID);

            this.txtDateNote.Text = this.NoteEntity.DateNote.ToShortDateString();
            this.txtNoteCode.Text = this.NoteEntity.NoteCode;
            
            this.txtMakerPsn.Text = this.NoteEntity.MakerPsn;   
            this.rchMemo.Text = this.NoteEntity.Memo;
            this.dtblItems = this.accItems.GetDataOutStoreItemsByNoteID(NoteID).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
        }

        void btnExplore_Click(object sender, EventArgs e)
        {

            FrmMsg.Show("正在生成打印文档，请稍候......");
            this.printerhelper.ExportToExcel(this.dtblItems.Select());
            FrmMsg.Hide();
           
        }
    }
}