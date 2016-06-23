using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Engineer
{
    public partial class FrmBuyer : Form
    {
        public FrmBuyer()
        {
            InitializeComponent();
            this.btnSave.Click += new EventHandler(btnSave_Click);
        }
        
       
        private int PrdID = -1;
        public void Buyer(int PrdID)
        {
            this.PrdID = PrdID;
            this.ctrlPrdBuyer.PrdBuyer (PrdID);
        }
        void btnSave_Click(object sender, EventArgs e)
        {
            this.ctrlPrdBuyer.Save(this.PrdID);
            MessageBox.Show("成功保存当前产品的采购人员");
            this.Close();
        }
    }
}