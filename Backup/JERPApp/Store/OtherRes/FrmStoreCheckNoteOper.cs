using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.OtherRes
{
    public partial class FrmStoreCheckNoteOper : Form
    {
        public FrmStoreCheckNoteOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accNotes = new JERPData.OtherRes.StoreCheckNotes();
            this.accItems = new JERPData.OtherRes.StoreCheckItems();
            this.NoteEntity = new JERPBiz.OtherRes.StoreCheckNoteEntity();
            this.accStore = new JERPData.OtherRes.Store();
            this.accPrds = new JERPData.OtherRes.Product();
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.ctrlBranchStoreID.AffterSelected += ctrlBranchStoreID_AffterSelected;
            this.btnImport.Click += new EventHandler(btnImport_Click);
            this.btnExport .Click +=new EventHandler(btnExport_Click);
            this.btnPrd.Click += new EventHandler(btnPrd_Click);
            this.btnDelete.Click += new EventHandler(btnDelete_Click);
            this.dgrdv .UserDeletingRow +=new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
            this.dtblPrds = this.accPrds.GetDataProduct().Tables[0];
        }


        private JERPData.OtherRes.StoreCheckNotes accNotes;
        private JERPData.OtherRes.StoreCheckItems accItems; 
        private JERPData.OtherRes.Store accStore;
        private JERPData.OtherRes.Product accPrds;
        private JERPBiz.OtherRes.StoreCheckNoteEntity NoteEntity;
        private JCommon.FrmExcelImport frmImport;
        private JERPApp.Define.OtherRes.FrmPrdMore frmPrd;
        private DataTable dtblItems,dtblPrds;
        private long noteid=-1;
        private long NoteID
        {
            get
            {
                return this.noteid;
            }
            set
            {
                this.noteid = value;
                this.dtpDateNote.Enabled = (value == -1);
                this.ctrlBranchStoreID.Enabled = (value == -1);
                this.btnDelete.Enabled = (value > -1);
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
        void btnPrd_Click(object sender, EventArgs e)
        {
            if (this.frmPrd == null)
            {
                this.frmPrd = new JERPApp.Define.OtherRes.FrmPrdMore();
                new FrmStyle(frmPrd).SetPopFrmStyle(this);
                this.frmPrd.AffterSelected += frmPrd_AffterSelected;
            }
            this.frmPrd.ShowDialog();
        }

        void frmPrd_AffterSelected(DataRow drow)
        {
            DataRow[] rows = this.dtblItems.Select("PrdID=" + drow["PrdID"].ToString(), "", DataViewRowState.CurrentRows);
           if (rows.Length == 0)
           {
               DataRow drowNew = this.dtblItems.NewRow();
               drowNew["PrdID"] = drow["PrdID"];
               drowNew["PrdName"] = drow["PrdName"];
               drowNew["PrdSpec"] = drow["PrdSpec"];
               drowNew["UnitName"] = drow["UnitName"];
               this.dtblItems.Rows.Add(drowNew);
           }
        }


        void ctrlBranchStoreID_AffterSelected()
        {
            DataTable dtblStore = this.accStore.GetDataStoreInventoryByBranchStoreID(this.ctrlBranchStoreID.BranchStoreID).Tables[0]; 
            if (this.dtblItems == null) return;
            foreach (DataRow drow in dtblStore.Rows)
            {
                if (this.dtblItems.Select("PrdID=" + drow["PrdID"].ToString(), "", DataViewRowState.CurrentRows).Length > 0) continue;
                drow["InventoryQty"] = DBNull.Value;
                this.dtblItems.ImportRow(drow);
            }
        }


       
        void btnImport_Click(object sender, EventArgs e)
        {
            if (this.frmImport == null)
            {
                frmImport = new JCommon.FrmExcelImport();
                new FrmStyle(frmImport).SetPopFrmStyle(this);
                DataColumn[] columns = new DataColumn[]{                  
                    new DataColumn ("产品名称",typeof (string )),
                    new DataColumn ("型号及规格",typeof (string )),
                    new DataColumn ("数量",typeof (decimal))
                };
                frmImport.SetImportColumn(columns, "数量:必填且为数值;");
                frmImport.ImportHandle += new JCommon.FrmExcelImport.ImportDelegate(frmImport_ImportHandle);

            }
            frmImport.ShowDialog();
        }
        private int GetPrdID(object objPrdName, object objPrdSpec)
        {
            string sql = "PrdName='" + objPrdName.ToString() + "'";
            if (objPrdSpec == DBNull.Value)
            {
                sql += " and PrdSpec is null";
            }
            else
            {
                sql += " and PrdSpec='" + objPrdSpec.ToString() + "'";
            }
            DataRow[] drows = this.dtblPrds.Select(sql);
            if (drows.Length == 0) return -1;
            return (int)drows[0]["PrdID"];

        }
        void frmImport_ImportHandle(DataRow drow, out bool flag, out string msg)
        {
           
            msg = string.Empty;
            flag = true;
            int PrdID = this.GetPrdID(drow["产品名称"],drow["型号及规格"]);
            DataRow[] rows = this.dtblItems.Select("PrdID=" +PrdID.ToString (), "", DataViewRowState.CurrentRows);
            if (rows.Length == 0)
            {
              
                if (PrdID == -1)
                {
                    flag = false;
                    msg = "未存此产品";
                }
                else
                {
                    DataRow drowNew = this.dtblItems.NewRow();
                    drowNew["PrdID"] = PrdID;
                    drowNew["PrdName"] = drow["产品名称"];
                    drowNew["PrdSpec"] = drow["型号及规格"];
                    drowNew["CheckQty"] = drow["数量"];
                    this.dtblItems.Rows.Add(drowNew);
                }
                
            }
            else
            { 
                rows[0]["CheckQty"] = drow["数量"];
            }

        }
        void LoadItems()
        {
            this.dtblItems = this.accItems.GetDataStoreCheckItemsByNoteID (this.NoteID).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
        }
  
        public  void New()
        {
            this.NoteID = -1;
            this.ctrlBranchStoreID.BranchStoreID = -1;
            this.txtNoteCode.Text = string.Empty;
            this.txtCheckPersons.Text = string.Empty;
            this.rchMemo.Text = string.Empty;
            this.dtpDateNote .Value = DateTime.Now;
            this.LoadItems();
        }
        public void Edit(long NoteID)
        {
            this.NoteID = NoteID;
            this.NoteEntity.LoadData(NoteID);
            this.txtNoteCode.Text = this.NoteEntity.NoteCode;
            this.ctrlBranchStoreID.BranchStoreID = this.NoteEntity.BranchStoreID;
            this.txtCheckPersons.Text = this.NoteEntity.CheckPersons;
            this.dtpDateNote.Value = this.NoteEntity.DateNote;
            this.LoadItems();

        }
        void btnExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "耗材库盘点");
            excel.SetCellVal("A2", "库位:"+this.ctrlBranchStoreID .BranchStoreName +"  盘点人:" + this.txtCheckPersons.Text);
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            FrmMsg.Hide();
            excel.Show();
        }
        private bool ValidateData()
        {
            if (this.ctrlBranchStoreID.BranchStoreID == -1)
            {
                MessageBox.Show("对不起，库位不正确");
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
                DialogResult rsl = MessageBox.Show("将进行保存,一经保存库位和盘点日期将不能变更，确认否?",
            "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rsl == DialogResult.No) return false;
                object objNoteID=DBNull .Value ;
                object objNoteCode=DBNull .Value ;
                this.dtpDateNote.Value = DateTime.Now;
                flag=this.accNotes.InsertStoreCheckNotes(ref errormsg,
                    ref objNoteID,
                    ref objNoteCode,
                    this.dtpDateNote.Value,
                    this.ctrlBranchStoreID.BranchStoreID,
                    JERPBiz.Frame.UserBiz.PsnID,
                    this.txtCheckPersons .Text ,
                    this.rchMemo .Text );
                if (flag)
                {
                    this.NoteID = (long)objNoteID;
                    this.txtNoteCode.Text = objNoteCode.ToString();
                }

            }
            else
            {
                flag = this.accNotes.UpdateStoreCheckNotes(
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
            string errormsg=string.Empty ;
            bool flag = false;
            foreach (DataRow drow in this.dtblItems.Rows )
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow["ItemID"] == DBNull.Value)
                {
                    objItemID = DBNull.Value;
                    flag=this.accItems.InsertStoreCheckItems(
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
                    this.accItems.UpdateStoreCheckItems(ref errormsg,
                        drow["ItemID"],
                        drow["CheckQty"]);

                }
            }
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
                flag = this.accItems.DeleteStoreCheckItems(ref ErrorMsg,
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
        void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult rsl = MessageBox.Show("即将删除当前盘点单，一经删除不能恢得，确认否?",
         "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rsl == DialogResult.No) return;
            string errormsg = string.Empty;
            bool flag=this.accNotes.DeleteStoreCheckNotes(ref errormsg,
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