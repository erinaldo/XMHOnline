using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.MaterialOEM
{
    public partial class FrmStoreCheckNoteConfirm : Form
    {
        public FrmStoreCheckNoteConfirm()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accNotes = new JERPData.Material.OEMStoreCheckNotes();
            this.accItems = new JERPData.Material.OEMStoreCheckItems(); 
            this.accStore = new JERPData.Material.OEMStore();
            this.accStoreReserve = new JERPData.Material.OEMStoreReserve();
            this.NoteEntity = new JERPBiz.Material.OEMStoreCheckNoteEntity();
            this.btnSave.Click += new EventHandler(btnSave_Click);  
        }

      
        private JERPData.Material.OEMStoreCheckNotes accNotes;
        private JERPData.Material.OEMStoreCheckItems accItems; 
        private JERPData.Material.OEMStore accStore;
        private JERPData.Material.OEMStoreReserve accStoreReserve;
        private JERPBiz.Material.OEMStoreCheckNoteEntity NoteEntity;
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
   
        public  void  Confirm(long NoteID)
        {
            this.NoteID = NoteID;
            this.NoteEntity.LoadData(NoteID);
            this.txtNoteCode.Text = this.NoteEntity.NoteCode;
            this.txtDateNote.Text = this.NoteEntity.DateNote.ToString();
            this.txtCompanyAbbName.Text = this.NoteEntity.CompanyAbbName;
            this.txtCheckPersons.Text = this.NoteEntity.CheckPersons;
            this.rchMemo.Text = this.NoteEntity.Memo;
            this.dtblItems = this.accItems.GetDataOEMStoreCheckItemsByNoteID(NoteID).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
        }    
       
      
       
        void btnSave_Click(object sender, EventArgs e)
        {
           
            DialogResult rsl = MessageBox.Show("将进行保存并入账，\n一经保存将不能变更，确认否?",
               "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rsl == DialogResult.No) return;
            string errormsg=string .Empty ;
            bool flag = false;
            flag = this.accNotes.UpdateOEMStoreCheckNotesForConfirm(ref errormsg,
                this.NoteID,
                JERPBiz.Frame.UserBiz.PsnID);
            if (!flag)
            {
                MessageBox.Show(errormsg);
                return;
            } 
            int CompanyID=this.NoteEntity .CompanyID ;
            foreach (DataRow drow in this.dtblItems.Rows )
            {

                if (drow["CheckQty"] == DBNull.Value)
                {
                    this.accItems.DeleteOEMStoreCheckItems(ref errormsg,
                        drow["ItemID"]);
                    continue;
                } 
                int PrdID = (int)drow["PrdID"];  
                if (drow["InitQty"]!=DBNull .Value )
                {
                    this.accStore.InsertOEMStoreForInitStore(
                       ref errormsg,
                       Report.Bill.FrmBizBill.CheckStoreNoteID,
                       Report.Bill.FrmBizBill.CheckStoreNoteName,
                           this.NoteID,
                           this.txtNoteCode .Text,
                           PrdID,
                           CompanyID,
                           drow["InitQty"]
                           );
                }
                
                //入库                  
                if (drow["SurplusQty"]!=DBNull .Value )
                {
                    this.accStore.InsertOEMStoreForCheckIntoStore(ref errormsg,
                     Report.Bill.FrmBizBill.CheckStoreNoteID,
                    Report.Bill.FrmBizBill.CheckStoreNoteName,
                        this.NoteID,
                        this.txtNoteCode .Text,
                        PrdID,
                        CompanyID,
                        drow["SurplusQty"]);
                }
                if (drow["LostQty"]!=DBNull .Value)
                {
                    this.accStore.InsertOEMStoreForCheckOutStore(ref errormsg,
                    Report.Bill.FrmBizBill.CheckStoreNoteID,
                    Report.Bill.FrmBizBill.CheckStoreNoteName,
                    NoteID,
                    this.txtNoteCode .Text,
                    PrdID,
                    CompanyID,
                    drow["LostQty"]);
                }
                //预留之调整
                this.accStoreReserve.UpdateOEMStoreReserveForAdjustStore(ref errormsg,  CompanyID, PrdID);
                    
            }
           
            MessageBox.Show("成功保存并入账当前盘点单");
            if (this.affterSave != null) this.affterSave();
            this.Close();
        }
    

    }
}