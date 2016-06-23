using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.QC
{
    public partial class FrmManufBadReportOper : Form
    {
        public FrmManufBadReportOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accItems = new JERPData.Manufacture.ManufBadReportItems();
            this.accNotes = new JERPData.Manufacture.ManufBadReportNotes();
            this.accXBadTypes = new JERPData.Manufacture.ManufBadReportItemXBadTypes();
            this.NoteEntity = new JERPBiz.Manufacture.ManufBadReportNoteEntity();
            this.accBadType = new JERPData.Product.BadType();
            this.ctrlBadTypeID.AllowDefine();
            this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
            this.dgrdv.CellValueChanged += new DataGridViewCellEventHandler(dgrdv_CellValueChanged);
            this.btnDelete.Click += new EventHandler(btnDelete_Click);
            this.btnNew.Click += new EventHandler(btnNew_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnAddBadType.Click += new EventHandler(btnAddBadType_Click);
            this.btnAddItem.Click += new EventHandler(btnAddItem_Click);
            this.ctrlWorkingSheetID.AffterSelected += new JERPApp.Define.Manufacture.CtrlWorkingSheet.AffterSelectedDelegate(ctrlWorkingSheetID_AffterSelected);
            this.ctrlWorkingSheetID_AffterSelected();
        }

        private JERPData.Manufacture.ManufBadReportNotes accNotes;
        private JERPData.Manufacture.ManufBadReportItems accItems;
        private JERPData.Manufacture.ManufBadReportItemXBadTypes accXBadTypes;
        private JERPBiz.Manufacture.ManufBadReportNoteEntity NoteEntity;
        private JERPData.Product.BadType accBadType;
        private DataTable dtblItems;
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
                this.dtpDateNote.Enabled = (value == -1);
            }
        }
        private void AddBadTypeColumn(int BadTypeID, string BadTypeName)
        {
            //加一列
            DataGridViewTextBoxColumn txtcol = new DataGridViewTextBoxColumn();
            txtcol.DataPropertyName = BadTypeID.ToString();
            txtcol.SortMode = DataGridViewColumnSortMode.NotSortable;
            txtcol.HeaderText = BadTypeName;
            txtcol.Width = 66;
            this.dgrdv.Columns.Add(txtcol);
        }
        private const int BadTypeGridIndex = 9;
        private const int BadTypeDtblIndex = 12;
        private void LoadItems()
        {           
            while (this.dgrdv.ColumnCount > BadTypeGridIndex)
            {
                this.dgrdv.Columns.RemoveAt(BadTypeGridIndex);
            }
            DataTable dtblBadType = this.accXBadTypes.GetDataManufBadReportItemXBadTypesBadTypesByNoteID (this.NoteID).Tables[0];
            foreach (DataRow drow in dtblBadType.Rows)
            {
                this.AddBadTypeColumn((int)drow["BadTypeID"], drow["BadTypeName"].ToString());
            }
            this.dtblItems  = this.accItems.GetDataManufBadReportItemsForSetting(NoteID).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
        }
        public void New()
        {
            this.NoteID = -1;
            this.dtpDateNote.Value = DateTime.Now.Date;
            this.txtNoteCode.Text = string.Empty;
            this.rchMemo.Text = string.Empty;
            this.LoadItems();
        }
        public void Edit(long NoteID)
        {
            this.NoteID = NoteID;
            this.NoteEntity.LoadData(NoteID);
            this.txtNoteCode.Text = this.NoteEntity.NoteCode;
            this.dtpDateNote.Value = this.NoteEntity.DateNote;
            this.rchMemo.Text = this.NoteEntity.Memo;
            this.txtQC.Text = this.NoteEntity.QC;
            this.LoadItems();
        }
        void dgrdv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;              
            if (icol >= BadTypeGridIndex)
            {
               
                decimal Quantity = 0;
                for (int j = BadTypeGridIndex; j < this.dgrdv.ColumnCount; j++)
                {
                    object objQty = this.dgrdv[j, irow].Value;
                    if (objQty != DBNull.Value)
                    {
                        Quantity += (decimal)objQty;
                    }
                }
                this.dgrdv[this.ColumnBadQty.Name, irow].Value = Quantity;
            }
        }
      
        private void dgrdv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            if (irow == this.dgrdv.RowCount - 1)
            {
           
                return;
            }
            bool flag = false;
            DataRow drow = this.dtblItems .DefaultView[irow].Row;
            if (drow["ItemID"] != DBNull.Value)
            {
                string errormsg = string.Empty;
                DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rul == DialogResult.Yes)
                {
                    flag = this.accItems .DeleteManufBadReportItems (ref errormsg, drow["ItemID"]);

                    if (flag)
                    {
                        MessageBox.Show("成功删除当前记录");
                    }
                    else
                    {
                        MessageBox.Show(errormsg);
                        e.Cancel = true;
                    }
                }
                else
                {
                    e.Cancel = true;
                }
            }
           
        }
        bool ValidateData()
        {
            bool flag = true;
            DataRow[] drows = this.dtblItems.Select("", "", DataViewRowState.CurrentRows);
            if (drows.Length == 0)
            {
                MessageBox.Show("未存在任何明细项");
                return false;
            }
            return flag;
        }
        private void SaveNote()
        {
            string errormsg = string.Empty;
            bool flag = false;
            if (this.NoteID == -1)
            {
                object objNoteID = DBNull.Value;
                object objNoteCode = DBNull.Value;
                flag = this.accNotes.InsertManufBadReportNotes(ref errormsg,
                    ref objNoteID,
                    ref objNoteCode,
                    this.dtpDateNote.Value.Date,
                    this.txtQC.Text,
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
                flag = this.accNotes.UpdateManufBadReportNotes(ref errormsg, this.NoteID,
                    this.txtQC.Text,
                    JERPBiz.Frame.UserBiz.PsnID,
                    this.rchMemo.Text);
            }
            if (!flag)
            {
                MessageBox.Show(errormsg);
                return;
            }
        }
        private void SaveItems()
        {
            string errormsg = string.Empty;
            bool flag = false;
            for (int irow = 0; irow < this.dtblItems .Rows.Count; irow++)
            {
                DataRow drow = this.dtblItems.Rows[irow];
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow.RowState == DataRowState.Unchanged) continue;
                if (drow["ItemID"] == DBNull.Value)
                {
                    object objItemID = DBNull.Value;
                    flag = this.accItems.InsertManufBadReportItems (ref errormsg,
                        ref objItemID,
                        this.NoteID,
                        drow["WorkingSheetID"],
                        drow["ManufProcessID"],
                        drow["Quantity"],
                        drow["BadQty"]);
                    if (flag)
                    {
                        drow["ItemID"] = objItemID;
                    }
                }
                else
                {
                    flag = this.accItems .UpdateManufBadReportItems (ref errormsg,
                        drow["ItemID"],
                        drow["Quantity"],
                        drow["BadQty"]);
                }
                for (int j = BadTypeDtblIndex ; j < this.dtblItems .Columns.Count; j++)
                {
                    object objQty = drow[j];
                    int BadTypeID = int.Parse(this.dtblItems.Columns[j].ColumnName);
                    if (objQty == DBNull.Value)
                    {
                        flag = this.accXBadTypes.DeleteManufBadReportItemXBadTypes (
                            ref errormsg,
                            drow["ItemID"],
                            BadTypeID);
                    }
                    else
                    {

                        flag = this.accXBadTypes.SaveManufBadReportItemXBadTypes (
                        ref errormsg,
                        drow["ItemID"],
                        BadTypeID,
                        objQty);

                    }
                }
            }
            this.dtblItems .AcceptChanges();
        }

        void ctrlWorkingSheetID_AffterSelected()
        {
            this.ctrlManufProcessID.LoadData(this.ctrlWorkingSheetID.PrdID);
        }

        void btnAddItem_Click(object sender, EventArgs e)
        {
            if (this.ctrlManufProcessID.ManufProcessID == -1)
            {
                MessageBox.Show("工序不能为空");
                return;
            }
            long WorkingSheetID = this.ctrlWorkingSheetID.WorkingSheetID;
            long ManufProcessID = this.ctrlManufProcessID.ManufProcessID;
            DataRow[] drows = this.dtblItems.Select("WorkingSheetID=" + WorkingSheetID.ToString() + " and ManufProcessID=" + ManufProcessID.ToString());
            if (drows.Length > 0) return;
            DataRow drowNew = this.dtblItems.NewRow();
            drowNew["WorkingSheetID"] = WorkingSheetID;
            drowNew["WorkingSheetCode"] = this.ctrlWorkingSheetID.WorkingSheetCode;
            drowNew["PrdCode"] = this.ctrlWorkingSheetID.PrdCode;
            drowNew["PrdName"] = this.ctrlWorkingSheetID.PrdName;
            drowNew["PrdSpec"] = this.ctrlWorkingSheetID.PrdSpec;
            drowNew["UnitName"] = this.ctrlWorkingSheetID.UnitName;
            drowNew["ManufProcessID"] = ManufProcessID;
            drowNew["PrdStatus"] = this.ctrlManufProcessID.PrdStatus;
            this.dtblItems.Rows.Add(drowNew);
        }
        void btnAddBadType_Click(object sender, EventArgs e)
        {
            int BadTypeID = this.ctrlBadTypeID.BadTypeID;
            if (BadTypeID == -1) return;           
            for (int j = BadTypeDtblIndex ; j < this.dtblItems.Columns.Count; j++)
            {
                if (this.dtblItems.Columns[j].ColumnName ==BadTypeID.ToString ()) return;
            }
            this.dtblItems.Columns.Add(BadTypeID.ToString(), typeof(decimal));
            this.AddBadTypeColumn(BadTypeID, this.ctrlBadTypeID.BadTypeName);
           
        }
        void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateData() == false) return;
            DialogResult rul = MessageBox.Show("将进行保存,请确认输入的正确性！", "保存确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return;
            this.SaveNote();
            this.SaveItems();
            MessageBox.Show("成功保存当前设转置");
            if (this.affterSave != null) this.affterSave();
   
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
                bool flag = false;
                string errormsg = string.Empty;
                flag = this.accNotes.DeleteManufBadReportNotes(ref errormsg, this.NoteID);
                if (flag)
                {
                    if (this.affterSave != null) this.affterSave();
                    MessageBox.Show("成功删除当前品检单");
                    this.Close();
                }
                else
                {
                    MessageBox.Show(errormsg);                  
                }
            }
        }
   
    }
}