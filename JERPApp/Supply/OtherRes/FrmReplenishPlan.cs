using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Supply.OtherRes
{
    public partial class FrmReplenishPlan : Form
    {

        public FrmReplenishPlan()
        {
            InitializeComponent();
            this.accReplenishPlan = new JERPData.OtherRes .BuyReplenishPlans();
            this.SetPermit();
        }
        private JERPData.OtherRes.BuyReplenishPlans accReplenishPlan; 
        private DataTable dtblSupplier;
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(752);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(753);
            if (this.enableBrowse)
            {

                //加载数据
                this.LoadData();
                this.lnkRefreshAll.Click += new EventHandler(lnkRefreshAll_Click);
            }
            this.btnAppend.Enabled = this.enableSave;
            if (this.enableSave)
            {
                this.btnAppend.Click += new EventHandler(btnAppend_Click);
            }
        }


        void lnkRefreshAll_Click(object sender, EventArgs e)
        { 
            this.LoadData();
        }

        private void Append(int CompanyID, string CompanyAbbName)
        {
            TabPage page;
            CtrlReplenishPlanOper ctrlOper;
            page = new TabPage();
            page.Tag = CompanyID;
            page.Text = CompanyAbbName;
            ctrlOper = new CtrlReplenishPlanOper();
            ctrlOper.ReplenishPlan(CompanyID);
            ctrlOper.Enabled = this.enableSave;
            page.Controls.Add(ctrlOper);
            ctrlOper.Dock = DockStyle.Fill;
            this.tabMain.TabPages.Add(page);
            this.ctrlTabNav.NavTabControl = this.tabMain;
        }
        private void LoadData()
        {
            this.dtblSupplier = this.accReplenishPlan.GetDataBuyReplenishPlansSupplier().Tables[0];
            this.tabMain.TabPages.Clear();
            foreach (DataRow drow in this.dtblSupplier.Rows)
            {
                this.Append((int)drow["CompanyID"], drow["CompanyAbbName"].ToString());
            }
        }

        void btnAppend_Click(object sender, EventArgs e)
        {
            if (this.ctrlCompanyID.CompanyID == -1) return;
            foreach (TabPage page in this.tabMain.TabPages)
            {
                if ((int)page.Tag == this.ctrlCompanyID.CompanyID)
                {
                    page.Select();
                    return;
                }
            }
            this.Append(this.ctrlCompanyID.CompanyID, this.ctrlCompanyID.CompanyAbbName);
        }
    }
}