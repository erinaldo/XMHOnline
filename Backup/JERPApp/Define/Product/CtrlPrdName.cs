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
    /// 表[CtrlPrdName]控件类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2015/8/31 21:41:55
    ///</时间> 
    public partial class CtrlPrdName : UserControl
    {
        public CtrlPrdName()
        {
            InitializeComponent();
            this.accProduct = new JERPData.Product.Product();
            this.cmbItem.SelectedIndexChanged += new EventHandler(cmbItem_SelectedIndexChanged);
            this.RefreshData();
        }
        private JERPData.Product.Product accProduct;
        private DataTable dtblProduct;
        public  void RefreshData()
        {
            this.dtblProduct = this.accProduct.GetDataProductPrdName().Tables[0];
            this.cmbItem.Items.Clear();
            foreach (DataRow drow in this.dtblProduct.Rows)
            {
                this.cmbItem.Items.Add (drow["PrdName"].ToString ());
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
        private void cmbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.affterSelected != null)
            {
                this.affterSelected();
            }
        }
        public string PrdName
        {
            get
            {
                return this.cmbItem.Text;
            }
            
        }
       
    }
}