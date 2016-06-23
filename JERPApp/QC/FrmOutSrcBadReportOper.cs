using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.QC
{
    public partial class FrmOutSrcBadReportOper : Form
    {
        public FrmOutSrcBadReportOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accItems = new JERPData.Manufacture.OutSrcBadReportItems();
            this.accNotes = new JERPData.Manufacture.OutSrcBadReportNotes();
            this.NoteEntity = new JERPBiz.Manufacture.OutSrcBadReportNoteEntity();
            this.accPrds = new JERPData.Product .Product();
            this.SetColumnSrc();
            this.dgrdv.CellQuery += new JCommon.MyDataGridView.CellQueryDelegate(dgrdv_CellQuery);
            this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
            this.btnDelete.Click += new EventHandler(btnDelete_Click);
            this.btnNew.Click += new EventHandler(btnNew_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.dgrdv.CellContextMenuStripNeeded += new DataGridViewCellContextMenuStripNeededEventHandler(dgrdv_CellContextMenuStripNeeded);
            this.btnAddPrd.Click += new EventHandler(btnAddPrd_Click);
        }
        private JERPData.Manufacture.OutSrcBadReportNotes accNotes;
        private JERPData.Manufacture.OutSrcBadReportItems accItems;
        private JERPBiz.Manufacture.OutSrcBadReportNoteEntity  NoteEntity;
        private JERPData.Product.Product accPrds;
        private JERPApp.Define.Product.FrmManufPrd  frmPrd;
        private JERPApp.Define.Product.FrmManufPrd frmAddPrd;
        private JCommon.FrmGridFind frmGridPrd;
        private DataTable dtblItems,  dtblPrds;
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
        private void SetColumnSrc()
        {

            this.dtblPrds = this.accPrds.GetDataProductForManufPrd ().Tables[0];
            this.ColumnPrdCode.DataSource = this.dtblPrds;
            this.ColumnPrdCode.ValueMember = "PrdID";
            this.ColumnPrdCode.DisplayMember = "PrdCode";

            this.ColumnPrdName.DataSource = this.dtblPrds;
            this.ColumnPrdName.ValueMember = "PrdID";
            this.ColumnPrdName.DisplayMember = "PrdName";

            this.ColumnPrdSpec.DataSource = this.dtblPrds;
            this.ColumnPrdSpec.ValueMember = "PrdID";
            this.ColumnPrdSpec.DisplayMember = "PrdSpec";

            this.ColumnModel.DataSource = this.dtblPrds;
            this.ColumnModel.ValueMember = "PrdID";
            this.ColumnModel.DisplayMember = "Model";

            this.ColumnUnitName.DataSource = this.dtblPrds;
            this.ColumnUnitName.ValueMember = "PrdID";
            this.ColumnUnitName.DisplayMember = "UnitName";


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
   
        private void LoadItems()
        {  
            this.dtblItems  = this.accItems.GetDataOutSrcBadReportItemsByNoteID (NoteID).Tables[0];
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
            this.ctrlCompanyID.CompanyID = this.NoteEntity.CompanyID;
            this.ctrlProcessTypeID.ProcessTypeID = this.NoteEntity.ProcessTypeID;
            this.rchMemo.Text = this.NoteEntity.Memo;
            this.txtQC.Text = this.NoteEntity.QC;
            this.LoadItems();
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
                    this.frmGridPrd.AddGridColumn("Model", "型号", 66);
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
            grow.Cells[this.ColumnPrdCode.Name].Value = drow["PrdID"];
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
                    this.frmPrd = new JERPApp.Define.Product.FrmManufPrd();
                    new FrmStyle(this.frmPrd).SetPopFrmStyle(this);
                    this.frmPrd.AffterSelected +=frmPrd_AffterSelected;
                }
                this.frmPrd.ShowDialog();
            }
        }

        void frmPrd_AffterSelected(DataRow drow)
        {
            int PrdID = (int)drow["PrdID"];
            this.dgrdv.CurrentCell.Value = PrdID;
            frmPrd.Close();

        }

        void btnAddPrd_Click(object sender, EventArgs e)
        {
            if (frmAddPrd == null)
            {
                this.frmAddPrd = new JERPApp.Define.Product.FrmManufPrd();
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
            this.dtblItems.Rows.Add(drowNew);

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
                    flag = this.accItems .DeleteOutSrcBadReportItems (ref errormsg, drow["ItemID"]);

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
            if (this.ctrlCompanyID.CompanyID == -1)
            {
                MessageBox.Show("供应商不能为空");
                return false;
            }
          
            bool flag = true;
            DataRow[] drows = this.dtblItems.Select("PrdID is null or Quantity is null or BadQty is null", "", DataViewRowState.CurrentRows);
            if (drows.Length >0)
            {
                MessageBox.Show("存在未完善记录");
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
                flag = this.accNotes.InsertOutSrcBadReportNotes(ref errormsg,
                    ref objNoteID,
                    this.txtNoteCode .Text ,
                    this.ctrlCompanyID .CompanyID ,
                    this.ctrlProcessTypeID .ProcessTypeID  ,
                    this.dtpDateNote.Value.Date,
                    this.txtQC.Text,
                    JERPBiz.Frame.UserBiz.PsnID,
                    this.rchMemo.Text);
                if (flag)
                {
                    this.NoteID = (long)objNoteID;
                }
            }
            else
            {
                flag = this.accNotes.UpdateOutSrcBadReportNotes(ref errormsg, this.NoteID,
                    this.txtNoteCode .Text ,
                    this.ctrlCompanyID .CompanyID ,
                    this.ctrlProcessTypeID .ProcessTypeID  ,
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
                    flag = this.accItems.InsertOutSrcBadReportItems (ref errormsg,
                        ref objItemID,
                        this.NoteID,
                        drow["PrdID"],
                        drow["Quantity"],
                        drow["BadQty"]);
                    if (flag)
                    {
                        drow["ItemID"] = objItemID;
                    }
                }
                else
                {
                    flag = this.accItems .UpdateOutSrcBadReportItems (ref errormsg,
                        drow["ItemID"],
                        drow["PrdID"],
                        drow["Quantity"],
                        drow["BadQty"]);
                }              
            }
            this.dtblItems .AcceptChanges();
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
                flag = this.accNotes.DeleteOutSrcBadReportNotes (ref errormsg, this.NoteID);
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