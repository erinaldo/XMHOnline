using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.MaterialOEM
{
    public partial class FrmStoreCheckNoteOper : Form
    {
        public FrmStoreCheckNoteOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accNotes = new JERPData.Material.OEMStoreCheckNotes();
            this.accItems = new JERPData.Material.OEMStoreCheckItems();
            this.accPrds = new JERPData.Product.Product();
            this.accStore = new JERPData.Material.OEMStore();
            this.NoteEntity = new JERPBiz.Material.OEMStoreCheckNoteEntity();
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnImport.Click += new EventHandler(btnImport_Click);
            this.btnPrd.Click += new EventHandler(btnPrd_Click);
            this.btnDelete .Click +=new EventHandler(btnDelete_Click);
            this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
            this.ctrlCustomerID.AffterSelected +=ctrlCustomerID_AffterSelected;
        }

     
        private JERPData.Material.OEMStoreCheckNotes accNotes;
        private JERPData.Material.OEMStoreCheckItems accItems;
        private JERPData.Product.Product accPrds;
        private JERPData.Material.OEMStore accStore;
        private JERPBiz.Material.OEMStoreCheckNoteEntity NoteEntity;
        private JERPApp.Define.Material.FrmPrdMore frmPrd;
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
                this.dtpDateNote.Enabled = (value == -1);
                this.ctrlCustomerID.Enabled = (value == -1);
                this.btnDelete.Enabled = (value > 0);
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
        private int GetPrdID(string PrdCode)
        {
            int rut = -1;
            this.accPrds.GetParmProductPrdID(PrdCode, ref rut);
            return rut;
        }
        void btnPrd_Click(object sender, EventArgs e)
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
            DataRow[] drowItmes = this.dtblItems.Select("PrdID=" + drow["PrdID"].ToString(), "", DataViewRowState.CurrentRows);
            if (drowItmes.Length > 0) return;
            DataRow drowNew = this.dtblItems.NewRow();
            drowNew["PrdID"] = drow["PrdID"];
            drowNew["AssistantCode"] = drow["AssistantCode"];
            drowNew["PrdCode"] = drow["PrdCode"];
            drowNew["PrdName"] = drow["PrdName"];
            drowNew["PrdSpec"] = drow["PrdSpec"];
            drowNew["Model"] = drow["Model"];
            drowNew["Manufacturer"] = drow["Manufacturer"];
            drowNew["UnitName"] = drow["UnitName"];
            this.dtblItems.Rows.Add(drowNew);

        }
        void ctrlCustomerID_AffterSelected()
        {
            DataTable dtblTempt = this.accStore.GetDataOEMStoreInventoryByCompanyID(this.ctrlCustomerID.CompanyID).Tables[0];
            foreach (DataRow drowTmp in dtblTempt.Rows)
            {
                DataRow[] drowitems = this.dtblItems.Select("PrdID=" + drowTmp["PrdID"].ToString(), "", DataViewRowState.CurrentRows);
                if (drowitems.Length > 0) continue;
                this.dtblItems.ImportRow(drowTmp);
            }
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
      
   
        void frmImport_ImportHandle(DataRow drow, out bool flag, out string msg)
        {
            object objItemID = DBNull.Value;
            msg = string.Empty;
            flag = true;
            DataRow[] rows = this.dtblItems.Select("PrdCode='" + drow["PrdCode"].ToString() + "'", "", DataViewRowState.CurrentRows);
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
        private void LoadItems()
        {
            this.dtblItems = this.accItems .GetDataOEMStoreCheckItemsByNoteID  (this.NoteID).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
        }
        public  void New()
        {
            this.NoteID = -1;
            this.ctrlCustomerID.CompanyID = -1;
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
            this.dtpDateNote.Value = this.NoteEntity.DateNote;
            this.ctrlCustomerID.CompanyID = this.NoteEntity.CompanyID;
            this.txtCheckPersons.Text = this.NoteEntity.CheckPersons;
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
                flag = this.accItems.DeleteOEMStoreCheckItems (ref ErrorMsg,
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
            if (this.ctrlCustomerID.CompanyID  == -1)
            {
                MessageBox.Show("未选择任何客户!");
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
                DialogResult rsl = MessageBox.Show("将进行保存,一经保存客户和盘点日期将不能变更，确认否?",
            "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rsl == DialogResult.No) return false;
                object objNoteID = DBNull.Value;
                object objNoteCode = DBNull.Value;
                flag = this.accNotes.InsertOEMStoreCheckNotes (ref errormsg,
                    ref objNoteID,
                    ref objNoteCode,
                    this.dtpDateNote.Value,
                    this.ctrlCustomerID .CompanyID ,
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
                flag = this.accNotes.UpdateOEMStoreCheckNotes (
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
                    flag=this.accItems.InsertOEMStoreCheckItems (
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
                    this.accItems.UpdateOEMStoreCheckItems (ref errormsg,
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
            bool flag = this.accNotes.DeleteOEMStoreCheckNotes (ref errormsg,
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