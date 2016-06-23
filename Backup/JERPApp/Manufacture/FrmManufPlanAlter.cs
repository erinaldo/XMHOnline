using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture
{
    public partial class FrmManufPlanAlter : Form
    {
        public FrmManufPlanAlter()
        {
            InitializeComponent();
            this.accManufPlans = new JERPData.Manufacture.ManufPlans  ();
            this.ManufPlanEntity = new JERPBiz.Manufacture.ManufPlanEntity  ();
            this.btnDelete.Click += new EventHandler(btnDelete_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.ctrlCompanyID.AppendAll();
            this.ctrlPrdID.AffterSelected +=ctrlPrdID_AffterSelected;
           
            
           
        }

        private JERPData.Manufacture.ManufPlans  accManufPlans;
        private JERPBiz.Manufacture.ManufPlanEntity  ManufPlanEntity;

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
                this.ctrlPrdID.Enabled = (value == -1);
            }
        }
        public void Edit(long ManufPlanID)
        {
            this.ManufPlanID = ManufPlanID;
            this.ManufPlanEntity.LoadData(ManufPlanID); 
            this.txtDateNote.Text = this.ManufPlanEntity.DateNote.ToShortDateString();
            this.ctrlCompanyID.CompanyID = this.ManufPlanEntity.CompanyID;
            this.ctrlPrdID.PrdID = this.ManufPlanEntity.PrdID;
            this.txtQuantity.Text = string.Format("{0:0.####}", this.ManufPlanEntity.Quantity);
            this.lblUnitName.Text = this.ManufPlanEntity.UnitName; 
            this.radPrdStore.Checked = this.ManufPlanEntity.PrdStoreFlag;
            this.radMtrStore.Checked = this.ManufPlanEntity.MtrStoreFlag;
            if (this.ManufPlanEntity.DateTarget == DateTime.MinValue)
            {
                this.dtpDateTarget.Value = DateTime.Now.AddDays(3);
            }
            else
            {
                this.dtpDateTarget.Value = this.ManufPlanEntity.DateTarget;
            }
           
            this.rchMemo .Text =this.ManufPlanEntity .Memo ;
            this.ckbBOMPlanFlag.Checked = this.ManufPlanEntity.BOMPlanFlag ; 
            
            //处理控件可用可不用
            bool BomPlanFlag = (this.ManufPlanEntity.BOMPlanFlag); 
            this.btnSave.Enabled = !BomPlanFlag;
            this.btnDelete.Enabled = !BomPlanFlag; 
           
        }
     
        void ctrlPrdID_AffterSelected()
        {
         
            this.lblUnitName.Text = this.ctrlPrdID.PrdEntity.UnitName;
            this.radPrdStore.Checked = this.ctrlPrdID.PrdEntity.SaleFlag; 
            this.radMtrStore.Checked = !this.radPrdStore.Checked;

        }
        bool ValidateData()
        {
            if (this.ctrlPrdID.PrdID == -1)
            {
                MessageBox.Show("未选择任何产品");
                return false;
            }
            decimal d;
            if (!decimal.TryParse(this.txtQuantity.Text, out d))
            {
                MessageBox.Show("数量格式出错!");
                return false;
            }
            if (d <= 0)
            {
                MessageBox.Show("数量不能小于或等于0!");
                return false;
            }
            return true;
        }
        void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateData() == false) return;
            DialogResult rul = MessageBox.Show("将要进行保存，请确认您的输入！", "操作确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (rul == DialogResult.Cancel) return;
            bool flag = false;
            string errormsg = string.Empty;
            flag = this.accManufPlans.UpdateManufPlans  (ref errormsg,
                this.ManufPlanID,
                this.ctrlCompanyID.CompanyID,
                this.txtQuantity.Text,
                this.dtpDateTarget.Value,
                this.radPrdStore.Checked,
                this.radMtrStore .Checked , 
                JERPBiz.Frame.UserBiz.PsnID,
                this.rchMemo.Text);
            if (flag)
            {
                MessageBox.Show("成功变更当前生产计划");
                if (this.affterSave != null) this.affterSave();
            }
            else
            {
                MessageBox.Show(errormsg );
                if (this.affterSave != null) this.affterSave();
                this.Close();
            }
        }

       

        void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult rul = MessageBox.Show("即将进行计划删除，一经删除不能恢复！", "操作确认", MessageBoxButtons.OKCancel , MessageBoxIcon.Question);
            if (rul == DialogResult.Cancel ) return;
            bool flag = false;
            string errormsg = string.Empty;
            flag = this.accManufPlans.DeleteManufPlans  (ref errormsg, this.ManufPlanID);
            if (flag)
            {
                MessageBox.Show("成功删除当前生产计划");
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