using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Config
{
    public partial class FrmSetStyle : Form
    {
        public FrmSetStyle()
        {
            InitializeComponent();
            this.cmbFont.Items.Clear();
            System.Drawing.Text.InstalledFontCollection fonts = new System.Drawing.Text.InstalledFontCollection();
            foreach (FontFamily ff in fonts.Families)
            {
                this.cmbFont.Items.Add(ff.Name);
            }
            this.cmbFont.Text = JERPBiz.Config.ConfigInfo.GetStyleFont();
            this.btnSet.Click += new EventHandler(btnSet_Click);
        }

        void btnSet_Click(object sender, EventArgs e)
        {
            if (this.cmbFont.Text != string.Empty)
            {
                JERPBiz.Config.ConfigInfo.SetStyleFont(this.cmbFont.Text);
                MessageBox.Show("成功保存字体样式设置,需重进系统生效");
                this.Close();
            }
        }
    }
}