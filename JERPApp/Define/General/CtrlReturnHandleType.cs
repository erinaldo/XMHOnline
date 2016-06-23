using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.General
{
    public partial class CtrlReturnHandleType : UserControl
    {
       
        public CtrlReturnHandleType()
        {
            InitializeComponent();
            this.accReturnHandleType = new JERPData.General.ReturnHandleType();
            this.RefreshDate();           
        }
        private DataTable dtbl;
        private JERPData.General.ReturnHandleType accReturnHandleType;
        private void RefreshDate()
        {
            dtbl = this.accReturnHandleType.GetDataReturnHandleType().Tables[0];
            JCommon.Others.SetCtrlBindSrc(this.cmbItem, dtbl, "ReturnHandleTypeID", "ReturnHandleTypeName");
        }
       
        public int ReturnHandleTypeID
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
        public string ReturnHandleTypeName
        {
            get
            {
                return this.cmbItem.Text;
            }
           
        }
        public delegate void AffterSelectedDelegate(int ReturnHandleTypeID);
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
            if (affterSelected != null) this.affterSelected(this.ReturnHandleTypeID );
        }
    }
}
