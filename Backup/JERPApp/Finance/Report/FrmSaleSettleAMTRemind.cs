using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Report
{
    public partial class FrmSaleSettleAMTRemind : Form
    {
        public FrmSaleSettleAMTRemind()
        {
            InitializeComponent();
            this.dgrdvCustomer.AutoGenerateColumns = false;
            this.ctrlCustomerFind.SeachGridView = this.dgrdvCustomer;
            this.accSaleReconcilaiton = new JERPData.Product.SaleReconciliations();
            this.salePrinterhelper = new JERPBiz.Product.SaleReconciliationPrintHelper();
            this.SetPermit();
        }

        private JERPData.Product.SaleReconciliations accSaleReconcilaiton;
        private JERPBiz.Product.SaleReconciliationPrintHelper salePrinterhelper;
        private DataTable dtblCustomerRpt;
        //权限码
        private bool enableBrowse = false;//浏览
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(115);
            if (this.enableBrowse)
            {
                this.LoadData();
                this.txtDateDiff.KeyDown += new KeyEventHandler(txtDateDiff_KeyDown);
                this.btnCustomerExplore.Click += btnCustomerExport_Click;
                for (int j = 1; j < this.dgrdvCustomer.Columns.Count; j++)
                {
                    this.dgrdvCustomer.Columns[j].ReadOnly = true;
                    
                }
                for (int j = 1; j < this.dgrdvExpress .Columns.Count; j++)
                {
                    this.dgrdvExpress.Columns[j].ReadOnly = true;
                }
            }
        }


        void txtDateDiff_KeyDown(object sender, KeyEventArgs e)
        {
            this.LoadData();
        }
        private void LoadData()
        {
            int DateDiff;
            if(!int.TryParse (this.txtDateDiff .Text ,out DateDiff ))
            {
                MessageBox .Show ("对不起，数量输入出错!");
                return;
            }
            this.dtblCustomerRpt = this.accSaleReconcilaiton.GetDataSaleReconciliationsSettleAMTRemind(DateDiff).Tables[0];
            this.dtblCustomerRpt.Columns.Add("CheckedFlag", typeof(bool));
            this.dgrdvCustomer.DataSource = this.dtblCustomerRpt;

        }
        void btnCustomerExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            DataRow[] drows = this.dtblCustomerRpt.Select("CheckedFlag=1");
            long[] ReconciliationIDs = new long[drows.Length];
            for(int i=0;i<ReconciliationIDs.Length ;i++)
            {
                ReconciliationIDs[i] =(long)drows[i]["ReconciliationID"];
            }
            this.salePrinterhelper.ExportToExcel(ReconciliationIDs);
            FrmMsg.Hide();
        }
       
    }
}