using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.ISO
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
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(431);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(432);
            this.ctrlFileBrowse.ReadOnly = !this.enableSave;
            if (this.enableBrowse)
            {
                string dir = JERPData.ServerParameter.ERPFileFolder + @"\ISO";
                this.ctrlFileBrowse.Browse(dir);
            }
          

        }
    }
}