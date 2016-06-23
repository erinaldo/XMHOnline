using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Sale
{
    public partial class FrmSaleDeliverAlterOper : Form
    {
        public FrmSaleDeliverAlterOper()
        {
            InitializeComponent();
            this.accNotes = new JERPData.Product.SaleDeliverNotes();
            this.accItems = new JERPData.Product.SaleDeliverItems();
            this.NoteEntity = new JERPBiz.Product.SaleDeliverNoteEntity();
            this.printhelper = new JERPBiz.Product.SaleDeliverPrintHelper();
            this.accOrderItems = new JERPData.Product.SaleOrderItems();
            this.accOrderNotes = new JERPData.Product.SaleOrderNotes();
            this.accPlanItems = new JERPData.Product.SaleDeliverPlanItems();
            this.accSettleType = new JERPData.Finance.SettleType();
            this.accIntoStoreItems = new JERPData.Product.IntoStoreItems();
            this.accIntoStoreNotes = new JERPData.Product.IntoStoreNotes();
            this.accStore = new JERPData.Product.Store();
            this.accStoreReserve = new JERPData.Product.StoreReserve();
            this.accPrds = new JERPData.Product.Product();
            this.accCustomer = new JERPData.General.Customer();
            this.accBranchStores = new JERPData.Product.BranchStore();
            this.MoneyTypeParm = new JERPBiz.Finance.MoneyTypeParm();
            this.accItemXBox = new JERPData.Product.SaleDeliverItemsXBox();
            this.dgrdv.AutoGenerateColumns = false;
            this.dtblPrds = this.accPrds.GetDataProduct().Tables[0];
            this.dtblBranchStore = this.accBranchStores.GetDataBranchStore().Tables[0];
            this.btnAddItem.Click += new EventHandler(btnAddItem_Click);
            this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.FormClosed += new FormClosedEventHandler(FrmSaleDeliverAlter_FormClosed);
            
    
        }


        private JERPData.Product.SaleDeliverNotes accNotes;
        private JERPData.Product.SaleDeliverItems accItems;
        private JERPData.Product.SaleOrderItems accOrderItems;
        private JERPData.Product.SaleDeliverItemsXBox accItemXBox;
        private JERPData.Product.SaleDeliverPlanItems accPlanItems;
        private JERPData.Product.SaleOrderNotes accOrderNotes;
        private JERPData.Finance.SettleType accSettleType;
        private JERPBiz.Product.SaleDeliverPrintHelper printhelper;
        private JERPBiz.Product.SaleDeliverNoteEntity NoteEntity;
        private JERPData.Product.Store accStore;
        private JERPData.Product.BranchStore accBranchStores;
        private JERPData.Product.StoreReserve accStoreReserve;
        private JERPData.Product.Product accPrds;
        private JERPData.Product.IntoStoreItems  accIntoStoreItems;
        private JERPData.Product.IntoStoreNotes  accIntoStoreNotes;
        private JERPData.General.Customer accCustomer;
        private JERPBiz.Finance.MoneyTypeParm MoneyTypeParm;
        private FrmSaleDeliverItemAppend frmItemOper;
        private DataTable dtblItems, dtblBranchStore, dtblPrds;
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
        public void EditNote(long NoteID)
        {
            this.NoteID = NoteID;
            this.NoteEntity.LoadData(NoteID);
            bool AllowAlterFlag = this.GetAllowAlterFlag(NoteID);
            this.dgrdv.AllowUserToDeleteRows = AllowAlterFlag;
            this.btnAddItem.Enabled = AllowAlterFlag;
            this.txtNoteCode.Text = this.NoteEntity.NoteCode;
            this.txtPONo.Text = this.NoteEntity.PONo;
            this.txtIntoStoreNoteCode.Text = this.NoteEntity.IntoStoreNoteCode;
            this.txtCompanyAbbName.Text = this.NoteEntity.CompanyAbbName;
            this.txtDeliverAddress.Text = this.NoteEntity.DeliverAddress;  
            this.txtDateNote.Text = this.NoteEntity.DateNote.ToShortDateString();
            this.rchMemo.Text = this.NoteEntity.Memo;
            this.ColumnPrice.Visible = (this.NoteEntity.SaleOrderNoteID == -1);
            this.LoadItem();
        }
        private long noteID = -1;
        private long NoteID
        {
            get
            {
                return this.noteID;
            }
            set
            {
                this.noteID = value;
            }
        }
        private decimal GetCostPrice(int PrdID, int BranchStoreID)
        {
            decimal rut = 0;
            this.accStore.GetParmStoreInventoryPrice(PrdID, BranchStoreID, ref rut);           
            return rut;
        }
        private decimal GetIntoStoreCostPrice(int PrdID)
        {
            decimal rut = 0;
            this.accPrds.GetParmProductCostPrice(PrdID, ref rut);
            return rut;
        }
        private void LoadItem()
        {
            this.dtblItems = this.accItems.GetDataSaleDeliverItemsByNoteID(this.NoteID).Tables[0]; 
            this.dgrdv.DataSource = this.dtblItems;
        }
        private bool GetAllowAlterFlag(long NoteID)
        {
            bool flag = false;
            this.accNotes.GetParmSaleDeliverNotesAllowAlterFlag(NoteID, ref flag);
            return flag;
        }
   
        void dgrdv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
           
            DataRow drow = this.dtblItems .DefaultView[irow].Row;           
            string errormsg = string.Empty;
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {
                //计划回归
                this.accPlanItems.UpdateSaleDeliverPlanItemsForFinishedQty(
                        ref errormsg,
                        drow["SaleDeliverPlanItemID"]); 
                if (drow["SaleOrderItemID"] != DBNull.Value)
                {
                    //订单回搞
                    this.accOrderItems.UpdateSaleOrderItemsForSubFinishedQty (ref errormsg, drow["SaleOrderItemID"],
                        drow["Quantity"]);
                }                          
                //删除订单明细
                this.accItems.DeleteSaleDeliverItems(ref errormsg, drow["ItemID"]);
                this.accItemXBox.DeleteSaleDeliverItemsXBoxBatch(ref errormsg, drow["ItemID"]);
                //弄一入库单
                object objNoteID = DBNull .Value ;
                object objNoteCode=DBNull .Value ;
                bool flag=this.accIntoStoreNotes.InsertIntoStoreNotes(ref errormsg,
                    ref objNoteID,
                    ref objNoteCode,
                    DateTime.Now.Date,
                    JERPBiz.Frame.UserBiz.PsnID,
                    "销售送货项删除");               
                //明细
                decimal CostPrice = this.GetIntoStoreCostPrice((int)drow["PrdID"]);
                this.accIntoStoreItems.InsertIntoStoreItems (ref errormsg, 
                    objNoteID, 
                    DBNull .Value ,
                    drow["PrdID"],
                    drow["Quantity"],
                    drow["BranchStoreID"],
                    CostPrice , 
                    DBNull.Value);
                //入库
                this.accStore.InsertStoreForIntoStore(ref errormsg,
                    JERPBiz.Finance.NoteNameParm.PrdIntoStoreNoteNameID,
                    objNoteID,
                    objNoteCode,
                    drow["PrdID"],
                    drow["BranchStoreID"],
                    drow["Quantity"],
                    CostPrice );
                this.SaveTotalAMT();
              
            
            }
            else
            {
                e.Cancel = true;
            }
        }  

        void btnAddItem_Click(object sender, EventArgs e)
        {
        
            if (this.frmItemOper == null)
            {
                this.frmItemOper = new FrmSaleDeliverItemAppend();
                new FrmStyle(this.frmItemOper).SetPopFrmStyle(this);
                this.frmItemOper.AffterAppend += new FrmSaleDeliverItemAppend.AffterAppendDelegate(frmItemOper_AffterAppend);
            }
            this.frmItemOper.DeliverItemAppend(this.NoteEntity.SaleDeliverPlanNoteID ,this.NoteID );
            this.frmItemOper.ShowDialog();
             
        }

        void frmItemOper_AffterAppend(DataRow drow)
        {
            if (this.dtblItems.Select("SaleDeliverPlanItemID=" + drow["ItemID"].ToString(), "", DataViewRowState.CurrentRows).Length > 0)
            {
                return;
            }
            DataRow drowNew = this.dtblItems.NewRow();
            drowNew["SaleDeliverPlanItemID"] = drow["ItemID"];
            drowNew["SaleOrderItemID"] = drow["SaleOrderItemID"];
            drowNew["PrdID"] = drow["PrdID"];
            DataRow[] drowPrds = this.dtblPrds.Select("PrdID=" + drow["PrdID"].ToString());
            if (drowPrds.Length > 0)
            {
                drowNew["PrdCode"] = drowPrds[0]["PrdCode"];
                drowNew["PrdName"] = drowPrds[0]["PrdName"];
                drowNew["PrdSpec"] = drowPrds[0]["PrdSpec"];
                drowNew["Model"] = drowPrds[0]["Model"];
                drowNew["UnitName"] = drowPrds[0]["UnitName"];
            }
            
            drowNew["BranchStoreID"] = drow["BranchStoreID"];
            DataRow[] drowBranchStores = this.dtblBranchStore.Select("BranchStoreID=" + drow["BranchStoreID"].ToString());
            if (drowBranchStores.Length > 0)
            {
                drowNew["BranchStoreName"] = drowBranchStores[0]["BranchStoreName"]; 
            }
            drowNew["Quantity"] = drow["DeliverQty"];
            drowNew["Price"] = drow["Price"];
            drowNew["CostPrice"] = this.GetCostPrice((int)drow["PrdID"],(int)drow["BranchStoreID"]); 
            drowNew["Memo"] = drow["Memo"];
            this.dtblItems.Rows.Add(drowNew);
            MessageBox.Show("成功追加送货明细");

        }
    
      
        private void SaveTotalAMT()
        {
            string errormsg = string.Empty;
            decimal TotalAMT = 0;
            foreach (DataRow drow in this.dtblItems.Select("Price is not null", "", DataViewRowState.CurrentRows))
            {
                TotalAMT += (decimal)drow["Price"] * (decimal)drow["Quantity"];
            }
            this.accNotes.UpdateSaleDeliverNotesForTotalAMT(ref errormsg, this.NoteID,
                TotalAMT);
            if (this.NoteEntity.SaleOrderNoteID > -1)
            {
                this.accOrderNotes.UpdateSaleOrderNotesForDeliverNoteAMT(ref errormsg,
                    this.NoteEntity.SaleOrderNoteID);
            }
        }
        
        void btnSave_Click(object sender, EventArgs e)
        {
            string errormsg = string.Empty;
            this.SaveTotalAMT();
            decimal TotalAMT = 0;
            foreach (DataRow drow in this.dtblItems.Select("ItemID is null and Price is not null", "", DataViewRowState.CurrentRows))
            {
                TotalAMT += (decimal)drow["Price"] * (decimal)drow["Quantity"];
            }          
           
            object objItemID = DBNull.Value;
            foreach (DataRow drow in this.dtblItems.Select("ItemID is null", "", DataViewRowState.CurrentRows))
            {
                //保存到送货项里      
              
                    this.accItems.InsertSaleDeliverItems(ref errormsg,
                        ref objItemID,
                        this.NoteID, 
                        drow["SaleDeliverPlanItemID"], 
                        drow["Quantity"],  
                        drow["Memo"]);
                    //设进去
                    this.accItems.UpdateSaleDeliverItemsForConfirm(ref errormsg,
                        objItemID,
                        drow["BranchStoreID"],
                        drow["CostPrice"]);
                    //增加完成数
                    this.accPlanItems.UpdateSaleDeliverPlanItemsForFinishedQty(
                        ref errormsg,
                        drow["SaleDeliverPlanItemID"]);

                    if (drow["SaleOrderItemID"] != DBNull.Value)
                    {
                        //增加PO完成数
                        this.accOrderItems.UpdateSaleOrderItemsForAppFinishedQty (ref errormsg,
                             drow["SaleOrderItemID"],
                             drow["Quantity"]);
                    } 
                    drow["ItemID"] = objItemID;
                    //直接给我出库          
                    this.accStore.InsertStoreForOutStore(ref errormsg,
                        JERPBiz.Finance.NoteNameParm.PrdSaleDeliverNoteNameID,
                        this.NoteID,
                        this.NoteEntity.NoteCode,
                        drow["PrdID"],
                        drow["BranchStoreID"],
                        drow["Quantity"],
                        drow["CostPrice"]);
                    this.accStoreReserve.SaveStoreReserveForSubReserve(ref errormsg, drow["PrdID"], drow["Quantity"]);
                    
            }
            this.accNotes.UpdateSaleDeliverNotesForIntoStoreNoteCode(ref errormsg,
                this.NoteID,
                this.txtIntoStoreNoteCode.Text);
            FrmMsg.Show("成功进行送货单变更，正在生成打印文档，请稍候......");
            this.printhelper.ExportToExcel(this.NoteID);
            FrmMsg.Hide();            
            this.Close();
        }

        void FrmSaleDeliverAlter_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.affterSave != null) this.affterSave();
        }
    }
}