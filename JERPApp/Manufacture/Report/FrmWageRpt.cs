using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture.Report
{
    public partial class FrmWageRpt : Form
    {
        public FrmWageRpt()
        {
            InitializeComponent();
            this.SetPermit();
        }
        //È¨ÏÞÂë
        private bool enableBrowse = false;//ä¯ÀÀ
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(368);
            if (this.enableBrowse)
            {

                this.ctrlBetweenDate.DateBegin = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                this.ctrlBetweenDate.DateEnd = this.ctrlBetweenDate.DateBegin.AddMonths(1).AddDays(-1);
                this.LoadData();
                this.ctrlBetweenDate.AffterEnter += this.LoadData;
            }
          
        }
        private void LoadData()
        {
            DateTime DateBegin=this.ctrlBetweenDate .DateBegin .Date ;
            DateTime DateEnd=this.ctrlBetweenDate .DateEnd .Date ;
            this.ctrlWorkinghourWorkinghour.WageRpt(DateBegin, DateEnd);
            this.ctrlIndivPieceworkQuantity.WageRpt(DateBegin, DateEnd);
            this.ctrlWorkinghourLaborWage.WageRpt(DateBegin, DateEnd);
            this.ctrlIndivPieceworkLaborWage.WageRpt(DateBegin, DateEnd);
            this.ctrlGroupPieceworkLaborWage.WageRpt(DateBegin, DateEnd);
        }
    }
}