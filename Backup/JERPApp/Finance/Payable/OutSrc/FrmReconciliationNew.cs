using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Payable.OutSrc
{
    public partial class FrmReconciliationNew : Form
    {
        public FrmReconciliationNew()
        {
            InitializeComponent();
            this.dtpDateNote.Value = DateTime.Now.Date;
            this.dtpDateTarget.Value = this.dtpDateNote.Value.AddDays(30);
            this.ctrlYear.Year = DateTime.Now.Year;
            this.ctrlMonth.Month = DateTime.Now.Month;
            this.ctrlYear.OnSelected += this.SetCaption;
            this.ctrlMonth.OnSelected += this.SetCaption;
            this.SetCaption();
            this.accReconciliation = new JERPData.Manufacture.OutSrcReconciliations();
            this.btnSave.Click += new EventHandler(btnSave_Click);
        }
        private JERPData.Manufacture.OutSrcReconciliations accReconciliation;
        public delegate void AffterSaveDelegate(long ReconciliationID);
        private AffterSaveDelegate affterSave;
        public event AffterSaveDelegate AffterSave
        {
            add
            {
                affterSave += value;
            }
            remove
            {
                affterSave -= value;
            }
        }
        public void New()
        {
            this.txtReconciliationCode.Text = string.Empty;
        }
        private void SetCaption()
        {
            this.txtReconciliationName.Text = this.ctrlYear.Year.ToString() + "年" + this.ctrlMonth.Month.ToString() + "月对账单";
        }
        void btnSave_Click(object sender, EventArgs e)
        {
             DialogResult rut = MessageBox.Show("你将新增对账单，一经保存，供应商、币种、年、月、结算类型不能变更，确认否?", "新增确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
             if (rut == DialogResult.Yes)
             {
                 object objReconciliationID = DBNull.Value;
                 string errormsg=string.Empty ;
                 bool flag=this.accReconciliation.InsertOutSrcReconciliations (
                     ref errormsg,
                     ref objReconciliationID,
                     this.txtReconciliationCode.Text,
                     this.txtReconciliationName .Text ,
                     this.ctrlYear.Year,
                     this.ctrlMonth.Month,
                     this.dtpDateNote.Value.Date,
                     this.ctrlSupplierID.CompanyID,
                     DBNull .Value ,
                     false,
                     this.ctrlMoneyTypeID.MoneyTypeID,
                     this.ctrlSettleTypeID .SettleTypeID ,
                     this.dtpDateTarget .Value .Date ,
                     JERPBiz.Frame.UserBiz.PsnID);
                 if (flag)
                 {
                     MessageBox.Show("成功新增对账单");
                     if (this.affterSave != null) this.affterSave((long)objReconciliationID);
                     this.Close();
                 }
                 else
                 {
                     MessageBox.Show(errormsg);
                 }
             }
              
        }
    }
}