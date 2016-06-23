using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Common
{
    public partial class FrmOtherResBuyApplyConfirmOper : Form
    {
        public FrmOtherResBuyApplyConfirmOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false; 
            this.accItems = new JERPData.OtherRes.BuyOrderApplyItems();
            this.accNotes = new JERPData.OtherRes.BuyOrderApplyNotes(); 
            this.NoteEntity = new JERPBiz.OtherRes.BuyOrderApplyNoteEntity();  
            this.accBuyPlans =new JERPData.OtherRes.BuyPlans ();
            this.btnSave.Click += new EventHandler(btnSave_Click);  
        }

        private JERPData.OtherRes.BuyOrderApplyNotes accNotes;
        private JERPData.OtherRes.BuyOrderApplyItems accItems;
        private JERPBiz.OtherRes.BuyOrderApplyNoteEntity NoteEntity; 
        private JERPData .OtherRes .BuyPlans accBuyPlans;
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