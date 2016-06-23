using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Tool
{
    public partial class CtrlPosition : UserControl
    {
       
        public CtrlPosition()
        {
            InitializeComponent();
            this.accDa = new JERPData.Tool.Position();
            new ToolTip().SetToolTip(this.cmbItem, "ÓÒ½¡ÐÂÔö");
            this.RefreshData();
            this.cmbItem.MouseDown += new MouseEventHandler(cmbItem_MouseDown);
            this.cmbItem.SelectedIndexChanged +=new EventHandler(cmbItem_SelectedIndexChanged);
        }
        DataTable dtbl;
        JERPData.Tool.Position accDa;
        FrmPosition frmDefine = null;
        void cmbItem_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (frmDefine == null)
                {
                    frmDefine = new FrmPosition();
                    new FrmStyle(frmDefine).SetPopFrmStyle(this);
                    frmDefine.AffterSave += new FrmPosition.AffterSaveDelegate(frmDefine_AffterSave);
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
            dtbl = this.accDa.GetDataPosition().Tables[0];
            this.cmbItem.DataSource = dtbl;
            this.cmbItem.ValueMember = "PositionID";
            this.cmbItem.DisplayMember = "PositionName";
        }
        public int PositionID
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
       
        public string  PositionName
        {
            get
            {
                return this.dtbl.Rows[this.cmbItem.SelectedIndex]["PositionName"].ToString();
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
