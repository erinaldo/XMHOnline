using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Product
{
    public partial class CtrlBadType : UserControl
    {

        public CtrlBadType()
        {
            InitializeComponent();
            this.accBadType = new JERPData.Product.BadType ();
            this.RefreshData();
            this.cmbItem.SelectedIndexChanged +=new EventHandler(cmbItem_SelectedIndexChanged);
        }
        DataTable dtblBadType;
        JERPData.Product.BadType  accBadType;
        FrmBadType frmDefine = null;
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
                    frmDefine = new FrmBadType();
                    new FrmStyle(frmDefine).SetPopFrmStyle(this);
                    frmDefine.AffterSave += this.frmDefine_AffterSave;
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
            dtblBadType = this.accBadType.GetDataBadType().Tables[0];
            dtblBadType.Columns.Add("Exp", typeof(string), "ISNULL(BadTypeCode,'')+ISNULL(BadTypeName,'')");
            this.cmbItem.DataSource = dtblBadType;
            this.cmbItem.ValueMember = "BadTypeID";
            this.cmbItem.DisplayMember = "Exp";
        }
        public int BadTypeID
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
        public string BadTypeCode
        {
            get
            {
                return this.dtblBadType.Rows[this.cmbItem.SelectedIndex]["BadTypeCode"].ToString();
            }

        }
        public string  BadTypeName
        {
            get
            {
                return this.dtblBadType.Rows[this.cmbItem.SelectedIndex]["BadTypeName"].ToString();
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
