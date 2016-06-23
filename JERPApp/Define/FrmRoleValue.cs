using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define
{
    public partial class FrmRoleValue : Form
    {
        public FrmRoleValue()
        {
            InitializeComponent();

            this.accFrm = new JERPData.Frame.Forms();
            this.accFun = new JERPData.Frame.Functions();
            this.accMod = new JERPData.Frame.Modules();
            this.accRole = new JERPData.Frame.Roles();
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnExport.Click += new EventHandler(btnExport_Click);
            this.Shown += new EventHandler(FrmRoleValue_Shown);
            this.ckbAll.CheckedChanged += new EventHandler(ckbAll_CheckedChanged);
            this.lnkCopy.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkCopy_LinkClicked);
        }

             
        private short RoleID = -1;
        private  string RoleValue = string.Empty;    
        private JERPData.Frame.Modules accMod;     
        private JERPData.Frame.Forms accFrm;       
        private JERPData.Frame.Functions accFun;
        private JERPData.Frame.Roles accRole;
        private JERPApp.Define.Frame.FrmRole frmRoleSel;
        private ToolTip tip = new ToolTip();
        public  void SetRoleValue(short RoleID)
        {
            this.RoleID = RoleID;
            DataTable dtblRole = this.accRole.GetDataRolesByRoleID(this.RoleID).Tables[0];
            this.RoleValue = string.Empty;
            if (dtblRole.Rows.Count > 0)
            {
                DataRow drow=dtblRole .Rows [0];
                this.Text = drow["RoleName"].ToString ();
                if ((drow["RoleValue"] == DBNull.Value)||(drow["RoleValue"].ToString ()==string.Empty ))
                { 
                        StringBuilder sb = new StringBuilder();
                        sb.Append('0', 3000);
                        sb[1] = '0';
                        this.RoleValue = sb.ToString();
                }
                else
                {
                    this.RoleValue = drow["RoleValue"].ToString();
                }
                this.lblRoleInfor .Text  = drow ["RoleName"].ToString();
            }
            
           
        }

        void lnkCopy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (frmRoleSel == null)
            {
                frmRoleSel = new JERPApp.Define.Frame.FrmRole();
                new FrmStyle(frmRoleSel).SetPopFrmStyle(this);
                frmRoleSel.AffterSelect += new JERPApp.Define.Frame.FrmRole.AffterSelectDelegate(frmRoleSel_AffterSave);
            }
            frmRoleSel.LoadData();
            frmRoleSel.ShowDialog();
        }

        void frmRoleSel_AffterSave(DataRow drow)
        {
            string rolevalue = drow["RoleValue"].ToString();
            if (rolevalue == string.Empty) return;
            CheckBox ckb;
            Panel pnl;
            if (this.pnlMain.Controls.Count > 0)
            {
                for (int i = 0; i < this.pnlMain.Controls.Count; i++)
                {
                    pnl = (Panel)this.pnlMain.Controls[i];
                    foreach (Control ctrl in pnl.Controls)
                    {
                        if (ctrl.GetType().Equals(typeof(CheckBox)))
                        {
                            ckb = (CheckBox)ctrl;
                            int ck = (int)ckb.Tag;
                            if (rolevalue.Substring(ck - 1, 1) == "1")
                            {
                                ckb.Checked = true;
                            }
                        }
                    }
                }
               
            }
            this.frmRoleSel.Close();
        }
        void FrmRoleValue_Shown(object sender, EventArgs e)
        {
            this.LoadData();           
        }  
        private void LoadData()
        {  
            CheckBox ckb;
            Panel pnl;
            if (this.pnlMain.Controls.Count > 0)
            {
                for (int i = 0; i < this.pnlMain.Controls.Count; i++)
                {
                    pnl = (Panel)this.pnlMain.Controls[i];
                    foreach (Control ctrl in pnl.Controls)
                    {
                        if (ctrl.GetType().Equals(typeof(CheckBox)))
                        {
                            ckb = (CheckBox)ctrl;
                            int ck = (int)ckb.Tag;
                            ckb.Checked = (this.RoleValue.Substring(ck-1, 1) == "1");
                        }
                    }
                }
                return;
            }
            Application.DoEvents();
            DataTable dtblMod = this.accMod.GetDataModuleTreeValidate(0, "    ", "").Tables[0];
          
            Label lbl;
            
            int ckbLeft;
            int top = 0;
            FrmMsg.Show("数据正在加载中,请稍候....");
            foreach (DataRow drowM in dtblMod.Rows)
            {
               
                string ModuleName = drowM["ModuleName"].ToString();
                int ModuleID = (int)drowM["ModuleID"];
                int iBank = ModuleName.Length - ModuleName.Trim().Length;
                pnl = new Panel();
                pnl.BackColor = Color.White;
                pnl.Left = 0;
                pnl.Top = top;
                pnl.Width = 600;
                pnl.Name = "pnl"+ModuleName;
                pnl.Height = 30;
                
                lbl = new Label();
                lbl.BackColor = Color.White;
                lbl.Text = ModuleName;
                lbl.Tag = ModuleID;
                lbl.Top = 5;
                lbl.Left = 2;
                lbl.Cursor = Cursors.Hand ;
                tip.SetToolTip(lbl, "点击全选");
                lbl.AutoSize = true;
                lbl .Click +=new EventHandler(Modulelbl_Click);
                pnl.Controls.Add(lbl);
                this.pnlMain.Controls.Add(pnl);
                top+= 30;
                DataTable dtblForm = this.accFrm.GetDataFormPermitMsgByModule(ModuleID, this.RoleID).Tables[0];
                int i = 0;
               
                foreach (DataRow rowFrm in dtblForm.Rows)
                {
                 
                    pnl = new Panel();
                    pnl.Name = "pnl" + ModuleName+rowFrm["FormName"].ToString ();
                    pnl.BackColor = Color.White;
                    pnl.Height = 30;
                    pnl.Width = 600;
                    pnl.Left = 0;
                    pnl.Top = top;
                    pnl.Tag = ModuleID;
                    this.pnlMain.Controls.Add(pnl);
                    top +=30;
                    
                    lbl = new Label();
                    lbl.BackColor = Color.White;
                    tip.SetToolTip(lbl, "点击全选");
                    lbl.Cursor = Cursors.Hand ;
                    lbl.Click += new EventHandler(Formlbl_Click);
                    lbl.Text = ModuleName.Substring(0, iBank) + "     ♀" + rowFrm["FormName"];
                    lbl.Top = 5;                  
                    lbl.Left = 2;
                  
                   
                    lbl.AutoSize = true;
                    pnl.Controls.Add(lbl);                   
                    ckbLeft = 300;
                    int FormID=(int)rowFrm ["FormID"];
                    DataTable dtblFun = this.accFun.GetDataFunctionPermitMsgByFormID(FormID, this.RoleID).Tables[0];
                    foreach (DataRow rowFun in dtblFun.Rows)
                    {
                        ckb = new CheckBox();
                        ckb.BackColor = Color.White;
                        ckb.Top = 5;
                        ckb.Name = "ckb"+rowFun["FunctionID"].ToString();
                        ckb.Tag = (int)rowFun["FunctionID"];
                        ckb.Text = rowFun["FunctionName"].ToString();
                        ckb.CheckAlign = ContentAlignment.MiddleRight;
                        ckb.Checked = (bool)rowFun["UsableFlag"];
                        ckb.Left = ckbLeft;
                        ckb.AutoSize = true;
                        pnl.Controls.Add(ckb);
                        ckbLeft +=  ckb.Width + 10;
                    }
                    i++;
                }
            }
            if (this.pnlMain.Controls.Count > 0)
            {
                this.pnlMain.Controls[0].Focus();
            }
            FrmMsg.Hide();
        }
        void Modulelbl_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            int ModuleID = (int)lbl.Tag;
            for (int i = 0; i < this.pnlMain.Controls.Count; i++)
            {
                Panel pnl = (Panel)this.pnlMain.Controls[i];
                if (pnl.Tag == null) continue;
                if ((int)pnl.Tag == ModuleID)
                {
                    foreach (Control ctrl in pnl.Controls)
                    {
                        if (ctrl.GetType().Equals(typeof(CheckBox)))
                        {
                            CheckBox ckb = (CheckBox)ctrl;
                            ckb.Checked = !ckb.Checked ;
                        }
                    }
                }
            } 
        }
        void Formlbl_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            Panel pnl = (Panel)lbl.Parent;
            foreach (Control ctrl in pnl.Controls)
            {
                if (ctrl.GetType().Equals(typeof(CheckBox)))
                {
                    CheckBox ckb = (CheckBox)ctrl;
                    ckb.Checked = !ckb.Checked;
                }
            }
        }
        void ckbAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < this.pnlMain.Controls.Count; i++)
            {
                Panel pnl = (Panel)this.pnlMain.Controls[i];
                foreach (Control ctrl in pnl.Controls)
                {
                    if (ctrl.GetType().Equals(typeof(CheckBox)))
                    {
                        CheckBox ckb = (CheckBox)ctrl;
                        ckb.Checked = this.ckbAll.Checked;
                    }
                }
            }      
        }
        void btnSave_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder(this.RoleValue);
            int pos = 0;
            bool flag = false;
            for (int i = 0; i < this.pnlMain.Controls.Count; i++)
            {
                Panel pnl = (Panel)this.pnlMain.Controls[i];
                foreach (Control ctrl in pnl.Controls)
                {
                    if (ctrl.GetType().Equals(typeof(CheckBox)))
                    {
                        CheckBox ckb = (CheckBox)ctrl;
                        pos = (int)ckb.Tag;
                        sb[pos - 1] = ckb.Checked ? '1' : '0';
                    }
                }
            }           
            this.RoleValue = sb.ToString();
            flag = this.accRole.UpdateRolesRoleValue(this.RoleID, this.RoleValue);
            if (flag)
            {
                MessageBox.Show("成功保存了权限设置");
            }
            else
            {
                MessageBox.Show("保存失败!");
            }
        }
        
        void btnExport_Click(object sender, EventArgs e)
        {
            DataTable dtblMenus = new DataTable();
            dtblMenus.Columns.Add("Menu", typeof(string));
            dtblMenus.Columns.Add("FunPermitMsg", typeof(string));
            DataTable dtblModules = this.accMod .GetDataModuleTreeValidate(0, "   ", "").Tables[0];
            DataTable dtblForm;           
            foreach (DataRow drow in dtblModules.Rows)
            {
                string ModuleName = drow["ModuleName"].ToString();
                int iBank = ModuleName.Length - ModuleName.Trim().Length;
                dtblMenus.Rows.Add(drow["ModuleName"], "");

                dtblForm = this.accFrm .GetDataFormPermitMsgByModule((int)drow["ModuleID"], RoleID).Tables[0];
                foreach (DataRow row in dtblForm.Rows)
                {
                    dtblMenus.Rows.Add(ModuleName.Substring(0, iBank) + "   ♀" + row["FormName"], row["FunPermitMsg"]);
                }
            }

            JERPApp.FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder  + @"GeneralShowSheet.xlt");
            excel.SetCellVal("B1", "角色权限表");
            excel.SetCellVal("A2", "角色:" + this.lblRoleInfor .Text );
            int rowIndex = 3;
            int rowcount = dtblMenus.Rows.Count;
            int columnCount = dtblMenus.Columns .Count;
           
            excel.SetCellVal("A3","系统目录");
            excel.SetCellVal("B3", "权限");
            for (int i = 0; i < rowcount; i++)
            {
                rowIndex++;               
                excel.SetCellVal("A"+rowIndex .ToString (), dtblMenus.Rows[i] ["Menu"].ToString ());
                excel.SetCellVal("B" + rowIndex.ToString(), dtblMenus.Rows[i]["FunPermitMsg"].ToString());
            }

            excel.SetRangeInnerBorder(3, 1, rowIndex, columnCount);
            excel.SetRangeAutoFit(3, 1, rowIndex, columnCount, true, false);
            excel.Show();
            JERPApp.FrmMsg.Hide();
        }
    }
}