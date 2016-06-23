using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture
{
    public partial class FrmWorkingSheetOper : Form
    {
        public FrmWorkingSheetOper()
        {
            InitializeComponent();
            this.accWorkingSheets = new JERPData.Manufacture.WorkingSheets();
            this.WorkingSheetEntity = new JERPBiz.Manufacture.WorkingSheetEntity();
            this.accManufPlans = new JERPData.Manufacture.ManufPlans();
            this.ManufPlanEntity = new JERPBiz.Manufacture.ManufPlanEntity();
            this.ctrlPrdID.AffterSelected += this.LoadManufProcess;
            this.accManufProcess = new JERPData.Manufacture.ManufProcess();
            this.btnDelete.Click += new EventHandler(btnDelete_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
        }

        private JERPData.Manufacture.WorkingSheets accWorkingSheets;
        private JERPBiz.Manufacture.WorkingSheetEntity WorkingSheetEntity;
        private JERPData.Manufacture.ManufPlans accManufPlans;
        private JERPBiz.Manufacture.ManufPlanEntity ManufPlanEntity;
        private JERPData.Manufacture.ManufProcess accManufProcess;
        private DataTable dtblManufProcess;
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
        private long manufplanid = -1;
        private long ManufPlanID
        {
            get
            {
                return this.manufplanid;
            }
            set
            {

                this.manufplanid = value;
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
        void LoadManufProcess()
        {
            this.dtblManufProcess = this.accManufProcess.GetDataManufProcessByPrdID(this.ctrlPrdID.PrdID).Tables[0];
            this.tabMain.TabPages.Clear();
            TabPage page;
            CtrlManufScheduleOper ctrlScheduleOper;
            foreach (DataRow drow in this.dtblManufProcess.Rows)
            {
                page = new TabPage();
                page.Text = drow["PrdStatus"].ToString();
                ctrlScheduleOper = new CtrlManufScheduleOper();
                ctrlScheduleOper.ManufScheduleOper(this.ManufPlanID,
                    this.WorkingSheetID,
                    (long)drow["ManufProcessID"]);
                page.Controls.Add(ctrlScheduleOper);
                ctrlScheduleOper.Dock = DockStyle.Fill;
                this.tabMain.TabPages.Add(page);
            }
        }
        public void New()
        {
            this.WorkingSheetID = -1;
            this.ManufPlanID = -1;
            this.txtWorkingSheetCode.Text = string.Empty;
            this.ctrlPrdID.Enabled = true;
            this.ctrlPrdID.PrdID = -1;
            this.txtQuantity.Enabled = true;
            this.txtQuantity.Text = string.Empty;
            this.ctrlCompanyID.CompanyID = -1;
            this.dtpDateTarget.Value = DateTime.Now.Date;
            this.rchMemo.Text = string.Empty;

            this.LoadManufProcess(); 
        }
        public void New(long ManufPlanID)
        {
            this.WorkingSheetID = -1;
            this.ManufPlanID = ManufPlanID;
            this.txtWorkingSheetCode.Text = string.Empty;
            this.ManufPlanEntity.LoadData(ManufPlanID);
            this.ctrlPrdID.Enabled = false;
            this.ctrlPrdID.PrdID = this.ManufPlanEntity.PrdID;       
            this.txtQuantity.Enabled = true;
            this.txtQuantity.Text = string.Format("{0:0.####}", this.ManufPlanEntity.NonFinishedQty );
            this.ctrlCompanyID.CompanyID = this.ManufPlanEntity.CompanyID;
            this.dtpDateTarget.Value = DateTime.Now.Date;
            if (this.ManufPlanEntity.DateTarget != DateTime.MinValue)
            {
                this.dtpDateTarget.Value = this.ManufPlanEntity.DateTarget;
            }
            this.radMtrStore.Checked = this.ManufPlanEntity.MtrStoreFlag;
            this.radPrdStore.Checked = this.ManufPlanEntity.PrdStoreFlag;
            this.rchMemo.Text = this.ManufPlanEntity.Memo;
            this.LoadManufProcess();
        }
        public void Edit(long WorkingSheetID)
        {
            this.WorkingSheetID = WorkingSheetID;
            this.WorkingSheetEntity.LoadData(WorkingSheetID);
            this.txtWorkingSheetCode.Text = this.WorkingSheetEntity.WorkingSheetCode;
            this.ManufPlanID = this.WorkingSheetEntity.ManufPlanID;
            this.ctrlPrdID.Enabled = false;
            this.ctrlPrdID.PrdID = this.WorkingSheetEntity.PrdID;          
            this.txtQuantity.Enabled = false;
            this.txtQuantity.Text = string.Format("{0:0.####}", this.WorkingSheetEntity.Quantity);
            this.ctrlCompanyID.CompanyID = this.WorkingSheetEntity.CompanyID;
            this.dtpDateTarget.Value = DateTime.Now.Date;
            if (this.WorkingSheetEntity.DateTarget != DateTime.MinValue)
            {
                this.dtpDateTarget.Value = this.WorkingSheetEntity.DateTarget;
            }
            this.radMtrStore.Checked = this.WorkingSheetEntity.MtrStoreFlag;
            this.radPrdStore.Checked = this.WorkingSheetEntity.PrdStoreFlag;
            this.rchMemo.Text = this.WorkingSheetEntity.Memo;
            this.LoadManufProcess();
        }
        public bool ValidateData()
        {

            if (this.ctrlPrdID.PrdID == -1)
            {
                MessageBox.Show("产品不能为空");
                return false;
            } 
            decimal d = 0;
            if (decimal.TryParse(this.txtQuantity.Text, out d) == false)
            {
                MessageBox.Show("数量不能为空");
                return false;
            }
            CtrlManufScheduleOper ctrlScheduleOper;
            foreach (TabPage page in this.tabMain .TabPages)
            {
                ctrlScheduleOper = (CtrlManufScheduleOper)page.Controls[0];
                if (!ctrlScheduleOper.ValidateFlag)
                {
                    return false;
                }
            }
            return true;

        }
        void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateData() == false) return;
            string errormsg = string.Empty;
            bool flag = false;
            if (this.WorkingSheetID == -1)
            {
                DialogResult rul = MessageBox.Show("将新增生产制令,一经保存数量不能变更，请确认！", "新增确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rul == DialogResult.No) return;
                object objWorkingSheetID = DBNull.Value;
                object objWorkingSheetCode = DBNull.Value;
                flag = this.accWorkingSheets.InsertWorkingSheets(
                    ref errormsg,
                    ref objWorkingSheetID,
                    ref objWorkingSheetCode ,
                    DateTime.Now.Date,
                    this.ManufPlanID, 
                    this.ctrlPrdID.PrdID,
                    this.ctrlCompanyID.CompanyID,
                    this.txtQuantity.Text,
                    this.radPrdStore .Checked ,
                    this.radMtrStore .Checked ,
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
                    this.radPrdStore.Checked,
                    this.radMtrStore.Checked,
                    this.rchMemo.Text,
                    JERPBiz.Frame.UserBiz.PsnID);
            }
            if (!flag)
            {
                MessageBox.Show(errormsg);
                return;
            }
            this.accManufPlans.UpdateManufPlansForFinishedQty(ref errormsg, ManufPlanID);
            CtrlManufScheduleOper ctrlScheduleOper;
            foreach (TabPage page in this.tabMain.TabPages)
            {
                ctrlScheduleOper = (CtrlManufScheduleOper)page.Controls[0];
                ctrlScheduleOper .Save (this.WorkingSheetID ,decimal.Parse (this.txtQuantity .Text ));
            }
            if (this.affterSave != null) this.affterSave();
            MessageBox.Show("成功保存当前制令"); 
            //设置计划完成数
            this.accManufPlans.UpdateManufPlansForFinishedQty(ref errormsg, this.ManufPlanID);
            this.Edit(this.WorkingSheetID);
            if (this.affterSave != null) this.affterSave();
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
            string errormsg = string.Empty;
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return;
            bool flag = this.accWorkingSheets.DeleteWorkingSheets(ref errormsg, this.WorkingSheetID);
            if (flag)
            {
                MessageBox.Show("成功删除当前生产制令");
                this.accManufPlans.UpdateManufPlansForFinishedQty(ref errormsg, this.ManufPlanID);
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