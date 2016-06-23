using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Threading;
using System.Diagnostics;
using Microsoft.Win32;
namespace JERPApp
{
    public partial class FrmMain : Form
    {
       
        private JERPData.Frame.Users UsersAc ;
        private delegate void FlushClient();//代理

        public FrmMain()
        {
            InitializeComponent();
            this.pnlNotice.Visible = false;
            this.tabForm.TabChanged += new EventHandler(tabForm_TabChanged);
            this.tabForm.TabClosed += new EventHandler(tabForm_TabClosed);    
            this.treeMenu .NodeMouseClick +=new TreeNodeMouseClickEventHandler(treeMenu_NodeMouseClick);
            this.treeMenu .AfterCollapse +=new TreeViewEventHandler(treeMenu_AfterCollapse);
            this.treeMenu .AfterExpand +=new TreeViewEventHandler(treeMenu_AfterExpand);
            this.treeMenu .BeforeSelect +=new TreeViewCancelEventHandler(treeMenu_BeforeSelect);
            
            this.hasTreeMenu = new Hashtable();
            ctrlAlt = new ToolTip();
            this.TreadMessage = new Thread(new ThreadStart(this.SetMessageInfo));
            this.TreadMessage.IsBackground = true;
            UsersAc = new JERPData.Frame.Users();
            this.accFrms = new JERPData.Frame.Forms();
            this.FormClosed += new FormClosedEventHandler(FrmMain_FormClosed);
            this.pnlNotice.LostFocus += new EventHandler(pnlNotice_LostFocus);
            //调用聊天           
            this.pctRemind.Click += new EventHandler(pctRemind_Click);
            this.spMenu.SplitterMoved += new SplitterEventHandler(spMenu_SplitterMoved);
            ctrlAlt.SetToolTip(this.pctQQ, "客服QQ");
            this.pctQQ.Click += new EventHandler(pctQQ_Click);
        }

   
        private int LastSpMenuLeft = 200;
        DataTable dtblMenu;
        private Thread TreadMessage;
        private DataTable dtblRemindFrms;
        private Hashtable hasTreeMenu;
        private JERPData.Frame.Forms accFrms;
        //建树形目录结构
        private void BuildMenuByUser()
        {
            short  UserID = JERPBiz.Frame.UserBiz.UserID;
            Application.DoEvents();
            this.dtblMenu = UsersAc.GetDataMenuTree (JERPBiz.Frame .Passport .GetPassport (),JERPBiz.Frame.UserBiz.UserPermitCode).Tables [0];
            this.pnlTopMenu.Visible = false;
            this.CreateTopMenu();
            //清除空的       
            this.DeleteNullRow(0);
            this.dtblMenu.AcceptChanges();
            //清除TopMenu
            this.ResetTopMenu();
            this.pnlTopMenu.Visible = true;
            if (this.dtblMenu.Rows.Count > 0)
            {
                this.lblMenu_Click  (this.pnlTopMenu.Controls[this.pnlTopMenu.Controls.Count - 1], null);
            }
            
        }

   

        private void CreateTopMenu()
        {
            DataRow[] drows = this.dtblMenu.Select("ParentID=0 and IsModule=1", "Code", DataViewRowState.CurrentRows);
            Label   lblMenu;
            for (int i = 0; i < drows.Length; i++)
            {
                lblMenu = new Label();
                lblMenu.Tag = drows[i]["ID"];
                lblMenu.Name = drows[i]["Name"].ToString (); 
                lblMenu.Text= drows[i]["Name"].ToString();
                lblMenu.ImageAlign = ContentAlignment.MiddleRight ;
                lblMenu.TextAlign = ContentAlignment.MiddleCenter ;
              
                lblMenu.AutoSize = false;
                lblMenu.Width = 70;
              
                lblMenu.ForeColor = Color.Black   ;
                lblMenu.Dock = DockStyle.Left;
                lblMenu.BackColor = Color.Transparent;
                lblMenu.MouseHover += new EventHandler(lblMenu_MouseHover);
                lblMenu.MouseLeave += new EventHandler(lblMenu_MouseLeave);
                lblMenu.Click += new EventHandler(lblMenu_Click);            
                this.pnlTopMenu.Controls.Add(lblMenu);
                lblMenu.BringToFront();
            }
        }

        void lblMenu_MouseLeave(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            if (lbl.BackColor !=Color.Gray)
            {
                lbl.BackColor = Color.Transparent;
                lbl.ForeColor = Color.Black;
            }
        }

        void lblMenu_MouseHover(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            if (lbl.BackColor != Color.Gray)
            {
                lbl.BackColor = Color.FromArgb(222, 187, 178);
                lbl.ForeColor = Color.White;
            }
           
        }


      
        private void ResetTopMenu()
        {
            for (int i = 0; i < this.pnlTopMenu.Controls.Count; i++)
            {
                Control ctrl = this.pnlTopMenu.Controls[i];
                DataRow[] drows = this.dtblMenu.Select("IsModule=1 and ParentID=0 and ID=" + ctrl.Tag.ToString(), "", DataViewRowState.CurrentRows);
                if (drows.Length == 0)
                {
                    this.pnlTopMenu.Controls.Remove(ctrl);
                    i--;
                }
            }
          
        }
        void lblMenu_Click(object sender, EventArgs e)
        {
            if (this.IsMenuHidden)
            {
                this.pnlMenu.Width = this.LastSpMenuLeft;
                this.IsMenuHidden = false;
            }
            object objKey = this.lblMenuCaption.Tag;
            if (objKey != null)
            {
                TreeNode[] nds=new TreeNode[this.treeMenu .Nodes .Count ];
                for (int i = 0; i < nds.Length; i++)
                {
                    nds[i] = this.treeMenu.Nodes[i];
                }
                if (this.hasTreeMenu.Contains(objKey))
                {
                    this.hasTreeMenu[objKey] = nds;
                }
                else
                {
                    this.hasTreeMenu.Add(objKey, nds);
                }
            }
            Label lbl = (Label)sender;           
            objKey = lbl.Tag;
            this.lblMenuCaption.Tag = objKey ;
            this.treeMenu.Nodes.Clear();
            if (this.hasTreeMenu.Contains(objKey ))
            {
                this.treeMenu.Nodes.AddRange((TreeNode[])this.hasTreeMenu[objKey]);
            }
            else
            {
                int ParentID = (int)lbl.Tag;
                this.InitTree(this.treeMenu.Nodes, ParentID);
             
            }
            foreach (Control ctrl in this.pnlTopMenu.Controls)
            {
                //((Label )ctrl).Image =null;
                //((Label)ctrl).TextAlign = ContentAlignment.MiddleCenter;
                ctrl.BackColor = Color.Transparent;
                ctrl.ForeColor = Color.Black;
            }
            lbl.BackColor = Color.Gray;
            lbl.ForeColor = Color.White;
            //lbl.TextAlign = ContentAlignment.MiddleLeft ;
            //lbl.Image = global::JERPApp.Properties.Resources.topmenubgsel;
        }

        void lnkMenu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.lblMenu_Click(sender, null);
        }

        //建树的基本思路是：从根节点开始递归调用显示子树
        private void InitTree(TreeNodeCollection Nds, int parent_id)//建树的基本思路是：从根节点开始递归调用显示子树
        {          
            foreach (DataRow drv in this.dtblMenu.Select("ParentID=" + parent_id.ToString (),"Code",DataViewRowState .CurrentRows ))
            {
                TreeNode tmpNd = new TreeNode();
                tmpNd.Name  = drv["ID"].ToString();
                if (drv["NameSpace"] != DBNull.Value)
                {
                    tmpNd.Tag = drv["NameSpace"];
                }               
                tmpNd.Text = drv["Name"].ToString();                 
                Nds.Add(tmpNd);
                if ((bool)drv["IsModule"])
                {
                    tmpNd.ImageIndex = 1;                  
                    this.InitTree(tmpNd.Nodes, int.Parse(tmpNd.Name));
                }
                else
                {
                    tmpNd.ImageIndex = 0;
                }

            }

        }
        private bool GetHasChildFlag(int ParentID)
        {
            DataRow[] drows = this.dtblMenu.Select("ParentID=" + ParentID.ToString());
            return (drows.Length > 0);
        }
        private void  DeleteNullRow(int ID)
        {
            DataRow[] drows;
            if (this.GetHasChildFlag(ID))
            {
                drows = this.dtblMenu.Select("IsModule=1 and ParentID=" + ID.ToString());
                foreach (DataRow drowChild in drows)
                {
                    this.DeleteNullRow((int)drowChild["ID"]);
                }
                if (this.GetHasChildFlag(ID)==false )
                {
                    drows = this.dtblMenu.Select("IsModule=1 and ID=" + ID.ToString());                    
                    if (drows .Length >0)
                    {
                        this.dtblMenu.Rows.Remove(drows[0]);
                    }
                }
            }
            else
            {

                drows = this.dtblMenu.Select("IsModule=1 and ID=" + ID.ToString());
                if (drows.Length > 0)
                {
                    this.dtblMenu.Rows.Remove(drows[0]);
                }
            }
           
        }
        private DataTable dtblTreeMenus;
        private void BuildTreeMenu(DataRow drowMenu, string prefix)
        {
            this.dtblTreeMenus.Rows.Add(drowMenu["ID"], prefix + drowMenu["Name"].ToString(), drowMenu["NameSpace"]);
            prefix += "     ";
            if ((bool)drowMenu["IsModule"])
            {
                foreach (DataRow drow in this.dtblMenu.Select("ParentID=" + drowMenu["ID"].ToString()))
                {
                    BuildTreeMenu(drow, prefix);
                }
            }
        }
        private MdiClient GetMdiClient()
        {
            MdiClient mdi = null;
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.GetType().Equals(typeof(MdiClient)))
                {
                    mdi = ctrl as MdiClient;
                    break;
                }
            }
            return mdi;
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {

           
            this.SetStatusInfor("系统加载中,正在加载目录......");
            this.pctRemind.Visible = false;
            this.pctRemind.Cursor = Cursors.Hand;
            MdiClient mdi = this.GetMdiClient();
            mdi.BackColor = Color.White ;
            this.BackgroundImageLayout = ImageLayout.None ;
            this.BackgroundImage = global::JERPApp.Properties.Resources.frmmainbg;
            this.Text = "天衣ERP 用户:" + JERPBiz.Frame.UserBiz.PsnName;
            this.BuildMenuByUser();    
          
            //制treeMenu
            if (this.dtblTreeMenus == null)
            {
                this.dtblTreeMenus = new DataTable();
                this.dtblTreeMenus.Columns.Add("FormID", typeof(int));
                this.dtblTreeMenus.Columns.Add("Menu", typeof(string));
                this.dtblTreeMenus.Columns.Add("NameSpace", typeof(string));
                foreach (DataRow drow in this.dtblMenu.Select("ParentID=0"))
                {
                    this.BuildTreeMenu(drow, "");
                }
            }
            this.ctrlAlt.SetToolTip(this.pctOtherMenu, "系统整体设置");
            this.ctrlAlt.SetToolTip(this.pctRemind , "新任务");
            this.ctrlAlt.SetToolTip(this.pctMenu, "隐藏菜单");       
          
            if (!JERPBiz.Config.ConfigInfo.GetNotePrintKeyFlag  ())
            {
                if (frmPrinter == null)
                {
                    frmPrinter = new JERPApp.Config.FrmPrinter();
                    new FrmStyle(frmPrinter).SetPopFrmStyle(this);
                }
                frmPrinter.ShowDialog();
            }
            //获取提示窗体
            this.SetStatusInfor("正在加载任务窗体......");
            this.dtblRemindFrms = this.accFrms.GetDataFormsRemindByPermitCode(JERPBiz.Frame.UserBiz.UserPermitCode).Tables[0];
            //
            this.SetStatusHidden();
          

            //设置信息
            this.TreadMessage.Start();

            //
        }
       
        public void ShowInMainFrm(int FormID,string FormName,string nameSpace,string StepInfo)
        {
            foreach (Form fr in this.MdiChildren)
            {
                if (fr.Tag.ToString() == FormID.ToString ())
                {
                    this.tabForm.SetTab((object)fr, FormID.ToString (), FormName);
                    return;
                }
            }
            this.SetStatusInfor(FormName + "窗体正在加载中.......");
            System.Reflection.Assembly tempAssembly = System.Reflection.Assembly.GetExecutingAssembly(); 
           
            Form frm = (Form)tempAssembly.CreateInstance(nameSpace);
            frm.MdiParent = this;
            frm.Tag = FormID;
            Application.DoEvents();
            frm.Text = StepInfo;
            frm.Left = 15;
            frm.Top = 15; 
            frm.SizeChanged += new EventHandler(frm_SizeChanged);
            frm.ControlAdded += new ControlEventHandler(frm_ControlAdded);
            Application.DoEvents();
            (new FrmStyle(frm)).SetFrmStyle();
            if (frm.Height > this.Height - 150)
            {
                frm.Height = this.Height - 150;
            }
            if (frm.Width > 880)
            {
                frm.Width = frm.Parent.Width - 30;
                frm.Height = frm.Parent.Height - 30;
            }
            else
            {
                if (frm.Height > 700)
                {
                    frm.Height = frm.Parent.Height - 30;
                }
            }

            Application.DoEvents();
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            this.tabForm.SetTab((object)frm, FormID.ToString (), FormName);
            this.SetStatusHidden();
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
        private TreeNode GetTopNode(TreeNode Node)
        {
            if (Node.Parent == null) return Node;
            return this.GetTopNode(Node.Parent);
        }
     
        private void treeMenu_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode nd = e.Node;
            if (e.X  < nd.Bounds .X-20) return;
            if (nd.Nodes.Count > 0)
            {
                if (nd.IsExpanded)
                {
                    nd.Collapse();
                }
                else
                {
                    nd.Expand();
                }

            }
            if (nd.Tag != null) 
            {
                int FormID=int.Parse (nd.Name); 
                string FormName=nd .Text ;
                string nameSpace=nd.Tag.ToString ();
                DataRow[] drows = this.dtblMenu.Select("IsModule=false and ID=" + FormID.ToString());               
                string SetpInfo = drows[0]["StepInfor"].ToString ();
                this.ShowInMainFrm(FormID, FormName, nameSpace, SetpInfo);
                SendKeys.Send("{TAB}");
                SendKeys.Send("{TAB}");
            }
         
        }
        private void treeMenu_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            e.Cancel = true;

        }

        private void treeMenu_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            TreeNode tmpNd = e.Node;
            if (tmpNd.ImageIndex == 2)
            {
                tmpNd.ImageIndex = 1;
            }
        }

        private void treeMenu_AfterExpand(object sender, TreeViewEventArgs e)
        {
            TreeNode tmpNd = e.Node;
            if (tmpNd.ImageIndex == 1)
            {
                tmpNd.ImageIndex = 2;
            }
        }
        void frm_ControlAdded(object sender, ControlEventArgs e)
        {
            Application.DoEvents();
        }
        void frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form frm = (Form)sender; 
            this.tabForm.CloseCurTab(frm.Tag.ToString());
         
        }               
        void tabForm_TabClosed(object sender, EventArgs e)
        {
                
                Control ctrl = (Control)sender;
                Form frm = (Form)ctrl.Tag;
                if (frm != null)
                {
                    frm.Close();
                }
        }
        void tabForm_TabChanged(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            Form frm = (Form)ctrl.Tag; 
            foreach (Form fr in this.MdiChildren)
            {
                if (fr != frm)
                {
                    fr.Visible = false;
                }
                else
                {
                    try
                    {
                        fr.Visible = true;
                    }
                    catch { }
                }
            }
        }
  
        private bool IsMenuHidden = false;
        private ToolTip ctrlAlt;
        private void pctMenu_Click(object sender, EventArgs e)
        {

            this.pnlMenu.Width = (IsMenuHidden) ? this.LastSpMenuLeft  : 0;
            if (IsMenuHidden)
            {
               // this.pctMenu.Image = global::JERPApp.Properties.Resources.hiddenmenu;
                this.ctrlAlt.SetToolTip(this.pctMenu, "隐藏菜单");
            }
            else
            {
               // this.pctMenu.Image = global::JERPApp.Properties.Resources.showmenu;
                this.ctrlAlt.SetToolTip(this.pctMenu, "显示菜单");
            }

            IsMenuHidden = !IsMenuHidden;
        }
        void spMenu_SplitterMoved(object sender, SplitterEventArgs e)
        {
            this.LastSpMenuLeft = (spMenu.Left > 200) ? spMenu.Left : 200;
        }
        public void SetStatusInfor(string info)
        {
           
            FrmMsg.Show(info);
            Application.DoEvents();
            
        }
        private void SetStatusHidden()
        {
            
            FrmMsg.Hide ();
            Application.DoEvents();
        }
      
        public static void SetStatusInfor(Form frm,string info)
        {
            FrmMain frmain = (FrmMain)frm.ParentForm;
            FrmMsg.Show(info);
            Application.DoEvents();
                     
        }
        public static  void SetStatusHidden(Form frm)
        {
            FrmMain frmain = (FrmMain)frm.ParentForm;
            FrmMsg.Hide();
            Application.DoEvents();
        }
        
        private void pctLock_Click(object sender, EventArgs e)
        {
            this.otherMenu.Show(MousePosition.X - 120, MousePosition.Y + 10);
        }

        void FrmLock_Load(object sender, EventArgs e)
        {            
            this.Visible = false;
        }

        void FrmLock_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Visible = true;
          
        }

        void pnlNotice_LostFocus(object sender, EventArgs e)
        {
            this.pnlNotice.Visible = false;
        }


    

        private void SetUserMenuItem_Click(object sender, EventArgs e)
        {
            JERPApp.Config.FrmUserSelfAdm frmSelftAdm = new JERPApp.Config.FrmUserSelfAdm();
            new FrmStyle(frmSelftAdm).SetPopFrmStyle(this);
            frmSelftAdm.StartPosition = FormStartPosition.CenterParent;
            (new FrmStyle(frmSelftAdm )).SetPopFrmStyle(this);
            frmSelftAdm.ShowDialog();
        }

        private void menuItemLock_Click(object sender, EventArgs e)
        {
              //窗体之锁定
            Form FrmLock = new JERPApp.Config.FrmUnlock();
            FrmLock.Load += new EventHandler(FrmLock_Load);
            FrmLock.FormClosed += new FormClosedEventHandler(FrmLock_FormClosed);
            (new FrmStyle(FrmLock)).SetPopFrmStyle(this);
            FrmLock.StartPosition = FormStartPosition.CenterParent;
            this.SendToBack();
            FrmLock.BringToFront();
            FrmLock.ShowDialog();
        }

       
        Config.FrmAbout frmAbount = null;
        private void MenuItemHelp_Click(object sender, EventArgs e)
        {
            if (frmAbount == null)
            {
                this.frmAbount = new JERPApp.Config.FrmAbout();
                new FrmStyle(frmAbount).SetPopFrmStyle(this);
                frmAbount.StartPosition = FormStartPosition.CenterParent;
            }
            frmAbount.ShowDialog();
        }
      
        private Config.FrmShortcut frmshortcut;
        private void mItemShortcut_Click(object sender, EventArgs e)
        {
            if (frmshortcut == null)
            {
                frmshortcut = new JERPApp.Config.FrmShortcut(this.dtblTreeMenus );
                new FrmStyle(frmshortcut).SetPopFrmStyle(this);
                frmshortcut. StartPosition = FormStartPosition.CenterParent;
            }
            frmshortcut.ShowDialog();
          
        }
        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            JERPApp.Config.ShortcutHelper.ShortcutHandle(this,e, true);
        }
        void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.TreadMessage.IsAlive)
            {
                this.TreadMessage.Abort();
            }
            FrmStyle.CloseForm(this);
        }

      

        //内部交流信息
        private void SetMessageInfo()
        {
            while (true)
            {
                ThreadFunction();
                Thread.Sleep(6000);
            }
        }
        private bool GetRemindFlag(int FormID)
        {
            bool rut = false;
            this.accFrms.GetParmFormsRemindFlag(FormID, JERPBiz.Frame.UserBiz.PsnID, ref rut);
            return rut;
        }
        private void ThreadFunction()
        {
            if (this.pctRemind.InvokeRequired)//等待异步
            {
                FlushClient fc = new FlushClient(ThreadFunction);
                this.Invoke(fc);//通过代理调用刷新方法
            }
            else
            {
                bool RemindFlag = false;
                foreach (DataRow drow in this.dtblRemindFrms.Rows)
                {
                    RemindFlag = this.GetRemindFlag((int)drow["FormID"]);
                    if (RemindFlag) break;
                }
                this.pctRemind.Visible = RemindFlag;
            }
        }


        void pctRemind_Click(object sender, EventArgs e)
        {
            this.pnlNotice.Controls.Clear();
            int top = 10;
            ToolTip tip = new ToolTip();
            LinkLabel lnk;
            foreach (DataRow drow in this.dtblRemindFrms.Rows)
            {
                if (this.GetRemindFlag((int)drow["FormID"]))
                {
                    lnk = new LinkLabel();
                    lnk.Name = drow["FormID"].ToString();
                    lnk.Top = top;
                    lnk.Left = 10;
                    lnk.Tag = (int)drow["FormID"];
                    tip.SetToolTip(lnk, drow["StepInfor"].ToString());
                    lnk.Text = drow["FormName"].ToString();
                    lnk.LinkClicked += new LinkLabelLinkClickedEventHandler(lnk_LinkClicked);
                    lnk.BackColor = Color.Transparent;
                    this.pnlNotice.Controls.Add(lnk);
                    top += 30;
                }
            }
            this.pnlNotice.Visible = true;
            this.pnlNotice.Focus();
        }

        void lnk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.pnlNotice.Visible = false;
            int FormID = (int)(sender as LinkLabel).Tag;
            DataRow[] drows = this.dtblMenu.Select("ID=" + FormID.ToString() + " and IsModule =false");
            if (drows.Length > 0)
            {
                this.ShowInMainFrm(FormID,
                    drows[0]["Name"].ToString(), drows[0]["NameSpace"].ToString(),
                    drows[0]["StepInfor"].ToString());
            }


        }

        private void mmItemCasio_Click(object sender, EventArgs e)
        {
            JCommon.FrmCasio.ShowCasio();
        }
        Config.FrmBackup frmBackup;
        private void mItemBackup_Click(object sender, EventArgs e)
        {
            if (frmBackup == null)
            {
                frmBackup = new JERPApp.Config.FrmBackup();
                new FrmStyle(frmBackup).SetPopFrmStyle(this);
                frmBackup.StartPosition = FormStartPosition.CenterParent;
            }
            frmBackup.ShowDialog();
        }
        Config.FrmPrinter  frmPrinter = null;
        private void SetNotePrinterMenuItem_Click(object sender, EventArgs e)
        {
            if (frmPrinter == null)
            {
                frmPrinter = new JERPApp.Config.FrmPrinter();
                new FrmStyle(frmPrinter).SetPopFrmStyle(this);
                frmPrinter.StartPosition = FormStartPosition.CenterParent;
            }
            frmPrinter.ShowDialog();
        }
        Config.FrmSetStyle frmSetStyle = null;
        private void mItemStyle_Click(object sender, EventArgs e)
        {
            if (frmSetStyle == null)
            {
                frmSetStyle = new JERPApp.Config.FrmSetStyle();
                new FrmStyle(frmSetStyle).SetPopFrmStyle(this);
                frmSetStyle.StartPosition = FormStartPosition.CenterParent;
            }
            frmSetStyle.ShowDialog();
        }
        Config.FrmRemote frmRemote;
        private void mItemRemote_Click(object sender, EventArgs e)
        {
            if (frmRemote == null)
            {
                frmRemote = new JERPApp.Config.FrmRemote();
                new FrmStyle(frmRemote).SetPopFrmStyle(this);
                frmRemote.StartPosition = FormStartPosition.CenterParent;
            }
            frmRemote.ShowDialog();
        }

        private void mItemExpress_Click(object sender, EventArgs e)
        {
            Config.FrmExpress.ExpressPrint();
        }

        private void pctOtherMenu_Click(object sender, EventArgs e)
        {
            this.otherMenu.Show(MousePosition.X - 120, MousePosition.Y + 10);
        }
        void pctQQ_Click(object sender, EventArgs e)
        {
            string QQ = "50062765";
            string arg = "tencent://message/?uin=" + QQ;//请求参数字符串           
            RegistryKey appPath = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Tencent\QQ2009");
            string path = string.Empty;
            if (appPath == null)
            {
                appPath = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Tencent\QQ2009");
            }
            if (appPath != null)
            {
                path = appPath.GetValue("Install") + @"\Bin\Timwp.exe";
                Process.Start(path, arg);
            }
            else
            {
                MessageBox.Show("未装腾讯QQ软件");
            }

        }
    }
}