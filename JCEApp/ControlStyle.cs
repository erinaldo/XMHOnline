using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace JCEApp
{
    public class ControlStyle
    {
        public static  void SetStyle(Control ctrl)
        {
            if (ctrl.GetType().Equals(typeof(TextBox)))
            {
                TextBox txt = (TextBox)ctrl;
                txt.BorderStyle = BorderStyle.FixedSingle;
                ctrl.DoubleClick += new EventHandler(ctrl_DoubleClick);
            }         
            if (ctrl.Controls.Count > 0)
            {
                foreach (Control ctrlChild in ctrl.Controls)
                {
                   SetStyle(ctrlChild);
                }
            }
        }

        static void ctrl_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show(((TextBox)sender).Text);
        }
    }
}
