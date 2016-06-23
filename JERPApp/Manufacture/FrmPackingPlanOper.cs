using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture
{
    public partial class FrmPackingPlanOper : Form
    {
        public FrmPackingPlanOper()
        {
            InitializeComponent();
            this.accPackingPlans = new JERPData.Packing .PackingPlans  ();
            this.PackingPlanEntity = new JERPBiz.Packing.PackingPlanEntity();
            this.btnDelete.Click += new EventHandler(btnDelete_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.ctrlCompanyID.AppendAll();
            this.ctrlPrdID.AffterSelected +=ctrlPrdID_AffterSelected;  
        }

        private JERPData.Packing.PackingPlans accPackingPlans;
        private JERPBiz.Packing.PackingPlanEntity PackingPlanEntity; 
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
        private long packingplanid = -1;
        private long PackingPlanID
        {
            get
            {
                return this.packingplanid;
            }
            set
            {
                this.packingplanid = value; 
            }
        }
        public void New()
        {
            this.PackingPlanID = -1;
            this.dtpDateNote.Value = DateTime.Now.Date;
            this.ctrlCompanyID.CompanyID = -1;
            this.ctrlPrdID.PrdID = -1;
            this.txtQuantity.Text = "0";
            this.ctrlPackingTypeID.LoadData(-1);
            this.ctrlPackingTypeID.PackingTypeID = -1; 
            this.dtpDateTarget.Value = DateTime.Now.Date.AddDays(3);
            this.rchMemo.Text = string.Empty;
            this.ckbBOMPlanFlag.Checked = false; 
            this.btnSave.Enabled = true;
            this.btnDelete.Enabled = false;
        }
        public void Edit(long PackingPlanID)
        {
            this.PackingPlanID = PackingPlanID;
            this.PackingPlanEntity.LoadData(PackingPlanID);
            this.dtpDateNote.Value = this.PackingPlanEntity.DateNote.Date ;
            this.ctrlCompanyID.CompanyID = this.PackingPlanEntity.CompanyID;
            this.ctrlPrdID.PrdID = this.PackingPlanEntity.PrdID;
            this.txtQuantity.Text = string.Format("{0:0.####}", this.PackingPlanEntity.Quantity);
            this.lblUnitName.Text = this.PackingPlanEntity.UnitName; 
            this.ctrlPackingTypeID.LoadData(this.PackingPlanEntity.PrdID);
            this.ctrlPackingTypeID.PackingTypeID = this.PackingPlanEntity.PackingTypeID; 
            if (this.PackingPlanEntity.DateTarget == DateTime.MinValue)
            {
                this.dtpDateTarget.Value = DateTime.Now.AddDays(3);
            }
            else
            {
                this.dtpDateTarget.Value = this.PackingPlanEntity.DateTarget;
            }
           
            this.rchMemo .Text =this.PackingPlanEntity .Memo ;
            this.ckbBOMPlanFlag.Checked = this.PackingPlanEntity.BOMPlanFlag ; 
            
            //处理控件可用可不用
            bool BomPlanFlag = (this.PackingPlanEntity.BOMPlanFlag); 
            this.btnSave.Enabled = !BomPlanFlag;
            this.btnDelete.Enabled = !BomPlanFlag; 
           
        }
      
        void ctrlPrdID_AffterSelected()
        {
            this.ctrlPackingTypeID.LoadData(this.ctrlPrdID.PrdID);
            this.lblUnitName.Text = this.ctrlPrdID.PrdEntity.UnitName;
          

        }
        bool ValidateData()
        {
            if (this.ctrlPrdID.PrdID == -1)
            {
                MessageBox.Show("未选择任何产品");
                return false;
            }
            if (this.ctrlPackingTypeID.PackingTypeID == -1)
            {
                MessageBox.Show("包装类型不能为空");
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
            bool flag = false;

            string errormsg = string.Empty;
            if (this.PackingPlanID == -1)
            {
                //先整订单处理
                DialogResult rul = MessageBox.Show("您将进行包装下单，请确认！", "包装确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rul == DialogResult.No) return;
                object objPackingPlanID=DBNull .Value ;
                flag=this.accPackingPlans.InsertPackingPlans(ref errormsg,
                    ref objPackingPlanID ,
                    this.dtpDateNote.Value.Date,
                    DBNull.Value,
                    this.ctrlCompanyID.CompanyID,
                   this.ctrlPrdID.PrdID,
                   this.ctrlPackingTypeID.PackingTypeID,
                   this.txtQuantity.Text,
                   this.dtpDateTarget.Value,
                   this.rchMemo.Text,
                   JERPBiz.Frame.UserBiz.PsnID
                   );
                if (flag)
                {
                    this.PackingPlanID =(long)objPackingPlanID;
                }
            }
            else
            {
                flag = this.accPackingPlans.UpdatePackingPlans(ref errormsg,
                    this.PackingPlanID,
                    this.dtpDateNote .Value .Date ,
                    this.ctrlCompanyID.CompanyID,
                    this.ctrlPrdID .PrdID ,
                    this.ctrlPackingTypeID.PackingTypeID,
                    this.txtQuantity.Text,
                    this.dtpDateTarget.Value,
                    JERPBiz.Frame.UserBiz.PsnID,
                    this.rchMemo.Text);
            }
            if (flag)
            {
                MessageBox.Show("成功保存当前包装计划");
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
            flag = this.accPackingPlans.DeletePackingPlans(ref errormsg, this.PackingPlanID);
            if (flag)
            {
                MessageBox.Show("成功删除当前包装计划");
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