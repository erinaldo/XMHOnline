using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Tool
{
    public partial class CtrlStatus : UserControl
    {
       
        public CtrlStatus()
        {
            InitializeComponent();
            this.accDa = new JERPData.Tool.Status();
            new ToolTip().SetToolTip(this.cmbItem, "ÓÒ½¡ÐÂÔö");
            this.RefreshData();
            this.cmbItem.MouseDown += new MouseEventHandler(cmbItem_MouseDown);
            this.cmbItem.SelectedIndexChanged +=new EventHandler(cmbItem_SelectedIndexChanged);
        }
        DataTable dtbl;
        JERPData.Tool.Status accDa;
        FrmStatus frmDefine = null;
        void cmbItem_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (frmDefine == null)
                {
                    frmDefine = new FrmStatus();
                    new FrmStyle(frmDefine).SetPopFrmStyle(this);
                    frmDefine.AffterSave += new FrmStatus.AffterSaveDelegate(frmDefine_AffterSave);
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
            dtbl = this.accDa.GetDataStatus().Tables[0];
            this.cmbItem.DataSource = dtbl;
            this.cmbItem.ValueMember = "StatusID";
            this.cmbItem.DisplayMember = "StatusName";
        }
        public int StatusID
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
       
        public string  StatusName
        {
            get
            {
                return this.dtbl.Rows[this.cmbItem.SelectedIndex]["StatusName"].ToString();
            }
        }
        public bool AvailableManufFlag
        {
            get
            {
                return (bool)this.dtbl.Rows[this.cmbItem.SelectedIndex]["AvailableManufFlag"];
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
