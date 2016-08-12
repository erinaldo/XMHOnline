using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Sale
{
    public partial class FrmSaleOrderConfirm : Form
    {
        public FrmSaleOrderConfirm()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accNotes = new JERPData.Product.SaleOrderNotes();
             this.SetPermit();
        }
        private JERPData.Product.SaleOrderNotes accNotes;
        private DataTable dtblNotes;
        private FrmSaleOrderConfirmOper frmOper;
        //È¨ÏÞÂë
        private bool enableBrowse = false;//ä¯ÀÀ
        private bool enableSave = false;//±£´æ
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(58);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(59);
            if (this.enableBrowse)
            {
         
                LoadData();
                this.dgrdv.ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                this.radNonConfirm.CheckedChanged += this.rad_CheckedChanged;
                this.radConfirm.CheckedChanged += this.rad_CheckedChanged;
            }
            this.ColumnbtnConfirm.Visible = this.enableSave;
            if (this.enableSave)
            {
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
                
            }
        }

        void rad_CheckedChanged(object sender, EventArgs e)
        {
            this.LoadData();
        }

        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnbtnConfirm.Name)
            {
                long NoteID = (long)this.dtblNotes.DefaultView[irow]["NoteID"];
                if (this.frmOper == null)
                {
                    this.frmOper = new FrmSaleOrderConfirmOper();
                    new FrmStyle(frmOper).SetPopFrmStyle(this);
                    this.frmOper.AffterSave += this.LoadData;
                }
                this.frmOper.ConfirmOper(NoteID);
                this.frmOper.ShowDialog();
            }
        }


        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
        private void LoadData()
        {
            if (this.radNonConfirm.Checked)
            {
                this.dtblNotes = this.accNotes.GetDataSaleOrderNotesNeedConfirm().Tables[0];
            }
            else
            {
                this.dtblNotes = this.accNotes.GetDataSaleOrderNotesHasConfirm().Tables[0];
            }
            this.dgrdv.DataSource = this.dtblNotes;

        }
    }
}