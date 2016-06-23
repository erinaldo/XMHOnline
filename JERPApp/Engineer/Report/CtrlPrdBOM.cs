using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Engineer.Report
{
    public partial class CtrlPrdBOM : UserControl
    {
        public CtrlPrdBOM()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accBOM = new JERPData.Product.BOM();
            this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
            
           }

     
        private JERPData.Product.BOM accBOM;
        private DataTable dtblBom;
        private JERPApp.Engineer.Report.FrmProductDetail frmPrd;
        private int PrdID = -1;
        public void PrdBom(int PrdID)
        {
            this.PrdID = PrdID;
            this.dtblBom = this.accBOM.GetDataBOMByParentID(this.PrdID).Tables[0]; 
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
            DataRow drow = this.dtblBom.DefaultView[irow].Row;
            int PrdID = (int)drow["PrdID"];
            if (this.dgrdv.Columns[icol].Name == this.ColumnMark.Name )
            {
                              
                if (frmPrd == null)
                {
                    frmPrd = new FrmProductDetail();
                    new FrmStyle(frmPrd).SetPopFrmStyle(this.ParentForm);
                }
                frmPrd.PrdDetail(PrdID);
                frmPrd.ShowDialog();
                 
            }
        }
    }
}
