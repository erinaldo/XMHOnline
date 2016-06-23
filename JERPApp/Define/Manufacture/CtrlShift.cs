using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Manufacture
{
    public partial class CtrlShift : UserControl
    {
       
        public CtrlShift()
        {
            InitializeComponent();
            this.accDa = new JERPData.Manufacture.Shift();
            this.RefreshData();
            this.cmbItem.SelectedIndexChanged +=new EventHandler(cmbItem_SelectedIndexChanged);
        }
        DataTable dtbl;
        JERPData.Manufacture.Shift accDa;
        JERPApp.Manufacture .Define .FrmShift frmDefine = null;
        public void AllowDefine()
        {
            new ToolTip().SetToolTip(this.cmbItem, "ÓÒ½¡ÐÂÔö");
            this.cmbItem.MouseDown += new MouseEventHandler(cmbItem_MouseDown);
        }
        void cmbItem_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (frmDefine == null)
                {
                    frmDefine = new JERPApp.Manufacture.Define.FrmShift();
                    new FrmStyle(frmDefine).SetPopFrmStyle(this);
                    frmDefine.AffterSave +=frmDefine_AffterSave;
                }
                frmDefine.ShowDialog();
            }
        }

        void frmDefine_AffterSave()
        {
            this.RefreshData();
        }
        public void RefreshData()
        {
            dtbl = this.accDa.GetDataShift().Tables[0];
            this.cmbItem.DataSource = dtbl;
            this.cmbItem.ValueMember = "ShiftID";
            this.cmbItem.DisplayMember = "ShiftName";
        }
        public int ShiftID
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
        public string ShiftCode
        {
            get
            {
                return this.dtbl.Rows[this.cmbItem.SelectedIndex]["ShiftCode"].ToString();
            }

        }
        public string  ShiftName
        {
            get
            {
                return this.dtbl.Rows[this.cmbItem.SelectedIndex]["ShiftName"].ToString();
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
      
    }
}
