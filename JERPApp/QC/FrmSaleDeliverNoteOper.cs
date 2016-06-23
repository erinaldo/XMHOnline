using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.QC
{
    public partial class FrmSaleDeliverNoteOper :Form   
    {
        public FrmSaleDeliverNoteOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.NoteEntity = new JERPBiz.Product.SaleDeliverNoteEntity();
            this.accItems = new JERPData.Product.SaleDeliverItems();
            this.accNotes = new JERPData.Product.SaleDeliverNotes();
            this.btnConfrim.Click += new EventHandler(btnConfrim_Click);
        } 
        private JERPBiz.Product.SaleDeliverNoteEntity NoteEntity;
        private JERPData.Product.SaleDeliverItems accItems;
        private JERPData.Product.SaleDeliverNotes accNotes;
        private DataTable dtblItems;
        private long NoteID = -1;
        public  void ConfirmOper(long NoteID)
        {
            this.NoteID = NoteID;
            this.NoteEntity.LoadData(NoteID);
            this.txtPONo.Text = this.NoteEntity.PONo;
            this.txtCompanyAbbName.Text = this.NoteEntity.CompanyAbbName;
            this.txtDateNote.Text = this.NoteEntity.DateNote.ToShortDateString();
            this.txtNoteCode.Text = this.NoteEntity.NoteCode;
            this.txtMakerPsn.Text = this.NoteEntity.MakerPsn;
           
      
            this.rchMemo.Text = this.NoteEntity.Memo;
            this.dtblItems = this.accItems.GetDataSaleDeliverItemsByNoteID(NoteID).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
        }
        public delegate void AffterSaveDelegate();
        private AffterSaveDelegate affterSave;
        public event AffterSaveDelegate AffterSave
        {
            add
            {
                affterSave += value;
            }
            remove
            {
                affterSave -= value;
            }
        }
        void btnConfrim_Click(object sender, EventArgs e)
        {
            DialogResult rul = MessageBox.Show("销售送货单进行QC确认！", "审核确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No )return;
            string errormsg=string.Empty ;
            bool flag=this.accNotes.UpdateSaleDeliverNotesForFQCConfirm(ref errormsg,
                this.NoteID,
                JERPBiz.Frame.UserBiz.PsnID,
                 this.rchFQCPsns.Text);
            if (flag)
            {
                MessageBox.Show("成功进行检品确认");
            }
            else
            {
                MessageBox.Show(errormsg);
            }
            if (this.affterSave != null) this.affterSave();
            this.Close();
        }
       
    }
}