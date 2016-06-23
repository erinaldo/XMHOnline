using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Engineer.Tool
{
    public partial class FrmOrderNoteOper : Form
    {
        public FrmOrderNoteOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accItems = new JERPData.Tool.BuyOrderItems();
            this.accNotes = new JERPData.Tool.BuyOrderNotes();
            this.accPrds = new JERPData.Tool.Product ();
            this.NoteEntity = new JERPBiz.Tool.BuyOrderNoteEntity();
            this.accSupplier = new JERPData.General.Supplier();
            this.accUnits = new JERPData.General.Unit();
            this.SetColumnSrc();
            this.dgrdv .CellValueChanged +=new DataGridViewCellEventHandler(dgrdv_CellValueChanged);
            this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
            this.dgrdv.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdv_DataBindingComplete);
            this.dgrdv.CellContextMenuStripNeeded += new DataGridViewCellContextMenuStripNeededEventHandler(dgrdv_CellContextMenuStripNeeded);
            this.btnNew.Click += new EventHandler(btnNew_Click);
            this.btnDelete.Click += new EventHandler(btnDelete_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.FormClosed += new FormClosedEventHandler(FrmBuyOrderNoteOper_FormClosed);
            this.lnkFile.LinkClicked +=new LinkLabelLinkClickedEventHandler(lnkFile_LinkClicked);
        }

      
        private JERPData.Tool.BuyOrderNotes accNotes;
        private JERPData.Tool.BuyOrderItems accItems;
        private JERPData.Tool.Product  accPrds;
        private JERPBiz.Tool.BuyOrderNoteEntity NoteEntity;
        private JERPApp.Define.Tool.FrmProduct frmPrd;
        private JERPData.General.Supplier accSupplier;
        private JCommon.FrmFileBrowse frmFileBrowse;
        private JERPData.General.Unit accUnits;
        private DataTable dtblItems,dtblPrds,dtblUnits;
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
                this.lnkFile.Enabled = (value > -1);
                this.ctrlCompanyID.Enabled  = (value == -1);
            }
        }
        private void SetColumnSrc()
        {
            this.dtblPrds = this.accPrds.GetDataProduct ().Tables[0];
            this.ColumnPrdCode.DataSource = this.dtblPrds;
            this.ColumnPrdCode.ValueMember = "PrdID";
            this.ColumnPrdCode.DisplayMember = "PrdCode";

            this.ColumnPrdName.DataSource = this.dtblPrds;
            this.ColumnPrdName.ValueMember = "PrdID";
            this.ColumnPrdName.DisplayMember = "PrdName";

            this.ColumnPrdSpec.DataSource = this.dtblPrds;
            this.ColumnPrdSpec.ValueMember = "PrdID";
            this.ColumnPrdSpec.DisplayMember = "PrdSpec";

            this.ColumnUnitName.DataSource = this.dtblPrds;
            this.ColumnUnitName.ValueMember = "PrdID";
            this.ColumnUnitName.DisplayMember = "UnitName";

            this.dtblUnits = this.accUnits.GetDataUnit().Tables[0];
            this.ColumnPriceUnitID.DataSource = this.dtblUnits;
            this.ColumnPriceUnitID .ValueMember = "UnitID";
            this.ColumnPriceUnitID.DisplayMember = "UnitName";
        }

     

        private void LoadItems()
        {
            this.dtblItems = this.accItems.GetDataBuyOrderItemsByNoteID(this.NoteID).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
            this.dtblItems.Columns["PrdID"].AllowDBNull = false;
            this.dtblItems.Columns["PriceUnitID"].AllowDBNull = false;
        }
        public void NewNote()
        {
            this.NoteID = -1;
            this.txtNoteCode.Text = string.Empty;
            this.dpkDateNote.Value = DateTime.Now.Date;
            this.rchMemo.Text = string.Empty;
            this.ctrlDeliverAddress.LoadData();
            this.LoadItems();
        }
        public void EditNote(long NoteID)
        {
            this.NoteID = NoteID;
            this.NoteEntity.LoadData(NoteID);
            this.txtNoteCode.Text = this.NoteEntity .NoteCode ;
            this.ctrlCompanyID .CompanyID  = this.NoteEntity.CompanyID  ;
            this.dpkDateNote .Value  = this.NoteEntity.DateNote.Date ;
            this.ctrlMoneyTypeID .MoneyTypeID  = this.NoteEntity.MoneyTypeID ;
            this.ctrlSettleTypeID .SettleTypeID   = this.NoteEntity.SettleTypeID ;
            this.ctrlPriceTypeID.PriceTypeID = this.NoteEntity.PriceTypeID ;
            this.ctrlInvoiceTypeID.InvoiceTypeID = this.NoteEntity.InvoiceTypeID;
            this.ctrlDeliverAddress.LoadData();
            this.ctrlDeliverAddress.DeliverAddress = this.NoteEntity.DeliverAddress;
            this.ctrlDeliverTypeID.DeliverTypeID = this.NoteEntity.DeliverTypeID;
            this.txtExpressRequire.Text = this.NoteEntity.ExpressRequire;
            this.rchMemo.Text = this.NoteEntity.Memo  ;
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
                flag = this.accItems .DeleteBuyOrderItems(ref ErrorMsg,
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
   

        void dgrdv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow grow in this.dgrdv.Rows)
            {
                grow.ErrorText = string.Empty;
                if (grow.Cells[this.ColumnQuantity.Name].Value == DBNull.Value)
                {
                    grow.ErrorText = "未设数量";
                    continue;
                }
                if (grow.Cells[this.ColumnPriceUnitID.Name].Value == DBNull.Value)
                {
                    grow.ErrorText = "未设计量单位";
                    continue;
                }
                if (grow.Cells[this.ColumnPrdCode.Name].Value == DBNull.Value)
                {
                    grow.ErrorText = "未设产品";
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
                flag = this.accNotes.InsertBuyOrderNotes(ref errormsg,
                    ref objNoteID,
                    ref objNoteCode,
                    this.dpkDateNote.Value.Date,
                    this.ctrlCompanyID.CompanyID,
                    this.ctrlDeliverAddress .DeliverAddress ,
                    this.ctrlDeliverTypeID .DeliverTypeID ,
                    this.txtExpressRequire .Text ,
                    this.ctrlMoneyTypeID.MoneyTypeID,
                    this.ctrlSettleTypeID.SettleTypeID,
                    this.ctrlPriceTypeID.PriceTypeID,
                    this.ctrlInvoiceTypeID .InvoiceTypeID ,
                    JERPBiz.Frame.UserBiz.PsnID,
                    this.rchMemo.Text);
                if (flag)
                {
                    this.txtNoteCode.Text = objNoteCode.ToString();
                    this.NoteID = (long)objNoteID;
                }
            }
            else
            {
                flag = this.accNotes.UpdateBuyOrderNotes(ref errormsg, this.NoteID,
                    this.ctrlDeliverAddress.DeliverAddress,
                    this.ctrlDeliverTypeID.DeliverTypeID,
                    this.txtExpressRequire.Text,
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
            string ErrorMsg = string.Empty;
            bool flag = false;
            object objItemID = DBNull.Value;
            foreach (DataRow drow in this.dtblItems.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow.RowState ==DataRowState.Unchanged) continue;   
		        objItemID=drow["ItemID"];              
                if (objItemID == DBNull.Value)
                {
                    flag = this.accItems.InsertBuyOrderItems(ref ErrorMsg,
                         ref objItemID,
                         this.NoteID ,
                         drow["PrdID"],
                         drow["Quantity"],
                         drow["Price"],
                         drow["PriceUnitID"],
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
                    flag=this.accItems.UpdateBuyOrderItems(ref ErrorMsg,
			            drow["ItemID"],
                        drow["PrdID"],
			            drow["Quantity"],
			            drow["Price"],
                        drow["PriceUnitID"],
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
            
            }
        }
        private object GetPrice(int PrdID, int PriceUnitID)
        {

            decimal Price = -1;
            this.accItems.GetParmBuyOrderItemsLastPrice(
                this.ctrlCompanyID.CompanyID,
                this.ctrlMoneyTypeID.MoneyTypeID,
                this.ctrlSettleTypeID.SettleTypeID,
                this.ctrlPriceTypeID.PriceTypeID,
                PrdID,
                PriceUnitID,
                ref Price);
            if (Price > -1)
            {
                return Price;
            }            
            return DBNull.Value;
        }
        void lnkFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.frmFileBrowse == null)
            {
                this.frmFileBrowse = new JCommon.FrmFileBrowse();
                new FrmStyle(frmFileBrowse).SetPopFrmStyle(this);
                this.frmFileBrowse.ReadOnly = false;
            }
            this.frmFileBrowse.Browse(JERPData.ServerParameter.ERPFileFolder + @"\Supply\ToolOrderNote\" + this.NoteID.ToString());
            this.frmFileBrowse.ShowDialog();
        }

        private object GetPriceUnitID(int PrdID)
        {

            int PriceUnitID = -1;
            this.accItems.GetParmBuyOrderItemsLastPriceUnitID(
                this.ctrlCompanyID.CompanyID,
                PrdID,
                ref PriceUnitID);
            if (PriceUnitID > -1)
            {
                return PriceUnitID;
            }
            
            DataRow[] drows = this.dtblPrds.Select("PrdID=" + PrdID.ToString());
            if (drows.Length > 0)
            {
                return drows[0]["UnitID"];
            }
            return DBNull.Value;
        }
        void dgrdv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[e.ColumnIndex].DataPropertyName == "PrdID")
            {
                object objPrdID = this.dgrdv[icol, irow].Value;
                object objPriceUnitID = this.dgrdv[this.ColumnPriceUnitID.Name, irow].Value;
                if (objPrdID != DBNull.Value)
                {
                    if (objPriceUnitID == DBNull.Value)
                    {
                        objPriceUnitID = this.GetPriceUnitID((int)objPrdID);
                        this.dgrdv[this.ColumnPriceUnitID.Name, irow].Value = objPriceUnitID;
                    }
                    else
                    {
                        this.dgrdv[this.ColumnPrice.Name, irow].Value = this.GetPrice((int)objPrdID, (int)objPriceUnitID);

                    }
                }
            }
            if (this.dgrdv.Columns[e.ColumnIndex].DataPropertyName == "PriceUnitID")
            {
                object objPrdID = this.dgrdv[this.ColumnPrdCode.Name, irow].Value;
                object objPriceUnitID = this.dgrdv[this.ColumnPriceUnitID.Name, irow].Value;
                if ((objPrdID != DBNull.Value) && (objPriceUnitID != DBNull.Value))
                {
                    this.dgrdv[this.ColumnPrice.Name, irow].Value = this.GetPrice((int)objPrdID, (int)objPriceUnitID);
                }
            }
        }
        private void SaveSupplier()
        {
            string errormsg = string.Empty;
            this.accSupplier.UpdateSupplierForDateLastOrder(ref errormsg, this.NoteEntity.CompanyID);

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
            DataRow[] drows = this.dtblItems.Select("", "", DataViewRowState.CurrentRows);
            if (drows.Length == 0)
            {
                MessageBox.Show("没有任何明细项");
                return false;
            }
            foreach (DataRow drow in drows)
            {
                drow.RowError = string.Empty;
            }          
            return true;
        }
        void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateData() == false) return;
            if (this.NoteID == -1)
            {
                DialogResult rul = MessageBox.Show("将进行订单保存,一经保存供应商、订单日期均不能变更", "新增确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rul == DialogResult.No) return;
            }
            if (this.SaveNote())
            {
                this.SaveItem();
                this.SaveSupplier();
                MessageBox.Show("成功保存当前订单");
            }

        }
        void FrmBuyOrderNoteOper_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.affterSave != null) this.affterSave();
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
              DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
              if (rul == DialogResult.Yes)
              {
                  string errormsg=string.Empty ;
                  bool flag= this.accNotes.DeleteBuyOrderNotes(ref errormsg, this.NoteID);
                  if (!flag)
                  {
                      MessageBox.Show(errormsg);
                      return;
                  }
                  this.Close();
              }
        }
      
        void dgrdv_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].DataPropertyName == "PrdID")
            {
                this.dgrdv.CurrentCell = this.dgrdv[icol, irow];
                if (frmPrd == null)
                {
                    this.frmPrd = new JERPApp.Define.Tool.FrmProduct();
                    new FrmStyle(this.frmPrd).SetPopFrmStyle(this);
                    this.frmPrd.AffterSelected += new JERPApp.Define.Tool.FrmProduct.AffterSelectedDelegate(frmPrd_AffterSelected);
                }
                this.frmPrd.ShowDialog();
            }
        }


        void frmPrd_AffterSelected(DataRow drow)
        {
            int PrdID = (int)drow["PrdID"];
            this.dgrdv.CurrentCell.Value = PrdID;
            int irow = this.dgrdv.CurrentRow.Index;
            object objPriceUnitID = this.GetPriceUnitID(PrdID);
            this.dgrdv[this.ColumnPriceUnitID.Name, irow].Value = objPriceUnitID;
            this.dgrdv[this.ColumnPrice.Name, irow].Value = this.GetPrice(PrdID, (int)objPriceUnitID); 
        
        }
   
  
    }
}