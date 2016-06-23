using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture.SemiPrd.Report
{
    public partial class FrmPrdInventory : Form
    {
        public FrmPrdInventory()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accStore = new JERPData.SemiPrd.Store();
            this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
        }

        private JERPData.SemiPrd.Store accStore;
        private DataTable dtblInventory;
        private FrmOutSrcInventory frmOutSrcInventory;
        public void PrdInventory(int PrdID)
        {
            this.dtblInventory = this.accStore.GetDataStoreByPrdID(PrdID).Tables[0];
            this.dgrdv.DataSource = this.dtblInventory;
        }

        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
               int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnOutSrcSupplier.Name)
            {
                long ManufProcessID = (long)this.dtblInventory.DefaultView[irow]["ManufProcessID"];
                if (frmOutSrcInventory == null)
                {
                    frmOutSrcInventory = new FrmOutSrcInventory();
                    new FrmStyle(frmOutSrcInventory).SetPopFrmStyle(this);
                }
                frmOutSrcInventory.OutSrcInventory(ManufProcessID);
                frmOutSrcInventory.ShowDialog();
            }
        }
    }
}