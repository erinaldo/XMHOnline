using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Supply.MaterialOEM
{
    public partial class FrmOEMPlan : Form
    {

        public FrmOEMPlan()
        {
            InitializeComponent();
            this.accOEMPlan = new JERPData.Material .OEMPlans();
            this.SetPermit();
        }
        private JERPData.Material.OEMPlans accOEMPlan; 
        private DataTable dtblCustomer;
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(97);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(98);
            if (this.enableBrowse)
            {

                //加载数据
                this.LoadData();
                this.lnkRefreshAll.Click += new EventHandler(lnkRefreshAll_Click);
            } 
        }


        void lnkRefreshAll_Click(object sender, EventArgs e)
        { 
            this.LoadData();
        }

        private void Append(int CompanyID, string CompanyAbbName)
        {
            TabPage page;
            CtrlOEMPlanOper ctrlOper;
            page = new TabPage();
            page.Tag = CompanyID;
            page.Text = CompanyAbbName;
            ctrlOper = new CtrlOEMPlanOper();
            ctrlOper.OEMPlanOper (CompanyID);
            ctrlOper.Enabled = this.enableSave;
            page.Controls.Add(ctrlOper);
            ctrlOper.Dock = DockStyle.Fill;
            this.tabMain.TabPages.Add(page);
            this.ctrlTabNav.NavTabControl = this.tabMain;
        }
        private void LoadData()
        {
            this.dtblCustomer = this.accOEMPlan.GetDataOEMPlansNonFinishedCustomer ().Tables[0];
            this.tabMain.TabPages.Clear();
            foreach (DataRow drow in this.dtblCustomer.Rows)
            {
                this.Append((int)drow["CompanyID"], drow["CompanyAbbName"].ToString());
            }
        }

        
    }
}