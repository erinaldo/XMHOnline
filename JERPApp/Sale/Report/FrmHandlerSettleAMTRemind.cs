using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Sale.Report
{
    public partial class FrmHandlerSettleAMTRemind : Form
    {
        public FrmHandlerSettleAMTRemind()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accReconcilaiton = new JERPData.Product.SaleReconciliations();
            this.printerhelper = new JERPBiz.Product.SaleReconciliationPrintHelper();
            this.SetPermit();
        }

        private JERPData.Product.SaleReconciliations accReconcilaiton;
        private JERPBiz.Product.SaleReconciliationPrintHelper printerhelper;
        private DataTable dtblReport;
        //权限码
        private bool enableBrowse = false;//浏览
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(133);
            if (this.enableBrowse)
            {
                this.LoadData();
                this.txtDateDiff.KeyDown += new KeyEventHandler(txtDateDiff_KeyDown);
                this.btnExplore.Click += btnExport_Click;
                for (int j = 1; j < this.dgrdv.Columns.Count; j++)
                {
                    this.dgrdv.Columns[j].ReadOnly = true;
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
            this.dtblReport = this.accReconcilaiton.GetDataSaleReconciliationsSettleAMTRemindByHandlePsnID (DateDiff,JERPBiz.Frame .UserBiz .PsnID ).Tables[0];
            this.dtblReport.Columns.Add("CheckedFlag", typeof(bool));
            this.dgrdv.DataSource = this.dtblReport;
        }
        void btnExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            DataRow[] drows = this.dtblReport.Select("CheckedFlag=1");
            long[] ReconciliationIDs = new long[drows.Length];
            for(int i=0;i<ReconciliationIDs.Length ;i++)
            {
                ReconciliationIDs[i] =(long)drows[i]["ReconciliationID"];
            }
            this.printerhelper.ExportToExcel(ReconciliationIDs);
            FrmMsg.Hide();
        }

     
    }
}