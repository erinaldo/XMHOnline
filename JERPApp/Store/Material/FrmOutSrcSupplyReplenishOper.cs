using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Material
{
    public partial class FrmOutSrcSupplyNoteReplenishOper : Form
    {
        public FrmOutSrcSupplyNoteReplenishOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accItems = new JERPData.Material.OutSrcSupplyItems();
            this.accNotes = new JERPData.Material.OutSrcSupplyNotes();
            this.accStore = new JERPData.Material.Store(); 
            this.accStoreReserve = new JERPData.Material.StoreReserve();
            this.accOutSrcStore = new JERPData.Material.OutSrcStore();
            this.accOutSrcStoreReserve = new JERPData.Material.OutSrcStoreReserve();
            
            this.accBranchSotre = new JERPData.Material.BranchStore();
            this.accPrds = new JERPData.Product.Product();   
            this.accExpenseAccount = new JERPData.Finance.ExpenseAccount();
            this.SupplierEntity = new JERPBiz.General.SupplierEntity();
            this.SetColumnSrc();
            this.dgrdv.CellValueChanged += new DataGridViewCellEventHandler(dgrdv_CellValueChanged);
            this.dgrdv.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdv_DataBindingComplete);
            this.btnSave.Click += new EventHandler(btnSave_Click);
        }

    
        private JERPData.Material.OutSrcSupplyNotes accNotes;
        private JERPData.Material.OutSrcSupplyItems accItems;
        private JERPData.Material.Store accStore;
        private JERPData.Material.StoreReserve accStoreReserve; 

        private JERPData.Material.OutSrcStore accOutSrcStore;
        private JERPData.Material.OutSrcStoreReserve accOutSrcStoreReserve;  
        
        private JERPData.Product.Product accPrds;
        private JERPData.Material.BranchStore accBranchSotre;  
        private JERPData.Finance.ExpenseAccount accExpenseAccount;
        private JERPBiz.General.SupplierEntity SupplierEntity;
        private DataTable dtblItems, dtblBranchStores;
        private int CompanyID = -1;
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
        
        private decimal GetCostPrice(int PrdID,int BranchStoreID)
        {
            decimal rut = 0;
            this.accStore.GetParmStoreInventoryPrice(PrdID,BranchStoreID,ref rut);
            if (rut == 0)
            {
                this.accPrds.GetParmProductCostPrice(PrdID, ref rut);
            }
            return rut;
        }
        private decimal GetLastNonFinishedQty(int PrdID)
        {
            decimal rut = 0;
            this.accItems.GetParmOutSrcSupplyItemsLastNonFinishedQty(this.CompanyID,
                PrdID, ref rut);
            return rut;
        }
        private decimal GetOutSrcStoreQty(int PrdID)
        {
            decimal rut=0;
            this.accOutSrcStore.GetParmOutSrcStoreInventoryQty (this.CompanyID, PrdID, ref rut);
            return rut;
        }
        private decimal GetStoreQty(int PrdID, int BranchStoreID)
        {
            decimal rut = 0;
            this.accStore.GetParmStoreInventoryQty(PrdID, BranchStoreID, ref rut);
            return rut;
        }

        private decimal GetMinPackingQty(int PrdID)
        {
            decimal rut = 0;
            this.accPrds.GetParmProductMinPackingQty(PrdID, ref rut);
            return rut;
        }
     
        private decimal GetQuantity(decimal  MinPackingQty, decimal PlanQty)
        {
            if (MinPackingQty == 0) return PlanQty;
            return Math.Ceiling(PlanQty / MinPackingQty) * MinPackingQty;
        }
        private void LoadItems()
        {
            this.dtblItems =this.accItems .GetDataOutSrcSupplyItemsByNoteID (-1).Tables [0];
            this.dtblItems.Columns.Add("StoreQty", typeof(decimal));  
            DataTable dtblReplenishs = this.accItems .GetDataOutSrcSupplyItemsForReplenish (this.CompanyID).Tables[0];
            int PrdID=-1;
            decimal LastNonFinishedQty,OutSrcInventoryQty,Quantity;
            DataRow drowNew;
            foreach (DataRow drowReplenish in dtblReplenishs.Rows)
            {
                drowNew = this.dtblItems.NewRow();
                PrdID =(int)drowReplenish["PrdID"];
                drowNew["PrdID"] = PrdID;
                drowNew["PrdCode"] = drowReplenish["PrdCode"];
                drowNew["PrdName"] = drowReplenish["PrdName"];
                drowNew["PrdSpec"] = drowReplenish["PrdSpec"];
                drowNew["Model"] = drowReplenish["Model"]; 
                drowNew["UnitName"] = drowReplenish["UnitName"];
                LastNonFinishedQty = this.GetLastNonFinishedQty(PrdID);
                drowNew["LastNonFinishedQty"] = LastNonFinishedQty;
                drowNew["RequireQty"] = 0;
                OutSrcInventoryQty = this.GetOutSrcStoreQty(PrdID);
                drowNew["OutSrcInventoryQty"] = OutSrcInventoryQty;
                Quantity = (OutSrcInventoryQty >= LastNonFinishedQty) ? 0 : LastNonFinishedQty;
                drowNew["Quantity"] = this.GetQuantity(this.GetMinPackingQty (PrdID ), Quantity);
                drowNew["BranchStoreID"] = this.GetDefaultBranchStoreID(PrdID);
                if (drowNew["BranchStoreID"] != DBNull.Value)
                {
                    drowNew["StoreQty"] = this.GetStoreQty(PrdID, (int)drowNew["BranchStoreID"]);
                }
                this.dtblItems.Rows.Add(drowNew);
            }            
            this.dgrdv.DataSource = this.dtblItems;
        }
        public void NewNote(int CompanyID)
        {
            this.CompanyID = CompanyID;
            this.SupplierEntity.LoadData(CompanyID);
            this.ctrlSupplierAddress.LoadData(CompanyID);
            this.txtCompanyAbbName.Text = this.SupplierEntity.CompanyAbbName;
            this.dtpDateNote.Value = DateTime.Now.Date;            
            this.txtNoteCode.Text = string.Empty;
            this.rchMemo.Text = string.Empty;
            this.LoadItems();
        }
    
        void dgrdv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int icol = e.ColumnIndex; ;
            int irow = e.RowIndex;
            if ((irow == -1) || (icol == -1)) return;           
            if (this.dgrdv.Columns[icol].Name == this.ColumnBranchStoreID.Name)
            {
                object objBranchStoreID = this.dgrdv[icol, irow].Value;
                object objPrdID = this.dgrdv[this.ColumnPrdID.Name , irow].Value;
                if (objBranchStoreID == DBNull.Value) return;
                if ((objPrdID == DBNull.Value) || (objPrdID == null)) return;
                this.dgrdv[this.ColumnStoreQty .Name, irow].Value = this.GetStoreQty((int)objPrdID, (int)objBranchStoreID);
              
            }
           
            
        }

        bool ValidateData()
        {
          
            DataRow[] drows = this.dtblItems.Select("BranchStoreID is null or Quantity is null", "", DataViewRowState.CurrentRows);
            if (drows.Length > 0)
            {
                MessageBox.Show("对不起,未设置任何库位或数量为空的记录");
                return false;
            }
            drows = this.dtblItems.Select("Quantity>StoreQty", "", DataViewRowState.CurrentRows);
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
                          
                grow.ErrorText = string.Empty; 
                object objQuantity = grow.Cells[this.ColumnQuantity.Name].Value;
                if (objQuantity == DBNull.Value)
                {
                    grow.ErrorText = "数量不能为空";
                    continue;
                }
                object objBranchStoreID = grow.Cells[this.ColumnBranchStoreID.Name].Value;
                if (objBranchStoreID== DBNull.Value)
                {
                    grow.ErrorText = "未设任何库位";
                    continue;
                }
                object objStoreQty = grow.Cells[this.ColumnStoreQty.Name].Value;
                if ((objQuantity != DBNull.Value) && (objStoreQty != DBNull.Value))
                {
                    grow.ErrorText = ((decimal)objQuantity > (decimal)objStoreQty) ? "库存不足" : string.Empty;
                    continue ;
                }
               
               
               
            }
        }    
        void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateData() == false) return;
             DialogResult rul = MessageBox.Show("将进行保存入账一经入账不能变更！", "审核确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return;
            string errormsg = string.Empty;
            bool flag = false;
            long NoteID = -1;
            string NoteCode = string.Empty;
            object objNoteID = DBNull.Value;
            object objNoteCode = DBNull.Value;
            flag = this.accNotes.InsertOutSrcSupplyNotes (ref errormsg, 
                ref objNoteID,
                ref objNoteCode,
                this.dtpDateNote.Value.Date,
                this.CompanyID ,
                this.ctrlSupplierAddress.SupplierAddress ,
                JERPBiz.Frame.UserBiz.PsnID,
                this.rchMemo.Text);
            if (!flag)
            {
                MessageBox.Show(errormsg);
                return;
            }
            //设置为审核
            this.accNotes.UpdateOutSrcSupplyNotesForConfirm(ref errormsg, objNoteID, JERPBiz.Frame.UserBiz.PsnID);
            NoteID = (long)objNoteID;
            NoteCode = objNoteCode.ToString();
            this.txtNoteCode.Text = NoteCode;
            object objItemID = DBNull.Value;
            int PrdID;
            object objCostPrice = DBNull.Value;
            decimal TotalAMT = 0; 
            decimal LastNonFinishedQty,OutSrcInventoryQty, 
                 RequireQty, Quantity, IntoOutSrcStoreQty,OutOutSrcStoreQty,NonFinishedQty;
            foreach (DataRow drow in this.dtblItems.Rows )
            {
               
                PrdID = (int)drow["PrdID"];
                RequireQty = (decimal)drow["RequireQty"];
                Quantity = (decimal)drow["Quantity"];
                LastNonFinishedQty = this.GetLastNonFinishedQty(PrdID);
                OutSrcInventoryQty = this.GetOutSrcStoreQty(PrdID);
                objCostPrice = this.GetCostPrice(PrdID, (int)drow["BranchStoreID"]);
                TotalAMT += Quantity * (decimal)objCostPrice;
                NonFinishedQty = 0;
                if (LastNonFinishedQty + RequireQty>Quantity + OutSrcInventoryQty)
                {
                    NonFinishedQty = LastNonFinishedQty + RequireQty - Quantity - OutSrcInventoryQty;
                }
                objItemID = DBNull.Value;
                this.accItems.InsertOutSrcSupplyItems  (ref errormsg,
                  ref objItemID ,
                  NoteID,
                  PrdID,
                  RequireQty, 
                  drow["MinPackingQty"],
                  Quantity ,
                  drow["BranchStoreID"]   
                  );
                this.accItems.UpdateOutSrcSupplyItemsForConfirm(ref errormsg,
                    objItemID,
                    Quantity,
                    LastNonFinishedQty,
                    NonFinishedQty,
                    objCostPrice);
                if (Quantity > 0)
                {
                    //出库
                    this.accStore.InsertStoreForOutStore(ref errormsg,
                             JERPBiz.Finance.NoteNameParm.MtrOutSrcSupplyNoteNameID,
                              NoteID,
                              NoteCode,
                              PrdID,
                              drow["BranchStoreID"],
                              Quantity,
                              objCostPrice);
                    //预留出
                    this.accStoreReserve.SaveStoreReserveForSubReserve(ref errormsg,
                        PrdID,
                        Quantity);
                   
                }
                OutOutSrcStoreQty = (OutSrcInventoryQty> LastNonFinishedQty + RequireQty) ? (LastNonFinishedQty + RequireQty) : OutSrcInventoryQty;
                if (OutOutSrcStoreQty > 0)
                {
                    //委外出库
                    this.accOutSrcStore.InsertOutSrcStoreForOutStore(
                        ref errormsg,
                       JERPBiz.Material.OutSrcStoreNoteName.OutSrcSupplyNoteNameID,
                       JERPBiz.Material.OutSrcStoreNoteName.OutSrcSupplyNoteName,
                        NoteID,
                        NoteCode,
                        PrdID,
                        this.CompanyID,
                        OutOutSrcStoreQty,
                        objCostPrice
                        );
                    //只要出货预留就减
                    this.accOutSrcStoreReserve.SaveOutSrcStoreReserveForSubReserve(
                        ref errormsg,
                        this.CompanyID,
                        PrdID,
                        OutOutSrcStoreQty);
                     
                }
                IntoOutSrcStoreQty = Quantity + OutOutSrcStoreQty - LastNonFinishedQty - RequireQty; //  
                //委外物料(入库)
                if (IntoOutSrcStoreQty > 0)
                {
                    this.accOutSrcStore.InsertOutSrcStoreForIntoStore(
                          ref errormsg,
                          JERPBiz.Material.OutSrcStoreNoteName.OutSrcSupplyNoteNameID,
                         JERPBiz.Material.OutSrcStoreNoteName.OutSrcSupplyNoteName,
                          NoteID,
                          NoteCode,
                          PrdID,
                          this.CompanyID,
                          IntoOutSrcStoreQty,
                          objCostPrice);
                }  
            }
            if (TotalAMT > 0)
            {
                //生产领料单
                this.accExpenseAccount.InsertExpenseAccountForDebit(
                    ref errormsg,
                    "原料委外领料单[" + NoteCode + "]",
                    JERPBiz.Finance.ExpenseTypeParm.MtrExpense,
                    TotalAMT,
                    JERPBiz.Frame.UserBiz.PsnID);
            }  
            MessageBox.Show("成功保存并入账当前单据");
            if (this.affterSave != null) this.affterSave();
            this.Close();
        }

 

    }
}