using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture.Boxing
{
    public partial class FrmChipsetCode : Form
    {
        public FrmChipsetCode()
        {
            InitializeComponent();
            this.accBoxItems = new JERPData.Packing.BoxItems();
            this.SetPermit();
        }
        private JERPData.Packing.BoxItems accBoxItems;
          //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(449);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(450);
            if (this.enableBrowse)
            {
                this.lblInfor.Text = string.Empty;
                this.New();
            }
            if (this.enableSave)
            {
                this.txtChipsetCode.KeyDown += new KeyEventHandler(txtChipsetCode_KeyDown);
                this.txtBarcode.KeyDown += new KeyEventHandler(txtBarcode_KeyDown);
            }

        } 
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
            if (e.KeyCode == Keys.Enter)
            {
                bool ExistFlag = false;
                this.accBoxItems.GetParmBoxItemsExistFlag(this.txtBarcode.Text, ref ExistFlag);
                if (ExistFlag ==false)
                {
                    this.lblInfor.Text = "*没有此产品条码！";
                }
                else
                {
                    string errormsg=string.Empty ;
                    this.accBoxItems.UpdateBoxItemsForChipsetCode(ref errormsg,
                        this.txtBarcode .Text ,
                        this.txtChipsetCode.Text);
                    this.lblInfor.Text = "成功进行芯片系列号绑定";
                    this.New();
                }
            }
        }

   
    }
}