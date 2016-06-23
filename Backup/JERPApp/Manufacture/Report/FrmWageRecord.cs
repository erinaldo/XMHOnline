using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture.Report
{
    public partial class FrmWageRecord : Form
    {
        public FrmWageRecord()
        {
            InitializeComponent();
            this.SetPermit();
        }
        //È¨ÏÞÂë
        private bool enableBrowse = false;//ä¯ÀÀ
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(391);
            if (this.enableBrowse)
            {

                this.ctrlBetweenDate.DateBegin = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                this.ctrlBetweenDate.DateEnd = this.ctrlBetweenDate.DateBegin.AddMonths(1).AddDays(-1);
                this.LoadData();
                this.ctrlBetweenDate.AffterEnter += this.LoadData;
                this.ctrlPsnID.AffterSelected += new JERPApp.Define.Hr.CtrlPersonnel.AffterSelectedDelegate(ctrlPsnID_AffterSelected);
            }
          
        }

        void ctrlPsnID_AffterSelected(int PsnID)
        {
            this.LoadData();
        }
        private void LoadData()
        {
            DateTime DateBegin=this.ctrlBetweenDate .DateBegin .Date ;
            DateTime DateEnd=this.ctrlBetweenDate .DateEnd .Date ;
            int PsnID = this.ctrlPsnID.PsnID;
            string PsnInfor = this.ctrlPsnID.PsnCode + this.ctrlPsnID.PsnName;
            this.ctrlGroupPieceworkLaborWageRecord .WageRecord (PsnID,PsnInfor,DateBegin, DateEnd);
            this.ctrlIndivPieceworkRecord.WageRecord (PsnID, PsnInfor, DateBegin, DateEnd);
            this.ctrlWorkinghourLaborWageRecord.WageRecord(PsnID, PsnInfor, DateBegin, DateEnd);
            this.ctrlWorkinghourWorkinghourRecord.WageRecord(PsnID, PsnInfor, DateBegin, DateEnd);
        }
    }
}