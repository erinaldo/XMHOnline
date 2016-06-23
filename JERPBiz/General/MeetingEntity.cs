/*
$Header$
$Author$
$Date$
$Revision$
*/
using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
namespace JERPBiz.General
{
    /// <描述>
    /// 表[Meeting]数据实体类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2014-11-26 09:46:49
    ///</时间>  
    public class MeetingEntity
    {
        public MeetingEntity()
        {
            this.accData = new JERPData.General.Meeting();
        }
        private JERPData.General.Meeting accData;
        public long MeetingID = -1;
        public DateTime DateMeeting = DateTime.MinValue;
        public string MeetingTitle = string.Empty;
        public string MeetingContent = string.Empty;
        public string MeetingPsns = string.Empty;
        public int MakerPsnID = -1;
        public string MakerPsn = string.Empty;
        public void LoadData(long MeetingID)
        {
            this.MeetingID = MeetingID;
            DataTable dtbl = this.accData.GetDataMeetingByMeetingID(MeetingID).Tables[0];
            if (dtbl.Rows.Count == 0)
            {
                this.DateMeeting = DateTime.MinValue;
                this.MeetingTitle = string.Empty;
                this.MeetingContent = string.Empty;
                this.MeetingPsns = string.Empty;
                this.MakerPsnID = -1;
                this.MakerPsn = string.Empty;
                return;
            }
            DataRow drow = dtbl.Rows[0];
            if (drow["DateMeeting"] == DBNull.Value)
            {
                this.DateMeeting = DateTime.MinValue;
            }
            else
            {
                this.DateMeeting = (DateTime)drow["DateMeeting"];
            }
            if (drow["MeetingTitle"] == DBNull.Value)
            {
                this.MeetingTitle = string.Empty;
            }
            else
            {
                this.MeetingTitle = drow["MeetingTitle"].ToString();
            }
            if (drow["MeetingContent"] == DBNull.Value)
            {
                this.MeetingContent = string.Empty;
            }
            else
            {
                this.MeetingContent = drow["MeetingContent"].ToString();
            }
            if (drow["MeetingPsns"] == DBNull.Value)
            {
                this.MeetingPsns = string.Empty;
            }
            else
            {
                this.MeetingPsns = drow["MeetingPsns"].ToString();
            }
            if (drow["MakerPsnID"] == DBNull.Value)
            {
                this.MakerPsnID = -1;
            }
            else
            {
                this.MakerPsnID = (int)drow["MakerPsnID"];
            }
            if (drow["MakerPsn"] == DBNull.Value)
            {
                this.MakerPsn = string.Empty;
            }
            else
            {
                this.MakerPsn = drow["MakerPsn"].ToString();
            }
        }
    }
}