using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Finance
{
    public partial class CtrlSettleAMTType : UserControl 
    {
        public  CtrlSettleAMTType()
        {
            InitializeComponent();
            this.accBank = new JERPData.Finance.Bank();
            this.btnRefresh.Click += new EventHandler(btnRefresh_Click);
            this.LoadData(); 
        }

        void btnRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
        private JERPData.Finance.Bank accBank; 
        private DataTable dtblBank;
        public int BankID
        {
            get
            {
                return (int)this.dtblBank.Rows[this.cmbItem.SelectedIndex]["BankID"];
            }
        }
        private void LoadData()
        {
            dtblBank = this.accBank.GetDataBank().Tables[0];
            this.dtblBank.Columns.Add("exp", typeof(string), "ISNULL(BankName,'')+' '+ISNULL(BankCode,'')");
            DataRow drowNew = this.dtblBank.NewRow();
            drowNew["BankID"] = -1;
            drowNew["BankName"] = "ож╫П";
            if (this.dtblBank.Rows.Count == 0)
            {
                this.dtblBank.Rows.Add(drowNew);
            }
            else
            {
                this.dtblBank.Rows.InsertAt(drowNew,0);
            }
            this.cmbItem.DataSource = this.dtblBank;
            this.cmbItem.ValueMember = "BankID";
            this.cmbItem.DisplayMember = "exp";
        }
        
       
    }
}