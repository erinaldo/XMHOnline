using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Product
{
    public partial class FrmSaleOrderRequire : Form
    {
        public FrmSaleOrderRequire()
        {
            InitializeComponent();
            this.accRequireType = new JERPData.Product.SaleOrderRequireType();
            this.LoadData();
            this.btnConfirm.Click += new EventHandler(btnConfirm_Click);
        }

        private JERPData.Product.SaleOrderRequireType accRequireType;
        private DataTable dtblRequireType;
        private void LoadData()
        {
            this.dtblRequireType = this.accRequireType.GetDataSaleOrderRequireType().Tables[0];
            this.pnlMain.Controls.Clear();
            JERPApp .Define .Product .CtrlSaleOrderRequireType ctrlRequireType;
            foreach (DataRow drow in this.dtblRequireType.Rows)
            {
                ctrlRequireType = new CtrlSaleOrderRequireType(
                    drow["RequireTypeName"].ToString(),
                    drow["DefaultValue"].ToString(),
                    drow["ItemValues"].ToString());
                ctrlRequireType.Dock = DockStyle.Top;                
                this.pnlMain.Controls.Add(ctrlRequireType);
                ctrlRequireType.BringToFront();
            }
        }
        public delegate void AffterConfirmDelegate(string RequireInfor);
        private AffterConfirmDelegate affterConfirm;
        public event AffterConfirmDelegate AffterConfirm
        {
            add
            {
                affterConfirm += value;
            }
            remove
            {
                affterConfirm -= value;
            }
        }
        void btnConfirm_Click(object sender, EventArgs e)
        {
            string requireinfor = string.Empty;
            JERPApp .Define .Product .CtrlSaleOrderRequireType ctrlRequireType;
            for(int i=this.pnlMain .Controls .Count -1;i>-1;i--)
            {
                Control ctrl = this.pnlMain.Controls[i];
                ctrlRequireType = (JERPApp.Define.Product.CtrlSaleOrderRequireType)ctrl;
                if (ctrlRequireType.RequireValue != string.Empty)
                {
                    requireinfor += ctrlRequireType.RequireValue + ";";
                }
            }
            if (this.affterConfirm != null) this.affterConfirm(requireinfor);
            this.Close();
        }
    }
}