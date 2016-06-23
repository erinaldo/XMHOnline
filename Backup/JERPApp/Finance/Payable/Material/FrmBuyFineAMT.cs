using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Payable.Material
{
    public partial class FrmBuyFineAMT : Form
    {
        public FrmBuyFineAMT()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accFineNote = new JERPData.Material.BuyFineAMTNotes();
            this.SetPermit();
        }
        private JERPData.Material.BuyFineAMTNotes accFineNote;
        private DataTable dtblFineAMT;
        private FrmBuyFineAMTOper frmOper;
        private FrmBuyFineAMTConfirm frmConfirmOper;
        //È¨ÏÞÂë
        private bool enableBrowse = false;//ä¯ÀÀ
        private bool enableSave = false;//±£´æ  
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(258);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(259);           
            if (this.enableBrowse)
            {
                this.LoadData();
                this.dgrdv .ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
            }
            this.lnkNew.Enabled = this.enableSave;
            this.ColumnbtnEdit.Visible = this.enableSave;
            this.ColumnbtnConfirm.Visible = this.enableSave;
            if (this.enableSave)
            {
                this.lnkNew.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkNew_LinkClicked);
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
            }
        }

        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if((irow==-1)||(icol==-1))return;
            long NoteID = (long)this.dtblFineAMT.DefaultView[irow]["NoteID"];
            if (this.dgrdv.Columns[icol].Name == this.ColumnbtnEdit.Name)
            {
               
                if (frmOper == null)
                {
                    frmOper = new FrmBuyFineAMTOper();
                    new FrmStyle(frmOper).SetPopFrmStyle(this);
                    frmOper.AffterSave += this.LoadData;
                }
                frmOper.Edit(NoteID);
                frmOper.ShowDialog();
            }
            if (this.dgrdv.Columns[icol].Name == this.ColumnbtnConfirm .Name)
            {
                if (frmConfirmOper  == null)
                {
                    frmConfirmOper = new FrmBuyFineAMTConfirm();
                    new FrmStyle(frmConfirmOper).SetPopFrmStyle(this);
                    frmConfirmOper.AffterSave += this.LoadData;
                }
                frmConfirmOper.ConfirmOper (NoteID);
                frmConfirmOper.ShowDialog();
            }
        }

        void lnkNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (frmOper == null)
            {
                frmOper = new FrmBuyFineAMTOper();
                new FrmStyle(frmOper).SetPopFrmStyle(this);
                frmOper.AffterSave += this.LoadData;
            }
            frmOper.New();
            frmOper.ShowDialog();
        }

        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
        private void LoadData()
        {
            this.dtblFineAMT = this.accFineNote.GetDataBuyFineAMTNotesNonConfirm().Tables[0];
            this.dgrdv.DataSource = this.dtblFineAMT;
        }
    }
}