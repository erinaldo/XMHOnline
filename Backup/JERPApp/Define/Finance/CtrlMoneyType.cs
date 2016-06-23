using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Finance
{
    public partial class CtrlMoneyType : UserControl
    {
       
        public CtrlMoneyType()
        {
            InitializeComponent();
            this.accMoneyType = new JERPData.Finance.MoneyType();
            this.RefreshData();
            this.cmbItem.SelectedIndexChanged += new EventHandler(cmbItem_SelectedIndexChanged);
        
           
        }
        private JERPData.Finance.MoneyType accMoneyType;
        private JERPBiz.Finance.MoneyTypeEntity moneyEntity = new JERPBiz.Finance.MoneyTypeEntity();
        public JERPBiz.Finance.MoneyTypeEntity MoneyEntity
        {
            get
            {
                this.moneyEntity.LoadData(this.MoneyTypeID);
                return this.moneyEntity;
            }
        }
        public delegate void AffterSelectedDelegate();
        private AffterSelectedDelegate affterSelected;
        public event AffterSelectedDelegate AffterSelected
        {
            add
            {
                affterSelected += value;
            }
            remove
            {
                affterSelected -= value;
            }
        }

        private void cmbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
           if (this.affterSelected != null) this.affterSelected();
        }
      
        private DataTable dtbl;
        void RefreshData()
        {
            this.dtbl = this.accMoneyType.GetDataMoneyType().Tables[0];
            this.dtbl.Columns.Add("Exp", typeof(string), "ISNULL(MoneyTypeCode,'')+ISNULL(MoneyTypeName,'')");
            this.cmbItem.ValueMember = "MoneyTypeID";
            this.cmbItem.DisplayMember = "Exp";
            this.cmbItem.DataSource = this.dtbl;
        }
        void frmDefine_AffterSave()
        {
            this.RefreshData();
        }
        
        public int MoneyTypeID
        {
            get
            {
                if (this.cmbItem.SelectedIndex == -1) return -1;              
                return (int)this.cmbItem.SelectedValue;
            }
            set
            {
                this.cmbItem.SelectedValue = value;
            }
        }
        public string  MoneyTypeName
        {
            get
            {
                return this.MoneyEntity.MoneyTypeName;
            }
           
        }
        public string MoneyTypeCode
        {
            get
            {
                return this.MoneyEntity.MoneyTypeCode;
            }

        }
        public decimal  ExchangeRate
        {
            get
            {
                return this.MoneyEntity.ExchangeRate ;
            }

        }
       
      
    }
}
