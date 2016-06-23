using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Sale.Report
{
    public partial class FrmBeforeCustomer : Form
    {
        public FrmBeforeCustomer()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false; 
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accCustomers = new JERPData.General.PotentialCustomer();
            this.SetPermit();
        }
        private JERPData.General.PotentialCustomer  accCustomers;
        private DataTable dtblCustomer;
        //权限码
        private bool enableBrowse = false;//浏览
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(637);
            if (this.enableBrowse)
            {
                this.dtpDateBegin.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                this.dtpDateEnd.Value = dtpDateBegin.Value.AddMonths(1).AddDays(-1);
                this.ctrlQFind.SeachGridView = this.dgrdv;             
                this.LoadData();
                this.btnExport .Click += btnExport_Click;
                this.btnSearch.Click += new EventHandler(btnSearch_Click);
            }
        }

        void btnSearch_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private void LoadData()
        {
            string wherecluase = string.Empty;            
            if (this.ckbSalerFlag.Checked)
            {
                wherecluase += " and (SalePsnID=" + this.ctrlSalePsnID.PsnID.ToString() + ")";
            }          
            if (this.ckbRegisterFlag.Checked)
            {
                wherecluase += " and (DateRegister>='" + this.dtpDateBegin.Value.ToShortDateString() + "' and DateRegister<='" + this.dtpDateEnd.Value.ToShortDateString() + "')";
            }
            if (this.ckbSourceType  .Checked)
            {
                wherecluase += " and (SourceTypeID=" + this.ctrlSourceTypeID.SourceTypeID.ToString() + ")";
            }
            if (this.ckbProcessType .Checked)
            {
                wherecluase += " and (ProcessTypeID=" + this.ctrlProcessTypeID.ProcessTypeID .ToString() + ")";
            }
            if (this.ckbPauseFlag .Checked)
            {
                if (this.radPauseFlag.Checked )
                {
                    wherecluase += " and (PauseFlag=1)";
                }
                else
                {
                    wherecluase += " and (PauseFlag=0)";
                }
            }
            if (this.ckbSuccessFlag .Checked)
            {
                if (this.radSuccessFlag.Checked )
                {
                    wherecluase += " and (SuccessFlag=1)";
                }
                else
                {
                    wherecluase += " and (SuccessFlag=0)";
                }
            }
            this.dtblCustomer = this.accCustomers.GetDataPotentialCustomerFreeSearch  (wherecluase).Tables[0];
            this.dgrdv.DataSource = this.dtblCustomer;
        }

    
        void btnExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成Excel文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "售前客户列表");
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            excel.SetRangeAutoFit(3, 1, rowIndex, colIndex, true, true);
            FrmMsg.Hide();
            excel.Show();
        }
    }
}