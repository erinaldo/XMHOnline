using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Material
{
    public partial class CtrlOutStoreNoteOper : UserControl
    {
        public CtrlOutStoreNoteOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accItems = new JERPData.Material.OutStoreItems();
            this.accNotes = new JERPData.Material.OutStoreNotes();
            this.accStore = new JERPData.Material.Store();
            this.accStoreReserve = new JERPData.Material.StoreReserve(); 
            this.accBranchSotre = new JERPData.Material.BranchStore();
            this.accStorePlace = new JERPData.Material.StorePlace();
            this.accExpenseAccount = new JERPData.Finance.ExpenseAccount();
            this.accReplenishPlans = new JERPData.Material.OutStoreReplenishPlans();
            this.printhelper = new JERPBiz.Material.OutStoreNotePrintHelper();
            this.SetColumnSrc();          
            this.btnExport .Click +=new EventHandler(btnExport_Click);
            this.dgrdv.CellValueChanged += new DataGridViewCellEventHandler(dgrdv_CellValueChanged);
            this.dgrdv.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdv_DataBindingComplete);        
        }


        private JERPData.Material.OutStoreItems accItems;
        private JERPData.Material.OutStoreNotes accNotes;
        private JERPData.Material.BranchStore accBranchSotre;
        private JERPData.Finance.ExpenseAccount accExpenseAccount;
        private JERPData.Material.OutStoreReplenishPlans accReplenishPlans;
        private JERPBiz.Material.OutStoreNotePrintHelper printhelper;
        private DataTable dtblItems, dtblBranchStores;
        private JERPData.Material.Store accStore;
        private JERPData.Material.StoreReserve accStoreReserve;
        private JERPData.Material.StorePlace accStorePlace;
        private decimal GetStoreQty(int PrdID, int BranchStoreID)
        {
            decimal rut = 0;
            this.accStore.GetParmStoreInventoryQty(PrdID, BranchStoreID, ref rut);
            return rut;
        }
        private decimal GetReplenishQty(int PrdID)
        {
            decimal rut = 0;
            this.accReplenishPlans.GetParmOutStoreReplenishPlansQuantity(PrdID, ref rut);
            return rut;
        }
        private decimal GetCostPrice(int PrdID, int BranchStoreID)
        {
            decimal rut = 0;
            this.accStore.GetParmStoreInventoryPrice(PrdID, BranchStoreID, ref rut);
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
        private string GetStorePlace( int PrdID,int BranchStoreID)
        {
            string rut = string.Empty;
            this.accStorePlace.GetParmStorePlace(BranchStoreID, PrdID, ref rut);
            return rut;
        }
        void dgrdv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow grow in this.dgrdv.Rows)
            {
                if (grow.IsNewRow) continue;
                object objQuantity = grow.Cells[this.ColumnQuantity.Name].Value;
                object objInventory = grow.Cells[this.ColumnInventoryQty.Name].Value;
                if ((objQuantity != DBNull.Value) && (objInventory != DBNull.Value))
                {
                    grow.ErrorText = ((decimal)objQuantity > (decimal)objInventory) ? "库存不足" : string.Empty;
                }

            }
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
                this.dgrdv[this.ColumnBranchStoreName.Name, irow].Value = this.dgrdv[this.ColumnBranchStoreID.Name, irow].FormattedValue;
                this.dgrdv[this.ColumnInventoryQty.Name, irow].Value = this.GetStoreQty((int)objPrdID, (int)objBranchStoreID);
                this.dgrdv[this.ColumnStorePlace.Name, irow].Value = this.GetStorePlace((int)objPrdID, (int)objBranchStoreID);
            }
        }
        public void NoteOper()
        {
            this.dtblItems = this.accItems.GetDataOutStoreItemsByNoteID(-1).Tables[0];
            this.dtblItems.Columns.Add("RequireQty", typeof(decimal));
            this.dtblItems.Columns.Add("ReplenishQty", typeof(decimal));
            this.dtblItems.Columns.Add("InventoryQty", typeof(decimal)); 
            this.dgrdv.DataSource = this.dtblItems;
        }

        public void AppendItem(DataRow drowBom)
        {
            int PrdID = (int)drowBom["PrdID"];
            object objBranchStoreID;
            DataRow[] drowItems = this.dtblItems.Select("PrdID=" + PrdID.ToString());
            DataRow drowItem;
            if (drowItems.Length == 0)
            {
                drowItem = this.dtblItems.NewRow();
                drowItem["PrdID"] = PrdID;
                drowItem["PrdCode"] = drowBom["PrdCode"];
                drowItem["PrdName"] = drowBom["PrdName"];
                drowItem["PrdSpec"] = drowBom["PrdSpec"];
                drowItem["Manufacturer"] = drowBom["Manufacturer"];
                drowItem["UnitName"] = drowBom["UnitName"];
                drowItem["RequireQty"] = drowBom["RequireQty"];
                drowItem["ReplenishQty"] = this.GetReplenishQty(PrdID);
                drowItem["Quantity"] = (decimal)drowItem["RequireQty"]+(decimal)drowItem["ReplenishQty"];
                drowItem["InventoryQty"] = 0;
                objBranchStoreID = this.GetDefaultBranchStoreID(PrdID);
                drowItem["BranchStoreID"] = objBranchStoreID;
                if (objBranchStoreID != DBNull.Value)
                {
                    drowItem["InventoryQty"] = this.GetStoreQty(PrdID, (int)objBranchStoreID);
                    drowItem["StorePlace"] = this.GetStorePlace(PrdID, (int)objBranchStoreID);
                    drowItem["BranchStoreName"] = this.GetBranchStoreName((int)objBranchStoreID);
                }
            }
            else
            {
                drowItem = drowItems[0];
                drowItem["RequireQty"] = (decimal)drowItem["RequireQty"] + (decimal)drowBom ["RequireQty"];
                drowItem["Quantity"] = drowItem["RequireQty"];
            }
            if (drowItems.Length == 0)
            {
                this.dtblItems.Rows.Add(drowItem);
            }

        }
        public  bool ValidateData(out string ErrorMsg)
        {
            ErrorMsg = string.Empty;
            foreach (DataRow drow in this.dtblItems.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow["BranchStoreID"] != DBNull.Value)
                {
                    drow["InventoryQty"] = this.GetStoreQty((int)drow["PrdID"], (int)drow["BranchStoreID"]);
                }
            }
            DataRow[]  drows = this.dtblItems.Select("BranchStoreID is null");
            if (drows.Length > 0)
            {
                ErrorMsg ="对不起,未设置任何库位";
                return false;
            }
            drows = this.dtblItems.Select("Quantity>InventoryQty", "", DataViewRowState.CurrentRows);
            if (drows.Length > 0)
            {
                ErrorMsg ="对不起,当前库存存在不足,不能出库";
                return false;
            }
           
            return true;
        }
        public int RowCount
        {
            get
            {
                return this.dgrdv.RowCount;
            }
        }      
        public void Save()
        {
           
            string errormsg = string.Empty;
            bool flag = false;
            long NoteID = -1;
            string NoteCode = string.Empty;
            object objNoteID = DBNull.Value;
            object objNoteCode = DBNull.Value;
            flag = this.accNotes.InsertOutStoreNotes(ref errormsg,
                ref objNoteID,
                ref objNoteCode,
                DateTime .Now ,
                JERPBiz.Frame.UserBiz.PsnID,
                "生产领料");
            if (!flag)
            {
                MessageBox.Show(errormsg);
                return;
            }
            NoteID = (long)objNoteID;
            NoteCode = objNoteCode.ToString();
            decimal TotalAMT = 0;
            decimal CostPrice, Quantity,RequireQty,ReplenishQty;
            int PrdID, BranchStoreID; 
            foreach (DataRow drow in this.dtblItems.Rows)
            {
              
                PrdID = (int)drow["PrdID"];
                BranchStoreID =(int)drow["BranchStoreID"];
                RequireQty = (decimal)drow["RequireQty"];
                ReplenishQty = (decimal)drow["ReplenishQty"];
                Quantity = (drow["Quantity"] == DBNull.Value) ? 0 : (decimal)drow["Quantity"];
                CostPrice = this.GetCostPrice(PrdID, BranchStoreID);
                TotalAMT += Quantity * CostPrice;
                this.accItems.InsertOutStoreItems(ref errormsg,
                   NoteID,
                   PrdID,
                   Quantity,
                   BranchStoreID, 
                   CostPrice);
                //出库
                this.accStore.InsertStoreForOutStore(ref errormsg,
                         JERPBiz.Finance.NoteNameParm.MtrOutStoreNoteNameID,
                          NoteID,
                          NoteCode,
                          PrdID,
                         BranchStoreID,
                          Quantity,
                          CostPrice);
                //预留出
                this.accStoreReserve.SaveStoreReserveForSubReserve(ref errormsg,
                    PrdID,
                    Quantity);
              
                //先假定完成的是扣除部分
                this.accReplenishPlans.UpdateOutStoreReplenishPlansForFinishedQty(ref errormsg,
                    PrdID,
                    ReplenishQty);
                if (ReplenishQty + RequireQty > Quantity)
                {
                    this.accReplenishPlans.SaveOutStoreReplenishPlans(ref errormsg,
                        PrdID,
                        ReplenishQty  + RequireQty - Quantity);
                }
               
            }
            if (TotalAMT > 0)
            {
                //生产领料单
                this.accExpenseAccount.InsertExpenseAccountForDebit(
                    ref errormsg,
                    "原料领料单[" + NoteCode + "]",
                    JERPBiz.Finance.ExpenseTypeParm.MtrExpense,
                    TotalAMT,
                    JERPBiz.Frame.UserBiz.PsnID);
            }

        }
        void btnExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            this.printhelper.ExportToExcel(this.dtblItems.Select());
            FrmMsg.Hide();
           
        }
        
    }
}
