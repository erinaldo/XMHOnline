using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace JERPApp.Common.Report.Bill
{
    public partial class FrmMeeting : Form
    {
        public FrmMeeting()
        {
            InitializeComponent();
            this.MeetingEntity = new JERPBiz.General.MeetingEntity();
        }
        JERPBiz.General.MeetingEntity MeetingEntity;
        public void Detail(long MeetingID)
        {
            this.MeetingEntity.LoadData(MeetingID);
            this.txtDateMeeting .Text  = this.MeetingEntity.DateMeeting .ToShortDateString ();
            this.txtPsnName.Text = this.MeetingEntity.MeetingPsns ;
            this.txtMeetingTitle.Text = this.MeetingEntity.MeetingTitle  ;
            this.rchMeetingContent.Text = this.MeetingEntity.MeetingContent  ;
            string dir = JERPData.ServerParameter.ERPFileFolder + @"\Common\Meeting\" + MeetingID.ToString();
            if (Directory.Exists(dir))
            {
                this.ctrlFileBrowse.Browse(dir);
            }
            else
            {
                this.ctrlFileBrowse.Clear();
            }
        }
    }
}