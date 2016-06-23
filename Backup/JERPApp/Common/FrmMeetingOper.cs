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
    public partial class FrmMeetingOper : Form
    {
        public FrmMeetingOper()
        {
            InitializeComponent();
            this.accMeeting = new JERPData.General.Meeting();
            this.MeetingEntity = new JERPBiz.General.MeetingEntity();
            this.btnDelete.Click += new EventHandler(btnDelete_Click);
            this.btnNew.Click += new EventHandler(btnNew_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
        }

        JERPData.General.Meeting accMeeting;
        JERPBiz.General.MeetingEntity MeetingEntity;
        public delegate void AffterSaveDelegate();
        private AffterSaveDelegate affterSave;
        public event AffterSaveDelegate AffterSave
        {
            add
            {
                affterSave += value;
            }
            remove
            {
                affterSave -= value;
            }
        }
        private long meetingid = -1;
        private long MeetingID
        {
            get
            {
                return this.meetingid;
            }
            set
            {
                this.meetingid = value;
                this.btnDelete.Enabled = (value > -1);
                this.ctrlFileBrowse.ReadOnly = (value == -1);
                if (value == -1)
                {
                    this.ctrlFileBrowse.Clear();
                }
            }
        }
        public void New()
        {
            this.MeetingID  = -1;
            this.dtpDateMeeting.Value = DateTime.Now.Date;
            this.txtMeetingTitle.Text = "每周例会";
            this.rchMeetingContent.Text = string.Empty;
        }
        public void Edit(long MeetingID)
        {
            this.MeetingID = MeetingID;
            this.MeetingEntity.LoadData(MeetingID);
            this.dtpDateMeeting.Value = this.MeetingEntity.DateMeeting ;
            this.txtMeetingTitle.Text = this.MeetingEntity.MeetingTitle ;
            this.txtMeetingPsns.Text = this.MeetingEntity.MeetingPsns;
            this.rchMeetingContent.Text = this.MeetingEntity.MeetingContent ;
            string dir = JERPData.ServerParameter.ERPFileFolder + @"\Common\Meeting\" + MeetingID.ToString();
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            this.ctrlFileBrowse.Browse(dir);
        }
        private bool ValidateData()
        {
            if (this.txtMeetingTitle.Text == string.Empty)
            {
                MessageBox.Show("对不起，标题不能为空");
                return false;
            }
            return true;
        }
        void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateData() == false) return;
            string errormsg = string.Empty;
            bool flag = false;
            if (this.MeetingID == -1)
            {
                object objMeetingID = DBNull.Value;
                flag = this.accMeeting.InsertMeeting(ref errormsg,
                    ref objMeetingID,
                    this.dtpDateMeeting.Value.Date,
                    this.txtMeetingTitle.Text,
                    this.rchMeetingContent .Text ,
                    this.txtMeetingPsns .Text ,
                    JERPBiz .Frame .UserBiz .PsnID);
                if (flag)
                {
                    this.MeetingID = (long)objMeetingID;
                }
            }
            else
            {
                flag = this.accMeeting.UpdateMeeting(ref errormsg,
                    this.MeetingID,
                    this.dtpDateMeeting.Value.Date,
                    this.txtMeetingTitle.Text,
                    this.rchMeetingContent.Text,
                    this.txtMeetingPsns .Text ,
                    JERPBiz .Frame .UserBiz .PsnID );
            }
            if (flag)
            {
                MessageBox.Show("成功保存当前会议记录");
                if (this.affterSave != null) this.affterSave();
            }
            else
            {
                MessageBox.Show(errormsg);
            }
        }

        void btnNew_Click(object sender, EventArgs e)
        {
            this.New();
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
            bool flag = false;
            string errormsg = string.Empty;
            DialogResult rul = MessageBox.Show("您将删除当前会议记录，一经删除不能恢复！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return;
            flag = this.accMeeting.DeleteMeeting(ref errormsg, this.MeetingID);
            if (flag)
            {
                MessageBox.Show("成功删除当前会议记录");              
            }
            else
            {
                MessageBox.Show(errormsg);
            }
            if (this.affterSave != null) this.affterSave();
            this.Close();
        }
    }
}