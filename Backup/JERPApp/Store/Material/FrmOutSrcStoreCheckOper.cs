using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Material
{
    public partial class FrmOutSrcStoreCheckOper : Form
    {
        public FrmOutSrcStoreCheckOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false; 
            this.accStore = new JERPData.Material.OutSrcStore();
            this.accPrds = new JERPData.Product.Product(); 
            this.accItems = new JERPData.Material.OutSrcStoreCheckItems();
            this.accNotes = new JERPData.Material.OutSrcStoreCheckNotes();
            this.NoteEntity = new JERPBiz.Material.OutSrcStoreCheckNoteEntity();
            this.ctrlQFind.SeachGridView = this.dgrdv; 
            foreach (DataGridViewColumn col in this.dgrdv.Columns)
            {
                col.ReadOnly = true;
            }
            this.ColumnCheckQty.ReadOnly = false;
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnImport.Click += new EventHandler(btnImport_Click);
            this.btnAppend.Click += new EventHandler(btnAppend_Click);
            this.btnDelete .Click +=new EventHandler(btnDelete_Click);
            //加载数据
            this.ctrlCompanyID.AffterSelected += new JERPApp.Define.General.CtrlSupplierForOutSrc.AffterSelectedDelegate(ctrlCompanyID_AffterSelected);
            this.dgrdv .UserDeletingRow +=new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
            this.btnExport.Click += new EventHandler(btnExport_Click);
        }


        private JERPData.Product.Product accPrds;
        private JERPData.Material.OutSrcStore accStore;
        private JERPApp.Define.Material .FrmPrdMore frmPrd; 
        private JERPData.Material.OutSrcStoreCheckItems accItems;
        private JERPData.Material.OutSrcStoreCheckNotes accNotes;
        private JERPBiz.Material.OutSrcStoreCheckNoteEntity NoteEntity; 
        private JCommon.FrmExcelImport frmImport;
        private DataTable dtblItems;
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
                this.ctrlCompanyID.Enabled = (value == -1);
                this.dtpDateNote.Enabled = (value == -1);
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
        public void New()
        {
            this.NoteID = -1;
            this.txtNoteCode.Text = string.Empty;
            this.ctrlCompanyID.CompanyID = -1;
            this.dtpDateNote.Value = DateTime.Now;
            this.txtCheckPersons.Text = string.Empty;
            this.rchMemo.Text = string.Empty;
            this.LoadItems();

        }
        public void Edit(long NoteID)
        {
            this.NoteID = NoteID;
            this.NoteEntity.LoadData(NoteID);
            this.txtNoteCode.Text = this.NoteEntity.NoteCode;
            this.ctrlCompanyID.CompanyID = this.NoteEntity.CompanyID;
            this.dtpDateNote.Value = this.NoteEntity.DateNote;
            this.txtCheckPersons.Text = this.NoteEntity.CheckPersons;
            this.rchMemo.Text = this.NoteEntity.Memo;
            this.LoadItems();
        }

        void ctrlCompanyID_AffterSelected()
        {
            DataTable dtblStore = this.accPrds.GetDataProductForMtrOutSrcCheckStore(this.ctrlCompanyID.CompanyID).Tables[0];
            foreach (DataRow drow in dtblStore.Rows)
            {
                if (this.dtblItems.Select("PrdID=" + drow["PrdID"].ToString(), "", DataViewRowState.CurrentRows).Length > 0) continue;
                drow["InventoryQty"] = DBNull.Value;
                this.dtblItems.ImportRow(drow);
            }
        }
        private   void LoadItems()
        {
            this.dtblItems = this.accItems .GetDataOutSrcStoreCheckItemsByNoteID  (this.NoteID ).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
        }
        
      
        void btnImport_Click(object sender, EventArgs e)
        {
            if (this.frmImport == null)
            {
                frmImport = new JCommon.FrmExcelImport();
                new FrmStyle(frmImport).SetPopFrmStyle(this);
                DataColumn[] columns = new DataColumn[]{                  
                    new DataColumn ("原料编号",typeof (string )),
                    new DataColumn ("数量",typeof (decimal))
                };
                frmImport.SetImportColumn(columns, "数量:必填且为数值;");
                frmImport.ImportHandle += new JCommon.FrmExcelImport.ImportDelegate(frmImport_ImportHandle);

            }
            frmImport.ShowDialog();
        }
        private int GetPrdID(string PrdCode)
        {
            int rut = -1;
            this.accPrds.GetParmProductPrdID(PrdCode, ref rut);
            return rut;
        }
       
        void frmImport_ImportHandle(DataRow drow, out bool flag, out string msg)
        {
            msg = string.Empty;
            flag = true;
            DataRow[] rows = this.dtblItems .Select("PrdCode='" + drow["PrdCode"].ToString() + "'","",DataViewRowState.CurrentRows);
            if (rows.Length > 0)
            {
                rows[0]["CheckQty"] = drow["数量"];
                return;
            }
            int PrdID = this.GetPrdID(drow["PrdCode"].ToString());
            DataRow drowNew = this.dtblItems.NewRow();
            drowNew["PrdID"] = PrdID;
            drowNew["PrdCode"] = drow["原料编号"];
            drowNew["CheckQty"] = drow["数量"];
            this.dtblItems.Rows.Add(drowNew);
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
                flag = this.accItems.DeleteOutSrcStoreCheckItems (ref ErrorMsg,
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
 
        private bool ValidateData()
        {
            if (this.ctrlCompanyID.CompanyID  == -1)
            {
                MessageBox.Show("未选择任何供应商");
                return false;
            }  
            return true;
        }

        void btnAppend_Click(object sender, EventArgs e)
        {
            if (frmPrd == null)
            {
                frmPrd = new JERPApp.Define.Material.FrmPrdMore();
                new FrmStyle(frmPrd).SetPopFrmStyle(this);
                frmPrd.AffterSelected += frmPrd_AffterSelected;
            }
            frmPrd.ShowDialog();
        }

        void frmPrd_AffterSelected(DataRow drow)
        {
            DataRow[] drows = this.dtblItems.Select("PrdID=" + drow["PrdID"].ToString(),"",DataViewRowState.CurrentRows );
            if (drows.Length > 0) return;           
            DataRow drowNew = this.dtblItems.NewRow();
            drowNew["PrdID"] = drow["PrdID"];
            drowNew["PrdCode"] = drow["PrdCode"];
            drowNew["PrdName"] = drow["PrdName"];
            drowNew["PrdSpec"] = drow["PrdSpec"];
            drowNew["Model"] = drow["Model"];
            drowNew["Manufacturer"] = drow["Manufacturer"];
            drowNew["UnitName"] = drow["UnitName"];
            this.dtblItems.Rows.Add(drowNew);
            this.frmPrd.Close();
        }

        void btnExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "物料委外盘点单");
            excel.SetCellVal("A2", "供应商:" + this.ctrlCompanyID .CompanyAbbName+" 盘点日期:"+
                this.dtpDateNote .Value .ToShortDateString ()+" 盘点人:"+this.txtCheckPersons .Text );
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            FrmMsg.Hide();
            excel.Show();
        }
        private bool SaveNote()
        {
            string errormsg = string.Empty;
            bool flag = false;
            if (this.NoteID == -1)
            {
                DialogResult rsl = MessageBox.Show("将进行保存,一经保存库位和盘点日期将不能变更，确认否?",
            "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rsl == DialogResult.No) return false;
                object objNoteID = DBNull.Value;
                object objNoteCode = DBNull.Value;
                this.dtpDateNote.Value = DateTime.Now;
                flag = this.accNotes.InsertOutSrcStoreCheckNotes (ref errormsg,
                    ref objNoteID,
                    ref objNoteCode,
                    this.dtpDateNote.Value,
                    this.ctrlCompanyID .CompanyID ,
                    JERPBiz.Frame.UserBiz.PsnID,
                    this.txtCheckPersons.Text,
                    this.rchMemo.Text);
                if (flag)
                {
                    this.NoteID = (long)objNoteID;
                    this.txtNoteCode.Text = objNoteCode.ToString();
                }

            }
            else
            {
                flag = this.accNotes.UpdateOutSrcStoreCheckNotes (
                    ref errormsg,
                    this.NoteID,
                    JERPBiz.Frame.UserBiz.PsnID,
                    this.txtCheckPersons.Text,
                    this.rchMemo.Text);

            }
            if (!flag)
            {
                MessageBox.Show(errormsg);
            }
            return flag;
        }
        private void SaveItem()
        {
            object objItemID = DBNull.Value;
            string errormsg = string.Empty;
            bool flag = false;
            foreach (DataRow drow in this.dtblItems.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow["ItemID"] == DBNull.Value)
                {
                    objItemID = DBNull.Value;
                    flag=this.accItems.InsertOutSrcStoreCheckItems (
                        ref errormsg,
                        ref objItemID,
                        this.NoteID,
                        drow["PrdID"],
                        drow["CheckQty"]);
                    if (flag)
                    {
                        drow["ItemID"] = objItemID;
                    }
                }
                else
                {
                    this.accItems.UpdateOutSrcStoreCheckItems (ref errormsg,
                        drow["ItemID"],
                        drow["CheckQty"]);

                }
            }
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult rsl = MessageBox.Show("即将删除当前盘点单，一经删除不能恢得，确认否?",
         "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rsl == DialogResult.No) return;
            string errormsg = string.Empty;
            bool flag = this.accNotes.DeleteOutSrcStoreCheckNotes (ref errormsg,
                this.NoteID);
            if (flag)
            {
                MessageBox.Show("成功删除当前盘点单!");

            }
            else
            {
                MessageBox.Show(errormsg);
            }
            if (this.affterSave != null) this.affterSave();
            this.Close();
        }
        void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateData() == false) return;
            if (this.SaveNote())
            {
                this.SaveItem();
            }
            this.LoadItems();
            if (this.affterSave != null) this.affterSave();
            MessageBox.Show("成功保存并入账当前盘点单");
        }
    }
}