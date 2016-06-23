using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture
{
    public partial class CtrlManufScheduleOper : UserControl
    {
        public CtrlManufScheduleOper()
        {
            InitializeComponent();
            this.dgrdvManufBOM.AutoGenerateColumns = false;
            this.ctrlQManufBOM.SeachGridView = this.dgrdvManufBOM;
            this.dgrdvBOMPlan.AutoGenerateColumns = false;
            this.ctrlQBOMPlan.SeachGridView = this.dgrdvBOMPlan;

            this.dgrdvPrdBOM.AutoGenerateColumns = false;
            this.ctrlQPrdBOM.SeachGridView = this.dgrdvPrdBOM;

            this.accPrdBOM = new JERPData.Product.BOM();
            this.accBOMPlans = new JERPData.Manufacture.BOMPlans();
            this.accManufBOM = new JERPData.Manufacture.BOM();
            this.accManufSchedules = new JERPData.Manufacture.ManufSchedules(); 
            this.accSourceType = new JERPData.Product.SourceType();
            this.ManufProcessEntity = new JERPBiz.Manufacture.ManufProcessEntity();
            this.ManufScheduleEntity = new JERPBiz.Manufacture.ManufScheduleEntity();
            this.accManufProcess = new JERPData.Manufacture.ManufProcess();
            
             this.dgrdvManufBOM.DataError += new DataGridViewDataErrorEventHandler(dgrdvManufBOM_DataError);
            this.dgrdvManufBOM.CellContextMenuStripNeeded +=dgrdvManufBOM_CellContextMenuStripNeeded; 
            this.btnAddPrd.Click += new EventHandler(btnAddPrd_Click);
            this.dgrdvManufBOM.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdvManufBOM_UserDeletingRow);
            
            this.dgrdvManufBOM.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdvManufBOM_DataBindingComplete);

        
             this.SetColumnDataSrc();
            this.lnkFileCount.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkFileCount_LinkClicked);
          
            this.btnBOMPlanCopy.Click += new EventHandler(btnBOMPlanCopy_Click);
            this.btnPrdBOMCopy.Click += new EventHandler(btnPrdBOMCopy_Click);
            this.btnRefresh.Click += new EventHandler(btnRefresh_Click);

        }
         
        private JERPData.Product.BOM accPrdBOM;
        private JERPData.Manufacture.BOM accManufBOM;
        private JERPData.Manufacture.BOMPlans accBOMPlans;
        private JERPData.Manufacture.ManufSchedules accManufSchedules;
        private JERPData.Manufacture.ManufProcess accManufProcess;
        private JERPData.Product.SourceType accSourceType; 
        private JCommon.FrmFileBrowse frmFileBrowse; 
        private JERPApp.Define.Product.FrmProduct frmPrd;
        private JERPApp.Define.Product.FrmProduct frmPrdAlter;
        private JERPBiz.Manufacture.ManufProcessEntity ManufProcessEntity;
        private JERPBiz.Manufacture.ManufScheduleEntity ManufScheduleEntity;
        private DataTable dtblSourceType, dtblManufBOM,dtblBOMPlans,dtblPrdBOM; 
     
        private void SetColumnDataSrc()
        { 
            this.dtblSourceType = this.accSourceType.GetDataSourceType().Tables[0];
            this.ColumnSourceTypeID.DataSource = this.dtblSourceType;
            this.ColumnSourceTypeID.ValueMember = "SourceTypeID";
            this.ColumnSourceTypeID.DisplayMember = "SourceTypeName";
        }


        private long ManufProcessID = -1;
        private long ManufscheduleID= -1;
        private long ManufPlanID = -1;
        public void ManufScheduleOper(long ManufPlanID,long WorkingSheetID,long ManufProcessID)
        {
            long manufscheduleid = -1;
            this.accManufSchedules.GetParmManufSchedulesManufScheduleID(WorkingSheetID, ManufProcessID, ref manufscheduleid);
            this.ManufscheduleID = manufscheduleid; 

            this.ManufProcessID = ManufProcessID;
            this.ManufPlanID = ManufPlanID;
            this.ManufProcessEntity.LoadData(ManufProcessID);
            this.txtMouldCode.Text = this.ManufProcessEntity.MouldCode;
            this.lnkFileCount.Text = this.ManufProcessEntity.FileCount.ToString();
            this.ckbPrdStatus.Checked = true;
            this.txtPrdStatus.Text = this.ManufProcessEntity.PrdStatus; 
            if (this.ManufscheduleID == -1)
            {
                if (WorkingSheetID > -1)
                {
                    this.ckbPrdStatus.Checked = false;
                }
                 
                this.ckbOutSrcFlag.Checked = this.ManufProcessEntity.OutSrcFlag;
                this.ctrlSupplierID.CompanyID = this.ManufProcessEntity.OutSrcCompanyID;
                this.rchMemo.Text = this.ManufProcessEntity.Memo; 
                this.dtpDateTarget.Checked = false; 
                this.dtpDateTarget.Value = DateTime.Now.Date;

            }
            else
            {
                this.ManufScheduleEntity.LoadData(ManufscheduleID); 
                this.ckbOutSrcFlag.Checked = this.ManufScheduleEntity.OutSrcFlag;
                this.ctrlSupplierID.CompanyID = this.ManufScheduleEntity.OutSrcCompanyID;
                this.rchMemo.Text = this.ManufScheduleEntity.Memo; 
                this.dtpDateTarget.Checked = false; 
                if (this.ManufScheduleEntity.DateTarget   != DateTime.MinValue)
                {
                    this.dtpDateTarget .Checked = true;
                    this.dtpDateTarget.Value = this.ManufScheduleEntity.DateTarget;
                }
            }
            this.dtblBOMPlans = this.accBOMPlans.GetDataBOMPlansForManufScheduleBOM(
               this.ManufPlanID,
               this.ManufProcessID).Tables[0];
            this.dgrdvBOMPlan.DataSource = this.dtblBOMPlans;

            this.dtblPrdBOM = this.accPrdBOM.GetDataBOMByManufProcessID(this.ManufProcessID).Tables[0];
            this.dgrdvPrdBOM.DataSource = this.dtblPrdBOM;

            this.dtblManufBOM = this.accManufBOM.GetDataBOMByManufScheduleID(this.ManufscheduleID).Tables[0];
            this.dtblManufBOM.Columns["AssemblyQty"].DefaultValue = 1;
            this.dtblManufBOM.Columns["LossRate"].DefaultValue = 0;
            this.dgrdvManufBOM.DataSource = this.dtblManufBOM;
        }

        void btnRefresh_Click(object sender, EventArgs e)
        {

            this.dtblManufBOM = this.accManufBOM.GetDataBOMByManufScheduleID(this.ManufscheduleID).Tables[0];
            this.dtblManufBOM.Columns["AssemblyQty"].DefaultValue = 1;
            this.dtblManufBOM.Columns["LossRate"].DefaultValue = 0;
            this.dgrdvManufBOM.DataSource = this.dtblManufBOM;
        }

        void dgrdvManufBOM_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //啥也不要干,暂时解决出错之问题
        }

        void dgrdvManufBOM_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow grow in this.dgrdvManufBOM.Rows)
            {               
                grow.ErrorText = string.Empty;
              
                int PrdID = (int)grow.Cells[this.ColumnPrdID.Name].Value;
                if (PrdID ==-1)
                {
                    grow.ErrorText = "不存在此产品";
                    continue;
                }         
                if (grow.Cells[this.ColumnPrdID.Name].Value == DBNull.Value)
                {
                    grow.ErrorText = "产品不能为空";
                    continue;
                }
                if (grow.Cells[this.ColumnSourceTypeID .Name].Value == DBNull.Value)
                {
                    grow.ErrorText = "来源方式不能为空";
                    continue;
                }
                if (grow.Cells[this.ColumnAssemblyQty .Name].Value == DBNull.Value)
                {
                    grow.ErrorText = "用量不能为空";
                    continue;
                }
                
            }
            this.pageManufBOM.Text = "临时料[" + this.dgrdvManufBOM.Rows.Count.ToString() + "]";
        }

        void btnAddPrd_Click(object sender, EventArgs e)
        {
            if (this.frmPrd  == null)
            {
                this.frmPrd = new JERPApp.Define.Product.FrmProduct();
                this.frmPrd.AllowAppendFlag = true;
                new FrmStyle(this.frmPrd).SetPopFrmStyle(this.ParentForm);
                this.frmPrd .AffterSelected+=new JERPApp.Define.Product.FrmProduct.AffterSelectedDelegate(frmPrd_AffterSelected);
            }
            this.frmPrd.ShowDialog(); 
        }
        void frmPrd_AffterSelected(DataRow drow)
        { 
            DataRow drowNew = this.dtblManufBOM.NewRow(); 
            drowNew["PrdID"] = drow["PrdID"];
            drowNew["PrdCode"] = drow["PrdCode"];
            drowNew["PrdName"] = drow["PrdName"];
            drowNew["PrdSpec"] = drow["PrdSpec"];
            drowNew["Model"] = drow["Model"];
            drowNew["Manufacturer"] = drow["Manufacturer"];
            drowNew["UnitName"] = drow["UnitName"];
            drowNew["AssemblyQty"] = 1;
            drowNew["SourceTypeID"] =2; 
            this.dtblManufBOM.Rows.Add(drowNew); 
        }
    
     
        void dgrdvManufBOM_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if ((this.dgrdvManufBOM.Columns[icol].DataPropertyName == "PrdCode")
                ||(this.dgrdvManufBOM.Columns[icol].DataPropertyName == "PrdName")
                 ||(this.dgrdvManufBOM.Columns[icol].DataPropertyName == "PrdSpec")
                 ||(this.dgrdvManufBOM.Columns[icol].DataPropertyName == "Model")
                 ||(this.dgrdvManufBOM.Columns[icol].DataPropertyName == "Manufacturer")
                )
            {
                this.dgrdvManufBOM.CurrentCell = this.dgrdvManufBOM[icol, irow];
                if (this.frmPrdAlter  == null)
                {
                    this.frmPrdAlter = new JERPApp.Define.Product.FrmProduct();
                    this.frmPrdAlter.AllowAppendFlag = true;
                    new FrmStyle(this.frmPrdAlter).SetPopFrmStyle(this.ParentForm);
                    this.frmPrdAlter.AffterSelected += new JERPApp.Define.Product.FrmProduct.AffterSelectedDelegate(frmPrdAlter_AffterSelected);
                }
                this.frmPrdAlter .ShowDialog();
            }
        } 
        void frmPrdAlter_AffterSelected(DataRow drow)
        {
            int PrdID = (int)drow["PrdID"];
           
           DataGridViewRow grow = this.dgrdvManufBOM.CurrentRow;
           grow.Cells [this.ColumnPrdID .Name ].Value  =PrdID;
           grow.Cells[this.ColumnPrdCode.Name].Value = drow["PrdCode"];
           grow.Cells[this.ColumnPrdName.Name].Value = drow["PrdName"];
           grow.Cells[this.ColumnPrdSpec.Name].Value = drow["PrdSpec"];
           grow.Cells[this.ColumnModel.Name].Value = drow["Model"];
           grow.Cells[this.ColumnManufacturer.Name].Value = drow["Manufacturer"];
           grow.Cells[this.ColumnUnitName .Name].Value = drow["UnitName"]; 
           this.frmPrdAlter.Close();
        }
      
        void dgrdvManufBOM_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            bool flag = false;
            DataRow drow = this.dtblManufBOM.DefaultView[irow].Row;
            if (drow["ID"] == DBNull.Value)
            {
                return;
            }
            string errormsg = string.Empty;
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {
                flag = this.accManufBOM .DeleteBOM(ref errormsg, drow["ID"]);
             
            }
            else
            {
                e.Cancel = true;
            }
        }
     
    
       void lnkFileCount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (frmFileBrowse == null)
            {
                frmFileBrowse = new JCommon.FrmFileBrowse();
                frmFileBrowse.ReadOnly = true;
                new FrmStyle(frmFileBrowse).SetPopFrmStyle(this.ParentForm);

            }
            frmFileBrowse.Browse(JERPData.ServerParameter.ERPFileFolder + @"\Engineer\ManufProcess\" + this.ManufProcessID .ToString());
            frmFileBrowse.ShowDialog();
           
        }

        public  bool ValidateFlag
        {
            get
            { 
                foreach (DataGridViewRow grow in this.dgrdvManufBOM.Rows)
                {
                    if (grow.IsNewRow) continue;
                    if (grow.ErrorText != string.Empty)
                    { 
                        return false;
                    }
                }
                return true;
            }
        }

        void btnPrdBOMCopy_Click(object sender, EventArgs e)
        {
            foreach (DataRow drowPrdBom in this.dtblPrdBOM.Rows)
            {
                drowPrdBom["ID"] = DBNull.Value;
                if (this.dtblManufBOM.Select("PrdID=" + drowPrdBom["PrdID"].ToString(), "", DataViewRowState.CurrentRows).Length > 0)
                {
                    continue;
                }
                this.dtblManufBOM.ImportRow(drowPrdBom);
            }
        }

        void btnBOMPlanCopy_Click(object sender, EventArgs e)
        {
            foreach (DataRow drowPrdBom in this.dtblBOMPlans .Rows)
            {
                drowPrdBom["ID"] = DBNull.Value;
                if (this.dtblManufBOM.Select("PrdID=" + drowPrdBom["PrdID"].ToString(), "", DataViewRowState.CurrentRows).Length > 0)
                {
                    continue;
                }
                this.dtblManufBOM.ImportRow(drowPrdBom);
            }
        }

       
 
        public void Save(long WorkingSheetID,decimal Quantity)
        {
            string errormsg = string.Empty;
            bool flag = false;
            if (this.ckbPrdStatus.Checked == false)
            {
                if (this.ManufscheduleID > -1)
                {
                    flag=this.accManufSchedules.DeleteManufSchedules(ref errormsg,
                        this.ManufscheduleID);
                    if (!flag)
                    {
                        MessageBox.Show(errormsg);
                    }
                }
                return;
            } 
            object objDateTarget=DBNull .Value ; 
            if (this.dtpDateTarget.Checked)
            {
                objDateTarget = this.dtpDateTarget.Value;
            }
            if (this.ManufscheduleID == -1)
            {
                object objManufScheduleID=DBNull .Value ;
                flag=this.accManufSchedules.InsertManufSchedules(
                    ref errormsg,
                    ref objManufScheduleID,
                    WorkingSheetID,
                    this.ManufProcessID,
                    this.rchMemo.Text,
                    this.ckbOutSrcFlag.Checked,
                    this.ctrlSupplierID.CompanyID,
                    Quantity, 
                    objDateTarget);
                if (flag)
                {
                    this.ManufscheduleID = (long)objManufScheduleID;
                }
            }
            else
            {
                this.accManufSchedules .UpdateManufSchedules (ref errormsg,
                    this.ManufscheduleID ,
                    this.rchMemo .Text , 
                    this.ckbOutSrcFlag .Checked ,
                    this.ctrlSupplierID .CompanyID , 
                    objDateTarget);
            }
          
            foreach (DataRow drow in this.dtblManufBOM.Rows)            
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow.RowState == DataRowState.Unchanged) continue;
                if (drow["PrdID"] == DBNull.Value) continue;
                if (drow["ID"] == DBNull.Value)
                {
                    object objID = DBNull.Value;
                    flag = this.accManufBOM.InsertBOM (ref errormsg,
                        ref objID,
                        this.ManufscheduleID ,
                        drow["PrdID"],
                        drow["AssemblyQty"],
                        drow["LossRate"],
                        drow["SourceTypeID"]);
                    if (flag)
                    {
                        drow["ID"] = objID; 
                    }
                }
                else
                {
                    
                    flag = this.accManufBOM .UpdateBOM (
                        ref errormsg,
                        drow["ID"], 
                        drow["PrdID"],
                        drow["AssemblyQty"],
                        drow["LossRate"],
                        drow["SourceTypeID"]);
                } 
                drow.AcceptChanges();

            }
            //设置是不是需要做BOM
            this.accManufSchedules.UpdateManufSchedulesForBOMRequire(ref errormsg, this.ManufscheduleID);
         
        } 
    }
}