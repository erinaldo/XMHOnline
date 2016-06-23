using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Material
{
    public partial class FrmOutStoreReplenishAdjust : Form
    {
        public FrmOutStoreReplenishAdjust()
        {
            InitializeComponent();     
            this.btnSave.Click += new EventHandler(btnSave_Click);
         
        }  
        public delegate void AffterSaveDelegate();
        private AffterSaveDelegate affterSave;
        public event AffterSaveDelegate AffterSave
        {
            add
            {
                affterSave += value;
            }
            remove
            {
                affterSave -= value;
            }
        }
       
        public void AdjustOper()
        {
            this.ctrlOutStoreAjust.AdjustOper();
            this.ctrlOEMOutStoreAdjust .AdjustOper ();
            
            
        } 
      
      
        void btnSave_Click(object sender, EventArgs e)
        {
            
            DialogResult rul = MessageBox.Show("将进行保存入账一经入账不能变更！", "调整确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return;
            this.ctrlOutStoreAjust .Save();
            this.ctrlOEMOutStoreAdjust .Save();  
            MessageBox.Show("成功保存并入账当前单据");
            if (this.affterSave != null) this.affterSave();
            this.Close();

        }
  
     

    }
}