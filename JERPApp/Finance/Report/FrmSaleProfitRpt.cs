using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Report
{
    public partial class FrmSaleProfitRpt : Form
    {
        public FrmSaleProfitRpt()
        {
            InitializeComponent();
            this.accItems = new JERPData.Product.SaleDeliverItems();        
            this.ctrlYearRpt.Year = DateTime.Now.Year;
            this.MoneyParm = new JERPBiz.Finance.MoneyTypeParm();
            this.SetPermit();
        }

        
       
        JERPData.Product.SaleDeliverItems accItems;
        private JERPBiz.Finance.MoneyTypeParm MoneyParm;
        //È¨ÏÞÂë
        private bool enableBrowse = false;//ä¯ÀÀ
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(220);
            if (this.enableBrowse)
            {
                this.txtMainMoneyType.Text = this.MoneyParm .GetMainMoneyTypeName();
                this.LoadData();
                this.ctrlYearRpt .OnSelected +=this.LoadData;

            }
           
        }
        private void LoadData()
        {
            this.ctrlCustomerProfit.Report(this.ctrlYearRpt.Year);
            this.ctrlPrdTypeProfit.Report(this.ctrlYearRpt.Year);
            this.ctrlProductProfit.Report(this.ctrlYearRpt.Year);
        }
    }
}