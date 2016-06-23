using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace JERPApp
{
    public class FrmStyle 
    {
        Form frm;
     
        public FrmStyle(Form frm)
        {
            this.frm = frm;
            this.frm.KeyPreview = true;            
        }
        private void BasicFrmStyle()
        {
           
            frm.BackColor = SystemColors.ButtonFace;
            frm.FormBorderStyle = FormBorderStyle.Sizable;
            frm.StartPosition = FormStartPosition.Manual ;
            frm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));           
            frm.AutoScroll = true;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.HelpButton = false; 
            frm.ControlBox = true;
            frm.AutoSize = false;
            frm.ShowIcon = false;
            frm.ShowInTaskbar = true;
            if (frm.IsMdiChild)
            {
                frm.ShowInTaskbar = false;
            }          
            frm.SizeChanged += new EventHandler(frm_SizeChanged);
            this.SetCaptionLabel(frm, frm.Width);
            SetControlStyle(frm);
        }

        private void SetCaptionLabel(Control ctrl, int FrmWidth)
        {
            if (ctrl.GetType().Equals(typeof(Label)))
            {
                Label lbl = (Label)ctrl;
                if (lbl.Font.Bold == true)
                {
                    lbl.Left = FrmWidth / 2 - lbl.Width / 2;
                    return;
                }
            }
            else
            {
                if (ctrl.Controls.Count > 0)
                {
                    foreach (Control ctrl_ in ctrl.Controls)
                    {
                        this.SetCaptionLabel(ctrl_, FrmWidth);
                    }
                }
            }

        }
        void frm_SizeChanged(object sender, EventArgs e)
        {

            Form frm = (Form)sender;
            this.SetCaptionLabel(frm, frm.Width);

        }
        public void SetFrmStyle()
        {
            BasicFrmStyle();  
        }
        
        public void SetPopFrmStyle(Control ctrlParent)
        {            
          
            if (ctrlParent.FindForm().IsMdiChild)
            {
                frm.Left = ctrlParent.Left + 300;
                frm.Top = ctrlParent.Top + 100;
            }
            else
            {
                frm.Left = ctrlParent.Left + 100;
                frm.Top = ctrlParent.Top + 80;
               
            }
            if (Screen.PrimaryScreen.WorkingArea.Width -frm .Left  < frm.Width)
            {
                frm.Left = Screen.PrimaryScreen.WorkingArea.Width - frm.Width;
            }
           
            if (Screen.PrimaryScreen.WorkingArea.Height - frm .Top  < frm.Height)
            {
                frm.Top = Screen.PrimaryScreen.WorkingArea.Height - frm.Height;
            }
            if (frm.Top < 0) frm.Top = 0;
            frm.KeyDown += new KeyEventHandler(frm_KeyDown);
            SetFrmStyle();
        }

        private void CatchImg(Form frm)
        {
          
            Bitmap bit = new Bitmap(frm.Width, frm.Height);
            Rectangle rut = new Rectangle(0, 0, frm.Width, frm.Height);
            frm.DrawToBitmap(bit, rut);
            string caption = frm.Text;
            SaveFileDialog filedlg = new SaveFileDialog();
            caption = caption.Replace(" ", "").Replace(":", "_");
            filedlg.FileName = caption;
            filedlg.Filter = "图片文件(*.jpeg)|*.jpeg";
            Clipboard.Clear();

            Clipboard.SetImage(bit);
            if (filedlg.ShowDialog() == DialogResult.OK)
            {
                bit.Save(filedlg.FileName, ImageFormat.Jpeg);
            }
            bit.Dispose();
        }
        void frm_KeyDown(object sender, KeyEventArgs e)
        {
            
            if ((e.Modifiers==Keys .Alt)&&(e.KeyCode  ==Keys .P ))
            {
                CatchImg((Form)sender);
            }
            JERPApp.Config.ShortcutHelper.ShortcutHandle(sender  ,e, false);
        }
     
        public void SetButtonStyle(Button btn)
        {
           
            //btn.FlatStyle = System.Windows.Forms.FlatStyle.System  ;
            btn.MouseHover += new EventHandler(btn_MouseHover);
            btn.MouseLeave += new EventHandler(btn_MouseLeave);
        }
        public void SetTextBoxStyle(TextBox txt)
        {
            new JCommon.MyTextBoxStyle(txt).Decorate();
        }
        public void SetRichTextBoxSyle(RichTextBox rtxt)
        {
            rtxt.AcceptsTab = true;
           
        }
        public void SetTabControlSyl(TabControl tabcontrol)
        {
            tabcontrol.BackColor = Color.Yellow;
        }
        public void SetTabPageStyle(TabPage  tabpage)
        {
            tabpage.BackColor = this.frm.BackColor;
        }
      
        
        //设置窗体中各控件之样式
        public   void  SetControlStyle(Control ctrl)
        {           
            Application.DoEvents();
            if (ctrl.Controls.Count == 0)
            {
                if (JERPBiz.Config.ConfigInfo.GetStyleFontKeyFlag())
                {
                    Font fnt = ctrl.Font;
                    if (fnt.Name.ToLower() != "webdings")
                    {
                        ctrl.Font = new Font(JERPBiz.Config.ConfigInfo.GetStyleFont(), fnt.SizeInPoints , fnt.Style);
                    }  
                }
            }
            if (ctrl.GetType().Equals(typeof(Button)))
            {
                Button btn = (Button)ctrl;
                SetButtonStyle(btn);
              
            }
            if (ctrl.GetType().Equals(typeof(JCommon.MyDataGridView)))
            {
                JCommon.MyDataGridView grid = (JCommon.MyDataGridView)ctrl;
                new JCommon.MydbgrdvStyle(grid).Decorate();
                if (JERPBiz.Config.ConfigInfo.GetStyleFontKeyFlag())
                {                   
                    grid.Font = new System.Drawing.Font(JERPBiz.Config.ConfigInfo.GetStyleFont(), 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));           
                }
            }
            if (ctrl.GetType().Equals(typeof(TextBox)))
            {
                TextBox txt = (TextBox)ctrl;
                new JCommon.MyTextBoxStyle(txt).Decorate();
              
            }
            if (ctrl.GetType().Equals(typeof(RichTextBox)))
            {
                new JCommon.MyRichTextBoxStyle((RichTextBox)ctrl).Decorate();
               
            }
            if (ctrl.GetType().Equals(typeof(ComboBox)))
            {
                ComboBox cmb = (ComboBox)ctrl;
                cmb.FlatStyle = FlatStyle.System;
                cmb.BackColor = Color.White;
                cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend ;
                cmb.AutoCompleteSource = AutoCompleteSource.ListItems ;
                cmb.MaxDropDownItems = 32;
                int width_ = 0;
                System.Drawing.Graphics g = cmb.CreateGraphics();
                for (int i = 0; i < cmb.Items.Count; i++)
                {
                    SizeF size = g.MeasureString(cmb.GetItemText(cmb.Items[i]), cmb.Font);
                    int lng = (int)size.Width;
                    if (lng > width_) width_ = lng;
                }
                cmb.DropDownWidth = width_ +20;
                //if (cmb.ValueMember !=string.Empty )
                //{
                //    cmb.KeyPress += new KeyPressEventHandler(cmb_KeyPress);
                //}
            }
            if (ctrl.GetType().Equals(typeof(Label)))
            {
                if (ctrl.Parent == this.frm.GetChildAtPoint(new Point(0, 0)))
                {
                    ctrl.BackColor = Color.Transparent;
                }

            }         
            if (ctrl.GetType().Equals(typeof(TabPage)))
            {
                TabPage tpg = (TabPage)ctrl;
                this.SetTabPageStyle(tpg);
            }
           
            if (ctrl.GetType().Equals(typeof(GroupBox)))
            {
                ctrl.BackColor = frm.BackColor;

            }            
            foreach (Control ctrl_ in ctrl.Controls)
            {
                SetControlStyle(ctrl_);
            }
        }

        void cmb_KeyPress(object sender, KeyPressEventArgs e)
        {  
            ComboBox cmb = (ComboBox)sender;
            if (cmb.Text == string.Empty) return;
            object objDataSrc = cmb.DataSource;
            string field = cmb.DisplayMember;
            if (objDataSrc.GetType().Equals(typeof(DataTable)))
            {
                DataTable dtbl = (DataTable)objDataSrc;
                AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
                foreach (DataRow drow in dtbl.Select(field + " like '%" + cmb.Text + "%'"))
                {
                    collection.Add(drow[field].ToString());
                }
                cmb.AutoCompleteCustomSource = collection;
            }
            else
            {
                cmb.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
        }
      
        void frmCmb_AffterSelect(object Sender,object objValue)
        {
            ((ComboBox)Sender).SelectedValue = Sender;
        }
        void btn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.ForeColor = Color.Black;
        }

        void btn_MouseHover(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.ForeColor = Color.Tomato;
        }
        [DllImportAttribute("user32.dll")]
        private  static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);
        /*        1. AW_SLIDE : 使用滑动类型, 默认为该类型. 当使用 AW_CENTER 效果时, 此效果被忽略 
         * 2. AW_ACTIVE: 激活窗口, 在使用了 AW_HIDE 效果时不可使用此效果       
         * 3. AW_BLEND: 使用淡入效果        
         * 4. AW_HIDE: 隐藏窗口        
         * 5. AW_CENTER: 与 AW_HIDE 效果配合使用则效果为窗口几内重叠,  单独使用窗口向外扩展.     
         * 6. AW_HOR_POSITIVE : 自左向右显示窗口       
         * 7. AW_HOR_NEGATIVE: 自右向左显示窗口       
         * 8. AW_VER_POSITVE: 自顶向下显示窗口        
         * 9. AW_VER_NEGATIVE : 自下向上显示窗口        */
        public const Int32 AW_HOR_POSITIVE = 0x00000001;
        public const Int32 AW_HOR_NEGATIVE = 0x00000002; 
        public const Int32 AW_VER_POSITIVE = 0x00000004;
        public const Int32 AW_VER_NEGATIVE = 0x00000008;
        public const Int32 AW_CENTER = 0x00000010; 
        public const Int32 AW_HIDE = 0x00010000; 
        public const Int32 AW_ACTIVATE = 0x00020000;
        public const Int32 AW_SLIDE = 0x00040000; 
        public const Int32 AW_BLEND = 0x00080000;
        public static void LoadForm(Form frm)
        {
            AnimateWindow(frm.Handle, 800, AW_SLIDE + AW_CENTER);
        }
        public static void CloseForm(Form frm)
        {
            AnimateWindow(frm.Handle, 800, AW_SLIDE + AW_HIDE + AW_CENTER);
        }
    }
   
}
