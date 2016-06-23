using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Supply.Material
{
    public partial class FrmOrderNoteConfirmOper : Form
    {
        public FrmOrderNoteConfirmOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accNotes = new JERPData.Material.BuyOrderNotes();
            this.accItems = new JERPData.Material.BuyOrderItems();
            this.NoteEntity = new JERPBiz.Material.BuyOrderNoteEntity();
            this.printhelper = new JERPBiz.Material.BuyOrderNotePrintHelper();
            this.lnkFile.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkFile_LinkClicked);
            this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
            this.btnConfirm.Click += new EventHandler(btnConfirm_Click);
        }

   
        private JERPData.Material.BuyOrderNotes accNotes;
        private JERPData.Material.BuyOrderItems accItems;
        private JERPBiz.Material.BuyOrderNoteEntity NoteEntity;
        private JERPBiz.Material.BuyOrderNotePrintHelper printhelper;
        private JCommon.FrmFileBrowse frmFileBrowse;
        private DataTable dtblItems;
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
        private long NoteID = -1;       
        public void ConfirmOper(long NoteID)
        {
            this.NoteID = NoteID;
            this.NoteEntity.LoadData(NoteID);
            this.txtNoteCode.Text = this.NoteEntity.NoteCode;
            this.txtCompanyAbbName.Text = this.NoteEntity.CompanyAbbName;
            this.txtDateNote.Text = this.NoteEntity.DateNote.ToShortDateString();
            this.txtMoneyTypeName.Text = this.NoteEntity.MoneyTypeName;
            this.txtSettleTypeName.Text = this.NoteEntity.SettleTypeName;
            this.txtPriceTypeName.Text = this.NoteEntity.PriceTypeName;
            this.txtInvoiceTypeName.Text = this.NoteEntity.InvoiceTypeName;
            this.txtDeliverAddress.Text = this.NoteEntity.DeliverAddress;
            this.txtDeliverTypeName.Text = this.NoteEntity.DeliverTypeName;
            this.txtExpressRequire.Text = this.NoteEntity.ExpressRequire;
            this.txtDateNote.Text = this.NoteEntity.DateNote.ToShortDateString(); 
            this.rchMemo.Text = this.NoteEntity.Memo;
            this.txtMakerPsn.Text = this.NoteEntity.MakerPsn;
            this.dtblItems = this.accItems.GetDataBuyOrderItemsByNoteID(NoteID).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
        }
        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow=e.RowIndex ;
            int icol=e.ColumnIndex ;
            if((irow==-1)||(icol==-1))return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnPrdCode.Name)
            {
                string url = this.dgrdv[this.ColumnURL.Name, irow].Value.ToString();
                if (url == string.Empty) return;
                System.Diagnostics.Process.Start(url);
            }
        } 
      
        void lnkFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.frmFileBrowse == null)
            {
                this.frmFileBrowse = new JCommon.FrmFileBrowse();
                new FrmStyle(frmFileBrowse).SetPopFrmStyle(this);
                this.frmFileBrowse.ReadOnly = true;
            }
            this.frmFileBrowse.Browse(JERPData.ServerParameter.ERPFileFolder + @"\Supply\MtrOrderNote\" + this.NoteID.ToString());
            this.frmFileBrowse.ShowDialog();
        }
        void btnConfirm_Click(object sender, EventArgs e)
        {
            DialogResult rut = MessageBox.Show ("即将审核当前订单,一经审核不能变更,但可以取消审核再度变更!", "审核确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (rut == DialogResult.Cancel) return;
            string errormsg=string.Empty ;
            bool flag=this.accNotes.UpdateBuyOrderNotesForConfirm(ref errormsg,
                this.NoteID,
                JERPBiz.Frame.UserBiz.PsnID);
            if (flag)
            {
                rut = MessageBox.Show("成功审核当前订单,需要立即打印输出吗？", "输出确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rut == DialogResult.OK )
                {
                    this.printhelper.ExportToExcel(this.NoteID);
                }
            }
            else
            {
                MessageBox.Show(errormsg);
            }
            if (this.affterSave != null)
            {
                this.affterSave();
            }
            this.Close();
        }

    }
}