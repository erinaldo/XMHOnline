using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Supply.OutSrc
{
    public partial class FrmOutSrcPriceOper : Form
    {
        public FrmOutSrcPriceOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accItems = new JERPData.Manufacture.OutSrcPriceItems();
            this.accNotes = new JERPData.Manufacture.OutSrcPriceNotes();
            this.NoteEntity = new JERPBiz.Manufacture.OutSrcPriceNoteEntity();
            this.dpkDateNote.Value = DateTime.Now.Date;
            this.btnDelete.Click += new EventHandler(btnDelete_Click);
            this.btnNew.Click += new EventHandler(btnNew_Click);
            this.btnSave .Click +=new EventHandler(btnSave_Click);
            this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
            this.dgrdv.CellContextMenuStripNeeded += new DataGridViewCellContextMenuStripNeededEventHandler(dgrdv_CellContextMenuStripNeeded);
            foreach (DataGridViewColumn col in this.dgrdv.Columns)
            {
                col.ReadOnly = true;
            }
            this.ColumnMemo.ReadOnly = false;
            this.ColumnPrice.ReadOnly = false;
            this.btnAdd.Click += new EventHandler(btnAdd_Click); 
        }

   

        private JERPData.Manufacture.OutSrcPriceNotes accNotes;
        private JERPData.Manufacture.OutSrcPriceItems accItems; 
        private JERPApp.Define.Manufacture.FrmManufProcessSelect   frmManufProcessAdd;
        private JERPApp.Define.Manufacture.FrmManufProcessSelect frmManufProcess; 
        private DataTable dtblItems;
        private JERPBiz.Manufacture.OutSrcPriceNoteEntity NoteEntity;
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
            if (this.dtblItems != null) this.dtblItems.Clear();
            this.dtblItems = this.accItems.GetDataOutSrcPriceItemsByNoteID(this.NoteID).Tables[0];          
            this.dgrdv.DataSource = this.dtblItems;

        }
        public void NewNote()
        {
            this.NoteID = -1;
            this.txtNoteCode.Text = "新报价单";
            this.ctrlFileBrowse.Clear();
            this.LoadItems();
        }
        public void EditNote(long NoteID)
        {
            this.NoteID = NoteID;
            this.NoteEntity.LoadData(NoteID);
            this.txtNoteCode.Text = this.NoteEntity.NoteCode;
            this.ctrlCompanyID .CompanyID  = this.NoteEntity.CompanyID ;
            this.ctrlOrderTypeID.OrderTypeID = this.NoteEntity.OrderTypeID;
            this.ctrlMoneyTypeID.MoneyTypeID = this.NoteEntity.MoneyTypeID;
            this.ctrlSettleTypeID.SettleTypeID = this.NoteEntity.SettleTypeID;
            this.ctrlPriceTypeID.PriceTypeID = this.NoteEntity.PriceTypeID; 
            this.rchMemo.Text = this.NoteEntity.Memo;
            string dir = JERPData.ServerParameter.ERPFileFolder + @"\Supply\OutSrc\Price\" + NoteID.ToString();
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
            if((this.dgrdv .Columns [icol].Name ==this.ColumnPrdCode .Name )
                ||(this.dgrdv .Columns [icol].Name ==this.ColumnPrdName .Name )
                || (this.dgrdv.Columns[icol].Name == this.ColumnPrdSpec.Name)
                || (this.dgrdv.Columns[icol].Name == this.ColumnModel .Name)
                ||(this.dgrdv .Columns [icol].Name ==this.ColumnPrdStatus  .Name ))
            {
                this.dgrdv.CurrentCell = this.dgrdv[icol, irow];
                if (this.frmManufProcess == null)
                {
                    frmManufProcess= new JERPApp.Define.Manufacture.FrmManufProcessSelect();
                    new FrmStyle(frmManufProcess).SetPopFrmStyle(this);
                    frmManufProcess.AffterSalected +=frmManufProcess_AffterSalected;
                }
                this.frmManufProcess.ShowDialog();
            }
        }
        void frmManufProcess_AffterSalected(DataRow drow)
        {
            long ManufProcessID = (long)drow["ManufProcessID"];
            DataRow[] rows = this.dtblItems.Select("ManufProcessID=" + ManufProcessID.ToString(), "", DataViewRowState.CurrentRows);
            if (rows.Length > 0) return;
            DataGridViewRow grow = this.dgrdv.CurrentRow;
            grow.Cells[this.ColumnManufProcessID.Name].Value = ManufProcessID;
            grow.Cells[this.ColumnPrdCode.Name].Value = drow["PrdCode"];
            grow.Cells[this.ColumnPrdName.Name].Value = drow["PrdName"];
            grow.Cells[this.ColumnPrdSpec.Name].Value = drow["PrdSpec"];
            grow.Cells[this.ColumnModel.Name].Value = drow["Model"];
            grow.Cells[this.ColumnPrdStatus.Name].Value = drow["PrdStatus"];
            this.frmManufProcess.Close();
        }
        void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.frmManufProcessAdd == null)
            {
                frmManufProcessAdd = new JERPApp.Define.Manufacture.FrmManufProcessSelect();
                new FrmStyle(frmManufProcessAdd).SetPopFrmStyle(this);
                frmManufProcessAdd.AffterSalected += frmManufProcessAdd_AffterSalected;
            }          
            this.frmManufProcessAdd.ShowDialog();
        }

        void frmManufProcessAdd_AffterSalected(DataRow drow)
        {

            long ManufProcessID = (long)drow["ManufProcessID"];
            DataRow[] rows = this.dtblItems.Select("ManufProcessID=" + ManufProcessID.ToString(),"",DataViewRowState.CurrentRows );
            if (rows.Length > 0) return;
            DataRow drowNew = this.dtblItems.NewRow();
            drowNew["ManufProcessID"] = ManufProcessID;
            drowNew["PrdCode"] = drow["PrdCode"];
            drowNew["PrdName"] = drow["PrdName"];
            drowNew["PrdSpec"] = drow["PrdSpec"];
            drowNew["PrdStatus"] = drow["PrdStatus"];
            drowNew["UnitName"] = drow["UnitName"]; 
            this.dtblItems.Rows.Add(drowNew);
        }


        void dgrdv_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (this.frmManufProcessAdd == null)
                {
                    frmManufProcessAdd = new JERPApp.Define.Manufacture.FrmManufProcessSelect();
                    new FrmStyle(frmManufProcessAdd).SetPopFrmStyle(this);
                    frmManufProcessAdd.AffterSalected += new JERPApp.Define.Manufacture.FrmManufProcessSelect.AffterSelectedDelegate(frmManufProcess_AffterSalected);
                }
                this.frmManufProcessAdd.ShowDialog();
            }
        }
        private bool ValidateData()
        {
            if (this.ctrlCompanyID.CompanyID == -1)
            {
                MessageBox.Show("供应商不能为空！", "出错啦!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (this.ctrlOrderTypeID.OrderTypeID == -1)
            {
                MessageBox.Show("订单类型不能为空！", "出错啦!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            bool flag =false;
            if (this.NoteID == -1)
            {
                object objNoteID = DBNull.Value;
                flag = this.accNotes.InsertOutSrcPriceNotes(ref errormsg, ref objNoteID,
                    this.txtNoteCode.Text,
                    this.dpkDateNote.Value.Date,
                    this.ctrlCompanyID.CompanyID,
                    this.ctrlOrderTypeID.OrderTypeID,
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
                flag = this.accNotes.UpdateOutSrcPriceNotes (ref errormsg, this.NoteID,
                    this.txtNoteCode.Text,
                    this.dpkDateNote.Value.Date,
                    this.ctrlCompanyID.CompanyID,
                    this.ctrlOrderTypeID.OrderTypeID,
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
            foreach (DataRow drow in this.dtblItems.Select("", "", DataViewRowState.CurrentRows))
            {
                if (drow.RowState == DataRowState.Unchanged) continue;
              
                if (drow["ItemID"] == DBNull.Value)
                {
                    object objItemID = DBNull.Value;
                    flag = this.accItems.InsertOutSrcPriceItems(ref errormsg, ref objItemID, this.NoteID,
                        drow["ManufProcessID"],
                        drow["Price"],
                        drow["Memo"]);
                    if (flag)
                    {
                        drow["ItemID"] = objItemID;
                    }
                }
                else
                {
                    flag=this.accItems .UpdateOutSrcPriceItems (ref errormsg ,
                        drow["ItemID"], 
                        drow["ManufProcessID"],
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
                flag = this.accItems.DeleteOutSrcPriceItems (ref ErrorMsg,
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
            bool flag = this.accNotes.DeleteOutSrcPriceNotes(ref errormsg, this.NoteID);
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