using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Supply.OutSrc
{
    public partial class FrmOrderNoteConfirmOper : Form
    {
        public FrmOrderNoteConfirmOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accNotes = new JERPData.Manufacture.OutSrcOrderNotes();
            this.accItems = new JERPData.Manufacture.OutSrcOrderItems();
            this.NoteEntity = new JERPBiz.Manufacture.OutSrcOrderNoteEntity();
            this.printhelper = new JERPBiz.Manufacture.OutSrcOrderNotePrintHelper();
            this.lnkFile.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkFile_LinkClicked);
            this.btnConfirm.Click += new EventHandler(btnConfirm_Click);
        }

  
        private JERPData.Manufacture.OutSrcOrderNotes accNotes;
        private JERPData.Manufacture.OutSrcOrderItems accItems;
        private JERPBiz.Manufacture.OutSrcOrderNoteEntity NoteEntity;
        private JERPBiz.Manufacture.OutSrcOrderNotePrintHelper printhelper;
        private JCommon.FrmFileBrowse frmFileBrowse;
        private DataTable dtblItems;
        private long NoteID = -1;       
        public void ConfirmOper(long NoteID)
        {
            this.NoteID = NoteID;
            this.NoteEntity.LoadData(NoteID);
            this.txtNoteCode.Text = this.NoteEntity.NoteCode;
            this.txtCompanyAbbName.Text = this.NoteEntity.CompanyAbbName;
            this.txtDateNote.Text = this.NoteEntity.DateNote.ToShortDateString();
            this.txtOrderTypeName.Text = this.NoteEntity.OrderTypeName;
            this.txtDateNote.Text = this.NoteEntity.DateNote.ToShortDateString();
            this.txtMoneyTypeName.Text = this.NoteEntity.MoneyTypeName;
            this.txtSettleTypeName.Text = this.NoteEntity.SettleTypeName;
            this.txtPriceTypeName.Text = this.NoteEntity.PriceTypeName;
            this.txtInvoiceTypeName.Text = this.NoteEntity.InvoiceTypeName;
            this.txtSupplierAddress.Text = this.NoteEntity.SupplierAddress;
            this.txtDeliverAddress.Text = this.NoteEntity.DeliverAddress;
           
            this.rchMemo.Text = this.NoteEntity.Memo;
            this.txtMakerPsn.Text = this.NoteEntity.MakerPsn;
            this.dtblItems = this.accItems.GetDataOutSrcOrderItemsByNoteID(NoteID).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
        }
        void lnkFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.frmFileBrowse == null)
            {
                this.frmFileBrowse = new JCommon.FrmFileBrowse();
                new FrmStyle(frmFileBrowse).SetPopFrmStyle(this);
                this.frmFileBrowse.ReadOnly = true;
            }
            this.frmFileBrowse.Browse(JERPData.ServerParameter.ERPFileFolder + @"\Supply\OutSrcOrderNote\" + this.NoteID.ToString());
            this.frmFileBrowse.ShowDialog();
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
        void btnConfirm_Click(object sender, EventArgs e)
        {
            DialogResult rut = MessageBox.Show("即将进行审核，审核后订单方可送料\n是否审核?请确认!", "审核确认", MessageBoxButtons.OKCancel , MessageBoxIcon.Question);
            if (rut == DialogResult.Cancel ) return;
            string errormsg = string.Empty;
            bool flag = this.accNotes.UpdateOutSrcOrderNotesForConfirm(ref errormsg, this.NoteID, JERPBiz.Frame.UserBiz.PsnID);
           if (flag)
            {
                //rut = MessageBox.Show("成功审核当前订单,需要立即打印输出吗？", "输出确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                //if (rut == DialogResult.OK )
                //{
                    //this.printhelper.ExportToExcel(this.NoteID);
                this.accNotes.UpdateOutSrcOrderNotesForPrint(ref errormsg, this.NoteID);
                //}
            }
            else
            { 
                MessageBox.Show(errormsg, "出错啦", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } 
            if (this.affterSave != null) this.affterSave();
            this.Close();
        }

      
    }
}