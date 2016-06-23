using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Sale
{
    public partial class FrmBeforeCustomerAdmin : Form
    {
        public FrmBeforeCustomerAdmin()
        {
            InitializeComponent();
            this.accCustomer = new JERPData.General.PotentialCustomer();
            this.accParms = new JERPData.General.Parms();
            this.dgrdvNormal.AutoGenerateColumns = false;
            this.ctrlGridNormal.SeachGridView = this.dgrdvNormal;
            this.dgrdvPause.AutoGenerateColumns = false;
            this.ctrlGridPause.SeachGridView = this.dgrdvPause;
            new ToolTip().SetToolTip(this.btnAlterSalePsn, "未选择表示进行共享");
            this.SetPermit();
        }
        private JERPData.General.PotentialCustomer accCustomer;
        private JERPData.General.Parms accParms;
        private DataTable dtblNormal, dtblPause;
        private int iDelayDays;
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(635);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(636);
            if (this.enableBrowse)
            {
                string istr = string.Empty;
                this.accParms.GetParmParmsParmValue(3,
                    ref istr);
                iDelayDays = 30;
                if (istr != "-1")
                {
                    iDelayDays = int.Parse(istr);
                }

                this.LoadData();
                this.ctrlGridNormal.BeforeFilter += this.LoadNormal;
                this.ctrlGridPause.BeforeFilter += this.LoadPause;
                for (int j = 1; j < this.dgrdvNormal.ColumnCount; j++)
                {
                    this.dgrdvNormal.Columns[j].ReadOnly = true;
                }
                for (int j = 1; j < this.dgrdvPause .ColumnCount; j++)
                {
                    this.dgrdvPause.Columns[j].ReadOnly = true;
                }
                this.dgrdvNormal.ContextMenuStrip = this.cMenu ;
                this.dgrdvPause.ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);


            }
            this.btnAlterSalePsn.Enabled = this.enableSave;
            this.btnPause.Enabled = this.enableSave;
            this.btnRecover.Enabled = this.enableSave;
            if (this.enableSave)
            {
                this.btnRecover.Click += new EventHandler(btnRecover_Click);
                this.btnAlterSalePsn.Click += new EventHandler(btnAlterSalePsn_Click);
                this.btnPause.Click += new EventHandler(btnPause_Click);
            }
        }

        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
        private void LoadData()
        {
            this.LoadNormal();
            this.LoadPause();
        }
        void btnPause_Click(object sender, EventArgs e)
        {
            string errormsg = string.Empty;
            DataRow[] drows = this.dtblNormal.Select("CheckedFlag=1");
            foreach (DataRow drow in drows)
            {
                this.accCustomer.UpdatePotentialCustomerForPause(ref errormsg, drow["CompanyID"], true);
               
            }
            this.LoadData();
            MessageBox.Show("成功进行客户临时终止");
        }

        void btnAlterSalePsn_Click(object sender, EventArgs e)
        {
            string errormsg = string.Empty;
            DataRow[] drows = this.dtblNormal.Select("CheckedFlag=1");
            int SalePsnID =this.ctrlSalePsnID.PsnID ;
            if (this.ckbAllFlag.Checked)
            {
                SalePsnID = -1;
            }
            foreach (DataRow drow in drows)
            {                
                this.accCustomer.UpdatePotentialCustomerForSalePsn (ref errormsg, drow["CompanyID"], SalePsnID  );
            }
            this.LoadNormal();
            MessageBox.Show("成功进行客户业务变更");
        }

        void btnRecover_Click(object sender, EventArgs e)
        {

            string errormsg = string.Empty;
            DataRow[] drows = this.dtblPause .Select("CheckedFlag=1");
            foreach (DataRow drow in drows)
            {
                this.accCustomer.UpdatePotentialCustomerForPause(ref errormsg, drow["CompanyID"], false );

            }
            this.LoadData();
            MessageBox.Show("成功进行客户终止恢复");
        }
        private void LoadNormal()
        {
            this.dtblNormal = this.accCustomer.GetDataPotentialCustomerForPause(false).Tables[0];
            this.dgrdvNormal.DataSource = this.dtblNormal;
            this.dtblNormal.Columns.Add("CheckedFlag", typeof(bool));
            foreach (DataRow drow in this.dtblNormal.Rows)
            {
                drow.RowError = string.Empty;
                if (drow["DateBegin"] == DBNull.Value) continue;
                if (((DateTime)drow["DateBegin"]).Date.AddDays(Convert.ToDouble(this.iDelayDays)) < DateTime.Now.Date)
                {
                    drow.RowError = "追加超时";
                }
            }
            this.pageNormal.Text = "跟进中[" + this.dtblNormal.Rows.Count.ToString() + "]";
        }
        private void LoadPause()
        {
            this.dtblPause = this.accCustomer.GetDataPotentialCustomerForPause(true).Tables[0];
            this.dgrdvPause.DataSource = this.dtblPause;
            this.dtblPause.Columns.Add("CheckedFlag", typeof(bool));
            this.pagePause .Text = "已终止[" + this.dtblPause.Rows.Count.ToString() + "]";
        }
    }
}