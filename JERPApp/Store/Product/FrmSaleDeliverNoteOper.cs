using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Product
{
    public partial class FrmSaleDeliverNoteOper : Form
    {
        public FrmSaleDeliverNoteOper()
        {
            InitializeComponent();
            this.dgrdvPlan.AutoGenerateColumns = false;
            this.ctrlCkbAll.SeachGridView = this.dgrdvPlan;
            this.ctrlQFind.SeachGridView = this.dgrdvPlan;
            this.dgrdvItem.AutoGenerateColumns = false;
            this.accNotes = new JERPData.Product .SaleDeliverNotes();
            this.accItems = new JERPData.Product.SaleDeliverItems();
            this.accOrderItems = new JERPData.Product.SaleOrderItems();
            this.PlanNoteEntity = new JERPBiz.Product.SaleDeliverPlanNoteEntity();
            this.NoteEntity = new JERPBiz.Product.SaleDeliverNoteEntity();
            this.accPlanItems = new JERPData.Product.SaleDeliverPlanItems();
            this.bizStore = new JERPBiz.Product.Store();
            this.btnSave .Click +=new EventHandler(btnSave_Click);  
            this.dgrdvItem.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdvItem_UserDeletingRow);
            for (int j = 1; j < this.dgrdvPlan.ColumnCount; j++)
            {
                this.dgrdvPlan.Columns[j].ReadOnly = true;
            }
            this.dgrdvItem.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdvItem_DataBindingComplete);
            this.btnAdd.Click += new EventHandler(btnAdd_Click);
            this.btnDelete.Click += new EventHandler(btnDelete_Click);
        }

     
        private JERPData.Product.SaleDeliverNotes accNotes;
        private JERPData.Product.SaleDeliverItems accItems; 
        private JERPBiz.Product.SaleDeliverNoteEntity NoteEntity;
        private JERPData.Product.SaleDeliverPlanItems accPlanItems;
        private JERPData.Product.SaleOrderItems accOrderItems;
        private JERPBiz.Product.Store bizStore;
        private JERPBiz.Product.SaleDeliverPlanNoteEntity PlanNoteEntity;  
        private DataTable  dtblPlans,dtblItems;
        private long SaleDeliverPlanNoteID = -1;  
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
                this.tpkDateNote.Enabled = (value == -1);
                this.btnDelete.Enabled = (value > -1);
            }
        }
        private void LoadPlans()
        {
            this.dtblPlans = this.accPlanItems.GetDataSaleDeliverPlanItemsForDeliver(
                this.SaleDeliverPlanNoteID, this.NoteID).Tables[0];
            this.dtblPlans.Columns.Add("CheckedFlag", typeof(bool));
            this.dtblPlans.Columns.Add("InventoryQty", typeof(decimal));
            foreach (DataRow drow in this.dtblPlans.Rows )
            {
                drow["InventoryQty"] = this.bizStore.GetPrdStoreQty((int)drow["PrdID"]);
            }
            this.dgrdvPlan.DataSource = this.dtblPlans;
        }
        private void LoadItems()
        {
            this.dtblItems = this.accItems.GetDataSaleDeliverItemsForSetting (this.NoteID ).Tables[0];
            this.dtblItems.Columns.Add("InventoryQty", typeof(decimal));
            foreach (DataRow drow in this.dtblItems.Rows )
            {
                drow["InventoryQty"] = this.bizStore.GetPrdStoreQty((int)drow["PrdID"]);
            }
            this.dgrdvItem.DataSource = this.dtblItems;
        }
        public void New(long SaleDeliverPlanNoteID)
        {
            this.NoteID = -1;
            this.SaleDeliverPlanNoteID = SaleDeliverPlanNoteID;
            this.PlanNoteEntity.LoadData(SaleDeliverPlanNoteID); 
            this.tpkDateNote.Value = DateTime.Now.Date;
            this.txtNoteCode.Text = string.Empty;     

            this.txtPONo.Text = this.PlanNoteEntity.PONo;
            this.txtCompanyAbbName.Text = this.PlanNoteEntity.CompanyAbbName;

            this.ctrlDeliverAddressID.LoadData(this.PlanNoteEntity.CompanyID);
            this.ctrlDeliverAddressID.DeliverAddressID = this.PlanNoteEntity.DeliverAddressID ;

            this.txtExpressRequire.Text = this.PlanNoteEntity.ExpressRequire;

            this.ctrlFinanceAddressID.LoadData(this.PlanNoteEntity.CompanyID);
            this.ctrlFinanceAddressID.FinanceAddressID = this.PlanNoteEntity.FinanceAddressID;

            this.ctrlDeliverTypeID.DeliverTypeID = this.PlanNoteEntity.DeliverTypeID;
 

            this.rchMemo.Text = string.Empty;
            this.LoadPlans();
            this.LoadItems();
           
          
        }
        public void Edit(long NoteID)
        {
            this.NoteID = NoteID;
            this.NoteEntity.LoadData(NoteID);
            this.SaleDeliverPlanNoteID = this.NoteEntity.SaleDeliverPlanNoteID;
            this.txtNoteCode.Text = this.NoteEntity.NoteCode;
            this.tpkDateNote.Value = this.NoteEntity.DateNote;
            this.txtPONo.Text = this.NoteEntity.PONo;
            this.txtCompanyAbbName.Text = this.NoteEntity.CompanyAbbName;

            this.ctrlDeliverAddressID.LoadData(this.NoteEntity.CompanyID);
            this.ctrlDeliverAddressID.DeliverAddressID = this.NoteEntity.DeliverAddressID;

            this.ctrlFinanceAddressID.LoadData(this.NoteEntity.CompanyID);
            this.ctrlFinanceAddressID.FinanceAddressID = this.NoteEntity.FinanceAddressID;

            this.txtExpressRequire.Text = this.NoteEntity.ExpressRequire;
            this.rchMemo.Text = this.NoteEntity.Memo;
            this.LoadPlans();
            this.LoadItems();
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

        void btnAdd_Click(object sender, EventArgs e)
        {
            DataRow drowPlan, drowNew;
            DataGridViewRow grow;
            for (int irow = 0; irow < this.dgrdvPlan.RowCount;irow++ )
            {
                grow = this.dgrdvPlan.Rows[irow];
                if (grow.Cells[this.ColumnCheckedFlag.Name].Value == DBNull.Value) continue;
                if ((bool)grow.Cells[this.ColumnCheckedFlag.Name].Value == false) continue;
                drowPlan = this.dtblPlans.DefaultView[grow.Index].Row;
                drowNew = this.dtblItems.NewRow();
                drowNew["SaleDeliverPlanItemID"] = drowPlan["ItemID"];
                drowNew["SaleOrderItemID"] = drowPlan["SaleOrderItemID"];
                drowNew["PrdID"] = drowPlan["PrdID"];
                drowNew["PrdCode"] = drowPlan["PrdCode"];
                drowNew["PrdName"] = drowPlan["PrdName"];
                drowNew["PrdSpec"] = drowPlan["PrdSpec"];
                drowNew["Model"] = drowPlan["Model"];
                drowNew["CustomerRef"] = drowPlan["CustomerRef"];
                drowNew["UnitName"] = drowPlan["UnitName"];
                drowNew["InventoryQty"] = drowPlan["InventoryQty"];
                drowNew["AllowDeliverQty"] = drowPlan["NonFinishedQty"];
                drowNew["Quantity"] = drowPlan["NonFinishedQty"];
                drowNew["Price"] = drowPlan["Price"];
                drowNew["Memo"] = drowPlan["Memo"];
                this.dtblItems.Rows.Add(drowNew);
                this.dgrdvPlan.Rows.Remove(grow);
                irow--;
            }
        }
        void dgrdvItem_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow grow in this.dgrdvItem.Rows)
            {
                object objQty = grow.Cells[this.ColumnQuantity.Name].Value;
                object objAllowDeliverQty = grow.Cells[this.ColumnAllowDeliverQty.Name].Value;
                if (objQty == DBNull.Value)
                {
                    grow.ErrorText = "数量不能为空";
                    continue;
                }
                if ((decimal)objQty <= 0)
                {
                    grow.ErrorText = "数量不能小于或等于0";
                    continue;
                }
                if ((decimal)objQty > (decimal)objAllowDeliverQty)
                {
                    grow.ErrorText = "数量不能大于可送货数";
                    continue;
                }
            }
        }

        private void ReturnRow(long SaleDeliverPlanItemID)
        {
            DataTable dtblApplyItems = this.accPlanItems.GetDataSaleDeliverPlanItemsByItemID(SaleDeliverPlanItemID).Tables[0];
            dtblApplyItems.Columns.Add("CheckedFlag", typeof(bool));
            dtblApplyItems.Columns.Add("InventoryQty", typeof(decimal));
            if (dtblApplyItems.Rows.Count > 0)
            {
                DataRow drow= dtblApplyItems.Rows[0];
                drow["InventoryQty"] = this.bizStore.GetPrdStoreQty((int)drow["PrdID"]);
                this.dtblPlans.ImportRow(drow);
            }

        }
        void dgrdvItem_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            bool flag = false;
            DataRow drow = this.dtblItems.DefaultView[irow].Row;
            string ErrorMsg = string.Empty;
            if (drow["ItemID"] == DBNull.Value)
            {
                this.ReturnRow((long)drow["SaleDeliverPlanItemID"]);
                return;
            }
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {
                flag = this.accItems.DeleteSaleDeliverItems (ref ErrorMsg,
                    drow["ItemID"]);
                if (flag)
                {
                    this.accPlanItems.UpdateSaleDeliverPlanItemsForFinishedQty(ref ErrorMsg,
                        drow["SaleDeliverPlanItemID"] ); 
                    this.accOrderItems.UpdateSaleOrderItemsForSubFinishedQty (ref ErrorMsg,
                        drow["SaleOrderItemID"],
                        drow["Quantity"]);
                    this.ReturnRow((long)drow["SaleDeliverPlanItemID"]);
                }
                else
                {
                    MessageBox.Show(ErrorMsg);
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }
        private bool ValidateData()
        { 
            foreach (DataGridViewRow grow in this.dgrdvItem.Rows)
            {
                if (grow.ErrorText != string.Empty)
                {
                    return false;
                }
            }
            return true; 
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateData() == false) return;
            DialogResult rul = MessageBox.Show("将进行出货单保存，一经保存日期不能变更！", "审核确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
         
            bool flag = false;
            string errormsg = string.Empty; 
            decimal TotalAMT = 0;
            foreach (DataRow drow in this.dtblItems.Rows )
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow.RowState == DataRowState.Unchanged ) continue;
                if (drow["Quantity"] == DBNull.Value) continue;
                if (drow["Price"] == DBNull.Value) continue;
                TotalAMT += (decimal)drow["Quantity"] * (decimal)drow["Price"];
            }
            if (this.NoteID == -1)
            {
                object objNoteID = DBNull.Value;
                object objNoteCode = DBNull.Value;
                string NoteCode = string.Empty;
                if (this.txtNoteCode.Text != string.Empty)
                {
                    objNoteCode = this.txtNoteCode.Text;
                }
                flag = this.accNotes.InsertSaleDeliverNotes(
                   ref errormsg,
                   ref objNoteID,
                   ref objNoteCode,
                   this.tpkDateNote.Value.Date,
                   this.SaleDeliverPlanNoteID,
                   this.ctrlDeliverAddressID .DeliverAddressID ,
                   this.ctrlFinanceAddressID .FinanceAddressID ,
                   this.ctrlDeliverTypeID.DeliverTypeID,
                   this.ckbFQCFlag.Checked,
                   this.txtExpressRequire.Text,
                   this.ctrlDeliverPsnID.PsnID,
                   TotalAMT,
                   JERPBiz.Frame.UserBiz.PsnID,
                   this.rchMemo.Text);
                if (flag)
                {
                    this.NoteID = (long)objNoteID;
                    this.txtNoteCode.Text = objNoteCode.ToString();
                }
            }
            else
            {
                flag = this.accNotes.UpdateSaleDeliverNotes(
                    ref errormsg,
                    this.NoteID,
                   this.ctrlDeliverAddressID.DeliverAddressID,
                   this.ctrlFinanceAddressID.FinanceAddressID,
                    this.ctrlDeliverTypeID.DeliverTypeID,
                    this.txtExpressRequire.Text,
                    this.ctrlDeliverPsnID.PsnID,
                    JERPBiz.Frame.UserBiz.PsnID,
                    this.ckbFQCFlag.Checked,
                    TotalAMT ,
                    this.rchMemo.Text);
            }
            if (!flag)
            {
                MessageBox.Show(errormsg,"操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           
            //明细
            object objItemID=DBNull .Value ;   
            foreach (DataRow drow in this.dtblItems.Rows )
            {
                if (drow.RowState == DataRowState.Deleted) continue;  
                if (drow["ItemID"] == DBNull.Value)
                {
                    objItemID = DBNull.Value;
                    flag = this.accItems.InsertSaleDeliverItems(ref errormsg, ref objItemID,
                        this.NoteID,
                        drow["SaleDeliverPlanItemID"],
                        drow["Quantity"],  
                        drow["Memo"]);
                    if (flag)
                    {
                        drow["ItemID"] = objItemID;

                    }
                }
                else
                {
                    this.accItems .UpdateSaleDeliverItems (ref errormsg ,
                        drow["ItemID"],
                        drow["Quantity"],  
                        drow["Memo"]);

                }
                //增加完成(计划之完成)
                this.accPlanItems.UpdateSaleDeliverPlanItemsForFinishedQty(ref errormsg,
                    drow["SaleDeliverPlanItemID"] );
                //设计订单完成
                this.accOrderItems.UpdateSaleOrderItemsForAppFinishedQty (ref errormsg,
                    drow["SaleOrderItemID"],
                    drow["Quantity"]);
                drow.AcceptChanges();
            }
            this.LoadPlans();
            this.LoadItems();
	        MessageBox.Show("成功保存当前送货单");
            if (this.affterSave != null) this.affterSave();
        }
        void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult rul = MessageBox.Show("您将删除当前送货单，一经删除不能恢复！", "操作确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            bool flag = false;
            string errormsg = string.Empty;
            flag = this.accNotes.DeleteSaleDeliverNotes(ref errormsg, this.NoteID);
            if (!flag)
            {
                MessageBox.Show(errormsg);
                return;
            }
            MessageBox.Show("成功删除当前送货单");
            if (this.affterSave != null) this.affterSave();
            this.Close();
        }

     
    }
}