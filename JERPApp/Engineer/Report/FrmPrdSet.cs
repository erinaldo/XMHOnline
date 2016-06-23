using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Engineer.Report
{
    public partial class FrmPrdSet : Form 
    {
        public FrmPrdSet()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accBOM = new JERPData.Product.PrdSet (); 
                    
        } 
        private JERPData.Product.PrdSet  accBOM;  
        private DataTable dtblBom;         
        public void PrdSetBom(int PrdID)
        {
            this.dtblBom = this.accBOM.GetDataPrdSetBySetPrdID(PrdID).Tables[0];
            this.dgrdv.DataSource = this.dtblBom;
        } 
   
    }
}