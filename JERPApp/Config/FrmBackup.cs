using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Config
{
    public partial class FrmBackup : Form
    {
        public FrmBackup()
        {
            InitializeComponent();
            this.accPath = new JERPData.Frame.BackupPath();
            this.accDBParm = new JERPData.ServerParameter ();
            this.SetPermit();
        }
        private JERPData.Frame.BackupPath accPath;
        private JERPData.ServerParameter  accDBParm;
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(5);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(6);
            if (this.enableBrowse)
            {
                this.LoadData();
                string path = string.Empty ;
                this.accPath.GetParmBackupPath(ref path);
                this.txtBackupPath.Text = path;                
                this.treeFold.NodeMouseClick += new TreeNodeMouseClickEventHandler(treeFold_NodeMouseClick);
            }
            this.btnSave.Enabled = this.enableSave;
            this.btnClear.Enabled = this.enableSave;            
            if (this.enableSave)
            {
                this.btnSave.Click += new EventHandler(btnSave_Click);
                this.btnClear.Click += new EventHandler(btnClear_Click);
             
            }
        }

  
        void btnClear_Click(object sender, EventArgs e)
        {
            this.txtBackupPath.Text = string.Empty;
        }

        void treeFold_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode nd = e.Node;
            this.txtBackupPath.Text = this.GetPath(nd);
            if (nd.Nodes.Count ==0)
            {
                DataTable dtbl = this.accDBParm.GetDataServerFolder(this.txtBackupPath.Text).Tables[0];                
                foreach (DataRow drow in dtbl.Rows)
                {
                    nd.Nodes .Add (drow["subdirectory"].ToString());
                }
                if (dtbl.Rows.Count > 0)
                {
                    nd.Expand();
                }
            }
            
        }

        private string GetPath(TreeNode nd)
        {
            string rut = nd.Text + @"\";
            if (nd.Parent != null)
            {
                rut = this.GetPath(nd.Parent) + rut;
            }
            return rut;


        }
        private void LoadData()
        {
           
            DataTable dtbl = this.accDBParm.GetDataServerFolder("").Tables[0];
            this.treeFold.Nodes.Clear();
            foreach (DataRow drow in dtbl .Rows )
            {
                this.treeFold.Nodes.Add(drow["name"].ToString());
            }

           
        }
        private bool ValidateData()
        {
            if (this.txtBackupPath.Text == string.Empty)
            {
                MessageBox.Show("路径不能为空");
                return false;
            }
            return true;
        }
        void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateData() == false) return;
            string errormsg=string.Empty ;
            bool flag =this.accPath.SaveBackupPath(ref errormsg, this.txtBackupPath.Text);
            if (flag)
            {
                FrmMsg.Show("正在备份数据库...");
                new JERPData.ServerParameter().PM_BackupDatabase(JERPData.ServerParameter.DbName);
                FrmMsg.Hide();    
            }
            else
            {
                MessageBox.Show(errormsg);
            }
            
        }

    }
}