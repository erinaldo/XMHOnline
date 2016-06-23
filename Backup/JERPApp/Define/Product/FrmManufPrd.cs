using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Product
{
    public partial class FrmManufPrd : Form
    {
        public FrmManufPrd()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accPrds = new JERPData.Product.Product();
            this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick); 
            this.LoadData();
            this.ctrlPrdTypeID.AffterSelected += this.LoadData;
            this.ctrlQFind.BeforeFilter += this.LoadData;
            this.txtAssistantCode.KeyDown += new KeyEventHandler(txtAssistantCode_KeyDown);
        }

        private JERPData.Product.Product accPrds;
        private JCommon.FrmImgBrowse frmImgBrowse;
        private DataTable dtblPrds;
        private void LoadData()
        {
            
           this.dtblPrds = this.accPrds.GetDataProductForManufPrdByPrdTypeID(this.ctrlPrdTypeID.PrdTypeID).Tables[0];
            this.dgrdv.DataSource = this.dtblPrds;
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
        void txtAssistantCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.dtblPrds = this.accPrds.GetDataProductForManufPrdByAssistantCode (this.txtAssistantCode.Text).Tables[0];
                this.dgrdv.DataSource = this.dtblPrds;
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
            string dir = string.Empty;
           
            if (this.dgrdv.Columns[icol].Name == this.ColumnlnkImgs.Name)
            {
                dir = JERPData.ServerParameter.ERPFileFolder + @"\Product\PrdImg\" + PrdID.ToString() ;
                if (this.frmImgBrowse == null)
                {
                    this.frmImgBrowse = new JCommon.FrmImgBrowse();
                    new FrmStyle(this.frmImgBrowse).SetPopFrmStyle(this);
                    this.frmImgBrowse.ReadOnly = true;
                }
                this.frmImgBrowse.Browse(dir);
                this.frmImgBrowse.ShowDialog();
            }

        }

    }
}