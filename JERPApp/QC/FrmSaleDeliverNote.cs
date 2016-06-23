using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.QC
{
    public partial class FrmSaleDeliverNote : Form
    {
        public FrmSaleDeliverNote()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accNotes = new JERPData.Product.SaleDeliverNotes();
            this.SetPermit();
        }
        private JERPData.Product.SaleDeliverNotes accNotes;
        private FrmSaleDeliverNoteOper frmOper;
        private DataTable dtblNotes;
         //È¨ÏÞÂë
        private bool enableBrowse = false;//ä¯ÀÀ
        private bool enableSave = false;//±£´æ
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(189);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(190);
            if (this.enableBrowse)
            {

                this.LoadData();
                
                this.dgrdv.ContextMenuStrip = this.cMenu;

                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
            }
        }

        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnbtnConfirm .Name)
            {
                long NoteID=(long)this.dtblNotes .DefaultView [irow]["NoteID"];
                if (frmOper == null)
                {
                    frmOper = new FrmSaleDeliverNoteOper();
                    new FrmStyle(frmOper).SetPopFrmStyle(this);
                    frmOper.AffterSave += this.LoadData;
                }
                frmOper.ConfirmOper(NoteID);
                frmOper.ShowDialog();
            }
        }

       

        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
        private void LoadData()
        {
            this.dtblNotes = this.accNotes.GetDataSaleDeliverNotesNeedFQCConfirm().Tables[0];
            this.dgrdv.DataSource = this.dtblNotes;
        }
    }
}