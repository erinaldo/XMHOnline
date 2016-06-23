using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.General
{
    public partial class CtrlUnit : UserControl
    {
       
        public CtrlUnit()
        {
            InitializeComponent();
            this.accUnit = new JERPData.General.Unit();
            new ToolTip().SetToolTip(this.cmbItem, "ÓÒ½¡ÐÂÔö");
            this.RefreshDate();
            this.cmbItem.MouseDown += new MouseEventHandler(cmbItem_MouseDown);
           
        }
        private DataTable dtbl;
        private JERPData.General.Unit accUnit;
        private void RefreshDate()
        {
            dtbl = this.accUnit.GetDataUnit().Tables[0];
            JCommon.Others.SetCtrlBindSrc(this.cmbItem, dtbl, "UnitID", "UnitName");
        }
        JERPApp.Define.FrmUnit frmDefine = null;
        void cmbItem_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (frmDefine == null)
                {
                    frmDefine = new JERPApp.Define.FrmUnit();
                    new FrmStyle(frmDefine).SetPopFrmStyle(this);
                    frmDefine.AffterSave += this.RefreshDate;
                }
                frmDefine.ShowDialog();
            }
        }
              
        public int UnitID
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
        public string  UnitName
        {
            get
            {
                return this.cmbItem.Text;
            }
           
        }
        public delegate void AffterSelectedDelegate(int UnitID);
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
            if (affterSelected != null) this.affterSelected(this.UnitID);
        }
    }
}
