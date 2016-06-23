using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Drawing.Printing;
namespace JERPApp.Config
{
    public partial class FrmPrinter : Form
    {
        public FrmPrinter()
        {
            InitializeComponent();
            this.LoadData();
        }
        private void LoadData()
        {
            //打印机开列表
           cmbNotePrinter.Items.Clear();
           cmbBoxPrinter.Items.Clear();
           foreach (string printer in PrinterSettings.InstalledPrinters)
           {
                cmbNotePrinter.Items.Add(printer);
                cmbBoxPrinter.Items.Add(printer);

                cmbBoxItemPrinter.Items.Add(printer);
           }
           this.cmbNotePrinter.Text =JERPBiz. Config.ConfigInfo .GetNotePrinter ();
           this.cmbBoxPrinter.Text = JERPBiz.Config.ConfigInfo.GetBoxPrinter();
           this.cmbBoxItemPrinter.Text = JERPBiz.Config.ConfigInfo.GetBoxItemPrinter ();      
        }
     
        private void btnRegedit_Click(object sender, EventArgs e)
        {
           
            if (this.cmbNotePrinter.SelectedIndex > -1)
            {
                JERPBiz.Config.ConfigInfo.SetNotePrinter(this.cmbNotePrinter.Text);
            }
         
            if (this.cmbBoxPrinter .SelectedIndex > -1)
            {
                JERPBiz.Config.ConfigInfo.SetBoxPrinter (this.cmbBoxPrinter .Text);
            }
            if (this.cmbBoxItemPrinter.SelectedIndex > -1)
            {
                JERPBiz.Config.ConfigInfo.SetBoxItemPrinter (this.cmbBoxItemPrinter.Text);
            }
            MessageBox.Show("成功保存系统信息");
            this.Close();
        }

       
    }
}