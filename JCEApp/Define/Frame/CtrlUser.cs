using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
namespace JCEApp.Define.Frame
{
    /// <描述>
    /// 表[BranchStore]控件类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2014-09-29 09:29:43
    ///</时间> 
    public partial class CtrlUser : UserControl
    {
        public CtrlUser()
        {
            InitializeComponent();
            this.accUser = new JCEData.Frame.Users();
            this.LoadData();
        }
        private JCEData.Frame.Users accUser;
        private DataTable dtblUsers;
        private void LoadData()
        {
            this.dtblUsers = this.accUser.GetDataUsers().Tables[0];
            this.cmbItem.DataSource = this.dtblUsers;
            this.cmbItem.ValueMember = "UserID";
            this.cmbItem.DisplayMember = "UserName";
        } 
        public int UserID
        {
            get
            {
                if (this.cmbItem.SelectedIndex == -1) return -1;
                return (int)this.cmbItem.SelectedValue;
            } 
        }
      
        public string UserName
        {
            get
            {
                return this.cmbItem.Text;
            }
        }
      
    }
}