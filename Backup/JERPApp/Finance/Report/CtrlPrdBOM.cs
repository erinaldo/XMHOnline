using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Report
{
    public partial class CtrlPrdBOM : UserControl
    {
        public CtrlPrdBOM()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accBOM = new JERPData.Product.BOM();
            this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
        }


        private JERPData.Product.BOM accBOM;
        private DataTable dtblBom;
        private JERPApp.Finance .Report.FrmPrdCostPriceDetail  frmPrd;
        private int PrdID = -1;
        public void PrdBom(int PrdID)
        {
            this.PrdID = PrdID;
            this.dtblBom = this.accBOM.GetDataBOMTreeByPrdID(this.PrdID, "     ", "").Tables[0];
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
            for (int i = 0; i < this.dgrdv.Rows.Count; i++)
            {
                this.dgrdv.Rows[i].Visible = ((int)this.dgrdv[this.ColumnParentID.Name, i].Value == this.PrdID);
            }
        }

        
        bool GetParentFlag(int PrdID)
        {
            return (this.dtblBom.Select("ParentID=" + PrdID.ToString()).Length > 0);
        }
        private void SetChildHidden(int irow)
        {
            int PrdID = (int)this.dgrdv[this.ColumnPrdID.Name, irow].Value;
            if ((bool)this.dgrdv[this.ColumnParentFlag.Name, irow].Value)
            {
                this.dgrdv[this.ColumnMark.Name, irow].Value = "+";
            }
            for (int i = irow + 1; i < this.dgrdv.Rows.Count; i++)
            {
                if ((int)this.dgrdv[this.ColumnParentID.Name, i].Value != PrdID) break;               
                this.dgrdv.Rows[i].Visible = false;
                if ((bool)this.dgrdv[this.ColumnParentFlag.Name, i].Value)
                {

                    this.SetChildHidden(i);
                }
              
            }
        }
        private void SetRowVisibled(int irow)
        {
            
            if ((bool)this.dgrdv[this.ColumnParentFlag.Name, irow].Value == false) return;
            int PrdID = (int)this.dgrdv[this.ColumnPrdID.Name, irow].Value;          
            for (int i = irow + 1; i < this.dgrdv.Rows.Count; i++)
            {
                if ((int)this.dgrdv[this.ColumnParentID.Name, i].Value != PrdID) break;              
                this.dgrdv.Rows[i].Visible = !this.dgrdv.Rows[i].Visible;
                if ((this.dgrdv.Rows[i].Visible == false)
                    && ((bool)this.dgrdv[this.ColumnParentFlag.Name, i].Value))
                {
                    this.SetChildHidden(i);
                }
              
            }
        }
   
        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            DataRow drow = this.dtblBom.DefaultView[irow].Row;
            int PrdID = (int)drow["PrdID"];
            if (this.dgrdv.Columns[icol].Name == this.ColumnMark.Name)
            {
                this.SetRowVisibled(irow);
            }
            if (this.dgrdv.Columns[icol].GetType ().Equals (typeof (DataGridViewLinkColumn )))
            { 
                if (frmPrd == null)
                {
                    frmPrd = new FrmPrdCostPriceDetail();
                    new FrmStyle(frmPrd).SetPopFrmStyle(this.ParentForm);
                }
                frmPrd.PrdDetail(PrdID);
                frmPrd.ShowDialog();
                 
            }
        }
    }
}
