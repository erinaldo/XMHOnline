using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Material
{
    public partial class CtrlOutStoreReplenishOper : UserControl
    {
        public CtrlOutStoreReplenishOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false; 
            this.accItems = new JERPData.Material.OutStoreItems();
            this.accNotes = new JERPData.Material.OutStoreNotes();
            this.accStore = new JERPData.Material.Store();
            this.accStoreReserve = new JERPData.Material.StoreReserve(); 
            this.accBranchSotre = new JERPData.Material.BranchStore();
            this.accExpenseAccount = new JERPData.Finance.ExpenseAccount();
            this.accReplenishPlans = new JERPData.Material.OutStoreReplenishPlans();
            this.SetColumnSrc();
            this.dgrdv.ContextMenuStrip = this.cMenu;
            this.mItemExport.Click += new EventHandler(mItemExport_Click); 
            this.dgrdv.CellValueChanged += new DataGridViewCellEventHandler(dgrdv_CellValueChanged);
            this.dgrdv.CellMouseClick += new DataGridViewCellMouseEventHandler(dgrdv_CellMouseClick);
            this.dgrdv.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdv_DataBindingComplete);        
        }


        private JERPData.Material.OutStoreItems accItems;
        private JERPData.Material.OutStoreNotes accNotes;
        private JERPData.Material.BranchStore accBranchSotre;
        private JERPData.Finance.ExpenseAccount accExpenseAccount;
        private JERPData.Material.OutStoreReplenishPlans accReplenishPlans;
        private DataTable dtblItems, dtblBranchStores;
        private JERPData.Material.Store accStore;
        private JERPData.Material.StoreReserve accStoreReserve; 
        private decimal GetStoreQty(int PrdID, int BranchStoreID)
        {
            decimal rut = 0;
            this.accStore.GetParmStoreInventoryQty(PrdID, BranchStoreID, ref rut);
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
        void dgrdv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnQuantity.Name )
            {
                if (e.Button ==MouseButtons .Left )
                {
                    object objQuantity = this.dgrdv[icol, irow].Value;
                    if (objQuantity == DBNull.Value)
                    {
                        object objReplenishQty = this.dgrdv [this.ColumnReplenishQty .Name,irow].Value;
                        object objInventory =this.dgrdv [this.ColumnInventoryQty.Name,irow].Value;
                        if ((objReplenishQty != DBNull.Value) && (objInventory != DBNull.Value))
                        {
                            this.dgrdv[icol, irow].Value = ((decimal)objReplenishQty > (decimal)objInventory) ? objInventory : objReplenishQty;
                        }
                    }
                }
                if (e.Button == MouseButtons.Right)
                {
                    this.dgrdv[icol, irow].Value = DBNull.Value;
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
                this.dgrdv[this.ColumnInventoryQty.Name, irow].Value = this.GetStoreQty((int)objPrdID, (int)objBranchStoreID);
            }
        }
        public void NoteOper()
        {
            this.dtblItems = this.accReplenishPlans.GetDataOutStoreReplenishPlans ().Tables[0];
            this.dtblItems.Columns.Add("BranchStoreID", typeof(int));
            this.dtblItems.Columns.Add("ReplenishQty", typeof(decimal));
            this.dtblItems.Columns.Add("InventoryQty", typeof(decimal));
            object objBranchStoreID = DBNull.Value;
            int PrdID = -1;
            foreach (DataRow drow in this.dtblItems.Rows)
            {
                PrdID = (int)drow["PrdID"];
                drow["ReplenishQty"] = drow["Quantity"];
                drow["Quantity"] = DBNull.Value;
                objBranchStoreID = this.GetDefaultBranchStoreID(PrdID);
                drow["BranchStoreID"] = objBranchStoreID;
                drow["InventoryQty"] = 0;
                if (objBranchStoreID != DBNull.Value)
                {
                    drow["InventoryQty"] = this.GetStoreQty(PrdID, (int)objBranchStoreID);
                }
            }
            this.dgrdv.DataSource = this.dtblItems;
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
            DataRow[]  drows = this.dtblItems.Select("BranchStoreID is null and Quantity is not null");
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
            if (this.dtblItems.Select("Quantity is not null", "", DataViewRowState.CurrentRows).Length == 0)
            {
                return;
            }
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
                "生产补料");
            if (!flag)
            {
                MessageBox.Show(errormsg);
                return;
            }
            NoteID = (long)objNoteID;
            NoteCode = objNoteCode.ToString();
            decimal TotalAMT = 0;
            decimal CostPrice, Quantity,ReplenishQty;
            int PrdID, BranchStoreID; 
            foreach (DataRow drow in this.dtblItems.Rows)
            {
                if (drow["Quantity"] == DBNull.Value) continue;
                PrdID = (int)drow["PrdID"];
                BranchStoreID =(int)drow["BranchStoreID"]; 
                ReplenishQty = (decimal)drow["ReplenishQty"];
                Quantity = (decimal)drow["Quantity"];
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
                if (ReplenishQty > Quantity)
                {
                    this.accReplenishPlans.SaveOutStoreReplenishPlans(ref errormsg,
                        PrdID,
                        ReplenishQty  - Quantity);
                }
               
            }
            if (TotalAMT > 0)
            {
                //生产领料单
                this.accExpenseAccount.InsertExpenseAccountForDebit(
                    ref errormsg,
                    "原料补料单[" + NoteCode + "]",
                    JERPBiz.Finance.ExpenseTypeParm.MtrExpense,
                    TotalAMT,
                    JERPBiz.Frame.UserBiz.PsnID);
            }

        }
        void mItemExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "生产补料单");
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            FrmMsg.Hide();
            excel.Show();
        }
        
    }
}
