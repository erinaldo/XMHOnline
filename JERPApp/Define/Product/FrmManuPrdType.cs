using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Product
{
    public partial class FrmManuPrdType : Form
    {
        public FrmManuPrdType()
        {
            InitializeComponent();
            this.ctrlCommonTypeTree.InitiaParam(0);
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
            this.ctrlCommonTypeTree.AllowDefine();
        }
        //取得当前        
        public int PrdTypeID
        {
            get
            {
                return this.ctrlCommonTypeTree.PrdTypeID;
            }

        }

        public string PrdTypeName
        {
            get
            {
                return this.ctrlCommonTypeTree.PrdTypeName;
            }
        } 
    }
}
