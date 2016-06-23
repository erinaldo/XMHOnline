using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Engineer
{
    public partial class FrmPrdPackingOper : Form
    {
        public FrmPrdPackingOper()
        {
            InitializeComponent();
            this.accPackingType = new JERPData.Product.PackingType();
            this.btnAdd.Click += new EventHandler(btnAdd_Click);
            this.FormClosed += new FormClosedEventHandler(FrmPackingOper_FormClosed);
            this.btnSave.Click += new EventHandler(btnSave_Click);
        }

 
        private JERPData.Product.PackingType accPackingType;
        private DataTable dtblPackingType;
        private int prdid = -1;
        private int PrdID
        {
            get
            {
                return this.prdid;
            }
            set
            {
                this.prdid = value;
                this.btnAdd.Enabled = (value > -1);
            }
        }
      
        public delegate void AffterSaveDelegate(int PrdID);
        private AffterSaveDelegate affterSave;
        public event AffterSaveDelegate AffterSave
        {
            add
            {
                affterSave += value;
            }
            remove
            {
                affterSave -= value;
            }
        }
        void FrmPackingOper_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.affterSave != null) this.affterSave(this.PrdID);
        }

        public void PackingOper(int PrdID)
        {
            this.PrdID = PrdID;
            this.tabMain.TabPages.Clear();
            this.dtblPackingType = this.accPackingType.GetDataPackingTypeByPrdID(PrdID).Tables[0];
            foreach (DataRow drow in this.dtblPackingType.Rows)
            {
                int PackingTypeID = (int)drow["PackingTypeID"];
                JERPApp.Define.Product.CtrlPackingTypeOper ctrl = new JERPApp.Define.Product.CtrlPackingTypeOper();
                ctrl.Edit(PackingTypeID);
                ctrl.Dock = DockStyle.Fill;
                ctrl.AffterRemove += new JERPApp.Define.Product.CtrlPackingTypeOper.AffterRemoveDelegate(ctrl_AffterRemove);
                TabPage page = new TabPage();
                page.Text = drow["PackingTypeName"].ToString();
                page.Controls.Add(ctrl);
                this.tabMain.TabPages.Add(page);

            }
        }
        void ctrl_AffterRemove(object sender)
        {
            Control ctrl = (Control)sender;
            TabPage page = (TabPage)ctrl.Parent;
            this.tabMain.TabPages.Remove(page);
        }

        void btnAdd_Click(object sender, EventArgs e)
        {
            JERPApp.Define.Product.CtrlPackingTypeOper ctrl = new JERPApp.Define.Product.CtrlPackingTypeOper();
            ctrl.AffterRemove += new JERPApp.Define.Product.CtrlPackingTypeOper.AffterRemoveDelegate(ctrl_AffterRemove);
            ctrl.New(this.PrdID);
            ctrl.Dock = DockStyle.Fill;
            TabPage page = new TabPage();
            page.Text = "ÐÂ·½°¸";
            page.Controls.Add(ctrl);
            this.tabMain.TabPages.Add(page);
        }
        void btnSave_Click(object sender, EventArgs e)
        {
           
            foreach (TabPage page in this.tabMain.TabPages)
            {
                JERPApp.Define.Product.CtrlPackingTypeOper ctrl = (JERPApp.Define.Product.CtrlPackingTypeOper)page.Controls[0];
                ctrl.Save();
                page.Text = ctrl.PackingTypeName;
            }
        }
    }
}