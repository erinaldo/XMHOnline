using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Product
{
    public partial class FrmStoreCheckNoteConfirm : Form
    {
        public FrmStoreCheckNoteConfirm()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accNotes = new JERPData.Product.StoreCheckNotes();
            this.accItems = new JERPData.Product.StoreCheckItems();
            this.accPrds = new JERPData.Product .Product();
            this.accStore = new JERPData.Product.Store();
            this.NoteEntity = new JERPBiz.Product.StoreCheckNoteEntity();
            this.accStoreReserve = new JERPData.Product.StoreReserve();  
            this.btnSave.Click += new EventHandler(btnSave_Click);  
           
        }
        private JERPData.Product.StoreCheckNotes accNotes;
        private JERPData.Product.StoreCheckItems accItems;
        private JERPData.Product.Product accPrds; 
        private JERPData.Product.Store accStore;
        private JERPData.Product.StoreReserve accStoreReserve; 
        private JERPBiz.Product.StoreCheckNoteEntity NoteEntity;
        private DataTable dtblItems;
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
      
    
        public  void Confirm(long NoteID)
        {
            this.NoteID = NoteID;
            this.NoteEntity.LoadData(NoteID);
            this.txtNoteCode.Text = this.NoteEntity.NoteCode;
            this.txtBranchStoreName .Text =this.NoteEntity .BranchStoreName ;
            this.txtCheckPersons.Text = this.NoteEntity.CheckPersons;
            this.rchMemo.Text = this.NoteEntity.Memo;
            this.txtDateNote  .Text  = this.NoteEntity.DateNote.ToString ();
            this.dtblItems = this.accItems.GetDataStoreCheckItemsByNoteID(NoteID).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
        }
      
        void btnSave_Click(object sender, EventArgs e)
        {
            
            DialogResult rsl = MessageBox.Show("将进行并入账，\n一经保存将不能变更，确认否?",
               "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rsl == DialogResult.No) return;
            string errormsg=string .Empty ;
            bool flag = false;
            flag = this.accNotes.UpdateStoreCheckNotesForConfirm(ref errormsg,
                this.NoteID,
                JERPBiz.Frame.UserBiz.PsnID);
            if (!flag)
            {
                MessageBox.Show(errormsg);
                return;
            }
            int BranchStoreID=this.NoteEntity .BranchStoreID ;         
            foreach (DataRow drow in this.dtblItems.Rows )
            {
                if (drow["CheckQty"] == DBNull.Value)
                {
                    this.accItems.DeleteStoreCheckItems(ref errormsg,
                        drow["ItemID"]);
                    continue;
                } 
                if(drow["InitQty"]!=DBNull .Value )
                {
                    this.accStore .InsertStoreForInitStore (
                        ref errormsg ,
                        JERPBiz.Finance.NoteNameParm.PrdStoreCheckNoteNameID,
                        this.NoteID,
                        this.txtNoteCode .Text ,
                        drow["PrdID"],
                        BranchStoreID ,
                        drow["InitQty"] ,
                        drow["CostPrice"]);
                }
                if(drow["SurplusQty"]!=DBNull .Value )
                {
                        this.accStore.InsertStoreForCheckIntoStore(
                        ref errormsg,
                        JERPBiz.Finance.NoteNameParm.PrdStoreCheckNoteNameID,
                        this.NoteID,
                        this.txtNoteCode .Text ,
                        drow["PrdID"],
                        BranchStoreID ,
                        drow["SurplusQty"] ,
                        drow["CostPrice"]);
                 } 
                if (drow["LostQty"] != DBNull.Value)
                {
                    this.accStore.InsertStoreForCheckOutStore(ref errormsg,
                        JERPBiz.Finance.NoteNameParm.PrdStoreCheckNoteNameID,
                        NoteID,
                        this.txtNoteCode .Text ,
                        drow["PrdID"],
                        BranchStoreID ,
                        drow["LostQty"] ,
                        drow["CostPrice"]);
                }
                 
                //变更一下预留
                this.accStoreReserve.UpdateStoreReserveForAdjustStore(ref errormsg,
                    drow["PrdID"]);
              
            }
            MessageBox.Show("成功保存并入账当前盘点单");
            if (this.affterSave != null) this.affterSave();
            this.Close();
        }
    

    }
}