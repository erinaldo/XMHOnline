using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture
{
    public partial class FrmBOMPlanForManuf : Form
    {
        public FrmBOMPlanForManuf()
        {
            InitializeComponent();
            this.accManufPlans = new JERPData.Manufacture.ManufPlans ();
            this.accManufProcess = new JERPData.Manufacture.ManufProcess();
            this.ManufPlanEntity = new JERPBiz.Manufacture.ManufPlanEntity ();
            this.ctrlCustomerID.AppendAll();
            this.ctrlPrdID.AffterSelected += this.LoadManufProcessBom;
            this.ctrlCustomerID.AffterSelected += this.ComputeBOM;
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.txtQuantity.TextChanged += new EventHandler(txtQuantity_TextChanged);
            
        }

      

        JERPData.Manufacture.ManufPlans   accManufPlans;
        private JERPData.Manufacture.ManufProcess accManufProcess;
        private DataTable dtblManufProcess;
        private JERPBiz.Manufacture.ManufPlanEntity  ManufPlanEntity;
        private long  manufplanid = -1;
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
                this.txtQuantity.Enabled  = (value==-1);
            }
        }
        void ComputeBOM()
        {
            decimal ManufQty;
            if (!decimal.TryParse(this.txtQuantity.Text, out ManufQty))
            {
                MessageBox.Show("数量格式出错");
                return;
            }
            CtrlManufBOMPlanOper ctrlPlanOper;
            foreach (TabPage page in this.tabMain.TabPages)
            {
                ctrlPlanOper = (CtrlManufBOMPlanOper)page.Controls[0];
                ctrlPlanOper.ComputeBOM(ManufQty, this.ctrlCustomerID.CompanyID);
            }
        }
       
        void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            this.ComputeBOM();
        }

      
     
        private void LoadManufProcessBom()
        {
            this.dtblManufProcess = this.accManufProcess.GetDataManufProcessByPrdID(this.ctrlPrdID.PrdID).Tables[0];
            CtrlManufBOMPlanOper ctrlPlanOper;
            this.tabMain.TabPages.Clear();
            TabPage page;
            decimal ManufQty;
            if (!decimal.TryParse(this.txtQuantity .Text, out ManufQty))
            {
                ManufQty = 0;
            }
            foreach (DataRow drowProcess in this.dtblManufProcess.Rows)
            {
                 
                ctrlPlanOper = new CtrlManufBOMPlanOper();
                ctrlPlanOper.BOMPlanOper(this.ManufPlanID,(long)drowProcess["ManufProcessID"]);
                ctrlPlanOper.ComputeBOM(ManufQty, this.ctrlCustomerID.CompanyID);
                ctrlPlanOper.Dock = DockStyle.Fill;
                page = new TabPage();
                page.Text = drowProcess["PrdStatus"].ToString();
                this.tabMain.TabPages.Add(page);
                page.Controls.Add(ctrlPlanOper);
            }
        }
        public void BOMPlanOper()
        {
            this.ManufPlanID = -1; 
            this.ctrlPrdID.PrdID = -1;
            this.ctrlCustomerID.Enabled = true;
            this.ctrlCustomerID.CompanyID = -1;
            this.txtQuantity.Text = "0"; 
            this.LoadManufProcessBom();
        }
        public void BOMPlanOper(long ManufPlanID)
        {
            this.ManufPlanID = ManufPlanID;
            this.ManufPlanEntity.LoadData(ManufPlanID);
            this.ctrlPrdID.PrdID = this.ManufPlanEntity.PrdID;
            this.ctrlCustomerID.Enabled = false;
            this.ctrlCustomerID.CompanyID = this.ManufPlanEntity.CompanyID;
            this.txtQuantity.Text = string.Format("{0:0.####}", this.ManufPlanEntity.Quantity); 
            this.LoadManufProcessBom();
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
        private bool ValidateData()
        {
            decimal ManufQty;
            if (!decimal.TryParse(this.txtQuantity .Text, out ManufQty))
            {
                MessageBox.Show("算料数格式出错");
                return false;
            }           
            CtrlManufBOMPlanOper ctrlPlanOper;
            foreach (TabPage page in this.tabMain.TabPages)
            {
                ctrlPlanOper = (CtrlManufBOMPlanOper)page.Controls[0];
                if (ctrlPlanOper.ValidateData() == false)
                {
                    MessageBox.Show(page.Text + " 设置有误");
                    return false;
                }
            }
            return true;
        }
        void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateData() == false) return;
            DialogResult rul = MessageBox.Show("请仔细检查您的物料计算,一经保存不能变更！", "操作确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return;
            decimal ManufQty = decimal.Parse(this.txtQuantity.Text);
            CtrlManufBOMPlanOper ctrlPlanOper;
            foreach (TabPage page in this.tabMain.TabPages)
            {
                ctrlPlanOper = (CtrlManufBOMPlanOper)page.Controls[0];
                ctrlPlanOper.Save();
            }
            string errormsg=string.Empty ;
            if (this.ManufPlanID > -1)
            {
                   this.accManufPlans.UpdateManufPlansForBOMPlan   (ref errormsg,
                    this.ManufPlanID );
            }
            if (this.affterSave != null) this.affterSave();
            MessageBox.Show("成功进行当前物料计划计算");
            this.Close();
        }
    }
}