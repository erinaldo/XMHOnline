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
    /// 表[Diary]数据实体类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2014-11-27 22:29:36
    ///</时间>  
    public class DiaryEntity
    {
        public DiaryEntity()
        {
            this.accData = new JERPData.General.Diary();
        }
        private JERPData.General.Diary accData;
        public long DiaryID = -1;
        public int PsnID = -1;
        public DateTime DateDiary = DateTime.MinValue;
        public string DiaryTitle = string.Empty;
        public string DiaryContent = string.Empty;
        public int DiaryTypeID = -1;
        public bool CloseFlag = false;
        public string PsnCode = string.Empty;
        public string PsnName = string.Empty;
        public string DiaryTypeName = string.Empty;
        public void LoadData(long DiaryID)
        {
            this.DiaryID = DiaryID;
            DataTable dtbl = this.accData.GetDataDiaryByDiaryID(DiaryID).Tables[0];
            if (dtbl.Rows.Count == 0)
            {
                this.PsnID = -1;
                this.DateDiary = DateTime.MinValue;
                this.DiaryTitle = string.Empty;
                this.DiaryContent = string.Empty;
                this.DiaryTypeID = -1;
                this.CloseFlag = false;
                this.PsnCode = string.Empty;
                this.PsnName = string.Empty;
                this.DiaryTypeName = string.Empty;
                return;
            }
            DataRow drow = dtbl.Rows[0];
            if (drow["PsnID"] == DBNull.Value)
            {
                this.PsnID = -1;
            }
            else
            {
                this.PsnID = (int)drow["PsnID"];
            }
            if (drow["DateDiary"] == DBNull.Value)
            {
                this.DateDiary = DateTime.MinValue;
            }
            else
            {
                this.DateDiary = (DateTime)drow["DateDiary"];
            }
            if (drow["DiaryTitle"] == DBNull.Value)
            {
                this.DiaryTitle = string.Empty;
            }
            else
            {
                this.DiaryTitle = drow["DiaryTitle"].ToString();
            }
            if (drow["DiaryContent"] == DBNull.Value)
            {
                this.DiaryContent = string.Empty;
            }
            else
            {
                this.DiaryContent = drow["DiaryContent"].ToString();
            }
            if (drow["DiaryTypeID"] == DBNull.Value)
            {
                this.DiaryTypeID = -1;
            }
            else
            {
                this.DiaryTypeID = (int)drow["DiaryTypeID"];
            }
            if (drow["CloseFlag"] == DBNull.Value)
            {
                this.CloseFlag = false;
            }
            else
            {
                this.CloseFlag = (bool)drow["CloseFlag"];
            }
            if (drow["PsnCode"] == DBNull.Value)
            {
                this.PsnCode = string.Empty;
            }
            else
            {
                this.PsnCode = drow["PsnCode"].ToString();
            }
            if (drow["PsnName"] == DBNull.Value)
            {
                this.PsnName = string.Empty;
            }
            else
            {
                this.PsnName = drow["PsnName"].ToString();
            }
            if (drow["DiaryTypeName"] == DBNull.Value)
            {
                this.DiaryTypeName = string.Empty;
            }
            else
            {
                this.DiaryTypeName = drow["DiaryTypeName"].ToString();
            }
        }
    }
}