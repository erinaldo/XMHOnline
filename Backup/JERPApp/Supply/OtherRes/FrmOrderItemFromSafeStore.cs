using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Supply.OtherRes
{
    public partial class FrmOrderItemFromSafeStore : Form
    {
        public FrmOrderItemFromSafeStore()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false; 
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.ctrlQFind.BeforeFilter += this.LoadData;
            this.dtpDateTarget.Value = DateTime.Now.AddDays(10).Date;
            this.accStores = new JERPData.OtherRes.Store();
            for (int j = 1; j < this.dgrdv.ColumnCount; j++)
            {
                this.dgrdv.Columns[j].ReadOnly = true;
            }
            this.btnSave.Click += new EventHandler(btnSave_Click);            
        }


        private JERPData.OtherRes.Store accStores;
        private DataTable dtblInitStore,dtblStores;
        public void ItemFromStore(DataRow[] drowItems)
        {
            this.dtblInitStore  = this.accStores.GetDataStoreSafeInventory ().Tables[0];
            this.dtblInitStore.Columns.Add("CheckedFlag", typeof(bool));
            this.dtblInitStore.Columns.Add("DateTarget", typeof(DateTime));
            foreach (DataRow drowItem in drowItems)
            {
                DataRow[] drowStores = this.dtblInitStore.Select("PrdID=" + drowItem["PrdID"].ToString(), "", DataViewRowState.CurrentRows);
                if (drowStores.Length > 0)
                {
                    decimal RequireQty=(decimal)drowStores[0]["RequireQty"];
                    decimal Quantity = (decimal)drowItem["Quantity"];
                    if (RequireQty <= Quantity)
                    {
                        drowStores[0].Delete();
                    }
                    else
                    {
                        drowStores[0]["RequireQty"] = RequireQty - Quantity;
                    }
                }
            }
            this.LoadData();
        }
        private void LoadData()
        {
            this.dtblStores = this.dtblInitStore.Copy();
            this.dgrdv.DataSource = this.dtblStores;

        }
        public delegate void AffterSaveDelegate(DataRow drowStore);
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
            if (this.dtblStores .Select("CheckedFlag=1").Length == 0)
            {
                MessageBox.Show("对不起,没有任何明细项");
                return false;
            }          
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateData() == false) return;      
            foreach (DataRow drow in this.dtblStores.Rows )
            {
                if (drow.RowState == DataRowState.Unchanged) continue;
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow["CheckedFlag"] != DBNull.Value)
                {
                    if ((bool)drow["CheckedFlag"])
                    {
                        drow["DateTarget"] = this.dtpDateTarget.Value;
                        if (this.affterSave != null) this.affterSave(drow);
                    }
                }
            }          
            MessageBox.Show("成功将当前计划加入订单!");
            this.Close();
        }
    }
}