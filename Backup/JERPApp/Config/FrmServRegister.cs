using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Config
{
    public partial class FrmServRegister : Form
    {
        public FrmServRegister()
        {
            InitializeComponent();
            this.txtPassport.Text = JERPBiz.Frame.Passport.GetPassport();
        }
    }
}