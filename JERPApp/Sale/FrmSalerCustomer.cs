using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Sale
{
    public partial class FrmSalerCustomer : Form
    {
        public FrmSalerCustomer()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false; 
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accCustomers = new JERPData.General.Customer();
            this.SetPermit();
        }
        private JERPData.General.Customer accCustomers;
        private DataTable dtblCustomer;
        private FrmCustomerOper frmCustomerOper;
        private Report.Bill.FrmCustomer  frmDetail;
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存 
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(523);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(524); 
            if (this.enableBrowse)
            {
                this.ctrlQFind.SeachGridView = this.dgrdv;
                //加载数据              
                this.dgrdv.ContextMenuStrip = this.cMenu;
                this.mItemRefresh .Click +=new EventHandler(mItemRefresh_Click);
                this.LoadData();
             
            }
            this.lnkNew.Enabled = this.enableSave;
            this.ColumnbtnEdit.Visible = this.enableSave;
            if (this.enableSave)
            {
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
                this.lnkNew.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkNew_LinkClicked);
            }
        }

        void lnkNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (frmCustomerOper == null)
            {
                frmCustomerOper = new FrmCustomerOper();
                new FrmStyle(frmCustomerOper).SetPopFrmStyle(this);
                frmCustomerOper.AffterSave += this.LoadData;
            }
            frmCustomerOper.New();
            frmCustomerOper.ShowDialog();
        }

       

        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
        private void LoadData()
        {
            this.dtblCustomer = this.accCustomers.GetDataCustomerBySalePsnID(JERPBiz.Frame .UserBiz .PsnID).Tables[0];
            this.dgrdv.DataSource = this.dtblCustomer;
        }

        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            int CompanyID = (int)this.dtblCustomer.DefaultView[irow]["CompanyID"];
            if ((this.dgrdv.Columns[icol].Name ==this.ColumnCompanyCode .Name )
                ||(this.dgrdv.Columns[icol].Name ==this.ColumnCompanyAbbName.Name)
                ||(this.dgrdv.Columns[icol].Name ==this.ColumnCompanyAllName.Name))
            {
              
                if (frmDetail == null)
                {
                    frmDetail = new JERPApp.Sale  .Report.Bill.FrmCustomer();
                    new FrmStyle(frmDetail).SetPopFrmStyle(this);
                }
                frmDetail.Detail(CompanyID);
                frmDetail.ShowDialog();
            }
            if (this.dgrdv.Columns[icol].Name == this.ColumnbtnEdit.Name)
            {
                if (frmCustomerOper == null)
                {
                    frmCustomerOper = new FrmCustomerOper();
                    new FrmStyle(frmCustomerOper).SetPopFrmStyle(this);
                    frmCustomerOper.AffterSave += this.LoadData;
                }
                frmCustomerOper.Edit (CompanyID);
                frmCustomerOper.ShowDialog();

            }
        }
   
    }
}