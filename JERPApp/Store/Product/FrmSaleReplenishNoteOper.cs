using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Product
{
    public partial class FrmSaleReplenishNoteOper : Form
    {
        public FrmSaleReplenishNoteOper()
        {
            InitializeComponent();
            this.accNotes = new JERPData.Product .SaleReplenishNotes();
            this.accItems = new JERPData.Product.SaleReplenishItems();
            this.accReplenishPlans = new JERPData.Product.SaleReplenishPlans();
            this.accStoreReserve = new JERPData.Product.StoreReserve();
            this.accStore = new JERPData.Product.Store();
            this.dgrdvItem.AutoGenerateColumns = false;
            this.accBranchStore = new JERPData.Product.BranchStore();
            this.PrintHelper = new JERPBiz.Product.SaleReplenishPrintHelper();
            this.SetColumnDataSrc();
            this.dgrdvItem.CellMouseClick += new DataGridViewCellMouseEventHandler(dgrdvItem_CellMouseClick);
            this.dgrdvItem.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdvItem_DataBindingComplete);
            this.btnSave .Click +=new EventHandler(btnSave_Click);
            this.btnFromBox .Click +=new EventHandler(btnFromBox_Click);
        }

     

     
        private JERPData.Product.SaleReplenishNotes accNotes;
        private JERPData.Product.SaleReplenishItems accItems;
        private JERPData.Product.SaleReplenishPlans accReplenishPlans;
        private JERPData.Product.BranchStore accBranchStore;
        private JERPData.Product.Store accStore;
        private JERPData.Product.StoreReserve accStoreReserve;
        private JERPBiz.Product.SaleReplenishPrintHelper PrintHelper;
        private JERPApp.Define.Packing.FrmBoxFromBarcode frmBox;
        private DataTable  dtblItems, dtblBranchStore;      
        private void SetColumnDataSrc()
        {
            this.dtblBranchStore = this.accBranchStore.GetDataBranchStore ().Tables[0];
            this.ColumnBranchStoreID.DataSource = this.dtblBranchStore;
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
       
     
        private int CompanyID = -1;
        public void NewNote(int CompanyID,string CompanyAbbName)
        {
            this.CompanyID = CompanyID;
            this.txtCompanyAbbName.Text = CompanyAbbName;
            this.tpkDateNote.Value = DateTime.Now.Date;
            this.txtNoteCode.Text = string.Empty;
            this.rchMemo.Text = string.Empty;
            this.ctrlDeliverAddressID.LoadData(CompanyID);
            this.dtblItems = this.accReplenishPlans.GetDataSaleReplenishPlansByCompanyID(CompanyID).Tables[0];
            this.dtblItems.Columns.Add("BranchStoreID", typeof(int));  
            this.dtblItems.Columns.Add("ReplenishQty", typeof(decimal));
            this.dtblItems.Columns.Add("InventoryQty", typeof(decimal)); 
            this.dtblItems.Columns.Add("Memo", typeof(decimal));
            object objBranchStoreID=DBNull .Value ;
            foreach (DataRow drow in this.dtblItems.Rows)
            {
                objBranchStoreID= this.GetDefaultBranchStoreID((int)drow["PrdID"]);
                drow["BranchStoreID"]=objBranchStoreID ;
                if (objBranchStoreID != DBNull.Value)
                {
                    drow["InventoryQty"] = this.GetStoreQty((int)drow["PrdID"], (int)objBranchStoreID);
                }
                
            }
            this.dgrdvItem.DataSource = this.dtblItems;

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
      
        void dgrdvItem_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvItem.Columns[icol].DataPropertyName == "ReplenishQty")
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (this.dgrdvItem[icol, irow].Value == DBNull.Value)
                    {
                        decimal NonFinishedQty = (decimal)this.dgrdvItem[this.ColumnQuantity .Name, irow].Value;
                        decimal StoreQty = (decimal)this.dgrdvItem[this.ColumnInventoryQty.Name, irow].Value;
                        this.dgrdvItem[icol, irow].Value = (NonFinishedQty >= StoreQty) ? StoreQty : NonFinishedQty;
                    }
                }
                if (e.Button == MouseButtons.Right)
                {
                    this.dgrdvItem[icol, irow].Value = DBNull.Value;
                }
            }
        }
        void btnFromBox_Click(object sender, EventArgs e)
        {
            if (frmBox == null)
            {
                frmBox = new JERPApp.Define.Packing.FrmBoxFromBarcode();
                new FrmStyle(frmBox).SetPopFrmStyle(this);
                frmBox.AffterSelect += new JERPApp.Define.Packing.FrmBoxFromBarcode.AffterConfirmDelegate(frmBox_AffterSelect);
            }
            System.Collections.Hashtable Has = new System.Collections.Hashtable();
            foreach (DataRow drow in this.dtblItems.Rows)
            {
                Has.Add((int)drow["PrdID"], (int)drow["PrdID"]);
            }
            frmBox.New(Has);
            frmBox.ShowDialog();
        }

        void frmBox_AffterSelect(DataRow drowBox)
        {
            DataRow[] drowItems = this.dtblItems.Select("PrdID=" + drowBox["PrdID"].ToString(), "", DataViewRowState.CurrentRows);
            DataRow drowItem;
            if (drowItems.Length == 0) return;
            drowItem = drowItems[0];
            if (drowItem["ReplenishQty"] == DBNull.Value)
            {
                drowItem["ReplenishQty"] = drowBox["Quantity"];
            }
            else
            {
                drowItem["ReplenishQty"] = (decimal)drowItem["ReplenishQty"] + (decimal)drowBox["Quantity"];
            }
             
        }
         private decimal GetStoreQty(int PrdID, int BranchStoreID)
        {
            decimal rut = 0;
            this.accStore.GetParmStoreInventoryQty (PrdID, BranchStoreID, ref rut);
            return rut;
        }
        private decimal GetCostPrice(int PrdID, int BranchStoreID)
        {
            decimal rut = 0;
            this.accStore.GetParmStoreInventoryPrice(PrdID, BranchStoreID, ref rut);           
            return rut;
        }
        private  bool ValidateData()
        {
            DataRow[] drows=this.dtblItems.Select("ReplenishQty is not null", "", DataViewRowState.CurrentRows);
            if (drows.Length == 0)
            {
                MessageBox.Show("对不起,没有任何明细项");
                return false ;
            }
            drows = this.dtblItems.Select("ReplenishQty is not null and BranchStoreID is null", "", DataViewRowState.CurrentRows);
            if (drows.Length > 0)
            {
                MessageBox.Show("对不起,存在未设库位明细项");
                return false;
            }
            if (this.dtblItems.Select("ReplenishQty>InventoryQty", "", DataViewRowState.CurrentRows).Length > 0)
            {
                MessageBox.Show("出货数不能大于库存数");
                return false;
            }
            return true;
        }
        void dgrdvItem_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow grow in this.dgrdvItem.Rows)
            {
                object objReplenishQty = grow.Cells[this.ColumnReplenishQty.Name].Value;
                object objInventory = grow.Cells[this.ColumnInventoryQty.Name].Value;
                grow.ErrorText = string.Empty;
                if (objReplenishQty != DBNull.Value)
                {
                    if (grow.Cells[this.ColumnBranchStoreID.Name].Value == DBNull.Value)
                    {
                        grow.ErrorText = "库位不能为空";
                        continue;
                    }
                    if (objInventory != DBNull.Value)
                    {
                        if ((decimal)objReplenishQty > (decimal)objInventory)
                        {
                            grow.ErrorText = "库存不足";
                            continue;
                        }
                    }
                   
                }

            }
        }
  
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateData() == false) return;
            DialogResult rul = MessageBox.Show("将进行保存入账一经确认不能变更！", "审核确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return;           
            bool flag = false;
            string errormsg = string.Empty;
            long NoteID = -1;
            string NoteCode = this.txtNoteCode.Text.Trim();
            object objNoteID = DBNull.Value;
            bool NoteCodeFlag = (NoteCode.Length > 0);
            if (NoteCodeFlag)
            {
                flag = this.accNotes.InsertSaleReplenishNotes(
                   ref errormsg,
                   ref objNoteID,
                   NoteCode ,
                   this.tpkDateNote.Value.Date,
                   this.CompanyID,
                   this.ctrlDeliverAddressID.DeliverAddressID,
                   this.ctrlDeliverPsnID.PsnID,
                   JERPBiz.Frame.UserBiz.PsnID,
                   this.rchMemo.Text);
              
            }
            else
            {
                object objNoteCode = DBNull.Value;
                flag = this.accNotes.InsertSaleReplenishNotesNonNoteCode(
                 ref errormsg,
                 ref objNoteID,
                 ref objNoteCode,
                 this.tpkDateNote.Value.Date,
                 this.CompanyID,
                 this.ctrlDeliverAddressID.DeliverAddressID,
                 this.ctrlDeliverPsnID.PsnID,
                 JERPBiz.Frame.UserBiz.PsnID,
                 this.rchMemo.Text);
                if (flag)
                {
                    NoteCode = objNoteCode.ToString();
                    this.txtNoteCode.Text = NoteCode;
                }

            }
            if (!flag)
            {
                MessageBox.Show(errormsg,"操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            NoteID = (long)objNoteID;
            //明细
            object objItemID = DBNull.Value;
            foreach (DataRow drow in this.dtblItems.Rows)
            {
                if (drow["ReplenishQty"] == DBNull.Value) continue;
                int PrdID = (int)drow["PrdID"];
                decimal CostPrice = this.GetCostPrice(PrdID, (int)drow["BranchStoreID"]);
                decimal Quantity = (decimal)drow["ReplenishQty"];
                this.accItems.InsertSaleReplenishItems(ref errormsg, ref objItemID,
                    NoteID,
                    PrdID ,
                    Quantity,
                    CostPrice ,
                    drow["BranchStoreID"],
                    drow["Memo"]);
                //增加完成数
                this.accReplenishPlans.UpdateSaleReplenishPlansForAppFinishedQty(ref errormsg, this.CompanyID ,
                   PrdID, Quantity);
                //销售出库
                this.accStore.InsertStoreForOutStore (ref errormsg,
                    JERPBiz.Finance .NoteNameParm .PrdSaleReplenishNoteNameID ,
                     NoteID,
                     NoteCode ,
                     PrdID ,
                     drow["BranchStoreID"],
                     Quantity,
                     CostPrice );
                this.accStoreReserve.SaveStoreReserveForSubReserve(ref errormsg,
                    PrdID,
                    drow["Quantity"]);
            }
            if (NoteCodeFlag)
            {
                this.accNotes.UpdateSaleReplenishNotesForPrint(ref errormsg, NoteID, JERPBiz.Frame.UserBiz.PsnID);
            }
            else
            {
                rul = MessageBox.Show("需要立即将打印吗?", "打印确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rul == DialogResult.Yes)
                {
                    this.PrintHelper.ExportToExcel(NoteID);
                    this.accNotes.UpdateSaleReplenishNotesForPrint(ref errormsg, NoteID, JERPBiz.Frame.UserBiz.PsnID);
                }
            }
 	        MessageBox.Show("成功保存当前补货单");
            if (this.affterSave != null) this.affterSave();
            this.Close();
        }
      
    }
}