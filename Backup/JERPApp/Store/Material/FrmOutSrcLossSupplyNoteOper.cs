using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Material
{
    public partial class FrmOutSrcLossSupplyNoteOper : Form
    {
        public FrmOutSrcLossSupplyNoteOper()
        {
            InitializeComponent();
            
            this.dgrdv.AutoGenerateColumns = false;
            this.accItems = new JERPData.Material.OutSrcLossSupplyItems();
            this.accNotes = new JERPData.Material.OutSrcLossSupplyNotes();
            this.accStore = new JERPData.Material.Store();
            this.accStoreReserve = new JERPData.Material.StoreReserve();
            this.accBranchSotre = new JERPData.Material.BranchStore();
            this.NoteEntity = new JERPBiz.Material.OutSrcLossSupplyNoteEntity();  
            this.printhelper = new JERPBiz.Material.OutSrcLossSupplyNotePrintHelper();
            this.accExpenseAccount = new JERPData.Finance.ExpenseAccount();
            this.accStorePlace = new JERPData.Material.StorePlace();
            this.outstoreprint = new JERPBiz.Material.OutStoreNotePrintHelper();
            this.SetColumnSrc();
            this.dgrdv.CellValueChanged += new DataGridViewCellEventHandler(dgrdv_CellValueChanged);
            this.dgrdv.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdv_DataBindingComplete); 
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnExport.Click += new EventHandler(btnExport_Click);
          
        }

        private JERPData.Material.OutSrcLossSupplyNotes  accNotes;
        private JERPData.Material.OutSrcLossSupplyItems  accItems;
        private JERPData.Material.BranchStore accBranchSotre;
        private JERPBiz.Material.OutStoreNotePrintHelper outstoreprint;
        private DataTable  dtblItems,dtblBranchStores;
        private JERPData.Material.Store accStore;
        private JERPBiz.Material.OutSrcLossSupplyNoteEntity NoteEntity;
        private JERPBiz.Material.OutSrcLossSupplyNotePrintHelper printhelper;
        private JERPData.Material.StoreReserve accStoreReserve;
        private JERPData.Finance.ExpenseAccount accExpenseAccount;
        private JERPData.Material.StorePlace accStorePlace;
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
        private long NoteID = -1;
        private decimal GetStoreQty(int PrdID,int BranchStoreID)
        {
            decimal rut = 0;
            this.accStore.GetParmStoreInventoryQty (PrdID,BranchStoreID,ref rut);
            return rut;
        }
        
        private decimal GetCostPrice(int PrdID, int BranchStoreID)
        {
            decimal rut = 0;
            this.accStore.GetParmStoreInventoryPrice(PrdID,BranchStoreID , ref rut);
            return rut;
        } 
        private void SetColumnSrc()
        { 

            this.dtblBranchStores = this.accBranchSotre.GetDataBranchStore().Tables[0];
            this.ColumnBranchStoreID.DataSource = this.dtblBranchStores;
            this.ColumnBranchStoreID.ValueMember = "BranchStoreID";
            this.ColumnBranchStoreID.DisplayMember = "BranchStoreName";
 

        } 
        private object GetDefaultBranchStoreID(int PrdID)
        {
            int rut = 1;
            this.accStore.GetParmStoreDefaultBranchStoreID(PrdID, ref rut);
            if (rut > -1)
            {
                return rut;
            }
            return DBNull.Value;
        }
        private string GetBranchStoreName(int BranchStoreID)
        {
            DataRow[] drows = this.dtblBranchStores.Select("BranchStoreID=" + BranchStoreID.ToString());
            if (drows.Length > 0)
            {
                return drows[0]["BranchStoreName"].ToString();
            }
            return string.Empty;
        }
        private string GetStorePlace(int PrdID, int BranchStoreID)
        {
            string rut = string.Empty;
            this.accStorePlace.GetParmStorePlace(BranchStoreID, PrdID, ref rut);
            return rut;
        }

        void dgrdv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return; 
            if (this.dgrdv.Columns[icol].Name == this.ColumnBranchStoreID.Name)
            {
                object objBranchStoreID = this.dgrdv[this.ColumnBranchStoreID.Name, irow].Value;
                if (objBranchStoreID == DBNull.Value) return;
                object objPrdID = this.dgrdv[this.ColumnPrdID.Name, irow].Value;
                if (objPrdID == DBNull.Value) return;             
                this.dgrdv[this.ColumnInventoryQty.Name, irow].Value = this.GetStoreQty((int)objPrdID , (int)objBranchStoreID);
                this.dgrdv[this.ColumnBranchStoreName.Name, irow].Value = this.dgrdv[this.ColumnBranchStoreID.Name, irow].FormattedValue;
                this.dgrdv[this.ColumnStorePlace.Name, irow].Value = this.GetStorePlace((int)objPrdID, (int)objBranchStoreID);
            }           
        }
   
       
        public void ConfirmOper(long NoteID)
        {
            this.NoteID = NoteID;
            this.NoteEntity.LoadData(NoteID);
            this.txtNoteCode.Text = this.NoteEntity.NoteCode;
            this.txtCompanyAbbName.Text = this.NoteEntity.CompanyAbbName;
            this.txtDateNote.Text = this.NoteEntity.DateNote.ToShortDateString();
            this.txtSupplierAddress.Text = this.NoteEntity.SupplierAddress; 
            this.rchMemo.Text = this.NoteEntity.Memo; 
            this.dtblItems = this.accItems.GetDataOutSrcLossSupplyItemsByNoteID (NoteID).Tables[0];
            this.dtblItems.Columns.Add("InventoryQty", typeof(decimal));
            this.dtblItems.Columns.Add("StorePlace", typeof(string));
            foreach (DataRow drow in this.dtblItems.Rows)
            {
                drow["BranchStoreID"] = this.GetDefaultBranchStoreID((int)drow["PrdID"]);
                if (drow["BranchStoreID"] != DBNull.Value)
                {
                    drow["InventoryQty"] = this.GetStoreQty((int)drow["PrdID"], (int)drow["BranchStoreID"]);
                    drow["StorePlace"] = this.GetStorePlace((int)drow["PrdID"], (int)drow["BranchStoreID"]);
                    drow["BranchStoreName"] = this.GetBranchStoreName((int)drow["BranchStoreID"]);
                }
            }
            this.dgrdv.DataSource = this.dtblItems;  
        } 
        private bool ValidateData()
        {
           
            DataRow[] drows  = this.dtblItems.Select("BranchStoreID is null");
            if (drows.Length > 0)
            {
                MessageBox.Show("对不起,未设置任何库位");
                return false;
            }
            drows = this.dtblItems.Select("Quantity>InventoryQty");
            if (drows.Length > 0)
            {
                MessageBox.Show("对不起,当前库存存在不足,不能出货");
                return false;
            }  
         
            return true;
        }
       

        void dgrdv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow grow in this.dgrdv.Rows)
            { 
                object objQuantity = grow.Cells[this.ColumnQuantity.Name].Value;
                object objInventory = grow.Cells[this.ColumnInventoryQty.Name].Value;
                if ((objQuantity != DBNull.Value) && (objInventory != DBNull.Value))
                {
                    grow.ErrorText = ((decimal)objQuantity > (decimal)objInventory) ? "库存不足" : string.Empty;
                } 
            }
        }

        void btnExport_Click(object sender, EventArgs e)
        {
            this.outstoreprint.ExportToExcel(this.dtblItems.Select());
        }

    
        void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateData() == false) return;
            DialogResult rul = MessageBox.Show("将进行保存入账一经入账不能变更！", "审核确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return;
            string errormsg = string.Empty;
            bool flag = false;
            
            flag = this.accNotes.UpdateOutSrcLossSupplyNotesForConfirm(ref errormsg,
                this.NoteID ,
                JERPBiz.Frame.UserBiz.PsnID);
            if (!flag)
            {
                MessageBox.Show(errormsg);
                return;
            }      
            int PrdID;
            decimal Quantity = 0, TotalAMT = 0;
            object objCostPrice = DBNull.Value;
            foreach (DataRow drow in this.dtblItems.Rows )
            { 
                objCostPrice = DBNull.Value;
                PrdID = (int)drow["PrdID"];
                Quantity = (decimal)drow["Quantity"]; 
                objCostPrice = this.GetCostPrice(PrdID,(int)drow["BranchStoreID"]);
                TotalAMT += Quantity * (decimal)objCostPrice; 
                flag = this.accItems.UpdateOutSrcLossSupplyItemsForConfirm (ref errormsg,
                    drow["ItemID"], 
                   drow["BranchStoreID"],
                   objCostPrice ,
                   JERPBiz.Frame.UserBiz.PsnID);                
                //出库
                this.accStore.InsertStoreForOutStore(ref errormsg,
                         JERPBiz.Finance.NoteNameParm.MtrOutSrcLossSupplyNoteNameID ,
                          NoteID,
                          this.txtNoteCode .Text,
                          PrdID,
                          drow["BranchStoreID"],
                          Quantity,
                          objCostPrice);
                //预留出
                this.accStoreReserve.SaveStoreReserveForSubReserve(ref errormsg,
                    PrdID,
                    Quantity); 
            }
            if (TotalAMT > 0)
            {
                //生产领料单
                this.accExpenseAccount.InsertExpenseAccountForDebit(
                    ref errormsg,
                    "委外超损发料单[" + this.txtNoteCode .Text  + "]",
                    JERPBiz.Finance.ExpenseTypeParm.MtrExpense,
                    TotalAMT,
                    JERPBiz.Frame.UserBiz.PsnID);
            }

            rul = MessageBox.Show("将进行保存入账当前单据，是否需要打印输出?\n是,打印;否,取消", "操作确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {
                this.printhelper.ExportToExcel(NoteID);
            }
            if (this.affterSave != null) this.affterSave();
            this.Close();
        }
 

    }
}