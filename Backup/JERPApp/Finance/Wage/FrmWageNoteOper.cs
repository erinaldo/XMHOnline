using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Wage
{
    public partial class FrmWageNoteOper : Form
    {
        public FrmWageNoteOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accItems = new JERPData.Finance.WageItems();
            this.accNotes = new JERPData.Finance.WageNotes();
            this.NoteEntity = new JERPBiz.Finance.WageNoteEntity();
            this.accPsns = new JERPData.Hr.Personnel();
            this.accWageType = new JERPData.Finance.OtherWageType();
            this.accBasicWages = new JERPData.Finance.BasicWages();
            this.accOtherItems = new JERPData.Finance.WageOtherItems();
            this.CreateColumn();
            this.SetColumnSrc();
            int Year = DateTime.Now.Year;
            int Month = DateTime.Now.Month;
            this.ctrlYear.Year = Year;
            this.ctrlMonth.Month = Month;
            this.dtpDateBegin.Value = new DateTime(Year, Month, 1);
            this.dtpDateEnd.Value = this.dtpDateBegin.Value.AddMonths(1).AddDays(-1);
            this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
            this.dgrdv.CellValueChanged +=new DataGridViewCellEventHandler(dgrdv_CellValueChanged);
            this.btnDelete.Click += new EventHandler(btnDelete_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnExport.Click += new EventHandler(btnExport_Click);
            this.btnNew.Click += new EventHandler(btnNew_Click);
        }        
        private JERPData.Finance.WageNotes accNotes;
        private JERPData.Finance.WageItems accItems;
        private JERPData.Hr.Personnel accPsns;
        private JERPBiz.Finance.WageNoteEntity NoteEntity;
        private JERPData.Finance.OtherWageType accWageType;
        private JERPData.Finance.BasicWages accBasicWages;
        private JERPData.Finance.WageOtherItems accOtherItems;
        private DataTable dtblItems,dtblPsns,dtblWageType;
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
                this.btnExport.Enabled = (value > -1);             
            }
        }
        public delegate void AffterSaveDelegate();
        protected AffterSaveDelegate affterSave;
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
            this.dtblPsns = this.accPsns .GetDataPersonnelOnjob ().Tables[0];
            this.dtblPsns.Columns.Add("exp", typeof(string), "ISNULL(PsnName,'')+ISNULL(PsnCode,'')");
            this.ColumnPsnID.DataSource = this.dtblPsns;
            this.ColumnPsnID.ValueMember = "PsnID";
            this.ColumnPsnID.DisplayMember = "exp";            

        }
        private void CreateColumn()
        {
            this.dtblWageType = this.accWageType.GetDataOtherWageType().Tables[0];
            DataGridViewTextBoxColumn txtcol;          
            foreach (DataRow drow in this.dtblWageType.Rows)
            {
                txtcol = new DataGridViewTextBoxColumn();
                txtcol.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                txtcol.DataPropertyName = drow["WageTypeID"].ToString ();
                txtcol.HeaderText = drow["WageTypeName"].ToString();
                txtcol.DefaultCellStyle.Format = "0.#####"; 
                this.dgrdv.Columns.Add(txtcol);
            }
            txtcol = new DataGridViewTextBoxColumn();
            txtcol.Width = 60;
            txtcol.DataPropertyName = "TotalWage";
            txtcol.HeaderText = "合计";
            txtcol.DefaultCellStyle.Format  = "0.#####";      
            this.dgrdv.Columns.Add(txtcol);
            this.ctrlQFind.SeachGridView = this.dgrdv;
        }
        public void NewNote()
        {
            this.NoteID = -1;          
            this.dtblItems = this.accItems.GetDataWageItemsForSetting(this.NoteID).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
            this.dtblItems.Columns["PsnID"].AllowDBNull = false;
            this.dtblItems.Columns["PsnID"].Unique = true;
          
        }
        public void EditNote(long NoteID)
        {
            this.NoteID = NoteID;
            this.NoteEntity.LoadData(NoteID);
            this.ctrlYear.Year = this.NoteEntity.Year;
            this.ctrlMonth.Month = this.NoteEntity.Month;
            this.dtpDateBegin.Value = this.NoteEntity.DateBegin.Date;
            this.dtpDateEnd.Value = this.NoteEntity.DateEnd;
            this.dtblItems = this.accItems.GetDataWageItemsForSetting(this.NoteID).Tables[0];         
            this.dgrdv.DataSource = this.dtblItems;
            this.dtblItems.Columns["PsnID"].AllowDBNull = false;
            this.dtblItems.Columns["PsnID"].Unique = true;
           
        }

      
        void btnNew_Click(object sender, EventArgs e)
        {
            this.NewNote();
           
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
                flag = this.accItems .DeleteWageItems(ref ErrorMsg,
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
    
        void dgrdv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].DataPropertyName == "PsnID")
            {
                object objPsnID = this.dgrdv[icol, irow].Value;
                if (objPsnID != DBNull.Value)
                {
                    decimal StaticWage = 0, PositionWage = 0;
                    this.accBasicWages.GetParmBasicWagesWage((int)objPsnID,
                        ref StaticWage,ref PositionWage);
                    this.dgrdv[this.ColumnStaticWage.Name, irow].Value = StaticWage;
                    this.dgrdv[this.ColumnPositionWage.Name, irow].Value = PositionWage;                  
                }
            }
            this.ComputeTotalWage();
        }
        void ComputeTotalWage()
        {
            DataGridViewRow grow = this.dgrdv.CurrentRow;
            decimal TotalAMT = 0;
            int l=this.dgrdv .ColumnCount -1;
            for (int j = 1; j < l; j++)
            {
                if (grow.Cells[j].Value  != DBNull.Value)
                {
                    TotalAMT += (decimal)grow.Cells[j].Value;
                }
            }
            grow.Cells[l].Value = TotalAMT;
        }
        void btnSave_Click(object sender, EventArgs e)
        {
            string errormsg = string.Empty;
            bool flag = false;
            if (this.NoteID == -1)
            {
                object objNoteID = DBNull.Value;
                flag = this.accNotes.InsertWageNotes(ref errormsg,
                    ref objNoteID,
                    this.ctrlYear.Year,
                    this.ctrlMonth.Month,
                    this.dtpDateBegin.Value.Date,
                    this.dtpDateEnd.Value.Date,
                    JERPBiz.Frame.UserBiz.PsnID);
                if (flag)
                {
                    this.NoteID = (long)objNoteID;
                }
            }
            else
            {
                flag=this.accNotes .UpdateWageNotes (ref errormsg ,
                    this.NoteID ,
                    this.ctrlYear.Year,
                    this.ctrlMonth.Month,
                    this.dtpDateBegin.Value.Date,
                    this.dtpDateEnd.Value.Date,
                    JERPBiz.Frame.UserBiz.PsnID);
            }
            if (this.NoteID == -1)
            {
                MessageBox.Show(errormsg);
                return;
            }
            foreach (DataRow drow in this.dtblItems.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow.RowState == DataRowState.Unchanged) continue;
                string ErrorMsg = string.Empty;
                object objItemID = drow["ItemID"];             
                if (objItemID == DBNull.Value)
                {
                    flag = this.accItems.InsertWageItems(ref ErrorMsg,
                         ref objItemID,
                         this.NoteID,
                         drow["PsnID"],
                         drow["StaticWage"],
                         drow["PositionWage"],
                         drow["LaborWage"],
                         drow["TotalWage"]);
                    if (flag)
                    {
                        drow["ItemID"] = objItemID;                     
                    }
                }
                else
                {
                    flag = this.accItems.UpdateWageItems(ref ErrorMsg,
                         objItemID,
                         drow["PsnID"],
                         drow["StaticWage"],
                         drow["PositionWage"],
                         drow["LaborWage"],
                         drow["TotalWage"]);                   
                }
                if (flag)
                {
                    //玩明细
                    foreach (DataRow drowType in this.dtblWageType .Rows )
                    {
                        int WageTypeID=(int)drowType["WageTypeID"];
                        string columnname = WageTypeID.ToString();
                        if (drow[columnname] == DBNull.Value)
                        {
                            this.accOtherItems.DeleteWageOtherItems(ref ErrorMsg,
                                objItemID,
                                WageTypeID);

                        }
                        else
                        {
                            this.accOtherItems.SaveWageOtherItems(
                                ref ErrorMsg,
                                objItemID,
                                WageTypeID,
                                drow[columnname]);
                        }
                    }
                }
                else
                {
                    MessageBox.Show(ErrorMsg);
                }

            }
            if (this.affterSave != null) this.affterSave();
            MessageBox.Show("成功保存当前工资表");
            this.dtblItems.AcceptChanges();
            
        }
    

        void btnDelete_Click(object sender, EventArgs e)
        {
              DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
              if (rul == DialogResult.Yes)
              {
                  string errormsg=string.Empty ;
                  this.accNotes.DeleteWageNotes(ref errormsg, this.NoteID);
                  if (this.affterSave != null) this.affterSave();
                  this.Close();
              }
        }
        void btnExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成Excel文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", this.ctrlYear .Year .ToString () + "年" + this.ctrlMonth .Month .ToString () + "月工资表");
            int rowIndex = 3;
            int colIndex = 1;
            excel.SetCellVal("A1", "起始日期:" + this.dtpDateBegin .Value .ToShortDateString ()+ " 截止日期:" + this.dtpDateEnd.Value .ToShortDateString ());
            excel.ImportGridData(dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            excel.SetRangeAutoFit(3, 1, rowIndex, colIndex, true, true);
            FrmMsg.Hide();
            excel.Show();
        }

      
    }
}