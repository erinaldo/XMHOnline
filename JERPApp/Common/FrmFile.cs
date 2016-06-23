using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Common
{
    public partial class FrmFile : Form
    {
        public FrmFile()
        {
            InitializeComponent();
            this.ctrlFileBrowse.ReadOnly = false;
            this.SetPermit();

        }
        //È¨ÏÞÂë 
        private bool enableSave = false;//±£´æ
        private void SetPermit()
        {
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(344);
            if (this.enableSave)
            {
                string dir = JERPData.ServerParameter.ERPFileFolder  + @"\UserFile\"+JERPBiz .Frame .UserBiz.UserID  .ToString ();
                this.ctrlFileBrowse.Browse(dir);
            }
            

        }
    }
}