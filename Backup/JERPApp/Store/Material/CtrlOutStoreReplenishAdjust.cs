using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Material
{
    public partial class CtrlOutStoreReplenishAdjust : UserControl
    {
        public CtrlOutStoreReplenishAdjust()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;  
            this.accReplenishPlans = new JERPData.Material.OutStoreReplenishPlans();    
        }
         
        private JERPData.Material.OutStoreReplenishPlans accReplenishPlans;
        private DataTable dtblItems;  
        public void AdjustOper()
        {
            this.dtblItems = this.accReplenishPlans .GetDataOutStoreReplenishPlans ().Tables[0]; 
            this.dgrdv.DataSource = this.dtblItems;
        }
        public int RowCount
        {
            get
            {
                return this.dgrdv.RowCount;
            }
        }
        public void Save()
        {
            string errormsg = string.Empty;  
            foreach (DataRow drow in this.dtblItems.Rows)
            {
                if (drow.RowState == DataRowState.Unchanged) continue;
                this.accReplenishPlans.UpdateOutStoreReplenishPlansForAdjust(ref errormsg,
                    drow["PrdID"],
                    drow["Quantity"]);
            }

        }

    }
}
