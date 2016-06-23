using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Product
{
    public partial class FrmPrdType : Form
    {
        public FrmPrdType()
        {
            InitializeComponent();
            this.btnConfirm.Click += new EventHandler(btnConfirm_Click);
        }

        void btnConfirm_Click(object sender, EventArgs e)
        {
            if (this.affterSelected != null) this.affterSelected();
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
        public void AllowDefine()
        {
            this.ctrlPrdTypeID.AllowDefine();
        }
        //取得当前        
        public int PrdTypeID
        {
            get
            {
                return this.ctrlPrdTypeID.PrdTypeID;
            }

        }

        public string PrdTypeName
        {
            get
            {
                return this.ctrlPrdTypeID.PrdTypeName;
            }
        } 
    }
}