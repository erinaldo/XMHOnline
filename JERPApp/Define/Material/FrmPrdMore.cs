using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Material
{
    public partial class FrmPrdMore : Form
    {
        public FrmPrdMore()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlCheckAll.SeachGridView = this.dgrdv;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accPrds = new JERPData.Product.Product();
            this.dgrdv.ContextMenuStrip = this.cMenu;
            this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
            this.ctrlPrdTypeID.AffterSelected += new JERPApp.Define.Product.CtrlPrdTypeTree.AffterSelectDelegate(ctrlPrdTypeID_AffterSelected);
            this.ctrlQFind.BeforeFilter += this.LoadData;
            this.txtAssistantCode.KeyDown += new KeyEventHandler(txtAssistantCode_KeyDown);
            foreach (DataGridViewColumn col in this.dgrdv.Columns)
            {
                col.ReadOnly = true;
            }
            this.ColumnCheckedFlag.ReadOnly = false;
            this.btnSelect.Click += new EventHandler(btnSelect_Click);
            this.btnAll.Click += new EventHandler(btnAll_Click);
            this.LoadData();
        }

        void btnAll_Click(object sender, EventArgs e)
        {
            this.AllFlag = true;
            this.LoadData();
        }

        void ctrlPrdTypeID_AffterSelected()
        {
            this.AllFlag = false ;
            this.LoadData();
        }

        private JERPData.Product.Product accPrds;
        private JCommon.FrmImgBrowse frmImgBrowse;
        private DataTable dtblPrds;
        private bool AllFlag = false;
        private void LoadData()
        {
            if (this.AllFlag)
            {
                this.dtblPrds = this.accPrds.GetDataProductForMaterial().Tables[0];
            }
            else
            {
                this.dtblPrds = this.accPrds.GetDataProductForMaterialByPrdTypeID(this.ctrlPrdTypeID.PrdTypeID).Tables[0];
            }
            this.dtblPrds.Columns.Add("CheckedFlag", typeof(bool));
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
                this.dtblPrds = this.accPrds.GetDataProductForMaterialByAssistantCode(this.txtAssistantCode.Text).Tables[0];
                this.dtblPrds.Columns.Add("CheckedFlag", typeof(bool));
                this.dgrdv.DataSource = this.dtblPrds;
            }
        }
        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            DataRow drow=this.dtblPrds .DefaultView [irow].Row ; 
            int PrdID = (int)drow["PrdID"];
            string dir=string.Empty ;          
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
            if (this.dgrdv.Columns[icol].Name == this.ColumnURL.Name)
            {
                string url = this.dgrdv[icol, irow].Value.ToString();
                if (url == string.Empty) return;
                System.Diagnostics.Process.Start(url);
            }
        }

        void btnSelect_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow grow in this.dgrdv.Rows)
            {
                if (grow.Cells[this.ColumnCheckedFlag.Name].Value  == DBNull.Value) continue;
                if ((bool)grow.Cells[this.ColumnCheckedFlag.Name].Value == false) continue;
                if (this.affterSelected != null) this.affterSelected(this.dtblPrds .DefaultView [grow.Index].Row);
            }
          
        }

    


    }
}