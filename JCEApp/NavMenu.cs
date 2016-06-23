using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace JCEApp
{
    public partial class NavMenu : MainMenu 
    {
        public NavMenu()
        {
            InitializeComponent();
            this.ht =new Hashtable ();
            this.AddForm(this.MenuItems, strFrmBoxing);
            this.AddForm(this.MenuItems, strFrmChipset);
            this.AddForm(this.MenuItems, strFrmIntoStore ); 
            this.AddForm(this.MenuItems, strFrmOutStore); 

        }
        private string strFrmBoxing = "装箱";
        private string strFrmChipset = "条码绑定";
        private string strFrmIntoStore = "入库";
        private string strFrmOutStore = "出库";      
        private Form GetForm(string frmname)
        {
            if (ht[frmname] != null)
            {
                return (Form)ht[frmname];
            }
            else
            {
                Form frm=null;
                if (frmname == strFrmBoxing) frm = new FrmBoxing();
                if (frmname == strFrmChipset) frm = new FrmChipset();
                if (frmname == strFrmIntoStore) frm = new FrmIntoStore();
                if (frmname == strFrmOutStore) frm = new FrmOutStore();
                frm.Text = frmname;
                frm.Closed += new EventHandler(frm_Closed);
                ControlStyle.SetStyle(frm);
                this.ht[frmname] = frm;
                return frm;
            }
           
        }
        private void AddForm(MenuItemCollection  mItemCollection,string frmname)
        {
            MenuItem mItem = new MenuItem();
            mItem.Text = frmname;
            mItem.Click += new EventHandler(mItem_Click);
            mItemCollection.Add(mItem);
            this.ht.Add(frmname, null);
        }

       
        void frm_Closed(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void ShowForm(string frmname)
        {
            if (ht.ContainsKey(frmname) == false) return;
            if (frmname == LastFrmName) return;
            Form frm = this.GetForm(frmname);
            if (frm.Menu == null)
            {
                frm.Menu = this;
            }
            frm.Show();
            frm.Top = 0;
            frm.Left = 0;           
            frm.Visible = true;
            frm.WindowState = FormWindowState.Maximized;
            if (LastFrmName != string.Empty)
            {
                Form frmL = (Form)ht[LastFrmName];
                frmL.Visible = false;
            }
            LastFrmName =frmname;
        }
        void mItem_Click(object sender, EventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            this.ShowForm(item.Text);
        }
        private Hashtable   ht;
        private string LastFrmName = string.Empty;  
        public void ShowFirstFrm()
        {
            this.ShowForm(this.strFrmBoxing );
        }        
    }
}
