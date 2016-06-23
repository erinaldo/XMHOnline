using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Product
{
    public partial class FrmSaleDeliverNoteConfirm : Form
    {
        public FrmSaleDeliverNoteConfirm()
        {
            InitializeComponent();
            this.dgrdvBox.AutoGenerateColumns = false;
            this.accNotes = new JERPData.Product .SaleDeliverNotes();
            this.accItems = new JERPData.Product.SaleDeliverItems(); 
            this.accOrderItems = new JERPData.Product.SaleOrderItems();
            this.NoteEntity = new JERPBiz.Product.SaleDeliverNoteEntity();
            this.accStore = new JERPData.Product.Store();
            this.accBranchStore = new JERPData.Product.BranchStore();
            this.accSettleType = new JERPData.Finance.SettleType();
            this.accStoreReserve = new JERPData.Product.StoreReserve(); 
            this.accCustomer = new JERPData.General.Customer();
            this.accOrderNotes = new JERPData.Product.SaleOrderNotes();
            this.PrintHelper = new JERPBiz.Product.SaleDeliverPrintHelper();
            this.accBoxes = new JERPData.Packing.Boxes();
            this.accBoxItems = new JERPData.Packing.BoxItems();
            this.accXBox = new JERPData.Product.SaleDeliverItemsXBox();
            this.BoxEntity = new JERPBiz.Packing.BoxEntity();
            foreach (DataGridViewColumn col in this.dgrdvItem.Columns)
            {
                col.ReadOnly = true;
            }
            this.ColumnBranchStoreID.ReadOnly = false;
            this.SetColumnSrc();
            this.dgrdvItem.AutoGenerateColumns = false;  
            this.dgrdvItem.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdvItem_DataBindingComplete);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.dgrdvBox.CellValueChanged += new DataGridViewCellEventHandler(dgrdvBox_CellValueChanged);
        }

        private JERPBiz.Packing.BoxEntity BoxEntity;
        private JERPData.Product.SaleDeliverNotes accNotes;
        private JERPData.Product.SaleDeliverItems accItems;
        private JERPData.Product.SaleOrderItems accOrderItems;
        private JERPData.Packing.Boxes accBoxes;
        private JERPData.Packing.BoxItems accBoxItems;
        private JERPData.Product.SaleDeliverItemsXBox accXBox;
        private JERPBiz.Product.SaleDeliverNoteEntity NoteEntity;
        private JERPData.Product.SaleOrderNotes accOrderNotes;
        private JERPData.Product.Store accStore;
        private JERPData.Product.BranchStore accBranchStore;
        private JERPData.Product.StoreReserve accStoreReserve; 
        private JERPData.General.Customer accCustomer;
        private JERPBiz.Product.SaleDeliverPrintHelper PrintHelper;
        private JERPData.Finance.SettleType accSettleType; 
        private DataTable  dtblItems, dtblBranchStores,dtblBoxes; 
        private bool CashSettleFlag = false;
        private long NoteID = -1;
        private long SaleOrderNoteID = -1;
        private decimal GetInventoryQty( int PrdID,int BranchStoreID)
        {
            decimal InventoryQty = 0;
            this.accStore.GetParmStoreInventoryQty(PrdID, BranchStoreID, ref InventoryQty);          
            return InventoryQty;
        }
        private void SetColumnSrc()
        {
            this.dtblBranchStores = this.accBranchStore.GetDataBranchStore().Tables[0];
            this.ColumnBranchStoreID.DataSource = this.dtblBranchStores;
            this.ColumnBranchStoreID.ValueMember = "BranchStoreID";
            this.ColumnBranchStoreID.DisplayMember = "BranchStoreName";
        }
        private object GetDefaultBranchStoreID(int PrdID)
        {
            int BranchStoreID = -1;
            this.accStore.GetParmStoreDefaultBranchStoreID(PrdID, ref BranchStoreID);
            if (BranchStoreID == -1) return DBNull.Value;
            return BranchStoreID;
        }
        public void ConfirmOper(long NoteID)
        {
            this.NoteID = NoteID;
            this.NoteEntity.LoadData(NoteID);
            this.CashSettleFlag = this.NoteEntity.CashSettleFlag;
            this.SaleOrderNoteID = this.NoteEntity.SaleOrderNoteID;
            this.txtNoteCode.Text = this.NoteEntity.NoteCode;
            this.txtPONo.Text = this.NoteEntity.PONo;
            this.txtCompanyAbbName.Text = this.NoteEntity.CompanyAbbName;         
            

            this.txtDeliverAddress .Text  = this.NoteEntity.DeliverAddress ;
            this.txtExpressRequire.Text = this.NoteEntity.ExpressRequire;
            this.txtFinanceAddress.Text = this.NoteEntity.FinanceAddress;
            this.txtDeliverTypeName.Text = this.NoteEntity.DeliverTypeName;
            this.txtDeliverPsnName.Text = this.NoteEntity.DeliverPsn;
            this.ckbFQCFlag .Checked  = this.NoteEntity.FQCFlag ;
            this.txtFQCConfirmPsn.Text = this.NoteEntity.FQCConfirmPsn  ;
            this.rchMemo.Text = this.NoteEntity.Memo;
            this.dtblItems = this.accItems .GetDataSaleDeliverItemsByNoteID (NoteID).Tables[0];
            this.dtblItems.Columns.Add("InventoryQty", typeof(decimal));
            foreach (DataRow drow in this.dtblItems .Rows)
            {
                drow["BranchStoreID"] = this.GetDefaultBranchStoreID((int)drow["PrdID"]);
                if (drow["BranchStoreID"] != DBNull.Value)
                {
                    drow["InventoryQty"] = this.GetInventoryQty((int)drow["PrdID"], (int)drow["BranchStoreID"]);
                }
            }
            this.dgrdvItem.DataSource = this.dtblItems;

            this.dtblBoxes = this.accBoxes.GetDataBoxesByBoxCode(string.Empty).Tables[0];
            this.dtblBoxes.Columns.Add("SaleDeliverItemID", typeof(long));
            this.dgrdvBox .DataSource = this.dtblBoxes;

            this.btnSave.Enabled = true;
            if ((this.NoteEntity.FQCFlag) && (this.NoteEntity.FQCConfirmPsnID == -1))
            {
                this.btnSave.Enabled = false;
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

        void dgrdvItem_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow grow in this.dgrdvItem.Rows)
            {
            
                grow.ErrorText = string.Empty;
                object objBranchStoreID = grow.Cells[this.ColumnBranchStoreID.Name].Value;
                if (objBranchStoreID == DBNull.Value)
                {
                    grow.ErrorText = "库位不能为空";
                    continue;
                }
                object objInventoryQty = grow.Cells[this.ColumnInventoryQty.Name].Value;              
                if (objInventoryQty != DBNull.Value)
                {
                  
                    object objQuantity = grow.Cells[this.ColumnQuantity .Name].Value;
                    if ((decimal)objInventoryQty < (decimal)objQuantity)
                    {
                        grow.ErrorText = "库存不足";
                        continue;
                    }
                }

            }
        }
        private int GetBoxCodeCount(string BoxCode)
        {
            int cnt = 0;
            foreach (DataGridViewRow grow in this.dgrdvBox .Rows)
            {
                if (grow.IsNewRow) continue;
                if (grow.Cells[this.ColumnBoxCode.Name].Value.ToString() == BoxCode)
                {
                    cnt++;
                    continue;
                }
            }
            return cnt;
        }
        private void SetGridRowNull(DataGridViewRow grow)
        {
            DataGridView dgrdv = grow.DataGridView;
            for (int j = 0; j < dgrdv.ColumnCount; j++)
            {
                grow.Cells[j].Value = DBNull.Value;
            }

        }
        void dgrdvBox_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            DataRow[] drowItems;
            if (this.dgrdvBox.Columns[icol].Name == this.ColumnBoxCode.Name)
            {
                string BoxCode = this.dgrdvBox [icol, irow].Value.ToString();
                DataGridViewRow grow = this.dgrdvBox.Rows[irow];
                int cnt = this.GetBoxCodeCount(BoxCode);
                if (cnt > 1)
                {
                    this.SetGridRowNull(grow);
                    return;
                   
                }
                bool Existflag = false;
                this.accBoxes.GetParmBoxesExistFlag(BoxCode, ref Existflag);
                if (Existflag == false)
                {
                    this.SetGridRowNull(grow);
                    return;
                }

                this.BoxEntity.LoadData(BoxCode);
                drowItems =this.dtblItems. Select("PrdID=" + this.BoxEntity.PrdID.ToString());
                if (drowItems.Length == 0)
                {
                    MessageBox.Show("出货单里没有此产品");
                    this.SetGridRowNull(grow);
                    return;
                }
                grow.Cells[this.ColumnSaleDeliverItemID.Name].Value = drowItems[0]["ItemID"];
                grow.Cells[this.ColumnPrdID.Name].Value = this.BoxEntity.PrdID;
                grow.Cells[this.ColumnPrdCode.Name].Value = this.BoxEntity.PrdCode;
                grow.Cells[this.ColumnPrdName.Name].Value = this.BoxEntity.PrdName;
                grow.Cells[this.ColumnPrdSpec.Name].Value = this.BoxEntity.PrdSpec;
                grow.Cells[this.ColumnModel.Name].Value = this.BoxEntity.Model;
                grow.Cells[this.ColumnQuantity.Name].Value = this.BoxEntity.Quantity;
            }
        }
        private decimal GetCostPrice(int PrdID, int BranchStoreID)
        {
            decimal rut = 0;
            this.accStore.GetParmStoreInventoryPrice(PrdID, BranchStoreID, ref rut);           
            return rut;
        }
        private bool ValidateData()
        {
            if (this.dtblItems.Select("BranchStoreID is null", "", DataViewRowState.CurrentRows).Length > 0)
            {
                MessageBox.Show("库位不能为空");
                return false;
            }
            if (this.dtblItems.Select("Quantity>InventoryQty", "", DataViewRowState.CurrentRows).Length > 0)
            {
                MessageBox.Show("存在送货数大于库存数的记录");
                return false;
            } 
            long ItemID;
            object objBoxQty;
            decimal Qty;
            foreach (DataRow drowItem in this.dtblItems.Rows)
            {
                ItemID = (long)drowItem["ItemID"];
                Qty = (decimal)drowItem["Quantity"];
                if (this.dtblBoxes.Rows.Count > 0)
                {
                    objBoxQty = this.dtblBoxes.Compute("SUM(Quantity)", "SaleDeliverItemID=" + ItemID.ToString());
                    if (objBoxQty == null) continue;
                    if ((decimal)objBoxQty > Qty)
                    {
                        MessageBox.Show("存在同产品装箱产品数大于出货数");
                        return false;
                    }
                }

            }
            return true;
        }
       
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateData() == false) return;
            DialogResult rul = MessageBox.Show("将进行保存入账一经确认不能变更！", "审核确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
         
            bool flag = false;
            string errormsg = string.Empty;  
            decimal TotalAMT = 0;         
            foreach (DataRow drow in this.dtblItems.Select("Price is not null and Quantity is not null", "", DataViewRowState.CurrentRows))
            {
                TotalAMT += (decimal)drow["Quantity"] * (decimal)drow["Price"];
            }
            flag = this.accNotes.UpdateSaleDeliverNotesForConfirm (
               ref errormsg,
               this.NoteID , 
               JERPBiz.Frame.UserBiz.PsnID);      
            if (!flag)
            {
                MessageBox.Show(errormsg,"操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } 
            //计算一下订单的完成金额
            if (this.SaleOrderNoteID > -1)
            {
                this.accOrderNotes.UpdateSaleOrderNotesForDeliverNoteAMT(ref errormsg,
                    this.SaleOrderNoteID);
            }
            
            //明细 
            decimal CostPrice=0;
            int PrdID=0;
            int BranchStoreID = -1; 
            decimal Quantity=0;
            foreach (DataRow drow in this.dtblItems.Rows )
            {
                
                PrdID=(int)drow["PrdID"];
                Quantity = (decimal)drow["Quantity"];
                BranchStoreID = (int)drow["BranchStoreID"];
                CostPrice = this.GetCostPrice(PrdID, BranchStoreID);
                //设进去
                this.accItems.UpdateSaleDeliverItemsForConfirm(ref errormsg,
                    drow["ItemID"],
                    BranchStoreID,
                    CostPrice);
              
                this.accStore.InsertStoreForOutStore(ref errormsg,
                    JERPBiz.Finance.NoteNameParm.PrdSaleDeliverNoteNameID,
                    this.NoteID,
                    this.txtNoteCode .Text ,
                    PrdID ,
                    BranchStoreID,
                    Quantity ,
                    CostPrice);
                this.accStoreReserve.SaveStoreReserveForSubReserve(ref errormsg,
                    PrdID,
                    Quantity); 
                
            }
            foreach (DataRow drow in this.dtblBoxes.Rows )
            {
                this.accXBox.SaveSaleDeliverItemsXBox(
                    ref errormsg,
                    drow["SaleDeliverItemID"],
                    drow["BoxCode"]);
                this.accItems.UpdateSaleDeliverItemsForBoxInfor(ref errormsg, drow["SaleDeiverItemID"]);
            }
            //变更客户营业额
            this.accCustomer.UpdateCustomerForTotalMainAMT(ref errormsg, this.NoteEntity.CompanyID);
            //订单的送货金额
            this.accOrderNotes.UpdateSaleOrderNotesForDeliverNoteAMT(ref errormsg, this.NoteEntity.SaleOrderNoteID);
                rul = MessageBox.Show("需要立即将打印吗?", "打印确认", MessageBoxButtons.OKCancel , MessageBoxIcon.Question);
            if (rul == DialogResult.OK )
            {
                this.PrintHelper.ExportToExcel(NoteID); 
            }
	        MessageBox.Show("成功出库当前送货单");
            if (this.affterSave != null) this.affterSave();
            this.Close();

        }

   
      
    }
}