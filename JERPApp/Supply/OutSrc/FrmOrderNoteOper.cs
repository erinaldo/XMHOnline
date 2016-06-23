using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Supply.OutSrc
{
    public partial class FrmOrderNoteOper : Form
    {
        public FrmOrderNoteOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accItems = new JERPData.Manufacture.OutSrcOrderItems();
            this.accNotes = new JERPData.Manufacture.OutSrcOrderNotes();
            this.NoteEntity = new JERPBiz.Manufacture.OutSrcOrderNoteEntity();
            this.accPrice = new JERPData.Manufacture.OutSrcPriceItems();
            this.accPriceNote = new JERPData.Manufacture.OutSrcPriceNotes();   
            this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
            this.dgrdv.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdv_DataBindingComplete); 
            this.dgrdv.MouseClick += new MouseEventHandler(dgrdv_MouseClick); 
            this.btnAddItem.Click += new EventHandler(btnAddItem_Click);
            this.btnNew.Click += new EventHandler(btnNew_Click);
            this.btnDelete.Click += new EventHandler(btnDelete_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.FormClosed += new FormClosedEventHandler(FrmOutSrcOrderNoteOper_FormClosed);
            this.ctrlOrderTypeID.AffterSelected += this.SetPriceElement;
            this.ctrlCompanyID.AffterSelected += ctrlCompanyID_AffterSelected;
            this.ctrlMoneyTypeID.AffterSelected += this.SetAllPrice;
            this.ctrlSettleTypeID.AffterSelected += this.SetAllPrice;
            this.ctrlPriceTypeID.AffterSelected += this.SetAllPrice;
        }

      

        private JERPData.Manufacture.OutSrcOrderNotes accNotes;
        private JERPData.Manufacture.OutSrcOrderItems accItems;
        private JERPData.Manufacture.OutSrcPriceItems accPrice;
        private JERPData.Manufacture.OutSrcPriceNotes accPriceNote;
        private JERPBiz.Manufacture.OutSrcOrderNoteEntity NoteEntity;   
        private DataTable dtblItems;
        private FrmOrderItemFromSchedule frmSchedule;
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
                this.btnDelete.Enabled = (value > -1);
                this.dpkDateNote.Enabled = (value == -1);
                this.ctrlCompanyID.Enabled = (value == -1);
            }
        }
       
        void SetPriceElement()
        {
          
            int MoneyTypeID = 1;
            int SettleTypeID = 1;
            int PriceTypeID = 1;
            this.accPriceNote.GetParmOutSrcPriceNotesLastElement (
                this.ctrlCompanyID .CompanyID ,
                this.ctrlOrderTypeID .OrderTypeID ,
                ref MoneyTypeID,
                ref SettleTypeID,
                ref PriceTypeID);
            this.ctrlMoneyTypeID.MoneyTypeID = MoneyTypeID;
            this.ctrlSettleTypeID.SettleTypeID = SettleTypeID;
            this.ctrlPriceTypeID.PriceTypeID = PriceTypeID;
            this.SetAllPrice();
        }
        private object GetPrice(long ManufProcessID)
        {
            decimal rut = 0;
            this.accPrice .GetParmOutSrcPriceItemsPrice (
                this.ctrlCompanyID.CompanyID,
                this.ctrlOrderTypeID.OrderTypeID,
                this.ctrlMoneyTypeID.MoneyTypeID,
                this.ctrlSettleTypeID.SettleTypeID,
                this.ctrlPriceTypeID.PriceTypeID,
                DateTime .Now .Date ,
                ManufProcessID , 
                ref rut);
            if (rut> -1)
            {
                return rut;
            }
            this.accItems.GetParmOutSrcOrderItemsPrice(
                ManufProcessID,
                 this.ctrlCompanyID.CompanyID,
                this.ctrlOrderTypeID.OrderTypeID,
                this.ctrlMoneyTypeID.MoneyTypeID,
                this.ctrlSettleTypeID.SettleTypeID,
                this.ctrlPriceTypeID.PriceTypeID, 
                ref rut);
            if (rut > -1)
            {
                return rut;
            }
            return DBNull .Value ;
        }
        
        private void SetAllPrice()
        {
            if (this.dtblItems == null) return;
            foreach (DataRow drow in this.dtblItems.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow["ManufProcessID"] == DBNull.Value) continue; 
                drow["Price"] = this.GetPrice((long)drow["ManufProcessID"]);
            }
        }
        void ctrlCompanyID_AffterSelected()
        {
            this.ctrlSupplierAddress.LoadData(this.ctrlCompanyID.CompanyID);
            this.SetPriceElement();
        }
        private void LoadItems()
        {
            this.dtblItems = this.accItems.GetDataOutSrcOrderItemsByNoteID(this.NoteID).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;      
            
        }
        public void NewNote()
        {
            this.NoteID = -1;
            this.txtNoteCode.Text = string.Empty;
            this.dpkDateNote.Value = DateTime.Now.Date;
            this.txtExpressRequire.Text = string.Empty;
            this.rchMemo.Text = string.Empty;
            this.ctrlDeliverAddress.LoadData(); 
            this.ctrlCompanyID_AffterSelected();
            this.LoadItems();
        }
        public void EditNote(long NoteID)
        {
            this.NoteID = NoteID;
            this.NoteEntity.LoadData(NoteID);
            this.txtNoteCode.Text = this.NoteEntity.NoteCode;
            this.dpkDateNote.Value = this.NoteEntity.DateNote;
            this.ctrlCompanyID.CompanyID = this.NoteEntity.CompanyID;           
            this.ctrlDeliverAddress.LoadData();
            this.ctrlDeliverAddress.DeliverAddress = this.NoteEntity.DeliverAddress;
            this.ctrlSupplierAddress.LoadData(this.NoteEntity.CompanyID);
            this.ctrlSupplierAddress.SupplierAddress = this.NoteEntity.SupplierAddress;
            this.ctrlMoneyTypeID.MoneyTypeID = this.NoteEntity.MoneyTypeID;
            this.ctrlSettleTypeID.SettleTypeID = this.NoteEntity.SettleTypeID;
            this.ctrlPriceTypeID.PriceTypeID = this.NoteEntity.PriceTypeID;
            this.ctrlInvoiceTypeID.InvoiceTypeID = this.NoteEntity.InvoiceTypeID;
            this.rchMemo.Text = this.NoteEntity.Memo;
            this.LoadItems();
        }

        void btnNew_Click(object sender, EventArgs e)
        {
            this.NewNote();
         
        }    
        void dgrdv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            bool flag = false;
            DataRow drow = this.dtblItems .DefaultView[irow].Row;
            string ErrorMsg = string.Empty;
            if (drow["ItemID"] == DBNull.Value)
            {           
                return;
            }
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {
                flag = this.accItems .DeleteOutSrcOrderItems(ref ErrorMsg,
                    drow["ItemID"]);
                if (!flag)
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
       
         
        private void AddSchedule()
        {
            DataRow[] drows = this.dtblItems.Select("", "", DataViewRowState.CurrentRows);
            if (frmSchedule == null)
            {
                frmSchedule = new FrmOrderItemFromSchedule();
                new FrmStyle(frmSchedule).SetPopFrmStyle(this);
                frmSchedule.AffterSave += new FrmOrderItemFromSchedule.AffterSaveDelegate(frmSchedule_AffterSave);
            }
            frmSchedule.OrderFromSchedule(drows);
            frmSchedule.ShowDialog();
        }
        void frmSchedule_AffterSave(DataRow drowSchedule)
        {
            long ManufScheduleID = (long)drowSchedule["ManufScheduleID"];
            if (dtblItems.Select("ManufScheduleID=" + ManufScheduleID.ToString(), "", DataViewRowState.CurrentRows).Length > 0)
            {
                return;
            }
            DataRow drowNew = this.dtblItems.NewRow();
            drowNew["ManufScheduleID"] = ManufScheduleID;

            drowNew["WorkingSheetCode"] = drowSchedule["WorkingSheetCode"];
            drowNew["ManufProcessID"] = drowSchedule["ManufProcessID"];
            drowNew["PrdID"] = drowSchedule["PrdID"]; 
            drowNew["PrdCode"] = drowSchedule["PrdCode"];
            drowNew["PrdName"] = drowSchedule["PrdName"];
            drowNew["PrdSpec"] = drowSchedule["PrdSpec"];
            drowNew["PrdStatus"] = drowSchedule["PrdStatus"];
            drowNew["UnitName"] = drowSchedule["UnitName"];  
            drowNew["Price"] = this.GetPrice((long)drowSchedule["ManufProcessID"]);
            drowNew["Quantity"] = drowSchedule["OutSrcOrderNonFinishedQty"];
            drowNew["Memo"] = drowSchedule["Memo"];
            drowNew["DateTarget"] = drowSchedule["DateEnd"];
            this.dtblItems.Rows.Add(drowNew);


        }

        void dgrdv_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.AddSchedule();
            }
        }


        void btnAddItem_Click(object sender, EventArgs e)
        {
            this.AddSchedule();
        }

    
     
        void dgrdv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow grow in this.dgrdv.Rows)
            {
                if (grow.IsNewRow) continue;
                grow.ErrorText = string.Empty;             
                object objManufScheduleID = grow.Cells[this.ColumnManufScheduleID.Name].Value;
                if (objManufScheduleID == DBNull.Value)
                {
                    grow.ErrorText = "未选择任何加工项";
                    continue;
                }
                object objQuantity = grow.Cells[this.ColumnQuantity.Name].Value;
                if (objQuantity == DBNull.Value)
                {
                    grow.ErrorText = "数量不全";
                    continue;
                } 
               
            }
        }     

        private bool SaveNote()
        {
            bool flag = false;
            string errormsg = string.Empty;
            if (this.NoteID == -1)
            {
                object objNoteID = DBNull.Value;
                object objNoteCode = DBNull.Value;
                flag = this.accNotes.InsertOutSrcOrderNotes(ref errormsg,
                       ref objNoteID,
                       ref objNoteCode ,
                       this.dpkDateNote.Value.Date,
                       this.ctrlCompanyID.CompanyID,
                       this.ctrlOrderTypeID.OrderTypeID,
                       this.ctrlSupplierAddress.SupplierAddress ,
                       this.ctrlDeliverAddress .DeliverAddress ,
                       this.ctrlDeliverTypeID .DeliverTypeID ,
                       this.txtExpressRequire .Text ,
                       this.ctrlMoneyTypeID .MoneyTypeID ,
                       this.ctrlSettleTypeID .SettleTypeID ,
                       this.ctrlPriceTypeID .PriceTypeID ,
                       this.ctrlInvoiceTypeID .InvoiceTypeID ,
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
                flag = this.accNotes.UpdateOutSrcOrderNotes(ref errormsg, 
                    this.NoteID,
                    this.ctrlSupplierAddress .SupplierAddress ,
                    this.ctrlDeliverAddress .DeliverAddress ,
                    this.ctrlDeliverTypeID .DeliverTypeID ,
                    this.txtExpressRequire .Text ,
                    this.ctrlMoneyTypeID .MoneyTypeID ,
                    this.ctrlSettleTypeID .SettleTypeID ,
                    this.ctrlPriceTypeID .PriceTypeID ,
                    this.ctrlInvoiceTypeID .InvoiceTypeID ,
                    JERPBiz.Frame.UserBiz.PsnID,
                    this.rchMemo.Text);
            }
            if (!flag)
            {              
                MessageBox.Show(errormsg);
            }
            return flag;

        }
        void SaveItem()
        {
            foreach (DataRow drow in this.dtblItems.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow.RowState ==DataRowState.Unchanged) continue;               
                string ErrorMsg=string.Empty;
		        object  objItemID=drow["ItemID"];
                bool flag = false;
                if (objItemID == DBNull.Value)
                {
                    flag = this.accItems.InsertOutSrcOrderItems(ref ErrorMsg,
                         ref objItemID,
                         this.NoteID ,
                         drow["ManufScheduleID"],
                         drow["Quantity"],
                         drow["Price"], 
                         drow["DateTarget"],
                         drow["Memo"]);
                    if (flag)
                    {
                        drow["ItemID"] = objItemID;
                        drow.AcceptChanges();
                    }
                }
                else
                {
                    flag=this.accItems.UpdateOutSrcOrderItems(ref ErrorMsg,
			            drow["ItemID"],
                        drow["ManufScheduleID"],
                        drow["Quantity"],
                        drow["Price"], 
			            drow["DateTarget"],
                        drow["Memo"]);
		                if(flag)
		                {
			                drow.AcceptChanges ();
		                }
                }
                if (!flag)
                {
                 
                    MessageBox.Show(ErrorMsg);
                }
                //这里对计划的完成数做存贮过程里了，所以。。。您懂的
            }
        }
        private bool ValidateData()
        {
            if (this.ctrlCompanyID.CompanyID == -1)
            {
                MessageBox.Show("供应商不能为空！", "出错啦!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (this.ctrlMoneyTypeID.MoneyTypeID == -1)
            {
                MessageBox.Show("币种不能为空！", "出错啦!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (this.ctrlSettleTypeID.SettleTypeID == -1)
            {
                MessageBox.Show("结算方式不能为空！", "出错啦!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (this.ctrlPriceTypeID.PriceTypeID == -1)
            {
                MessageBox.Show("单价类型不能为空！", "出错啦!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (this.ctrlInvoiceTypeID.InvoiceTypeID == -1)
            {
                MessageBox.Show("发票类型不能为空！", "出错啦!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            DataRow[] drows = this.dtblItems.Select("", "", DataViewRowState.CurrentRows);
            if (drows.Length == 0)
            {
                MessageBox.Show("没有任何明细项");
                return false;
            }          
            drows = this.dtblItems.Select("ManufScheduleID is null or Quantity is null", "", DataViewRowState.CurrentRows);
            if (drows.Length > 0)
            {
                MessageBox.Show("有记录信息不全!");               
                return false;
            }
            return true;
        }
      
        void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateData() == false) return;
            if (this.NoteID == -1)
            {
                DialogResult rul = MessageBox.Show("将生成新的订单，\n请确认供应商、下单日期的正确性！\n一经保存不能变更", "保存确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rul == DialogResult.No) return; 
            }
            if (this.SaveNote())
            {
                this.SaveItem();
                MessageBox.Show("成功保存当前订单");
            }

        }
        void FrmOutSrcOrderNoteOper_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.affterSave != null) this.affterSave();
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
              DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
              if (rul == DialogResult.Yes)
              {
                  string errormsg=string.Empty ;
                  bool flag=this.accNotes.DeleteOutSrcOrderNotes(ref errormsg, this.NoteID);
                  if (!flag)
                  {
                      MessageBox.Show(errormsg , "出借啦!", MessageBoxButtons.OK , MessageBoxIcon.Error );
                      return;
                  }
                  if (this.affterSave != null) this.affterSave();
                  this.Close();
              }
        }
       

 
    }
}