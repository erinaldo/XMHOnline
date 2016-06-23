using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Supply.OutSrc
{
    public partial class FrmFile : Form
    {
        public FrmFile()
        {
            InitializeComponent();
            this.SetPermit();

        }
        //È¨ÏÞÂë
        private bool enableBrowse = false;//ä¯ÀÀ
        private bool enableSave = false;//±£´æ
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(237);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(238);
            if (this.enableBrowse)
            {
                string dir = JERPData.ServerParameter.ERPFileFolder  + @"\Manufacture\OutSrc";
                this.ctrlFileBrowse.Browse(dir);
            }
            this.ctrlFileBrowse.ReadOnly = !this.enableSave;

        }
    }
}