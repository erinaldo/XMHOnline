using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Report.Bill.Finance
{
    public partial class FrmPostageNote : Form    
    {
        public FrmPostageNote()
        {
            InitializeComponent();
            this.Entity = new JERPBiz.Finance.PostageNoteEntity();
            this.btnExport.Click += new EventHandler(btnExport_Click);
        }


        private JERPBiz.Finance.PostageNoteEntity  Entity;
        public   void DetailNote(long NoteID)
        {
            this.Entity.LoadData(NoteID);
            this.txtNoteCode.Text = Entity.NoteCode;
            this.txtDateNote.Text = Entity.DateNote.ToShortDateString ();         
            this.txtAmount.Text = string.Format ("{0:0.####}",Entity.Amount);
            this.txtCompanyAllName.Text = this.Entity.CompanyName ;
            this.txtMakerPsn.Text = this.Entity.MakerPsn;
            this.rchMemo.Text = this.Entity.Memo;
           
        }
        void btnExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "快递单");
            excel.SetCellVal("A2", "快递单号:" + this.txtNoteCode.Text + "      付款日期:" + this.txtDateNote.Text);
            excel.SetCellVal("A3", "物流公司:" + this.txtCompanyAllName.Text + "        制单人:" + this.txtMakerPsn.Text);
            excel.SetCellVal("A4", "金额:" + this.txtAmount.Text);
            excel.SetCellVal("A5", "备注:" + this.rchMemo.Text);
            excel.Show();
            FrmMsg.Hide();
        }
    }
}