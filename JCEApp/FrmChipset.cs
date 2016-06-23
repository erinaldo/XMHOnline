using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JCEApp
{
    public partial class FrmChipset : Form
    {
        public FrmChipset()
        {
            InitializeComponent();
            this.accBoxItems = new JCEData.Packing.BoxItems();
            this.txtBarcode.KeyDown += new KeyEventHandler(txtBarcode_KeyDown);
            this.txtChipsetCode.KeyDown += new KeyEventHandler(txtChipsetCode_KeyDown); 
            this.lblInfor.Text = string.Empty;
            this.New();
        }

        private JCEData.Packing.BoxItems accBoxItems;
        private void New()
        {
            this.txtChipsetCode.Text = string.Empty;
            this.txtChipsetCode.Focus();
            this.txtBarcode.Text = string.Empty;

        }
        void txtChipsetCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtBarcode.Focus();
            }
        }

        void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            bool ExistFlag = false;
            this.accBoxItems.GetParmBoxItemsExistFlag (this.txtBarcode.Text, ref ExistFlag );
            if (ExistFlag ==false)
            {
                this.lblInfor.Text = "*没有此产品条码！";
            }
            else
            {
                string errormsg = string.Empty;
                this.accBoxItems.UpdateBoxItemsForChipsetCode(ref errormsg,
                    this.txtBarcode .Text ,
                    this.txtChipsetCode.Text);
                this.lblInfor.Text = "成功进行芯片系列号绑定";
                this.New();
            }
        }
      
        
    }
}