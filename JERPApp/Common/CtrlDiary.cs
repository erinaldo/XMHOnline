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
    public partial class CtrlDiary : UserControl
    {
        public CtrlDiary()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accDiary = new JERPData.General.Diary();
            ToolTip tip = new ToolTip();
            tip.SetToolTip(this.btnSave, "Ctrl+S");
            tip.SetToolTip(this.btnNew, "Ctrl+N");
            this.dgrdv.RowEnter += new DataGridViewCellEventHandler(dgrdv_RowEnter);
            this.rchDiaryContent.TextChanged += new EventHandler(rchDiaryContent_TextChanged);
            this.btnDelete.Click += new EventHandler(btnDelete_Click);
            this.btnNew.Click += new EventHandler(btnNew_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.radClose.CheckedChanged += rad_CheckedChanged;
            this.radNonClose.CheckedChanged += rad_CheckedChanged;
        }

        private JERPData.General.Diary accDiary;
        private DataTable dtblDiary;
        private int DiaryTypeID = -1;
        void rchDiaryContent_TextChanged(object sender, EventArgs e)
        {
            this.lblInfor.Text = "编辑中...";
        }
        private bool ValidateData()
        {
            if (this.txtDiaryTitle.Text == string.Empty)
            {
                MessageBox.Show("标题不能为空");
                return false;
            }
            return true;
        }

        void rad_CheckedChanged(object sender, EventArgs e)
        {
            this.LoadData();
        }
        public  void Save()
        {
            if (this.ValidateData() == false) return;
            string errormsg = string.Empty;
            bool flag = false;
            if (this.DiaryID == -1)
            {
                object objDiaryID = DBNull.Value;
                flag = this.accDiary.InsertDiary(ref errormsg,
                    ref objDiaryID,
                    JERPBiz.Frame.UserBiz.PsnID ,
                    this.dtpDateDiary.Value.Date,
                    this.txtDiaryTitle.Text,
                    this.rchDiaryContent.Text,
                    this.DiaryTypeID,
                    this.ckbCloseFlag.Checked);
                if (flag)
                {
                    DataRow drowNew = this.dtblDiary.NewRow();
                    drowNew["DiaryID"] = objDiaryID;
                    drowNew["DateDiary"] = this.dtpDateDiary.Value.Date;
                    drowNew["DiaryTitle"] = this.txtDiaryTitle.Text;
                    drowNew["DiaryContent"] = this.rchDiaryContent .Text;
                    drowNew["CloseFlag"] = this.ckbCloseFlag.Checked;
                    this.dtblDiary.Rows.Add(drowNew);
                    this.dgrdv.CurrentCell = this.dgrdv[0,this.dgrdv.Rows.Count - 1];
                    this.DiaryID = (long)objDiaryID;
                }
            }
            else
            {
                flag=this.accDiary .UpdateDiary (ref errormsg ,
                    this.DiaryID ,
                    this.dtpDateDiary .Value .Date ,
                    this.txtDiaryTitle.Text,
                    this.rchDiaryContent.Text,
                    this.DiaryTypeID,
                    this.ckbCloseFlag.Checked);
                if (flag)
                {
                    DataRow drow = this.dtblDiary.DefaultView[this.dgrdv.CurrentRow.Index].Row;
                    drow["DateDiary"] = this.dtpDateDiary.Value.Date;
                    drow["DiaryTitle"] = this.txtDiaryTitle.Text;
                    drow["DiaryContent"] = this.rchDiaryContent.Text;
                    drow["CloseFlag"] = this.ckbCloseFlag.Checked;
                    drow.AcceptChanges();
                }
            }
            if (flag)
            {
                this.lblInfor.Text = "保存完成";
            }
            else
            {
                MessageBox.Show(errormsg);
            }
        }
        void btnSave_Click(object sender, EventArgs e)
        {
            this.Save();

        }
        public  void New()
        {
            this.LoadDetail(-1);
        }
        void btnNew_Click(object sender, EventArgs e)
        {
            this.New();
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
            bool flag = false;
            string errormsg = string.Empty;
            DialogResult rul = MessageBox.Show("您将删除当前的内容，一经删除不能恢复！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return;
            flag = this.accDiary .DeleteDiary(ref errormsg, this.DiaryID );
            if (flag)
            {
                MessageBox.Show("成功进行删除操作");
            }
            else
            {
                MessageBox.Show(errormsg);
            }
        }

       
        private long diaryid = -1;
        private long DiaryID
        {
            get
            {
                return this.diaryid;
            }
            set
            {
                this.diaryid = value;
                this.ctrlFileBrowse.ReadOnly = (value == -1);
                if (value == -1)
                {
                    this.ctrlFileBrowse.Clear();
                }
                else
                {
                    string dir = JERPData.ServerParameter.ERPFileFolder + @"\Common\Diary\" + value.ToString();
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }
                    this.ctrlFileBrowse.Browse(dir);
                }
                this.btnDelete.Enabled = (value > -1);
            }
        }
     
        private void LoadDetail(int irow)
        {
            if (irow == -1)
            {
                this.DiaryID = -1;
                this.txtDiaryTitle.Text = string.Empty;
                this.rchDiaryContent.Text = string.Empty;
                this.ckbCloseFlag.Checked = false;
                this.dtpDateDiary.Value = DateTime.Now.Date;
            }
            else
            {
                DataRow drow = this.dtblDiary.DefaultView[irow].Row;
                this.DiaryID = (long)drow["DiaryID"];
                this.txtDiaryTitle.Text = drow["DiaryTitle"].ToString();
                this.dtpDateDiary.Value = (DateTime)drow["DateDiary"];
                this.ckbCloseFlag.Checked = (bool)drow["CloseFlag"];
                this.rchDiaryContent.Text = drow["DiaryContent"].ToString();
            }
            
        }
        void dgrdv_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.LoadDetail(e.RowIndex);
           
        }
        public void LoadData(int DiaryTypeID)
        {
            this.DiaryTypeID = DiaryTypeID;
            this.LoadData();
        }
        private void LoadData()
        {
            this.dtblDiary = this.accDiary.GetDataDiaryForHandle(JERPBiz.Frame.UserBiz.PsnID,
                this.DiaryTypeID, this.radClose .Checked).Tables[0];
            this.dgrdv.DataSource = this.dtblDiary;
            if (this.dtblDiary.Rows.Count ==0)
            {
                this.LoadDetail(-1);
            }
            
        }
    }
}