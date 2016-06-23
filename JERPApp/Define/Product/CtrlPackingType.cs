using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Product
{
    public partial class CtrlPackingType : UserControl
    {
        public CtrlPackingType()
        {
            InitializeComponent();
            this.accBom = new JERPData.Product.PackingBOM();
            this.Entity = new JERPBiz.Product.PackingTypeEntity();
            this.gridhelper = new JCommon.DataGridViewHelper();
            this.ctrlFileBrowse.ReadOnly = true;
            this.dgrdv.AutoGenerateColumns = false;
            this.dgrdv.CellPainting += new DataGridViewCellPaintingEventHandler(dgrdv_CellPainting);
        }

        void dgrdv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if (irow> -1) return;
            if ((icol == 4) || (icol == 5))
            {
                this.gridhelper.MerageColumnHeaderSpan(this.dgrdv, e, 4, 5, "”√¡ø±»");
            }
        }

        private JERPData.Product.PackingBOM accBom;
        private DataTable dtblBom;
        private JERPBiz.Product.PackingTypeEntity Entity;
        private JCommon.DataGridViewHelper gridhelper;
        public void LoadPacking(int PackingTypeID)
        {
            this.Entity.LoadData(PackingTypeID);
            this.rchDescription.Text = this.Entity.Description;
            this.dtblBom = this.accBom .GetDataPackingBOMByPackingTypeID (PackingTypeID).Tables[0];
            this.dgrdv.DataSource = this.dtblBom;           
            string dir = JERPData.ServerParameter.ERPFileFolder + @"\Engineer\Packing\" + PackingTypeID.ToString();
            this.ctrlFileBrowse.Browse(dir);
            this.ctrlFileBrowse.ReadOnly = true;
           
         
        }
       
    }
}
