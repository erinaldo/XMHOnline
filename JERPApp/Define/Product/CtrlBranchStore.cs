using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Product
{
    public partial class CtrlBranchStore : UserControl
    {

        public CtrlBranchStore()
        {
            InitializeComponent();
            this.accBranchStore = new JERPData.Product.BranchStore();
            this.RefreshDate();
          
           
        }
        private DataTable dtblBranchStore;
        private JERPData.Product .BranchStore  accBranchStore;
        private void RefreshDate()
        {
            dtblBranchStore = this.accBranchStore.GetDataBranchStore ().Tables[0];
            JCommon.Others.SetCtrlBindSrc(this.cmbItem, dtblBranchStore, "BranchStoreID", "BranchStoreName");
            if (this.cmbItem.Items.Count > 0)
            {
                this.cmbItem.SelectedIndex = 0;
            }
        }
  
        void frmDefine_AffterSave()
        {
            this.RefreshDate();
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
                this.cmbItem.SelectedValue = value;
            }
        }
        public string  BranchStoreName
        {
            get
            {
                return this.cmbItem.Text;
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
            if (affterSelected != null) this.affterSelected();
        }
    }
}
