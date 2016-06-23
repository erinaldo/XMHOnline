using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Product
{
    public partial class CtrlBOMStore : UserControl
    {
        public CtrlBOMStore()
        {
            InitializeComponent(); 
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accBOM = new JERPData.Product.BOM();
            this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
            this.btnExport.Click += new EventHandler(btnExport_Click);
        }

     
        private JERPData.Product.BOM accBOM;
        private DataTable dtblBom;
        private JERPApp.Store .FrmBOMStore frmBomStore;
        public void BOMStore(int PrdID)
        {

            this.dtblBom = this.accBOM.GetDataBOMStoreByParentID(PrdID).Tables[0];
            this.dtblBom.Columns.Add("Mark", typeof(Image));
            foreach (DataRow drow in this.dtblBom.Rows)
            {

                if ((bool)drow["ParentFlag"])
                {
                    drow["Mark"] = global::JERPApp.Properties.Resources.plus;
                }
                else
                {
                    drow["Mark"] = global::JERPApp.Properties.Resources.subtract;
                }
            }
            this.dgrdv.DataSource = this.dtblBom;
        }

        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnMark.Name)
            {
                int PrdID = (int)this.dtblBom.DefaultView[irow]["PrdID"];
                if (frmBomStore == null)
                {
                    frmBomStore = new JERPApp.Store.FrmBOMStore();
                    new FrmStyle(frmBomStore).SetPopFrmStyle(this.ParentForm);
                }
                frmBomStore.BOMStore(PrdID);
                frmBomStore.ShowDialog();
            }
        }
        void btnExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt"); 
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(this.dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            FrmMsg.Hide();
            excel.Show();
        }

    }
}
