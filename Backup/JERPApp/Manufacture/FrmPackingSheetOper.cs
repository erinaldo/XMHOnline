using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture
{
    public partial class FrmPackingSheetOper : Form
    {
        public FrmPackingSheetOper()
        {
            InitializeComponent();
            this.dgrdvBOM.AutoGenerateColumns = false;
            this.dgrdvBOMPlan.AutoGenerateColumns = false;
            this.dgrdvPackingBOM.AutoGenerateColumns = false;
            this.ctrlQBOM.SeachGridView = this.dgrdvBOM;
            this.ctrlQBOMPlan.SeachGridView = this.dgrdvBOMPlan;
            this.ctrlQPackingBOM.SeachGridView = this.dgrdvPackingBOM;
            this.accBOMPlans = new JERPData.Packing.BOMPlans();
            this.accPackingBOM = new JERPData.Packing.BOM();
            this.accPackingTypeBOM = new JERPData.Product.PackingBOM();
            this.accWorkingSheets = new JERPData.Packing.WorkingSheets();
            this.WorkingSheetEntity = new JERPBiz.Packing.WorkingSheetEntity();
            this.accPackingPlans = new JERPData.Packing.PackingPlans();
            this.PackingPlanEntity = new JERPBiz.Packing.PackingPlanEntity();
            this.accSourceType = new JERPData.Product.SourceType();
            this.gridhelper = new JCommon.DataGridViewHelper();
            this.ctrlPrdID.AffterSelected += new JERPApp.Define.Product.CtrlManufPrd.AffterSelectedDelegate(ctrlPrdID_AffterSelected);
            this.ctrlPackingTypeID.AffterSelected += new JERPApp.Define.Product.CtrlPrdPackingType.AffterSelectedDelegate(ctrlPackingTypeID_AffterSelected);
            this.ctrlCompanyID.AppendAll();
            this.SetColumnDataSrc();
            this.btnAddPrd.Click += this.btnAddPrd_Click;
            this.dgrdvBOM .CellPainting +=this.dgrdv_CellPainting ;
            this.dgrdvBOMPlan .CellPainting +=this.dgrdv_CellPainting ;
            this.dgrdvPackingBOM.CellPainting += this.dgrdv_CellPainting;
            this.dgrdvPackingBOM.DataError += new DataGridViewDataErrorEventHandler(dgrdvPackingBOM_DataError);
            this.dgrdvPackingBOM.CellContextMenuStripNeeded += dgrdvPackingBOM_CellContextMenuStripNeeded;
            this.btnAddPrd.Click += new EventHandler(btnAddPrd_Click);
            this.dgrdvPackingBOM.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdvPackingBOM_UserDeletingRow);

            this.dgrdvPackingBOM.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdvPackingBOM_DataBindingComplete);
            this.btnBOMCopy.Click += this.btnBOMCopy_Click;
            this.btnPlanCopy.Click += this.btnPlanCopy_Click;
            this.btnDelete.Click += new EventHandler(btnDelete_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);

        }

        void dgrdv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if (irow > -1) return;
            DataGridView grid = (DataGridView)sender;
            if ((icol == 4) || (icol == 5))
            {
                this.gridhelper.MerageColumnHeaderSpan(grid, e, 4, 5, "用量");
            }
        }

        private JERPData.Packing .WorkingSheets accWorkingSheets;
        private JERPBiz.Packing.WorkingSheetEntity WorkingSheetEntity;
        private JERPData.Packing .PackingPlans accPackingPlans;
        private JERPBiz.Packing.PackingPlanEntity PackingPlanEntity;
        private JERPData.Packing.BOM accPackingBOM;
        private JERPData.Packing.BOMPlans accBOMPlans;
        private JERPData.Product.PackingBOM accPackingTypeBOM; 
        private JERPData.Product.SourceType accSourceType;
        private JERPApp.Define.Product.FrmProduct frmPrd;
        private JERPApp.Define.Product.FrmProduct frmPrdAlter;
        private JCommon.DataGridViewHelper gridhelper;
        private DataTable dtblBOMPlan, dtblBOM, dtblPackingBOM,dtblSourceType;
        private long workingsheetid = -1;
        private long WorkingSheetID
        {
            get
            {
                return this.workingsheetid;
            }
            set
            {
                this.workingsheetid = value;
                this.btnDelete.Enabled = (value > -1); 
                
            }
        }
        private long packingplanid=-1;
        private long PackingPlanID
        {
            get
            {
                return this.packingplanid ;
            }
            set
            {

                this.packingplanid =value ; 
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
        void ctrlPrdID_AffterSelected()
        {
            this.ctrlPackingTypeID.LoadData(this.ctrlPrdID.PrdID);
        }

        void ctrlPackingTypeID_AffterSelected()
        {
            this.LoadBOM();
        }
        private void LoadBOMPlan()
        {
            this.dtblBOMPlan = this.accBOMPlans.GetDataBOMPlansByPackingPlanID(this.PackingPlanID).Tables[0];
            this.dgrdvBOMPlan.DataSource = this.dtblBOMPlan;

        }
        private void LoadBOM()
        {
            this.dtblBOM = this.accPackingTypeBOM.GetDataPackingBOMByPackingTypeID(this.ctrlPackingTypeID.PackingTypeID).Tables[0];
            this.dgrdvBOM.DataSource = this.dtblBOM;
        }
        private void LoadPackingBOM()
        {
            this.dtblPackingBOM = this.accPackingBOM.GetDataBOMByWorkingSheetID(this.WorkingSheetID).Tables[0];
            this.dgrdvPackingBOM.DataSource = this.dtblPackingBOM;
        }

        public void New()
        {
            this.WorkingSheetID = -1;
            this.PackingPlanID = -1;
            this.txtWorkingSheetCode.Text = string.Empty;
            this.ctrlPrdID.Enabled = true;
            this.ctrlPrdID.PrdID = -1;
            this.ctrlPrdID_AffterSelected();
            this.ctrlPackingTypeID.Enabled = true;
            this.ctrlPackingTypeID.PackingTypeID = -1;
            this.ctrlPackingTypeID_AffterSelected();
            this.txtQuantity.Enabled = true;
            this.txtQuantity.Text = string.Empty;
            this.ctrlCompanyID.CompanyID = -1;
            this.dtpDateTarget.Value = DateTime.Now.Date;
            this.rchMemo.Text = string.Empty;
            this.LoadBOMPlan();
            this.LoadBOM();
            this.LoadPackingBOM ();
        }
        public void New(long ManufPlanID)
        {
            this.WorkingSheetID = -1;
            this.PackingPlanID = ManufPlanID;
            this.txtWorkingSheetCode.Text = string.Empty;
            this.PackingPlanEntity.LoadData(ManufPlanID);
            this.ctrlPrdID.Enabled = false ;
            this.ctrlPrdID.PrdID = this.PackingPlanEntity.PrdID;
            this.ctrlPrdID_AffterSelected();
            this.ctrlPackingTypeID.Enabled = false;
            this.ctrlPackingTypeID.PackingTypeID =this.PackingPlanEntity .PackingTypeID;
            this.ctrlPackingTypeID_AffterSelected();
            this.txtQuantity.Enabled = true;
            this.txtQuantity.Text = string.Format("{0:0.####}", this.PackingPlanEntity.NonFinishedQty );
            this.ctrlCompanyID.CompanyID = this.PackingPlanEntity.CompanyID; 
            this.dtpDateTarget.Value = DateTime.Now.Date;
            if (this.PackingPlanEntity.DateTarget != DateTime.MinValue)
            {
                this.dtpDateTarget.Value = this.PackingPlanEntity.DateTarget;
            }
            this.rchMemo.Text = this.PackingPlanEntity.Memo;
            this.LoadBOMPlan();
            this.LoadBOM();
            this.LoadPackingBOM();
        }
        public void Edit(long WorkingSheetID)
        {
            this.WorkingSheetID = WorkingSheetID;
            this.WorkingSheetEntity.LoadData(WorkingSheetID);
            this.txtWorkingSheetCode.Text = this.WorkingSheetEntity.WorkingSheetCode;
            this.PackingPlanID =this.WorkingSheetEntity.PackingPlanID ; 
            this.ctrlPrdID.Enabled = false;
            this.ctrlPrdID.PrdID = this.WorkingSheetEntity.PrdID;
            this.ctrlPrdID_AffterSelected();
            this.ctrlPackingTypeID.Enabled = false;
            this.ctrlPackingTypeID.PackingTypeID = this.WorkingSheetEntity.PackingTypeID;
            this.ctrlPackingTypeID_AffterSelected();
            this.txtQuantity.Enabled = false;
            this.txtQuantity.Text = string.Format("{0:0.####}", this.WorkingSheetEntity.Quantity);
            this.ctrlCompanyID.CompanyID = this.WorkingSheetEntity.CompanyID;
            this.dtpDateTarget.Value = DateTime.Now.Date;
            if (this.WorkingSheetEntity.DateTarget != DateTime.MinValue)
            {
                this.dtpDateTarget.Value = this.WorkingSheetEntity.DateTarget;
            }
            this.rchMemo.Text = this.WorkingSheetEntity.Memo;
            this.LoadBOMPlan();
            this.LoadBOM();
            this.LoadPackingBOM();
        }
        void btnRefresh_Click(object sender, EventArgs e)
        {
            this.LoadPackingBOM();
        }
        private void SetColumnDataSrc()
        {
            this.dtblSourceType = this.accSourceType.GetDataSourceType().Tables[0];
            this.ColumnSourceTypeID.DataSource = this.dtblSourceType;
            this.ColumnSourceTypeID.ValueMember = "SourceTypeID";
            this.ColumnSourceTypeID.DisplayMember = "SourceTypeName";
        }
        void dgrdvPackingBOM_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //啥也不要干,暂时解决出错之问题
        }

        void dgrdvPackingBOM_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow grow in this.dgrdvPackingBOM.Rows)
            {
                grow.ErrorText = string.Empty;

                int PrdID = (int)grow.Cells[this.ColumnPrdID.Name].Value;
                if (PrdID == -1)
                {
                    grow.ErrorText = "不存在此产品";
                    continue;
                }
                if (grow.Cells[this.ColumnPrdID.Name].Value == DBNull.Value)
                {
                    grow.ErrorText = "产品不能为空";
                    continue;
                }
                if (grow.Cells[this.ColumnSourceTypeID.Name].Value == DBNull.Value)
                {
                    grow.ErrorText = "来源方式不能为空";
                    continue;
                }
                if (grow.Cells[this.ColumnPrdAssembly.Name].Value == DBNull.Value)
                {
                    grow.ErrorText = "产品用量不能为空";
                    continue;
                }
                if (grow.Cells[this.ColumnPackageAssembly.Name].Value == DBNull.Value)
                {
                    grow.ErrorText = "包材用量不能为空";
                    continue;
                }

            }
            this.pagePackingBOM .Text = "临时料[" + this.dgrdvPackingBOM.Rows.Count.ToString() + "]";
        }

        void btnAddPrd_Click(object sender, EventArgs e)
        {
            if (this.frmPrd == null)
            {
                this.frmPrd = new JERPApp.Define.Product.FrmProduct();
                this.frmPrd.AllowAppendFlag = true;
                new FrmStyle(this.frmPrd).SetPopFrmStyle(this.ParentForm);
                this.frmPrd.AffterSelected += new JERPApp.Define.Product.FrmProduct.AffterSelectedDelegate(frmPrd_AffterSelected);
            }
            this.frmPrd.ShowDialog();
        }
        void frmPrd_AffterSelected(DataRow drow)
        { 
            DataRow drowNew = this.dtblPackingBOM.NewRow();
            drowNew["PrdID"] = drow["PrdID"];
            drowNew["PrdCode"] = drow["PrdCode"];
            drowNew["PrdName"] = drow["PrdName"];
            drowNew["PrdSpec"] = drow["PrdSpec"]; 
            drowNew["UnitName"] = drow["UnitName"];
            drowNew["PrdAssembly"] = 1;
            drowNew["PackageAssembly"] = 1;
            drowNew["SourceTypeID"] = 2; 
            this.dtblPackingBOM.Rows.Add(drowNew);
        }


        void dgrdvPackingBOM_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if ((this.dgrdvPackingBOM.Columns[icol].DataPropertyName == "PrdCode")
                || (this.dgrdvPackingBOM.Columns[icol].DataPropertyName == "PrdName")
                 || (this.dgrdvPackingBOM.Columns[icol].DataPropertyName == "PrdSpec")) 
            {
                this.dgrdvPackingBOM.CurrentCell = this.dgrdvPackingBOM[icol, irow];
                if (this.frmPrdAlter == null)
                {
                    this.frmPrdAlter = new JERPApp.Define.Product.FrmProduct();
                    this.frmPrdAlter.AllowAppendFlag = true;
                    new FrmStyle(this.frmPrdAlter).SetPopFrmStyle(this.ParentForm);
                    this.frmPrdAlter.AffterSelected += new JERPApp.Define.Product.FrmProduct.AffterSelectedDelegate(frmPrdAlter_AffterSelected);
                }
                this.frmPrdAlter.ShowDialog();
            }
        }
        void frmPrdAlter_AffterSelected(DataRow drow)
        {
            int PrdID = (int)drow["PrdID"]; 
            DataGridViewRow grow = this.dgrdvPackingBOM.CurrentRow;
            grow.Cells[this.ColumnPrdID.Name].Value = PrdID;
            grow.Cells[this.ColumnPrdCode.Name].Value = drow["PrdCode"];
            grow.Cells[this.ColumnPrdName.Name].Value = drow["PrdName"];
            grow.Cells[this.ColumnPrdSpec.Name].Value = drow["PrdSpec"]; 
            grow.Cells[this.ColumnUnitName.Name].Value = drow["UnitName"]; 
            this.frmPrdAlter.Close();
        }

        void dgrdvPackingBOM_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            bool flag = false;
            DataRow drow = this.dtblPackingBOM.DefaultView[irow].Row;
            if (drow["ID"] == DBNull.Value)
            {
                return;
            }
            string errormsg = string.Empty;
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {
                flag = this.accPackingBOM.DeleteBOM (ref errormsg, drow["ID"]);

            }
            else
            {
                e.Cancel = true;
            }
        }
        public bool ValidateData()
        {
             
            if (this.ctrlPrdID.PrdID == -1)
            {
                MessageBox.Show("产品不能为空");
                return false;
            }
            if (this.ctrlPackingTypeID.PackingTypeID == -1)
            {
                MessageBox.Show("包装方案不能为空");
                return false;
            }
            decimal d = 0;
            if (decimal.TryParse(this.txtQuantity.Text, out d) == false)
            {
                MessageBox.Show("数量不能为空");
                return false;
            }
            foreach (DataGridViewRow grow in this.dtblPackingBOM.Rows)
            {
                if (grow.IsNewRow) continue;
                if (grow.ErrorText != string.Empty)
                {
                  
                    MessageBox.Show("存在错误的临时物料");
                    return false;
                }
            }
            return true;
            
        }

        void btnBOMCopy_Click(object sender, EventArgs e)
        {
            foreach (DataRow drowPrdBom in this.dtblBOM .Rows)
            {
                drowPrdBom["ID"] = DBNull.Value;
                if (this.dtblPackingBOM .Select("PrdID=" + drowPrdBom["PrdID"].ToString(), "", DataViewRowState.CurrentRows).Length > 0)
                {
                    continue;
                }
                this.dtblPackingBOM.ImportRow(drowPrdBom);
            }
        }

        void btnPlanCopy_Click(object sender, EventArgs e)
        {
            foreach (DataRow drowPrdBom in this.dtblBOMPlan .Rows)
            {
                drowPrdBom["ID"] = DBNull.Value;
                if (this.dtblPackingBOM.Select("PrdID=" + drowPrdBom["PrdID"].ToString(), "", DataViewRowState.CurrentRows).Length > 0)
                {
                    continue;
                }
                this.dtblPackingBOM.ImportRow(drowPrdBom);
            }
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateData() == false) return;
            string errormsg = string.Empty;
            bool flag = false;
            if (this.WorkingSheetID == -1)
            {
                DialogResult rul = MessageBox.Show("将新增包装制令,一经保存数量及包装类型不能变更，请确认！", "新增确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rul == DialogResult.No) return;
                object objWorkingSheetID = DBNull.Value;
                object objWorkingSheetCode = DBNull.Value;
                flag = this.accWorkingSheets.InsertWorkingSheets(
                    ref errormsg,
                    ref objWorkingSheetID,
                    ref objWorkingSheetCode ,
                    DateTime.Now.Date,
                    this.PackingPlanID,
                    this.ctrlPrdID.PrdID,
                    this.ctrlPackingTypeID.PackingTypeID,
                    this.ctrlCompanyID.CompanyID,
                    this.txtQuantity.Text,
                    this.dtpDateTarget.Value,
                    this.rchMemo.Text,
                    JERPBiz.Frame.UserBiz.PsnID);
                if (flag)
                {
                    this.WorkingSheetID = (long)objWorkingSheetID;
                    this.txtWorkingSheetCode.Text = objWorkingSheetCode.ToString();
                }
            }
            else
            {
                flag = this.accWorkingSheets.UpdateWorkingSheets(
                    ref errormsg,
                    this.WorkingSheetID,
                    this.ctrlCompanyID.CompanyID,
                    this.dtpDateTarget.Value,
                    this.rchMemo.Text,                    
                    JERPBiz.Frame.UserBiz.PsnID);
            }
            if (!flag)
            {
                MessageBox.Show(errormsg);
                return;
            }
            foreach (DataRow drow in this.dtblPackingBOM.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow["ID"] == DBNull.Value)
                {
                    object objID = DBNull.Value;
                    flag=this.accPackingBOM.InsertBOM(ref errormsg,
                        ref objID,
                        this.WorkingSheetID,
                        drow["PrdID"],
                        drow["PrdAssembly"],
                        drow["PackingAssembly"],
                        drow["SourceTypeID"]);
                    if (flag)
                    {
                        drow["ID"] = objID;
                    }
                }
                else
                {
                    this.accPackingBOM .UpdateBOM (ref errormsg ,
                        drow["ID"],
                        drow["PrdID"],
                        drow["PrdAssembly"],
                        drow["PackingAssembly"],
                        drow["SourceTypeID"]);
                }
            }
            MessageBox.Show("成功保存了当前制令");
            //设置计划完成数
            this.accPackingPlans.UpdatePackingPlansForFinishedQty(ref errormsg, this.PackingPlanID);
            this.Edit(this.WorkingSheetID);
            if (this.affterSave != null) this.affterSave();
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
             string errormsg = string.Empty;
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No )return;
            bool flag = this.accWorkingSheets.DeleteWorkingSheets(ref errormsg, this.WorkingSheetID);
            if (flag)
            {
                MessageBox.Show("成功删除当前包装制令");
                this.accPackingPlans.UpdatePackingPlansForFinishedQty(ref errormsg, this.PackingPlanID);
            }
            else
            {
                MessageBox.Show(errormsg);
            }
            if (this.affterSave != null) this.affterSave();
            this.Close();
        }


    }
}