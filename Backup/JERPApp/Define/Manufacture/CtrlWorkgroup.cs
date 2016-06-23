using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Manufacture
{
    public partial class CtrlWorkgroup : UserControl
    {
       
        public CtrlWorkgroup()
        {
            InitializeComponent();         
            this.accWorkgroup = new JERPData.Manufacture.Workgroup();
            this.RefreshData();
         
        }
        private JERPData.Manufacture.Workgroup  accWorkgroup;
        DataTable dtblWorkgroup;
     
        public void RefreshData()
        {
            this.dtblWorkgroup = this.accWorkgroup.GetDataWorkgroup().Tables[0];
            JCommon.Others.SetCtrlBindSrc(this.cmbItem, dtblWorkgroup, "WorkgroupID", "WorkgroupName");
        }
        public int WorkgroupID
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
        public string  WorkgroupName
        {
            get
            {
                if (cmbItem.SelectedIndex == -1) return string.Empty;
                return this.dtblWorkgroup.Rows[this.cmbItem.SelectedIndex]["WorkgroupName"].ToString();
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
            if (this.affterSelected != null) this.affterSelected();
        }
        JERPApp.Manufacture .Define .FrmWorkgroup frmOper = null;
        private void CtrlWorkgroup_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (frmOper == null)
                {
                    frmOper = new JERPApp.Manufacture.Define.FrmWorkgroup();
                    new FrmStyle(frmOper).SetPopFrmStyle(this);
                    frmOper.AffterSave +=frmOper_AffterSave;
                }               
                frmOper.ShowDialog();
            }
        }
        void frmOper_AffterSave()
        {
            int storageAreaID = this.WorkgroupID;
            RefreshData();
            this.WorkgroupID = storageAreaID;
        }
    }
}
