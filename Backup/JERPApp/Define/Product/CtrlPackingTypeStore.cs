using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Product
{
    public partial class CtrlPackingTypeStore : UserControl
    {
        public CtrlPackingTypeStore()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;

            this.accBom = new JERPData.Product.PackingBOM();
            this.gridhelper = new JCommon.DataGridViewHelper();
            this.dgrdv.CellPainting += new DataGridViewCellPaintingEventHandler(dgrdv_CellPainting);
  
        }

        private JCommon.DataGridViewHelper gridhelper;
        private JERPData.Product.PackingBOM accBom;
        private DataTable dtblBom;
        public void PackingBom(int PackingTypeID)
        {
            this.dtblBom = this.accBom.GetDataPackingBOMStoreByPackingTypeID(PackingTypeID).Tables[0];
            this.dgrdv.DataSource = this.dtblBom;
        }
        void dgrdv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if (irow > -1) return;
            if ((icol == 4) || (icol == 5))
            {
                this.gridhelper.MerageColumnHeaderSpan(this.dgrdv, e, 4, 5, "”√¡ø±»");
            }
        }
    }
}
