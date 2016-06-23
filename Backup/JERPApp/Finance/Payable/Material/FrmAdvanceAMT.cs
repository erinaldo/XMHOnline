using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Payable.Material
{
    public partial class FrmAdvanceAMT : Form
    {
        public FrmAdvanceAMT()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accRecords = new JERPData.Material.BuyAdvanceAMTRecords();
            this.SetPermit();
        } 
        private JERPData.Material.BuyAdvanceAMTRecords  accRecords;
        private FrmAdvanceAMTOper frmOper;  
        private DataTable dtblRecords;
        private string whereclause = string.Empty;
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(116);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(117);
            if (this.enableBrowse)
            {
                //加载数据
                this.tpkDateBegin.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                this.tpkDateEnd.Value = this.tpkDateBegin.Value.AddMonths(1).AddDays(-1);
                LoadData();
                this.dgrdv.ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                this.pbar.OnPageIndexChanged += new EventHandler(pbar_OnPageIndexChanged);
                this.btnSearch.Click += new EventHandler(btnSearch_Click);
            
            }
            this.lnkNew.Enabled = this.enableSave;
            if (this.enableSave)
            {
                this.lnkNew.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkNew_LinkClicked);
            }
          
        }

        void lnkNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (frmOper == null)
            {
                frmOper = new FrmAdvanceAMTOper();
                new FrmStyle(frmOper).SetPopFrmStyle(this);
                frmOper.AffterSave += this.frmOper_AffterSave;
            }
            frmOper.New();
            frmOper.ShowDialog();
        }

        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.whereclause = string.Empty;
            this.LoadData();
        }
        private void LoadData()
        {
            int cnt = 0;
            this.dtblRecords = this.accRecords.GetDataBuyAdvanceAMTRecordsDescPagesFreeSearch (1, this.pbar.PageSize, ref cnt, this.whereclause).Tables[0];
            this.dgrdv.DataSource = this.dtblRecords;
            this.pbar.Init(1, cnt);
        }
        void btnSearch_Click(object sender, EventArgs e)
        {
            this.whereclause = string.Empty;
            if (this.ckbNoteCode.Checked)
            {
                this.whereclause += "and (PONo like '%" + txtPONo.Text + "%')";
            }
            if (this.ckbCapDateNote.Checked)
            {
                this.whereclause += "and (DateRecord>='" + tpkDateBegin.Value.ToShortDateString() + "' and DateRecord<='" + tpkDateEnd.Value.ToShortDateString() + "')";
            }

            if (this.ckbSupplier.Checked)
            {
                this.whereclause += "and (CompanyID =" + this.ctrlSupplierID.CompanyID.ToString() + ")";
            }
            this.LoadData();
        }
      

        void frmOper_AffterSave()
        {
            this.whereclause = string.Empty;
            int cnt = 0;
            this.dtblRecords = this.accRecords.GetDataBuyAdvanceAMTRecordsDescPagesFreeSearch (1, this.pbar.PageSize, ref cnt, this.whereclause).Tables[0];
            this.dgrdv.DataSource = this.dtblRecords;
        }
        void pbar_OnPageIndexChanged(object sender, EventArgs e)
        {
            int cnt = 0;
            this.dtblRecords = this.accRecords.GetDataBuyAdvanceAMTRecordsDescPagesFreeSearch (this.pbar.PageIndex, this.pbar.PageSize, ref cnt, this.whereclause).Tables[0];
            this.dgrdv.DataSource = this.dtblRecords;
        }
    }
}