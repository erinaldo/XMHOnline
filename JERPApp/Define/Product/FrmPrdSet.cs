using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Product
{
    public partial class FrmPrdSet : Form
    {
        public FrmPrdSet()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accPrds = new JERPData.Product.Product();
            this.ctrlPrdTypeID.AffterSelected += this.LoadData;
            this.ctrlQFind.BeforeFilter += this.LoadData;
            this.dgrdv.ContextMenuStrip = this.cMenu; 
            this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
            this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click); 
            this.LoadData();
        }

     
        private JERPData.Product.Product accPrds;
        private JERPApp.Engineer.Report.FrmPrdSet frmBom;
        private JCommon.FrmImgBrowse frmImgBrowse; 
        private DataTable dtblPrds;
        private void LoadData()
        { 
            this.dtblPrds = this.accPrds.GetDataProductPrdSetByPrdTypeID (this.ctrlPrdTypeID.PrdTypeID).Tables[0]; 
            this.dgrdv.DataSource = this.dtblPrds;
        }
      
        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
        public delegate void AffterSelectedDelegate(DataRow drow);
        private AffterSelectedDelegate affterSelected;
        public event AffterSelectedDelegate AffterSelected
        {
            add
            {
                affterSelected += value;
            }
            remove
            {
                affterSelected -= value;
            }
        }
        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            DataRow drow=this.dtblPrds .DefaultView [irow].Row ;
            if (this.dgrdv.Columns[icol].Name == this.ColumnbtnSelect.Name)
            {          
             if (this.affterSelected != null) this.affterSelected(drow);
            }
            int PrdID = (int)drow["PrdID"]; 
            if (this.dgrdv.Columns[icol].Name == this.ColumnlnkImgs.Name)
            {

                string dir = JERPData.ServerParameter.ERPFileFolder + @"\Product\PrdImg\" + PrdID.ToString();
                if (this.frmImgBrowse == null)
                {
                    this.frmImgBrowse = new JCommon.FrmImgBrowse();
                    new FrmStyle(this.frmImgBrowse).SetPopFrmStyle(this);
                    this.frmImgBrowse.ReadOnly = true;
                }
                this.frmImgBrowse.Browse(dir);
                this.frmImgBrowse.ShowDialog();
                
            }
            if (this.dgrdv.Columns[icol].Name == this.ColumnSetPrdCount .Name)
            {
                if (frmBom == null)
                {
                    frmBom = new JERPApp.Engineer.Report.FrmPrdSet();
                    new FrmStyle(frmBom).SetPopFrmStyle(this);    
                }
                frmBom.PrdSetBom(PrdID);
                frmBom.ShowDialog();
            }
        }

    }
}