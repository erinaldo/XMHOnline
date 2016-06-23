using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPBiz.General
{
    public partial class FrmFormat : Form
    {
        public static FrmFormat frm;
        private  FrmFormat()
        {
            InitializeComponent();         
            this.btnExport.Click += new EventHandler(btnExport_Click);
        }       
        public static int GetFormatID(DataTable dtblFormat)
        {
            if (dtblFormat.Rows.Count == 1)
            {
                return (int)dtblFormat.Rows[0]["FormatID"];
            }
            if (frm == null)
            {
                frm = new FrmFormat();                
            }
            frm.cmbItem.DataSource = dtblFormat;
            frm.cmbItem.ValueMember = "FormatID";
            frm.cmbItem.DisplayMember = "TmpSheetName";
            frm.ShowDialog();
            return (int)frm.cmbItem.SelectedValue;
        }   
       
     
        void btnExport_Click(object sender, EventArgs e)
        {           
            this.Close();
        }

    }
}