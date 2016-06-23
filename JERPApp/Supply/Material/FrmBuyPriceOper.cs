using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Supply.Material
{
    public partial class FrmBuyPriceOper : Form
    {
        public FrmBuyPriceOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv; 
            this.dpkDateNote.Value = DateTime.Now.Date;
            this.accItems = new JERPData.Material.BuyPriceItems();
            this.accNotes = new JERPData.Material.BuyPriceNotes();
            this.NoteEntity = new JERPBiz.Material.BuyPriceNoteEntity();
            this.accPrds = new JERPData.Product.Product();
            this.btnDelete.Click += new EventHandler(btnDelete_Click);
            this.btnNew.Click += new EventHandler(btnNew_Click);
            this.btnSave .Click +=new EventHandler(btnSave_Click);
            this.btnImport.Click += new EventHandler(btnImport_Click);
            this.dgrdv.CellQuery += new JCommon.MyDataGridView.CellQueryDelegate(dgrdv_CellQuery);
            this.dgrdv.CellContextMenuStripNeeded += new DataGridViewCellContextMenuStripNeededEventHandler(dgrdv_CellContextMenuStripNeeded);
            this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
            this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
            this.btnPrd.Click += new EventHandler(btnAdd_Click);
            this.dtblPrds = this.accPrds.GetDataProductForMaterial().Tables[0];
            foreach (DataGridViewColumn col in this.dgrdv.Columns)
            {
                col.ReadOnly = true;
            }
            this.ColumnAssistantCode.ReadOnly = false;
            this.ColumnPrice.ReadOnly = false;
            this.ColumnMemo.ReadOnly = false;
        }

        private JERPData.Material.BuyPriceNotes accNotes;
        private JERPData.Material.BuyPriceItems accItems;
        private JERPData.Product.Product accPrds; 
        private JERPApp.Define.Material.FrmProduct    frmPrd;
        private JERPApp.Define.Material.FrmPrdMore frmPrdMore;
        private DataTable dtblPrds, dtblItems; 
        private JCommon.FrmGridFind frmGridPrd;
        private JCommon.FrmExcelImport frmImport;
        private JERPBiz.Material.BuyPriceNoteEntity NoteEntity;
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
            this.dtblItems = this.accItems.GetDataBuyPriceItemsByNoteID(this.NoteID).Tables[0];
            this.dtblItems.Columns["PrdID"].AllowDBNull = false;
            this.dtblItems.Columns["PrdID"].Unique = true;
            this.dgrdv.DataSource = this.dtblItems;

        }
        public void NewNote()
        {
            this.NoteID = -1;
            this.NoteEntity.LoadData(-1);
            this.txtNoteCode.Text = "新报价单";  
            this.ctrlFileBrowse.Clear();
            this.LoadItems();
        }
        public void EditNote(long NoteID)
        {
            this.NoteID = NoteID;
            this.NoteEntity.LoadData(NoteID);
            this.txtNoteCode.Text = this.NoteEntity.NoteCode;
            this.ctrlCompanyID.CompanyID = this.NoteEntity.CompanyID;
            this.dpkDateNote.Value = this.NoteEntity.DateNote;
            this.ctrlMoneyTypeID .MoneyTypeID  = this.NoteEntity.MoneyTypeID ;
            this.ctrlSettleTypeID .SettleTypeID  = this.NoteEntity.SettleTypeID ;
            this.ctrlPriceTypeID .PriceTypeID  = this.NoteEntity.PriceTypeID ;
            this.rchMemo.Text = this.NoteEntity.Memo;
            string dir = JERPData.ServerParameter.ERPFileFolder + @"\Purchase\Material\Price\" + NoteID.ToString();
            if (System.IO.Directory.Exists(dir) == false)
            {
                System.IO.Directory.CreateDirectory(dir);
            }
            this.ctrlFileBrowse.Browse(dir);
            this.LoadItems();

        }

        void btnImport_Click(object sender, EventArgs e)
        {
            if (frmImport == null)
            {
                frmImport = new JCommon.FrmExcelImport();
                new FrmStyle(frmImport).SetPopFrmStyle(this);
                DataColumn[] columns = new DataColumn[]{    
                    new DataColumn ("物料编号",typeof (string)),  
                    new DataColumn ("单价",typeof (decimal)),
                    new DataColumn ("备注",typeof (string))
                 };
                frmImport.SetImportColumn(columns, "物料编号不能为空,新导入的单价将会覆盖之前的单价");
                frmImport.ImportHandle += new JCommon.FrmExcelImport.ImportDelegate(frmImport_ImportHandle);
                frmImport.AffterSave += new JCommon.FrmExcelImport.AffterSaveDelegate(frmImport_AffterSave);
            }
            frmImport.ShowDialog();
        }
 
        void frmImport_ImportHandle(DataRow drow, out bool flag, out string msg)
        {
            flag = true;
            msg = "成功";
            DataRow[] drowPrds = this.dtblPrds.Select("PrdCode='" + drow["物料编号"].ToString () + "'");
            if (drowPrds.Length==0)
            {
                flag = false;
                msg = "不存此物料编号";
                return;
            }
            int PrdID = (int)drowPrds[0]["PrdID"]; 
            DataRow[] drowItems = this.dtblItems.Select("PrdID=" + PrdID.ToString());
            DataRow drowItem;
            if (drowItems.Length > 0)
            {
                drowItem = drowItems[0];
                drowItem["Price"] = drow["单价"];
                drowItem["Memo"] = drow["备注"];
            }
            else
            {
                drowItem = this.dtblItems.NewRow();
                drowItem["PrdID"] = PrdID;
                drowItem["PrdCode"] = drowPrds[0]["PrdCode"];
                drowItem["PrdName"] = drowPrds[0]["PrdName"];
                drowItem["PrdSpec"] =drowPrds[0]["PrdSpec"];
                drowItem["Model"] = drowPrds[0]["Model"];
                drowItem["Manufacturer"] = drowPrds[0]["Manufacturer"];
                drowItem["UnitName"] = drowPrds[0]["UnitName"];
                drowItem["Price"] = drow["单价"];
                drowItem["Memo"] = drow["备注"];
                this.dtblItems.Rows.Add(drowItem);
            }
        }
        void frmImport_AffterSave()
        {
            MessageBox.Show("导入完成，请点击保存");
        }

     
        void dgrdv_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if ((this.dgrdv.Columns[icol].Name  ==this.ColumnPrdCode .Name )
                ||(this.dgrdv.Columns[icol].Name  ==this.ColumnPrdName .Name )
                ||(this.dgrdv.Columns[icol].Name  ==this.ColumnPrdSpec .Name )                
                ||(this.dgrdv.Columns[icol].Name  ==this.ColumnModel .Name )             
                ||(this.dgrdv.Columns[icol].Name  ==this.ColumnManufacturer .Name ))
            {
                this.dgrdv.CurrentCell = this.dgrdv[icol, irow];
                if (this.frmPrd == null)
                {
                    frmPrd = new JERPApp.Define.Material.FrmProduct();
                    new FrmStyle(frmPrd).SetPopFrmStyle(this);
                    frmPrd.AffterSelected += new JERPApp.Define.Material.FrmProduct.AffterSelectedDelegate(frmPrd_AffterSelected);
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
            grow.Cells[this.ColumnManufacturer.Name].Value = drow["Manufacturer"];
            grow.Cells[this.ColumnURL .Name].Value = drow["URL"];
            grow.Cells[this.ColumnUnitName.Name].Value = drow["UnitName"];
            this.frmPrd.Close();
        }

        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnPrdCode.Name)
            {
                string url = this.dgrdv[this.ColumnURL.Name, irow].Value.ToString();
                if (url == string.Empty) return;
                System.Diagnostics.Process.Start(url);
            }
        }

        void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.frmPrdMore  == null)
            {
                frmPrdMore = new JERPApp.Define.Material.FrmPrdMore();
                new FrmStyle(frmPrdMore).SetPopFrmStyle(this);
                frmPrdMore.AffterSelected += new JERPApp.Define.Material.FrmPrdMore.AffterSelectedDelegate(frmPrdMore_AffterSelected);
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
            drowNew["Manufacturer"] = drow["Manufacturer"];
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
                    this.frmGridPrd.AddGridColumn("PrdCode", "物料编号", 100);
                    this.frmGridPrd.AddGridColumn("PrdName", "物料名称", 100);
                    this.frmGridPrd.AddGridColumn("PrdSpec", "物料规格", 120);
                    this.frmGridPrd.AddGridColumn("Manufacturer", "品牌", 66);
                    this.frmGridPrd.AddGridColumn("AssistantCode", "助记码", 66);
                    this.frmGridPrd.AffterSelected += frmGridPrd_AffterSelected;

                }
                this.frmGridPrd.Query(this.dtblPrds, "AssistantCode", this.dgrdv.CurrentCell);
            }
        }
        void frmGridPrd_AffterSelected(DataRow drow)
        {
            DataGridViewRow grow = this.dgrdv.CurrentRow;
            grow.Cells[this.ColumnPrdID.Name].Value = drow["PrdID"];
            grow.Cells[this.ColumnPrdCode.Name].Value = drow["PrdCode"];
            grow.Cells[this.ColumnPrdName.Name].Value = drow["PrdName"];
            grow.Cells[this.ColumnPrdSpec.Name].Value = drow["PrdSpec"];
            grow.Cells[this.ColumnModel.Name].Value = drow["Model"];
            grow.Cells[this.ColumnManufacturer.Name].Value = drow["Manufacturer"];
            grow.Cells[this.ColumnUnitName .Name].Value = drow["UnitName"];
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
                flag = this.accNotes.InsertBuyPriceNotes(ref errormsg, ref objNoteID,
                    this.txtNoteCode.Text,
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
                flag = this.accNotes.UpdateBuyPriceNotes(ref errormsg, this.NoteID,
                    this.txtNoteCode.Text,
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
                    flag = this.accItems.InsertBuyPriceItems(ref errormsg,
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
                    flag=this.accItems .UpdateBuyPriceItems (ref errormsg ,
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
                flag = this.accItems.DeleteBuyPriceItems (ref ErrorMsg,
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
            bool flag = this.accNotes.DeleteBuyPriceNotes(ref errormsg, this.NoteID);
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