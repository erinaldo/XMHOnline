using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Product
{
    public partial class CtrlSaleOrderRequireType : UserControl
    {
        public CtrlSaleOrderRequireType(string RequireTypeName, string DefaultValue, string ItemValues)
        {
            InitializeComponent();       
            this.ckbRequreTypeName.Text = RequireTypeName;
            this.cmbRequireValue .Items .Clear ();
            string[] strs = ItemValues.Split(';');
            if (strs.Length > 0)
            {
                foreach (string str in strs)
                {
                    this.cmbRequireValue.Items.Add(str);
                }
            }
            if (DefaultValue != string.Empty)
            {
                this.cmbRequireValue.Text = DefaultValue;
            }
        }
        public string RequireValue
        {
            get
            {
                if (this.ckbRequreTypeName.Checked == false) return string.Empty;
                string rut = this.ckbRequreTypeName.Text;
                if (this.cmbRequireValue.Text != string.Empty)
                {
                    rut += ":" + this.cmbRequireValue.Text;
                }
                return rut;
            }
        }
    }
}
