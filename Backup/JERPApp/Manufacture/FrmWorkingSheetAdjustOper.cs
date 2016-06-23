using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture
{
    public partial class FrmWorkingSheetAdjustOper : Form
    {
        public FrmWorkingSheetAdjustOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accManufSchedules = new JERPData.Manufacture.ManufSchedules();
            this.WorkingSheetEntity = new JERPBiz.Manufacture.WorkingSheetEntity();
            this.accWorkingSheets = new JERPData.Manufacture.WorkingSheets();
            this.accManufPlans = new JERPData.Manufacture.ManufPlans();
            foreach (DataGridViewColumn col in this.dgrdv.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            this.dgrdv.CellValueChanged += new DataGridViewCellEventHandler(dgrdv_CellValueChanged);
            this.btnSave.Click += new EventHandler(btnSave_Click);
        }
        private JERPData.Manufacture.ManufSchedules accManufSchedules;
        private JERPData.Manufacture.WorkingSheets accWorkingSheets;
        private JERPData.Manufacture.ManufPlans accManufPlans;
        private DataTable dtblManufSchedules;
        private JERPBiz.Manufacture.WorkingSheetEntity WorkingSheetEntity;
        private long WorkingSheetID = -1;
        public void WorkingSheetAdjust(long WorkingSheetID)
        {
            this.WorkingSheetID = WorkingSheetID;
            this.WorkingSheetEntity.LoadData(WorkingSheetID);
            this.txtWorkingSheetCode.Text = this.WorkingSheetEntity.WorkingSheetCode;
            this.txtCompanyCode.Text = this.WorkingSheetEntity.CompanyCode;
            this.txtPONo.Text = this.WorkingSheetEntity.PONo;
            this.txtPrdCode.Text = this.WorkingSheetEntity.PrdCode;
            this.txtPrdName.Text = this.WorkingSheetEntity.PrdName;
            this.txtPrdSpec.Text = this.WorkingSheetEntity.PrdSpec;
            this.txtModel.Text = this.WorkingSheetEntity.Model;
            this.txtDateTarget.Text = this.WorkingSheetEntity.DateTarget.ToString();
            this.txtQuantity.Text = string.Format("{0:0.####}", this.WorkingSheetEntity.Quantity);
            this.txtFinishedQty.Text = string.Format("{0:0.####}", this.WorkingSheetEntity.FinishedQty);
            this.txtNonFinishedQty .Text = string.Format("{0:0.####}", this.WorkingSheetEntity.NonFinishedQty );
            this.dtblManufSchedules = this.accManufSchedules.GetDataManufSchedulesByWorkingSheetID(WorkingSheetID).Tables[0];
            this.dgrdv.DataSource = this.dtblManufSchedules;
          

        } 
        void dgrdv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnNonFinishedQty.Name)
            {
                object objNonFinishedQty = this.dgrdv[icol, irow].Value;
                if (objNonFinishedQty == DBNull.Value) return;
                if (irow == this.dgrdv.RowCount - 1) return;
                this.dgrdv[icol, irow + 1].Value = objNonFinishedQty;
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
   
      
        void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult rul = MessageBox.Show("请仔细检查您的各工序的输入,最后工序的未完数即为本计划的未完数！", "操作确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return;
            string errormsg=string.Empty ;
            DataRow drow;
            for(int irow=0;irow<this.dtblManufSchedules .Rows .Count ;irow++)
            {
                drow = this.dtblManufSchedules.Rows[irow];
                if (drow.RowState == DataRowState.Unchanged) continue;
                this.accManufSchedules.UpdateManufSchedulesAdjustNonFinishedQty(ref errormsg,
                    drow["ManufScheduleID"],
                    drow["NonFinishedQty"]);
                if (irow == this.dtblManufSchedules.Rows.Count - 1)
                {
                    this.accWorkingSheets.UpdateWorkingSheetsForAdjustNonFinishedQty (ref errormsg ,
                        this.WorkingSheetID ,
                        drow["NonFinishedQty"]);
                    this.accManufPlans.UpdateManufPlansForFinishedQty (ref errormsg,
                        this.WorkingSheetEntity.ManufPlanID);
                }
            }
            if (this.affterSave != null) this.affterSave();
            MessageBox.Show("成功调整排期尾数");
        }
    }
}