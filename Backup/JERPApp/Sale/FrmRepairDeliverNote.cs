using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Sale
{
    public partial class FrmRepairDeliverNote : Form
    {
        public FrmRepairDeliverNote()
        {
            InitializeComponent();
            this.accNotes = new JERPData.Product.RepairDeliverNotes();
            this.accRepairItems = new JERPData.Product.RepairItems();
            this.dgrdvNote.AutoGenerateColumns = false;
            this.dgrdvRepairItem.AutoGenerateColumns = false;
            this.ctrlQNote.SeachGridView = this.dgrdvNote;
            this.ctrlQRepairItem.SeachGridView = this.dgrdvRepairItem;
            this.SetPermit();
        }
        private JERPData.Product.RepairDeliverNotes accNotes;
        private JERPData.Product.RepairItems   accRepairItems;
        FrmRepairDeliverNoteOper frmOper = null; 
        private DataTable dtblRepairItems,dtblNotes;
       
        private bool enableBrowse = false;
        private bool enableSave= false;
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(457);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(458);
            if (this.enableBrowse)
            {  
                this.LoadNoteData();
                this.LoadNonDeliver(); 
                this.dgrdvRepairItem.ContextMenuStrip = this.cMenu;
                this.dgrdvNote.ContextMenuStrip = this.cMenu;
               
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);  
                
                 
            }
           
            if (this.enableSave)
            {
                this.dgrdvRepairItem.CellContentClick += new DataGridViewCellEventHandler(dgrdvRepairItem_CellContentClick);
                this.dgrdvNote.CellContentClick += new DataGridViewCellEventHandler(dgrdvNote_CellContentClick); 
               
            }
        }

     
       
        private void LoadNonDeliver()
        {
            this.dtblRepairItems = this.accRepairItems.GetDataRepairItemsNeedDeliver().Tables[0];
            this.dgrdvRepairItem.DataSource = this.dtblRepairItems;
            this.pageNonDeliver.Text = "Î´ÖÆµ¥[" + this.dtblRepairItems.Rows.Count.ToString() + "]";
        }
        private void LoadNoteData()
        { 
            this.dtblNotes = this.accNotes.GetDataRepairDeliverNotesNonConfirm().Tables[0];
            this.dgrdvNote.DataSource = this.dtblNotes; 
        } 
        void mItemRefresh_Click(object sender, EventArgs e)
        {
            if (this.cMenu.SourceControl == this.dgrdvNote)
            { 
                this.LoadNoteData();
            }
            if (this.cMenu.SourceControl == this.dgrdvRepairItem)
            {
                this.LoadNonDeliver();
            }
            
        }

        void dgrdvRepairItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { 
            int irow=e.RowIndex ;
            int icol=e.ColumnIndex ;
            if((irow==-1)||(icol ==-1))return;
            if(this.dgrdvRepairItem .Columns[icol].Name ==this.ColumnbtnNew .Name )
            {
                if (frmOper == null)
                {
                    frmOper = new FrmRepairDeliverNoteOper();
                    new FrmStyle(frmOper).SetPopFrmStyle(this);
                    frmOper.AffterSave += frmOper_AffterSave;

                }
                frmOper.New(this.dtblRepairItems .DefaultView [irow].Row);
                frmOper.ShowDialog();
            }
        }
        void frmOper_AffterSave()
        { 
            this.LoadNoteData();
            this.LoadNonDeliver(); 
        }
       
        private void dgrdvNote_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvNote.Columns[icol].Name == this.ColumnbtnEdit.Name)
            {
                long NoteID = (long)this.dtblNotes.DefaultView[irow]["NoteID"];
                if (frmOper   == null)
                {
                    frmOper = new FrmRepairDeliverNoteOper();
                    new FrmStyle(frmOper).SetPopFrmStyle(this);        
                    frmOper .AffterSave +=new FrmRepairDeliverNoteOper.AffterSaveDelegate(frmOper_AffterSave); 
                } 
                frmOper.Edit(NoteID);
                frmOper.ShowDialog();
            }
        }
       
       
    }
}