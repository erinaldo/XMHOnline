using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Supply.Material.Report.Bill
{
    public partial class FrmBuyOrderApplyNote : Form
    {
        public FrmBuyOrderApplyNote()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false; 
            this.accItems = new JERPData.Material.BuyOrderApplyItems(); 
            this.NoteEntity = new JERPBiz.Material.BuyOrderApplyNoteEntity();   
        }
         
        private JERPData.Material.BuyOrderApplyItems accItems;
        private JERPBiz.Material.BuyOrderApplyNoteEntity NoteEntity; 
        private DataTable dtblItems  ;  
        public void Detail(long NoteID)
        { 
            this.NoteEntity.LoadData(NoteID);
            this.txtDateNote.Text  = this.NoteEntity.DateNote.ToShortDateString ();
            this.txtDeptName .Text = this.NoteEntity.DeptName ;
            this.txtMakerPsn.Text = this.NoteEntity.MakerPsn;
            this.txtConfirmPsn.Text = this.NoteEntity.ConfirmPsn;
            this.rchMemo.Text = this.NoteEntity.Memo;
            this.dtblItems = this.accItems.GetDataBuyOrderApplyItemsByNoteID(NoteID).Tables[0];
            this.dgrdv.DataSource = this.dtblItems; 
        }
      
        
     
    }
}