using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
namespace JCEApp.Define.Product
{
    /// <描述>
    /// 表[BranchStore]控件类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2014-09-29 09:29:43
    ///</时间> 
    public partial class CtrlBranchStore : UserControl
    {
        public CtrlBranchStore()
        {
            InitializeComponent();
            this.accBranchStore = new JCEData.Product.BranchStore();
            this.cmbItem.SelectedIndexChanged += new EventHandler(cmbItem_SelectedIndexChanged);
            this.LoadData();
        }
        private JCEData.Product.BranchStore accBranchStore;
        private DataTable dtblBranchStore;
        private void LoadData()
        {
            this.dtblBranchStore = this.accBranchStore .GetDataBranchStore ().Tables[0];          
            this.cmbItem.DataSource = this.dtblBranchStore;
            this.cmbItem.ValueMember = "BranchStoreID";
            this.cmbItem.DisplayMember = "BranchStoreName";
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
        public int BranchStoreID
        {
            get
            {
                if (this.cmbItem.SelectedIndex == -1) return -1;
                return (int)this.cmbItem.SelectedValue;
            }
            set
            {
                if (value == -1)
                {
                    this.cmbItem.SelectedIndex = -1;
                }
                else
                {
                    this.cmbItem.SelectedValue = value;
                }
            }
        }
        private object GetFieldValue(string FieldName)
        {
            if (this.cmbItem.SelectedIndex == -1) return DBNull.Value;
            return this.dtblBranchStore.Rows[this.cmbItem.SelectedIndex][FieldName];
        }
        public string BranchStoreName
        {
            get
            {
                object objValue = this.GetFieldValue("BranchStoreName");
                if (objValue == DBNull.Value)
                {
                    return string.Empty;
                }
                else
                {
                    return objValue.ToString();
                }
            }
        }
     
    }
}