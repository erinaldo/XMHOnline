using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Supply.Material
{
    public partial class FrmOrderItemFromSetPlan : Form
    {
        public FrmOrderItemFromSetPlan()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accBuyPlans = new JERPData.Material.BuyPlans();
            this.btnAppend.Click += new EventHandler(btnAppend_Click);
            this.ctrlPrdSetID.AffterSelected += this.LoadData;
        }
        private JERPData.Material.BuyPlans accBuyPlans;
        private DataTable dtblPlans;
        public void BuyOrderFromSetPlan()
        {
            this.ctrlPrdSetID.PrdID = -1;
            this.LoadData();
        }
        void LoadData()
        {
            this.dtblPlans = this.accBuyPlans.GetDataBuyPlansBySetPrdID(this.ctrlPrdSetID.PrdID).Tables[0];
            this.dtblPlans.Columns.Add("PrdSetQty", typeof(decimal), "NonFinishedQty/AssemblyQty");
            this.dgrdv.DataSource = this.dtblPlans;
            this.txtQuantity.Text =string.Format ("{0:0.####}", this.dtblPlans.Compute("Min(PrdSetQty)", ""));
        }
        public delegate void AffterSaveDelegate(int PrdID,decimal Quantity);
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
        private bool ValidateData()
        {
            if (this.ctrlPrdSetID.PrdID == -1)
            {
                MessageBox.Show("对不起，套料物料未选择!");
                return false;
            }
            decimal Quantity;
            if (decimal.TryParse(this.txtQuantity.Text, out Quantity) == false)
            {
                
                MessageBox.Show("对不起，数量格式不正确!");
                return false;
            }
            return true;
        }
        void btnAppend_Click(object sender, EventArgs e)
        {
            if (ValidateData() == false) return;
            if (this.affterSave != null) this.affterSave(this.ctrlPrdSetID.PrdID, decimal.Parse(this.txtQuantity.Text));
            this.BuyOrderFromSetPlan();
        }
    }
}