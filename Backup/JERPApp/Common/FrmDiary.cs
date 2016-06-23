using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace JERPApp.Common
{
    public partial class FrmDiary : Form
    {
        public FrmDiary()
        {
            InitializeComponent();
            this.accDiaryType = new JERPData.General.DiaryType();
            this.KeyPreview = true;
            this.SetPermit();
        }
        private JERPData.General.DiaryType accDiaryType;
        private DataTable dtblDiaryType;
      
        //È¨ÏÞÂë
        private bool enableBrowse = false;//ä¯ÀÀ
        private bool enableSave = false;//±£´æ
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(623);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(624);
            if (this.enableBrowse)
            {
                this.LoadData();

            } 
        }

        void FrmDiary_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.tabMain.TabPages.Count == 0) return;
            CtrlDiary ctrlDiary =(CtrlDiary) this.tabMain.SelectedTab.Controls[0];
            if ((e.Modifiers == Keys.Control) && (e.KeyCode == Keys.S))
            {
                ctrlDiary.Save();
            }
            if ((e.Modifiers == Keys.Control) && (e.KeyCode == Keys.N))
            {
                ctrlDiary.New();
            }
        }

        private void LoadData()
        {
            this.dtblDiaryType = this.accDiaryType.GetDataDiaryType().Tables[0];
            this.tabMain.TabPages.Clear();
            TabPage page;
            CtrlDiary ctrlDiary;
            foreach (DataRow drow in this.dtblDiaryType.Rows)
            {
                page = new TabPage();
                page.Text = drow["DiaryTypeName"].ToString();
                ctrlDiary = new CtrlDiary();
                ctrlDiary.LoadData((int)drow["DiaryTypeID"]);
                page.Controls.Add(ctrlDiary);
                ctrlDiary.Dock = DockStyle.Fill;
                this.tabMain.TabPages.Add(page);
            }
        }
    }
}