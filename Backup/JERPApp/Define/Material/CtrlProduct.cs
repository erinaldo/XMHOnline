using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Material
{
    public partial class CtrlProduct : UserControl
    {
        public CtrlProduct()
        {
            InitializeComponent();
            this.PrdEntity = new JERPBiz.Product.ProductEntity();
            this.btnSelect.Click += new EventHandler(btnSelect_Click);
        }
        public  JERPBiz.Product.ProductEntity PrdEntity;
        private FrmProduct frmPrd;
        void btnSelect_Click(object sender, EventArgs e)
        {
            if (frmPrd == null)
            {
                frmPrd = new FrmProduct();
                new FrmStyle(frmPrd).SetPopFrmStyle(this.ParentForm);
                frmPrd.AffterSelected += new FrmProduct.AffterSelectedDelegate(frmPrd_AffterSelected);
            }
            frmPrd.ShowDialog();
        }

        void frmPrd_AffterSelected(DataRow drow)
        {
            this.PrdID = (int)drow["PrdID"];
            this.frmPrd.Close();
        }
       
        private int prdID = -1;
        public int PrdID
        {
            get
            {

                return this.prdID;
               
            }
            set
            {
                this.prdID = value;
                this.PrdEntity.LoadData(value);
                this.txtPrdCode.Text = this.PrdEntity.PrdCode;
                this.txtPrdName.Text = this.PrdEntity.PrdName;
                this.txtPrdSpec.Text = this.PrdEntity.PrdSpec+" "+this.PrdEntity .Manufacturer ;
                this.txtModel.Text = this.PrdEntity.Model;
                if (this.affterSelected != null) this.affterSelected();
            }
        }
     
        public delegate void AffterSelectedDelegate();
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
      
    }
}
