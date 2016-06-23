using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Receivable.Templet
{
    public partial class FrmSaleReconciliationFormatSetting : Form
    {
        public FrmSaleReconciliationFormatSetting()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;           
            this.accFormat = new JERPData.Product.SaleReconciliationFormat();
            this.accXCustomer = new JERPData.Product.SaleReconciliationFormatXCustomer();
            this.SetPermit();
        }
        private JERPData.Product.SaleReconciliationFormat accFormat;
        private JERPData.Product.SaleReconciliationFormatXCustomer accXCustomer;
        private FrmSaleReconciliationFormat frmFormat;
        private DataTable dtblFormat, dtblXCustomer;
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存          
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(273);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(274);
            if (this.enableBrowse)
            {
                this.dgrdv.ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                this.LoadData();

            }
            this.btnSave.Enabled = this.enableSave;
            this.lnkFormat.Enabled = this.enableSave;
            if (this.enableSave)
            {
                this.btnSave.Click += new EventHandler(btnSave_Click);
                this.lnkFormat.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkFormat_LinkClicked);
            }
        }
        private void LoadData()
        {
            this.dtblFormat = this.accFormat.GetDataSaleReconciliationFormat().Tables[0];
            while (this.dgrdv.ColumnCount > 2)
            {
                this.dgrdv.Columns.RemoveAt(2);
            }
            DataGridViewCheckBoxColumn ckbcol;
            foreach (DataRow drow in dtblFormat.Rows)
            {
                ckbcol = new DataGridViewCheckBoxColumn();
                ckbcol.Width = 80;
                ckbcol.HeaderText = drow["TmpSheetName"].ToString();            
                ckbcol.DataPropertyName = drow["FormatID"].ToString();
                this.dgrdv.Columns.Add(ckbcol);
            }
            this.dtblXCustomer = this.accXCustomer.GetDataSaleReconciliationFormatXCustomer().Tables[0];
            this.dgrdv.DataSource = this.dtblXCustomer;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.ctrlCheckedAll.SeachGridView = this.dgrdv;
        }
        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }

     
        void lnkFormat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (frmFormat == null)
            {
                frmFormat = new FrmSaleReconciliationFormat();
                new FrmStyle(frmFormat).SetPopFrmStyle(this);
                frmFormat.AffterSave += this.LoadData;
            }
            frmFormat.ShowDialog();
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            string errormsg=string.Empty ;
            bool flag = false;
            FrmMsg.Show("正在保存设置，请稍候....");
            foreach (DataRow drow in this.dtblXCustomer.Rows)
            {
                if (drow.RowState == DataRowState.Unchanged) continue;
                int CompanyID=(int)drow["CompanyID"];
                foreach (DataRow drowColumn in this.dtblFormat.Rows)
                {
                    int FormatID=(int)drowColumn["FormatID"];
                    if (drow[FormatID.ToString()] != DBNull.Value)
                    {                   
                        if ((bool)drow[FormatID.ToString()])
                        {
                            flag=this.accXCustomer.SaveSaleReconciliationFormatXCustomer(ref errormsg, FormatID, CompanyID);
                        }
                        else
                        {
                            flag=this.accXCustomer.DeleteSaleReconciliationFormatXCustomer(ref errormsg, FormatID, CompanyID);
                        }
                        if (!flag)
                        {
                            MessageBox.Show(errormsg);
                        }
                    }
                }
            }
            FrmMsg.Hide();
            MessageBox.Show("成功保存当前变更之设置");
        }
       
     
    }
}