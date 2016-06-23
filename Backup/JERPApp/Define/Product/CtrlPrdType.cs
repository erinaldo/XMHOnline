using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
namespace JERPApp.Define.Product
{
    /// <描述>
    /// 表[PrdType]控件类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2014/3/26 8:42:46
    ///</时间> 
    public partial class CtrlPrdType : UserControl
    {
        public CtrlPrdType()
        {
            InitializeComponent();
            this.accDataPrdType = new JERPData.Product.PrdType();
            this.btnSearch.Click += new EventHandler(btnSearch_Click);
        }

    
        private JERPData.Product.PrdType accDataPrdType;
        private FrmPrdType frmPrdType;     
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
        private bool allowdefine = false;
        public void AllowDefine()
        {
            this.allowdefine = true;
        }
        private int prdtypeid = -1;
        public int PrdTypeID
        {
            get
            {
                return prdtypeid;
            }
            set
            {
                this.prdtypeid = value;
                string typename=string.Empty ;
                this.accDataPrdType.GetParmPrdTypeTreePrdTypeName(value, ref typename);
                this.txtPrdTypeName.Text = typename;
            }
        } 
      
        public string PrdTypeName
        {
            get
            {
                return this.txtPrdTypeName.Text;
            }
        }
        void btnSearch_Click(object sender, EventArgs e)
        {
            if (frmPrdType == null)
            {
                frmPrdType = new FrmPrdType();
                new FrmStyle(this.frmPrdType).SetPopFrmStyle(this.ParentForm);
                if (this.allowdefine)
                {
                    frmPrdType.AllowDefine();
                }
                frmPrdType.AffterSelected += new FrmPrdType.AffterSelectedDelegate(frmPrdType_AffterSelected);
            }
            frmPrdType.ShowDialog();
        }

        void frmPrdType_AffterSelected()
        {
            this.PrdTypeID = frmPrdType.PrdTypeID;
            if (this.affterSelected != null) this.affterSelected();
            this.frmPrdType.Close();
        }
    }
}