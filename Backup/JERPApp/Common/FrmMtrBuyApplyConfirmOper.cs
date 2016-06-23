using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Common
{
    public partial class FrmMtrBuyApplyConfirmOper : Form
    {
        public FrmMtrBuyApplyConfirmOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false; 
            this.accItems = new JERPData.Material.BuyOrderApplyItems();
            this.accNotes = new JERPData.Material.BuyOrderApplyNotes(); 
            this.NoteEntity = new JERPBiz.Material.BuyOrderApplyNoteEntity();  
            this.accBuyPlans =new JERPData.Material.BuyPlans ();
            this.btnSave.Click += new EventHandler(btnSave_Click);  
        }

        private JERPData.Material.BuyOrderApplyNotes accNotes;
        private JERPData.Material.BuyOrderApplyItems accItems;
        private JERPBiz.Material.BuyOrderApplyNoteEntity NoteEntity; 
        private JERPData .Material .BuyPlans accBuyPlans;
        private DataTable dtblItems  ; 
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
        private long noteid = -1;
        private long NoteID
        {
            get
            {
                return this.noteid;
            }
            set
            {
                this.noteid = value; 
            }
        } 
        public void ConfirmOper(long NoteID)
        {
            this.NoteID = NoteID;
            this.NoteEntity.LoadData(NoteID);
            this.txtDateNote.Text  = this.NoteEntity.DateNote.ToShortDateString ();
            this.txtDeptName .Text = this.NoteEntity.DeptName ;
            this.txtMakerPsn.Text = this.NoteEntity.MakerPsn;
            this.rchMemo.Text = this.NoteEntity.Memo;
            this.dtblItems = this.accItems.GetDataBuyOrderApplyItemsByNoteID(this.NoteID).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
           
        }
      
        
        void btnSave_Click(object sender, EventArgs e)
        {    DialogResult rul = MessageBox.Show("您将进行申购审核，一经审核生成采购计划不能变更和取消，\n是，审核；否，取消！", "操作确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No )return;
            
            string errormsg = string.Empty;
            bool flag = this.accNotes.UpdateBuyOrderApplyNotesForConfirm (ref errormsg,
                this.NoteID, 
                JERPBiz.Frame.UserBiz.PsnID); 
            if (!flag)
            { 
                MessageBox.Show(errormsg); 
                return;
            }
          
            foreach (DataRow drow in this.dtblItems.Rows )
            {
               this.accBuyPlans .SaveBuyPlans (ref errormsg ,
                   drow["PrdID"],
                   drow["Quantity"]);

                            
            }              
            MessageBox.Show("成功保存并入账当前申购单");
            if (this.affterSave != null) this.affterSave();
            this.Close();
        } 
    }
}