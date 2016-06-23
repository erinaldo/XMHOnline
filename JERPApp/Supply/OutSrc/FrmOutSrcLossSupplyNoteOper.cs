using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Supply.OutSrc
{
    public partial class FrmOutSrcLossSupplyNoteOper : Form
    {
        public FrmOutSrcLossSupplyNoteOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accItems = new JERPData.Material.OutSrcLossSupplyItems();
            this.accNotes = new JERPData.Material.OutSrcLossSupplyNotes();
            this.accStore = new JERPData.Material.Store();  
            this.accPrds = new JERPData.Product.Product();
            this.NoteEntity = new JERPBiz.Material.OutSrcLossSupplyNoteEntity();
            this.ctrlCompanyID.AffterSelected += new JERPApp.Define.General.CtrlSupplierForOutSrc.AffterSelectedDelegate(ctrlCompanyID_AffterSelected);
            this.dtblPrds = this.accPrds.GetDataProductForMaterial().Tables[0];
            this.dgrdv .CellValueChanged +=new DataGridViewCellEventHandler(dgrdv_CellValueChanged);
            this.dgrdv.CellContextMenuStripNeeded += new DataGridViewCellContextMenuStripNeededEventHandler(dgrdv_CellContextMenuStripNeeded);
            this.dgrdv.CellQuery += new JCommon.MyDataGridView.CellQueryDelegate(dgrdv_CellQuery);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnAddPrd.Click += new EventHandler(btnAddPrd_Click);
            this.btnNew .Click +=new EventHandler(btnNew_Click);
            this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
            this.btnDelete.Click += new EventHandler(btnDelete_Click);
          
        }


        private JERPData.Material.OutSrcLossSupplyNotes  accNotes;
        private JERPData.Material.OutSrcLossSupplyItems  accItems;
        private JERPBiz.Material.OutSrcLossSupplyNoteEntity NoteEntity;
        private JERPData.Product.Product accPrds;  
        private DataTable dtblPrds,dtblItems;
        private JERPData.Material.Store accStore;   
        private JCommon.FrmGridFind frmGridPrd;  
        private JERPApp.Define.Material.FrmProduct frmPrd;
        private JERPApp.Define.Material.FrmProduct frmAddPrd;
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
                this.btnDelete.Enabled = (value > -1);
                this.dtpDateNote.Enabled = (value > -1);
            }
        }
        private decimal GetStoreQty(int PrdID)
        {
            decimal rut = 0;
            this.accStore.GetParmStorePrdInventoryQty  (PrdID,ref rut);
            return rut;
        }
        
        
        void ctrlCompanyID_AffterSelected()
        {
            this.ctrlSupplierAddress.LoadData(this.ctrlCompanyID.CompanyID );
        } 
 
        void dgrdv_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if ((this.dgrdv.Columns[icol].DataPropertyName == "PrdCode")
              || (this.dgrdv.Columns[icol].DataPropertyName == "PrdName")
              || (this.dgrdv.Columns[icol].DataPropertyName == "PrdSpec")
              || (this.dgrdv.Columns[icol].DataPropertyName == "Model")
              || (this.dgrdv.Columns[icol].DataPropertyName == "Manufacturer"))
            {

                this.dgrdv.CurrentCell = this.dgrdv[icol, irow];
                if (frmPrd == null)
                {
                    frmPrd = new JERPApp.Define.Material.FrmProduct();
                    new FrmStyle(frmPrd).SetPopFrmStyle(this);
                    frmPrd.AffterSelected += new JERPApp.Define.Material.FrmProduct.AffterSelectedDelegate(frmPrd_AffterSelected);
                }
                frmPrd.ShowDialog();
            }
        }

        void frmPrd_AffterSelected(DataRow drow)
        {
            DataGridViewRow grow = this.dgrdv.CurrentRow;
            int PrdID = (int)drow["PrdID"];
            grow.Cells[this.ColumnPrdID.Name].Value = PrdID;
            grow.Cells[this.ColumnPrdCode.Name].Value = drow["PrdCode"];
            grow.Cells[this.ColumnPrdName.Name].Value = drow["PrdName"];
            grow.Cells[this.ColumnPrdSpec.Name].Value = drow["PrdSpec"];
            grow.Cells[this.ColumnModel.Name].Value = drow["Model"];
            grow.Cells[this.ColumnManufacturer.Name].Value = drow["Manufacturer"];
            grow.Cells[this.ColumnUnitName.Name].Value = drow["UnitName"];  
            this.frmPrd.Close();
        }

        void btnAddPrd_Click(object sender, EventArgs e)
        {
            if (frmAddPrd == null)
            {
                this.frmAddPrd = new JERPApp.Define.Material.FrmProduct();
                new FrmStyle(this.frmAddPrd).SetPopFrmStyle(this);
                this.frmAddPrd.AffterSelected += frmAddPrd_AffterSelected;
            }
            this.frmAddPrd.ShowDialog();
        }
        void frmAddPrd_AffterSelected(DataRow drow)
        {
            int PrdID = (int)drow["PrdID"];
            if (this.dtblItems.Select("PrdID=" + PrdID.ToString(), "", DataViewRowState.CurrentRows).Length > 0)
            {
                return;
            }
            DataRow drowNew = this.dtblItems.NewRow();
            drowNew["PrdID"] = PrdID;
            drowNew["PrdCode"] = drow["PrdCode"];
            drowNew["PrdName"] = drow["PrdName"];
            drowNew["PrdSpec"] = drow["PrdSpec"];
            drowNew["Model"] = drow["Model"];
            drowNew["Manufacturer"] = drow["Manufacturer"];
            drowNew["UnitName"] = drow["UnitName"];
            drowNew["Quantity"] = 0;
            drowNew["InventoryQty"] = this.GetStoreQty(PrdID);
            this.dtblItems.Rows.Add(drowNew);

        }
     

        void dgrdv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].DataPropertyName == "PrdID")
            {
                object objPrdID = this.dgrdv[icol, irow].Value;
                if (objPrdID == DBNull.Value) return; 
                this.dgrdv[this.ColumnInventoryQty.Name, irow].Value = this.GetStoreQty((int)objPrdID);  
            }
            
           
        }
   
        
        public void New()
        {
            this.NoteID = -1;
            this.dtpDateNote.Value = DateTime.Now.Date; 
            this.rchMemo.Text = string.Empty;
            this.ctrlCompanyID.CompanyID = -1;
            this.rchMemo.Text = string.Empty;
            this.LoadItems();
          
        }
        public void Edit(long NoteID)
        {
            this.NoteID = NoteID;
            this.NoteEntity.LoadData(NoteID);
            this.txtNoteCode.Text = this.NoteEntity.NoteCode;
            this.dtpDateNote.Value = this.NoteEntity.DateNote;
            this.ctrlCompanyID.CompanyID = this.NoteEntity.CompanyID;
            this.ctrlCompanyID_AffterSelected();
            this.ctrlMoneyTypeID.MoneyTypeID = this.NoteEntity.MoneyTypeID;
            this.ctrlSupplierAddress.SupplierAddress = this.NoteEntity.SupplierAddress; 
            this.rchMemo.Text = this.NoteEntity.Memo;
            this.LoadItems();
        }
        private void LoadItems()
        {
            this.dtblItems = this.accItems.GetDataOutSrcLossSupplyItemsByNoteID(this.NoteID ).Tables[0];
            this.dtblItems.Columns.Add("InventoryQty", typeof(decimal));
            foreach (DataRow drow in this.dtblItems.Rows)
            {
                drow["InventoryQty"] = this.GetStoreQty((int)drow["PrdID"]);
            }
            this.dgrdv.DataSource = this.dtblItems; 
        }
        void btnNew_Click(object sender, EventArgs e)
        {
            this.New();
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult rul = MessageBox.Show("将进行删除，一经删除不能恢复！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return;
            string errormsg = string.Empty;
            bool flag = this.accNotes.DeleteOutSrcLossSupplyNotes (ref errormsg, this.NoteID);
            if (!flag)
            {
                MessageBox.Show(errormsg, "出借啦!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.affterSave != null) this.affterSave();
            this.Close();
        }
        
        private bool ValidateData()
        {
            if (this.ctrlCompanyID.CompanyID == -1)
            {
                MessageBox.Show("对不起,未选择委外商");
                return false;
            }
            DataRow[] drows = this.dtblItems.Select("Quantity is null");
            if (drows.Length > 0)
            {
                MessageBox.Show("存在数量为空项");
                return false;
            } 
         
            return true;
        } 
        void dgrdv_CellQuery(DataGridViewCellEventArgs e)
        { 
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnAssistantCode.Name)
            {
                
                if (this.frmGridPrd == null)
                {
                    this.frmGridPrd = new JCommon.FrmGridFind();
                    this.frmGridPrd.AddGridColumn("PrdCode", "物料编号", 100);
                    this.frmGridPrd.AddGridColumn("PrdName", "物料名称", 100);
                    this.frmGridPrd.AddGridColumn("PrdSpec", "物料规格", 100);
                    this.frmGridPrd.AddGridColumn("Model", "机型", 66);
                    this.frmGridPrd.AddGridColumn("Manufacturer", "品牌", 66);
                    this.frmGridPrd.AddGridColumn("AssistantCode", "助记码", 66);
                    this.frmGridPrd.AffterSelected += frmGridPrd_AffterSelected;

                }

                this.frmGridPrd.Query(this.dtblPrds, "AssistantCode", this.dgrdv.CurrentCell);
               
            }
        }
        void frmGridPrd_AffterSelected(DataRow drow)
        {
            int PrdID = (int)drow["PrdID"];
            DataGridViewRow grow = this.dgrdv.CurrentRow;
            grow.Cells[this.ColumnPrdID.Name].Value = PrdID;
            grow.Cells[this.ColumnPrdCode.Name].Value = drow["PrdCode"];
            grow.Cells[this.ColumnPrdName.Name].Value = drow["PrdName"];
            grow.Cells[this.ColumnPrdSpec.Name].Value = drow["PrdSpec"];
            grow.Cells[this.ColumnModel.Name].Value = drow["Model"];
            grow.Cells[this.ColumnManufacturer.Name].Value = drow["Manufacturer"];
            grow.Cells[this.ColumnUnitName.Name].Value = drow["UnitName"];

        }
        void dgrdv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            bool flag = false;
            DataRow drow = this.dtblItems.DefaultView[irow].Row;
            string ErrorMsg = string.Empty;
            if (drow["ItemID"] == DBNull.Value)
            {
                return;
            }
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {
                flag = this.accItems.DeleteOutSrcLossSupplyItems (ref ErrorMsg,
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
     
    
        void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateData() == false) return; 
            string errormsg = string.Empty;
            bool flag = false;
            if (this.NoteID == -1)
            {
                DialogResult rul = MessageBox.Show("即将新增超损单，一经保存日期不能变更！", "新增确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rul == DialogResult.No) return;
                object objNoteID = DBNull.Value;
                object objNoteCode = DBNull.Value;
                flag = this.accNotes.InsertOutSrcLossSupplyNotes(ref errormsg,
                    ref objNoteID,
                    ref objNoteCode,
                    this.dtpDateNote.Value.Date,
                    this.ctrlCompanyID.CompanyID,
                    this.ctrlMoneyTypeID .MoneyTypeID ,
                    this.ctrlSupplierAddress.SupplierAddress,
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
                flag=this.accNotes .UpdateOutSrcLossSupplyNotes (ref errormsg ,
                    this.NoteID ,
                    this.ctrlCompanyID .CompanyID ,
                    this.ctrlMoneyTypeID.MoneyTypeID ,
                    this.ctrlSupplierAddress .SupplierAddress ,
                     JERPBiz.Frame.UserBiz.PsnID,
                    this.rchMemo.Text);

            }
            if (!flag)
            {
                MessageBox.Show(errormsg);
                return;
            }
            object objItemID = DBNull.Value;
            foreach (DataRow drow in this.dtblItems.Rows )
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow.RowState == DataRowState.Unchanged) continue;
                if (drow["Quantity"] == DBNull.Value) continue;
                objItemID = drow["ItemID"];
                if (objItemID == DBNull.Value)
                {
                    flag = this.accItems.InsertOutSrcLossSupplyItems(ref errormsg,
                        ref objItemID,
                        this.NoteID,
                        drow["PrdID"],
                        drow["Quantity"],
                        drow["Price"],
                        drow["Memo"]);
                    if (flag)
                    {
                        drow["ItemID"] = objItemID;
                    }

                }
                else
                {
                    flag=this.accItems .UpdateOutSrcLossSupplyItems (ref errormsg ,
                        objItemID ,
                        drow["PrdID"],
                        drow["Quantity"],
                        drow["Price"],
                        drow["Memo"]);
                }
                drow.AcceptChanges(); 
            }
            MessageBox.Show("成功保存当前超损单");
            if (this.affterSave != null) this.affterSave(); 
            
        }
 

    }
}