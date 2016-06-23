using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Common
{
    public partial class FrmMtrBuyApplyOper : Form
    {
        public FrmMtrBuyApplyOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false; 
            this.accItems = new JERPData.Material.BuyOrderApplyItems();
            this.accNotes = new JERPData.Material.BuyOrderApplyNotes();
            this.accPrds = new JERPData.Product.Product();
            this.NoteEntity = new JERPBiz.Material.BuyOrderApplyNoteEntity();
            this.dtblPrds = this.accPrds.GetDataProductForMaterial().Tables[0];
            this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
            this.dgrdv.CellContextMenuStripNeeded += new DataGridViewCellContextMenuStripNeededEventHandler(dgrdv_CellContextMenuStripNeeded); 
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.dgrdv.CellQuery += new JCommon.MyDataGridView.CellQueryDelegate(dgrdv_CellQuery); 
            this.btnAddPrd.Click += new EventHandler(btnAddPrd_Click);
            this.btnDelete.Click += new EventHandler(btnDelete_Click);
            this.btnNew.Click += new EventHandler(btnNew_Click);
        }

        private JERPData.Material.BuyOrderApplyNotes accNotes;
        private JERPData.Material.BuyOrderApplyItems accItems;
        private JERPBiz.Material.BuyOrderApplyNoteEntity NoteEntity;
        private JERPData.Product .Product accPrds; 
        private JERPApp.Define.Material.FrmProduct frmPrd;
        private JERPApp.Define.Material.FrmProduct frmAddPrd;
        private JCommon.FrmGridFind frmGridPrd;
        private DataTable dtblItems, dtblPrds ; 
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
                this.btnDelete.Enabled = (value> -1);
            }
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
                    this.frmPrd = new JERPApp.Define.Material.FrmProduct();
                    new FrmStyle(this.frmPrd).SetPopFrmStyle(this);
                    this.frmPrd.AffterSelected += new JERPApp.Define.Material .FrmProduct.AffterSelectedDelegate(frmPrd_AffterSelected);
                }
                this.frmPrd.ShowDialog();
            }
        }

        void frmPrd_AffterSelected(DataRow drow)
        {
            int PrdID = (int)drow["PrdID"];
            DataGridViewRow grow = this.dgrdv.CurrentRow;
            grow.Cells[this.ColumnPrdID.Name].Value = PrdID;
            grow.Cells[this.ColumnPrdCode.Name].Value = drow["PrdCode"];
            grow.Cells[this.ColumnPrdName.Name].Value = drow["PrdName"];
            grow.Cells[this.ColumnPrdSpec.Name].Value = drow["PrdSpec"];
            grow.Cells[this.ColumnModel.Name].Value = drow["Model"];
            grow.Cells[this.ColumnUnitName.Name].Value = drow["UnitName"]; 
           
            frmPrd.Close();

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
                MessageBox.Show("已存在此产品");
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
            this.dtblItems.Rows.Add(drowNew);

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
        private void LoadItems()
        {
            this.dtblItems = this.accItems.GetDataBuyOrderApplyItemsByNoteID(this.NoteID ).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
            this.dtblItems.Columns["PrdID"].AllowDBNull = false;
            this.dtblItems.Columns["Quantity"].AllowDBNull = false; 
        }
        public void New()
        {
            this.NoteID = -1;
            this.dtpDateNote.Value = DateTime.Now.Date; 
            this.rchMemo.Text = string.Empty;
            this.LoadItems();
        }
        public void Edit(long NoteID)
        {
            this.NoteID = NoteID;
            this.NoteEntity.LoadData(NoteID);
            this.dtpDateNote.Value = this.NoteEntity.DateNote;
            this.ctrlDeptID.DeptID = this.NoteEntity.DeptID;
            this.rchMemo.Text = this.NoteEntity.Memo;
            this.LoadItems();
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
                flag = this.accItems.DeleteBuyOrderApplyItems (ref ErrorMsg,
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

        void btnNew_Click(object sender, EventArgs e)
        {
            this.New();
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
               DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
               if (rul == DialogResult.Yes)
               {
                   string errormsg = string.Empty;
                   bool flag = this.accNotes.DeleteBuyOrderApplyNotes(ref errormsg,
                       this.NoteID);
                   if (flag)
                   {
                       MessageBox.Show("成功删除当前申购单");
                   }
                   else
                   {
                       MessageBox.Show(errormsg);
                   }
                   if (this.affterSave != null) this.affterSave();
               }
        }

      
        void btnSave_Click(object sender, EventArgs e)
        { 
            string errormsg = string.Empty;
            bool flag = false;
            if (this.NoteID == -1)
            {
                object objNoteID = DBNull.Value;
                flag = this.accNotes.InsertBuyOrderApplyNotes(ref errormsg, ref objNoteID,
                    this.dtpDateNote.Value.Date,
                    this.ctrlDeptID.DeptID,
                    this.rchMemo.Text,                    
                    JERPBiz.Frame.UserBiz.PsnID);
                if (flag)
                {
                    this.NoteID = (long)objNoteID;
                } 
            }
            else
            {
                flag = this.accNotes.UpdateBuyOrderApplyNotes(ref errormsg,
                    this.NoteID,
                    this.dtpDateNote.Value.Date,
                    this.ctrlDeptID.DeptID,
                    this.rchMemo.Text,
                    JERPBiz.Frame.UserBiz.PsnID);
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
                objItemID = drow["ItemID"];
                if (objItemID == DBNull.Value)
                {
                    flag = this.accItems.InsertBuyOrderApplyItems(ref errormsg,
                        ref objItemID,
                       this.NoteID,
                       drow["PrdID"],
                       drow["Quantity"],
                       drow["Memo"]);
                    if (flag)
                    {
                        drow["ItemID"] = objItemID;
                    }
                }
                else
                {
                    flag=this.accItems .UpdateBuyOrderApplyItems (
                        ref errormsg ,
                       objItemID ,
                       drow["PrdID"],
                       drow["Quantity"],
                       drow["Memo"]);

                }               
            }              
            MessageBox.Show("成功保存并入账当前申购单");
            if (this.affterSave != null) this.affterSave(); 
            
        } 
    }
}