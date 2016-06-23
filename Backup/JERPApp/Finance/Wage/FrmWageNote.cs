using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Wage
{
    public partial class FrmWageNote : Form
    {
        public FrmWageNote()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accNotes = new JERPData.Finance.WageNotes();
            this.SetPermit();
        }
        private JERPData.Finance.WageNotes accNotes;
        private FrmWageNoteOper frmOper;
        private DataTable dtblNotes;
        
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(617);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(618);
            if (this.enableBrowse)
            {
               
                //加载数据
                LoadData();
                this.dgrdv.ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
           
            }
            this.lnkNew.Enabled = this.enableSave;
            this.ColumnbtnEdit.Visible = this.enableSave;
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
            if ((irow == -1) || (icol == -1)) return;           
            if (this.dgrdv.Columns[icol].Name == this.ColumnbtnEdit.Name)
            {
                long NoteID = (long)this.dtblNotes.DefaultView[irow]["NoteID"];
                if (this.frmOper == null)
                {
                    this.frmOper = new FrmWageNoteOper();
                    new FrmStyle(frmOper).SetPopFrmStyle(this);
                    frmOper.AffterSave += this.LoadData;
                }
                frmOper.EditNote(NoteID);
                frmOper.ShowDialog();
            } 
           
        }

        void lnkNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.frmOper == null)
            {
                this.frmOper = new FrmWageNoteOper();
                new FrmStyle(frmOper).SetPopFrmStyle(this);
                frmOper.AffterSave += this.LoadData;
            }
            frmOper.NewNote ();
            frmOper.ShowDialog();
        }
        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private void LoadData()
        {
            this.dtblNotes = this.accNotes.GetDataWageNotesNonConfirm().Tables[0];
            this.dgrdv.DataSource = this.dtblNotes;
        }

    
    }
}