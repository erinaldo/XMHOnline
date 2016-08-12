using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Sale
{
    public partial class FrmSalePriceOper : Form
    {
        public FrmSalePriceOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv; 
            this.dpkDateNote.Value = DateTime.Now.Date;
            this.accItems = new JERPData.Product.SalePriceItems();
            this.accNotes = new JERPData.Product.SalePriceNotes();
            this.NoteEntity = new JERPBiz.Product.SalePriceNoteEntity();
            this.accPrds = new JERPData.Product.Product();
            this.btnDelete.Click += new EventHandler(btnDelete_Click);
            this.btnNew.Click += new EventHandler(btnNew_Click);
            this.btnSave .Click +=new EventHandler(btnSave_Click);
            this.dgrdv.CellQuery += new JCommon.MyDataGridView.CellQueryDelegate(dgrdv_CellQuery);
            this.dgrdv.CellContextMenuStripNeeded += new DataGridViewCellContextMenuStripNeededEventHandler(dgrdv_CellContextMenuStripNeeded);
            this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
            this.btnPrd.Click += new EventHandler(btnAdd_Click);
            this.dtblPrds = this.accPrds.GetDataProductForFinishedPrd().Tables[0];
           
        }

     
        private JERPData.Product.SalePriceNotes accNotes;
        private JERPData.Product.SalePriceItems accItems;
        private JERPData.Product.Product accPrds; 
        private JERPApp.Define.Product.FrmFinishedPrd    frmPrd;
        private JERPApp.Define.Product.FrmFinishedPrdMore frmPrdMore;
        private DataTable dtblPrds, dtblItems; 
        private JCommon.FrmGridFind frmGridPrd;
        private JERPBiz.Product.SalePriceNoteEntity NoteEntity;
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
                this.ctrlFileBrowse.ReadOnly = (value == -1);
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
  
        private void LoadItems()
        {
            this.dtblItems = this.accItems.GetDataSalePriceItemsByNoteID(this.NoteID).Tables[0];
            this.dtblItems.Columns["PrdID"].AllowDBNull = false;
            this.dtblItems.Columns["PrdID"].Unique = true;
            this.dgrdv.DataSource = this.dtblItems;

        }
        public void NewNote()
        {
            this.NoteID = -1;
            this.NoteEntity.LoadData(-1); 
            this.ctrlFileBrowse.Clear();
            this.LoadItems();
        }
        public void EditNote(long NoteID)
        {
            this.NoteID = NoteID;
            this.NoteEntity.LoadData(NoteID); 
            this.ctrlCompanyID.CompanyID = this.NoteEntity.CompanyID;
            this.dpkDateNote.Value = this.NoteEntity.DateNote;
            this.ctrlMoneyTypeID .MoneyTypeID  = this.NoteEntity.MoneyTypeID ;
            this.ctrlSettleTypeID .SettleTypeID  = this.NoteEntity.SettleTypeID ;
            this.ctrlPriceTypeID .PriceTypeID  = this.NoteEntity.PriceTypeID ;
            this.rchMemo.Text = this.NoteEntity.Memo;
            string dir = JERPData.ServerParameter.ERPFileFolder + @"\Purchase\Product\Price\" + NoteID.ToString();
            if (System.IO.Directory.Exists(dir) == false)
            {
                System.IO.Directory.CreateDirectory(dir);
            }
            this.ctrlFileBrowse.Browse(dir);
            this.LoadItems();

        }

        void dgrdv_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if ((this.dgrdv.Columns[icol].DataPropertyName == "PrdCode")
              || (this.dgrdv.Columns[icol].DataPropertyName == "PrdName")
              || (this.dgrdv.Columns[icol].DataPropertyName == "PrdSpec")
              || (this.dgrdv.Columns[icol].DataPropertyName == "Model"))
            {

                this.dgrdv.CurrentCell = this.dgrdv[icol, irow];
                if (this.frmPrd == null)
                {
                    frmPrd = new JERPApp.Define.Product.FrmFinishedPrd();
                    new FrmStyle(frmPrd).SetPopFrmStyle(this);
                    frmPrd.AffterSelected +=frmPrd_AffterSelected;
                }
                this.frmPrd.ShowDialog();

            }
        }

        void frmPrd_AffterSelected(DataRow drow)
        {
            DataGridViewRow grow = this.dgrdv.CurrentRow;
            grow.Cells[this.ColumnPrdID.Name].Value = drow["PrdID"];
            grow.Cells[this.ColumnPrdCode.Name].Value = drow["PrdCode"];
            grow.Cells[this.ColumnPrdName.Name].Value = drow["PrdName"];
            grow.Cells[this.ColumnPrdSpec.Name].Value = drow["PrdSpec"];
            grow.Cells[this.ColumnModel.Name].Value = drow["Model"];
            grow.Cells[this.ColumnUnitName.Name].Value = drow["UnitName"];
            this.frmPrd.Close();

            this.frmPrd.Close();
        }

        void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.frmPrdMore  == null)
            {
                frmPrdMore = new JERPApp.Define.Product.FrmFinishedPrdMore();
                new FrmStyle(frmPrdMore).SetPopFrmStyle(this);
                frmPrdMore.AffterSelected += frmPrdMore_AffterSelected;
            }
            this.frmPrdMore.ShowDialog();
        }

        void frmPrdMore_AffterSelected(DataRow drow)
        { 
            int PrdID = (int)drow["PrdID"];
            DataRow[] rows = this.dtblItems.Select("PrdID=" + PrdID.ToString(),"",DataViewRowState.CurrentRows   );
            if (rows.Length > 0) return;
            DataRow drowNew = this.dtblItems.NewRow();
            drowNew["PrdID"] = PrdID;
            drowNew["PrdCode"] = drow["PrdCode"];
            drowNew["PrdName"] = drow["PrdName"];
            drowNew["PrdSpec"] = drow["PrdSpec"];
            drowNew["Model"] = drow["Model"];
            drowNew["UnitName"] = drow["UnitName"]; 
            drowNew["Price"] =0; 
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
                    this.frmGridPrd.AddGridColumn("PrdCode", "产品编号", 100);
                    this.frmGridPrd.AddGridColumn("PrdName", "产品名称", 100);
                    this.frmGridPrd.AddGridColumn("PrdSpec", "产品规格", 120);
                    this.frmGridPrd.AddGridColumn("Model", "机型", 66);
                    this.frmGridPrd.AddGridColumn("AssistantCode", "助记码", 66); 
                    this.frmGridPrd.AffterSelected += frmGridPrd_AffterSelected;

                }
                this.frmGridPrd.Query(this.dtblPrds, "AssistantCode", this.dgrdv.CurrentCell);
            }
        }
        void frmGridPrd_AffterSelected(DataRow drow)
        {
            DataGridViewRow grow = this.dgrdv.CurrentRow;
            grow.Cells[this.ColumnPrdCode.Name].Value = drow["PrdID"];
        }

        private bool ValidateData()
        {
            if (this.ctrlCompanyID.CompanyID == -1)
            {
                MessageBox.Show("客户不能为空！", "出错啦!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (this.ctrlMoneyTypeID.MoneyTypeID == -1)
            {
                MessageBox.Show("币种不能为空！", "出错啦!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (this.ctrlSettleTypeID.SettleTypeID == -1)
            {
                MessageBox.Show("结算方式！", "出错啦!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (this.ctrlPriceTypeID.PriceTypeID == -1)
            {
                MessageBox.Show("单价类型！", "出错啦!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    
        private bool SaveNote()
        {
            string errormsg = string.Empty;
            bool flag = false;
            if (this.NoteID == -1)
            {
                object objNoteID = DBNull.Value; 
                flag = this.accNotes.InsertSalePriceNotes(ref errormsg, ref objNoteID, 
                    this.dpkDateNote.Value.Date,
                    this.ctrlCompanyID.CompanyID,
                    this.ctrlMoneyTypeID.MoneyTypeID,
                    this.ctrlSettleTypeID.SettleTypeID,
                    this.ctrlPriceTypeID.PriceTypeID,
                    JERPBiz.Frame.UserBiz.PsnID,
                    this.rchMemo.Text);
                if (flag)
                {
                    this.NoteID = (long)objNoteID;
                }
            }
            else
            {
                flag = this.accNotes.UpdateSalePriceNotes(ref errormsg, 
                    this.NoteID, 
                    this.dpkDateNote.Value.Date,
                    this.ctrlCompanyID.CompanyID,
                    this.ctrlMoneyTypeID.MoneyTypeID,
                    this.ctrlSettleTypeID.SettleTypeID,
                    this.ctrlPriceTypeID.PriceTypeID,
                    JERPBiz.Frame.UserBiz.PsnID,
                    this.rchMemo.Text);
            }
            return flag;
        }
        void SaveItem()
        {
            string errormsg = string.Empty;
            bool flag = false;
            foreach (DataRow drow in this.dtblItems.Rows )
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow.RowState == DataRowState.Unchanged) continue;              
                if (drow["ItemID"] == DBNull.Value)
                {
                    object objItemID = DBNull.Value;
                    flag = this.accItems.InsertSalePriceItems(ref errormsg,
                        ref objItemID, 
                        this.NoteID,
                        drow["PrdID"], 
                        drow["Price"],
                        drow["Memo"]);
                    if (flag)
                    {
                        drow["ItemID"] = objItemID;
                    }
                }
                else
                {
                    flag=this.accItems .UpdateSalePriceItems (ref errormsg ,
                        drow["ItemID"],
                        drow["PrdID"],
                        drow["Price"],
                        drow["Memo"]);
                }
                if(flag)
                {
                      drow.RowError = string.Empty;
                      drow.AcceptChanges();
                }
                else
                {
                    drow.RowError = string.Empty;
                }

            }
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
                flag = this.accItems.DeleteSalePriceItems (ref ErrorMsg,
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
            this.NewNote();
        }
       

        void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult rul = MessageBox.Show("将进行报价单删除,一经删除不能恢复!", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return;
            string errormsg = string.Empty;
            bool flag = this.accNotes.DeleteSalePriceNotes(ref errormsg, this.NoteID);
            if (flag)
            {
                MessageBox.Show("成功删除当前报价单");
            }
            else
            {
                 MessageBox.Show(errormsg , "出错啦!", MessageBoxButtons.OK , MessageBoxIcon.Error );
            }
            if (this.affterSave != null) this.affterSave();
            this.Close();
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateData() == false) return;
            DialogResult rul = MessageBox.Show("将进行数据保存!", "保存确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return;
            if (this.SaveNote())
            {
                this.SaveItem();
                MessageBox.Show("成功进行单据保存");
                if (this.affterSave != null) this.affterSave();
            }
            
        }

      
    

    }
}