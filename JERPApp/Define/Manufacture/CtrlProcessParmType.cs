using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Manufacture
{
    public partial class CtrlProcessParmType : UserControl
    {
        public CtrlProcessParmType(string ParmTypeName, string DefaultValue, string ItemValues)
        {
            InitializeComponent();       
            this.ckbParmTypeName.Text = ParmTypeName ;
            this.cmbParmValue .Items .Clear ();
            string[] strs = ItemValues.Split(';');
            if (strs.Length > 0)
            {
                foreach (string str in strs)
                {
                    this.cmbParmValue.Items.Add(str);
                }
            }
            if (DefaultValue != string.Empty)
            {
                this.cmbParmValue.Text = DefaultValue;
            }
        }
        public string ParmValue
        {
            get
            {
                if (this.ckbParmTypeName.Checked == false) return string.Empty;
                string rut = this.ckbParmTypeName.Text;
                if (this.cmbParmValue.Text != string.Empty)
                {
                    rut += ":" + this.cmbParmValue.Text;
                }
                return rut;
            }
        }
    }
}
