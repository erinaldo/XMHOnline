using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Material
{
    public partial class CtrlOutSrcSupplyItemConfirm : UserControl 
    {
        public CtrlOutSrcSupplyItemConfirm()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accItems = new JERPData.Material.OutSrcSupplyItems(); 
            this.accStore = new JERPData.Material.Store();
            this.accOutSrcStore = new JERPData.Material.OutSrcStore();
            this.accStoreReserve = new JERPData.Material.StoreReserve(); 
            this.accPrds = new JERPData.Product.Product(); 
            this.accExpenseAccount = new JERPData.Finance.ExpenseAccount();
            this.accOutSrcStore = new JERPData.Material.OutSrcStore(); 
            this.accOutSrcStoreReserve = new JERPData.Material.OutSrcStoreReserve(); 
            this.dgrdv.ContextMenuStrip = this.cMenu;
            this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click); 
            this.dgrdv.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdv_DataBindingComplete);  
         
        }

        private JERPData.Material.OutSrcSupplyItems accItems; 
        private JERPData.Product.Product accPrds; 
        private JERPData.Finance.ExpenseAccount accExpenseAccount;
        private DataTable  dtblItems;
        private JERPData.Material.Store accStore;
        private JERPData.Material.StoreReserve accStoreReserve; 
        private JERPData.Material.OutSrcStore accOutSrcStore;
        private JERPData.Material.OutSrcStoreReserve accOutSrcStoreReserve;
        private long NoteID = -1;
        private int CompanyID = -1;        
        private string NoteCode = string.Empty;
        private decimal GetStoreQty(int PrdID,int BranchStoreID)
        {
            decimal rut = 0;
            this.accStore.GetParmStoreInventoryQty  (PrdID,BranchStoreID,ref rut);
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
            decimal rut = 0;
            this.accOutSrcStore.GetParmOutSrcStoreInventoryQty(this.CompanyID, PrdID, ref rut);
            return rut;
        }
        private decimal GetCostPrice(int PrdID, int BranchStoreID)
        {
            decimal rut = 0;
            this.accStore.GetParmStoreInventoryPrice(PrdID,BranchStoreID , ref rut);
            return rut;
        }
        private decimal GetQuantity(object objMinPackingQty, decimal PlanQty)
        {
            if (objMinPackingQty == DBNull.Value) return PlanQty;
            if ((decimal)objMinPackingQty <= 0) return PlanQty;
            return Math.Ceiling(PlanQty / (decimal)objMinPackingQty) * (decimal)objMinPackingQty;
        }
        
   
        void dgrdv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow grow in this.dgrdv.Rows)
            {               
                grow.ErrorText = string.Empty;
                object objQuantity = grow.Cells[this.ColumnQuantity.Name].Value; 
                object objInventory = grow.Cells[this.ColumnStoreQty .Name].Value; 
                decimal Quantity = (objQuantity != DBNull.Value) ? (decimal)objQuantity : 0; 
                decimal InventoryQty = (objInventory != DBNull.Value) ? (decimal)objInventory : 0;
                if (InventoryQty <Quantity )
                {
                    grow.ErrorText = "库存不足";
                    continue;
                }              
                object objBranchStoreID = grow.Cells[this.ColumnBranchStoreID.Name].Value; 
                if ((objBranchStoreID == DBNull.Value) )
                {
                    grow.ErrorText = "未设任何库位";
                    continue;
                }
            }
        }

        void mItemRefresh_Click(object sender, EventArgs e)
        {
         
            foreach (DataRow drowItem in this.dtblItems.Rows)
            {
                int PrdID = (int)drowItem["PrdID"];
                drowItem["LastNonFinishedQty"] = this.GetLastNonFinishedQty(PrdID);
                drowItem["OutSrcInventoryQty"] = this.GetOutSrcStoreQty(PrdID);
                if (drowItem["BranchStoreID"] != DBNull.Value)
                {
                    drowItem["StoreQty"] = this.GetStoreQty(PrdID, (int)drowItem["BranchStoreID"]);
                }
            }
        }
         
        public void ClearItems()
        {
            this.dtblItems.Clear();
        }

        public void ConfirmOper(long NoteID,string NoteCode,int CompanyID)
        {
            this.NoteID = NoteID;
            this.NoteCode = NoteCode;
            this.CompanyID = CompanyID;
            this.dtblItems = this.accItems.GetDataOutSrcSupplyItemsByNoteID(NoteID).Tables[0];
            this.dtblItems.Columns.Add("StoreQty", typeof(decimal));
            decimal RequireQty, LastNonFinishedQty, OutSrcInventoryQty;
            int PrdID = -1;
            foreach (DataRow drowItem in this.dtblItems.Rows)
            {
                PrdID = (int)drowItem["PrdID"];              
                RequireQty = Convert .ToInt32 ((decimal)drowItem["RequireQty"]);
                LastNonFinishedQty = this.GetLastNonFinishedQty (PrdID);
                drowItem["LastNonFinishedQty"] = LastNonFinishedQty ;
                OutSrcInventoryQty = this.GetOutSrcStoreQty(PrdID);
                drowItem["OutSrcInventoryQty"] = OutSrcInventoryQty; 
                if (drowItem["BranchStoreID"] != DBNull.Value)
                {
                    drowItem["StoreQty"] = this.GetStoreQty(PrdID, (int)drowItem["BranchStoreID"]);
                }
            }
            this.dgrdv.DataSource = this.dtblItems;
        } 
        public bool ValidateData()
        {
            if (this.dtblItems.Rows.Count == 0)
            {
                MessageBox.Show("对不起,没有发送任何物料!");
                return false;
            }
            if (this.dtblItems.Select("Quantity>StoreQty").Length > 0)
            {
                MessageBox.Show("发料数不能大于库存数");
                return false;
            }
            return true;
        }
        public void Export()
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "委外发料单");
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(this.dgrdv , ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            FrmMsg.Hide();
            excel.Show();
        }
        public void Save()
        {
            string errormsg = string.Empty;
            bool flag = false;  
            int PrdID;
            decimal RequireQty = 0, Quantity = 0, OutSrcInventoryQty, LastNonFinishedQty,
               OutOutSrcStoreQty, IntoOutSrcStoreQty, NonFinishedQty;
            decimal TotalAMT = 0;
            object objCostPrice = DBNull.Value;
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
                if (LastNonFinishedQty + RequireQty >Quantity + OutSrcInventoryQty)
                {
                    NonFinishedQty = LastNonFinishedQty + RequireQty - Quantity - OutSrcInventoryQty;
                }
                flag = this.accItems.UpdateOutSrcSupplyItemsForConfirm (ref errormsg,
                 drow["ItemID"],
                 LastNonFinishedQty,
                 OutSrcInventoryQty, 
                 NonFinishedQty,
                 objCostPrice);
                if (Quantity > 0)
                {
                    //出库
                    this.accStore.InsertStoreForOutStore(ref errormsg,
                             JERPBiz.Finance.NoteNameParm.MtrOutSrcSupplyNoteNameID,
                              this.NoteID,
                              this.NoteCode,
                              PrdID,
                              drow["BranchStoreID"],
                              Quantity,
                              objCostPrice);
                    //预留出
                    this.accStoreReserve.SaveStoreReserveForSubReserve(ref errormsg,
                        PrdID,
                        Quantity);
                 
                }
                OutOutSrcStoreQty = (OutSrcInventoryQty > LastNonFinishedQty + RequireQty) ? (LastNonFinishedQty + RequireQty) : OutSrcInventoryQty;
                if (OutOutSrcStoreQty > 0)
                {
                    //委外出库
                    this.accOutSrcStore.InsertOutSrcStoreForOutStore(
                        ref errormsg,
                        JERPBiz.Material.OutSrcStoreNoteName.OutSrcSupplyNoteNameID,
                        JERPBiz.Material.OutSrcStoreNoteName.OutSrcSupplyNoteName,
                        this.NoteID,
                        this.NoteCode,
                        PrdID,
                        this.CompanyID,
                        OutOutSrcStoreQty,
                        objCostPrice);
                    //只要出货预留就减
                    this.accOutSrcStoreReserve.SaveOutSrcStoreReserveForSubReserve(
                        ref errormsg,
                        this.CompanyID,
                        PrdID,
                        OutOutSrcStoreQty);
                  
                }
                IntoOutSrcStoreQty = Quantity + OutOutSrcStoreQty - LastNonFinishedQty - RequireQty;
                // Quantity + OutSrcInventoryQty - LastNonFinishedQty - RequireQty-(OutSrcInventoryQty -OutOutSrcStoreQty ); //    
                //委外物料(入库)
                if (IntoOutSrcStoreQty > 0)
                {
                    this.accOutSrcStore.InsertOutSrcStoreForIntoStore(
                         ref errormsg,
                         JERPBiz.Material.OutSrcStoreNoteName.OutSrcSupplyNoteNameID,
                         JERPBiz.Material.OutSrcStoreNoteName.OutSrcSupplyNoteName,
                         this.NoteID,
                         this.NoteCode,
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
                    "委外发料单[" + NoteCode + "]",
                    JERPBiz.Finance.ExpenseTypeParm.MtrExpense,
                    TotalAMT,
                    JERPBiz.Frame.UserBiz.PsnID);
            }  
           
        }
 

    }
}