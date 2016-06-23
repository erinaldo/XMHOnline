using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Product
{
    public partial class CtrlSourceType : UserControl
    {

        public CtrlSourceType()
        {
            InitializeComponent();
            this.accSourceType = new JERPData.Product.SourceType();
            this.RefreshDate();
          
           
        }
        private DataTable dtblSourceType;
        private JERPData.Product .SourceType  accSourceType;
        private void RefreshDate()
        {
            dtblSourceType = this.accSourceType.GetDataSourceType ().Tables[0];
            JCommon.Others.SetCtrlBindSrc(this.cmbItem, dtblSourceType, "SourceTypeID", "SourceTypeName");
        }
        public int SourceTypeID
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
        public string  SourceTypeName
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
